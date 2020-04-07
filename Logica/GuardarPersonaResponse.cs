
using Entity;

namespace Logica
{
    public class GuardarPersonaReponse
    {
        public GuardarPersonaReponse(Persona persona){
           Error = false;
           Persona = persona;
         }
    public GuardarPersonaReponse(string mensaje){
      Error = true;
      Mensaje = mensaje;
}
public bool Error { get; set; }
public string Mensaje { get; set; }
public Persona Persona { get; set; }
}




    }
