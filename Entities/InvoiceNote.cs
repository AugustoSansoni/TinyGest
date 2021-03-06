//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Estro.TinyGest.Entities
{
    public partial class InvoiceNote
    {
        #region Primitive Properties
    
        public virtual int InvoiceNoteId
        {
            get;
            set;
        }
    
        public virtual System.DateTime CreationDate
        {
            get;
            set;
        }
    
        public virtual string Text
        {
            get;
            set;
        }
    
        public virtual int InvoiceId
        {
            get { return _invoiceId; }
            set
            {
                if (_invoiceId != value)
                {
                    if (Invoice != null && Invoice.InvoiceId != value)
                    {
                        Invoice = null;
                    }
                    _invoiceId = value;
                }
            }
        }
        private int _invoiceId;

        #endregion
        #region Navigation Properties
    
        public virtual Invoice Invoice
        {
            get { return _invoice; }
            set
            {
                if (!ReferenceEquals(_invoice, value))
                {
                    var previousValue = _invoice;
                    _invoice = value;
                    FixupInvoice(previousValue);
                }
            }
        }
        private Invoice _invoice;

        #endregion
        #region Association Fixup
    
        private void FixupInvoice(Invoice previousValue)
        {
            if (previousValue != null && previousValue.AdministrativeInvoiceNotes.Contains(this))
            {
                previousValue.AdministrativeInvoiceNotes.Remove(this);
            }
    
            if (Invoice != null)
            {
                if (!Invoice.AdministrativeInvoiceNotes.Contains(this))
                {
                    Invoice.AdministrativeInvoiceNotes.Add(this);
                }
                if (InvoiceId != Invoice.InvoiceId)
                {
                    InvoiceId = Invoice.InvoiceId;
                }
            }
        }

        #endregion
    }
}
