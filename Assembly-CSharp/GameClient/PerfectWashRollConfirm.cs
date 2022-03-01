using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B71 RID: 7025
	internal class PerfectWashRollConfirm : ClientFrame
	{
		// Token: 0x06011371 RID: 70513 RVA: 0x004F431E File Offset: 0x004F271E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/PerfectWashRollConfirm";
		}

		// Token: 0x06011372 RID: 70514 RVA: 0x004F4328 File Offset: 0x004F2728
		protected override void _OnOpenFrame()
		{
			this.m_perfectScrollsID = int.Parse(TR.Value("ItemKeyPerfectScrollsID"));
			this.goParent = Utility.FindChild(this.frame, "middle/body/Viewport/content");
			this.goPrefab = Utility.FindChild(this.goParent, "prefabs");
			this.goPrefab.CustomActive(true);
			this.comItem = base.CreateComItem(Utility.FindChild(this.goPrefab, "itemParent"));
			this.comItem.Setup(null, null);
			this.name = Utility.FindComponent<Text>(this.goPrefab, "name", true);
			this._SetData();
		}

		// Token: 0x06011373 RID: 70515 RVA: 0x004F43C8 File Offset: 0x004F27C8
		protected override void _OnCloseFrame()
		{
			this.comItem.Setup(null, null);
			this.name = null;
		}

		// Token: 0x06011374 RID: 70516 RVA: 0x004F43DE File Offset: 0x004F27DE
		private void OnItemClicked(GameObject obj, ItemData item)
		{
		}

		// Token: 0x06011375 RID: 70517 RVA: 0x004F43E0 File Offset: 0x004F27E0
		private void _SetData()
		{
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.m_perfectScrollsID);
			this.comItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.OnItemClicked));
			if (commonItemTableDataByID != null)
			{
				this.name.text = commonItemTableDataByID.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x06011376 RID: 70518 RVA: 0x004F4433 File Offset: 0x004F2833
		[UIEventHandle("ok")]
		private void OnClickOk()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUsePerfectWashRoll, null, null, null, null);
			this.frameMgr.CloseFrame<PerfectWashRollConfirm>(this, false);
		}

		// Token: 0x06011377 RID: 70519 RVA: 0x004F4455 File Offset: 0x004F2855
		[UIEventHandle("close/image")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<PerfectWashRollConfirm>(this, false);
		}

		// Token: 0x0400B1C5 RID: 45509
		private int m_perfectScrollsID;

		// Token: 0x0400B1C6 RID: 45510
		private ComItem comItem;

		// Token: 0x0400B1C7 RID: 45511
		private Text name;

		// Token: 0x0400B1C8 RID: 45512
		private GameObject goParent;

		// Token: 0x0400B1C9 RID: 45513
		private GameObject goPrefab;
	}
}
