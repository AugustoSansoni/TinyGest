using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estro.TinyGest.Presentation
{
   using System.Windows.Input;

    /// <summary>
    /// This class holds the global commands used by the application
    /// </summary>
    public static class AppCommands
    {
        public static RoutedCommand AddNew = new RoutedUICommand("Add New Entry", "AddNew", typeof (AppCommands));
        public static RoutedCommand Clear = new RoutedUICommand("Mark Cleared", "Clear", typeof (AppCommands));
        public static RoutedCommand Delete = new RoutedUICommand("Delete", "Delete", typeof (AppCommands));
        public static RoutedCommand Copy = new RoutedUICommand("Copy", "Copy", typeof(AppCommands));
        public static RoutedCommand Paste = new RoutedUICommand("Paste", "Paste", typeof(AppCommands));
    }
    
}
