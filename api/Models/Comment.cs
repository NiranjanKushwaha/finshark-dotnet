using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set;}
        public string Title { get; set;} = String.Empty;

        public string comment { get; set;} = String.Empty;

        public DateTime createdOn   { get; set;} = DateTime.Now;
        public int? StockId { get; set;}

        public Stock? Stock { get; set; }
        
    }
}