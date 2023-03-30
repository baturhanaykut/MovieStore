using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Domain.Entities
{
    public interface IBaseEntity
    {
        public Status Statu { get; set; }
    }
}
