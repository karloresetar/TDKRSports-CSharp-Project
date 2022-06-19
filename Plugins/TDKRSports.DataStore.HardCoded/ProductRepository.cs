using System;
using System.Collections.Generic;
using System.Linq;
using TDKRSports.CoreBusiness.Models;
using TDKRSports.UseCases.PluginInterfaces.DataStore;

namespace TDKRSports.DataStore.HardCoded
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>
            {
                new Product { ProductId = 495, Brand = "ADIDAS", Name = "ADIDAS FIGHTER 3/// TAEKWONDO DOBOK", Price = 14.99, ImageLink = "https://i.ibb.co/Yf9KWhY/0015918-a903-adidas-taekwondo-dobok-adiflex3.jpg", Description = "Proizveden od super laganog 100% poliester materijala.Ostavlja vas hladnim i u vrijeme najžešćih borbi.Proizvod nastao nakon godina istraživanja i razvoja.Ova uniforma koristi adidas ClimaCool™ tehnologiju kako bi Vam pomogla pobijediti vrućinu i preznojavanje koje mogu dovesti do smanjenja Vaših performansi."},
                new Product { ProductId = 488, Brand = "ADIDAS", Name = "ADIDAS TAEKWONDO DOBOK ADIFLEX 3///", Price = 10.29, ImageLink = "https://i.ibb.co/9r1v7mD/0001351-jc2006-wtf-dobok-za-forme-poomsae-1000.jpg", Description = "Savršen spoj luksuza i ECOEVER Polyester tehnologije uz  neizostavnu liniju profesionalnosti. Ovaj fantastični dobok je kreiran kako bi izvukao maksimum iz Vaših pokreta.Super lagan i blago rastezljiv,briljantno moderan i precizan kroj,, proizveden od ECOEVER Polyestera sa Clima COOL ® ventilacijskim otvorima, dostupan samo s crnim ovratnikom, odabir najboljih svjetskih boraca, službeni dobok posljednjih olimpijskih igara."},
                new Product { ProductId = 477, Brand = "PRIDE", Name = "WTF DOBOK ZA FORME (POOMSAE)", Price = 15.99, ImageLink = "https://i.ibb.co/vcpKFcr/0001326-a902-adidas-fighter-3-taekwondo-dobok-1000.jpg", Description = "WTF dobok za forme (poomsae), model visoki dan predviđen za velemajstore zvanja od 7.DAN do 9.DAN.  Odobren od svjetske taekwondo federacije za sva svjetska i europska prvenstva i naravno treninge. ,,Dijamantni`` poliester/pamuk materijal."},
                new Product { ProductId = 468, Brand = "PRIDE", Name = "SPORTSKA MAJICA TAEKWONDO", Price = 14.99, ImageLink = "https://i.ibb.co/108YzkV/0001150-22225-sportska-majica-taekwondo.jpg", Description = "Sportska majica TAEKWONDO"},
                new Product { ProductId = 439, Brand = "PRIDE", Name = "ADIDAS MASTER POJAS", Price = 10.29, ImageLink = "https://i.ibb.co/WyRJ5Wr/0001234-a577-adidas-champion-pojas-1000.jpg", Description ="Adidas Master pojas. Super majstorski pojas. Rank 280. Poliester/satin. Širina pojasa 4.5 cm."},
            };
        }

        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(x => x.ProductId == id);
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter)) return products;
            return products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }
    }
}
