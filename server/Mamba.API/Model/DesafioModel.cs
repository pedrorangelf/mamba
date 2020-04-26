using System.Collections.Generic;

namespace Mamba.API.Model
{
    public class DesafioModel
    {
        public string IdDesafio { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<QuestaoModel> Questoes { get; set; }
    }

    public class QuestaoModel
    {
        public int IdQuestao { get; set; }
        public string Descricao { get; set; }
    }
}
