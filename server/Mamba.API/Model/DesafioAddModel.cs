using System;
using System.Collections.Generic;

namespace Mamba.API.Model
{
    public class DesafioAddModel
    {
        public int IdDesafio { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<QuestaoAddModel> Questoes { get; set; }
    }

    public class QuestaoAddModel
    {
        public int IdQuestao { get; set; }
        public string Descricao { get; set; }
    }
}
