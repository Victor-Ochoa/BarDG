using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Base
{
    public abstract class Entity: Notifiable
    {
        public virtual int Id { get; set; }

    }
}
