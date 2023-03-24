using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SelectTube.Models;

namespace SelectTube.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidateController : ControllerBase
    {
        // POST api/candidates/{processId}
        [HttpPost("{processId}")]
        public IActionResult AddCandidateFromProcess(int processId, [FromBody] Candidate candidate)
        {
            if (candidate == null)
            {
                return BadRequest();
            }

            var process = GetProcessById(processId);
            if (process == null)
            {
                return NotFound();
            }

            var processCandidate = new ProcessCandidate
            {
                Id = process.ProcessCandidates.Count + 1,
                Candidate = candidate,
                Process = process,
                DateIncluded = DateTime.UtcNow,
                Status = CandidateStatus.Selected
            };

            process.ProcessCandidates.Add(processCandidate);

            return CreatedAtAction(nameof(ListCandidatesFromProcess), new { processId }, process.ProcessCandidates.Select(pc => pc.Candidate));
        }

        // GET api/candidates/process/{processId}
        [HttpGet("process/{processId}")]
        public IActionResult ListCandidatesFromProcess(int processId)
        {
            var process = GetProcessById(processId);
            if (process == null)
            {
                return NotFound();
            }

            return Ok(process.ProcessCandidates.Select(pc => pc.Candidate));
        }

        // DELETE api/candidates/{processId}/{candidateId}
        [HttpDelete("{processId}/{candidateId}")]
        public IActionResult DeleteCandidateFromProcess(int processId, int candidateId)
        {
            var process = GetProcessById(processId);
            if (process == null)
            {
                return NotFound();
            }

            var processCandidate = process.ProcessCandidates.FirstOrDefault(pc => pc.Candidate.Id == candidateId);
            if (processCandidate == null)
            {
                return NotFound();
            }

            process.ProcessCandidates.Remove(processCandidate);

            return Ok();
        }

        private Process GetProcessById(int id)
        {
            var processController = new ProcessController();
            var processes = processController.GetProcesses() as OkObjectResult;

            if (processes != null)
            {
                return (processes.Value as List<Process>).FirstOrDefault(p => p.Id == id);
            }

            return null;
        }
    }
}
