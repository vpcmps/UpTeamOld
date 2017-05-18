﻿using System;
using System.Linq;
using UPTEAM.Domain.Entities;
using UPTEAM.Domain.RepositoryInterfaces;

namespace UPTEAM.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<tb_usuario>, IUsuarioRepository
    {
        public tb_usuario Authenticate(string login)
        {
            return Db.tb_usuario.Where(x => x.lgn_usuario.ToLower() == login.ToLower()).FirstOrDefault();
        }
        public bool Register(tb_usuario usuario)
        {
            try
            {
                Db.tb_usuario.Add(usuario);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}