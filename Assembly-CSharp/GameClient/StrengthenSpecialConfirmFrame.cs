using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B94 RID: 7060
	internal class StrengthenSpecialConfirmFrame : ClientFrame
	{
		// Token: 0x06011533 RID: 70963 RVA: 0x005022A1 File Offset: 0x005006A1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/StrengthenSpecialConfirm";
		}

		// Token: 0x06011534 RID: 70964 RVA: 0x005022A8 File Offset: 0x005006A8
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as StrengthenSpecialConfirmFrameData);
			this.title = Utility.FindComponent<Text>(this.frame, "Text", true);
			this.btnOk = Utility.FindComponent<Button>(this.frame, "ok", true);
			this.goParent = Utility.FindChild(this.frame, "middle/body/Viewport/content");
			this.goPrefab = Utility.FindChild(this.goParent, "prefabs");
			this.goPrefab.CustomActive(true);
			this.comItem = base.CreateComItem(Utility.FindChild(this.goPrefab, "itemParent"));
			this.comItem.Setup(null, null);
			this.name = Utility.FindComponent<Text>(this.goPrefab, "name", true);
			this.desc = Utility.FindComponent<Text>(this.frame, "image/hintUsed", true);
			this._SetData();
		}

		// Token: 0x06011535 RID: 70965 RVA: 0x0050238C File Offset: 0x0050078C
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

		// Token: 0x06011536 RID: 70966 RVA: 0x005023E3 File Offset: 0x005007E3
		private void OnItemClicked(GameObject obj, ItemData item)
		{
		}

		// Token: 0x06011537 RID: 70967 RVA: 0x005023E8 File Offset: 0x005007E8
		private void _SetData()
		{
			if (this.m_kData != null && this.m_kData.itemData != null && this.m_kData.equipData != null)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_kData.itemData.TableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_RANDOM_SHARPEN)
				{
					if (this.m_kData.equipData.EquipType == EEquipType.ET_REDMARK)
					{
						int num = 0;
						int num2 = 0;
						DataManager<EquipGrowthDataManager>.GetInstance().GetStrengthLevelIntervalValue(tableItem.ID, ref num, ref num2);
						this.title.text = string.Format(TR.Value("growth_sp_con_title2"), num, num2);
						this.desc.text = TR.Value("growth_desc");
					}
				}
				else if (tableItem.SubType == ItemTable.eSubType.ST_STRENTH_LUCK)
				{
					if (this.m_kData.equipData.EquipType == EEquipType.ET_COMMON)
					{
						OneStrengEnhanceTicketTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<OneStrengEnhanceTicketTable>(tableItem.ID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							this.title.text = string.Format(TR.Value("strengthen_sp_con_title"), float.Parse(tableItem2.desc) * 100f, this.m_kData.equipData.StrengthenLevel + 1);
							this.desc.text = TR.Value("strength_luck_desc");
						}
					}
				}
				else
				{
					StrengthenTicketTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(tableItem.StrenTicketDataIndex, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						if (this.m_kData.equipData.EquipType == EEquipType.ET_COMMON)
						{
							this.title.text = string.Format(TR.Value("strengthen_sp_con_title"), float.Parse(tableItem3.desc) * 100f, tableItem3.Level);
							this.desc.text = TR.Value("strength_desc");
						}
						else if (this.m_kData.equipData.EquipType == EEquipType.ET_REDMARK)
						{
							this.title.text = string.Format(TR.Value("growth_sp_con_title"), float.Parse(tableItem3.desc) * 100f, tableItem3.Level);
							this.desc.text = TR.Value("growth_desc");
						}
					}
				}
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.m_kData.itemData.TableID);
				this.comItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.OnItemClicked));
				if (commonItemTableDataByID != null)
				{
					this.name.text = commonItemTableDataByID.GetColorName(string.Empty, false);
				}
			}
		}

		// Token: 0x06011538 RID: 70968 RVA: 0x005026BC File Offset: 0x00500ABC
		[UIEventHandle("ok")]
		private void OnClickOk()
		{
			this.btnOk.enabled = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSpecailStrenghthenStart, null, null, null, null);
			this.frameMgr.CloseFrame<StrengthenSpecialConfirmFrame>(this, false);
		}

		// Token: 0x06011539 RID: 70969 RVA: 0x005026EA File Offset: 0x00500AEA
		[UIEventHandle("close/image")]
		private void OnClickClose()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSpecailStrenghthenCanceled, null, null, null, null);
			this.frameMgr.CloseFrame<StrengthenSpecialConfirmFrame>(this, false);
		}

		// Token: 0x0400B34F RID: 45903
		private StrengthenSpecialConfirmFrameData m_kData;

		// Token: 0x0400B350 RID: 45904
		private Text title;

		// Token: 0x0400B351 RID: 45905
		private ComItem comItem;

		// Token: 0x0400B352 RID: 45906
		private Text name;

		// Token: 0x0400B353 RID: 45907
		private Button btnOk;

		// Token: 0x0400B354 RID: 45908
		private GameObject goParent;

		// Token: 0x0400B355 RID: 45909
		private GameObject goPrefab;

		// Token: 0x0400B356 RID: 45910
		private Text desc;
	}
}
