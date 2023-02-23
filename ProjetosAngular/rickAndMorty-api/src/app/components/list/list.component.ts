import { ApiReturn } from './../../models/api-return';
import { ApiService } from './../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Results } from './../../models/api-return';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  public charactersList = new Observable<ApiReturn>();

  public resultsCharac: Results[] | undefined = [];

  constructor(public service: ApiService){}

  ngOnInit(): void{
    this.charactersList = this.service.getCharacter();

    this.charactersList.subscribe(
      (resp)=>{
        console.log(resp);
        this.resultsCharac = resp.results;
        console.log(this.resultsCharac);
      }
    )
  }
}
