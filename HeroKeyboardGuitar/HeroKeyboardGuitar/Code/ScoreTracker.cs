using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace HeroKeyboardGuitar;

internal static class ScoreTracker
{

    private const string sshHost = "99.78.67.225";
    private const string sshUsername = "dbuser"; // SSH username
    private const string sshPassword = "dbuser"; // SSH password
    private const int sshPort = 22;

    private const string mysqlHost = "localhost";
    private const int mysqlPort = 3306;
    private const string mysqlDatabase = "PlayerScoresDB";
    private const string mysqlUser = "dbuser";
    private const string mysqlPassword = "dbuser";

    private static SshClient sshClient;
    private static ForwardedPortLocal portForwarded;

    private static void SetupSshTunnel()
    {
        using (sshClient = new SshClient(sshHost, sshPort, sshUsername, sshPassword))
        {
            sshClient.HostKeyReceived += delegate (object sender, HostKeyEventArgs e)
            {
                e.CanTrust = true;
            };

            sshClient.Connect();

            portForwarded = new ForwardedPortLocal("localhost", (uint)mysqlPort, mysqlHost, (uint)mysqlPort);
            sshClient.AddForwardedPort(portForwarded);
            portForwarded.Start();

        }
    }

    private static void CloseSshTunnel()
    {
        if (portForwarded != null)
        {
            portForwarded.Stop();
            portForwarded.Dispose();
        }

        if (sshClient != null)
        {
            sshClient.Disconnect();
            sshClient.Dispose();
        }
    }

    private static string GetMySqlConnectionString()
    {
        return $"Server={mysqlHost};Port={mysqlPort};Database={mysqlDatabase};Uid={mysqlUser};Pwd={mysqlPassword};";
    }

    private static void CreateSongTableIfNotExists(string tableName)
    {
        using (MySqlConnection connection = new MySqlConnection(GetMySqlConnectionString()))
        {
            string query = $"CREATE TABLE IF NOT EXISTS `{tableName}` (" +
                           "PlayID INT PRIMARY KEY AUTO_INCREMENT," +
                           "PlayerID VARCHAR(3)," +
                           "PlayTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                           "Score VARCHAR(10);";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    internal static void InsertPlayData(string tableName, string playerId, string score)
    {
        SetupSshTunnel();

        CreateSongTableIfNotExists(tableName);
        using (MySqlConnection connection = new MySqlConnection(GetMySqlConnectionString()))
        {
            string query = $"INSERT INTO `{tableName}` (PlayerID, Score) VALUES (@PlayerID, @Score)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PlayerID", playerId);
                command.Parameters.AddWithValue("@Score", score);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        CloseSshTunnel();
    }

    internal static DataTable RetrievePlayData(string tableName)
    {
        SetupSshTunnel();
        DataTable playDataTable = new DataTable();
        using (MySqlConnection connection = new MySqlConnection(GetMySqlConnectionString()))
        {
            string query = $"SELECT * FROM `{tableName}`";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(playDataTable);
        }
        CloseSshTunnel();
        return playDataTable;
    }

}

