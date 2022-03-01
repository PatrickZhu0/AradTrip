using System;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016B5 RID: 5813
	internal class EquipSealFrame : ClientFrame
	{
		// Token: 0x0600E3E8 RID: 58344 RVA: 0x003AE126 File Offset: 0x003AC526
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/EquipSeal/EquipSeal";
		}

		// Token: 0x0600E3E9 RID: 58345 RVA: 0x003AE130 File Offset: 0x003AC530
		protected override void _OnOpenFrame()
		{
			EquipSealData equipSealData = this.userData as EquipSealData;
			if (equipSealData == null)
			{
				Logger.LogError("open EquipSealFrame, userdata is invalid!!");
				return;
			}
			ComItem comItem = base.CreateComItem(this.m_itemRoot);
			if (comItem != null)
			{
				comItem.Setup(equipSealData.item, null);
			}
			this.m_itemName.text = equipSealData.item.GetColorName(string.Empty, false);
			ComItem comItem2 = base.CreateComItem(this.m_materialRoot);
			if (comItem2 != null)
			{
				comItem2.Setup(equipSealData.material, null);
			}
			this.m_materialDesc.text = TR.Value("equip_seal_cost", equipSealData.material.Count, equipSealData.material.GetColorName(string.Empty, false));
			this.m_item = equipSealData.item;
		}

		// Token: 0x0600E3EA RID: 58346 RVA: 0x003AE204 File Offset: 0x003AC604
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600E3EB RID: 58347 RVA: 0x003AE208 File Offset: 0x003AC608
		[UIEventHandle("Seal")]
		private void _OnSealClicked()
		{
			if (this.m_item != null)
			{
				SceneSealEquipReq sceneSealEquipReq = new SceneSealEquipReq();
				sceneSealEquipReq.uid = this.m_item.GUID;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneSealEquipReq>(ServerType.GATE_SERVER, sceneSealEquipReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneSealEquipRet>(delegate(SceneSealEquipRet msgRet)
				{
					this.frameMgr.CloseFrame<EquipSealFrame>(this, false);
					if (msgRet.code != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.code, string.Empty);
					}
					else
					{
						ClientFrame.OpenTargetFrame<CommonGetItemFrame>(FrameLayer.Middle, new CommonGetItemData
						{
							title = "Effects/Common/Textures/Ui/tx_ui_fzcg",
							itemClickCallback = null
						});
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600E3EC RID: 58348 RVA: 0x003AE264 File Offset: 0x003AC664
		[UIEventHandle("Cancel")]
		private void _OnCancelClicked()
		{
			this.frameMgr.CloseFrame<EquipSealFrame>(this, false);
		}

		// Token: 0x040088E7 RID: 35047
		[UIObject("Item/ItemRoot")]
		private GameObject m_itemRoot;

		// Token: 0x040088E8 RID: 35048
		[UIControl("Item/Text", null, 0)]
		private Text m_itemName;

		// Token: 0x040088E9 RID: 35049
		[UIObject("Material/Item")]
		private GameObject m_materialRoot;

		// Token: 0x040088EA RID: 35050
		[UIControl("Material/Desc", null, 0)]
		private Text m_materialDesc;

		// Token: 0x040088EB RID: 35051
		private ItemData m_item;
	}
}
