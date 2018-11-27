DROP DATABASE IF EXISTS song_seller;
CREATE DATABASE song_seller;

USE song_seller;

CREATE TABLE person_type (
id INT AUTO_INCREMENT PRIMARY KEY,
name ENUM('Composer', 'Solo Artist', 'Group') NOT NULL UNIQUE
);

CREATE TABLE persons (
id INT AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(150) NOT NULL,
age INT NOT NULL,
address VARCHAR(150) NOT NULL,
type_id INT NOT NULL,
CONSTRAINT FOREIGN KEY (type_id) REFERENCES person_type(id)
);

CREATE TABLE person_groups (
id INT AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(150) NOT NULL UNIQUE,
type_id INT NOT NULL,
CONSTRAINT FOREIGN KEY (type_id) REFERENCES person_type(id)
);

CREATE TABLE group_info (
person_id INT,
group_id INT,
CONSTRAINT FOREIGN KEY (person_id) REFERENCES persons(id),
CONSTRAINT FOREIGN KEY (group_id) REFERENCES person_groups(id)
);

CREATE TABLE songs (
id INT AUTO_INCREMENT PRIMARY KEY,
title VARCHAR(200) NOT NULL,
duration INT NOT NULL
);

CREATE TABLE song_info (
person_id INT,
song_id INT,
group_id INT,
CONSTRAINT FOREIGN KEY (person_id) REFERENCES persons(id),
CONSTRAINT FOREIGN KEY (song_id) REFERENCES songs(id),
CONSTRAINT FOREIGN KEY (group_id) REFERENCES person_groups(id)
/* CONSTRAINT PK_person_song PRIMARY KEY (person_id, song_id) */
);

