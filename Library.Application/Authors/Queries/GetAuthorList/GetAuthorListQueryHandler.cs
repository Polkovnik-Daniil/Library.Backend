using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler
        : IRequestHandler<GetAuthorListQuery, AuthorListViewModel>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorListQueryHandler(ILibraryDbContext dbContext,
           IMapper mapper) =>
           (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<AuthorListViewModel> Handle(GetAuthorListQuery request,
            CancellationToken cancellationToken)
        {
            var authorsQuery = await _dbContext.Genres
                //.Where(author => author.Id == request.Id)
                .ProjectTo<AuthorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AuthorListViewModel { Authors = authorsQuery };
        }
    }
}
