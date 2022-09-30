using System;
using System.Linq;
using Wcf.Client.BookServiceReference;

namespace Wcf.Client
{
	public class BookRepository : IBookRepository
	{
		public void AddBook(Book book)
		{
			try
			{
				if (book == null) return;
				BookServiceClient client = new BookServiceClient();
				var ret = client.AddBook(book.ToEntityObject());
				client.Close();
			}
			catch (Exception ex)
			{
				return;
			}
		}

		public void DeleteAll()
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.DeleteAll();
				client.Close();
				return;
			}
			catch (Exception ex)
			{
				return;
			}
		}

		public void DeleteBook(long id)
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.DeleteBook(id);
				client.Close();
				return;
			}
			catch (Exception ex)
			{
				return;
			}
		}

		public Books GetAllBook()
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.GetAllBook();
				client.Close();
				if (ret.Data == null) return null;
				var books = ret.Data.Select(x => x.ToDomainObject()).ToList();
				return Books.FromEnumerable(books);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public Book GetBookById(long id)
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.GetBookById(id);
				client.Close();
				if (ret.Data == null) return null;
				return ret.Data.ToDomainObject();
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public Book GetBookByISBN(string isbn)
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.GetBookByISBN(isbn);
				client.Close();
				if (ret.Data == null) return null;
				return ret.Data.ToDomainObject();
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public bool Ping()
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.Ping();
				client.Close();
				return ret.Result;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}

}
