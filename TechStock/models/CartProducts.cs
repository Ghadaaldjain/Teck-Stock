using System;
namespace TechStock.models
{
    public class CartProducts
    {
        public string Id { get; set; }
        public string Cart_id { get; set; }
        public string Product_id { get; set; }
        public int Quantity { get; set; }
    }
}

//create table CartProducts (
//    Id NVARCHAR(255) PRIMARY KEY,
//    Cart_id NVARCHAR(255),
//    Product_id NVARCHAR(255),
//    Quantity int
//);


//ALTER TABLE CartProducts
//   ADD CONSTRAINT FK_Cart_products_pid FOREIGN KEY (Product_id)
//      REFERENCES[dbo].[Product](Id)
//      On delete no action 
//      ON UPDATE no action
//;

//ALTER TABLE CartProducts
//   ADD CONSTRAINT FK_Cart_products FOREIGN KEY (Cart_id)
//      REFERENCES[dbo].[Cart](Id)
//      ON DELETE CASCADE
//      ON UPDATE CASCADE
//;
