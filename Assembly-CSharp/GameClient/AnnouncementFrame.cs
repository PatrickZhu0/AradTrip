using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001433 RID: 5171
	public class AnnouncementFrame : ClientFrame
	{
		// Token: 0x0600C8D1 RID: 51409 RVA: 0x0030D318 File Offset: 0x0030B718
		protected override void _OnOpenFrame()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				this.mAnnouncementframe.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -217f);
			}
			else
			{
				this.mAnnouncementframe.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -158f);
			}
			this.contentData = (AnnounceData)this.userData;
			this.mContent.SetText(this.contentData.content, true);
			this.mContent.gameObject.transform.localPosition = new Vector3(this.ShowAreaWidth / 2f, this.mContent.gameObject.transform.localPosition.y, this.mContent.gameObject.transform.localPosition.z);
			this.TextLength = this.mContent.LinkTextWidth;
		}

		// Token: 0x0600C8D2 RID: 51410 RVA: 0x0030D417 File Offset: 0x0030B817
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600C8D3 RID: 51411 RVA: 0x0030D41F File Offset: 0x0030B81F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/AnnouncementFrame";
		}

		// Token: 0x0600C8D4 RID: 51412 RVA: 0x0030D428 File Offset: 0x0030B828
		protected override void _OnLoadPrefabFinish()
		{
			ComClientFrame comClientFrame = this.mComClienFrame as ComClientFrame;
			if (null != comClientFrame)
			{
				comClientFrame.bInitWithGameBindSystem = false;
			}
		}

		// Token: 0x0600C8D5 RID: 51413 RVA: 0x0030D454 File Offset: 0x0030B854
		private void ClearData()
		{
			this.ShowAreaWidth = 880f;
			this.TextLength = 0f;
			this.rollSpeed = 120f;
			this.ResPlayEnd = null;
		}

		// Token: 0x0600C8D6 RID: 51414 RVA: 0x0030D47E File Offset: 0x0030B87E
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600C8D7 RID: 51415 RVA: 0x0030D484 File Offset: 0x0030B884
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.mContent == null)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			if (clientSystemTown == null && clientSystemBattle == null)
			{
				return;
			}
			if (this.mContent.transform.localPosition.x < -(this.ShowAreaWidth / 2f + this.TextLength) && this.ResPlayEnd != null)
			{
				this.ResPlayEnd();
				return;
			}
			this.mContent.transform.localPosition = new Vector3(this.mContent.transform.localPosition.x - this.rollSpeed * timeElapsed, this.mContent.transform.localPosition.y, this.mContent.transform.localPosition.z);
		}

		// Token: 0x0600C8D8 RID: 51416 RVA: 0x0030D580 File Offset: 0x0030B980
		protected override void _bindExUI()
		{
			this.mContent = this.mBind.GetCom<LinkParse>("Content");
			this.mAnnouncementframe = this.mBind.GetGameObject("Announcementframe");
		}

		// Token: 0x0600C8D9 RID: 51417 RVA: 0x0030D5AE File Offset: 0x0030B9AE
		protected override void _unbindExUI()
		{
			this.mContent = null;
			this.mAnnouncementframe = null;
		}

		// Token: 0x040073CF RID: 29647
		public AnnouncementFrame.PlayEnd ResPlayEnd;

		// Token: 0x040073D0 RID: 29648
		private float ShowAreaWidth = 880f;

		// Token: 0x040073D1 RID: 29649
		private float TextLength;

		// Token: 0x040073D2 RID: 29650
		private float rollSpeed = 120f;

		// Token: 0x040073D3 RID: 29651
		private AnnounceData contentData;

		// Token: 0x040073D4 RID: 29652
		private LinkParse mContent;

		// Token: 0x040073D5 RID: 29653
		private GameObject mAnnouncementframe;

		// Token: 0x02001434 RID: 5172
		// (Invoke) Token: 0x0600C8DB RID: 51419
		public delegate void PlayEnd();
	}
}
