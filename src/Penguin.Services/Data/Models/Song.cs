/*

Copyright (C) 2024 Nathan McCrina

This file is part of Penguin.
   
Penguin is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or (at
your option) any later version.

Penguin is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Penguin.  If not, see <https://www.gnu.org/licenses/>.

*/

using System.Text.Json.Serialization;

namespace Penguin.Services.Data.Models
{
    public class Song
    {
        public Song()
        {
            Name = "";
            Path = "";
            Album = new Album();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public Album? Album { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int Duration { get; set; }
        public int? TrackNumber { get; set; }
        public DateTime Created { get; set; }
        public int? CoverArtId { get; set; }
        public CoverArt? CoverArt { get; set; }
        public string Path { get; set; }
        public int? LibraryId { get; set; }
        public Library? Library { get; set; }
    }
}