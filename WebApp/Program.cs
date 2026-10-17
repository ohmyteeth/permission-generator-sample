using Microsoft.AspNetCore.Authentication.Cookies;
using PermissionSample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        // APIなのでログイン画面にリダイレクトせず、ステータスコードをそのまま返す
        options.Events.OnRedirectToLogin = context => {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = context => {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

// [Permission] 属性から生成された拡張メソッドで、全ポリシーを一括登録する。
builder.Services.AddAuthorizationBuilder().AddPermissionPolicies();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
