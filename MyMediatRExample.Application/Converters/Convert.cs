using MyMediatRExample.Application.Models;
using MyMediatRExample.Infrastructure.Access;
using MyMediatRExample.OR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMediatRExample.Application.Converters
{
    public static class Convert
    {
        public static Cidade From(CidadeModel cidadeModel)
        {
            Cidade cidade = null;
            if (cidadeModel == null)
                throw new ArgumentNullException("cidadeModel");

            if (cidadeModel.Id != null)
                cidade = BOAccess.getBOFactory().CidadeBO().SelecionarPorId(cidadeModel.Id);

            if (cidade == null)
                cidade = new Cidade();

            cidade.Descricao = cidadeModel.Descricao;

            if (cidadeModel.Uf != null)
                cidade.IdUf = BOAccess.getBOFactory().UfBO().SelecionarPor("Sigla", cidadeModel.Uf);

            if (cidadeModel.Uf == null || cidade.IdUf == null)
                throw new ArgumentException("Uf não informada ou informada incorretamente.");

            return cidade;
        }
    }
}
