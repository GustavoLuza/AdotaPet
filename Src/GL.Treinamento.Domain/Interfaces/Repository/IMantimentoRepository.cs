﻿using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Repository
{
    public interface IMantimentoRepository :IRepository<Mantimentos>
    {
        IEnumerable<Mantimentos> ObterAtivos();
    }
}
