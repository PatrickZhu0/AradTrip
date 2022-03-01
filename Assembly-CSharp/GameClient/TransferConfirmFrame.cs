using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B96 RID: 7062
	internal class TransferConfirmFrame : ClientFrame
	{
		// Token: 0x0601153C RID: 70972 RVA: 0x0050271C File Offset: 0x00500B1C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/EquipTransferConfirm";
		}

		// Token: 0x0601153D RID: 70973 RVA: 0x00502724 File Offset: 0x00500B24
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as TransferConfirmFrameData);
			this.title = Utility.FindComponent<Text>(this.frame, "Text", true);
			this.btnOk = Utility.FindComponent<Button>(this.frame, "ok", true);
			this.goParent = Utility.FindChild(this.frame, "middle/body/Viewport/content");
			this.goPrefab = Utility.FindChild(this.goParent, "prefabs");
			this.goPrefab.CustomActive(true);
			this.comItem = base.CreateComItem(Utility.FindChild(this.goPrefab, "itemParent"));
			this.comItem.Setup(null, null);
			this.name = Utility.FindComponent<Text>(this.goPrefab, "name", true);
			this._SetData();
		}

		// Token: 0x0601153E RID: 70974 RVA: 0x005027F0 File Offset: 0x00500BF0
		protected override void _OnCloseFrame()
		{
			this.m_kData = null;
			this.title = null;
			this.comItem.Setup(null, null);
			this.name = null;
			if (this.btnOk != null)
			{
				this.btnOk.onClick.RemoveAllListeners();
				this.btnOk = null;
			}
		}

		// Token: 0x0601153F RID: 70975 RVA: 0x00502847 File Offset: 0x00500C47
		private void OnItemClicked(GameObject obj, ItemData item)
		{
		}

		// Token: 0x06011540 RID: 70976 RVA: 0x0050284C File Offset: 0x00500C4C
		private void _SetData()
		{
			if (this.m_kData != null && this.m_kData.data != null)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.m_kData.data.TableID);
				this.comItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.OnItemClicked));
				if (commonItemTableDataByID != null)
				{
					this.name.text = commonItemTableDataByID.GetColorName(string.Empty, false);
				}
			}
		}

		// Token: 0x06011541 RID: 70977 RVA: 0x005028C4 File Offset: 0x00500CC4
		[UIEventHandle("ok")]
		private void OnClickOk()
		{
			this.btnOk.enabled = false;
			this.frameMgr.CloseFrame<TransferConfirmFrame>(this, false);
			if (this.m_kData != null)
			{
				if (this.m_kData.onOk != null)
				{
					this.m_kData.onOk.Invoke(this.m_kData.item, this.m_kData.data);
				}
				this.m_kData.item = null;
				this.m_kData.data = null;
				this.m_kData.onOk = null;
				this.m_kData = null;
			}
		}

		// Token: 0x06011542 RID: 70978 RVA: 0x00502956 File Offset: 0x00500D56
		[UIEventHandle("close/image")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<TransferConfirmFrame>(this, false);
		}

		// Token: 0x0400B35A RID: 45914
		private TransferConfirmFrameData m_kData;

		// Token: 0x0400B35B RID: 45915
		private Text title;

		// Token: 0x0400B35C RID: 45916
		private ComItem comItem;

		// Token: 0x0400B35D RID: 45917
		private Text name;

		// Token: 0x0400B35E RID: 45918
		private Button btnOk;

		// Token: 0x0400B35F RID: 45919
		private GameObject goParent;

		// Token: 0x0400B360 RID: 45920
		private GameObject goPrefab;
	}
}
