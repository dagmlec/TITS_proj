using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiTSproj.Models;

namespace TiTSproj.Infrastructure
{
    public class ProduktySzczeglyDynamicNodeProvider : DynamicNodeProviderBase
    {
        private Model1 db1 = new Model1(); 

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodee)
        {
            var returnValue = new List<DynamicNode>();
            foreach(Produkty produkty in db1.Produkt)
            {
                DynamicNode node = new DynamicNode();
                node.Title = produkty.NazwaProduktu;
                node.Key = "Produkt_" + produkty.ProduktId;
                node.ParentKey = "Kategoria_" + produkty.KategoriaID;
                node.RouteValues.Add("id", produkty.ProduktId);
                returnValue.Add(node);
            }
            return returnValue;
        }
    }
}