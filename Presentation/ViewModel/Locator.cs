/*
  In App.xaml:
  <Application.Resources>
      <vm:MvvmViewModelLocator1 xmlns:vm="clr-namespace:Estro.TinyGest.Presentation.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
  
  OR (WPF only):
  
  xmlns:vm="clr-namespace:Estro.TinyGest.Presentation.ViewModel"
  DataContext="{Binding Source={x:Static vm:MvvmViewModelLocator1.ViewModelNameStatic}}"
*/

using System.Diagnostics.CodeAnalysis;
using Estro.TinyGest.Presentation.ViewModel.Invoice;
using Estro.TinyGest.Presentation.ViewModel.Customer;
using Estro.TinyGest.Presentation.ViewModel.Order;
using Estro.TinyGest.Presentation.ViewModel.Product;
namespace Estro.TinyGest.Presentation.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// Use the <strong>mvvmlocatorproperty</strong> snippet to add ViewModels
    /// to this locator.
    /// </para>
    /// <para>
    /// In Silverlight and WPF, place the MvvmViewModelLocator1 in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:MvvmViewModelLocator1 xmlns:vm="clr-namespace:Estro.TinyGest.Presentation.ViewModel"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// You can also use Blend to do all this with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// <para>
    /// In <strong>*WPF only*</strong> (and if databinding in Blend is not relevant), you can delete
    /// the ViewModelName property and bind to the ViewModelNameStatic property instead:
    /// </para>
    /// <code>
    /// xmlns:vm="clr-namespace:Estro.TinyGest.Presentation.ViewModel"
    /// DataContext="{Binding Source={x:Static vm:MvvmViewModelLocator1.ViewModelNameStatic}}"
    /// </code>
    /// </summary>
    public class Locator
    {
        private static InvoiceViewModel _invoice;
        private static InvoiceListViewModel _invoiceList;
        private static CustomerViewModel _customer;
        private static CustomerListViewModel _customerList;
        private static OrderViewModel _order;
        private static OrderListViewModel _orderList;
        private static ProductViewModel _product;
        private static ProductListViewModel _productList;        

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public Locator()
        {
           
        }

        public static InvoiceViewModel InvoiceStatic
        {
            get
            {
                if (_invoice == null)
                {
                    _invoice = new InvoiceViewModel();
                }

                return _invoice;
            }
        }

         [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public InvoiceViewModel Invoice
        {
            get { return Locator.InvoiceStatic; }
        }

         public static InvoiceListViewModel InvoiceListStatic
         {
             get
             {
                 if (_invoiceList == null)
                 {
                     _invoiceList = new InvoiceListViewModel();
                 }

                 return _invoiceList;
             }
         }

         [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
         public InvoiceListViewModel InvoiceList
         {
             get { return Locator.InvoiceListStatic; }
         }

         
        public static CustomerViewModel CustomerStatic
         {
             get
             {
                 if (_customer == null)
                 {
                     _customer = new CustomerViewModel();
                 }

                 return _customer;
             }
         }
         [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
         public CustomerViewModel Customer
         {
             get { return Locator.CustomerStatic; }
         }

         public static CustomerListViewModel CustomerListStatic
         {
             get
             {
                 if (_customerList == null)
                 {
                     _customerList = new CustomerListViewModel();
                 }

                 return _customerList;
             }
         }
         [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
         public CustomerListViewModel CustomerList
         {
             get { return Locator.CustomerListStatic; }
         }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            // Call ClearViewModelName() for each ViewModel.
        }
    }
}