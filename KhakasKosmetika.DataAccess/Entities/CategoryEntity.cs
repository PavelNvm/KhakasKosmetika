using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Entities
{
    public class CategoryEntity
    {
        public string Id { get; set; }             //<Ид>
        public string SupergroupId { get; set; }   //<Ид>
        public string Name { get; set; }           //<Наименование> 

        //1C remains                               
        public string Version { get; set; }       //<НомерВерсии>
        public bool DeletionMarker { get; set; }   //<ПометкаУдаления>        

        //Easier findings
        public int Depth { get; set; } //количетсво надргупп у этой группы (значение 0-2)
    }
}
