using MySqlConnector;
using simpleDuolingo.Entities;
namespace simpleDuolingo;

public class LanguageRepository
{
    private DBDriver _dbDriver;
    public Exception? ThrownException;

    public LanguageRepository(DBDriver dbDriver)
    {
        _dbDriver = dbDriver;
    }

    public List<Language> GetLang()
    {
        List<Language> languages = new List<Language>();

        using (var reader = _dbDriver.ExecuteReader("SELECT * FROM languages"))
        {
            while (reader.Read())
            {
                languages.Add(new Language
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    CreatedAt = reader.GetDateTime(2),
                    ModifiedAt = reader.GetDateTime(3),
                });
            }
        }

        return languages;
    }

    public void InsertLang(string name)
    {
        using (var connection = _dbDriver.GetConnection())
        {
            using (var command = new MySqlCommand("INSERT INTO languages (name) VALUES (@name);", connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
        }
    }
    
    public void DeteteLangWithId(int id)
    {
        MySqlConnection connection = _dbDriver.GetConnection();
        try
        {
            string query = "DELETE FROM languages WHERE id = @id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            int effectedRows = command.ExecuteNonQuery();
            if (effectedRows == 0)
            {
                ThrownException = new InvalidUserException(id);
            }
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
        }
    }
}