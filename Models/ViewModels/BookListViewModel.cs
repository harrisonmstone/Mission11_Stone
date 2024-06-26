﻿namespace Mission11_Stone.Models.ViewModels
{
    public class BookListViewModel
    {
        public IQueryable<Book> Books { get; set;}

        public PaginationInfo PaginationInfo { get; set;} = new PaginationInfo();

        public string? CurrentProjectType { get; set;}
    }
}
