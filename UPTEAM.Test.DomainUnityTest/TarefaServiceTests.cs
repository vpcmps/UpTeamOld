﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPTEAM.Infra.Data.Repositories;
using UPTEAM.Domain.Entities;
using System.Linq;

namespace UPTEAM.ApplicationServices.Tests
{
    [TestClass()]
    public class TarefaServiceTests
    {
        private TarefaService _tarefaService;
        private tb_tarefa _tarefaTeste;
        public TarefaServiceTests()
        {
            _tarefaService = new TarefaService(new TarefaRepository());
        }
        [TestMethod()]
        public void CriarNovaTarefaTest()
        {
            var tarefa = new tb_tarefa()
            {
                nme_tarefa = "UpTeamTeste@@"
            };

            _tarefaService.CriarNovaTarefa(tarefa);
            _tarefaTeste = _tarefaService.BuscarTarefasPorNome(tarefa.nme_tarefa).FirstOrDefault();
            Assert.IsNotNull(_tarefaTeste);
        }
        [TestMethod()]
        public void AlterarTarefaTest()
        {
            _tarefaTeste.nme_tarefa = "UpTeamTeste@@1234";
            _tarefaService.AlterarTarefa(_tarefaTeste);
            var tarefaBanco = _tarefaService.BuscarTarefa(_tarefaTeste.idt_tarefa);
            Assert.AreEqual(_tarefaTeste, tarefaBanco);
        }
        [TestMethod()]
        public void AlterarTarefaInexistenteTest()
        {
            tb_tarefa tarefa = new tb_tarefa()
            {
                idt_tarefa = 0
            };
            _tarefaService.AlterarTarefa(tarefa);
            var tarefaBanco = _tarefaService.BuscarTarefa(tarefa.idt_tarefa);
            Assert.AreEqual(tarefa, tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefaTest()
        {
            var tarefaBanco = _tarefaService.BuscarTarefa(_tarefaTeste.idt_tarefa);
            Assert.IsNotNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefaInexistenteTest()
        {
            var tarefaBanco = _tarefaService.BuscarTarefa(0);
            Assert.IsNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorNomeTest()
        {
            var tarefaBanco = _tarefaService.BuscarTarefasPorNome(_tarefaTeste.nme_tarefa);
            Assert.IsNotNull(tarefaBanco);
        }
        [TestMethod()]
        public void BuscarTarefasPorNomeInexistenteTest()
        {
            var tarefaBanco = _tarefaService.BuscarTarefasPorNome("UpTeamTesteInexistente@@1234");
            Assert.IsNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorNomeEmBrancoTest()
        {
            var tarefaBanco = _tarefaService.BuscarTarefasPorNome("");
            Assert.IsNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorProjetoTest()
        {
            var projeto = new tb_projeto()
            {
                idt_projeto = 1
            };
            var tarefaBanco = _tarefaService.BuscarTarefasPorProjeto(projeto);
            Assert.IsNotNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorProjetoInexistenteTest()
        {
            var projeto = new tb_projeto()
            {
                idt_projeto = 0
            };
            var tarefaBanco = _tarefaService.BuscarTarefasPorProjeto(projeto);
            Assert.IsNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorSprintTest()
        {
            var sprint = new tb_sprint()
            {
                idt_sprint = 1
            };
            var tarefaBanco = _tarefaService.BuscarTarefasPorSprint(sprint);
            Assert.IsNotNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorSprintInexistenteTest()
        {
            var sprint = new tb_sprint()
            {
                idt_sprint = 0
            };
            var tarefaBanco = _tarefaService.BuscarTarefasPorSprint(sprint);
            Assert.IsNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorUsuarioTest()
        {
            var usuario = new tb_usuario()
            {
                idt_usuario = 1
            };
            var tarefaBanco = _tarefaService.BuscarTarefasPorUsuario(usuario);
            Assert.IsNotNull(tarefaBanco);
        }

        [TestMethod()]
        public void BuscarTarefasPorUsuarioInexistenteTest()
        {
            var usuario = new tb_usuario()
            {
                idt_usuario = 0
            };
            var tarefaBanco = _tarefaService.BuscarTarefasPorUsuario(usuario);
            Assert.IsNull(tarefaBanco);
        }

        [TestMethod()]
        public void DeletarTarefaTest()
        {
            _tarefaService.DeletarTarefa(_tarefaTeste);
            var tarefaBanco = _tarefaService.BuscarTarefa(_tarefaTeste.idt_tarefa);
            Assert.IsNull(tarefaBanco);
        }
    }
}
