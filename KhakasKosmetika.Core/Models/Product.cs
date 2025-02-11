using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Models
{
    public class Product
    {

        public string Id { get; set; }             //<Ид>        
        public string Art { get; set; }            //<Артикул> 
        public string Code { get; set; }           //<Код> 
        public string Lenght { get; set; }         //<ДлинаМ>
        public string Width { get; set; }             //<ШиринаМ>
        public string Height { get; set; }            //<ВысотаМ>
        public string Diameter { get; set; }          //<ДиаметрМ>
        public string Volume { get; set; }            //<ОбъемМ>
        public string Weight { get; set; }            //<ВесМ>
        public string Name { get; set; }
        public string PriceLow { get; set; }
        public string PriceFull { get; set; }
        public int Rests { get; set; }
        public int AmountOfCategories { get; set; }      //Колво групп к которым относится товар
        public string Categories { get; set; }           //Id групп разделенных ';'
        public string PhotoLink { get; set; }
        public string Description { get; set; }

        public double Rating { get; set; }



        //1C remains                               
        public string Version { get; set; }       //<НомерВерсии>
        public bool DeletionMarker { get; set; }   //<ПометкаУдаления>        

        public static Product Create(
            string id,
            string art,
            string code,
            string lenght,
            string width,
            string height,
            string diameter,
            string volume,
            string weight,
            string name,
            string pricelow,
            string pricefull,
            int    rests,
            string version,
            string deletionMarker,
            int    amountOfCategories,
            string groups,
            string photolink,
            double rating,
            string description
            )
        {
            return new Product(
                id,
                art,
                code,
                lenght,
                width,
                height,
                diameter,
                volume,
                weight,
                name,
                pricelow,
                pricefull,
                rests,
                version,
                deletionMarker,
                amountOfCategories,
                groups,
                photolink,
                rating,
                description
                );
        }
        private Product(
            string id,
            string art,
            string code,
            string lenght,
            string width,
            string height,
            string diameter,
            string volume,
            string weight,
            string name,
            string pricelow,
            string pricefull,
            int rests,
            string version ,
            string deletionMarker,
            int amountOfCategories,
            string groups,
            string photolink,
            double rating,
            string description
            )
        {
            Id = id;
            Art = art;
            Code = code;
            Lenght = lenght;
            Width = width;
            Height = height;
            Diameter = diameter;
            Volume = volume;
            Weight = weight;
            Name = name;
            PriceLow = pricelow;
            PriceFull = pricefull;
            Rests = rests;
            Version = version;
            DeletionMarker = bool.Parse(deletionMarker);
            AmountOfCategories = amountOfCategories;
            Categories = groups;
            PhotoLink = photolink;
            Rating = rating;
            Description = description;
        }
    }
}
