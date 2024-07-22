using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UserRole : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; }
}
