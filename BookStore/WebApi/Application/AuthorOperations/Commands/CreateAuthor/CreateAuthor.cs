using System;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorsOperations.Command.CreateAuthor
{
    public class CreateAuthor
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorModel newAuthorModel { get; set; }

        public CreateAuthor(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var newAuthor = _mapper.Map<Author>(newAuthorModel);
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();

        }
        public class CreateAuthorModel
        {
            public string Name { get; set; }
            public string Surname {get;set;}
            public DateTime DateOfBirth { get; set; }
        }


    }
}