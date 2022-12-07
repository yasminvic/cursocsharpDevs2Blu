namespace Devs2Blu.ReceitasProjetoMVC.Models.Receita
{
    public class Recipe
    {
        public string Thumbnail_Url { get; set; }
        public string Name { get; set; }
        public string Original_Video_Url { get; set; }
        public int MyProperty { get; set; }
        public List<Step> Instructions { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}