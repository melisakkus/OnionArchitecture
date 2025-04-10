using AutoMapper;
using Onion.Application.Features.CQRS.Queries;
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
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query) 
        {
            var value = await _repository.GetByIdAsync(query.id);
            return _mapper.Map<GetCategoryByIdQueryResult>(value);
        }
    }
}
