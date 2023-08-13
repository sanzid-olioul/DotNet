using BlazorApp1.Models;

namespace BlazorApp1
{
    public class ContactService
    {
        public List<Contact> ContactList = new List<Contact>();

        public void AddContact(Contact contact)
        {
            ContactList.Add(contact);
        }
    }
}
