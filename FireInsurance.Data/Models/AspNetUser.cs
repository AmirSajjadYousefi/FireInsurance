using System;
using System.Collections.Generic;

#nullable disable

namespace FireInsurance.Data.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            BankCards = new HashSet<BankCard>();
            UserFiles = new HashSet<UserFile>();
            UserScores = new HashSet<UserScore>();
            UserTransactions = new HashSet<UserTransaction>();
            Wallets = new HashSet<Wallet>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCardId { get; set; }
        public string GeneratedIdentifierCode { get; set; }
        public string IdentifierCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int CityId { get; set; }
        public int UserStatus { get; set; }
        public string ActiveCode { get; set; }
        public bool IsForeigners { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime? CreateForgotPasswordTokenDateTime { get; set; }
        public string ForgotPasswordToken { get; set; }
        public string LocationCode { get; set; }
        public string ProfileImageName { get; set; }
        public int PofileImageStatus { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<BankCard> BankCards { get; set; }
        public virtual ICollection<UserFile> UserFiles { get; set; }
        public virtual ICollection<UserScore> UserScores { get; set; }
        public virtual ICollection<UserTransaction> UserTransactions { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
