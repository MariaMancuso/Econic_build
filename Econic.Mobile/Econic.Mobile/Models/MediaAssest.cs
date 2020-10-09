using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Econic.Mobile.Models
{
    public class MediaAssest
    {
        public enum MediaAssetType
        {
            Image, Video
        }


        public string Id { get; set; }
        public string Name { get; set; }
        public MediaAssetType Type { get; set; }
        public string PreviewPath { get; set; }
        public string Path { get; set; }
        public bool IsSelectable { get; set; }
        public Frame frame { get; set; }
    }
}
