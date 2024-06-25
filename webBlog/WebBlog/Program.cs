using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.Extensions.Configuration;
using ModelEFCore;
using BlogHelper;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<GenerateToken>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(opt => {
    opt.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions
    {
        EndPoints = { "localhost:6379" }, // Redis ��������ַ�Ͷ˿�
        Password = "137624351",  // Redis ����
    };
    opt.InstanceName = "cache_";
});
builder.Services.AddCors(opt => {
    opt.AddDefaultPolicy(b => {
        b.WithOrigins(new string[] { "http://localhost:5173" }).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});
builder.Services.AddDbContext<MyDbContext>(opt => {
#pragma warning disable CS8600 // �� null �����������Ϊ null ��ֵת��Ϊ�� null ���͡�
    string connStr = builder.Configuration.GetSection("connStr").Value;
#pragma warning restore CS8600 // �� null �����������Ϊ null ��ֵת��Ϊ�� null ���͡�
    opt.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
    //дһ�������ʾ������̨ �Ƿ�ɹ��������ݿ�Ĵ���  
        
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine("�������ݿ�ɹ���");
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
