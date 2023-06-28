using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_NET_Angular_RCD_Bibliotheque.BLL.Exceptions
{
    internal class AlreadyExistException : Exception
    {
        public AlreadyExistException() : base("L'entité existe déja")
        {
        }

        public AlreadyExistException(string? message) : base(message)
        {
        }
    }
}
