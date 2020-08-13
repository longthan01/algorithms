using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI.OOODesigns
{
    public class Jukebox
    {
        public CD CD { get; set; }
        public Queue<Song> Playlist { get; set; }
        public Display Monitor { get; set; }
        public bool IsRandomSong { get; set; }
        public Jukebox(CD cd)
        {
            this.CD = cd;
            foreach (var song in cd.GetAllSongs())
            {
                this.Playlist.Enqueue(song);
            }
        }
        public void Play(Song song)
        {
            // play
        }
        public void Shuffle()
        {

        }
        public Song GetNext()
        {
            int index = 0;
            if (IsRandomSong)
            {
                var random = new Random();
                index = random.Next(0, this.Playlist.Count - 1);
                return this.Playlist.ElementAt(index);
            }
            else
            {
                return this.Playlist.Dequeue();
            }
        }
    }

    public class Display
    {
        public void Show(Song s)
        {
            // show
        }
    }

    public class Song
    {
        public Artist SongArtist { get; set; }
        public string Name { get; set; }

        public class Artist
        {
            public string Name { get; set; }
        }
    }

    public class CD
    {
        public List<Song> GetAllSongs()
        {
            return new List<Song>()
            {
                new Song() { Name = "dkm.mp3" },
                new Song() { Name = "6234dfs.mp3" },
                new Song() { Name = "dk3242m.mp3" }
            };
        }
    }
}
