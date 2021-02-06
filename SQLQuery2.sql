INSERT INTO Cars (Id,BrandId,ColorId,ModelYear,DailyPrice,Description) VALUES (1,1,1,2019,75340.0,'VOLVO S40 2000CC');
INSERT INTO Cars (BrandId,ColorId,ModelYear,DailyPrice,Description) VALUES (1,2,2020,85000,'VOLVO S60 3000CC');
INSERT INTO Cars (BrandId,ColorId,ModelYear,DailyPrice,Description) VALUES (1,3,2021,95000,'VOLVO S80 3000CC');

INSERT INTO Colors (ColorName) VALUES ('Blue');

UPDATE Cars SET BrandId=2, ColorId=3, ModelYear=2019, DailyPrice=70000, Description='BMW i30 3000CC' Where Id=5;

INSERT INTO Brands (BrandName) VALUES ('BMW');
