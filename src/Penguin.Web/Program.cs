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


using Penguin.Services;
using Penguin.Services.Data;
using Penguin.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IPingResponseBuilder, PingResponseBuilder>();
builder.Services.AddTransient<IGetGenresResponseBuilder, GetGenresResponseBuilder>();
builder.Services.AddTransient<IAlbumList2ResponseBuilder, AlbumList2ResponseBuilder>();
builder.Services.AddTransient<IGetAlbumResponseBuilder, GetAlbumResponseBuilder>();
builder.Services.AddTransient<ICoverArtMimeTypeService, CoverArtMimeTypeService>();
builder.Services.AddTransient<ISongMimeTypeService, SongMimeTypeService>();

builder.Services.AddTransient<IPenguinRepository, PenguinRepository>();

builder.Services.AddTransient<IGetGenresService, GetGenresService>();
builder.Services.AddTransient<IAlbumList2Service, AlbumList2Service>();
builder.Services.AddTransient<IGetAlbumService, GetAlbumService>();
builder.Services.AddTransient<IGetCoverArtService, GetCoverArtService>();
builder.Services.AddTransient<IStreamService, StreamService>();

builder.Services.AddDbContext<PenguinDbContext>();

builder.Services.AddHttpLogging(o => {});

builder.Services.AddCors(options => {
    options.AddPolicy(name: "PenguinPolicy", policy => {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();
app.UsePathBase("/rest");

app.UseRouting();

app.UseCors("PenguinPolicy");
app.UseHttpLogging();

app.MapControllers();

app.Run();
