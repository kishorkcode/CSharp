using System;
using System.Threading;
using System.Windows.Threading;

namespace App
{
	class Program
	{
		private bool WaitForEvent(EventWaitHandle eventHandle, TimeSpan timeout)
        {
			var didWait = false;
			var frame = new DispatcherFrame();
			new Thread(() =>
			{
				didWait = eventHandle.WaitOne(timeout);
				frame.Continue = false;
			}).Start();
			Dispatcher.PushFrame(frame);
			return didWait;
        }
	}
}