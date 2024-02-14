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

namespace Penguin.Services.Data.Dtos
{
    public class AlbumList2Item
    {
        public AlbumList2Item()
        {
            Id = "";
            Name = "";
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Artist { get; set; }
        public string? ArtistId { get; set; }
        public string? CoverArt { get; set; }
        public int SongCount { get; set; }
        public int Duration { get; set; }
        public int? PlayCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Starred { get; set; }
        public int? Year { get; set; }
        public string? Genre { get; set; }
    }
}