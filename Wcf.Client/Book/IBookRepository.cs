using System.ServiceModel;

namespace Wcf.Client
{
	public interface IBookRepository
	{
		bool Ping();

		Books GetAllBook();

		Book GetBookByISBN(string isbn);

		Book GetBookById(long id);

		void AddBook(Book book);

		void DeleteBook(long id);

		void DeleteAll();
	}
}
