using BevAPI.Models.Data;
using BevAPI.Models.Local;
using BevAPI.Models.Repository.IRepository;
using BevAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BevAPI.Models.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public AccountRepository(AppDbContext context, IConfiguration configuration, IPasswordService passwordService, IJwtService jwtService)
        {
            _context = context;
            _configuration = configuration;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        public async Task<Result<Account>> AddAsync(Account request)
        {
            try
            {
                if (!IsUniqueUser(request.Email!))
                    return new Result<Account>(false, "An account with that email already exists!");

                var account = new Account
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    PhoneNumber = request.PhoneNumber,
                    Password = _passwordService.HashPassword(request.Password!),
                };

                await _context.Accounts!.AddAsync(account);
                await _context.SaveChangesAsync();

                return new Result<Account>(account, "Account created successfully!");
            }
            catch (Exception ex)
            {
                return new Result<Account>(false, ex.ToString());
            }
        }

        public Task<Result<bool>> DeleteAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Account>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Account>> GetByIdAsync(int id)
        {
            var account = await _context.Accounts!.FindAsync(id);
            if (account == null) return new Result<Account>(false, "Account not found.");

            return new Result<Account>(account);
        }

        public async Task<Result<Account>> LoginAsync(LoginRequest request)
        {
            var account = await _context.Accounts!
               .Where(x => x.Email == request.Email)
               .FirstOrDefaultAsync();

            if (account == null || _passwordService.VerifyHash(request.Password!, account!.Password!) == false)
                return new Result<Account>(false, "Username or password is incorrect!");

            account.Token = await _jwtService.GenerateTokenAsync(account);
            account.Password = "***********";

            return new Result<Account>(account);
        }

        public Task<Result<Account>> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }

        private bool IsUniqueUser(string email) => _context.Accounts!.SingleOrDefault(x => x.Email == email) == null;
    }
}