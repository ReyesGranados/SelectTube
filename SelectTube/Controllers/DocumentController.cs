using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelectTube.Models;

namespace SelectTube.Controllers
{
    [ApiController]
    [Route("api/processes/{processId}/candidates/{candidateId}/documents")]
    public class DocumentController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DocumentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult AddDocument(int processId, int candidateId, IFormFile file)
        {
            var process = GetProcessById(processId);
            if (process == null)
            {
                return NotFound();
            }

            var candidate = GetCandidateById(process, candidateId);
            if (candidate == null)
            {
                return NotFound();
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }

            var document = new CandidateDocument
            {
                Id = candidate.Documents.Count + 1,
                Name = file.FileName,
                ContentType = file.ContentType,
                Content = GetFileBytes(file),
            };

            candidate.Documents.Add(document);

            return CreatedAtAction(nameof(GetDocument), new { processId, candidateId, documentId = document.Id }, document);
        }

        [HttpGet("{documentId}")]
        public IActionResult GetDocument(int processId, int candidateId, int documentId)
        {
            var process = GetProcessById(processId);
            if (process == null)
            {
                return NotFound();
            }

            var candidate = GetCandidateById(process, candidateId);
            if (candidate == null)
            {
                return NotFound();
            }

            var document = candidate.Documents.FirstOrDefault(d => d.Id == documentId);
            if (document == null)
            {
                return NotFound();
            }

            return File(document.Content, document.ContentType, document.Name);
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

        private Candidate GetCandidateById(Process process, int id)
        {
            return process.ProcessCandidates.Select(pc => pc.Candidate).FirstOrDefault(c => c.Id == id);
        }

        private byte[] GetFileBytes(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
