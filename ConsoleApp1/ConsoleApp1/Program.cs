using System;
using System.Data.Common;
using ConsoleApp1;
using MySql.Data.MySqlClient;

 static void QueryEmployee(MySqlConnection conn)
{
    string Code, Batch_name, Quality,size,date_registration;
    string sql = "Select Code, Batch_name, Quality,size,date_registration from batch_products";
    MySqlCommand cmd = new MySqlCommand();
    cmd.Connection = conn;
    cmd.CommandText = sql;

    using (DbDataReader reader = cmd.ExecuteReader())
    {
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Code = reader["Code"].ToString();
                Batch_name = reader["batch_name"].ToString();
                Quality = reader["Quality"].ToString();
                size = reader["Size"].ToString();
                date_registration = reader["Date_registration"].ToString();
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("Код:" + Code + " Назва:" + Batch_name + 
                    " Гатунок:" + Quality + " Розмір:"+ size + " Дата регістрації:"+ date_registration);
                Console.WriteLine("---------------------------------------------------------------");
            }
        }
    }
}
Console.WriteLine("Getting Connection...");
MySqlConnection conn = DBUtils.GetDBConnection();
try
{
    Console.WriteLine("Openning Connection ...");
    conn.Open();
    Console.WriteLine("Connection successful!");
    QueryEmployee(conn);
}
catch (Exception e)
{
    Console.WriteLine("Error" + e.Message);
    Console.WriteLine(e.StackTrace);
}
finally
{
    conn.Close();
    conn.Dispose();
}
Console.Read();
