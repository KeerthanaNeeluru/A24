using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee()
            {
                Id = 1025,
                Fname = "Keerthana",
                Lname = "Neeluru",
                Salary = 85000
            };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("C:\\Users\\Keerthana\\OneDrive\\Desktop\\job\\simpli\\Assignments\\A24\\Assignment24\\Employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs, employee);
            }
            Console.WriteLine("Binary serialization done");

            //Reading the binary  file
            Console.WriteLine("\n\nDeserialized Data");
            using (FileStream fs1 = new FileStream("C:\\Users\\Keerthana\\OneDrive\\Desktop\\job\\simpli\\Assignments\\A24\\Assignment24\\Employee.bin", FileMode.Open))
            {
                Employee employee1 = (Employee)formatter.Deserialize(fs1);
                Console.WriteLine("Employee ID:" + employee1.Id);
                Console.WriteLine("Employee First Name:" + employee1.Fname);
                Console.WriteLine("Employee Last Name:" + employee1.Lname);
                Console.WriteLine("Employee Salary:" + employee1.Salary);
            }
            Console.WriteLine("\n");
            Console.WriteLine("===============================================================================");

            //XML serialization

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter textWriter = new StreamWriter("C:\\Users\\Keerthana\\OneDrive\\Desktop\\job\\simpli\\Assignments\\A24\\Assignment24\\Employee.Xml"))
            {
                serializer.Serialize(textWriter, employee);

            }
            Console.WriteLine("XML Serialization done");

            //xml deSerializer
            Console.WriteLine("\n\nDeserialized Data\n");
            using (TextReader textReader = new StreamReader("C:\\Users\\Keerthana\\OneDrive\\Desktop\\job\\simpli\\Assignments\\A24\\Assignment24\\Employee.Xml"))
            {
                Employee emp = (Employee)serializer.Deserialize(textReader);
                Console.WriteLine("Employee ID:" + emp.Id);
                Console.WriteLine("Employee First Name:" + emp.Fname);
                Console.WriteLine("Employee Last Name:" + emp.Lname);
                Console.WriteLine("Employee Salary:" + emp.Salary);
            }


            Console.ReadKey();
        }
    }
}
