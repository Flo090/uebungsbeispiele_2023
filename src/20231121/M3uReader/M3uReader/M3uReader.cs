using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3uReader
{
    internal class M3uReader
    {
        private List<M3uObject> _m3uObjects;
        private const string EXTM3U = "#EXTM3U";
        private const string EXTINF = "#EXTINF:";

        public M3uReader()
        {
            _m3uObjects = new List<M3uObject>();
        }

        public List<M3uObject> GetM3uObjects()
        {
            return _m3uObjects;
        }

        public void ReadFile()           //string path)
        {
            string titel = string.Empty;
            string artist = string.Empty;
            int duration = 0;
            string path = string.Empty;
            string thumbnail = string.Empty;

            M3uObject myObject = null;

            using (StreamReader sr = new StreamReader("C:\\myCode\\Repos\\uebungsbeispiele_2023\\src\\20231121\\M3uReader\\M3uReader\\bin\\Debug\\NewPlaylist.m3u"))
            {
                if (sr.ReadLine() == EXTM3U)
                {
                    do
                    {
                        string line = sr.ReadLine();

                        if (line.Contains(EXTINF))
                        {
                            // "EXTINF: 191, Artist Name – Track Title␤
                            // Path
                            int pos = line.IndexOf(',', 0);
                            string substringDuration = line.Substring(EXTINF.Length, pos - EXTINF.Length);
                            duration = int.Parse(substringDuration);

                            //int pos2 = line.IndexOf('.', pos); Dateiendung
                            string substringArtistTitle = line.Substring(EXTINF.Length + substringDuration.Length + 1, line.IndexOf("-") - EXTINF.Length - substringDuration.Length - 2);
                            artist = substringArtistTitle;

                            substringArtistTitle = line.Substring(EXTINF.Length + substringDuration.Length + artist.Length + 4, line.Length - EXTINF.Length - substringDuration.Length - artist.Length - 4);
                            titel = substringArtistTitle;

                            path = sr.ReadLine();
                        }
                        myObject = new M3uObject(titel, artist, duration, path, thumbnail);
                        _m3uObjects.Add(myObject);
                    } while (!sr.EndOfStream) ;
                }
            }
        }

        public void WriteFile(List <M3uObject> myList)
        {
            using (StreamWriter wr = new StreamWriter("C:\\myCode\\Repos\\uebungsbeispiele_2023\\src\\20231121\\M3uReader\\M3uReader\\bin\\Debug\\output.m3u"))
            {
                wr.WriteLine(EXTM3U);
                
                foreach (M3uObject obj in myList)
                {
                    wr.WriteLine(EXTINF + obj.Duration + "," + obj.Artist + "-" + obj.Titel);
                    wr.WriteLine(obj.Path);
                }
            }
        }
    }
}
