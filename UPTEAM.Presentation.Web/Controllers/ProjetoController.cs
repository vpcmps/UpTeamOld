﻿using System.Web.Mvc;
using UPTEAM.AutoMapper.Parses.Interfaces;
using UPTEAM.Domain.ServiceInterfaces;
using UPTEAM.Models;

namespace UPTEAM.Presentation.Web.Controllers
{
    public class ProjetoController : Controller
    {
        public ProjetoController(IProjetoService projetoService, IProjetoModelToTbProjetoParse projetoModelParser, ITbProjetoToProjetoModelParse tbProjetoParser)
        {
            _projetoService = projetoService;
            _projetoModelParser = projetoModelParser;
            _tbProjetoParser = tbProjetoParser;
        }

        private IProjetoService _projetoService { get; }
        private IProjetoModelToTbProjetoParse _projetoModelParser { get; }
        private ITbProjetoToProjetoModelParse _tbProjetoParser { get; }
        public ActionResult Criar()
        {
            var projeto = new ProjetoModel();
            projeto.EquipeProjeto = (int)Session["equipe"];
            return View(projeto);
        }
        [HttpPost]
        public ActionResult Criar(ProjetoModel projetoModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var aux = _projetoModelParser.Parse(projetoModel);
            aux = _projetoService.CriarNovoProjeto(aux);
            return RedirectToAction("Detalhe", aux);
        }

        public ActionResult Detalhe(ProjetoModel projeto)
        {
            return View(projeto);
        }
    }
}