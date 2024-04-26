using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public category(int categoryid,string categoryname) 
        {
            this.Id = categoryid;
            this.Name = categoryname;
        }
    }
}
