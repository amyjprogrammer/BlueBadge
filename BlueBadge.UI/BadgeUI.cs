using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBadge.UI
{
    public class BadgeUI
    {
        //great docs for HttpClient
        //https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-5.0
        static readonly HttpClient client = new HttpClient();

        private static string _token; //need to store this token for later

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;


            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine
                    (
                        "Welcome to Off the Poll\n" +
                        "****************************************************************\n\n" +
                        "1. Login\n" +
                        "2. Register\n" +
                        "3. Exit"
                    );
                PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter the number of your selection: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nPlease enter a valid number between 1-3");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        break;
                }
            }
        }
        //I think this needs to be an async call from the research (same for Register)
        private static async Task Login()//token request in Postman
        {
            Console.Clear();
            var login = new Dictionary<string, string> { { "grant_type", "password" } };

            Console.WriteLine("Logging in\n" +
                        "****************************************************************\n\n");
            PrintColorMessage(ConsoleColor.Yellow, "Please enter your email: ");
            login.Add("Username", Console.ReadLine());

            PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter a password: ");
            login.Add("Password", Console.ReadLine());

            var httpClient = new HttpClient();

            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44386/token");
            tokenRequest.Content = new FormUrlEncodedContent(login.AsEnumerable());
            var response = await httpClient.SendAsync(tokenRequest);
            var tokenInfo = await response.Content.ReadAsStringAsync();

            //when token is returned it has muliple data points including access_token
            var token = JsonConvert.DeserializeObject<AccessToken>(tokenInfo).Token;
            _token = token;//storing this bad boy for later

            //headers- Authorization shows up in Postman
            tokenRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (response.IsSuccessStatusCode)
                PrintColorMessage(ConsoleColor.Green, "\nYou are logged in.");
            else
                PrintColorMessage(ConsoleColor.DarkMagenta, "Login issue. Please try again.");
        }

        private static async Task Register()
        {
            Console.Clear();
            Console.WriteLine("Registering your account\n" +
                        "****************************************************************\n\n");
            PrintColorMessage(ConsoleColor.Yellow, "Please enter your email: ");

            //httprequestmessage = https://csharp.hotexamples.com/examples/-/HttpRequestMessage/-/php-httprequestmessage-class-examples.html
            //collecting the stuff from API and Postman- email, password and confirm password
            var registerUser = new Dictionary<string, string>
            {
                {"Email", Console.ReadLine() }
            };

            PrintColorMessage(ConsoleColor.Yellow, "\nPlease enter a password: ");
            registerUser.Add("Password", Console.ReadLine());

            PrintColorMessage(ConsoleColor.Yellow, "\nConfirm your password: ");
            registerUser.Add("ConfirmPassword", Console.ReadLine());

            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44386/api/Account/Register");//this is my local host
            request.Content = new FormUrlEncodedContent(registerUser.AsEnumerable());//like IEnumerable
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
                PrintColorMessage(ConsoleColor.Green, "\nYou have registered your account.  Please login.\n");
            else
                PrintColorMessage(ConsoleColor.DarkMagenta, "Something went wrong.  Please try to register again.");
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            //Change text color
            Console.ForegroundColor = color;
            //text
            Console.Write(message);
            //reset color
            Console.ResetColor();
        }

        //used just to get the access_token when returning the Json info
        public class AccessToken
        {
            [JsonProperty("access_token")]
            public string Token { get; set; }
        }
    }
}
