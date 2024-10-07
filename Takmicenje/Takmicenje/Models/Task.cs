using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Takmicenje.Models
{
    public class Task
    {
        public int ID_Task;
        public string Title;
        public string Description;
        public int FK_Room;
    }
}
