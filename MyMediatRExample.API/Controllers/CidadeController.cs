using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMediatRExample.Application.Commands;
using MyMediatRExample.Application.Converters;
using MyMediatRExample.Application.Models;
using MyMediatRExample.Domain.Enums;
using MyMediatRExample.Infrastructure.Access;
using MyMediatRExample.OR;
using System.Collections.Generic;

namespace MyMediatRExample.API
{
    /// <summary>
    /// Controller da classe <see cref='CidadeController'/>
    /// Gerado por RSClass - Gerador de Classes
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class CidadeController : ControllerBase
    {
        private readonly IMediator mediator;

        public CidadeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// Listar objetos.
        /// </summary>
        /// <param name="uf">O(A) uf.</param>
        /// <returns>A lista.</returns>
        [HttpGet, Route("uf")]
        public IActionResult ListarPorUf(string uf)
        {
            Uf uf_tmp = BOAccess.getBOFactory().UfBO().SelecionarPor("Sigla", uf);
            if (uf_tmp == null)
                return this.StatusCode(404, new ResponseModel() { StatusCode = 404, Message = "Nenhuma UF encontrada com esta sigla." });

            return Ok(BOAccess.getBOFactory().CidadeBO().ListarPorUf(uf_tmp));
        }
        /// <summary>
        /// Selecionar um objeto.
        /// </summary>
        /// <param name="id">O ID do objeto.</param>
        /// <returns>O objeto selecionado.</returns>
        [HttpGet, Route("{id:long}")]
        public IActionResult SelecionarPorId(long id)
        {
            Cidade cidade = BOAccess.getBOFactory().CidadeBO().SelecionarPorId(id);
            if (cidade == null)
                return StatusCode(StatusCodes.Status404NotFound, new { statusCode = StatusCodes.Status404NotFound, message = "Nenhum registro encontrado." });

            return Ok(cidade);
        }
        /// <summary>
        /// Listar objetos por uma propriedade específica.
        /// </summary>
        /// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
        /// <returns>A lista ordenada.</returns>
        [HttpGet, Route("{propertyOrder?}")]
        public IList<MyMediatRExample.OR.Cidade> Listar(string propertyOrder = null)
        {
            return BOAccess.getBOFactory().CidadeBO().Listar(propertyOrder);
        }
        /// <summary>
        /// Inserir um objeto no banco de dados.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> InserirAsync(CidadeModel cidade)
        {
            Command<Cidade> command = new Command<Cidade>()
            {
                Action = Operacao.Inclusão,
                Data = Convert.From(cidade)
            };
            ResponseModel response = await mediator.Send(command);
            return this.StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Altera um objeto no banco de dados.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        /// <returns>O objeto após a persistência.</returns>
        [HttpPut]
        public async System.Threading.Tasks.Task<IActionResult> AlterarAsync(CidadeModel cidade)
        {
            if (cidade.Id == null)
                return this.StatusCode(400, new ResponseModel() { StatusCode = 400, Message = "Informe o ID da cidade que deseja alterar." });

            Command<Cidade> command = new Command<Cidade>()
            {
                Action = Operacao.Alteração,
                Data = Convert.From(cidade)
            };
            ResponseModel response = await mediator.Send(command);
            return this.StatusCode(response.StatusCode, response);
        }
        /// <summary>
        /// Exclui o objeto do banco de dados.
        /// </summary>
        /// <param name="cidade">O(A) cidade.</param>
        [HttpDelete, Route("{id:long}")]
        public async System.Threading.Tasks.Task<IActionResult> ExcluirAsync(long id)
        {
            Cidade cidade = BOAccess.getBOFactory().CidadeBO().SelecionarPorId(id);
            if (cidade == null)
                return this.StatusCode(404, new ResponseModel() { StatusCode=404, Message="Nenhum registro encontrado com este ID."});

            Command<Cidade> command = new Command<Cidade>()
            {
                Action = Operacao.Exclusão,
                Data = cidade
            };
            ResponseModel response = await mediator.Send(command);
            return this.StatusCode(response.StatusCode, response);
        }
        /// <summary>
    }
}
