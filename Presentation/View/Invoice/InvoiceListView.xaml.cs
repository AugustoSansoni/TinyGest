using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Estro.TinyGest.Presentation.ViewModel.Invoice;
using models = Estro.TinyGest.Entities;

namespace Estro.TinyGest.Presentation.View.Invoice
{
    /// <summary>
    /// Interaction logic for InvoiceListView.xaml
    /// </summary>
    public partial class InvoiceListView : UserControl
    {
        public InvoiceListView()
        {
            InitializeComponent();
        }

        private InvoiceListViewModel ViewModel { get { return DataContext as InvoiceListViewModel; } }


        private void ListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (models.Invoice invoice in e.RemovedItems)
            {
                ViewModel.SelectedInvoices.Remove(invoice);
            }
            foreach (models.Invoice invoice in e.AddedItems)
            {
                ViewModel.SelectedInvoices.Add(invoice);
            }
        }
    }
}
