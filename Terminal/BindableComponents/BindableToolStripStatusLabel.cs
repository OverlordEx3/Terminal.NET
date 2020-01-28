using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal.BindableComponents
{
    class BindableToolStripStatusLabel : ToolStripStatusLabel, IBindableComponent
    {
        private ControlBindingsCollection controlBindings;
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (controlBindings == null)
                {
                    controlBindings = new ControlBindingsCollection(this);
                }

                return controlBindings;
            }
        }

        private BindingContext context;
        public BindingContext BindingContext
        {
            get
            {
                if (context == null)
                {
                    context = new BindingContext();
                }
                return context;
            }
            set { context = value; }
        }
    }
}
