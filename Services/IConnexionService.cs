using FluentAssertions.Common;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Generators;
using RocloWebApp.Models.admin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RocloWebApp.Services
{
    public class IConnexionService : IConnexion
    {
        private string filepath = "rocloapplication-df6ffaa55554.json";
        private string projectID;
        private FirestoreDb _firestoreDb;

        private readonly string key;

        public IConnexionService()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);
        }

        public IConnexionService(string key)
        {
            this.key = key;
        }
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public async Task<Object[]>  Connexion(string username, string password)
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectID = "rocloapplication";
            _firestoreDb = FirestoreDb.Create(projectID);

            Object[] adminconnect = new object[2];
            Query adminQuery = _firestoreDb.Collection("Admin");
            QuerySnapshot adminQuerySnapshot = await adminQuery.GetSnapshotAsync();
            bool authentifier = false;

            foreach (DocumentSnapshot documentSnapshot in adminQuerySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    Dictionary<string, object> admin = documentSnapshot.ToDictionary();
                    string nom = admin["nom"].ToString();
                    string motDePasse = admin["motDePasse"].ToString();

                    string json = JsonConvert.SerializeObject(admin);
                    Admin newAdmin = JsonConvert.DeserializeObject<Admin>(json);
                    newAdmin.idAdmin = documentSnapshot.Id;
                    if ( username == nom  && BCrypt.Net.BCrypt.Verify( password, motDePasse))
                    {
                        authentifier = true;
                        adminconnect[0] = newAdmin;
                    }
                }
            }

            if (!authentifier)
            {
                return null;
            }

            // Services.AddAuthentication(IISDefaults.AuthenticationScheme);

            /* var tokenHandler = new JwtSecurityTokenHandler();
             var tokenkey = Encoding.ASCII.GetBytes(key);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new Claim[]
                 {
                         new Claim(ClaimTypes.Name, username)
                 }),
                 //Expires = DateTime.UtcNow.AddHours(1),
                 SigningCredentials =
                 new SigningCredentials(
                     new SymmetricSecurityKey(tokenkey),
                     SecurityAlgorithms.HmacSha256Signature)
             };

             var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
             adminconnect[1] = token;
             return adminconnect;*/

            /*var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);*/
            return adminconnect;
        }
    }
}
