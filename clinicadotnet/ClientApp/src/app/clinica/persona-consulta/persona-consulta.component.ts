import { Component, OnInit } from '@angular/core';
import { Persona } from '../models/persona';
import { PersonaService } from '../../services/persona.service';
@Component({
selector: 'app-persona-consulta',
templateUrl: './persona-consulta.component.html',
styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {
personas:Persona[];
constructor(private PersonaService: PersonaService) { }
ngOnInit() {
this.PersonaService.get().subscribe(result => {
this.personas = result;
});

}
}


