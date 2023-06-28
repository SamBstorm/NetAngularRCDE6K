﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                Password = dto.Password,
            };
        }
    }
}
