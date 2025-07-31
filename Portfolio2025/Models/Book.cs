using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace Portfolio2025.Models
{
    public class Book
    {

        [Name("Id")]
        public int Id { get; set; }
        [Name("Book")]
        public string Title {  get; set; }
        [Name("Author(s)")]
        public string Author {  get; set; }
        [Name("Original language")]
        public string Language {  get; set; }
        [Name("First published")]
        public int FirstPublished {  get; set; }
        [Name("Approximate sales in millions")]
        public double SalesInMillions {  get; set; }
        [Name("Genre")]
        public string Genre { get; set; }
    

    }


    public static class DB
    {
        public static List<Book> LoadBooks()
        {
            using (var reader = new StreamReader("best-selling-books.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Book>().ToList();
            }
        }
        public static Book GetBook(int id)
        {
            List<Book> books = DB.LoadBooks();

            return books.FirstOrDefault(x => x.Id==id);
        }



        //foreach (Book p in books)
        //{
        //    if (p.Id == id)
        //    {
        //        return p;
        //    }
        //}
        //return new Book(); 
        // return empty Product if not in list


    }
    


    }
