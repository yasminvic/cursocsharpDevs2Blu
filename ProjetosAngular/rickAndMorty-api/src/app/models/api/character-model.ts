export class Character{
  name?:string;
  image?: string;
  species?: string;
  status?:string;
  gender?: string;
  origin?: CharacterProperties;
  location?: CharacterProperties;

  constructor(obj: Partial<Character>){
    Object.assign(this, obj);
  }
}

export class CharacterProperties{
  name?: string;
  url?: string;

  constructor(obj: Partial<Character>){
    Object.assign(this, obj);
  }
}
