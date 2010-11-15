using System.Collections.Generic;
using models=Estro.TinyGest.Entities;
using System.Collections.ObjectModel;
using Caliburn.Micro;


namespace Estro.TinyGest.Presentation.ViewModel.Invoice
{
    
    public class InvoiceListViewModel : Screen
    {
        private models.Invoice _selectedInvoice;
        /// <summary>
        /// Initializes a new instance of the InvoiceListViewModel class.
        /// </summary>
        public InvoiceListViewModel()
        {
           
        }

        public IEnumerable<models.Invoice> Invoices { get; set; }
        public ObservableCollection<models.Invoice> SelectedInvoices { get; set; }
        public models.Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                if (_selectedInvoice != value)
                {
                    _selectedInvoice = value;
                    NotifyOfPropertyChange(() => SelectedInvoice);
                    //Messenger.Default.Send<models.Invoice, InvoiceViewModel>(_selectedInvoice);
                }
            }
        }

        public string CustomerName { get; set; }
        public int Year            { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Order  { get; set; }        
    }
}