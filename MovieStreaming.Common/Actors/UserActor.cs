﻿using System;
using Akka.Actor;
using MovieStreaming.Common.Messages;

namespace MovieStreaming.Common.Actors
{
    public class UserActor : ReceiveActor
    {
        private readonly int _userId;
        private string _currentlyWatching;

        public UserActor(int userId)
        {
            _userId = userId;
            Stopped();
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(
                message => ColorConsole.WriteLineRed(
                    "Error: cannot start playing another movie before stopping existing one"));

            Receive<StopMovieMessage>(message => StopPlayingCurrentMovie());

            ColorConsole.WriteLineCyan("UserActor has now become Playing");
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message => StartPlayingMovie(message.MovieTitle));

            Receive<StopMovieMessage>(
                message => ColorConsole.WriteLineRed("Error: cannot stop if nothing is playing"));

            ColorConsole.WriteLineCyan("UserActor has now become Stopped");
        }
        

        private void StartPlayingMovie(string movieTitle)
        {
            _currentlyWatching = movieTitle;

            ColorConsole.WriteLineYellow(String.Format("User is currently watching '{0}'", _currentlyWatching));

            Context.ActorSelection("/user/Playback/PlaybackStatistics/MoviePlayCounter")
                .Tell(new IncrementPlayCountMessage(movieTitle));

            Become(Playing);
        }
        
        private void StopPlayingCurrentMovie()
        {
            ColorConsole.WriteLineYellow(String.Format("User has stopped watching '{0}'", _currentlyWatching));

            _currentlyWatching = null;

            Become(Stopped);
        }

        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("UserActor PreStart");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("UserActor PostStop");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("UserActor PreRestart because: " + reason);

            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("UserActor PostRestart because: " + reason);

            base.PostRestart(reason);
        }
    }
}
