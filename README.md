# Teck-Stock

This repository represents a demo built for an App Development session, for the purpose of demonstrating how to build an application with Azure cloud.



## Tech-Stock an application for selling electronics, built using Xamaring.Forms:

“Xamarin.Forms is a feature of Xamarin, the popular mobile development framework that extends the .NET developer platform with tools and libraries for building mobile apps.
Xamarin.Forms is an open source cross-platform framework from Microsoft for building iOS, Android, & Windows apps with .NET from a single shared codebase.”


### Main functionality:

After registration users will receive an SMS. This was achieved using Azure functions and Twillio API,
and to increase the reliability of this feature I also used Azure Storage Account’s Queues to hold the messages temporarily.

Once users upload a product for sale, they will receive a confirmation email.
This was achieved using Azure Logic Apps that will be triggered every time a new product is added to our database.

All data is stored in Azure SQL database and files/images are stored in an Azure Storage Account Containers as blobs for cost optimisation and efficiency.

Lastly, an Azure Web App was used to host the backend, 
Leveraging a DevOps feature: continuous deployment, by integrating the Web App's Deployment Center with this GitHub repo:
https://github.com/Ghadaaldjain/DemoBackend

<div class="row" style="display: flex;">
  <div class="column" style="padding:5px;">
    <img width="250" alt="home" src="https://user-images.githubusercontent.com/50453450/100446250-839e2b80-30bf-11eb-967e-0c23f62375f6.png" style="width:100%">
  </div>
  <div class="column" style="padding:5px;">
    <img width="250" alt="products" src="https://user-images.githubusercontent.com/50453450/100447124-11c6e180-30c1-11eb-8ac1-694233bcf433.png" style="width:100%">
  </div>
  <div class="column" style="padding:5px;">
    <img width="250" alt="search" src="https://user-images.githubusercontent.com/50453450/100446272-8d279380-30bf-11eb-978a-03bdb0c93e00.png"style="width:100%">
  </div>
</div>

<div class="row" style="display: flex;">
  <div class="column" style="padding:5px;">
   <img width="250" alt="cart" src="https://user-images.githubusercontent.com/50453450/100446282-8f89ed80-30bf-11eb-8105-3661949b4116.png" style="width:100%">
  </div>
  <div class="column" style="padding:5px;">
    <img width="250" alt="cate" src="https://user-images.githubusercontent.com/50453450/100446294-931d7480-30bf-11eb-9487-52996761365b.png" style="width:100%">
  </div>
  <div class="column" style="padding:5px;">
    <img width="250" alt="photos" src="https://user-images.githubusercontent.com/50453450/100446298-94e73800-30bf-11eb-9c12-0185bf0a8435.png" style="width:100%">
  </div>
</div>


<div class="row" style="display: flex;">
  <div class="column" style="padding:5px;">
   <img width="250" alt="ready for sale" src="https://user-images.githubusercontent.com/50453450/100446303-96186500-30bf-11eb-9df9-c7c225bdad56.png" style="width:100%">
  </div>
  <div class="column" style="padding:5px;">
    <img width="250" alt="regester" src="https://user-images.githubusercontent.com/50453450/100447303-64080280-30c1-11eb-975c-8c5d1b9ca84b.png" style="width:100%">
  </div>
  <div class="column" style="padding:5px;">
   <img width="250" alt="settings" src="https://user-images.githubusercontent.com/50453450/100447313-666a5c80-30c1-11eb-8534-39c1f97f2b8d.png"style="width:100%"> </div>
</div>

Thank you for reading.

