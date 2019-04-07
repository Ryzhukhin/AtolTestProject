using System;

namespace Project.Bll.Core.Dto
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}