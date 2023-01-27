using System.Data.SQLite;

public abstract class BaseDAO
{
    private string DataSourceFile => Environment.CurrentDirectory + "AppTarefasDB.sqlite";
    public SQLiteConnection Connection => new SQLiteConnection("DataSource=" + DataSourceFile);
}