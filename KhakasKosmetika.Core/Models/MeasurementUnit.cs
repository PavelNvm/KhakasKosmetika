using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KhakasKosmetika.Core.Models
{
    public class MeasurementUnit
    {
        public string Id { get; set; }                           //<Ид>
        public string Code { get; set; }                         //<Код>
        public string FullName { get; set; }                     //<НаименованиеПолное>
        public string ShortName { get; set; }                    //<НаименованиеКраткое>
        public string InternationalAbbreviation { get; set; }    //<МеждународноеСокращение>

        //1C remains                               
        public string Version { get; set; }         //<НомерВерсии>
        public bool DeletionMarker { get; set; }    //<ПометкаУдаления>
        public MeasurementUnit(string id, string code, string fullName, string shortName, string internationalAbbreviation, string version, bool deletionMarker)
        {
            Id = id;
            Code = code;  
            FullName = fullName;
            ShortName = shortName;
            InternationalAbbreviation = internationalAbbreviation;
            Version = version;
            DeletionMarker = deletionMarker;

        }
        
    }
}
