import { Character } from './../../models/api/character-model';
import { ApiService } from './../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})

export class DetailComponent implements OnInit{

  public character: Character = new Character({});

  constructor(public service: ApiService, public route: ActivatedRoute){}

  ngOnInit():void{

    let paraId = this.route.snapshot.paramMap.get('id');

    if(paraId){
      this.service.getSigleCharacter(paraId).subscribe(
        (resp) =>{
          this.character = resp
        }
      );
    }
  }
}
