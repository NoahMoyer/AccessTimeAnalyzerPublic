using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Time_Analyzer
{
    public class SQLManager
    {
        SqlConnection sqlconn;
        public List<AppGroup> AppGroups = new List<AppGroup>();
        public List<string> windowsVersions = new List<string>();
        public SQLManager() 
        {
            
        }
        //will return false if connection failed
        public bool connectToSqlServer(string connectionString)
        {
            sqlconn = new SqlConnection(connectionString);
            try
            {
                sqlconn.Open();
                Debug.WriteLine("Sql connection successful");
                getWindowsVersionsInDatabase();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.Write("Sql connection failed. \n" + ex);
                sqlconn.Close();
                return false;
            }
            
        }

        //IMPORTANT: The connection to the SQL database needs to be closed at some point so make sure to not leave it open after the application is closed
        //Currently we are closing it when the form is closed.
        public async void closeSqlConnection()
        {
            sqlconn.Close();
            Debug.Write("Sql connection closed. \n");
            await Task.Delay(1000);
        }

        //Getting default groups from sql database
        public void getGroupsFromDatabase(/*string windowsVersion*/)
        {
            AppGroups.Clear();//make sure the groups are empty before doing this.
            //this data is for when we are adding information to the default app list we will use to reference for analysis
            string tempGroupName;
            string tempAppName;
            string tempAppLocation;
            //string tempPrefetchName;
            List<defaultApp> listOfAppsToAdd;

            List<string> tablesToSearch = new List<string>();//this will be a list of tables for the windows verion of the computer we are looking at. The databse is 
                                                             //expected to contain tables that start with the group name and end with the windows version. EX: IT21H2 or AT22H2
            string tableQuery = "SELECT table_name " +
                                "FROM INFORMATION_SCHEMA.TABLES " +
                                "WHERE table_type = 'BASE TABLE' " /*+
                                $"AND table_name LIKE '%{windowsVersion}%'"*/;//this query will be used to return a list of tables in the database that have information for the version 
                                                                                 //of windows the computer being looked at is using
            SqlCommand tableCommand = new SqlCommand(tableQuery, sqlconn);
            //tableCommand.Parameters.AddWithValue("@windowsVersion", windowsVersion);
            //parameter did not work for some reason
            Debug.WriteLine("Running sql queries for tables for current machine windows version");
            SqlDataReader tableReader = tableCommand.ExecuteReader();
            try
            {
                while (tableReader.Read())
                {
                    tablesToSearch.Add(tableReader.GetString(0));
                    Debug.WriteLine("Table name: " + tableReader.GetString(0));
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error getting table information from databse: \n" + ex);
                //TODO: Might want to throw and error message and stop thigns from processing here if there is an error since this wil prevent things from working
            }
            finally
            {
                tableReader.Close();
            }


            //now that we have a list of tables to query for data we will want to do a query for each to get all the app information in them
            string appQuery;
            foreach (string table in tablesToSearch)
            {
                appQuery = "SELECT * FROM [AccessTime].[dbo].[" + table + "]";
                SqlCommand appCommand = new SqlCommand(appQuery, sqlconn);
                SqlDataReader appReader= appCommand.ExecuteReader();
                try
                {
                    listOfAppsToAdd= new List<defaultApp>();
                    tempGroupName = table.Substring(0, 2);//this should get the first two characters of the string. If it doesn't this will not work as expected
                    while (appReader.Read())
                    {
                        tempAppName = appReader["AppName"].ToString();
                        tempAppLocation = appReader["Location"].ToString();
                        //tempPrefetchName = appReader["PrefetchFileName"].ToString();
                        listOfAppsToAdd.Add(new defaultApp(tempAppName, tempAppLocation/*, tempPrefetchName*/));
                    }
                    AppGroups.Add(new AppGroup(tempGroupName, listOfAppsToAdd));
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Query failed for table " + table + ": \n" + ex);
                }
                finally 
                { 
                    appReader.Close();
                }
            }

        }

        //updating database with changed app group
        public void updateGroup(AppGroup inputAppGroup/*, string windowsVersion*/)
        {
            string tableName = inputAppGroup.getGroupName()/* + windowsVersion*/;
            string ClearQuery= "DELETE FROM " + tableName;
            SqlCommand ClearCommand = new SqlCommand(ClearQuery,sqlconn);
            string UpdateQuery = "";
            SqlCommand UpdateCommand;
            
            //clearing the table
            try
            {
                ClearCommand.ExecuteNonQuery();
                Debug.WriteLine(tableName  + " table cleared.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error with clearing sql table " + tableName + ": \n" + ex);
            }
            //populating table with new data
            foreach(defaultApp app in inputAppGroup.defaultApps)
            {
                try
                {
                    UpdateQuery = "INSERT INTO [AccessTime].[dbo].[" + tableName + "] (AppName, Location)" +
                                              "VALUES (@appName,@appLocation)";
                    UpdateCommand = new SqlCommand(UpdateQuery, sqlconn);
                    //parameterizing the user input so the user can't inject SQL commands
                    if (app.appName != "" || app.appLocation != "" || /*app.prefetchName != "" ||*/ app.appName != null || app.appLocation != null /*|| app.prefetchName != null*/)
                    {
                        UpdateCommand.Parameters.AddWithValue("@appname", app.appName);
                        UpdateCommand.Parameters.AddWithValue("@appLocation", app.appLocation);
                        //UpdateCommand.Parameters.AddWithValue("@prefetchName", app.prefetchName);
                        UpdateCommand.ExecuteNonQuery();
                        Debug.WriteLine(app.appName + " added");
                    }
                    else
                    {
                        Debug.WriteLine("Error: app name, location, and prefetch file name cannot be empty. Each must contain information");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error with updating sql table " + tableName + ": \n" + ex);
                }
            }
            
        }

        //adding a new group to the database
        public void addGroup(AppGroup inputAppGroup/*, string windowsVersion*/)
        {
            string tableName = inputAppGroup.getGroupName()/* + windowsVersion*/;
            string addGroupQuery = $"CREATE TABLE [{tableName}] (\n" +
                "AppName nvarchar(50) NOT NULL,\n" +
                "Location nvarchar(150) NOT NULL,\n" +
                //"PrefetchFileName nvarchar(50) NOT NULL" +
                ")";
            SqlCommand addGroupCommand = new SqlCommand(addGroupQuery, sqlconn);
            string insertIntoNewTableQuery;
            SqlCommand insertIntoNewTableCommand;
            //creating table
            try
            {
                addGroupCommand.ExecuteNonQuery();
                Debug.WriteLine("Table " + tableName + " created");
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error creating table " + tableName +": \n" + ex);
            }
            //inserting data into table
            foreach(defaultApp app in inputAppGroup.defaultApps)
            {
                try
                {
                    insertIntoNewTableQuery = "INSERT INTO [AccessTime].[dbo].[" + tableName + "] (AppName, Location)" +
                                              "VALUES (@appName,@appLocation)";
                    insertIntoNewTableCommand = new SqlCommand(insertIntoNewTableQuery,sqlconn);
                    //parameterizing the user input so the user can't inject SQL commands
                    if(app.appName != "" || app.appLocation != "" || /*app.prefetchName != "" ||*/ app.appName != null || app.appLocation != null /*|| app.prefetchName != null*/)
                    {
                        insertIntoNewTableCommand.Parameters.AddWithValue("@appname", app.appName);
                        insertIntoNewTableCommand.Parameters.AddWithValue("@appLocation", app.appLocation);
                        //insertIntoNewTableCommand.Parameters.AddWithValue("@prefetchName", app.prefetchName);
                        insertIntoNewTableCommand.ExecuteNonQuery();
                        Debug.WriteLine(app.appName + " added");
                    }
                    else
                    {
                        Debug.WriteLine("Error: app name, location, and prefetch file name cannot be empty. Each must contain information");
                    }

                    
                    
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Error adding app " + app.appName + ": \n" + ex);
                }
            }

        }

        //deleting an app group from the database
        public void removeGroup(AppGroup inputAppGroup/*, string windowsVersion*/)
        {
            string tableName = inputAppGroup.getGroupName()/* + windowsVersion*/;
            string deleteTableQuery = "DROP TABLE [" + tableName + "]";
            SqlCommand deleteTableCommand = new SqlCommand(deleteTableQuery,sqlconn);
            try
            {
                deleteTableCommand.ExecuteNonQuery();
                Debug.WriteLine(tableName + " dropped.");
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error deleting table" + tableName + ": \n" + ex);
            }
        }

        //get windows version in database
        public void getWindowsVersionsInDatabase()
        {
            string getWindowsQuery = "SELECT * FROM [AccessTime].[dbo].[WindowsVersion]";
            SqlCommand windowsCommand = new SqlCommand(getWindowsQuery,sqlconn);
            windowsVersions.Clear();//clear list before getting info
            try
            {
                SqlDataReader tableReader = windowsCommand.ExecuteReader();
                try
                {
                    while (tableReader.Read())
                    {
                        windowsVersions.Add(tableReader["WindowsVersions"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error adding row to windows version list. \n" + ex);
                }
                finally
                {
                    tableReader.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error running sql query. \n" + ex);
            }


        }
    }
}
