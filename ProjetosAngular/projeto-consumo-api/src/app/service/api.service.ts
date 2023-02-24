import { ApiReturn } from './../models/api-return';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pokemon } from '../models/api/pokemon-model';

//quer dizer que pode injetar ele em qualquer lugar
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public URL_API:string = 'https://pokeapi.co/api/v2/pokemon';

  constructor(public http: HttpClient) { }

  //metodo
  getPokemonList(){
    //http é o parametro no no construtor
    //vai retornar o tipo ApiReturn
    //nesse momento é feito o Bind, ele pega os dados da api e preenche na classe
      return this.http.get<ApiReturn>(this.URL_API);
  }

  getPokemonByName(name: string){
    return this.http.get<Pokemon>(`${this.URL_API}/${name}`);
  }
}

//Observable: recuros assincrno, registra ação.
