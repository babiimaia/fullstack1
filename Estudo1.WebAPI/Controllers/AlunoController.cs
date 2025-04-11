﻿using Estudo1.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estudo1.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServico _servico;
        public AlunoController(IAlunoServico servico)
        {
            _servico = servico;
        }
        [HttpPost]
        public IActionResult Adicionar(AlunoDto dto)
        {
            _servico.Adicionar(dto);
            return Ok("Aluno adicionado com sucesso");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_servico.Listar());
        }
    }
}