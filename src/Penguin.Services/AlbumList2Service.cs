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

using Penguin.Services.Data;
using Penguin.Services.Data.Dtos;

namespace Penguin.Services
{
    public interface IAlbumList2Service
    {
        Task<IEnumerable<AlbumList2Item>> GetAlbums(
            string type,
            int? size,
            int? offset,
            int? fromYear,
            int? toYear,
            string? genre,
            string? musicFolderId);
    }

    public class AlbumList2Service : IAlbumList2Service
    {
        private readonly IPenguinRepository repository;

        public AlbumList2Service(IPenguinRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<AlbumList2Item>> GetAlbums(
            string type,
            int? size,
            int? offset,
            int? fromYear,
            int? toYear,
            string? genre,
            string? musicFolderId)
        {
            AlbumListType? albumListType = null;

            switch (type)
            {
                case "random":
                {
                    albumListType = AlbumListType.RANDOM;
                    break;
                }
                case "newest":
                {
                    albumListType = AlbumListType.NEWEST;
                    break;
                }
                case "highest":
                {
                    albumListType = AlbumListType.HIGHEST;
                    break;
                }
                case "frequent":
                {
                    albumListType = AlbumListType.FREQUENT;
                    break;
                }
                case "recent":
                {
                    albumListType = AlbumListType.RECENT;
                    break;
                }
                case "alphabeticalByName":
                {
                    albumListType = AlbumListType.ALPHABETICAL_BY_NAME;
                    break;
                }
                case "alphabeticalByArtis":
                {
                    albumListType = AlbumListType.ALPHABETICAL_BY_ARTIST;
                    break;
                }
                case "starred":
                {
                    albumListType = AlbumListType.STARRED;
                    break;
                }
                case "byYear":
                {
                    albumListType = AlbumListType.BY_YEAR;
                    break;
                }
                case "byGenre":
                {
                    albumListType = AlbumListType.BY_GENRE;
                    break;
                }
                default:
                {
                    throw new ArgumentException($"'{type}' is not a valid value for type.");
                }
            }
            return repository.ListAlbums2(
                albumListType.Value,
                size,
                offset,
                fromYear,
                toYear,
                genre,
                string.IsNullOrEmpty(musicFolderId) ? null : int.Parse(musicFolderId));
        }
    }
}