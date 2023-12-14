using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;
using Library.Domain.Entities;

namespace Library.Application.Authors.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQueryHandler
        : IRequestHandler<GetAuthorDetailsQuery, AuthorDetailsViewModel>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQueryHandler(ILibraryDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<AuthorDetailsViewModel> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Authors
                            .FirstOrDefaultAsync(genre =>
                            genre.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            return _mapper.Map<AuthorDetailsViewModel>(entity);
        }
    }
}
