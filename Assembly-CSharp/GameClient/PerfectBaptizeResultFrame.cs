using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015B7 RID: 5559
	public class PerfectBaptizeResultFrame : ClientFrame
	{
		// Token: 0x0600D954 RID: 55636 RVA: 0x00367544 File Offset: 0x00365944
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/PerfectBaptizeResultFrame";
		}

		// Token: 0x0600D955 RID: 55637 RVA: 0x0036754C File Offset: 0x0036594C
		protected override void _bindExUI()
		{
			this.mItemRoot = this.mBind.GetGameObject("itemRoot");
			this.mItemName = this.mBind.GetCom<Text>("itemName");
			this.mOK = this.mBind.GetCom<Button>("OK");
			this.mOK.onClick.AddListener(new UnityAction(this._onOKButtonClick));
		}

		// Token: 0x0600D956 RID: 55638 RVA: 0x003675B7 File Offset: 0x003659B7
		protected override void _unbindExUI()
		{
			this.mItemRoot = null;
			this.mItemName = null;
			this.mOK.onClick.RemoveListener(new UnityAction(this._onOKButtonClick));
			this.mOK = null;
		}

		// Token: 0x0600D957 RID: 55639 RVA: 0x003675EA File Offset: 0x003659EA
		private void _onOKButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<PerfectBaptizeResultFrame>(this, false);
		}

		// Token: 0x0600D958 RID: 55640 RVA: 0x003675F8 File Offset: 0x003659F8
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

		// Token: 0x04007FCC RID: 32716
		private GameObject mItemRoot;

		// Token: 0x04007FCD RID: 32717
		private Text mItemName;

		// Token: 0x04007FCE RID: 32718
		private Button mOK;
	}
}
