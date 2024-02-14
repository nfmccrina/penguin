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
