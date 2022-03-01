using System;
using GameClient;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001AB3 RID: 6835
internal class AdjustResultFrame : ClientFrame
{
	// Token: 0x06010CC2 RID: 68802 RVA: 0x004C9B43 File Offset: 0x004C7F43
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/SmithShop/AdjustResultFrameEx";
	}

	// Token: 0x06010CC3 RID: 68803 RVA: 0x004C9B4C File Offset: 0x004C7F4C
	[UIEventHandle("ok")]
	private void OnClickOk()
	{
		if (this.data != null && this.data.callback != null)
		{
			this.data.callback.Invoke();
		}
		if (this.mOkBtn != null)
		{
			this.mOkBtn.enabled = false;
			InvokeMethod.Invoke(this, 1f, delegate()
			{
				if (this.mOkBtn != null)
				{
					this.mOkBtn.enabled = true;
				}
			});
		}
		this.frameMgr.CloseFrame<AdjustResultFrame>(this, false);
	}

	// Token: 0x06010CC4 RID: 68804 RVA: 0x004C9BC5 File Offset: 0x004C7FC5
	protected override void _OnOpenFrame()
	{
		this.m_kDesc = Utility.FindComponent<Text>(this.frame, "middle/Text", true);
		this.data = (this.userData as AdjustResultFrame.AdjustResultFrameData);
		this.m_kDesc.text = this.data.desc;
	}

	// Token: 0x06010CC5 RID: 68805 RVA: 0x004C9C05 File Offset: 0x004C8005
	protected override void _OnCloseFrame()
	{
	}

	// Token: 0x06010CC6 RID: 68806 RVA: 0x004C9C07 File Offset: 0x004C8007
	[UIEventHandle("close")]
	private void OnClickClose()
	{
		this.frameMgr.CloseFrame<AdjustResultFrame>(this, false);
	}

	// Token: 0x0400AC2B RID: 44075
	private AdjustResultFrame.AdjustResultFrameData data;

	// Token: 0x0400AC2C RID: 44076
	private Text m_kDesc;

	// Token: 0x0400AC2D RID: 44077
	[UIControl("ok", typeof(Button), 0)]
	private Button mOkBtn;

	// Token: 0x02001AB4 RID: 6836
	public class AdjustResultFrameData
	{
		// Token: 0x0400AC2E RID: 44078
		public string desc;

		// Token: 0x0400AC2F RID: 44079
		public UnityAction callback;
	}
}
