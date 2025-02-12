using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactSaveCSV
{
    class ContactManager
    {
        private const string FILE_NAME = "contacts.csv";
        private List<Contact> contacts = [];
        private ValidationManager validationManager = new();

        public ContactManager()
        {
            LoadContacts();
        }
      
        private void SaveContact()
        {
            //save current contacts to file
            File.WriteAllLines(FILE_NAME, contacts.Select(c => $"{c.Id},{c.Name},{c.PhoneNumber},{c.Email}"));
        }
        public void AddContact(string name,string phoneNo,string email)
        {
            //check if email and phonenumber are valid
            if (!validationManager.ValidateEmail(email) || !validationManager.ValidatePhoneNumber(phoneNo))
                return;


            //generate unique id for contacts
            int id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
            Contact contact = new()
            {
                Id = id,
                Name = name,
                PhoneNumber = phoneNo,
                Email = email
            };
            contacts.Add(contact);
            SaveContact();
            Console.WriteLine("Contact added successfully");
        }
        public void DeleteContact(int id)
        {
            Contact? contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
                SaveContact();
                Console.WriteLine("Contact deleted successfully");
            }
            else
                Console.WriteLine("Contact not found");
            }
        //update contact
        public void UpdateContact(int id, string name, string phoneNo, string email)
        {
            //check if email and phonenumber are valid
            if (!validationManager.ValidateEmail(email) || !validationManager.ValidatePhoneNumber(phoneNo))
                return;

            Contact? contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contact.Name = name;
                contact.PhoneNumber = phoneNo;
                contact.Email = email;
                SaveContact();
                Console.WriteLine("Contact updated successfully");
            }
            else            
                Console.WriteLine("Contact not found");
            }
        //list all contacts
        public void GetAllContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found !!!");
                return;
            }

            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }

        //list all contacts sorted by name
        public void GetAllContactsSortedByName()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found !!!");
                return;
            }
            foreach (Contact contact in contacts.OrderBy(c => c.Name))
            {
                Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }
        private void LoadContacts()
        {
            if (File.Exists(FILE_NAME))
            {
                string[] lines = File.ReadAllLines(FILE_NAME);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    Contact contact = new()
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        PhoneNumber = parts[2],
                        Email = parts[3]
                    };
                    contacts.Add(contact);
                }

            }
            else
            {
                //create file if not exists
                Console.WriteLine("File not found, creating new file");
                File.Create(FILE_NAME).Close();
                return;
            }
        }
    }
}
