import { Pokemon } from './../../models/api/pokemon-model';
import { ApiService } from './../../service/api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit{

  //vai ser usado para passar as informações no html
  public pokemon:Pokemon = new Pokemon({});

  constructor(public service: ApiService,
              //pra pegar parametro de rota, usa isso aqui
              public route: ActivatedRoute){}

  ngOnInit(): void {

    let paraName = this.route.snapshot.paramMap.get('name');
    if(paraName){
      //buscar o pokemon por nome
      this.service.getPokemonByName(paraName).subscribe(
        (resp) =>{
          this.pokemon = resp;
        }
      )
    }
  }
}
