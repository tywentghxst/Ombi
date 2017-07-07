﻿using System;
using System.Collections.Generic;
using Ombi.Store.Entities.Requests;

namespace Ombi.Notifications
{
    public class NotificationMessageCurlys
    { 

        public void Setup(FullBaseRequest req)
        {
            RequestedUser = string.IsNullOrEmpty(req.RequestedUser.Alias)
                ? req.RequestedUser.Username
                : req.RequestedUser.Alias;
            Title = req.Title;
            RequestedDate = req.RequestedDate.ToString("D");
            Type = req.RequestType.ToString();
            Overview = req.Overview;
            Year = req.ReleaseDate.Year.ToString();
            PosterImage = req.PosterPath;
        }

        public void Setup(ChildRequests req)
        {
            RequestedUser = string.IsNullOrEmpty(req.RequestedUser.Alias)
                ? req.RequestedUser.Username
                : req.RequestedUser.Alias;
            Title = req.ParentRequest.Title;
            RequestedDate = req.RequestedDate.ToString("D");
            Type = req.RequestType.ToString();
            Overview = req.ParentRequest.Overview;
            Year = req.ParentRequest.ReleaseDate.Year.ToString();
            PosterImage = req.ParentRequest.PosterPath;
            // DO Episode and Season Lists
        }
        
        // User Defined
        public string RequestedUser { get; set; }
        public string Title { get; set; }
        public string RequestedDate { get; set; }
        public string Type { get; set; }
        public string Issue { get; set; }
        public string Overview { get; set; }
        public string Year { get; set; }
        public string EpisodesList { get; set; }
        public string SeasonsList { get; set; }
        public string PosterImage { get; set; }

        // System Defined
        private string LongDate => DateTime.Now.ToString("D");
        private string ShortDate => DateTime.Now.ToString("d");
        private string LongTime => DateTime.Now.ToString("T");
        private string ShortTime => DateTime.Now.ToString("t");

        public Dictionary<string, string> Curlys => new Dictionary<string, string>
        {
            {nameof(RequestedUser), RequestedUser },
            {nameof(Title), Title },
            {nameof(RequestedDate), RequestedDate },
            {nameof(Type), Type },
            {nameof(Issue), Issue },
            {nameof(LongDate),LongDate},
            {nameof(ShortDate),ShortDate},
            {nameof(LongTime),LongTime},
            {nameof(ShortTime),ShortTime},
            {nameof(Overview),Overview},
            {nameof(Year),Year},
            {nameof(EpisodesList),EpisodesList},
            {nameof(SeasonsList),SeasonsList},
            {nameof(PosterImage),PosterImage},
        };
    }
}