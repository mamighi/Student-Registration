using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
namespace StudentRegistration
{
    class DataBaseManager
    {
        SQLiteConnection m_dbConnection;
        public DataBaseManager()
        {
             m_dbConnection= new SQLiteConnection("Data Source=StudentData.sqlite;Version=3;");
             if (File.Exists("StudentData.sqlite"))
                 return;

            SQLiteConnection.CreateFile("StudentData.sqlite");
            
            m_dbConnection.Open();
           
            string sql = "CREATE TABLE IF NOT EXISTS USERS (UserName varchar(30), Password varchar(30),Fname varchar(20),Lname varchar(20),PNo varchar(30),UT varchar(2))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "insert into USERS (UserName, Password,Fname,Lname,Pno,UT) values ('admin', 'admin','admin','admin','11111111','A')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE IF NOT EXISTS INTAKE (code varchar(20),date DATETIME)";
            command=new SQLiteCommand(sql,m_dbConnection);
            command.ExecuteNonQuery();

            sql = "CREATE TABLE IF NOT EXISTS STUDENT (id varchar(20),intake varchar(20),fname varchar(20),lname varchar(20),pno varchar(20),bd DATETIME,address varchar(100))";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            m_dbConnection.Close();

        }
        public int login(string sUserName,string sPassword)
        {
            int iRetVal=-1;
            string sql = "SELECT UT FROM USERS WHERE UserName='" + sUserName + "' AND Password='" + sPassword + "'";
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                string val = reader.GetString(0);
                if (val.Equals("A"))
                    iRetVal = 0;
                else
                    iRetVal = 1;
            }
            reader.Close();
            m_dbConnection.Close();
            return iRetVal;
        }
        public bool addUser(DataSets.Users userInfo)
        {
            bool retVal = false;
            m_dbConnection.Open();
            string sql = "SELECT * FROM USERS WHERE UserName='" + userInfo.userName + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if(!reader.Read())
            {
                reader.Close();
                retVal = true;
                sql = "insert into USERS (UserName, Password,Fname,Lname,Pno,UT) values ('" + userInfo.userName +
                    "', '"+userInfo.password+"','"+userInfo.fName+"','"+userInfo.lName+"','"+userInfo.pNo+"','C')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
                return retVal;
            }
            reader.Close();
            m_dbConnection.Close();
            return retVal;
        }
        public List<DataSets.Users> getUsers()
        {
            List<DataSets.Users> retVal = new List<DataSets.Users>();
            m_dbConnection.Open();
            string sql = "SELECT * FROM USERS";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                DataSets.Users temp = new DataSets.Users();
                temp.userName = reader.GetString(0);
                temp.password = reader.GetString(1);
                temp.fName = reader.GetString(2);
                temp.lName = reader.GetString(3);
                temp.pNo = reader.GetString(4);
                retVal.Add(temp);
            }
            reader.Close();
            m_dbConnection.Close();
            return retVal;
        }
        public void updateUser(DataSets.Users userInfo)
        {
            m_dbConnection.Open();
            string sql = "UPDATE USERS SET Password='" + userInfo.password + "'," +
                "Fname='" + userInfo.fName + "',Lname='" + userInfo.lName + 
                "', Pno='"+userInfo.pNo+"' WHERE UserName='" + userInfo.userName + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public void deleteUser(DataSets.Users userInfo)
        {
            string sql = "DELETE FROM USERS WHERE UserName='"+userInfo.userName+"'";
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public bool addIntake(DataSets.intake intakeInfo)
        {
            bool retVal = false;
            m_dbConnection.Open();
            string sql = "SELECT * FROM INTAKE WHERE code='" + intakeInfo.code + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if(!reader.Read())
            {
                reader.Close();
                retVal = true;
                sql="insert into INTAKE (code,date) values('"+intakeInfo.code+"','"+intakeInfo.date+"')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return retVal;
            }
            reader.Close();
            m_dbConnection.Close();
            return retVal;
        }
        public List<DataSets.intake> getIntakes()
        {
            List<DataSets.intake> retVal = new List<DataSets.intake>();
            m_dbConnection.Open();
            string sql = "SELECT * FROM INTAKE";
            SQLiteCommand command= new SQLiteCommand(sql,m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                DataSets.intake temp = new DataSets.intake();
                temp.code = reader.GetString(0);
                temp.date =DateTime.Parse(reader.GetString(1));
                retVal.Add(temp);
            }
            reader.Close();
            m_dbConnection.Close();
            return retVal;
        }
        public void updateIntake(DataSets.intake intakeInfo)
        {
            m_dbConnection.Open();
            string sql = "UPDATE INTAKE SET date='" + intakeInfo.date + "' WHERE code='" + intakeInfo.code + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public void DeleteIntake(DataSets.intake intakeInfo)
        {
            m_dbConnection.Open();
            string sql = "DELETE FROM INTAKE WHERE code='" + intakeInfo.code + "'";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        //(id varchar(20),intake varchar(20),fname varchar(20),lname varchar(20),pno varchar(20),bd DATETIME,address varchar(100))
        public bool addStudent(DataSets.student stInfo)
        {
            bool retVal = false;
            m_dbConnection.Open();
            string sql = "SELECT * FROM STUDENT WHERE id='" + stInfo.id + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if(!reader.Read())
            {
                reader.Close();
                retVal = true;
                sql = "INSERT INTO STUDENT (id,intake,fname,lname,pno,bd,address) values('" + stInfo.id +
                    "','" + stInfo.intake + "','" + stInfo.fname + "','" + stInfo.lname + "','" + stInfo.pno +
                    "','" + stInfo.bd + "','" + stInfo.address + "')";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
                return retVal;
            }
            reader.Close();
            m_dbConnection.Close();
            return retVal;
        }
        public void updateStudent(DataSets.student stInfo)
        {
            m_dbConnection.Open();
            string sql = "UPDATE STUDENT SET intake='" + stInfo.intake + "',fname='" + stInfo.fname +
                "',lname='" + stInfo.lname + "',pno='" + stInfo.pno + "',bd='" + stInfo.bd + "',address='" +
                stInfo.address + "' WHERE id='" + stInfo.id + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public void deleteStudent(string id)
        {
            m_dbConnection.Open();
            string sql = "DELETE FROM STUDENT WHERE id='" + id + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        public List<DataSets.student> getStudents()
        {
            List<DataSets.student> retVal = new List<DataSets.student>();
            m_dbConnection.Open();
            string sql = "SELECT * FROM STUDENT";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                DataSets.student temp = new DataSets.student();
                temp.id = reader.GetString(0);
                temp.intake = reader.GetString(1);
                temp.fname = reader.GetString(2);
                temp.lname = reader.GetString(3);
                temp.pno = reader.GetString(4);
                temp.bd =DateTime.Parse( reader.GetString(5));
                temp.address = reader.GetString(6);
                retVal.Add(temp);
            }
            reader.Close();
            m_dbConnection.Close();
            return retVal;
        }

    }
}
