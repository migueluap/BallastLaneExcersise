using Microsoft.Data.SqlClient;

namespace BallastLane.Infra.Data.Context;

public class BallastLaneContextNotEF<TEntity> where TEntity : class
{
    private readonly string connectionString;

    public BallastLaneContextNotEF(string connectionString)
    {
        this.connectionString = connectionString;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public void Add(TEntity entity)
    {
        using (SqlConnection connection = GetConnection())
        {
            connection.Open();

            string tableName = typeof(TEntity).Name;

            string query = $"INSERT INTO {tableName} ({GetColumnNames()}) VALUES ({GetParameterNames()})";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                MapParameters(command, entity);

                command.ExecuteNonQuery();
            }
        }
    }

    public TEntity Get(int id)
    {
        using (SqlConnection connection = GetConnection())
        {
            connection.Open();

            string tableName = typeof(TEntity).Name;

            string query = $"SELECT * FROM {tableName} WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapEntity(reader);
                    }
                }
            }
        }

        return null;
    }

    public void Update(TEntity entity)
    {
        using (SqlConnection connection = GetConnection())
        {
            connection.Open();

            string tableName = typeof(TEntity).Name;

            string query = $"UPDATE {tableName} SET {GetUpdateColumns()} WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                MapParameters(command, entity);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int id)
    {
        using (SqlConnection connection = GetConnection())
        {
            connection.Open();

            string tableName = typeof(TEntity).Name;

            string query = $"DELETE FROM {tableName} WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }

    private string GetColumnNames()
    {
        return string.Join(", ", typeof(TEntity).GetProperties().Select(prop => prop.Name));
    }

    private string GetParameterNames()
    {
        return string.Join(", ", typeof(TEntity).GetProperties().Select(prop => $"@{prop.Name}"));
    }

    private string GetUpdateColumns()
    {
        return string.Join(", ", typeof(TEntity).GetProperties().Select(prop => $"{prop.Name} = @{prop.Name}"));
    }

    private void MapParameters(SqlCommand command, TEntity entity)
    {
        foreach (var prop in typeof(TEntity).GetProperties())
        {
            command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity));
        }
    }

    private TEntity MapEntity(SqlDataReader reader)
    {
        var entity = Activator.CreateInstance<TEntity>();

        foreach (var prop in typeof(TEntity).GetProperties())
        {
            prop.SetValue(entity, reader[prop.Name]);
        }

        return entity;
    }

}
