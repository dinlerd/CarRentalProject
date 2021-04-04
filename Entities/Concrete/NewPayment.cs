using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class NewPayment : IEntity
    {
        public int NewPaymentId { get; set; }
        public int RentalId { get; set; }
        public string NameSurname { get; set; }
        public string CardNo { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvc { get; set; }
        public string PaymentDate { get; set; }
    }
}
