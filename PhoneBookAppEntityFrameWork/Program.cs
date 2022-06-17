using PhoneBookAppEntityFrameWork.Models;


namespace PhoneBookAppEntityFrameWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Insert data into data base.
            Program.InsertData("Roy", "616663524");
            //select data by Id to view
            Program.ReadDataById(1);

            // Update data by Id
            Contact contact = new Contact()
            {
                Name = "HIHI",
                PhoneNumber = "123456"
            };
            Program.UpdateDataById(1, contact);

            //delete data by selected ID
            Program.DeleteById(1);



            Console.ReadLine();
        }


        private static void InsertData(string name, string phoneNumber)
        {
            using var db = new PhoneBookContext();
            db.Add(new Contact { Name = name, PhoneNumber = phoneNumber });
            db.SaveChanges();
        }
        private static void ReadDataById(int contactId)
        {
            using var db = new PhoneBookContext();

            var newContact = db.Contacts.Where(x => x.Id == contactId).First();


            Console.WriteLine(newContact.ToString());
        }

        private static void UpdateDataById(int contactId, Contact contact)
        {
            using var db = new PhoneBookContext();
            var newContact = db.Contacts.Where(x => x.Id == contactId).First();

            if (newContact == null)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                newContact.Name = contact.Name;
                newContact.PhoneNumber = contact.PhoneNumber;
                db.SaveChanges();
            }


        }

        private static void DeleteById(int contactId)
        {
            using var db = new PhoneBookContext();
            var newContact = db.Contacts.Where(x => x.Id == contactId).First();
            if (newContact == null)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                db.Contacts.Remove(newContact);
                db.SaveChanges();
            }

        }

    }
}