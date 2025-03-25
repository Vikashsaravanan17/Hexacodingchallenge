Create database Art_Gallery;

Use Art_Gallery;

--Task creating tables

-- Create the Artists table 
CREATE TABLE Artists ( 
ArtistID INT PRIMARY KEY, 
Name VARCHAR(255) NOT NULL, 
Biography TEXT, 
Nationality VARCHAR(100)); 

-- Create the Categories table 
CREATE TABLE Categories ( 
CategoryID INT PRIMARY KEY, 
Name VARCHAR(100) NOT NULL); 

-- Create the Artworks table 
CREATE TABLE Artworks ( 
ArtworkID INT PRIMARY KEY, 
Title VARCHAR(255) NOT NULL, 
ArtistID INT, 
CategoryID INT, 
Year INT, 
Description TEXT, 
ImageURL VARCHAR(255), 
FOREIGN KEY (ArtistID) REFERENCES Artists (ArtistID), 
FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID)); 

-- Create the Exhibitions table 
CREATE TABLE Exhibitions ( 
ExhibitionID INT PRIMARY KEY, 
Title VARCHAR(255) NOT NULL, 
StartDate DATE, 
EndDate DATE, 
Description TEXT);

-- Create a table to associate artworks with exhibitions 
CREATE TABLE ExhibitionArtworks ( 
ExhibitionID INT, 
ArtworkID INT, 
PRIMARY KEY (ExhibitionID, ArtworkID), 
FOREIGN KEY (ExhibitionID) REFERENCES Exhibitions (ExhibitionID), 
FOREIGN KEY (ArtworkID) REFERENCES Artworks (ArtworkID)); 

-- Insert sample data into the Artists table 
INSERT INTO Artists (ArtistID, Name, Biography, Nationality) VALUES 
(1, 'Pablo Picasso', 'Renowned Spanish painter and sculptor.', 'Spanish'), 
(2, 'Vincent van Gogh', 'Dutch post-impressionist painter.', 'Dutch'), 
(3, 'Leonardo da Vinci', 'Italian polymath of the Renaissance.', 'Italian'),
(4, 'Monkey. D. Luffy',' Sun God Nika', 'Mexico'),
(5, 'ZORO', 'Desendent from Wano', 'Wano'),
(6, 'Sanji', 'Prince of Germa Kingdom', 'France'),
(7, 'Franky', 'Renowned Shipwright and engineer', 'American'),
(8, 'Nami', 'Best Navigator in the East Blue', 'Swiz'),
(9, 'Tony Tony Chopper', 'Youngest Doctor.', 'Canada'),
(10, 'Usopp', 'Brave warrior of the Sea.', 'Uganda'); 

-- Insert sample data into the Categories table 
INSERT INTO Categories (CategoryID, Name) VALUES 
(11, 'Painting'), 
(12, 'Sculpture'), 
(13, 'Photography'), 
(14, 'Drawing'),
(15, 'Sketching'), 
(16, 'Portrait'),
(17, 'Engineering designs'),
(18, 'Landscape'),
(19, 'venipuncture'),
(20, 'Designs'); 

-- Insert sample data into the Artworks table 
INSERT INTO Artworks (ArtworkID, Title, ArtistID, CategoryID, Year, Description, ImageURL) VALUES 
(21, 'Guernica', 1,11, 1937, 'Pablo Picasso\s powerful anti-war mural.', 'guernica.jpg'),
(22, 'Starry Night', 2, 12, 1889, 'A famous painting by Vincent van Gogh.', 'starry_night.jpg'), 
(23, 'Mona Lisa', 3, 13, 1503, 'The iconic portrait by Leonardo da Vinci.', 'mona_lisa.jpg'), 
(24, 'Niggu', 4, 14, 2005, 'luffy\s powerful Meat mural.', 'MEAT.jpg'),
(25, 'Enma', 5, 15, 2021, 'Zoro\s powerful Enma mural.', 'Enma.jpg'),
(26, 'Pudding', 6, 16, 2019, 'Sanji\s powerful Pudding mural.', 'Pudding.jpg'),
(27, 'Thoudsandsunny', 7, 17, 2015, 'Franky\s powerful anti-war mural.', 'Thousandsunny.jpg'),
(28, 'Cocovillage', 8, 18, 2003, 'Pablo Picasso\s powerful anti-war mural.', 'Cocovillage.jpg'),
(29, 'Monsterpoint', 9, 19, 2004, 'Pablo Picasso\s powerful anti-war mural.', 'Monsterpoint.jpg'),
(30, 'Kabuto', 10, 20, 2014, 'Pablo Picasso\s powerful anti-war mural.', 'Kabuto.jpg'); 

