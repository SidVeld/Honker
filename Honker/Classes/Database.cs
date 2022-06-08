using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Data;
using System;
using System.Collections.Generic;

namespace Honker
{
    public class Database
    {
        public int CurrentId { get; set; }
        
        private string databaseName;
        private string connectionString;
        private SQLiteConnection connection;

        private void SetupDatabase()
        {
            SQLiteCommand initCommand;
            string commandText;

            databaseName = "HonkerDatabase.db";
            connectionString = $"Data Source={databaseName}";

            if (!File.Exists(databaseName))
                SQLiteConnection.CreateFile(databaseName);

            connection = new(connectionString);
            connection.Open();

            commandText = @"
                CREATE TABLE IF NOT EXISTS characters (
                    id          INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    name        TEXT DEFAULT 'Unnamed',
                    spec        TEXT DEFAULT 'Space Clown',
                    age         TEXT DEFAULT '30',
                    bloodtype   TEXT DEFAULT 'A+',
                    race        TEXT DEFAULT 'Human',
                    build       TEXT DEFAULT 'Average',
                    height      TEXT DEFAULT 'Average',
                    hairstyle   TEXT DEFAULT 'Bald',
                    hairColor   TEXT DEFAULT 'Black',
                    eyeColor    TEXT DEFAULT 'Blue',
                    backstory   TEXT DEFAULT 'Space clown from deep space!',
                    recordsGen  TEXT DEFAULT 'General records.',
                    recordsMed  TEXT DEFAULT 'Medical records.',
                    recordsSec  TEXT DEFAULT 'Security records.',
                    recordsEmp  TEXT DEFAULT 'Employee records.',
                    flavor      TEXT DEFAULT 'Big nose.'
                );";
            
            initCommand = new(commandText, connection);
            initCommand.ExecuteNonQuery();
        }
        
        public Database()
        {
            SetupDatabase();
            HandleEmptyTable();
            CurrentId = GetFirstCharacterId();
        }

        private static string GetColumns()
        {
            StringBuilder columns;

            columns = new();

            columns.Append("name, ");
            columns.Append("spec, ");
            columns.Append("age, ");
            columns.Append("bloodtype, ");
            columns.Append("race, ");
            columns.Append("build, ");
            columns.Append("height, ");
            columns.Append("hairstyle, ");
            columns.Append("haircolor, ");
            columns.Append("eyeColor, ");
            columns.Append("backstory, ");
            columns.Append("recordsGen, ");
            columns.Append("recordsMed, ");
            columns.Append("recordsSec, ");
            columns.Append("recordsEmp, ");
            columns.Append("flavor");

            return columns.ToString();
        }

        private void HandleEmptyTable()
        {
            if (IsTableEmpty())
                InsertNewCharacterTemplate();
        }

        public void InsertNewCharacter(Character character)
        {
            SQLiteCommand insertCommand;
            string commandText;
            string values;
            string columns;

            columns = GetColumns();
            values = character.GetValuesSQL();

            commandText = $"INSERT INTO characters ({columns}) VALUES ({values});";

            insertCommand = new(commandText, connection);
            insertCommand.ExecuteNonQuery();

            CurrentId = GetLastCharacterId();
        }

        public void InsertNewCharacterTemplate()
        {
            Character characterTemplate;
            characterTemplate = CharacterFactory.CreateChracterTemplate();
            InsertNewCharacter(characterTemplate);
        }

        public void UpdateCharacter(Character character)
        {
            SQLiteCommand updateCommand;
            string commandText;
            string values;
            string columns;

            columns = GetColumns();
            values = character.GetValuesSQL();

            commandText = $"UPDATE characters SET ({columns}) = ({values}) WHERE id = {CurrentId}";

            updateCommand = new(commandText, connection);
            updateCommand.ExecuteNonQuery();
        }

        public void DeleteCharacter()
        {
            SQLiteCommand deleteCommand;
            string commandText;

            commandText = $"DELETE FROM characters WHERE id = {CurrentId}";

            deleteCommand = new(commandText, connection);
            deleteCommand.ExecuteNonQuery();
            
            HandleEmptyTable();
            CurrentId = GetFirstCharacterId();
        }

