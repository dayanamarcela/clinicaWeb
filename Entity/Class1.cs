using System;

namespace Entity
{
    public class Persona
    {
        public string Identificacion {get; set;  }
        public string Nombre {get; set;  }
        public double Salario {get; set;  }
        public double Servicio {get; set;  }
        public double Copago {get; set; }


        public double CalcularCopago(){
            if(this.Salario>2500000){
                this.Copago= this.Servicio*0.2;
            }else{
                this.Copago= this.Servicio*0.1;
            }
            return this.Copago;
        }
    }
}