-- Insert sample data into the Exhibitions table 
INSERT INTO Exhibitions (ExhibitionID, Title, StartDate, EndDate, Description) VALUES 
(41, 'Modern Art Masterpieces', '2023-01-01', '2023-03-01', 'A collection of modern art masterpieces.'), 
(42, 'Renaissance Art', '2023-04-01', '2023-06-01', 'A showcase of Renaissance art treasures.'),
(43, 'Wonders of Da Vinci', '2023-06-01', '2023-08-01', 'Magic of Da Vinci.'),
(44, 'Brains of Luffy', '2023-08-01', '2023-10-01', 'Showcase of Luff thoughts.'),
(45, 'King of Hell Enma', '2023-10-01', '2023-11-01', 'Might of Zoro .'),
(46, 'Love of Sanji', '2023-11-01', '2024-01-01', 'Love fro the women with 3 Eyes'),
(47, 'Secrets of franky', '2024-04-01', '2024-06-01', 'What is Pluton'),
(48, 'Dream of Nami', '2024-06-01', '2024-08-01', 'Map of the whole world'),
(49, 'Work of Chopper', '2024-08-01', '2024-10-01', 'Doctor Job.'),
(50, 'Warrior of sea', '2024-10-01', '2024-11-01', 'Aim of the Sniper King.'); 

-- Insert artworks into exhibitions 
INSERT INTO ExhibitionArtworks (ExhibitionID, ArtworkID) VALUES 
(41, 21), 
(42, 22), 
(43, 23), 
(44, 24),
(45, 25),
(46, 26),
(47, 27),
(48, 28),
(49, 29),
(50, 30); 

--Solve the below queries: 
--1. Retrieve the names of all artists along with the number of artworks they have in the gallery, and 
--list them in descending order of the number of artworks.
Select a.name,count(a1.ArtworkID) as artworkcount from Artists a join Artworks a1 on a.ArtistID=a1.ArtistID Group by a.name;

--2 List the titles of artworks created by artists from 'Spanish' and 'Dutch' nationalities, and order them by the year in ascending order. 
Select a1. Title,a1. Year ,a.Nationality,a.Name AS ArtistName from Artworks a1 join Artists a on a.ArtistID=a1.ArtistID 
where a.Nationality in('Spanish','Dutch');

--3 Find the names of all artists who have artworks in the 'Painting' category, and the number of artworks they have in this category. 
Select a.Name AS Artistname, COUNT(a1.ArtworkID) AS ArtworkCount FROM Artists a
join Artworks a1 ON a.ArtistID = a1.ArtistID
join Categories c ON a1.CategoryID = c.CategoryID
WHERE c.Name = 'Painting'
GROUP BY a.Name;

--4 List the names of artworks from the 'Modern Art Masterpieces' exhibition, along with their artists and categories.
Select a1.Title AS ArtworkTitle, a.Name AS ArtistName, c.Name AS CategoryName from Artworks a1 join Artists a on a1.ArtistID = a.ArtistID
join Categories c on a1.CategoryID = c.CategoryID join ExhibitionArtworks ea on a1.ArtworkID = ea.ArtworkID join Exhibitions e on ea.ExhibitionID = e.ExhibitionID
where e.Title = 'Modern Art Masterpieces';

--5 Find the artists who have more than two artworks in the gallery.
SELECT a.Name, NoOfWorks
from(select a1.ArtistID, COUNT(a1.ArtworkID) as NoOfWorks from Artworks a1 GROUP BY a1.ArtistID) as ArtworkCount
join Artists a ON a.ArtistID = ArtworkCount.ArtistID
where NoOfWorks > 2;
-- null result for >2 because no artist has more than 1 artwork but if we give =1
SELECT a.Name, NoOfWorks
from(select a1.ArtistID, COUNT(a1.ArtworkID) as NoOfWorks from Artworks a1 GROUP BY a1.ArtistID) as ArtworkCount
join Artists a ON a.ArtistID = ArtworkCount.ArtistID
where NoOfWorks =1;


