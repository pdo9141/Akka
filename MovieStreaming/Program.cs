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
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
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

            await MovieStreamingActorSystem.Terminate();
            //await MovieStreamingActorSystem.WhenTerminated;
            Console.WriteLine("Actor system shutdown");

            Console.ReadLine();
        }
    }
}
