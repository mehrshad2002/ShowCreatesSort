using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            SortName();
        }

        public static void ChangeToClass()
        {
            string ConString = @"Data Source=DESKTOP-6E77HUQ;Initial Catalog=ASM;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConString);


            string querystring = "SELECT TABLE_NAME" +
                " FROM ASM.INFORMATION_SCHEMA.TABLES" +
                " WHERE TABLE_TYPE = 'BASE TABLE' " +
                "order by TABLE_NAME";

            con.Open();

            SqlCommand cmd = new SqlCommand(querystring, con);

            //new
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);//for read table from db 
            DataSet tables = new DataSet(); //can read data from row and column 
            adapter.Fill(tables);

            var path = Environment.CurrentDirectory;
            var location = Directory.GetParent(path).Parent.Parent;

            Directory.CreateDirectory(location + @"\classess");

            foreach (DataRow item in tables.Tables[0].Rows)
            {
                var tableName = item.ItemArray[0].ToString();// we have all name here
                var query = File.ReadAllText(location + @"\query.txt");
                query = query.Replace("mehrshad", tableName);
                SqlCommand cmd2 = new SqlCommand(query, con);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    var text = reader[0].ToString();
                    File.WriteAllText(location + @$"\classess\{tableName}.cs", text);
                    Console.WriteLine(reader[0].ToString() + " ");
                }
                reader.Close();

            }


        }
        public static void ShowAllData()
        {
            string ConString = @"Data Source=DESKTOP-6E77HUQ;Initial Catalog=ASM;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConString);

            int counter = 0;
            string querystring = "SELECT TABLE_NAME" +
                " FROM ASM.INFORMATION_SCHEMA.TABLES" +
                " WHERE TABLE_TYPE = 'BASE TABLE' " +
                "order by TABLE_NAME";

            con.Open();
            SqlCommand cmd = new SqlCommand(querystring, con); // and path ?
            SqlDataReader reader = cmd.ExecuteReader(); // execute the cmd
            while (reader.Read())
            {
                var x = reader[0].ToString();
                File.Create(@$"C:\Users\micro\source\repos\newAppDB\newAppDB\{x}.cs");
                Console.WriteLine(reader[0].ToString() + "Number : " + ++counter);
            }
        } 
        public static void SortName()
        {
            string ConString = @"Data Source=DESKTOP-6E77HUQ;Initial Catalog=ASM;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConString);


            string querystring = "SELECT TABLE_NAME" +
                " FROM ASM.INFORMATION_SCHEMA.TABLES" +
                " WHERE TABLE_TYPE = 'BASE TABLE' " +
                "order by TABLE_NAME";

            con.Open();

            SqlCommand cmd = new SqlCommand(querystring, con);

            //new
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);//for read table from db 
            DataSet tables = new DataSet(); //can read data from row and column 
            adapter.Fill(tables);

            var path = Environment.CurrentDirectory;
            var location = Directory.GetParent(path).Parent.Parent;

            Directory.CreateDirectory(location + @"\classess");
            int Counter = 0;

            foreach (DataRow item in tables.Tables[0].Rows)
            {
                var tableName = item.ItemArray[0].ToString();
                var query = File.ReadAllText(location + @"\query.txt");
                query = query.Replace("mehrshad", tableName);
                SqlCommand cmd2 = new SqlCommand(query, con);
                SqlDataReader reader = cmd2.ExecuteReader();
                
                while (reader.Read())
                {
                    var Class = reader[0].ToString();
                    var text = tableName ;
                    var PartOFText = text.Substring(0, 3);

                    
                    bool Flag = Directory.Exists(location + @$"\classess\{PartOFText}"); //folder name 
                    if ( Flag == false )
                    {
                        Directory.CreateDirectory(location + @$"\classess\{PartOFText}");//create folder
                    }
                    File.WriteAllText(location + @$"\classess\{PartOFText}\{tableName}.cs", Class); // create data 
                }
                reader.Close();
            }
        }

    }
}
