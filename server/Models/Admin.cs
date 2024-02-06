using System;
using System.Collections.Generic;
using System.Security.Cryptography; // Add this line
using System.Text; // Add this line

namespace ActivityClubPortal.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; } = null!;
        private string PasswordHash { get; set; } = null!;

        // Public property for the database column 'Password'
        public string Password
        {
            // Getter returns the hashed password for external use
            get => PasswordHash;

            // Setter hashes the provided password
            set
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                    PasswordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                }
            }
        }

           public bool VerifyPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedInput = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return PasswordHash == hashedInput;
            }
        }


        // ... other methods ...
    }
}
