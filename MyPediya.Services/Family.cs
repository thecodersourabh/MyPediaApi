namespace MyPediya.Services;

public class Family : IFamily
{
    public List<Person> Members { get; set; }

    public Family()
    {
        Members = new List<Person>();
    }

    public void AddMember(Person member)
    {
        Members.Add(member);
    }

    public List<Person> GetMembers()
    {
        return Members;
    }
}