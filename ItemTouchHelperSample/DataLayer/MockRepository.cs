using System.Collections.Generic;
using System.Security.Policy;
using ItemTouchHelperSampleAndroid.DataLayer.DataObjects;

namespace ItemTouchHelperSampleAndroid.DataLayer
{
    public class MockRepository : IRepository
    {
        public IEnumerable<Contact> GetContacts()
        {
            List<Contact> listContacts = new List<Contact>
            {
                new Contact()
                {
                    CompanyIs = "ГК «Росатом»",
                    IsActive = true,
                    Title = "Василий Петрович",
                    
                },
                new Contact()
                {
                    CompanyIs = "ГК 'Ростехнологии'",
                    IsActive = true,
                    Title = "Кирилл Зайцев",

                },
                new Contact()
                {
                    CompanyIs = "РусГидро",
                    IsActive = true,
                    Title = "Дмитрий Балтийский",

                },
                new Contact()
                {
                    CompanyIs = "Холдинг МРСК",
                    IsActive = true,
                    Title = "Богомягкова Дарья",

                },
                new Contact()
                {
                    CompanyIs = "Роснефть",
                    IsActive = true,
                    Title = "Tanya Gremilova",

                },
                new Contact()
                {
                    CompanyIs = "Газпром",
                    IsActive = true,
                    Title = "Alexey Egoroff",

                },
                new Contact()
                {
                    CompanyIs = "Транснефть",
                    IsActive = true,
                    Title = "Ира Домбровская",

                },
                new Contact()
                {
                    CompanyIs = "РАО Энергетические системы Восток",
                    IsActive = true,
                    Title = "Анастасия Судакова",

                },
                new Contact()
                {
                    CompanyIs = "Аэрофлот - российские авиалинии",
                    IsActive = true,
                    Title = "Denis Yurkoff",

                },

            };

            return listContacts;


        }

        public IEnumerable<Task> GetTasks(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Note> GetNotes(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}