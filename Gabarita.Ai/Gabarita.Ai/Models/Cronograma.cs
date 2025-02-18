using System;
using System.Collections.Generic;

namespace Gabarita.Ai.Models
{
    public class Cronograma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<Materia> Materias { get; set; }
        public List<TarefaDiaria> TarefasDiarias { get; set; }
        public List<TarefaSemanal> TarefasSemanais { get; set; }
        public List<TarefaMensal> TarefasMensais { get; set; }

        public Cronograma()
        {
            Materias = new List<Materia>();
            TarefasDiarias = new List<TarefaDiaria>();
            TarefasSemanais = new List<TarefaSemanal>();
            TarefasMensais = new List<TarefaMensal>();
        }
    }

    public class Materia
    {
        public string Nome { get; set; }
        public TimeSpan TempoEstudo { get; set; }
    }

    public class TarefaDiaria
    {
        public DateTime Data { get; set; }
        public List<Materia> Materias { get; set; }

        public TarefaDiaria()
        {
            Materias = new List<Materia>();
        }
    }

    public class TarefaSemanal
    {
        public int Semana { get; set; }
        public List<Materia> Materias { get; set; }

        public TarefaSemanal()
        {
            Materias = new List<Materia>();
        }
    }

    public class TarefaMensal
    {
        public int Mes { get; set; }
        public List<Materia> Materias { get; set; }

        public TarefaMensal()
        {
            Materias = new List<Materia>();
        }
    }
}
