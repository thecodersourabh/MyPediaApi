namespace MyPediya.Services;

public interface IFamily
{
    void AddMember(Person member);
    List<Person> GetMembers();
}