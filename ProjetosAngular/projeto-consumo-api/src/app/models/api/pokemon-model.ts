export class Pokemon{
  name?: string;
  order?: number;
  weight?: number;
  height?: number;
  id?: number;
  base_experience?: number;
  sprites?: Sprite = new Sprite({});

  //onde faz o bind
  constructor(obj: Partial<Pokemon>){
    Object.assign(this, obj);
  }
}

export class Sprite{
  back_default?: string;
  back_female?: string;
  back_shiny?: string;
  back_shiny_female?: null;
  front_default?: string;
  front_female?: string;
  front_shiny?: string;
  front_shiny_female?: string;

  constructor(obj: Partial<Pokemon>){
    Object.assign(this, obj)
  }
}
