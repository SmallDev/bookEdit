# bookEdit
Test SPA project. Based on asp.net, angular and bootstrap

Site working almost out of box. With the exception of a couple of things.


## Visual Studio
You need Visual Studio 2015 to compile and run this app.It is better not to use the Express version.

## DataBase
This project uses code first Entity Framework approach. So all you need is to specify the correct connection string in the **web.config** file.
I am using MS SQL Express with windows authentication enabled, so by default connection string is:

```
<connectionStrings>
<add name="BookEditDb" providerName="System.Data.SqlClient" connectionString="Server=.\SQLEXPRESS;Initial Catalog=bookEditDb;Integrated Security=True;" />
</connectionStrings>

```

If you are using another version of MS SQL, then you should specify your connection string, keeping in mind two things

* Specify **Initial Catalog**,  so EF can create app database in it.
* If you don’t use **Integrated Security**,  then you should provide proper credentials with all necessary permissions.

(*I have tested this app only with MS SQL Server*)

## js tests

This application has some client code unit tests. They are written by  **jasmine**,  so you need [Chutzpah]( https://github.com/mmanela/chutzpah) test runner to execute them in Visual Studio. You can setup it as  Visual Studio extension.

