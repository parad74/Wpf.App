using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Net.NetworkInformation;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Wcf.Client;
using Wpf.Module.Events;

namespace Wpf.Module.ViewModels
{
	public class BookAddViewModel : BindableBase
    {
		private string _buttonName;
		private bool _pong = false;

		private string _isbn;
		private string _title;
		private string _author;
		private string _year;
        private string _description;
	
        private bool _isVisible;
        private IBookRepository _bookRepository;
        private IEventAggregator _eventAggregator;
        public ICommand OpenDialogCommand { get; private set; }
		public ICommand CreateCommand { get; private set; }
		public ICommand CancelCommand { get; private set; }
		public BookAddViewModel(IEventAggregator eventAggregator)
        {
			this.ButtonName = "Добавить книгу";
			this._eventAggregator = eventAggregator;
            this._bookRepository = Config.Configuration.Resolve<IBookRepository>();
			this.CreateCommand = new DelegateCommand(CreateBook, CanCreateBook);
			this.OpenDialogCommand = new DelegateCommand(OpendDialog);
			this.CancelCommand = new DelegateCommand(Cancel);
			this._bookRepository = Config.Configuration.Resolve<IBookRepository>();
			this.Pong = this._bookRepository.Ping();
			if (this.Pong == false) this.ButtonName = "WCF cервис не запущен";
		}

		public string ButtonName
		{
			get { return _buttonName; }
			set { SetProperty(ref _buttonName, value); }
		}

		public bool Pong
		{
			get { return this._pong; }
			set { SetProperty(ref this._pong, value); }
		}
		public string ISBN
		{
			get { return _isbn; }
			set { SetProperty(ref _isbn, value); }
		}


		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}
		public string Author
		{
			get { return _author; }
			set { SetProperty(ref _author, value); }
		}

		public string Year
		{
			get { return _year; }
			set { SetProperty(ref _year, value); }
		}
		public string Description
		{
			get { return _description; }
			set { SetProperty(ref _description, value); }
		}


		public bool IsVisible
		{
			get { return _isVisible; }
			set { SetProperty(ref _isVisible, value); }
		}

		private void Cancel()
        {
			ISBN = "";
			Title = "";
			Author = "";
			Year = "";
			Description = "";
			IsVisible = false;
			this._eventAggregator.GetEvent<BookAddedEvent>().Publish(null);
		}

        private void OpendDialog()
        {
            IsVisible = true;
        }

        private bool CanCreateBook()
        {
			this.Pong = this._bookRepository.Ping();
			return this.Pong;
        }

        private void CreateBook()             
        {
            if (string.IsNullOrWhiteSpace(Title) == false  )
            {
                var newBook = new Book();
				newBook.ISBN = ISBN;
				newBook.Title = Title;
				newBook.Author = Author;
				newBook.Year = Year;
				newBook.Description = Description;
				BitmapImage img = new BitmapImage();
				img.BeginInit();
				img.UriSource = new Uri(@"pack://application:,,,/Wpf.App;component/Icons/book.png");
				img.EndInit();
				newBook.Image = img;

				this._eventAggregator.GetEvent<BookAddedEvent>().Publish(newBook);
			}
			else
			{
				this._eventAggregator.GetEvent<BookAddedEvent>().Publish(null);
			}
			
			ISBN = "";
			Title = "";
			Author = "";
			Year = "";
			Description = "";
			IsVisible = false;
		}


    }
}


