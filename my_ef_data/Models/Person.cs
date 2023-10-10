using System;
namespace my_ef_data.Models
{
	public class Person
	{
		public int Id { get; set; }
        public required string Vorname { get; set; }
        public required string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public required string Lieblingsfarbe { get; set; }
    }
}

