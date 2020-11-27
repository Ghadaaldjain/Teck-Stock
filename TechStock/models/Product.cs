using System;
namespace TechStock.models
{
    public class Product
    {
        public string Id { get; set; }
        public string Category_id { get; set; }
        public string Users_id { get; set; }
        public string Name { get; set; }
        public string Image { set; get; }
        public double Price { get; set; }
        public string Subtitle { get; set; }
        public Boolean IsArabic { get; set; }
        public string Description { get; set; }
       

    }
}

//create table Category (
//    Id NVARCHAR(255) PRIMARY KEY,
//    Category_id NVARCHAR(255),
//    Users_id NVARCHAR(255),
//    Name NVARCHAR(255),
//    Image NVARCHAR(255),
//    Price float(55),
//    Subtitle NVARCHAR(255)
//    IsArabic bit not null default 0,
//    Description NVARCHAR(255)
//);

//ALTER TABLE Product
//   ADD CONSTRAINT FK_Product_category FOREIGN KEY (Category_id)
//      REFERENCES[dbo].[Category](Id)
//      ON UPDATE CASCADE
//;


//ALTER TABLE Product
//   ADD CONSTRAINT FK_Product_users FOREIGN KEY (Users_id)
//      REFERENCES[dbo].[Users](Id)
//      ON DELETE CASCADE
//      ON UPDATE CASCADE
//;

