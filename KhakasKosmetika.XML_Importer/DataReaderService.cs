using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KhakasKosmetika.XML_Importer
{
    public class DataReaderService : IXMLReaderService
    {
        private readonly string _folderPath;
        private XmlDocument _doc = new XmlDocument();
        string[] files;
        public DataReaderService()
        {
            _folderPath = "C:\\Users\\nagib\\OneDrive\\Desktop\\rabota\\000000001";
            files = Directory.GetFiles(_folderPath, "*.xml", SearchOption.AllDirectories);
        }

        public DataReaderService(string path)
        {
            files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
        }

        #region groups_File
        public async Task<List<Category>> ReadCategories()
        {
            List<Category> result = new List<Category>();

            using (StreamReader reader = new StreamReader(files.First(f => f.Contains("groups"))))
            {
                _doc.Load(reader);
            }
            //var a =_doc.ChildNodes;
            //result = GroupMapper.Map(_doc.ChildNodes.Item(1).ChildNodes.Item(1).ChildNodes.Item(2));
            foreach (XmlNode child in _doc.ChildNodes.Item(1).ChildNodes.Item(1).ChildNodes.Item(2))
            {
                result.AddRange(VerifyAndReturnGruops(child, 0).Result.ToList());
            }
            return result;

        }
        private async Task<List<Category>> VerifyAndReturnGruops(XmlNode node, int depth)
        {
            List<Category> result = new List<Category>();

            if (node.ChildNodes.Count == 5)
            {

                result.Add(
                    Category.Create(node.ChildNodes.Item(0).InnerText,
                    depth == 0 ? "none" : node.ParentNode.ParentNode.ChildNodes.Item(0).InnerText,
                    node.ChildNodes.Item(3).InnerText,
                    node.ChildNodes.Item(1).InnerText,
                    bool.Parse(node.ChildNodes.Item(2).InnerText),                    
                    depth
                    ));
                foreach (XmlNode grandchild in node.ChildNodes.Item(4))
                {
                    result.AddRange(VerifyAndReturnGruops(grandchild, depth + 1).Result.ToList());
                }

            }
            else if (node.ChildNodes.Count == 4)
            {

                result.Add(
                    Category.Create(node.ChildNodes.Item(0).InnerText,
                    depth == 0 ? "none" : node.ParentNode.ParentNode.ChildNodes.Item(0).InnerText,
                    node.ChildNodes.Item(3).InnerText,
                    node.ChildNodes.Item(1).InnerText,
                    bool.Parse(node.ChildNodes.Item(2).InnerText),                    
                    depth
                    ));
            }
            return result;
        }

        public async Task<List<MeasurementUnit>> ReadMeasurementUnits()
        {
            List<MeasurementUnit> result = new List<MeasurementUnit>();

            using (StreamReader reader = new StreamReader(files.First(f => f.Contains("groups"))))
            {
                _doc.Load(reader);

            }

            foreach (XmlNode child in _doc.ChildNodes.Item(1).ChildNodes.Item(1).ChildNodes.Item(4))
            {
                result.Add(new MeasurementUnit(
                    child.ChildNodes.Item(0).InnerText,
                    child.ChildNodes.Item(4).InnerText,
                    child.ChildNodes.Item(5).InnerText,
                    child.ChildNodes.Item(3).InnerText,
                    child.ChildNodes.Item(6).InnerText,
                    child.ChildNodes.Item(1).InnerText,
                    bool.Parse(child.ChildNodes.Item(2).InnerText))
                    );
            }
            return result;
        }

        public async Task<List<PriceType>> ReadPriceTypes()
        {
            List<PriceType> result = new List<PriceType>();

            using (StreamReader reader = new StreamReader(files.First(f => f.Contains("groups"))))
            {
                _doc.Load(reader);

            }

            foreach (XmlNode child in _doc.ChildNodes.Item(1).ChildNodes.Item(1).ChildNodes.Item(3))
            {
                result.Add(new PriceType(
                    child.ChildNodes.Item(0).InnerText,
                    child.ChildNodes.Item(3).InnerText,
                    child.ChildNodes.Item(4).InnerText,
                    child.ChildNodes.Item(5).ChildNodes.Item(0).InnerText,
                    bool.Parse(child.ChildNodes.Item(5).ChildNodes.Item(1).InnerText),
                    child.ChildNodes.Item(1).InnerText,
                    bool.Parse(child.ChildNodes.Item(2).InnerText))
                    );
            }
            return result;
        }
        #endregion
        public async Task<List<Product>> ReadProducts()
        {
            List<Product> result = new List<Product>();
            foreach (string adress in files.Where(o => o.Contains("import")))
            {
                using (StreamReader reader = new StreamReader(adress))
                {
                    _doc.Load(reader);

                }

                foreach (XmlNode child in _doc.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(3))
                {//19 3 1 = child.ChildNodes.Item(19).ChildNodes.Item(3).ChildNodes.Item(1).InnerText;

                    string temp="";
                    foreach (XmlNode child2 in child.ChildNodes)
                    {
                        if (child2.Name.Contains("ЗначенияРеквизитов"))
                        {
                            temp = child2.ChildNodes.Item(3).ChildNodes.Item(1).InnerText;
                            break;
                        }
                    }
                    result.Add(Product.Create(
                        child.ChildNodes.Item(0).InnerText,       // 0          string id,
                        child.ChildNodes.Item(4).InnerText,       // 4          string art,
                        child.ChildNodes.Item(5).InnerText,       // 5           string code,
                        child.ChildNodes.Item(7).InnerText,       // 7           string lenght,
                        child.ChildNodes.Item(8).InnerText,       // 8           int width,
                        child.ChildNodes.Item(9).InnerText,       // 9           int height,
                        child.ChildNodes.Item(10).InnerText,       // 10           int diameter,
                        child.ChildNodes.Item(11).InnerText,       // 11           int volume,
                        child.ChildNodes.Item(12).InnerText,       // 12          int weight,
                        child.ChildNodes.Item(13).InnerText,       // 13           string name,
                        "",       // ??           decimal pricelow,
                        "",       // ??           decimal pricefull,
                        0,       // ??           int rests,
                        child.ChildNodes.Item(1).InnerText,       // 1           string version ,
                        child.ChildNodes.Item(2).InnerText,       // 2           bool deletionMarker
                        child.ChildNodes.Item(16).ChildNodes.Count,
                        GlueGroup(child.ChildNodes.Item(16)),
                        $"https://api.hk19.ru/goods_photos/{temp.Split().FirstOrDefault()}%C2%A0{temp.Split().LastOrDefault()}.jpg" 
                        ));
                }
            }
            foreach (string adress in files.Where(o => o.Contains("prices")))
            {
                using (StreamReader reader = new StreamReader(adress))
                {
                    _doc.Load(reader);

                }

                foreach (XmlNode child in _doc.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(4))
                {
                    decimal price1;
                    decimal price2;
                    string price1str="";
                    string price2str;
                    decimal.TryParse(child.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(2).InnerText, out price1);
                    price1str = child.ChildNodes.Item(1).ChildNodes.Item(0).ChildNodes.Item(0).InnerText;

                    if (child.ChildNodes.Item(1).ChildNodes.Item(1) != null)
                    {
                        decimal.TryParse(child.ChildNodes.Item(1).ChildNodes.Item(1).ChildNodes.Item(2).InnerText, out price2);                        
                        price2str = child.ChildNodes.Item(1).ChildNodes.Item(1).ChildNodes.Item(0).InnerText;
                        result.FirstOrDefault(o => o.Id == child.ChildNodes.Item(0).InnerText).PriceFull = price1 > price2 ? price1str : price2str;
                        result.FirstOrDefault(o => o.Id == child.ChildNodes.Item(0).InnerText).PriceLow = price1 > price2 ? price2str : price1str;
                    }
                    else
                    {
                        result.FirstOrDefault(o => o.Id == child.ChildNodes.Item(0).InnerText).PriceFull = price1str;
                        result.FirstOrDefault(o => o.Id == child.ChildNodes.Item(0).InnerText).PriceLow = price1str;
                    }

                }
            }
            //TODO:СЧИТЫВАНИЕ ОСТАТКОВ
            return result;
        }
        
        private static string GlueGroup(XmlNode child)
        {
            string res = string.Empty;
            foreach(XmlNode grchild in child.ChildNodes)
            {
                res += grchild.FirstChild.InnerText;
                res += ";";
            }
            return res;
        }

        #region atoi
        public static decimal MyAtoi(string s)
        {
            char a = '0'; //48
            char b = '1'; //49
            char c = '9'; //57
            char d = '+'; //43
            char e = '-'; //45
            char f = ' '; //32
            bool positive = true;
            bool sign = false;
            char[] chars = s.ToCharArray();
            List<int> res = new List<int>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= '0' && chars[i] <= '9')
                {
                    res.Add(chars[i]);
                }
                else if (chars[i] == ' ' && res.Count == 0)
                { continue; }
                else if ((chars[i] == '+' || chars[i] == '-') && !sign && res.Count == 0)
                {
                    positive = chars[i] == '+' ? true : false;
                    sign = true;
                }
                else { break; }
            }
            while (res.Count > 0 && res[0] == '0')
            {
                res.RemoveAt(0);
            }
            int result = 0;
            if (res.Count >= 10)
            {
                if (res.Count == 10)
                {
                    if (res[0] > '2') //2
                    {
                        goto skipMaxValue;
                    }
                    if (res[1] > '1') //1
                    {
                        goto skipMaxValue;
                    }
                    if (res[2] > '4') //4
                    {
                        goto skipMaxValue;
                    }
                    if (res[3] > '7') //7
                    {
                        goto skipMaxValue;
                    }
                    if (res[4] > '4') //4
                    {
                        goto skipMaxValue;
                    }
                    if (res[5] > '8') //8
                    {
                        goto skipMaxValue;
                    }
                    if (res[6] > '3') //3
                    {
                        goto skipMaxValue;
                    }
                    if (res[7] > '6') //6
                    {
                        goto skipMaxValue;
                    }
                    if (res[8] > '4') //4
                    {
                        goto skipMaxValue;
                    }
                    if (res[9] > '7' && positive) //8
                    {
                        goto skipMaxValue;
                    }
                    if (res[9] > '8' && !positive) //8
                    {
                        goto skipMaxValue;
                    }
                }
                else
                {
                    goto skipMaxValue;
                }
            }
            int temp;

            for (int i = res.Count - 1; i >= 0; i--)
            {
                temp = Convert.ToInt32(res[i]) - 48;
                for (int j = 0; j < res.Count - i - 1; j++)
                {
                    temp *= 10;
                }
                result += temp;
            }

            if (!positive)
                result *= -1;

            return result;
        skipMaxValue:
            result = int.MaxValue;
            if (!positive)
                result *= -1;

            return result;
        }
        #endregion
    }
}
