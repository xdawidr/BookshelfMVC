﻿namespace BookshelfMVC.Domain.Model
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
