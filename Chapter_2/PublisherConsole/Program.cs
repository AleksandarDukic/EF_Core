// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

PubContext _context = new PubContext();
UnAssignAnArtistFromCover();
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

void ConnectExistingArtistAndCoverObjects()
{
    var artistA = _context.Artists.Find(1);
    var artistB = _context.Artists.Find(2);
    var coverA = _context.Covers.Find(1);
    if (artistA != null && artistB != null && coverA != null)
    {
        coverA.Artists.Add(artistA);
        coverA.Artists.Add(artistB);
    }


    _context.SaveChanges();

}

void CreateNewCoverWithExistingArtist()
{
    var artistA = _context.Artists.Find(1);
    var cover = new Cover
    {
        DesignIdeas = "Author has provided a photo"
    };

    cover.Artists.Add(artistA);
    _context.Covers.Add(cover);
    _context.SaveChanges();
}

void CreateNewCoverAndArtistTogether()
{
    var newArtist = new Artist
    {
        FirstName = "Kir",
        LastName = "Talmage"
    };

    var newCover = new Cover
    {
        DesignIdeas = "We like birds!"
    };

    newArtist.Covers.Add(newCover);
    _context.Artists.Add(newArtist);
    _context.SaveChanges();



}

void RetrieveAnArtistWithTheirCovers()
{
    var artistWithCovers = _context.Artists.Include(a => a.Covers).FirstOrDefault(a => a.ArtistId == 1);
    Console.Write(artistWithCovers);
}

void UnAssignAnArtistFromCover()
{
    var coverwithartist = _context.Covers
        .Include(c => c.Artists.Where(a => a.ArtistId == 1))
        .FirstOrDefault();
    coverwithartist.Artists.RemoveAt(0);
    _context.ChangeTracker.DetectChanges();
    var debugview = _context.ChangeTracker.DebugView.ShortView;
    _context.SaveChanges();
}