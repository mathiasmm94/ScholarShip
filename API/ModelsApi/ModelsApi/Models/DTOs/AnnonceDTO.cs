namespace ModelsApi.Models.DTOs
{
    public class AnnonceDTO
    {
          
            public int AnnonceId { get; set; }
            public double Price { get; set; }
            public string Titel { get; set; }
            public string Kategori { get; set; }
            public string Beskrivelse { get; set; }
            public string Studieretning { get; set; }
            public string BilledeSti { get; set; }
            public long EfManagerId { get; set; }
            public string Stand { get; set; }
            public int ChatId { get; set; }
            public bool CheckBoxValue { get; set; }
            public int NumberOfWeeks { get; set; }
    }
    }


