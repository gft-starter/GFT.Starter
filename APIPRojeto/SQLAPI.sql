insert into Cars(Id,Plate, Brand, Model, Color,Year, OwnerId)
values ('6837f64a-5316-4d23-bd8c-03ffffce980e','FAG0144','Renault', 'Duster','Vermelha','2013', '27329cd9-7881-4e65-ac8e-004a3fbd6901');

insert into Cars(Id,Plate, Brand, Model, Color,Year, OwnerId)
values ('338634c2-3164-4ac7-9426-da8bc1608849','NFS2015','Nissan', 'Skyline','Prata','2015', '06106cf6-b27d-49d1-a4d1-039eaafb8763');

insert into Owners(Id,Name,CPF,BirthDate,Gender)
values('27329cd9-7881-4e65-ac8e-004a3fbd6901','Carlos Miguel','33343412345','1995-10-15','M');

insert into Owners(Id,Name,CPF,BirthDate,Gender)
values('c4c343dd-a2e4-4867-91d6-f98df17c9a7f','Talita Reis','00347467348','1989-04-20','F');
insert into Owners(Id,Name,CPF,BirthDate,Gender)
values('06106cf6-b27d-49d1-a4d1-039eaafb8763','Roger Riders','09043288000','1989-02-28','M');

select * from Owners;
select * from Cars;