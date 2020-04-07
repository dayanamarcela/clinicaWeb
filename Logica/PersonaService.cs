using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class PersonaService
    {
        private readonly ConnectionManager _conexion;
        private readonly PersonaRepository _repositorio; 

        public PersonaService(string connectionString){
            _conexion=new ConnectionManager(connectionString);
            _repositorio = new PersonaRepository(_conexion);
        }

        public GuardarPersonaReponse Guardar(Persona persona){
         try{
             persona.CalcularCopago();
             _conexion.Open();
             _repositorio.Guardar(persona);
             _conexion.Close();
        return new GuardarPersonaReponse(persona);
         }
          catch (Exception e) {
         return new GuardarPersonaReponse($"Error de la Aplicacion: {e.Message}");
         }

 finally { _conexion.Close(); }
 }

          public List<Persona> ConsultarTodos(){
           _conexion.Open();
          List<Persona> personas = _repositorio.ConsultarTodos();
          _conexion.Close();
           return personas;
          }
        
        
          public Persona BuscarPorIdentificacion(string identificacion){
              this._conexion.Open();
              Persona persona=new Persona();
              return persona= this._repositorio.BuscarPorIdentificacion(identificacion);

          }




    }
}