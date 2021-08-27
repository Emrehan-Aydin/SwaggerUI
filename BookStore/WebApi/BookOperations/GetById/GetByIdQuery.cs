using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetByIdQuery
{
    public class BookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }  
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private IMapper _mapper;
        public int Id { get; set; }

        public GetByIdQuery(BookStoreDbContext Dbcontext,IMapper mapper)
        {
            _dbContext = Dbcontext;
            _mapper = mapper;
        }

        public BookModel Handle()
        {
            var book = _dbContext.Books.Where(book=> book.Id==this.Id).FirstOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            else
            {
                BookModel model = _mapper.Map<BookModel>(book);
                return model;
            }  
        }
        
    }
}
