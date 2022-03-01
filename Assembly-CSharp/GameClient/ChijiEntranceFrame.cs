using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001107 RID: 4359
	public class ChijiEntranceFrame : ClientFrame
	{
		// Token: 0x0600A538 RID: 42296 RVA: 0x002216D2 File Offset: 0x0021FAD2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiEntranceFrame";
		}

		// Token: 0x0600A539 RID: 42297 RVA: 0x002216D9 File Offset: 0x0021FAD9
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
		}

		// Token: 0x0600A53A RID: 42298 RVA: 0x002216E1 File Offset: 0x0021FAE1
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x0600A53B RID: 42299 RVA: 0x002216EC File Offset: 0x0021FAEC
		protected override void _bindExUI()
		{
			this.mHelp = this.mBind.GetCom<Button>("Help");
			if (null != this.mHelp)
			{
				this.mHelp.onClick.AddListener(new UnityAction(this._onHelpButtonClick));
			}
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mGo = this.mBind.GetCom<Button>("Go");
			if (null != this.mGo)
			{
				this.mGo.onClick.AddListener(new UnityAction(this._onGoButtonClick));
			}
		}

		// Token: 0x0600A53C RID: 42300 RVA: 0x002217C4 File Offset: 0x0021FBC4
		protected override void _unbindExUI()
		{
			if (null != this.mHelp)
			{
				this.mHelp.onClick.RemoveListener(new UnityAction(this._onHelpButtonClick));
			}
			this.mHelp = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			if (null != this.mGo)
			{
				this.mGo.onClick.RemoveListener(new UnityAction(this._onGoButtonClick));
			}
			this.mGo = null;
		}

		// Token: 0x0600A53D RID: 42301 RVA: 0x0022186D File Offset: 0x0021FC6D
		private void _onHelpButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiHelpFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600A53E RID: 42302 RVA: 0x00221881 File Offset: 0x0021FC81
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiEntranceFrame>(this, false);
		}

		// Token: 0x0600A53F RID: 42303 RVA: 0x00221890 File Offset: 0x0021FC90
		private void _onGoButtonClick()
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Chiji_has_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<ChijiDataManager>.GetInstance().SwitchingTownToPrepare = true;
			Utility.SwitchToChijiWaittingRoom();
		}

		// Token: 0x04005C36 RID: 23606
		private Button mHelp;

		// Token: 0x04005C37 RID: 23607
		private Button mClose;

		// Token: 0x04005C38 RID: 23608
		private Button mGo;
	}
}
