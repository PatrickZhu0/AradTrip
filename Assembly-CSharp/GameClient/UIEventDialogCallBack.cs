using System;

namespace GameClient
{
	// Token: 0x02000FBF RID: 4031
	internal class UIEventDialogCallBack : UIEvent
	{
		// Token: 0x06009AE1 RID: 39649 RVA: 0x001DF1F2 File Offset: 0x001DD5F2
		public UIEventDialogCallBack(TaskDialogFrame.OnDialogOver callback)
		{
			this.callback = callback;
			this.EventID = EUIEventID.DlgCallBack;
			this.IsUsing = true;
		}

		// Token: 0x04005071 RID: 20593
		public TaskDialogFrame.OnDialogOver callback;
	}
}
