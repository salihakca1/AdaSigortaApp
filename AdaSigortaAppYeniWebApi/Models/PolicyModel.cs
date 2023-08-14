using System.ComponentModel.DataAnnotations;

namespace AdaSigortaAppYeniWebApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } 
        public string? Name { get; set; }
    }

    public class Person
    {
        [Key]
        public int PersonId { get; set; } 

        public string? KimlikNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
    }

    public class Policy
    {
        [Key]
        public int PolicyId { get; set; } 

        public Person? Person { get; set; }
        public Product? Product { get; set; }

        public DateTime TanzimTarihi { get; set; }

        public DateTime VadeBaslangic { get; set; }

        public DateTime VadeBitis { get; set; }

        public double? Prim { get; set; }
    }

    public class Traffic : Policy
    {
        public string? PlakaIlKodu { get; set; }
        public string? PlakaKodu { get; set; }
    }

    public class Dask : Policy
    {
        public string? Adress { get; set; }
        public string? Ilce { get; set; }
        public string? Il { get; set; }
    }
}
