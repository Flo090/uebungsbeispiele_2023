using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3uReader
{
    internal class M3uObject
    {
        private string _titel;
        private string _artist;
        private int _duration;
        private string _path;
        private string _thumbnail;

        public M3uObject(string titel, string artist, int duration, string path, string thumbnail)
        {
            _titel = titel;
            _artist = artist;
            _duration = duration;
            _path = path;
            _thumbnail = thumbnail;
        }

        public string Titel
        {
            get { return _titel; }
        }
        public string Artist
        {
            get { return _artist; }
        }
        public int Duration
        {
            get { return _duration; }
        }
        public string Path
        {
            get { return _path; }
        }
        public string Thumbnail
        {
            get { return _thumbnail; }
        }
    }
}
