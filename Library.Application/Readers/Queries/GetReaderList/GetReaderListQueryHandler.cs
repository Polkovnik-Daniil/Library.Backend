using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using Library.Application.Users.Queries.GetUserList;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Readers.Queries.GetReaderList
{
    public class GetReaderListQueryHandler
                : IRequestHandler<GetReaderListQuery, ReaderListViewModel>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReaderListQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ReaderListViewModel> Handle(GetReaderListQuery request,
            CancellationToken cancellationToken)
        {
            var readersQuery = await _dbContext.Readers
                //.Where(user => user.Id == request.Id)
                .ProjectTo<ReaderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReaderListViewModel { Readers = readersQuery };
        }
    }
}
