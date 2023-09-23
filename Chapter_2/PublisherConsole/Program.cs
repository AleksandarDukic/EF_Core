// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;


PubContext _context = new PubContext();

QueryFilters();

void QueryFilters()
{
    var authors = _context.Authors.Where(s => EF.Functions.Like(s.LastName, "L%")).ToList();
}