using System.Xml.Serialization;
using System.Xml;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.XML_Importer;
using KhakasKosmetika.Application.Services;
using KhakasKosmetika.DataAccess.Repositories;
using KhakasKosmetika.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;






//XmlDocument doc = new XmlDocument();
////FileStream fileStream = new FileStream("C:\\Users\\nagib\\OneDrive\\Desktop\\rabota\\000000001\\groups_1_1_db22bef4-10bb-4ac6-8048-a9680a207370.xml", FileMode.Open);
//string[] files = Directory.GetFiles("C:\\Users\\nagib\\OneDrive\\Desktop\\rabota\\000000001", "*.xml", SearchOption.AllDirectories);

////var a = files.FirstOrDefault(f => f.Contains("groups"));

//using (StreamReader reader = new StreamReader("C:\\Users\\nagib\\OneDrive\\Desktop\\rabota\\000000001\\groups_1_1_db22bef4-10bb-4ac6-8048-a9680a207370.xml"))
//{

//    doc.Load(reader);

//}

//string jsonText = JsonConvert.SerializeXmlNode(doc);
//using (StreamReader reader = new StreamReader(files.First(f => f.Contains("groups"))))
//{
//    doc.Load(reader);
//}

////var result = doc.FirstChild;
IXMLReaderService reader = new DataReaderService();
var cats =reader.ReadCategories();
//var a =reader.ReadMeasurementUnits();
//var b = reader.ReadPriceTypes();
var a1 = reader.ReadProducts();
//var a2 = a1.Result.First(o=>o.Art== "BIG-14");
//string finder = "169818";
//var ssss = a1.Result.FirstOrDefault(x => x.Code == finder||x.Art==finder);

DbContextOptionsBuilder<KhakasKosmetikaDbContext> optionsBuilder = new DbContextOptionsBuilder<KhakasKosmetikaDbContext>();
var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Testiq.db");
var path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
Console.WriteLine(path1);
var options = optionsBuilder.UseSqlite($"Data Source = {path}");
var opts = options.Options;
var context = new KhakasKosmetikaDbContext(opts);
var productRep = new ProductRepository(context);
var categoryRep = new CategoryRepository(context);

var catserv = new CategoriesService(categoryRep, productRep);

var f = catserv.GetCategoriesDepthZero();
var f1 = productRep.GetProductsByCategoryIdAsync("4d49d696-39c6-4f26-abde-7dd21ae50563");
//productRep.GetSingleProductByIdAsync("");
var b1 = 1;





















