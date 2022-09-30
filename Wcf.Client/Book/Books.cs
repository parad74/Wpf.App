using System.Collections.ObjectModel;

namespace Wcf.Client
{
	public class Books : ObservableCollection<Book>
	{
		public static Books FromEnumerable(System.Collections.Generic.IEnumerable<Book> List)
		{
			Books books = new Books();
			foreach (Book item in List)
			{
				books.Add(item);
			}
			return books;
		}

		public Book CurrentItem { get; set; }

		public System.EventHandler CurrentChanged { get; set; }

		public long TotalCount { get; set; }
	}
}
