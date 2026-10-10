using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GET: api/menu/xml
        [HttpGet("xml")]
        public IActionResult GetMenuXml()
        {
            var xml = new XDocument(
                new XElement("menu",
                    new XElement("starter",
                        new XElement("dish", new XAttribute("name", "soup"), new XAttribute("type", "tomato")),
                        new XElement("dish", new XAttribute("name", "soup"), new XAttribute("type", "fish")),
                        new XElement("dish", new XAttribute("name", "pigeon salad"))
                    ),
                    new XElement("main_course",
                        new XElement("dish", new XAttribute("name", "steak"), new XAttribute("type", "sirloin"), new XAttribute("cooking", "medium")),
                        new XElement("dish", new XAttribute("name", "steak"), new XAttribute("type", "fillet"), new XAttribute("cooking", "rare")),
                        new XElement("dish", new XAttribute("name", "sea bass"))
                    ),
                    new XElement("accompaniment",
                        new XElement("dish", new XAttribute("name", "french fries"), new XAttribute("portions", "2")),
                        new XElement("dish", new XAttribute("name", "salad"), new XAttribute("portions", "1"))
                    )
                )
            );

            return Content(xml.ToString(), "application/xml");
        }
    }
}
