public struct Leaf
{
    public string md5;
    public string name;
    public bool required;
    public string path;
    public Leaf(string md5, string name, bool required, string route="")
    {
        this.md5 = md5;
        this.name = name;
        this.required = required;
        this.path = route;
    }
}

public struct AllDataToDownload
{
    public string md5;

    public string urlFile;

    public string nameFile;

    public string pathDownload;
    

    public AllDataToDownload(string md5, string urlFile, string nameFile, string pathDownload)
    {
        this.md5 = md5;
        this.urlFile = urlFile;
        this.nameFile = nameFile;
        this.pathDownload = pathDownload;
    }
}