using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamba.API.Model
{
    public class EmpresaModel
    {
        public int? IdEmpresa { get; set; }
        public int CodigoCidade { get; set; }
        public string Nome { get; set; }
        public int CNPJ { get; set; }
        public string Descricao { get; set; }
        public string Logo { get; set; }

        // ATRIBUTOS PADRÕES DE CONTROLE
        public int? CodigoUsuarioCadastro { get; set; }
    }
}
