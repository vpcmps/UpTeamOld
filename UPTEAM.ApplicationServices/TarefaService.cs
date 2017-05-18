﻿using System.Collections.Generic;
using System.Linq;
using UPTEAM.Domain.Entities;
using UPTEAM.Domain.ServiceInterfaces;
using UPTEAM.Infra.Data.Repositories;

namespace UPTEAM.ApplicationServices
{
    public class TarefaService : ITarefaService
    {
        private TarefaRepository _repositorio;

        public TarefaService(TarefaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void AlterarTarefa(tb_tarefa tarefa)
        {
            _repositorio.Update(tarefa);
        }

        public tb_tarefa BuscarTarefa(int idTarefa)
        {
            return _repositorio.GetById(idTarefa);
        }

        public List<tb_tarefa> BuscarTarefasPorNome(string nomeTarefa)
        {
            return _repositorio.GetByName(nomeTarefa).ToList();
        }

        public List<tb_tarefa> BuscarTarefasPorProjeto(tb_projeto projeto)
        {
            return _repositorio.GetByProject(projeto.idt_projeto).ToList();
        }

        public List<tb_tarefa> BuscarTarefasPorSprint(tb_sprint sprint)
        {
            return _repositorio.GetBySprint(sprint.idt_sprint).ToList();
        }

        public List<tb_tarefa> BuscarTarefasPorUsuario(tb_usuario usuario)
        {
            return _repositorio.GetByOwner(usuario.idt_usuario).ToList();
        }

        public void CriarNovaTarefa(tb_tarefa tarefa)
        {
            _repositorio.Add(tarefa);
        }

        public void DeletarTarefa(tb_tarefa tarefa)
        {
            _repositorio.Remove(tarefa);
        }
    }
}