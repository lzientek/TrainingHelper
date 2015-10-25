using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PostSharp.Aspects;

namespace TrainingHelper.PcClient.Common
{
    [Serializable]
    public class LoadingMethod : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Mouse.SetCursor(Cursors.Wait);
            base.OnEntry(args);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            MessageBox.Show(args.Exception.Message,"Error");
            base.OnException(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Mouse.SetCursor(Cursors.AppStarting);

            base.OnExit(args);
        }
    }
}
