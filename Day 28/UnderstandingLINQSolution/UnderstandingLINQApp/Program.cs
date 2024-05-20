using UnderstandingLINQApp.Model;

namespace UnderstandingLINQApp
{
    internal class Program
    {
        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.Key);
        //        Console.WriteLine(" - " + book.TitleCount);
        //    }
        //}
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(), TitleNames = title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }
        void printpubid()
        {
            pubsContext pubsContext = new pubsContext();
            var publishers = pubsContext.Titles.GroupBy(t => t.PubId)
                .Select(s => new
                {
                    PublisherName = s.Key,
                    Countoftitles = s.Count()
                });
            foreach (var publisher in publishers)
            {
                Console.WriteLine(publisher.PublisherName +" - "+publisher.Countoftitles);
            }
        }
        void printtitle()
        {
            pubsContext pubsContext = new pubsContext();
            var titles = pubsContext.Sales.GroupBy(t => t.TitleId)
                .Select(g => new
                {
                    Titleid = g.Key,
                    Orderdetails = g.Select(s => new
                    {
                        OrderId = s.OrdNum,
                        Quantity = s.Qty
                    })
                });
            foreach (var title in titles)
            {
                Console.WriteLine(title.Titleid +" - " +title.Orderdetails);
            }
        }
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type);
            Console.WriteLine($"There are {bookCount.Count()} in the type {type}");
        }
        
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        static void Main(string[] args)
        {
            // new Program().PrintNumberOfBooksFromType("mod_cook");
            new Program().printpubid();

        }
    }
}
