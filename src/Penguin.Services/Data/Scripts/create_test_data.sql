INSERT INTO Genres (Name) VALUES ("Rock");

INSERT INTO Artists (Name) VALUES ("Pink Floyd"), ("Yes");

INSERT INTO Albums (Name, ArtistId, SongCount, Duration, Created) VALUES ("Dark Side of the Moon", 1, 0, 0, date()), ("Fragile", 2, 0, 0, date());

INSERT INTO Songs (Name, AlbumId, GenreId, Duration, TrackNumber, Created) VALUES ("Any Colour You Like", 1, 1, 206, 8, date()), ("Time", 1, 1, 376, 4, date()), ("Heart of the Sunrise", 2, 1, 676, 9, date());