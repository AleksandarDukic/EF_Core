// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

PubContext _context = new PubContext();
//InserNewAuthorWithNewBook();
//AddNewBookToExistingAuthorInMemory();
deleteAuthor();
void InserNewAuthorWithNewBook()
{
    var author = new Author { FirstName = "Lynda", LastName = "Rutledhe" };
    author.Books.Add(new Book
    {
        Title = "West With Giraffes",
        PublishDate = new DateTime(2021, 2, 1)
    });

    _context.Authors.Add(author);
    _context.SaveChanges();
}

void AddNewBookToExistingAuthorInMemory()
{
    var author = _context.Authors.FirstOrDefault(a => a.LastName == "Rutledhe");
    if (author != null)
    {
        author.Books.Add(
            new Book { Title = "Wool", PublishDate = new DateTime(2012, 1, 1) }
            );
    }
    _context.SaveChanges();

}

void deleteAuthor()
{
    var author = _context.Authors.FirstOrDefault(a => a.LastName == "Rutledhe");
    _context.Authors.Remove(author);
    _context.SaveChanges();
}