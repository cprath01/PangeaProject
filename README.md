# PangeaProject
Pangea Project	
Quick instructions to get the application running locally.

1. Install RabbitMQ 
	- https://www.rabbitmq.com/download.html - you may need to install Erlang first but instructions are availabe on the RabbitMQ site.
	
2. Add the Management plugin for RabbitMQ
	- https://www.rabbitmq.com/management.html

3. Add Queue through Management Plugin
	- http://localhost:15672/#/queues
	  -name the queue "local"

4. Open the PangeaProject in Visual Studio and Publish the Database project called PangeaRepoDB
	- Setup was tested with SQLExpress locally 
	
5. Update connectionstring in the two solutions
	- connection was tested with Windows Auth.
	a. PangeaProject 
			- src\PangeaProject.DAL\PangeaRepoDB.edmx\PangeaRepoDB.Context.tt\PangeaProject.Context.cs
			- Change the connectionstring inthe base class constructor.
	b. MQConsumerService
			- MQConsumerService\App.config
			- Change the value in the PangeaRepoDBEntities connectionstring
			
6. Ready to run both projects at the same time to make everything work.
	- Setup was tested with both projects in Visual Studio 15 running at the same time.
