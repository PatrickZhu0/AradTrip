using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010D1 RID: 4305
	public class GoblinKingdomFrame : ClientFrame
	{
		// Token: 0x0600A2D3 RID: 41683 RVA: 0x00214AC8 File Offset: 0x00212EC8
		protected override void _bindExUI()
		{
			this.mTime = this.mBind.GetCom<Text>("Time");
			this.mNum = this.mBind.GetCom<Text>("Num");
			this.mRoom2 = this.mBind.GetCom<RectTransform>("Room2");
			this.mRoom1 = this.mBind.GetCom<RectTransform>("Room1");
			this.time = this.mBind.GetCom<Text>("time");
		}

		// Token: 0x0600A2D4 RID: 41684 RVA: 0x00214B43 File Offset: 0x00212F43
		protected override void _unbindExUI()
		{
			this.mTime = null;
			this.mNum = null;
			this.mRoom2 = null;
		}

		// Token: 0x0600A2D5 RID: 41685 RVA: 0x00214B5A File Offset: 0x00212F5A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/GoblinKingdomFrame";
		}

		// Token: 0x0600A2D6 RID: 41686 RVA: 0x00214B61 File Offset: 0x00212F61
		protected override void _OnOpenFrame()
		{
			this.mRoom2.gameObject.CustomActive(true);
		}

		// Token: 0x0600A2D7 RID: 41687 RVA: 0x00214B74 File Offset: 0x00212F74
		public void SetRoom()
		{
			this.mRoom1.gameObject.SetActive(true);
			this.mRoom2.gameObject.CustomActive(false);
		}

		// Token: 0x0600A2D8 RID: 41688 RVA: 0x00214B98 File Offset: 0x00212F98
		public void SetTime(string text)
		{
			if (this.time == null)
			{
				return;
			}
			this.time.text = text;
		}

		// Token: 0x0600A2D9 RID: 41689 RVA: 0x00214BB8 File Offset: 0x00212FB8
		public void SetTimeText(string text)
		{
			if (this.mTime == null)
			{
				return;
			}
			this.mTime.text = text;
		}

		// Token: 0x0600A2DA RID: 41690 RVA: 0x00214BD8 File Offset: 0x00212FD8
		public void SetNumText(string text)
		{
			if (this.mTime == null)
			{
				return;
			}
			this.mNum.text = text;
		}

		// Token: 0x04005AC0 RID: 23232
		private Text mTime;

		// Token: 0x04005AC1 RID: 23233
		private Text mNum;

		// Token: 0x04005AC2 RID: 23234
		private RectTransform mRoom2;

		// Token: 0x04005AC3 RID: 23235
		private RectTransform mRoom1;

		// Token: 0x04005AC4 RID: 23236
		private Text time;
	}
}
