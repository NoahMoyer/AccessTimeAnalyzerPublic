# Access Time Analyzer
This program will quickly get together information from exe "last accessed" property and will get
information from windows prefetch files using WinPrefetchView.exe from https://www.nirsoft.net/utils/win_prefetch_view.html
The idea of this application is to allow the user to analyze data about a set of application
on many different computers.

### Main screen
![main](https://github.com/NoahMoyer/AccessTimeAnalyzerPublic/assets/35582108/b5e00fc1-8181-48d9-a57e-f007f2458fea)


## Main functionality
The main function of Access Time analyzer is to scan a windows PC to confirm based on a preset list of applications what programs are installed, how often they are used, and when they were last used.

## How to use Access Time Analyzer
You will need to know the programs you want to look at and where their exes are stored when installed.

Here is an example of an app name and location: <br>
![1](https://github.com/NoahMoyer/AccessTimeAnalyzerPublic/assets/35582108/776c3c8c-19fe-4c02-9906-dd2484e9dd92)


The program currently requires a SQL server to store the information for application locations and the groups they correspond with. Here is an example of a working database table: <br>
![2](https://github.com/NoahMoyer/AccessTimeAnalyzerPublic/assets/35582108/2d99839c-f022-44c0-a0eb-d2e9edfeeda7)

<br>
***Note: Currently without a SQL server the application will not function.***

Once the application is opened it will automatically select one of the groups if it finds
one that is the same as what the computer name starts with. If you would like to analyze
a computer that is locally connected to your network you can change this by
typing the name of the computer in the text box under machine name then clicking
"Change machine name".
### Main screen
![main](https://github.com/NoahMoyer/AccessTimeAnalyzerPublic/assets/35582108/7f46f891-a6eb-4e41-a3bb-325fde655daa)


#### Last Accessed field
This property is not very reliable in determining when an application was last launched. From
what I have seen this property will update to recent even if the application hasn't been
used ever. So if a program is installed it will likely show a recent time regardless of its use.
This field will tell you if the application isn't installed on the system if it
can't find the exe.

#### Run Counter and Last Run Time
These fields get data from the prefetch file which is a much more reliable source. These files
do quite a few things, but all we use them for is this information since they will log how many
times and application has been run and every date and time it was run. The limitation here
lies in if the prefetch file is deleted the information will be lost. There is also a limit
to 1024 prefetch files, but most people don't use that many applications so that shouldn't be a
concern. Last thing to know here is if nothing shows up in this field that means there is no
prefetch file. If there is no prefetch file then the application has not been launched since
either it was installed or the last time the prefetch file was deleted.

## Summarizing the data
At this time you should have a good idea of how much the applications on someone's computer
have been used and how recently they have launched them. If you want you can now generate a
report of what is being displayed on screen. This will generate a CSV report titled with the
machine name and the date and time the report was generated. You can look at it in excel or
a note pad editor of your choosing.

If you want to look at another machine just type the machine name in the same box as before and
you can make another report with that. If you want to reset back to the local computer
click "Reset machine name". 
