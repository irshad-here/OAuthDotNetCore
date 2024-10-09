using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;

var builder = WebApplication.CreateBuilder(args);

// Adds MVC support to the application (using controllers and views).
builder.Services.AddControllersWithViews();

// Configures authentication options for the application.
builder.Services.AddAuthentication(options =>
{
    // Specifies the default authentication scheme for managing user sessions (cookies).
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    // Specifies the default challenge scheme (used for external login via Microsoft).
    options.DefaultChallengeScheme = MicrosoftAccountDefaults.AuthenticationScheme;
})
// Configures cookie-based authentication to store the user's session.
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true; // Makes the cookie inaccessible to client-side JavaScript (helps prevent XSS attacks).
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensures cookies are only sent over HTTPS.
        options.Cookie.SameSite = SameSiteMode.Lax; // Prevents CSRF attacks by limiting how cookies are sent on cross-site requests.
        options.SlidingExpiration = true; // Automatically renews cookie expiration if the user is actively using the site.
    })
// Configures Microsoft OAuth authentication for external login.
    .AddMicrosoftAccount(microsoftOptions =>
    {
        // The Client ID and Client Secret are required for Microsoft OAuth (replace with actual values).
        microsoftOptions.ClientId = "***"; // Replace with your actual Microsoft client ID.
        microsoftOptions.ClientSecret = "***"; // Replace with your actual Microsoft client secret.
        microsoftOptions.CallbackPath = "/signin-microsoft"; // The callback URL that Microsoft redirects to after login.
    });

var app = builder.Build();

// In non-development environments, use the Developer Exception Page to show detailed error information.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Redirects all HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Serves static files (like CSS, JS, and images) from the wwwroot folder.
app.UseStaticFiles();

// Enables routing for the application.
app.UseRouting();

// Activates the authentication system, allowing the app to validate user identity.
app.UseAuthentication();

// Activates the authorization system, ensuring users have the necessary permissions to access resources.
app.UseAuthorization();

// Defines the default route for the app (HomeController and Index action as the default page).
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Runs the application.
app.Run();
