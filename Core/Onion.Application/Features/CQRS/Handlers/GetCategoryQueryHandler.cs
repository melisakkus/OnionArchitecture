using AutoMapper;
using Onion.Application.Features.CQRS.Results;
using Onion.Application.Interfaces;
using Onion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return mapper.Map<List<GetCategoryQueryResult>>(values);
        }
    }
}
