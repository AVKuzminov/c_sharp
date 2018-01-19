using MusicDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicDemo.UI
{
	class Program
    {
		static void PrintSongs(IEnumerable<SongViewModel> songs)
		{
			Console.WriteLine("{0,-20}{1,-15}{2,-15} {3}", "Song", "Artist", "Album", "Duration");
			foreach (var song in songs)
			{
				Console.WriteLine("{0,-20}{1,-15}{2,-15} {3}:{4:D2}",
					song.Name, song.Artist, song.Album, song.Duration / 60, song.Duration % 60);
			}
		}

		static void Main(string[] args)
        {
			List<SongViewModel> songs;
            using (var c = new Context())
            {
				// c.Database.Log += Console.WriteLine;

				// Load all data into a list
				songs = c.Songs.Select(s => new SongViewModel
				{
					Name = s.Name,
					Album = s.Album.Name,
					Artist = s.Album.Artist.Name,
					Duration = s.Duration
				}).ToList();
            }
			PrintSongs(songs);
			Console.ReadKey();
        }
    }
}
