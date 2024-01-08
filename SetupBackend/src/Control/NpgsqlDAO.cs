using System;
using System.Data;
using System.Data.Common;
using Npgsql;

public class NpgsqlDAO : AbstractDAO {

    public NpgsqlDAO() : base("Table", "TableId") {
        this.Connection = this.GetConnection();
    }

    public NpgsqlDAO(string table, string tableId) : base(table, tableId) {
        this.Connection = this.GetConnection();
    }

    public NpgsqlDAO(DbConnection connection, string table, string tableId) : base(connection, table, tableId) {
        if (!(connection is NpgsqlConnection))
            throw new ArgumentException("The provided connection must be of type NpgsqlConnection.");
    }

    // If necessary, implement the abstract class methods

    protected override string GetConnectionString() 
    {
        this.Host = "localhost";
        this.Port = "5433";
        this.Username = "postgres";
        this.Password = "pwd123";
        this.Database = "project";
        this.ConnectionString = string.Format(
            this.ConnectionStringPattern, 
            this.Host, this.Port, this.Username, 
            this.Password, this.Database
        );
        return this.ConnectionString;
    }

    protected override DbConnection GetConnection() 
    {
        try {
            DbConnection connection = new NpgsqlConnection( this.GetConnectionString() );;
            return connection;
        } catch (NpgsqlException) {
            throw new Exception("BD_ERROR_CONNECTION");
        } catch (Exception) {
            throw new Exception("BD_ERROR_CONNECTION");
        }
    }

}// class
