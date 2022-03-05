# Using Microsoft SQL Server for Windows

Microsoft offers various editions of its popular and capable SQL Server product 
for Windows, Linux, and Docker containers. We will use a free version that can 
run standalone, known as SQL Server Developer Edition. You can also use the 
Express edition or the free SQL Server LocalDB edition that can be installed 
with Visual Studio for Windows.

## Downloading and installing SQL Server

You can download SQL Server editions from the following link:
https://www.microsoft.com/en-us/sql-server/sql-server-downloads

1.	Download the **Developer** edition.
2.	Run the installer.
3.	Select the **Custom** installation type.
4.	Select a folder for the installation files and then click **Install**.
5.	Wait for the 1.5 GB of installer files to download.
6.	In **SQL Server Installation Center**, click **Installation**, and then click **New SQL Server stand-alone installation or add features to an existing installation**, as shown in *Figure 10.1*:

![Installation using SQL Server Installation Center](cs11dotnet7_10_sql_01.png)
*Figure 10.1: Installation using SQL Server Installation Center*

7.	Select **Developer** as the free edition and then click **Next**.
8.	Accept the license terms and then click **Next**.
9.	Review the install rules, fix any issues, and then click **Next**.
10.	In **Feature Selection**, select **Database Engine Services**, and then click **Next**.
11.	In **Instance Configuration**, select **Default instance**, and then click **Next**. If you already have a default instance configured, then you could create a named instance, perhaps called **csdotnetbook**.
12.	In **Server Configuration**, note the **SQL Server Database Engine** is configured to start automatically. Set the **SQL Server Browser** to start automatically, and then click **Next**.
13.	In **Database Engine Configuration**, on the **Server Configuration** tab, set **Authentication Mode** to **Mixed**, set the **sa** account password to a strong password, click **Add Current User**, and then click **Next**.
14.	In **Ready to Install**, review the actions that will be taken, and then click **Install**.
15.	In **Complete**, note the successful actions taken, and then click **Close**.
16.	In **SQL Server Installation Center**, in **Installation**, click **Install SQL Server Management Tools**.
17.	In the browser window, click to download the latest version of SSMS.
18.	Run the installer and click **Install**.
19.	When the installer has finished, click **Restart** if needed or **Close**.

## Creating the Northwind sample database for SQL Server

Now we can run a database script to create the Northwind sample database:

1.	If you have not previously downloaded or cloned the GitHub repository for this book, then do so now using the following link: https://github.com/markjprice/cs11dotnet7/.
2.	Copy the script to create the Northwind database for SQL Server from the following path in your local Git repository: `/sql-scripts/Northwind4SQLServer.sql` into the `WorkingWithEFCore` folder.
3.	Start **SQL Server Management Studio**.
4.	In the **Connect to Server** dialog, for **Server name**, enter `.` (a dot) meaning the local computer name, and then click **Connect**.
If you had to create a named instance, like `csdotnetbook`, then enter `.\csdotnetbook`
5.	Navigate to **File** | **Open** | **File...**.
6.	Browse to select the `Northwind4SQLServer.sql` file and then click **Open**.
7.	In the toolbar, click **Execute**, and note the the **Command(s) completed successfully** message.
8.	In **Object Explorer**, expand the **Northwind** database, and then expand **Tables**.
9.	Right-click **Products**, click **Select Top 1000 Rows**, and note the returned results, as shown in *Figure 10.2*:

![The Products table in SQL Server Management Studio](cs11dotnet7_10_sql_02.png)
*Figure 10.2: The Products table in SQL Server Management Studio*

10.	In the **Object Explorer** toolbar, click the **Disconnect** button.
11.	Exit SQL Server Management Studio.

## Managing the Northwind sample database with Server Explorer

We did not have to use SQL Server Management Studio to execute the database script. We can also use tools in Visual Studio including the SQL Server Object Explorer and Server Explorer:

1.	In Visual Studio 2022, choose **View** | **Server Explorer**.
2.	In the **Server Explorer** window, right-click **Data Connections** and choose **Add Connection...**.
3.	If you see the **Choose Data Source** dialog, as shown in *Figure 10.3*, then select **Microsoft SQL Server** and then click **Continue**:

![Choosing SQL Server as the data source](cs11dotnet7_10_sql_03.png)
*Figure 10.3: Choosing SQL Server as the data source*

4.	In the **Add Connection** dialog, enter the server name as `.`, enter the database name as `Northwind`, and then click **OK**.
5.	In **Server Explorer**, expand the data connection and its tables. You should see 13 tables, including the **Categories** and **Products** tables, as shown in *Figure 10.4*:

![13 tables in Northwind database](cs11dotnet7_10_sql_04.png)
*Figure 10.4: 13 tables in Northwind database*

6.	Right-click the **Products** table, choose **Show Table Data**, and note the 77 rows of products are returned.
7.	To see the details of the **Products** table columns and types, right-click **Products** and choose **Open Table Definition**, or double-click the table in **Server Explorer**.

