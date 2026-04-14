namespace Aula4.Models
{
    public class Local
    {
        public string Nome { get; set; }
        public int FaixaEtariaRecomendada { get; set; }
        public string Endereco { get; set; }
        public string TipoLocal { get; set; }

        public static List<Local> Lista
        {
            get
            {
                var lista = new List<Local>
                {
                    new()  { Nome = "Bar do Xina", FaixaEtariaRecomendada = 30, Endereco = "Av. Principal, 1000", TipoLocal = "Bar" },
                    new()  { Nome = "Balada eletrônica", FaixaEtariaRecomendada = 20, Endereco = "Rua das Telas, 500", TipoLocal = "Club" },
                    new()  { Nome = "Festival do Som", FaixaEtariaRecomendada = 18, Endereco = "Praça da Cultura, 200", TipoLocal = "Festival" }
                };

                return lista;
            }
        }
    }
}