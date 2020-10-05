using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotnetCore.Models
{
    public abstract class Base
    {
    }

    public abstract class BaseEntity : Base
    {
        public Guid Id { get; set; }
    }
}
