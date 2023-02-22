//arquivo que lida com a api, é um molde da api


export class ApiReturn {
  count?: number;
  next?: string;
  previous?: string;
  //usando um array do tipo Results, da classe que criamos abaixo
  results?: Results[];

  constructor(obj: Partial<ApiReturn>){
    //cria um objeto com base noq tu passa
    //ele cria campos baseado noq tu passa, ent pode ter os mesmos objetos com quantidades difeerentes de campos
    Object.assign(this, obj);
  }
}

//classe que cuida dos pokemons
export class Results{
  name?: string;
  url?: string;

  constructor(obj: Partial<ApiReturn>){
    //cria um objeto com base noq tu passa
    //ele cria campos baseado noq tu passa, ent pode ter os mesmos objetos com quantidades difeerentes de campos
    Object.assign(this, obj);
  }
}
