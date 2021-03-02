using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Added";
        public static string Updated = "Updated";
        public static string Deleted = "Deleted";
        public static string NotAdded = "Not Added";
        public static string NotUpdated = "Not Updated";
        public static string NotDeleted = "Not Deleted";
        public static string CarNameInvalid = "Invalid Car Name, please enter more than 2 characters, " +
            "do not start with whitespace and enter dailyprice > 0";
        public static string Listed = "Listed";
        public static string CarNotAvailable = "Car is not available";
        public static string CarImageLimitExceeded="Car image limit exceeded; max 5 images";
        public static string CarNotExists="Car does not exist with this id";
        public static string AuthorizationDenied="Authorization denied";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "AccessToken Created";
        public static string ClaimsListed = "Claims Listed";
        public static string UserAdded = "User added";
    }
}
