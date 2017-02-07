using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSortCentrAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int NumericFirstParam { get; set; }
        public int NumericSecondParam { get; set; }
        public int NumericThirdParam { get; set; }
        public string StringFirstParam { get; set; }
        public string StringSecondParam { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ListOfPicturesNames { get; set; }
    }
}