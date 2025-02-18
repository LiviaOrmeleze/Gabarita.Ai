namespace Gabarita.Ai.Models
{
    public class Materias
    {
        public Guid MateriasId { get; set; }
        public string MateriasNome { get; set; }

        public Guid CategoriaMateriaId { get; set; }
        public CategoriaMateria? CategoriaMateria { get; set; }
    }
}
