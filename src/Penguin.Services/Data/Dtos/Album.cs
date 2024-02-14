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
    public class Album
    {
        public Album()
        {
            Name = "";
            Songs = new List<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SongCount => Songs.Count();
        public int Duration => Songs.Aggregate(0, (currentDuration, song) => currentDuration + song.Duration);
        public DateTime Created { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public string? Genre { get; set; }
        public int? CoverArtId { get; set; }
    }
}