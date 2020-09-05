using Normas.WebAPI.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class BuscarNormaUseCase
    {
        private readonly INormaRepository _normaRepository;
        public BuscarNormaUseCase(INormaRepository normaRepository)
        {
            _normaRepository = normaRepository;
        }
    }
}
