using System.Data.Common;
using System.Diagnostics;
using Npgsql;
using NpgsqlTypes;

public sealed class PersonDAO : NpgsqlDAO
{
    public PersonDAO() : base("person", "id") { }

    public PersonDAO(string table, string idTable) : base(table, idTable) { }

    public PersonDAO(DbConnection conexao, string table, string idTable) : base(conexao, table, idTable) { }

    public override void Create(IEntity entity)  {
        Person person = (Person)entity;
        try {
            this.OpenConnection();
            using (var cmd = new NpgsqlCommand()) {
                cmd.Connection = (NpgsqlConnection)this.Connection;
                cmd.CommandText = $"INSERT INTO { this.Table } (name, lastname, birthday) VALUES (@Name, @Lastname, @Birthday) RETURNING id";
                cmd.Parameters.AddWithValue("Name", person.Name);
                cmd.Parameters.AddWithValue("Lastname", person.Lastname);
                cmd.Parameters.AddWithValue("Birthday", person.Birthday);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    throw new Exception("Failed to get the generated ID after insertion.");   
                person.Id = Convert.ToInt32(result);
            }
        }
        catch (Exception ex) {
            throw new Exception("DB_INSERT_ERROR", ex);
        }
        finally {
            this.CloseConnection();
        }        
    }

    public override IEnumerable<IEntity> Read(IEntity entity) {        
        List<IEntity> entityList = new List<IEntity>();
        try {
            this.OpenConnection();
            using (var cmd = new NpgsqlCommand()) {
                cmd.Connection = (NpgsqlConnection)this.Connection;
                cmd.CommandText = $"SELECT * FROM {this.Table}";
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        Person person = new Person {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString(),
                            Lastname = reader["lastname"].ToString(),
                            Birthday = reader["birthday"] is DBNull ? (DateTime?)null : Convert.ToDateTime(reader["birthday"])
                        };
                        entityList.Add(person);
                    }
                }
            }
        } catch (Exception ex) {
            throw new Exception("DB_READ_ERROR", ex);
        } finally {
            this.CloseConnection();
        }
        return entityList;
    }

    public override void Update(IEntity entity) {
        Person person = (Person)entity;
        try {
            this.OpenConnection();
            using (var cmd = new NpgsqlCommand()) {
                cmd.Connection = (NpgsqlConnection)this.Connection;
                cmd.CommandText = $"UPDATE { this.Table } SET name = @Name, lastname = @Lastname, birthday = @Birthday WHERE id = @Id";
                cmd.Parameters.AddWithValue("Id", person.Id);
                cmd.Parameters.AddWithValue("Name", person.Name);
                cmd.Parameters.AddWithValue("Lastname", person.Lastname);
                cmd.Parameters.AddWithValue("Birthday", person.Birthday);
                cmd.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            throw new Exception("DB_UPDATE_ERROR", ex);
        } finally {
            this.CloseConnection();
        }
    }

    public override void Delete(IEntity entity) {
        Person person = (Person)entity;
        try {
            this.OpenConnection();
            using (var cmd = new NpgsqlCommand()) {
                cmd.Connection = (NpgsqlConnection)this.Connection;
                cmd.CommandText = $"DELETE FROM { this.Table } WHERE id = @Id";
                cmd.Parameters.AddWithValue("Id", person.Id);
                cmd.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            throw new Exception("DB_DELETE_ERROR", ex);
        } finally {
            this.CloseConnection();
        }
    }

}// class
