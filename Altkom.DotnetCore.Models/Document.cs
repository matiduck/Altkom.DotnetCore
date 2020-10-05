using System;

namespace Altkom.DotnetCore.Models
{
    class Document : BaseEntity
    {
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
