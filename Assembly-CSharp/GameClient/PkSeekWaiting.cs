using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200199A RID: 6554
	internal class PkSeekWaiting : ClientFrame
	{
		// Token: 0x0600FF28 RID: 65320 RVA: 0x0046A28B File Offset: 0x0046868B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/Seek";
		}

		// Token: 0x0600FF29 RID: 65321 RVA: 0x0046A292 File Offset: 0x00468692
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as PkSeekWaitingData);
			this.InitInterface();
			this.BindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600FF2A RID: 65322 RVA: 0x0046A2C4 File Offset: 0x004686C4
		protected override void _OnCloseFrame()
		{
			this.ShowTime = 0f;
			this.time = 0f;
			this.m_kData = null;
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
		}

		// Token: 0x0600FF2B RID: 65323 RVA: 0x0046A2FC File Offset: 0x004686FC
		protected void BindUIEvent()
		{
		}

		// Token: 0x0600FF2C RID: 65324 RVA: 0x0046A2FE File Offset: 0x004686FE
		protected void UnBindUIEvent()
		{
		}

		// Token: 0x0600FF2D RID: 65325 RVA: 0x0046A300 File Offset: 0x00468700
		private void InitInterface()
		{
		}

		// Token: 0x0600FF2E RID: 65326 RVA: 0x0046A302 File Offset: 0x00468702
		public void SetEstimateTime(string content)
		{
			this.EstimateTime.text = content;
		}

		// Token: 0x0600FF2F RID: 65327 RVA: 0x0046A310 File Offset: 0x00468710
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FF30 RID: 65328 RVA: 0x0046A314 File Offset: 0x00468714
		protected override void _OnUpdate(float timeElapsed)
		{
			this.time += timeElapsed;
			if (this.time < 1f)
			{
				return;
			}
			this.ShowTime += this.time;
			if (this.m_kData != null)
			{
				if (this.m_kData.roomtype == PkRoomType.TraditionPk || this.m_kData.roomtype == PkRoomType.Pk3v3 || this.m_kData.roomtype == PkRoomType.Pk3v3Cross || this.m_kData.roomtype == PkRoomType.Pk2v2Cross)
				{
					this.countDownText.text = string.Format("匹配中...({0})", Function.GetLastsTimeStr((double)this.ShowTime));
				}
				else
				{
					this.countDownText.text = ((int)this.ShowTime).ToString();
				}
			}
			this.time = 0f;
		}

		// Token: 0x0400A0F0 RID: 41200
		protected PlayerInfo playerInfo = ClientApplication.playerinfo;

		// Token: 0x0400A0F1 RID: 41201
		private PkSeekWaitingData m_kData;

		// Token: 0x0400A0F2 RID: 41202
		private float ShowTime;

		// Token: 0x0400A0F3 RID: 41203
		private float time;

		// Token: 0x0400A0F4 RID: 41204
		[UIControl("CountDown", null, 0)]
		protected Text countDownText;

		// Token: 0x0400A0F5 RID: 41205
		[UIControl("Text", null, 0)]
		protected Text EstimateTime;

		// Token: 0x0200199B RID: 6555
		// (Invoke) Token: 0x0600FF32 RID: 65330
		public delegate void OnClickCancel();
	}
}
