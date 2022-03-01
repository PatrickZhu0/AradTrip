using System;

namespace GameClient
{
	// Token: 0x020001FA RID: 506
	public class TestGameFrame : GameFrame
	{
		// Token: 0x0600102E RID: 4142 RVA: 0x00054A84 File Offset: 0x00052E84
		protected override void OnOpenFrame()
		{
			base.AddDelayCall(5f, delegate
			{
			});
			base.AddIntervalCall(delegate
			{
			}, 1f, float.MaxValue, 0f);
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00054AED File Offset: 0x00052EED
		protected override void OnCloseFrame()
		{
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x00054AEF File Offset: 0x00052EEF
		protected override void OnBindUIEvent()
		{
			base.BindUIEvent(EUIEventID.Invalid, null);
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x00054AF9 File Offset: 0x00052EF9
		protected override void OnUnBindUIEvent()
		{
			base.UnBindUIEvent(EUIEventID.Invalid, null);
		}
	}
}
