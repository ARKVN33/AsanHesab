//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class viewIncomeInfo
    {
        public int Id { get; set; }
        public Nullable<int> IncomeCategory_Id { get; set; }
        public Nullable<int> BankAccont_Id { get; set; }
        public string IncomeDate { get; set; }
        public string IncomeTime { get; set; }
        public Nullable<long> Amount { get; set; }
        public string ReceiptNumber { get; set; }
        public string IncomeDescription { get; set; }
        public byte PaymentId { get; set; }
        public string BankName { get; set; }
        public string Category { get; set; }
    }
}
