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
                Console.WriteLine(reader[0].ToString() + " ");
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

            foreach (DataRow item in tables.Tables[0].Rows)
            {
                var tableName = item.ItemArray[0].ToString();
                var query = File.ReadAllText(location + @"\query.txt");
                query = query.Replace("mehrshad", tableName);
                SqlCommand cmd2 = new SqlCommand(query, con);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {

                    var text = tableName ;
                    var PartOFText = text.Substring(0, 3);
                    Console.WriteLine("*" + PartOFText + " " + text);

                    switch (PartOFText)
                    {
                        case "Acc":
                            Directory.CreateDirectory(location + @"\classess\Acc");
                            File.WriteAllText(location + @$"\classess\Acc\{tableName}.cs", text);
                            break;

                        case "Add":
                            Directory.CreateDirectory(location + @"\classess\Add");
                            File.WriteAllText(location + @$"\classess\Add\{tableName}.cs", text);
                            break;

                        case "Arc":
                            Directory.CreateDirectory(location + @"\classess\Arc");
                            File.WriteAllText(location + @$"\classess\Arc\{tableName}.cs", text);
                            break;

                        case "Ast":
                            Directory.CreateDirectory(location + @"\classess\Ast");
                            File.WriteAllText(location + @$"\classess\Ast\{tableName}.cs", text);
                            break;

                        case "Bdg":
                            Directory.CreateDirectory(location + @"\classess\Bdg");
                            File.WriteAllText(location + @$"\classess\Bdg\{tableName}.cs", text);
                            break;

                        case "Cmr":
                            Directory.CreateDirectory(location + @"\classess\Cmr");
                            File.WriteAllText(location + @$"\classess\Cmr\{tableName}.cs", text);
                            break;

                        case "Cnt":
                            Directory.CreateDirectory(location + @"\classess\Cnt");
                            File.WriteAllText(location + @$"\classess\Cnt\{tableName}.cs", text);
                            break;

                        case "Cst":
                            Directory.CreateDirectory(location + @"\classess\Cst");
                            File.WriteAllText(location + @$"\classess\Cst\{tableName}.cs", text);
                            break;

                        case "Ele":
                            Directory.CreateDirectory(location + @"\classess\Ele");
                            File.WriteAllText(location + @$"\classess\Ele\{tableName}.cs", text);
                            break;

                        case "Gnr":
                            Directory.CreateDirectory(location + @"\classess\Gnr");
                            File.WriteAllText(location + @$"\classess\Gnr\{tableName}.cs", text);
                            break;

                        case "Hrm":
                            Directory.CreateDirectory(location + @"\classess\Hrm");
                            File.WriteAllText(location + @$"\classess\Hrm\{tableName}.cs", text);
                            break;

                        default:
                            break;
                    }
                    //File.WriteAllText(location + @$"\classess\{tableName}.cs", text);
                    //Console.WriteLine(reader[0].ToString() + " ");
                }
                reader.Close();
            }
        }

    }
}


//SELECT TABLE_NAME 
//FROM ASM.INFORMATION_SCHEMA.TABLES 
//WHERE TABLE_TYPE = 'BASE TABLE'
//order by TABLE_NAME

//@"
//SELECT TABLE_NAME 
//FROM ASM.INFORMATION_SCHEMA.TABLES 
//WHERE TABLE_TYPE = 'BASE TABLE'
//order by TABLE_NAME;
//"