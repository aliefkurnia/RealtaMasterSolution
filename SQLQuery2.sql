Create Procedure Master.SpCountry1
(
	@country_id int,
	@country_name nvarchar(50),
	@country_region_id int
)
AS
BEGIN
	BEGIN TRANSACTION
		SAVE TRANSACTION SavePoint;
	BEGIN TRY
		UPDATE master.country
		SET country_name = @country_name,
			country_region_id = @country_region_id
		WHERE country_id = @country_id

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
			ROLLBACK SavePoint;
	END CATCH
END 
GO