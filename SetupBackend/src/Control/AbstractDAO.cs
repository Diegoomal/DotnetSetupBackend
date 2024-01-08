using System.Data;
using System.Data.Common;

public abstract class AbstractDAO : IDAO {

    protected bool CtrlTransaction = true;
    protected string Table;
    protected string TableId;
    protected string Host = string.Empty;
    protected string Port = string.Empty;
    protected string Username = string.Empty;
    protected string Password = string.Empty;
    protected string Database = string.Empty;
    protected string ConnectionStringPattern = "Host={0};Port={1};Username={2};Password={3};Database={4}";
    protected string ConnectionString = string.Empty;
    protected DbConnection Connection;

    public AbstractDAO(string table, string tableId)
    {
        this.Table = table;
        this.TableId = tableId;
    }

    public AbstractDAO(DbConnection Connection, string Table, string TableId)
    {
        this.Table = Table;
        this.TableId = TableId;
        this.Connection = Connection;
    }

    protected virtual string GetConnectionString() 
    {
        string FormattedConnectionString = string.Format(ConnectionString, Host, Port, Username, Password, Database);
        return FormattedConnectionString;
    }

    protected virtual DbConnection GetConnection() {
        throw new NotImplementedException();
    }

    protected virtual void OpenConnection() 
    {
        try {
            if (this.Connection == null || ConnectionState.Closed.Equals(this.Connection.State) ) {
                this.Connection = this.GetConnection();
                this.Connection.Open();
            }
        }
        catch (Exception ex) {
            throw new Exception("BD_OPENCONNECTION_ERROR");
        }
    }

    protected virtual void CloseConnection()
    {
        if (this.Connection != null) {
            this.Connection.Close();
            this.Connection.Dispose();
        }
    }

    protected virtual DbCommand GetCommand(DbConnection connection) 
    {
        return connection.CreateCommand();
    }
  
    public virtual void Create(IEntity entity) {
        throw new NotImplementedException();
    }

    public virtual IEnumerable<IEntity> Read(IEntity entity) {
        throw new NotImplementedException();
    }

    public virtual void Update(IEntity entity) {
        throw new NotImplementedException();
    }

    public virtual void Delete(IEntity entity) {
        throw new NotImplementedException();
    }

}// class