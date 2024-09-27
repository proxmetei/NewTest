namespace NewTest.Context;

public class DbSettings
{
    public string ConnectionString { get; private set; }
    public DbInitSettings Init { get; private set; }
}

public class DbInitSettings
{
    public bool AddDemoData { get; private set; }
}