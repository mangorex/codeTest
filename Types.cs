public struct Leaf
{
    public string md5;
    public string name;
    public bool required;

    public Leaf(string md5, string name, bool required)
    {
        this.md5 = md5;
        this.name = name;
        this.required = required;
    }
}