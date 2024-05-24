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

/*
 * this page right here is a god damn godsend https://mysqlconnector.net/tutorials/connect-ssh/
 * reference btw
 */

internal static class ScoreTracker
{

    private const string sshHost = "";
    private const string sshUsername = "";
    private const string sshPassword = "";
    private const int sshPort = 22;

    private const string mysqlHost = "";
    private const int mysqlPort = 3306;
    private const string mysqlDatabase = "PlayerScoresDB";
    private const string mysqlUser = "";
    private const string mysqlPassword = "";

    private static SshClient sshClient;
    private static ForwardedPortLocal portForwarded;

    private static (SshClient SshClient, uint Port) SetupSshTunnel()
    {
        try
        {
            sshClient = new SshClient(sshHost, sshPort, sshUsername, sshPassword);
            sshClient.HostKeyReceived += delegate (object sender, HostKeyEventArgs e)
            {
                Console.WriteLine("Host key: " + BitConverter.ToString(e.FingerPrint).Replace("-", ":"));
                e.CanTrust = true;
            };

            Console.WriteLine("Connecting to SSH server...");
            sshClient.Connect();
            Console.WriteLine("Connected to SSH server.");

            portForwarded = new ForwardedPortLocal("127.0.0.1", mysqlHost, (uint)mysqlPort);
            sshClient.AddForwardedPort(portForwarded);
            portForwarded.Start();
            Console.WriteLine("Port forwarding started.");
        }
        catch (SshException ex)
        {
            Console.WriteLine("SSH Exception: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception: " + ex.Message);
            throw;
        }

        return (sshClient, portForwarded.BoundPort); 
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

    private static MySqlConnectionStringBuilder GetMySqlConnectionString()
    {
        var (sshClient, localPort) = SetupSshTunnel();
        MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            Port = localPort,
            UserID = mysqlUser,
            Password = mysqlPassword,
            Database = mysqlDatabase,
        };

        return csb;
    }

    private static void CreateSongTableIfNotExists(string tableName)
    {
        using (var connection = new MySqlConnection(GetMySqlConnectionString().ConnectionString))
        {
            try
            {
                string query = $"CREATE TABLE IF NOT EXISTS `{tableName}` (" +
                               "PlayID INT PRIMARY KEY AUTO_INCREMENT," +
                               "PlayerID VARCHAR(3)," +
                               "PlayTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                               "Score VARCHAR(10));";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    Console.WriteLine("MySQL connection opened.");
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table created if it did not exist.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
                throw;
            }
        }
    }

    internal static void InsertPlayData(string tableName, string playerId, string score)
    {
        CreateSongTableIfNotExists(tableName);

        using (var connection = new MySqlConnection(GetMySqlConnectionString().ConnectionString))
        {
            try
            {
                string query = $"INSERT INTO `{tableName}` (PlayerID, Score) VALUES (@PlayerID, @Score)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerID", playerId);
                    command.Parameters.AddWithValue("@Score", score);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
                throw;
            }
        }

        CloseSshTunnel();
    }

    internal static DataTable RetrievePlayData(string tableName)
    {
        SetupSshTunnel();
        DataTable playDataTable = new DataTable();

        using (var connection = new MySqlConnection(GetMySqlConnectionString().ConnectionString))
        {
            try
            {
                string query = $"SELECT * FROM `{tableName}`";
                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(playDataTable);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
                throw;
            }
        }

        CloseSshTunnel();
        return playDataTable;
    }

}

