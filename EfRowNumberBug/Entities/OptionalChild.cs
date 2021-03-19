using System;
using System.Collections.Generic;

namespace EfRowNumberBug.Entities
{
    public class OptionalChild
    {
        public Guid Id { get; set; }
        public ICollection<Parent>? Parents { get; set; }
        public ulong Version { get; set; }
    }
}