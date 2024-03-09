using asp_net_mvc_spd221.Controllers;

namespace asp_net_mvc_spd221.Models
{
    public static class MockData
    {
        public static List<Contact> GetContacts()
        {
            return new List<Contact>()
            {
                new Contact() { Id = 1, Name = "Olga", Phone = "33-445-434" },
                new Contact() { Id = 2, Name = "Igor", Phone = "23-23-23" },
                new Contact() { Id = 3, Name = "Sofia", Phone = "999-66-99" }
            };
        }
    }
}
