using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Features.CQRS.Results
{
    public record GetCategoryQueryResult(Guid CategoryId,string CategoryName);

    //public class GetCategoryQueryResult
    //{
    //    public Guid CategoryId { get; set; }
    //    public string CategoryName { get; set; }

    //}
}
