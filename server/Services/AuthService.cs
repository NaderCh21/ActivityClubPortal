using ActivityClubPortal.Models; // Add this line for Admin
using ActivityClubPortal.Repositories; // Add this line for AdminRepository

public class AuthService
{
    private readonly AdminRepository _adminRepository;

    public AuthService(AdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public bool AuthenticateAdmin(string username, string password)
    {
        var admin = _adminRepository.GetAdminByUsername(username);

        if (admin == null)
            return false;

        return admin.VerifyPassword(password);
    }
}
