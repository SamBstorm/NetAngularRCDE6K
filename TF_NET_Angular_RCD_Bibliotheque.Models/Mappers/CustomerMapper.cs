using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.Mappers
{
    public static class CustomerMapper
    {
        public static Customer ToDAL(this CustomerFormDTO dto)
        {
            return new Customer()
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Birthdate = dto.Birthdate,
                Pseudo = dto.Pseudo,
                Password = sha256_hash(dto.Password)
            };
        }
        public static CustomerFormDTO? ToDTO(this Customer dal)
        {
            if (dal is null) return null;
            return new CustomerFormDTO()
            {
                Id = dal.Id,
                Firstname = dal.Firstname,
                Lastname = dal.Lastname,
                Birthdate = dal.Birthdate,
                Pseudo = dal.Pseudo,
                Password = "*********"
            };
        }

        public static CustomerLoginDTO? ToLoginDTO(this Customer dal)
        {
            if (dal is null) return null;
            return new CustomerLoginDTO()
            {
                Id = dal.Id,
                Pseudo = dal.Pseudo,
                Password = "*********"
            };
        }

        public static Byte[] sha256_hash(this String value)
        {
            Byte[] result;
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                result = hash.ComputeHash(enc.GetBytes(value));
            }
            return result;
        }
    }
}
