using System;
namespace TechStock.models
{
    public class Cart
    {
        public string Id { get; set; }
        public string Users_id { get; internal set; }
        public float Total { get; set; }
        public int ProductsCount { get; set; }
        
    }
}

//create table Cart (
//    Id NVARCHAR(255) PRIMARY KEY,
//    Users_id NVARCHAR(255),
//    Total float(35),
//    ProductsCount int
//);


//ALTER TABLE Cart
//   ADD CONSTRAINT FK_Cart_users FOREIGN KEY (Users_id)
//      REFERENCES[dbo].[Users](Id)
//      ON DELETE CASCADE
//      ON UPDATE CASCADE
//;


