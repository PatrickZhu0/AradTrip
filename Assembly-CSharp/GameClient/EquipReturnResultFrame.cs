using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015CF RID: 5583
	internal class EquipReturnResultFrame : ClientFrame
	{
		// Token: 0x0600DAC1 RID: 56001 RVA: 0x00370A9A File Offset: 0x0036EE9A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipRecovery/EquipReturnResultFrame";
		}

		// Token: 0x0600DAC2 RID: 56002 RVA: 0x00370AA1 File Offset: 0x0036EEA1
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				this.frameMgr.CloseFrame<EquipReturnResultFrame>(this, false);
				return;
			}
			this.resultItem = (this.userData as EquipReturnResultItem);
			this._InitUI();
		}

		// Token: 0x0600DAC3 RID: 56003 RVA: 0x00370AD3 File Offset: 0x0036EED3
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0600DAC4 RID: 56004 RVA: 0x00370AD8 File Offset: 0x0036EED8
		private void _InitUI()
		{
			ComItem comItem = this.mItemRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.mItemRoot);
			}
			int result = this.resultItem.itemdata.TableID;
			comItem.Setup(this.resultItem.itemdata, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(result);
			});
			this.mItemScore.text = this.resultItem.Score.ToString();
			this.mName.text = this.resultItem.itemdata.Name;
		}

		// Token: 0x0600DAC5 RID: 56005 RVA: 0x00370B88 File Offset: 0x0036EF88
		private void _OnShowTips(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600DAC6 RID: 56006 RVA: 0x00370BB0 File Offset: 0x0036EFB0
		protected override void _bindExUI()
		{
			this.mItemRoot = this.mBind.GetGameObject("ItemRoot");
			this.mItemScore = this.mBind.GetCom<Text>("ItemScore");
			this.mOkBtn = this.mBind.GetCom<Button>("okBtn");
			if (null != this.mOkBtn)
			{
				this.mOkBtn.onClick.AddListener(new UnityAction(this._onOkBtnButtonClick));
			}
			this.mName = this.mBind.GetCom<Text>("name");
		}

		// Token: 0x0600DAC7 RID: 56007 RVA: 0x00370C44 File Offset: 0x0036F044
		protected override void _unbindExUI()
		{
			this.mItemRoot = null;
			this.mItemScore = null;
			if (null != this.mOkBtn)
			{
				this.mOkBtn.onClick.RemoveListener(new UnityAction(this._onOkBtnButtonClick));
			}
			this.mOkBtn = null;
			this.mName = null;
		}

		// Token: 0x0600DAC8 RID: 56008 RVA: 0x00370C9A File Offset: 0x0036F09A
		private void _onOkBtnButtonClick()
		{
			this.frameMgr.CloseFrame<EquipReturnResultFrame>(this, false);
		}

		// Token: 0x040080AF RID: 32943
		private EquipReturnResultItem resultItem = new EquipReturnResultItem();

		// Token: 0x040080B0 RID: 32944
		private GameObject mItemRoot;

		// Token: 0x040080B1 RID: 32945
		private Text mItemScore;

		// Token: 0x040080B2 RID: 32946
		private Button mOkBtn;

		// Token: 0x040080B3 RID: 32947
		private Text mName;
	}
}
