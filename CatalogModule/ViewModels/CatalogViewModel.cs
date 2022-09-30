using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Linq;
using System.Windows.Input;
using Wcf.Client;
using Wpf.Module.Events;

namespace Wpf.Module.ViewModels
{
    public class CatalogViewModel : BindableBase
    {
        private Books _books;
        private IEventAggregator _eventAgreagator;
        private Book _currentBook;
        private bool? _isVisible = null;
		private bool _pong = false;
		private IBookRepository _bookRepository;

        public bool? IsVisible
        {
            get { return this._isVisible; }
            set { SetProperty(ref this._isVisible, value); }
        }

		public bool Pong
		{
			get { return this._pong; }
			set { SetProperty(ref this._pong, value); }
		}


		public Books Books
        {
            get { return this._books; }
            set { SetProperty(ref this._books, value); }
        }
        public Book CurrentBook
        {
            get { return this._currentBook; }
            set { SetProperty(ref this._currentBook, value); }
        }

        public ICommand RemoveCommand { get;  set; }
        public ICommand ClosePopupCommand { get; set; }

        public CatalogViewModel(IEventAggregator eventAggregator)
        {
			this._eventAgreagator = eventAggregator;
			this._bookRepository = Config.Configuration.Resolve<IBookRepository>();
			Pong = this._bookRepository.Ping();

			Books = this._bookRepository.GetAllBook();

            if(Books != null)
            {
				CurrentBook = Books.FirstOrDefault();
			}

			this.RemoveCommand = new DelegateCommand<long?>(Execute, CanExecute);
			this.ClosePopupCommand = new DelegateCommand(Close, CanClose);
            this._eventAgreagator.GetEvent<BookAddedEvent>().Subscribe(UpdateBooks);
        }
        
        private void UpdateBooks(Book book)
        {
            if (book != null)
            {
                this._bookRepository.AddBook(book);
            }
			this.Books = _bookRepository.GetAllBook();
        }

    
        private void Close()
        {
			this.IsVisible = !this.IsVisible;
        }

        private bool CanClose()
        {
            return true;
        }

        private void Execute(long? id)
        {
            if (id != null )
            {
                this._bookRepository.DeleteBook(id.Value);
				this.Books = this._bookRepository.GetAllBook();
			}
            else this.IsVisible = true;
        }

        private bool CanExecute(long? id)
        {
            return true;
        }
    }
}
