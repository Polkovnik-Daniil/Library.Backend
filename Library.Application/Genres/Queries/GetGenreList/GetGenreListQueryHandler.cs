using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Genres.Queries.GetGenreList
{
    public class GetGenreListQueryHandler
        : IRequestHandler<GetGenreListQuery, GenreListViewModel>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreListQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GenreListViewModel> Handle(GetGenreListQuery request,
            CancellationToken cancellationToken)
        {
            var genresQuery = await _dbContext.Genres
                //.Where(genre => genre.Id == request.Id)
                .ProjectTo<GenreLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GenreListViewModel { Genres = genresQuery };
        }
    }
}
