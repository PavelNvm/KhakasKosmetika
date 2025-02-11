using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Entities
{
    public class ProductEntity
    {
        public string Id { get; set; } = "";            //<Ид>        
        public string Art { get; set; } = "";       //<Артикул> 
        public string Code { get; set; } = "";      //<Код> 
        public string Lenght { get; set; } = "";     //<ДлинаМ>
        public string Width { get; set; } = "";      //<ШиринаМ>
        public string Height { get; set; } = "";       //<ВысотаМ>
        public string Diameter { get; set; } = "";      //<ДиаметрМ>
        public string Volume { get; set; } = "";    //<ОбъемМ>
        public string Weight { get; set; } = "";      //<ВесМ>
        public string Name { get; set; } = "";
        public string PriceLow { get; set; } = "";
        public string PriceFull { get; set; } = "";
        public int Rests { get; set; }
        public int AmountOfCategories { get; set; }     //Колво групп к которым относится товар
        public string Categories { get; set; } = "";         //Id групп разделенных ';'
        public string PhotoLink { get; set; } = "";


        public string Description { get; set; } = "";

        public int TotalTimesRated { get; set; }
        public int SumOfRating { get; set; }
        public double AverageRating { get; set; }





        //1C remains                               
        public string Version { get; set; } = "";    //<НомерВерсии>
        public bool DeletionMarker { get; set; }   //<ПометкаУдаления>        

    }
}
