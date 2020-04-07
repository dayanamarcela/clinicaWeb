using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static clinicadotnet.models.PersonaModels;

namespace clinicadotnet.Controllers
{
    [Route("api/[controller]")]
 [ApiController]
 public class PersonaController : ControllerBase
 {
 private readonly PersonaService _personaService;
 public IConfiguration Configuration { get; }
 public PersonaController(IConfiguration configuration)
 {
 Configuration = configuration;
 string connectionString = Configuration["ConnectionStrings:Data source=LAPTOP-UODV76AM/SQLEXPRESS; initial catalog=Clinica; Integrated Security=true"];
 _personaService = new PersonaService(connectionString);
 }
 // GET: api/Persona
 [HttpGet]
 public IEnumerable<PersonaViewModel> Gets()
 {
 var personas = _personaService.ConsultarTodos().Select(p=> new PersonaViewModel(p));
 return personas;
 }
 // GET: api/Persona/5
 [HttpGet("{identificacion}")]
 public ActionResult<PersonaViewModel> Get(string identificacion)
 {
 var persona = _personaService.BuscarPorIdentificacion(identificacion);
 if (persona == null) return NotFound();
 var personaViewModel = new PersonaViewModel(persona);
 return personaViewModel;
 }

 [HttpPost]
 public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
 {
 Persona persona = MapearPersona(personaInput);
 var response = _personaService.Guardar(persona);
 if (response.Error)
 {
 return BadRequest(response.Mensaje);
 }
 return Ok(response.Persona);
 }

private Persona MapearPersona(PersonaInputModel personaInput)
{
 var persona = new Persona
 {
 Identificacion = personaInput.Identificacion,
 Nombre = personaInput.Nombre,
 Salario=personaInput.Salario,
 Servicio= personaInput.Servicio,
 
 };
 return persona;
}

 }
}