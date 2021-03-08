# codeTest

## AUTHOR: Manuel Antonio Gómez Angulo
## RELEASE DATE: 08/03/2021

It is about the automatic download of files developed in C# with a source json downloaded from a web server, which has to be deserializated, maintaining the folder structure

### Architecture and technologies used:
* **Ubuntu 20.04**
* **Net core 3.1.406**
* Nginx Web server
* Visual studio code
* Nunit
* Newtonsoft.Json

### Points completed
* **Code in english with so love and not so bad style of code (I think)**
* Main allows the passing of parameters. Url, name of file json and path to download
* **Deserialization of json hosted on local web server (Nginx)**
* **Download of remote files** maintaining the folder structure. Download is **asynchronous**
* Files only will be downloaded when they are required and they do not exist locally
* If it exists locally, the **md5 is checked**. If it is different, the file will be downloaded 
* It contains two **Nunit tests**. I had to throw out most for a refactoring

### Points not completed:
* **Code with the best style of code (I think)**
* Data entry form, available for when there are no parameters
* Download progress bar
* **Use of Moq**
* **Implement that can deserialize the json when a folder is empty on the web server, fixing the null pointer exception error in the leaf**

So **many thanks to the people** who have given me the exercise, **to prove myself**
