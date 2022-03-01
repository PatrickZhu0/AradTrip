using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015B6 RID: 5558
	public class EquipTransferResultFrame : ClientFrame
	{
		// Token: 0x0600D94E RID: 55630 RVA: 0x0036743B File Offset: 0x0036583B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/EquipTransferResultFrame";
		}

		// Token: 0x0600D94F RID: 55631 RVA: 0x00367444 File Offset: 0x00365844
		protected override void _bindExUI()
		{
			this.mItemRoot = this.mBind.GetGameObject("itemRoot");
			this.mItemName = this.mBind.GetCom<Text>("itemName");
			this.mOK = this.mBind.GetCom<Button>("OK");
			this.mOK.onClick.AddListener(new UnityAction(this._onOKButtonClick));
		}

		// Token: 0x0600D950 RID: 55632 RVA: 0x003674AF File Offset: 0x003658AF
		protected override void _unbindExUI()
		{
			this.mItemRoot = null;
			this.mItemName = null;
			this.mOK.onClick.RemoveListener(new UnityAction(this._onOKButtonClick));
			this.mOK = null;
		}

		// Token: 0x0600D951 RID: 55633 RVA: 0x003674E2 File Offset: 0x003658E2
		private void _onOKButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<EquipTransferResultFrame>(this, false);
		}

		// Token: 0x0600D952 RID: 55634 RVA: 0x003674F0 File Offset: 0x003658F0
		protected override void _OnOpenFrame()
		{
			ItemData itemData = this.userData as ItemData;
			if (itemData == null)
			{
				return;
			}
			ComItem comItem = base.CreateComItem(this.mItemRoot);
			comItem.Setup(itemData, null);
			this.mItemName.text = itemData.GetColorName(string.Empty, false);
		}

		// Token: 0x04007FC9 RID: 32713
		private GameObject mItemRoot;

		// Token: 0x04007FCA RID: 32714
		private Text mItemName;

		// Token: 0x04007FCB RID: 32715
		private Button mOK;
	}
}
