## Summary
The project is a simple ASP.NET Core MVC application that integrates Microsoft OAuth for user authentication. The app allows users to sign in using their Microsoft accounts, leveraging Azure Active Directory (Azure AD) for authentication. Once logged in, the user is authenticated and managed via cookie-based sessions.


## Microsoft OAuth Setup

**1. Azure AD Registration**
- Register the application in **Azure Active Directory (Azure AD)**.
- Generate the **Client ID** and **Client Secret** during the registration process.
- Add a **Redirect URI** (e.g., `https://localhost:<port number as shown in launchSettings.json>/signin-microsoft`) that handles authentication responses after login.

**2. Configure OAuth in ASP.NET Core**
- Set up **Microsoft OAuth** in the ASP.NET Core project by using the **Client ID** and **Client Secret** from Azure AD.
- Configure **cookie-based authentication** to manage user sessions securely.
- Ensure the callback path in the application matches the **Redirect URI** in Azure AD.

**3. AccountController Setup**
- Create an **AccountController** to handle authentication:
  - The **Login** method redirects users to the Microsoft login page for authentication.
  - The **Logout** method signs the user out and clears the session cookie.

**4. Running the Application**
- Run the application and use the provided login functionality to authenticate users via their Microsoft accounts.
- After logging in, users are redirected back to the app, and their session is authenticated.
