using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Faq : Entity<int>
{
    public string Question { get; set; }
    public string Answer { get; set; }
}
