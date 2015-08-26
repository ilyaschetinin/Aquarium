using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Aquarium.Utils
{
	public static class FormExtensions
	{
		static public void UIThread(this Form form, MethodInvoker code)
		{
			if (form.InvokeRequired)
			{
				form.BeginInvoke(code);
			}
			else
			{
				code.Invoke();
			}
		}
	}
}
