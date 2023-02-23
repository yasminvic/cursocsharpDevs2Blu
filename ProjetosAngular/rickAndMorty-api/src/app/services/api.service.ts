import { ApiReturn } from './../models/api-return';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public URL_API: string = "https://rickandmortyapi.com/api/character";

  constructor(public http: HttpClient) { }

  getCharacter(){
    return this.http.get<ApiReturn>(this.URL_API);
  }
}
