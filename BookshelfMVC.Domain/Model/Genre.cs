﻿namespace BookshelfMVC.Domain.Model
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
