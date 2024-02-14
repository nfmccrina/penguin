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
using System.Xml.Serialization;

namespace Penguin.Web.Dtos
{
    public class AlbumSong
    {
        public AlbumSong()
        {
            Id = "";
            Title = "";
            ReplayGain = new ReplayGain();
        }

        [XmlAttribute(AttributeName = "id")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "parent")]
        [JsonPropertyName("parent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Parent { get; set; }
        [JsonIgnore]
        public bool ParentSpecified => !string.IsNullOrEmpty(Parent);

        [XmlAttribute(AttributeName = "isDir")]
        [JsonPropertyName("isDir")]
        public bool IsDir => false;

        [XmlAttribute(AttributeName = "title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "album")]
        [JsonPropertyName("album")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Album { get; set; }
        [JsonIgnore]
        public bool AlbumSpecified => !string.IsNullOrEmpty(Album);

        [XmlAttribute(AttributeName = "artist")]
        [JsonPropertyName("artist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Artist { get; set; }
        [JsonIgnore]
        public bool ArtistSpecified => !string.IsNullOrEmpty(Artist);

        [XmlAttribute(AttributeName = "track")]
        [JsonPropertyName("track")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Track { get; set; }
        [JsonIgnore]
        public bool TrackSpecified => Track != default;

        [XmlAttribute(AttributeName = "year")]
        [JsonPropertyName("year")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Year { get; set; }
        [JsonIgnore]
        public bool YearSpecified => Year != default;

        [XmlAttribute(AttributeName = "genre")]
        [JsonPropertyName("genre")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Genre { get; set; }
        [JsonIgnore]
        public bool GenreSpecified => !string.IsNullOrEmpty(Genre);

        [XmlAttribute(AttributeName = "coverArt")]
        [JsonPropertyName("coverArt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CoverArt { get; set; }
        [JsonIgnore]
        public bool CoverArtSpecified => !string.IsNullOrEmpty(CoverArt);

        [XmlAttribute(AttributeName = "size")]
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Size { get; set; }
        [JsonIgnore]
        public bool SizeSpecified => Size != default;

        [XmlAttribute(AttributeName = "contentType")]
        [JsonPropertyName("contentType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContentType { get; set; }
        [JsonIgnore]
        public bool ContentTypeSpecified => !string.IsNullOrEmpty(ContentType);

        [XmlAttribute(AttributeName = "suffix")]
        [JsonPropertyName("suffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Suffix { get; set; }
        [JsonIgnore]
        public bool SuffixSpecified => !string.IsNullOrEmpty(Suffix);

        [XmlAttribute(AttributeName = "transcodedContentType")]
        [JsonPropertyName("transcodedContentType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TranscodedContentType { get; set; }
        [JsonIgnore]
        public bool TranscodedContentTypeSpecified => !string.IsNullOrEmpty(TranscodedContentType);

        [XmlAttribute(AttributeName = "transcodedSuffix")]
        [JsonPropertyName("transcodedSuffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TranscodedSuffix { get; set; }
        [JsonIgnore]
        public bool TranscodedSuffixSpecified => !string.IsNullOrEmpty(TranscodedSuffix);

        [XmlAttribute(AttributeName = "duration")]
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Duration { get; set; }
        [JsonIgnore]
        public bool DurationSpecified => Duration != default;

        [XmlAttribute(AttributeName = "bitrate")]
        [JsonPropertyName("bitrate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Bitrate { get; set; }
        [JsonIgnore]
        public bool BitrateSpecified => Bitrate != default;

        [XmlAttribute(AttributeName = "path")]
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Path { get; set; }
        [JsonIgnore]
        public bool PathSpecified => !string.IsNullOrEmpty(Path);

        [XmlAttribute(AttributeName = "isVideo")]
        [JsonPropertyName("isVideo")]
        public bool IsVideo => false;

        [XmlAttribute(AttributeName = "userRating")]
        [JsonPropertyName("userRating")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int UserRating { get; set; }
        [JsonIgnore]
        public bool UserRatingSpecified => UserRating != default && UserRating >= 1 && UserRating <= 5;

        [XmlAttribute(AttributeName = "averageRating")]
        [JsonPropertyName("averageRating")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double AverageRating { get; set; }
        [JsonIgnore]
        public bool AverageRatingSpecified => AverageRating != default && AverageRating >= 1.0 && AverageRating <= 5.0;

        [XmlAttribute(AttributeName = "playCount")]
        [JsonPropertyName("playCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int PlayCount { get; set; }
        [JsonIgnore]
        public bool PlayCountSpecified => PlayCount != default;

        [XmlAttribute(AttributeName = "discNumber")]
        [JsonPropertyName("discNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int DiscNumber { get; set; }
        [JsonIgnore]
        public bool DiscNumberSpecified => DiscNumber != default;

        [XmlAttribute(AttributeName = "created")]
        [JsonPropertyName("created")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Created { get; set; }
        [JsonIgnore]
        public bool CreatedSpecified => Created != default;

        [XmlAttribute(AttributeName = "starred")]
        [JsonPropertyName("starred")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Starred { get; set; }
        [JsonIgnore]
        public bool StarredSpecified => Starred != default;

        [XmlAttribute(AttributeName = "albumId")]
        [JsonPropertyName("albumId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AlbumId { get; set; }
        [JsonIgnore]
        public bool AlbumIdSpecified => !string.IsNullOrEmpty(AlbumId);

        [XmlAttribute(AttributeName = "artistId")]
        [JsonPropertyName("artistId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ArtistId { get; set; }
        [JsonIgnore]
        public bool ArtistIdSpecified => !string.IsNullOrEmpty(ArtistId);

        [XmlAttribute(AttributeName = "type")]
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
        [JsonIgnore]
        public bool TypeSpecified => !string.IsNullOrEmpty(Type) && new List<string>() {"music", "podcast", "audiobook", "video"}.Contains(Type);

        [XmlAttribute(AttributeName = "mediaType")]
        [JsonPropertyName("mediaType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MediaType { get; set; }
        [JsonIgnore]
        public bool MediaTypeSpecified => !string.IsNullOrEmpty(MediaType) && new List<string>() {"song", "album", "artist"}.Contains(MediaType);

        [XmlAttribute(AttributeName = "bookmarkPosition")]
        [JsonPropertyName("bookmarkPosition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int BookmarkPosition { get; set; }
        [JsonIgnore]
        public bool BookmarkPositionSpecified => BookmarkPosition != default;

        [XmlAttribute(AttributeName = "originalWidth")]
        [JsonPropertyName("originalWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int OriginalWidth { get; set; }
        [JsonIgnore]
        public bool OriginalWidthSpecified => OriginalWidth != default;

        [XmlAttribute(AttributeName = "originalHeight")]
        [JsonPropertyName("originalHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int OriginalHeight { get; set; }
        [JsonIgnore]
        public bool OriginalHeightSpecified => OriginalHeight != default;

        [XmlAttribute(AttributeName = "played")]
        [JsonPropertyName("played")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Played { get; set; }
        [JsonIgnore]
        public bool PlayedSpecified => Played != default;

        [XmlAttribute(AttributeName = "bpm")]
        [JsonPropertyName("bpm")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int BPM { get; set; }
        [JsonIgnore]
        public bool BPMSpecified => BPM != default;

        [XmlAttribute(AttributeName = "comment")]
        [JsonPropertyName("comment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Comment { get; set; }
        [JsonIgnore]
        public bool CommentSpecified => !string.IsNullOrEmpty(Comment);

        [XmlAttribute(AttributeName = "sortName")]
        [JsonPropertyName("sortName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SortName { get; set; }
        [JsonIgnore]
        public bool SortNameSpecified => !string.IsNullOrEmpty(SortName);

        [XmlAttribute(AttributeName = "musicBrainzId")]
        [JsonPropertyName("musicBrainzId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MusicBrainzId { get; set; }
        [JsonIgnore]
        public bool MusicBrainzIdSpecified => !string.IsNullOrEmpty(MusicBrainzId);

        [XmlArray(ElementName = "genres", IsNullable = false)]
        [XmlArrayItem(ElementName = "genre")]
        [JsonPropertyName("genres")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<AlbumSongGenre>? Genres { get; set; }

        [XmlArray(ElementName = "artists", IsNullable = false)]
        [XmlArrayItem(ElementName = "artist")]
        [JsonPropertyName("artists")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<AlbumSongArtist>? Artists { get; set; }

        [XmlAttribute(AttributeName = "displayArtist")]
        [JsonPropertyName("displayArtist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DisplayArtist { get; set; }
        [JsonIgnore]
        public bool DisplayArtistSpecified => !string.IsNullOrEmpty(DisplayArtist);

        [XmlArray(ElementName = "albumArtists", IsNullable = false)]
        [XmlArrayItem(ElementName = "albumArtist")]
        [JsonPropertyName("albumArtists")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<AlbumSongArtist>? AlbumArtists { get; set; }

        [XmlAttribute(AttributeName = "displayAlbumArtist")]
        [JsonPropertyName("displayAlbumArtist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DisplayAlbumArtist { get; set; }
        [JsonIgnore]
        public bool DisplayAlbumArtistSpecified => !string.IsNullOrEmpty(DisplayAlbumArtist);

        [XmlArray(ElementName = "contributors", IsNullable = false)]
        [XmlArrayItem(ElementName = "contributor")]
        [JsonPropertyName("contributors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<AlbumSongContributor>? Contributors { get; set; }

        [XmlAttribute(AttributeName = "displayComposer")]
        [JsonPropertyName("displayComposer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DisplayComposer { get; set; }
        [JsonIgnore]
        public bool DisplayComposerSpecified => !string.IsNullOrEmpty(DisplayComposer);

        [XmlArray(ElementName = "moods", IsNullable = false)]
        [JsonPropertyName("moods")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Moods { get; set; }

        [XmlElement(ElementName = "replayGain")]
        [JsonPropertyName("replayGain")]
        public ReplayGain ReplayGain { get; set; }
    }
}