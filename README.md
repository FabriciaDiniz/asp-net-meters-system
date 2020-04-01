# asp-net-meters-system
Repository for a remote meter monitoring system

### Summary
The objective of this project is to simulate a system that remotely collect readings and is able to send some basic commands directly to the meters, 
avoiding the need for someone to go to the location of said meters to collect informations.

The project contains a WPF desktop core module which connects to a PostgreSQL database, 
a WPF desktop simulator that connects to the desktop app via Tcp/Ip and basically acts as a meters, returning request info to the desktop app,
and a Asp.net core web app, which is the main part users interact with, being able to create new meters, see a meter's readings and send commands to it. It will connect to the desktop app via WCF (WIP).

That said, this is my first big project using ASP.NET, WPF and WCF so it is a little rough right now. I will be polishing it in the near future.
