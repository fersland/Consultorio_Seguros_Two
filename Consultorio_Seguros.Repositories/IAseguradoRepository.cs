﻿using Consultorio_Seguros.Models;
using Consultorio_Seguros.Models.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Repositories
{
    public interface IAseguradoRepository
    {
        IEnumerable<AseguradoVM> GetAll();
        Asegurado GetById(int id);
        void Insert(Asegurado asegurado);
        void Update(int id,  Asegurado asegurado);
        void Delete(int id);
    }
}
