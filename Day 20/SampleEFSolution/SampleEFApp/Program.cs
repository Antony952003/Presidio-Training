using SampleEFApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //connectionString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=dbEmployeeTracker;Integrated Security=True;";
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();

            //Area area = new Area();
            //area.Area1 = "TITQ";
            //area.Zipcode = "44344";
            //context.Areas.Add(area);
            //context.SaveChanges();
            //Console.WriteLine("The Values have been added to the database");
            //var farea = context.Areas.ToList().Find((a) => a.Area1 == "TITQ");
            //farea.Zipcode = "98098";
            //context.Update(farea);
            //context.SaveChanges();
            var farea = context.Areas.ToList().Find((a) => a.Area1 == "TITQ");
            context.Areas.Remove(farea);
            context.SaveChanges();
            var areas = context.Areas.ToList();
            foreach ( var area in areas )
            {
                Console.WriteLine(area.Area1+" "+area.Zipcode);
            }
        }
    }
}
