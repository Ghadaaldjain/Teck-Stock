# Teck-Stock

This repository represents a demo built for an App Development session, for the purpose of demonstrating how to build an application with Azure cloud.



Tech-Stock an application for selling electronics, built using Xamaring.Forms:

“Xamarin.Forms is a feature of Xamarin, the popular mobile development framework that extends the .NET developer platform with tools and libraries for building mobile apps.
Xamarin.Forms is an open source cross-platform framework from Microsoft for building iOS, Android, & Windows apps with .NET from a single shared codebase.”


Main functionality:

After registration users will receive an SMS, This was achieved using Azure functions and Twillio API,
To increase the reliability of this feature I also used Azure Storage Account’s Queues to hold the massages temporarily.

Once users upload a product for sale, they will receive a confirmation email.
This was achieved using Azure Logic Apps that will be triggered every time a new product as added to our database.

All data is stored in Azure SQL database and files/images are stored in an Azure Storage Account Containers as blobs for cost optimisation and efficiency.

Lastly, an Azure Web App was used to host the backend, 
Leveraging a DevOps feature: continuous deployment, by integrating the Web App's Deployment Center with this GitHub repo:
https://github.com/Ghadaaldjain/DemoBackend
