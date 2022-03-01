using System;

namespace GameClient
{
	// Token: 0x02000FB8 RID: 4024
	internal class UIClientFrameEvent : UIEvent
	{
		// Token: 0x06009ADA RID: 39642 RVA: 0x001DF1D5 File Offset: 0x001DD5D5
		public UIClientFrameEvent(EUIEventID eventID, UIClientFrameEvent.OnCallBack callback)
		{
			this.callback = callback;
			this.EventID = eventID;
			this.IsUsing = true;
		}

		// Token: 0x04005058 RID: 20568
		public UIClientFrameEvent.OnCallBack callback;

		// Token: 0x02000FB9 RID: 4025
		// (Invoke) Token: 0x06009ADC RID: 39644
		public delegate void OnCallBack(IClientFrame frame);
	}
}
