using System;

namespace EfRowNumberBug.Entities
{
    public class Parent
    {
        public Guid Id { get; set; }
        public OptionalChild? OptionalChild { get; set; }
    }
}