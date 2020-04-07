using Entity;

namespace clinicadotnet.models
{
    public class PersonaModels
    {
        public class PersonaInputModel
        {
       public string Nombre { get; set; }
       public string Identificacion { get; set; }
       
       public double Salario { get; set; }

       public double Servicio { get; set; }

 
      }

      public class PersonaViewModel : PersonaInputModel
 {
        public PersonaViewModel() {
 }
 public PersonaViewModel(Persona persona)
 {
 Identificacion = persona.Identificacion;
 Nombre = persona.Nombre;
 Salario= persona.Salario;
 Servicio=persona.Servicio;
 Copago= persona.Copago;
 }
 public double Copago { get; set; }
 }


    }
}