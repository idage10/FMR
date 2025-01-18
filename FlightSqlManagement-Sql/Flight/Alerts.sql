CREATE TABLE [dbo].[alerts] (
    alert_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    user_id INT NOT NULL,
    flight_source NVARCHAR(255) NOT NULL,
    flight_destination NVARCHAR(255) NOT NULL,
    price_threshold DECIMAL(18, 2) NOT NULL,
    is_active BIT NOT NULL
);
