using BankLoanManagement.Models.DTOs;

namespace BankLoanManagement.Interfaces
{
    public interface IUserService
    {
        public UserDTO Login(UserDTO userDTO);
        public UserDTO Register(UserDTO userDTO);
    }
}
