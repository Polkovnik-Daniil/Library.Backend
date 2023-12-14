using MediatR;

namespace Library.Application.Users.Queries.GetUserDetails
{
    /// <summary>
    /// Класс содержащий те поля которые необходимы для получения уточняющей информации
    /// т.е. он содержит ту информацию которая касаятся запроса относильного какого-то пользователя
    /// </summary>
    public class GetUserDetailsQuery : IRequest<UserDetailsViewModel>
    {
        #region Fields
        public Guid Id { get; set; }
        #endregion
    }
}
