using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public seller(int sellerid,string sellername,string sellerphone) 
        {
            this.Id = sellerid;
            this.Name = sellername;
            this.Phone = sellerphone;

        }
    }
}
