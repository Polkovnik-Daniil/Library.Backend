using AutoMapper;
using Library.Application.Authors.Queries.GetAuthorList;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Genres.Queries.GetGenreDetails
{
    public class GetGenreDetailsQueryHandler 
        : IRequestHandler<GetGenreDetailsQuery, GenreDetailsViewModel> 
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreDetailsQueryHandler(ILibraryDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GenreDetailsViewModel> Handle(GetGenreDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Genres
                .FirstOrDefaultAsync(genre =>
                genre.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }

            return _mapper.Map<GenreDetailsViewModel>(entity);
        }
    }
}
