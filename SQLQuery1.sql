create table article 

( 

article_id int identity(1,1) primary key, 

article_topic char(60), 

article_description varchar(4000), 

article_publishby char(20) 

) 

insert into article values('Covid-19','The Coronavirus (COVID-19) is a new respiratory illness first identified during an investigation into an outbreak in Wuhan, China, but has now spread to other parts of the world, including the United States. The virus that causes COVID-19 is called SARS-CoV-2 and is spread between people who are in close contact with each other (within about six feet), mostly through respiratory droplets produced when an infected person coughs or sneezes.','Jhon Denver') 

drop table Appointments

create table Appointments(
Id int identity(1,1) primary key,
Time varchar(30),
Reason varchar(400),
Doctor_email varchar(50),
Patient_email varchar(50))

