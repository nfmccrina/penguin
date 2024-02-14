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
    public class ReplayGain
    {
        public int? TrackGain { get; set; }
        public int? AlbumGain { get; set; }
        public int? TrackPeak { get; set; }
        public int? AlbumPeak { get; set; }
        public int? BaseGain { get; set; }
        public int? FallbackGain { get; set; }
    }
}