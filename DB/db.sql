USE master;  
GO  
CREATE DATABASE   
ON   
( NAME = cars,  
    FILENAME = 'C:\Program Files\TMS\DB\cars.mdf',  
    SIZE = 10,  
    MAXSIZE = 50,  
    FILEGROWTH = 5 )  
LOG ON  
( NAME = Cars,  
    FILENAME = 'C:\Program Files\TMS\DB\cars.mdf',  
    SIZE = 5MB,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB );  
GO
