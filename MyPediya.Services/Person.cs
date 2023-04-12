using System.Text.Json.Serialization;

namespace MyPediya.Services;

public class Person
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Gender { get; set; }
    public List<Person> Children { get; set; } = new List<Person>();
    public Guid? ParentId { get; set; }

    public Person(string name, string gender, string dateOfBirth, Guid parentId)
    {

        Name = name;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        ParentId = parentId;
    }

    public void AddChild(Person child)
    {
        Children.Add(child);
        child.ParentId = child.ParentId;
    }

    public override string ToString()
    {
        return $"{Name}, {Gender},{DateOfBirth}";
    }
}


