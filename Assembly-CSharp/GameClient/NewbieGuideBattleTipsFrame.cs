using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001025 RID: 4133
	public class NewbieGuideBattleTipsFrame : ClientFrame
	{
		// Token: 0x06009C81 RID: 40065 RVA: 0x001E9561 File Offset: 0x001E7961
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/BattleTip";
		}

		// Token: 0x06009C82 RID: 40066 RVA: 0x001E9568 File Offset: 0x001E7968
		protected override void _bindExUI()
		{
			this.mText = this.mBind.GetCom<Text>("Text");
			this.delayCallTime = Convert.ToInt32(this.mBind.GetPrefabPath("delayCloseTime"));
		}

		// Token: 0x06009C83 RID: 40067 RVA: 0x001E959B File Offset: 0x001E799B
		protected override void _unbindExUI()
		{
			this.mText = null;
		}

		// Token: 0x06009C84 RID: 40068 RVA: 0x001E95A4 File Offset: 0x001E79A4
		public void SetTipsText(string text)
		{
			if (this.mText != null)
			{
				this.mText.text = text;
			}
		}

		// Token: 0x06009C85 RID: 40069 RVA: 0x001E95C3 File Offset: 0x001E79C3
		protected override void _OnOpenFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(this.delayCallTime, delegate
			{
				this.Close();
			}, 0, 0, false);
		}

		// Token: 0x06009C86 RID: 40070 RVA: 0x001E95EA File Offset: 0x001E79EA
		public void Close()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<NewbieGuideBattleTipsFrame>(this, false);
		}

		// Token: 0x040055EF RID: 21999
		private Text mText;

		// Token: 0x040055F0 RID: 22000
		private int delayCallTime;
	}
}
