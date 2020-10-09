using System;
using System.Collections.Generic;
using System.Text;

namespace Econic.Mobile.Models
{
    public class MediaEventArgs
    {
        public MediaAssest Media { get; }
        public MediaEventArgs(MediaAssest media)
        {
            Media = media;
        }
    }
}
