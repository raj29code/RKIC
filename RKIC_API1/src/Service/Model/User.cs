using MongoDB.Bson;
using Service.Model.comman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Service.Model
{
   public class User: BaseModel
    {
        public ObjectId _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; private set; }
        public string IdentityId { get; private set; }
        public List<RefreshToken> RefreshTokens = new List<RefreshToken>();
        public static User From(User data)
        {

            return new User()
            {
                _id = ObjectId.GenerateNewId(),
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                UserName = data.UserName,
                Password = data.Password,
                PasswordHash = data.PasswordHash,
                CreatedBy = data.CreatedBy,
                CreatedDateTime = DateTime.Now.ToString(),
                LastUpdatedDateTime = DateTime.Now.ToString(),
                LastUpdatedBy = data.LastUpdatedBy,
                IsActive = true,
            };
        }

        public bool HasValidRefreshToken(string refreshToken)
        {
            return RefreshTokens.Any(rt => rt.Token == refreshToken && rt.Active);
        }

        public void AddRefreshToken(string token, string userId, string remoteIpAddress, double daysToExpire = 5)
        {
            RefreshTokens.Add(new RefreshToken(token, DateTime.UtcNow.AddDays(daysToExpire), userId, remoteIpAddress));
        }

        public void RemoveRefreshToken(string refreshToken)
        {
            RefreshTokens.Remove(RefreshTokens.First(t => t.Token == refreshToken));
        }

    }
}
