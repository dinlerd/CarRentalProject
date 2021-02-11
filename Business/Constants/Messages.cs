using System;
using System.Collections.Generic;
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
    }
}
