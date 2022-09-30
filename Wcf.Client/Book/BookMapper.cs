using System;
using System.Collections;
using System.Windows.Media.Imaging;
using Wpf.Client;

namespace Wcf.Client
{
	public static class BookMapper
	{
		public static Wcf.Client.Book ToDomainObject(this Wcf.Client.BookServiceReference.Book entity)
		{
			if (entity == null)
				return null;
			BitmapImage image = null;
			if (entity.FrontPage != null && entity.FrontPage.Length > 0)
			{
				image = UtilsImage.ImageFromBuffer(entity.FrontPage);
			}
			return new Book()
			{
				Id = entity.ID,
				ISBN = entity.ISBN,
				Title = entity.Title,
				Author = entity.Author,
				Year = entity.Year,
				Image = image,
				Description = entity.Description
			};

		}

		public static Wcf.Client.BookServiceReference.Book ToEntityObject(this Wcf.Client.Book domainObject)
		{
			if (domainObject == null)
				return null;
			byte[] frontPage = null;
			if (domainObject.Image != null)
			{
				frontPage = UtilsImage.ImageToByte(domainObject.Image);
			}
			return new Wcf.Client.BookServiceReference.Book()
			{
				ID = domainObject.Id,
				ISBN = domainObject.ISBN,
				Title = domainObject.Title,
				Author = domainObject.Author,
				Year = domainObject.Year,
				Description = domainObject.Description,
				FrontPage = frontPage

			};

		}
	}

}