        public DataView GetCharactersDataView()
        {
            SQLiteDataAdapter dataAdapter;
            string commandText;
            DataTable dataTable;

            dataTable = new();
            commandText = "SELECT id, name, age, spec, race, bloodtype FROM characters";
            dataAdapter = new(commandText, connection);
            dataAdapter.Fill(dataTable);

            return dataTable.AsDataView();
        }

        public bool IsTableEmpty()
        {
            SQLiteDataReader dataReader;
            SQLiteCommand selectCommand;
            string commandText;

            commandText = "SELECT * FROM characters";
            selectCommand = new(commandText, connection);

            dataReader = selectCommand.ExecuteReader();

            if (dataReader.HasRows)
                return false;
            return true;
        }

        public bool IsCharacterExists(int id)
        {
            SQLiteDataReader dataReader;
            SQLiteCommand selectCommand;
            string commandText;
            int tableID;

            commandText = $"SELECT * FROM characters WHERE id={id}";

            selectCommand = new(commandText, connection);

            dataReader = selectCommand.ExecuteReader();
            
            while (dataReader.Read())
            {
                tableID = Convert.ToInt32(dataReader.GetValue(0));
                if (tableID == id)
                    return true;
            }
            return false;
        }

        public Dictionary<string, string> GetCharacterDataById()
        {
            string name;
            string spec;
            string age;
            string bloodtype;
            string race;
            string build;
            string height;
            string hairstyle;
            string hairColor;
            string eyeColor;
            string backstory;
            string recordsGen;
            string recordsMed;
            string recordsSec;
            string recordsEmp;
            string flavor;

            SQLiteDataReader dataReader;
            SQLiteCommand selectCommand;
            string commandText;

            Dictionary<string, string> characterData;

            commandText = $"SELECT * FROM characters WHERE id={CurrentId}";
            selectCommand = new(commandText, connection);

            dataReader = selectCommand.ExecuteReader();
            dataReader.Read();

            name = dataReader.GetValue(1).ToString();
            spec = dataReader.GetValue(2).ToString();
            age = dataReader.GetValue(3).ToString();
            bloodtype = dataReader.GetValue(4).ToString();
            race = dataReader.GetValue(5).ToString();
            build = dataReader.GetValue(6).ToString();
            height = dataReader.GetValue(7).ToString();
            hairstyle = dataReader.GetValue(8).ToString();
            hairColor = dataReader.GetValue(9).ToString();
            eyeColor = dataReader.GetValue(10).ToString();
            backstory = dataReader.GetValue(11).ToString();
            recordsGen = dataReader.GetValue(12).ToString();
            recordsMed = dataReader.GetValue(13).ToString();
            recordsSec = dataReader.GetValue(14).ToString();
            recordsEmp = dataReader.GetValue(15).ToString();
            flavor = dataReader.GetValue(16).ToString();

            characterData = new()
            {
                { "name", name },
                { "spec", spec },
                { "age", age },
                { "bloodtype", bloodtype },
                { "race", race },
                { "build", build },
                { "height", height },
                { "hairstyle", hairstyle },
                { "hairColor", hairColor },
                { "eyeColor", eyeColor },
                { "backstory", backstory },
                { "recordsGen", recordsGen },
                { "recordsMed", recordsMed },
                { "recordsSec", recordsSec },
                { "recordsEmp", recordsEmp },
                { "flavor", flavor }
            };

            return characterData;
        }

        private int GetFirstCharacterId()
        {
            SQLiteDataReader dataReader;
            SQLiteCommand selectCommand;
            string commandText;
            int id;

            commandText = $"SELECT * FROM characters";
            selectCommand = new(commandText, connection);

            dataReader = selectCommand.ExecuteReader();
            dataReader.Read();

            id = Convert.ToInt32(dataReader.GetValue(0));

            return id;
        }

        private int GetLastCharacterId()
        {
            SQLiteDataReader dataReader;
            SQLiteCommand selectCommand;
            string commandText;
            int id;
            
            id = GetFirstCharacterId();

            commandText = $"SELECT * FROM characters";
            selectCommand = new(commandText, connection);

            dataReader = selectCommand.ExecuteReader();


            while (dataReader.Read())
            {
                id = Convert.ToInt32(dataReader.GetValue(0));
            }

            return id;
        }

    }
}