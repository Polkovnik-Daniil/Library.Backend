using AutoMapper;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Application.Users.Queries.GetUserDetails;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQueryHandler
        : IRequestHandler<GetBookDetailsQuery, BookDetailsViewModel>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookDetailsQueryHandler(ILibraryDbContext dbContext,
           IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BookDetailsViewModel> Handle(GetBookDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Books
                .Include(m => m.Authors)
                .Include(m => m.Readers)
                .Include(m=>m.Genres)
                .FirstOrDefaultAsync(entity =>
                entity.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }
            return _mapper.Map<BookDetailsViewModel>(entity);
        }
    }
}
