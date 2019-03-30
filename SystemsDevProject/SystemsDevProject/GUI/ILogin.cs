using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemsDevProject.GUI
{
    public interface ILogin
    {
        void UpdateLoggedInUserName();
        void UpdateEnabledProperty(bool enabled);
    }
}
