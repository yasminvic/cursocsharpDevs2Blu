import { Results } from './../../models/api-return';
import { Observable, Subject } from 'rxjs';
import { ApiService } from './../../service/api.service';
import { Component, OnInit } from '@angular/core';
import { ApiReturn } from 'src/app/models/api-return';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit{

  //vai receber os dados e criar html
  //public pkmList$ = new Observable<ApiReturn>();

  //pode ser tanto um array de results ou undefined, é pra isso que serve essa barra
  //public resultsList$: Results[] | undefined = [];

  //outra forma de fazer
  public resultsList$ = new Subject<Results[] | undefined>();

  constructor(public service: ApiService){}

  //dps do construtor, é disparado esse metodo
  ngOnInit(): void {
    //this.pkmList$ = this.service.getPokemonList();

    //outra forma de fazer
    this.service.getPokemonList().subscribe(
    //this.pkmList$.subscribe(
      (resp) =>{
        console.log(resp);
        //this.resultsList$ = resp.results;
        //outra forma de fazer
        this.resultsList$.next(resp.results);
      }
    );
  }

}

//todo recurso async usamos o cifrao $
