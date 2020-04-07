using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;


namespace Datos
{
    public class PersonaRepository
    {
        public readonly SqlConnection _connection;
        public readonly List<Persona>_personas =new List<Persona>();

        public PersonaRepository(ConnectionManager connection){
            _connection= connection._conexion; 
        }

        public void Guardar(Persona persona){
            using(var command= _connection.CreateCommand()){
                command.CommandText=@"insert into Persona (Identificacion,Nombre,Salario,Servicio,Copago)
                values (@Identificacion,@Nombre,@Salario,@Servicio,@Copago)";
                command.Parameters.AddWithValue ("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue ("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue ("@Salario", persona.Salario);
                command.Parameters.AddWithValue ("@Servicio", persona.Servicio);
                command.Parameters.AddWithValue ("@Copago", persona.Copago);
                var filas = command.ExecuteNonQuery();                
            }

        }

        public List<Persona> ConsultarTodos(){

          SqlDataReader dataReader;

          List<Persona> personas = new List<Persona>();

           using (var command = _connection.CreateCommand()){

             command.CommandText = "Select * from persona ";

             dataReader = command.ExecuteReader();

             if (dataReader.HasRows){

                 while (dataReader.Read()){

                  Persona persona = DataReaderMapToPerson(dataReader);

                  personas.Add(persona);

                 }

            }
return personas;
         }



     }
    
    public Persona BuscarPorIdentificacion(string identificacion){

     SqlDataReader dataReader;

     using (var command = _connection.CreateCommand()){

         command.CommandText = "select * from persona where Identificacion=@Identificacion";

         command.Parameters.AddWithValue("@Identificacion", identificacion);

         dataReader = command.ExecuteReader();

         dataReader.Read();

return DataReaderMapToPerson(dataReader);

}

}

   private Persona DataReaderMapToPerson(SqlDataReader dataReader){

     if(!dataReader.HasRows) return null;

     Persona persona = new Persona();

     persona.Identificacion = (string)dataReader["Identificacion"];

     persona.Nombre = (string)dataReader["Nombre"];

     persona.Salario=(double)dataReader["Salario"];

     persona.Servicio=(double)dataReader["Servicio"];

     persona.Copago=(double)dataReader["Copago"];

return persona;

   }



}


}