using System;
using Akka.Actor;
using MovieStreaming.Messages;

namespace MovieStreaming.Actors
{
    public class PlaybackActor : ReceiveActor
    {
        public PlaybackActor()
        {
            Console.WriteLine("Creating a PlaybackActor");
            Receive<PlayMovieMessage>(message => HandlePlayMovieMessage(message), message => message.UserId == 42);
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            Console.WriteLine("Received movie title " + message.MovieTitle);
            Console.WriteLine("Received user ID " + message.UserId);
        }
    }
}
