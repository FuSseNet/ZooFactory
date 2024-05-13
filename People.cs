public abstract class People
{
    private string name;
    private string gender;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }
    public abstract void status();
}