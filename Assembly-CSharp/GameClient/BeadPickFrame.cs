using System;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001ACD RID: 6861
	public class BeadPickFrame : ClientFrame
	{
		// Token: 0x06010D7D RID: 68989 RVA: 0x004CD6D6 File Offset: 0x004CBAD6
		protected sealed override void _bindExUI()
		{
			this.mBeadPickView = this.mBind.GetCom<BeadPickView>("BeadPickView");
		}

		// Token: 0x06010D7E RID: 68990 RVA: 0x004CD6EE File Offset: 0x004CBAEE
		protected sealed override void _unbindExUI()
		{
			this.mBeadPickView = null;
		}

		// Token: 0x06010D7F RID: 68991 RVA: 0x004CD6F7 File Offset: 0x004CBAF7
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/BeadPickFrame/BeadPickFrame";
		}

		// Token: 0x06010D80 RID: 68992 RVA: 0x004CD700 File Offset: 0x004CBB00
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.mDate = (this.userData as BeadPickModel);
			if (this.mDate == null)
			{
				return;
			}
			if (this.mBeadPickView != null)
			{
				this.mBeadPickView.Init(this.mDate, new UnityAction(this.OnCloseClick), new UnityAction(this.OnOkBtnClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSelectPickBeadExpendItem, new ClientEventSystem.UIEventHandler(this._OnSelectPickBeadExpendItem));
		}

		// Token: 0x06010D81 RID: 68993 RVA: 0x004CD785 File Offset: 0x004CBB85
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mDate = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSelectPickBeadExpendItem, new ClientEventSystem.UIEventHandler(this._OnSelectPickBeadExpendItem));
			this.pestleId = 0;
			this.mExpendItemSuccessRate = 0;
			this.mBeadRemainPickNumber = 0;
		}

		// Token: 0x06010D82 RID: 68994 RVA: 0x004CD7C4 File Offset: 0x004CBBC4
		private void _OnSelectPickBeadExpendItem(UIEvent iEvent)
		{
			this.pestleId = (int)iEvent.Param1;
			this.mExpendItemSuccessRate = (int)iEvent.Param2;
			this.mBeadRemainPickNumber = (int)iEvent.Param3;
		}

		// Token: 0x06010D83 RID: 68995 RVA: 0x004CD7F9 File Offset: 0x004CBBF9
		private void OnCloseClick()
		{
			this.frameMgr.CloseFrame<BeadPickFrame>(this, false);
		}

		// Token: 0x06010D84 RID: 68996 RVA: 0x004CD808 File Offset: 0x004CBC08
		private void OnOkBtnClick()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.pestleId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("BeadPickFrame_SelectExpand"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.ID) == null)
			{
				return;
			}
			int num = this.mExpendItemSuccessRate / 100;
			string msgContent = string.Empty;
			if (num < 100)
			{
				msgContent = TR.Value("bead_pick_des", TR.Value("Bead_red_color"), num);
			}
			else
			{
				msgContent = TR.Value("bead_pick_des", TR.Value("Bead_Green_color"), num);
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<BeadCardManager>.GetInstance().SendSceneExtirpePreciousBeadReq((byte)this.mDate.mPrecBead.index, this.mDate.mEquipItemData.GUID, (uint)this.pestleId);
			}, null, 0f, false);
		}

		// Token: 0x0400ACBD RID: 44221
		private BeadPickModel mDate;

		// Token: 0x0400ACBE RID: 44222
		private int pestleId;

		// Token: 0x0400ACBF RID: 44223
		private int mExpendItemSuccessRate;

		// Token: 0x0400ACC0 RID: 44224
		private int mBeadRemainPickNumber;

		// Token: 0x0400ACC1 RID: 44225
		protected const string mPrefabPath = "UIFlatten/Prefabs/SmithShop/BeadPickFrame/BeadPickFrame";

		// Token: 0x0400ACC2 RID: 44226
		private BeadPickView mBeadPickView;
	}
}
