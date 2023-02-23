export class ApiReturn{
  info?: InfoApi[];
  results?: Results[];

  constructor(obj: Partial<ApiReturn>){
    Object.assign(this, obj);
  }
}

export class InfoApi{
  count?:number;
  pages?:number;
  prev?:string;

  constructor(obj: Partial<ApiReturn>){
    Object.assign(this, obj);
  }
}

export class Results{
  name?:string;
  url?: string;

  constructor(obj: Partial<ApiReturn>){
    Object.assign(this, obj);
  }
}


