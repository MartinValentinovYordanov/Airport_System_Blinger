# Airport_System_Blinger
Web app for booking seats for flights.

If you want to run the project go to StartUp.cs and change this line:
services.AddDbContext<BlingerDbContext>(options =>
            {
                options.UseMySql("server=localhost; port=3307; user=root; password=123456789; database=blinger", new MySqlServerVersion(new System.Version(8, 0, 22)));
            });
After you make your DB server change the values inside the quotes above.
The DB version is MariaDB





Whit this program you can manage Airlines, Airports , Flights and Seats. You can create Flights, Airlines, Airports and you can delete them too.
You can book a seat in an exact flights on an exact date. 

Just try it.