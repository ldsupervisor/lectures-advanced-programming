using System.Xml.Linq;

using var client = new HttpClient();
var response = await client.GetStringAsync("http://localhost:5286/api/menu/xml");

XDocument xml = XDocument.Parse(response);
Console.WriteLine("Received XML:\n" + xml);

Console.WriteLine("\nList of main courses:");
foreach (var dish in xml.Descendants("main_course").Elements("dish"))
{
    Console.WriteLine($"- {dish.Attribute("name")?.Value} {dish.Attribute("type")?.Value}");
}