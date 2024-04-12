namespace DoctorSpeciality
{
    internal class Program
    {
        Doctor CreatenewDoctorwithalldetails(int id)
        {
            Doctor doctor = new Doctor(id);
            Console.WriteLine($"Doctor Id No : {id}");
            Console.WriteLine("Please enter the name of the doctor :");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Please enter the Qualification of the doctor :");
            doctor.Qualification = Console.ReadLine();
            Console.WriteLine("Please enter the Speciality of the doctor :");
            doctor.Speciality = Console.ReadLine();
            Console.WriteLine("Please enter the Age of the doctor :");
            doctor.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Experience of the doctor :");
            doctor.Experience = int.Parse(Console.ReadLine());
            return doctor;
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("hello");
            Program program = new Program();
            Doctor[] doctors = new Doctor[3];
            for(int i=0;i<doctors.Length; i++)
            {
                doctors[i] = program.CreatenewDoctorwithalldetails(101+i);
            }
            Console.WriteLine("All the doctors have been added to the List");
            Console.WriteLine("What Speciality of Doctors are u searching for : ");
            string search = Console.ReadLine();
            for(int i=0;i<doctors.Length;i++)
            {
                if (doctors[i].Speciality.Equals(search))
                {
                    doctors[i].printDetailsofDoctorofspecifiedspeciality();
                }
            }
        }
    }
}
