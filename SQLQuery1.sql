select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'country'
select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'address'
select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'members'
select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'service_task'
select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'price_items'
select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'policy'
select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'category_group'
select * from Hotel_Realta.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'policy_category_group'



select * from master.country
select * from master.address
select * from master.members
select * from master.price_items


 INSERT INTO Master.Country(country_name) 
                                    VALUES('jepang')
                                    SELECT cast(scope_identity() as int) 

alter table master.country
add constraint defaultvaluecountry default null for Country_region_id

alter table master.address
add constraint defaultvalueaddress default null for addr_spatial_location

    alter table master.address 
    alter column addr_spatial_location NVARCHAR(50);

ALTER TABLE master.address 
    ALTER COLUMN addr_spatial_location NVARCHAR(50);
    
drop table master.address
UPDATE master.address
SET addr_spatial_location = CONVERT(NVARCHAR(50), addr_spatial_location.ToString())

ALTER TABLE master.address
DROP CONSTRAINT fk_addr_prov_id;
