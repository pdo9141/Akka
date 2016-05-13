using System;
using System.Threading.Tasks;
using Akka.Actor;
using MovieStreaming.Actors;
using MovieStreaming.Messages;

namespace MovieStreaming
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;

        static void Main(string[] args)
        {
            AsyncMain().Wait();
        }

        private static async Task AsyncMain()
        {
            ColorConsole.WriteLineGray("Creating MovieStreamingActorSystem");
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");

            ColorConsole.WriteLineGray("Creating actor supervisory hierarchy");
            MovieStreamingActorSystem.ActorOf(Props.Create<PlaybackActor>(), "Playback");

            do
            {
                ShortPause();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                ColorConsole.WriteLineGray("enter a command and hit enter");

                var command = Console.ReadLine();

                if (command.StartsWith("play"))
                {
                    int userId = int.Parse(command.Split(',')[1]);
                    string movieTitle = command.Split(',')[2];

                    var message = new PlayMovieMessage(movieTitle, userId);
                    MovieStreamingActorSystem.ActorSelection("/user/Playback/UserCoordinator").Tell(message);
                }

                if (command.StartsWith("stop"))
                {
                    int userId = int.Parse(command.Split(',')[1]);

                    var message = new StopMovieMessage(userId);
                    MovieStreamingActorSystem.ActorSelection("/user/Playback/UserCoordinator").Tell(message);
                }

                if (command.StartsWith("exit"))
                {
                    await MovieStreamingActorSystem.Terminate();
                    ColorConsole.WriteLineGray("Actor system shutdown");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            } while (true);
            
            /*
            Console.WriteLine("Actor system created");

            Props userActorProps = Props.Create<UserActor>();
            IActorRef userActorRef = MovieStreamingActorSystem.ActorOf(userActorProps, "UserActor");

            Console.ReadKey();
            Console.WriteLine("Sending a PlayMovieMessage (Codenan the Destroyer)");
            userActorRef.Tell(new PlayMovieMessage("Codenan the Destroyer", 42));

            Console.ReadKey();
            Console.WriteLine("Sending another PlayMovieMessage (Boolean Lies)");
            userActorRef.Tell(new PlayMovieMessage("Boolean Lies", 42));

            Console.ReadKey();
            Console.WriteLine("Sending a StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());

            Console.ReadKey();
            Console.WriteLine("Sending another StopMovieMessage");
            userActorRef.Tell(new StopMovieMessage());

            Console.ReadKey();
            */

            /*
            Props playbackActorProps = Props.Create<PlaybackActor>();

            IActorRef playbackActorRef = MovieStreamingActorSystem.ActorOf(playbackActorProps, "PlaybackActor");
            playbackActorRef.Tell(new PlayMovieMessage("Akka.NET: The Movie", 42));
            playbackActorRef.Tell(new PlayMovieMessage("Partial Recall", 99));
            playbackActorRef.Tell(new PlayMovieMessage("Boolean Lies", 77));
            playbackActorRef.Tell(new PlayMovieMessage("Codenan the Destroyer", 1));

            playbackActorRef.Tell(PoisonPill.Instance);

            Console.ReadLine();
            */

            /*
            await MovieStreamingActorSystem.Terminate();
            //await MovieStreamingActorSystem.WhenTerminated;
            Console.WriteLine("Actor system shutdown");

            Console.ReadLine();
            */
        }

        private static void ShortPause()
        {
            System.Threading.Thread.Sleep(3000);
        }
    }
}