CREATE TABLE arrangements (
id INT AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE song_arrangement (
song_id INT,
arrangement_id INT,
CONSTRAINT FOREIGN KEY (song_id) REFERENCES songs(id),
CONSTRAINT FOREIGN KEY (arrangement_id) REFERENCES arrangements(id)
);

CREATE TABLE genres (
id INT AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE song_genre (
song_id INT,
genre_id INT,
CONSTRAINT FOREIGN KEY (song_id) REFERENCES songs(id),
CONSTRAINT FOREIGN KEY (genre_id) REFERENCES genres(id)
);

CREATE TABLE styles (
id INT AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE song_style (
song_id INT,
style_id INT,
CONSTRAINT FOREIGN KEY (song_id) REFERENCES songs(id),
CONSTRAINT FOREIGN KEY (style_id) REFERENCES styles(id)
);

/* INSERT заявки за добавяне на изпълнител и композитор */
INSERT INTO person_type (name) VALUES ('Solo Artist'); -- ID = 1
INSERT INTO person_type (name) VALUES ('Composer'); -- ID = 2
INSERT INTO person_type (name) VALUES ('Group'); -- ID = 3

/* INSERT заявки за добавяне на изпълнители */
INSERT INTO persons (name, age, address, type_id) VALUES ('50 Cent', 42, '50 Cent address', 1); -- ID = 1
INSERT INTO persons (name, age, address, type_id) VALUES ('Ice Cube', 48, 'Ice Cube address', 1); -- ID = 2
INSERT INTO persons (name, age, address, type_id) VALUES ('Taylor Swift', 28, 'Taylor Swift address', 1); -- ID = 3
INSERT INTO persons (name, age, address, type_id) VALUES ('Bon Jovi', 35, 'Bon Jovi address', 1); -- ID = 4
INSERT INTO persons (name, age, address, type_id) VALUES ('Eminem', 35, 'Eminem address', 1); -- ID = 5
INSERT INTO persons (name, age, address, type_id) VALUES ('Takeoff', 23, 'Takeoff address', 1); -- ID = 6
INSERT INTO persons (name, age, address, type_id) VALUES ('Offset', 26, 'Offset address', 1); -- ID = 7
INSERT INTO persons (name, age, address, type_id) VALUES ('Quavo', 27, 'Quavo address', 1); -- ID = 8

/* INSERT заявки за добавяне на композитори */
INSERT INTO persons (name, age, address, type_id) VALUES ('Lars Winther', 38, 'Lars Winther address', 2); -- ID = 9
INSERT INTO persons (name, age, address, type_id) VALUES ('Jacob Cooper', 28, 'Jacob Cooper address', 2); -- ID = 10
INSERT INTO persons (name, age, address, type_id) VALUES ('Daniel Hensel', 40, 'Daniel Hensel address', 2); -- ID = 11

/* INSERT заявки за добавяне на групи */
INSERT INTO person_groups (name, type_id) VALUES ('Migos', 3); -- ID = 1

/* INSERT заявки за добавяне на изпълнители към група */
INSERT INTO group_info (person_id, group_id) VALUES (6, 1);
INSERT INTO group_info (person_id, group_id) VALUES (7, 1);
INSERT INTO group_info (person_id, group_id) VALUES (8, 1);

/* INSERT заявки за добавяне на аранжименти */
INSERT INTO arrangements (name) VALUES ('Electronic'); -- ID = 1
INSERT INTO arrangements (name) VALUES ('Jazz'); -- ID = 2

/* INSERT заявки за добавяне на жанрове */
INSERT INTO genres (name) VALUES ('Hip-Hop'); -- ID = 1
INSERT INTO genres (name) VALUES('Pop'); -- ID = 2
INSERT INTO genres (name) VALUES ('Rock'); -- ID = 3

/* INSERT заявки за добавяне на стилове */
INSERT INTO styles (name) VALUES ('Dance'); -- ID = 1
INSERT INTO styles (name) VALUES('Sad'); -- ID = 2
INSERT INTO styles (name) VALUES('Funky'); -- ID = 3
INSERT INTO styles (name) VALUES('Deep'); -- ID = 4

/* INSERT заявки за добавяне на песни */

INSERT INTO songs (title, duration) VALUES ('Pilot', 182); -- ID = 1
INSERT INTO songs (title, duration) VALUES ('Gangsta Rap Made Me Do It', 350); -- ID = 2
INSERT INTO songs (title, duration) VALUES ('Animal Ambition', 200); -- ID = 3
INSERT INTO songs (title, duration) VALUES ('Im The Man', 351); -- ID = 4
INSERT INTO songs (title, duration) VALUES ('Look What You Made Me Do', 249); -- ID = 5
INSERT INTO songs (title, duration) VALUES ('Its My Life', 220); -- ID = 6
INSERT INTO songs (title, duration) VALUES ('Shake It Off', 300); -- ID = 7
INSERT INTO songs (title, duration) VALUES ('Not Afraid', 290); -- ID = 8
INSERT INTO songs (title, duration) VALUES ('In Your Head', 320); -- ID = 9
INSERT INTO songs (title, duration) VALUES ('Talkin 2 Myself', 400); -- ID = 10
INSERT INTO songs (title, duration) VALUES ('Trapstar', 140); -- ID = 11
INSERT INTO songs (title, duration) VALUES ('Growth', 180); -- ID = 12
INSERT INTO songs (title, duration) VALUES ('Intruder', 134); -- ID = 13
INSERT INTO songs (title, duration) VALUES ('Slippery', 320); -- ID = 14
INSERT INTO songs (title, duration) VALUES ('Get Right Witcha', 274); -- ID = 15

/* INSERT заявки за свърване на песен към даден изпълнител | група */
INSERT INTO song_info (person_id, song_id) VALUES (1, 1);
INSERT INTO song_info (person_id, song_id) VALUES (1, 3);
INSERT INTO song_info (person_id, song_id) VALUES (1, 4);
INSERT INTO song_info (person_id, song_id) VALUES (2, 2);
INSERT INTO song_info (person_id, song_id) VALUES (3, 5);
INSERT INTO song_info (person_id, song_id) VALUES (3, 7);
INSERT INTO song_info (person_id, song_id) VALUES (4, 6);
INSERT INTO song_info (person_id, song_id) VALUES (5, 8);
INSERT INTO song_info (person_id, song_id) VALUES (5, 9);
INSERT INTO song_info (person_id, song_id) VALUES (5, 10);
INSERT INTO song_info (person_id, song_id) VALUES (6, 13);
INSERT INTO song_info (person_id, song_id) VALUES (7, 12);
INSERT INTO song_info (person_id, song_id) VALUES (8, 11);
INSERT INTO song_info (group_id, song_id) VALUES (1, 14);
INSERT INTO song_info (group_id, song_id) VALUES (1, 15);

/* INSERT заявки за свърване на песен към даден композитор */
INSERT INTO song_info (person_id, song_id) VALUES (9, 5);
INSERT INTO song_info (person_id, song_id) VALUES (9, 7);
INSERT INTO song_info (person_id, song_id) VALUES (10, 6);

/* INSERT заявки за свързване на песен към даден жанр */
INSERT INTO song_genre (song_id, genre_id) VALUES (1, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (2, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (3, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (4, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (5, 2);
INSERT INTO song_genre (song_id, genre_id) VALUES (6, 3);
INSERT INTO song_genre (song_id, genre_id) VALUES (7, 2);
INSERT INTO song_genre (song_id, genre_id) VALUES (8, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (9, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (10, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (11, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (12, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (13, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (14, 1);
INSERT INTO song_genre (song_id, genre_id) VALUES (15, 1);

/* INSERT заявки за свързване на песен към даден стил */
INSERT INTO song_style (song_id, style_id) VALUES (1, 1);
INSERT INTO song_style (song_id, style_id) VALUES (2, 4);
INSERT INTO song_style (song_id, style_id) VALUES (3, 1);
INSERT INTO song_style (song_id, style_id) VALUES (4, 4);
INSERT INTO song_style (song_id, style_id) VALUES (5, 1);
INSERT INTO song_style (song_id, style_id) VALUES (6, 1);
INSERT INTO song_style (song_id, style_id) VALUES (7, 3);
INSERT INTO song_style (song_id, style_id) VALUES (8, 4);
INSERT INTO song_style (song_id, style_id) VALUES (9, 4);
INSERT INTO song_style (song_id, style_id) VALUES (10, 4);
INSERT INTO song_style (song_id, style_id) VALUES (11, 1);
INSERT INTO song_style (song_id, style_id) VALUES (12, 1);
INSERT INTO song_style (song_id, style_id) VALUES (13, 1);
INSERT INTO song_style (song_id, style_id) VALUES (14, 3);
INSERT INTO song_style (song_id, style_id) VALUES (15, 1);

/* INSERT заявки за свързване на песен към даден аранжимент */
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (1, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (2, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (3, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (4, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (5, 2);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (6, 2);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (7, 2);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (8, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (9, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (10, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (11, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (12, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (13, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (14, 1);
INSERT INTO song_arrangement (song_id, arrangement_id) VALUES (15, 1);

/* SECOND TASK */
SELECT persons.name AS Artist, persons.age AS Age, songs.title AS Song, songs.duration AS Duration
FROM persons
JOIN songs ON persons.id IN (
	SELECT person_id
	FROM song_info
	WHERE song_id = songs.id)
WHERE persons.type_id = 1 AND persons.name LIKE '%Eminem%'
ORDER BY songs.title;

/* THIRD TASK */
SELECT persons.name AS Artist, COUNT(songs.id) AS Songs, SUM(songs.duration) AS total_duration
FROM persons
JOIN songs ON persons.id IN (
	SELECT person_id
	FROM song_info
	WHERE song_id = songs.id)
WHERE persons.type_id = 1
GROUP by persons.name
HAVING songs > 1
UNION
SELECT person_groups.name AS Artist, COUNT(songs.id) AS Songs, SUM(songs.duration) AS total_duration
FROM person_groups
JOIN songs ON person_groups.id IN (
	SELECT group_id
	FROM group_info
	WHERE group_id IN (
		SELECT group_id
		FROM song_info
		WHERE song_id = songs.id))
GROUP by person_groups.name
HAVING songs > 1
ORDER BY songs DESC;

/* FOURTH TASK - INNER JOIN */
SELECT persons.name AS person_name, person_type.name AS type, songs.title AS songTitle
FROM persons
INNER JOIN song_info ON persons.id = song_info.person_id
INNER JOIN songs ON song_info.song_id = songs.id
INNER JOIN person_type ON persons.type_id = person_type.id
ORDER BY person_type.name DESC;

/* FOURTH TASK - LEFT OUTER JOIN */
SELECT persons.name AS person_name, person_type.name AS type, songs.title AS song_title
FROM persons
LEFT JOIN songs ON persons.id IN (
	SELECT person_id
	FROM song_info
	WHERE song_id = songs.id)
JOIN person_type ON persons.type_id = person_type.id;

/* FIFTH TASK */
SELECT persons.name AS Composer, Count(songs.id) AS songs
FROM persons
LEFT JOIN song_info ON persons.id = song_info.person_id
LEFT JOIN songs ON song_info.song_id = songs.id
JOIN person_type ON persons.type_id = person_type.id
WHERE persons.type_id = 2
GROUP BY persons.name;

/* SIX TASK */
USE song_seller;
DROP PROCEDURE IF EXISTS CursorTask;
DELIMITER |
CREATE PROCEDURE CursorTask()
BEGIN
DECLARE finished INT;
DECLARE lastId INT;
DECLARE tempArtistName VARCHAR(200);
DECLARE tempType VARCHAR(200);
DECLARE tempSongName VARCHAR(200);
DECLARE tempSongDuration INT;

DECLARE SongsCursor CURSOR FOR
SELECT persons.name AS Name, person_type.name AS type, songs.title AS title, songs.duration AS song_duration
FROM persons
JOIN songs ON persons.id IN (
	SELECT person_id
	FROM song_info
	WHERE song_id = songs.id)
JOIN person_type ON persons.id 
WHERE person_type.id = persons.type_id
UNION
SELECT person_groups.name AS Name, person_type.name AS type, songs.title AS title, songs.duration AS song_duration
FROM person_groups
JOIN songs ON person_groups.id IN (
	SELECT group_id
	FROM group_info
	WHERE group_id IN (
		SELECT group_id
		FROM song_info
		WHERE song_id = songs.id))
JOIN person_type ON person_groups.type_id
WHERE person_type.id = person_groups.type_id;

DECLARE CONTINUE handler FOR NOT FOUND SET finished = 1;
SET finished = 0;
set lastId = 0;
DROP TABLE IF EXISTS tempSongsInfo;
CREATE TEMPORARY TABLE tempSongsInfo(
	id INT PRIMARY KEY AUTO_INCREMENT,
	name VARCHAR(200),
	person_type VARCHAR(100),
	songTitle VARCHAR(200),
	songDuration INT,
	finishStatus INT NULL DEFAULT 0
) ENGINE = Memory;
OPEN SongsCursor;
songs_loop: WHILE (finished = 0)
DO
FETCH SongsCursor INTO tempArtistName, tempType, tempSongName, tempSongDuration;
	IF (finished = 1)
THEN
	LEAVE songs_loop;
	END IF;
SET lastId = lastId + 1;
INSERT INTO tempSongsInfo VALUES (lastId, tempArtistName, tempType, tempSongName, tempSongDuration, 0);
END WHILE;
CLOSE SongsCursor;
SET finished = 0;
UPDATE tempSongsInfo SET finishStatus = 1 WHERE id = lastId;
SELECT * FROM tempSongsInfo;
DROP TABLE tempSongsInfo;
END
|
DELIMITER ;

CALL CursorTask();