--6 Find the titles of artworks that were exhibited in both 'Modern Art Masterpieces' and 'Renaissance Art' exhibitions
Select title from Artworks  where ArtworkID( select ea.ArtworkID
from Exhibitions e join ExhibitionArtworks ea ON e.ExhibitionID = ea.ExhibitionID WHERE e.Title IN ('Modern Art Masterpieces', 'Renaissance Art');

--7 Find the total number of artworks in each category 
Select c.Name as CategoryName, COUNT(a.ArtworkID) as TotalArtworks from Categories c
left join Artworks a on c.CategoryID = a.CategoryID group by c.Name;

--8 artist having more than 3 works
Select a.Name, Totalartworks from (select art.ArtistID, COUNT(art.ArtworkID) as TotalArtworks from Artworks art group by art.ArtistID) as ArtworkCount
join Artists a on a.ArtistID = ArtworkCount.ArtistID where TotalArtworks > 3;
--null output because no artist has more than 1 artwork
Select a.Name, Totalartworks from (select art.ArtistID, COUNT(art.ArtworkID) as TotalArtworks from Artworks art group by art.ArtistID) as ArtworkCount
join Artists a on a.ArtistID = ArtworkCount.ArtistID where TotalArtworks = 1;

--9 Find the artworks created by artists from a specific nationality (e.g., Spanish).
Select a1.Title AS ArtworkTitle from Artworks a1 join Artists a on a1.ArtistID = a.ArtistID WHERE a.Nationality = 'Spanish';  

--10   List exhibitions that feature artwork by both Vincent van Gogh and Leonardo da Vinci.
Select e.Title as ExhibitionTitle from Exhibitions e join ExhibitionArtworks ea1 on e.ExhibitionID = ea1.ExhibitionID 
join Artworks art1 on ea1.ArtworkID = art1.ArtworkID join Artists a1 on art1.ArtistID = a1.ArtistID
join ExhibitionArtworks ea2 ON e.ExhibitionID = ea2.ExhibitionID join Artworks art2 ON ea2.ArtworkID = art2.ArtworkID
join Artists a2 ON art2.ArtistID = a2.ArtistID WHERE a1.Name = 'Vincent van Gogh' AND a2.Name = 'Leonardo da Vinci';
--No exhibition has both da vinci and van gogh

--11 Find all the artworks that have not been included in any exhibition. 
Select art.Title, a.Name as Artistname from Artworks art join Artists a on art.ArtistID = a.ArtistID
join ExhibitionArtworks ea on art.ArtworkID = ea.ArtworkID where ea.ExhibitionID IS NULL;
--every art has been presented at an exhibition

--12  List artists who have created artworks in all available categories.
Select a.Name as Artistname from Artists a where not exists ( select c.CategoryID from Categories c where not exists (Select 1 from Artworks a1
where a1.ArtistID = a.ArtistID and a1.CategoryID = c.CategoryID ));
--No one

--13   List the total number of artworks in each category. 
Select  c.Name, COUNT(a.ArtworkID) from Categories c join Artworks a on c.CategoryID = a.CategoryID group by c.Name ; 

--14 Find the artists who have more than 2 artworks in the gallery. 
SELECT a.Name, NoOfWorks
from(select a1.ArtistID, COUNT(a1.ArtworkID) as NoOfWorks from Artworks a1 GROUP BY a1.ArtistID) as ArtworkCount
join Artists a ON a.ArtistID = ArtworkCount.ArtistID
where NoOfWorks > 2;
--no artist has 2 works 

--15  List the categories with the average year of artworks they contain, only for categories with more than 1 artwork.
Select c.Name as Categoryname, AvgYear from ( select art.CategoryID, AVG(art.Year) AS AvgYear, COUNT(art.ArtworkID) AS ArtworkCount from Artworks art
 group by art.CategoryID) as CategoryAvg JOIN Categories c ON c.CategoryID = CategoryAvg.CategoryID WHERE CategoryAvg.ArtworkCount >1; 
 -- no artist has more than one artwork but if given " = 1" we get
 Select c.Name as Categoryname, AvgYear from ( select art.CategoryID, AVG(art.Year) AS AvgYear, COUNT(art.ArtworkID) AS ArtworkCount from Artworks art
 group by art.CategoryID) as CategoryAvg JOIN Categories c ON c.CategoryID = CategoryAvg.CategoryID WHERE CategoryAvg.ArtworkCount =1; 

 --16 Find the artworks that were exhibited in the 'Modern Art Masterpieces' exhibition. 
 SELECT art.title as artwork_title, a.name as artist_name, c.name as category_name from artworks art join artists a on art.artistid = a.artistid
join categories c on art.categoryid = c.categoryid join exhibitionartworks ea on art.artworkid = ea.artworkid
join exhibitions e on ea.exhibitionid = e.exhibitionid where e.title = 'Modern Art Masterpieces';

--17 Find the categories where the average year of artworks is greater than the average year of all artworks. 
SELECT top 1 category_name, avg_category_year from (select c.name AS category_name, avg(a.year) AS avg_category_year from categories c
join artworks a on c.categoryid = a.categoryid group by c.name) AS category_avg where avg_category_year > (select avg(year) from artworks);

--18  List the artworks that were not exhibited in any exhibition.
SELECT art.title AS artwork_title, a.name AS artist_name, c.name AS category_name from artworks art 
join artists a on art.artistid = a.artistid join categories c on art.categoryid = c.categoryid join exhibitionartworks ea on art.artworkid = ea.artworkid
where ea.exhibitionid is null;
--every artwork has been displayed

--19 Show artists who have artworks in the same category as "Mona Lisa." 
SELECT a.name AS artist_name from artists a join artworks art on a.artistid = art.artistid where art.categoryid = (select categoryid from artworks 
where title = 'Mona Lisa');

--20 List the names of artists and the number of artworks they have in the gallery. 
SELECT a.name, COUNT(art.artworkid)  from artists a left join artworks art on a.artistid = art.artistid group by a.name;
