using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000FDF RID: 4063
	internal class WaitNetMessageFrame : ClientFrame
	{
		// Token: 0x06009B4E RID: 39758 RVA: 0x001E1167 File Offset: 0x001DF567
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x06009B4F RID: 39759 RVA: 0x001E116C File Offset: 0x001DF56C
		protected override void _OnOpenFrame()
		{
			if (this.m_content == null)
			{
				this.m_content = this.mBind.GetGameObject("root");
			}
			this.m_content.SetActive(false);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_delayCallUnit);
			this.m_delayCallUnit = Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(1500, new DelayCaller.Del(this._ShowContent), 0, 0, false);
			WaitNetMessageFrame.ms_count = 0;
			this._OnReopenFrame(null);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WaitMessageReopen, new ClientEventSystem.UIEventHandler(this._OnReopenFrame));
		}

		// Token: 0x06009B50 RID: 39760 RVA: 0x001E1212 File Offset: 0x001DF612
		protected override void _OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_delayCallUnit);
			WaitNetMessageFrame.ms_count = 0;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WaitMessageReopen, new ClientEventSystem.UIEventHandler(this._OnReopenFrame));
		}

		// Token: 0x06009B51 RID: 39761 RVA: 0x001E124A File Offset: 0x001DF64A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/WaitingConnectFrame";
		}

		// Token: 0x06009B52 RID: 39762 RVA: 0x001E1251 File Offset: 0x001DF651
		private void _OnReopenFrame(UIEvent a_event)
		{
			if (this.frame != null)
			{
				this.frame.transform.SetAsFirstSibling();
			}
		}

		// Token: 0x06009B53 RID: 39763 RVA: 0x001E1274 File Offset: 0x001DF674
		public static void TryOpen()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<WaitNetMessageFrame>(null))
			{
				if (WaitNetMessageFrame.ms_count > 0)
				{
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<WaitNetMessageFrame>(FrameLayer.TopMost, null, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WaitMessageReopen, null, null, null, null);
			}
			WaitNetMessageFrame.ms_count++;
		}

		// Token: 0x06009B54 RID: 39764 RVA: 0x001E12D2 File Offset: 0x001DF6D2
		public static void TryClose()
		{
			WaitNetMessageFrame.ms_count--;
			if (WaitNetMessageFrame.ms_count <= 0)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<WaitNetMessageFrame>(null, false);
			}
		}

		// Token: 0x06009B55 RID: 39765 RVA: 0x001E12F7 File Offset: 0x001DF6F7
		private void _ShowContent()
		{
			if (null != this.m_content)
			{
				this.m_content.SetActive(true);
			}
		}

		// Token: 0x040054C8 RID: 21704
		private GameObject m_content;

		// Token: 0x040054C9 RID: 21705
		private DelayCallUnitHandle m_delayCallUnit;

		// Token: 0x040054CA RID: 21706
		private static int ms_count;
	}
}
