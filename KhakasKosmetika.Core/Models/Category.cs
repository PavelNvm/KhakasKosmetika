using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Models
{
    public class Category
    {
        public string Id { get; set; }             //<Ид>
        public string SupergroupId { get; set; }   //<Ид>
        public string Name { get; set; }           //<Наименование> 

        //1C remains                               
        public string Version { get; set; }       //<НомерВерсии>
        public bool DeletionMarker { get; set; }   //<ПометкаУдаления>
        public int AmountOfGroups { get; set; }     //<Группы> Количество подгрупп (для возможного восстановления изначального XML файла)

        //Easier findings
        public int Depth { get; set; } //количетсво надргупп у этой группы (значение 0-2)
        public static Category Create(string id, string supergroupId, string name, string version, bool deletionMarker, int depth)
        {
            return new Category(id, supergroupId, name, version, deletionMarker, depth);
        }
        private Category(string id, string supergroupId, string name, string version, bool deletionMarker, int depth)
        {
            Id=id; SupergroupId=supergroupId; Name=name; Version=version; DeletionMarker=deletionMarker; Depth=depth;
        }
    }
}
