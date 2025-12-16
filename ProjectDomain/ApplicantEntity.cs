using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain
{
    public class ApplicantEntity
    {
        public string Id { get; private set;}
        public string Name { get; private set;}
        public string Email { get; private set; }
        public string Phone { get; private set;}
        public string Website { get; private set; }
        public ResumeEntity? Resume { get; private set; }
        public DateTime? DateOfBirth { get; private set; }

        public ApplicantEntity(string id, string name, string email, string phone, string website,ResumeEntity resume, DateTime? dateOfBirth)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email cannot be null or empty", nameof(email));
            if (string.IsNullOrEmpty(phone)) throw new ArgumentException("Phone number cannot be null or empty", nameof(phone));
            if (string.IsNullOrEmpty(website)) throw new ArgumentException("Website cannot be null or empty", nameof(website));

            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Website = website;
            this.Resume = resume;
            this.DateOfBirth = dateOfBirth;
        }
    }
}
