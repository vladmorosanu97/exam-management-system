using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models
{
    public class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
    }
}
