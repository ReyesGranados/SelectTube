using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SelectTube.Models;

namespace SelectTube.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController : ControllerBase
    {
        private static List<Process> _processes = new List<Process>
        {
            new Process { Id = 1, Nombre = "Proceso 1", FechaCreacion = DateTime.Now, FechaComienzo = DateTime.Now.AddDays(1), FechaFinalizacion = DateTime.Now.AddDays(10), Estado = ProcessStatus.Borrador },
            new Process { Id = 2, Nombre = "Proceso 2", FechaCreacion = DateTime.Now, FechaComienzo = DateTime.Now.AddDays(3), FechaFinalizacion = DateTime.Now.AddDays(20), Estado = ProcessStatus.Reclutando },
            new Process { Id = 3, Nombre = "Proceso 3", FechaCreacion = DateTime.Now, FechaComienzo = DateTime.Now.AddDays(5), FechaFinalizacion = DateTime.Now.AddDays(30), Estado = ProcessStatus.Finalizado }
        };

        [HttpGet]
        public IActionResult GetProcesses()
        {
            return Ok(_processes);
        }

        [HttpPost]
        public IActionResult AddProcess([FromBody] Process newProcess)
        {
            if (newProcess == null)
            {
                return BadRequest("El objeto de proceso es nulo.");
            }

            // Asignar un nuevo ID al proceso
            int newId = _processes.Count + 1;
            newProcess.Id = newId;

            // Establecer la fecha de creación del proceso
            newProcess.FechaCreacion = DateTime.Now;

            // Agregar el proceso a la lista de procesos
            _processes.Add(newProcess);

            return CreatedAtAction(nameof(GetProcessById), new { id = newProcess.Id }, newProcess);
        }

        [HttpGet("{id}")]
        public IActionResult GetProcessById(int id)
        {
            Process process = _processes.Find(p => p.Id == id);

            if (process == null)
            {
                return NotFound($"No se encuentra el proceso con ID {id}.");
            }

            return Ok(process);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProcess(int id)
        {
            var process = _processes.FirstOrDefault(p => p.Id == id);
            if (process == null)
            {
                return NotFound("Process not found");
            }

            _processes.Remove(process);
            return NoContent();
        }
    }
}
