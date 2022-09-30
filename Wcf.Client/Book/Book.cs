using System.Windows.Media.Imaging;

namespace Wcf.Client
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public System.Byte[] FrontPage { get; set; }
		public BitmapImage Image { get; set; }

	public Book()
        {
			ISBN = "";
			Title = "";
			Author = "";
			Year = "";
			Description = "";
		}
  
    }

}


// https://stackoverflow.com/questions/4852558/how-to-save-image-to-a-database