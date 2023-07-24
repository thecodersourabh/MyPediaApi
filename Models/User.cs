using MongoDB.Bson;

namespace Models;

public class Users
{
    public ObjectId _id { get; set; }
    public string EmailId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    //public string MobileNumber { get; set; }
    // Add other user details as needed
}

