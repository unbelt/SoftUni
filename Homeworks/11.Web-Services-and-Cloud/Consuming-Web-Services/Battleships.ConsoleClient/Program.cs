using System.Linq;
using System.Net.Http;

namespace Battleships.ConsoleClient
{
    using System;

    public class Program
    {
        private static HttpRequester requester = new HttpRequester("http://localhost:62858/api/");  // Change to your local port

        public static void Main()
        {
            Console.Write("Enter Command: ");
            Console.WriteLine(ExecuteCommand(Console.ReadLine()));

            /*try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }

        private static HttpResponseMessage ExecuteCommand(string input)
        {
            var commands = input.Split(null);
            switch (commands[0])
            {
                case "register":
                    return Register(commands[1], commands[2], commands[3]);
                case "login":
                    return Login(commands[1], commands[2]);
                case "create-game":
                    return CreateGame();
                case "join-game":
                    return JoinGame(commands[1]);
                case "play":
                    return Play(commands[1], int.Parse(commands[2]), int.Parse(commands[3]));
                default:
                    throw new ArgumentException("Invalid Command!");
            }
        }

        public static HttpResponseMessage Register(string username, string password, string passwordConfirm)
        {
            if (password != passwordConfirm)
            {
                throw new ArgumentException("The passwords does not match!");
            }

            var user = new
            {
                username,
                password
            };

            return requester.Post("account/register", user);
        }

        public static HttpResponseMessage Login(string username, string password)
        {
            var user = new
            {
                username,
                password
            };

            return requester.Post("account/login", user);
        }

        public static HttpResponseMessage CreateGame()
        {
            return requester.Post("games/create", null);
        }

        public static HttpResponseMessage JoinGame(string gameId)
        {
            return requester.Post("games/join", gameId);
        }

        public static HttpResponseMessage Play(string gameId, int positionX, int positionY)
        {
            var playTurn = new
            {
                gameId,
                positionX,
                positionY
            };

            return requester.Post("games/play", playTurn);
        }
    }
}
