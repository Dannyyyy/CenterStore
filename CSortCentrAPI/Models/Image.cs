using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSortCentrAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public bool IsIdentified { get; set; }
    }
}