using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Entities
{    
    public class Category
    {
        public Category()
        {
            CategoryId = Guid.NewGuid();
        }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }      
        
        public IList<Product> Products { get; set; }  
    }
}
