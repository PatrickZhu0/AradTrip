using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BAD RID: 7085
	internal class StrengthenConfirm : ClientFrame
	{
		// Token: 0x06011597 RID: 71063 RVA: 0x00504840 File Offset: 0x00502C40
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/StrengthenConfirm";
		}

		// Token: 0x06011598 RID: 71064 RVA: 0x00504848 File Offset: 0x00502C48
		protected sealed override void _OnOpenFrame()
		{
			this.isSelected = false;
			this.hintUsed = Utility.FindComponent<Text>(this.frame, "image/hintUsed", true);
			this.hintUnUsed = Utility.FindComponent<Text>(this.frame, "image/hintUnUsed", true);
			this.btnOk = Utility.FindComponent<Button>(this.frame, "Mode0/ok", true);
			this.btnOk.enabled = true;
			this.btnOk2 = Utility.FindComponent<Button>(this.frame, "Mode1/ok", true);
			this.btnOk2.enabled = true;
			this.goMode0 = Utility.FindChild(this.frame, "Mode0");
			this.goMode1 = Utility.FindChild(this.frame, "Mode1");
			this.okBtnText = Utility.FindComponent<Text>(this.frame, "Mode1/ok/Text", true);
			this.okBtnGray2 = Utility.FindComponent<UIGray>(this.frame, "Mode1/ok", true);
			if (this.okBtnText != null)
			{
				this.OkBtnOriginText = this.okBtnText.text;
			}
			this.m_data = (this.userData as StrengthenConfirmData);
			if (this.m_data == null)
			{
				Logger.LogError("StrengthenConfirm data is null!!");
				return;
			}
			this.bUseModeNormal = (this.m_data.ItemData.StrengthenLevel < 10 || this.m_data.UseProtect);
			this.goMode0.CustomActive(this.bUseModeNormal);
			this.goMode1.CustomActive(!this.bUseModeNormal);
			this.hintUsed.enabled = this.m_data.UseProtect;
			this.hintUnUsed.enabled = !this.m_data.UseProtect;
			StrengthenCost strengthenCost = default(StrengthenCost);
			if (!this.m_data.UseStrengthenImplement)
			{
				if (this.m_data.ItemData.EquipType == EEquipType.ET_COMMON)
				{
					bool cost = DataManager<StrengthenDataManager>.GetInstance().GetCost(this.m_data.ItemData.StrengthenLevel, this.m_data.ItemData.LevelLimit, this.m_data.ItemData.Quality, ref strengthenCost);
					ItemData itemData = this.m_data.ItemData;
					if (itemData.SubType == 1)
					{
						float num = 1f;
						SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(21, string.Empty, string.Empty);
						if (tableItem != null)
						{
							num = (float)tableItem.Value / 10f;
						}
						strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num);
						strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num);
						strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num);
					}
					else if (itemData.SubType >= 2 && itemData.SubType <= 6)
					{
						float num2 = 1f;
						SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(22, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							num2 = (float)tableItem2.Value / 10f;
						}
						strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num2);
						strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num2);
						strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num2);
					}
					else if (itemData.SubType >= 7 && itemData.SubType <= 9)
					{
						float num3 = 1f;
						SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(23, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							num3 = (float)tableItem3.Value / 10f;
						}
						strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num3);
						strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num3);
						strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num3);
					}
					if (!cost)
					{
						Logger.LogErrorFormat("StrengthenConfirm can not find strengthen cost!! ItemTableID:{0} ItemGUID:{1} StrengthenLevel:{2} EquipLevel:{3} Quality:{4}", new object[]
						{
							this.m_data.ItemData.TableID,
							this.m_data.ItemData.GUID,
							this.m_data.ItemData.StrengthenLevel,
							this.m_data.ItemData.LevelLimit,
							(int)this.m_data.ItemData.Quality
						});
						return;
					}
				}
			}
			Text component = Utility.FindGameObject(this.frame, "Text", true).GetComponent<Text>();
			if (this.m_data.ItemData.EquipType == EEquipType.ET_COMMON)
			{
				this.bIsUpdate = (this.m_data.ItemData.Quality > ItemTable.eColor.PURPLE && !this.bUseModeNormal);
				component.text = TR.Value("strengthen_level_desc", this.m_data.TargetStrengthenLevel + 1);
			}
			else if (this.m_data.ItemData.EquipType == EEquipType.ET_REDMARK)
			{
				this.bIsUpdate = !this.bUseModeNormal;
				component.text = TR.Value("growth_level_desc", this.m_data.TargetStrengthenLevel + 1);
				if (this.hintUsed != null)
				{
					this.hintUsed.text = TR.Value("growth_use_protectstamp_desc");
				}
				if (this.hintUnUsed != null)
				{
					this.hintUnUsed.text = TR.Value("growth_unuse_protectstamp_desc");
				}
			}
			if (this.bIsUpdate)
			{
				SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(683, string.Empty, string.Empty);
				this.fCountDownTime = (float)tableItem4.Value;
				this._SetOkButtonEnabe(false);
			}
			Text component2 = Utility.FindGameObject(this.frame, "middle/nick/hint", true).GetComponent<Text>();
			if (this.m_data.UseProtect)
			{
				component2.text = TR.Value("strengthen_cost_hint_use_protect");
			}
			else if (this.m_data.ItemData.StrengthenLevel + 1 <= 10)
			{
				component2.text = TR.Value("strengthen_cost_hint_neednot_protect");
			}
			else
			{
				component2.text = TR.Value("strengthen_cost_hint_unuse_protect");
			}
			List<StrengthenConfirm.ItemObject> list = new List<StrengthenConfirm.ItemObject>();
			list.Clear();
			if (this.m_data.UseStrengthenImplement)
			{
				if (this.m_data.StrengthenImplementItem != null)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = this.m_data.StrengthenImplementItem.TableID,
						count = 1
					});
				}
				if (this.m_data.ItemData.EquipType == EEquipType.ET_COMMON)
				{
					if (this.m_data.UseProtect)
					{
						list.Add(new StrengthenConfirm.ItemObject
						{
							id = 200000310,
							count = 1
						});
					}
				}
				else if (this.m_data.ItemData.EquipType == EEquipType.ET_REDMARK && this.m_data.UseProtect)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = 300000207,
						count = 1
					});
				}
			}
			else if (this.m_data.ItemData.EquipType == EEquipType.ET_COMMON)
			{
				if (strengthenCost.ColorCost > 0)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = 300000105,
						count = strengthenCost.ColorCost
					});
				}
				if (strengthenCost.UnColorCost > 0)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = 300000106,
						count = strengthenCost.UnColorCost
					});
				}
				if (strengthenCost.GoldCost > 0)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD),
						count = strengthenCost.GoldCost
					});
				}
				if (this.m_data.UseProtect)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = 200000310,
						count = 1
					});
				}
			}
			else if (this.m_data.ItemData.EquipType == EEquipType.ET_REDMARK)
			{
				List<ItemSimpleData> growthCosts = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthCosts(this.m_data.ItemData);
				for (int i = 0; i < growthCosts.Count; i++)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = growthCosts[i].ItemID,
						count = growthCosts[i].Count
					});
				}
				if (this.m_data.UseProtect)
				{
					list.Add(new StrengthenConfirm.ItemObject
					{
						id = 300000207,
						count = 1
					});
				}
			}
			GameObject gameObject = Utility.FindGameObject(this.frame, "middle/body/Viewport/content/prefabs", true);
			gameObject.CustomActive(false);
			GameObject parent = Utility.FindGameObject(this.frame, "middle/body/Viewport/content", true);
			for (int j = 0; j < list.Count; j++)
			{
				ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(list[j].id, 100, 0);
				GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
				Utility.AttachTo(gameObject2, parent, false);
				gameObject2.CustomActive(true);
				if (gameObject2 != null)
				{
					GameObject goParent = Utility.FindChild(gameObject2, "itemParent");
					ComItem comItem = base.CreateComItem(goParent);
					this.m_arrComItems.Add(comItem);
					Text text = Utility.FindComponent<Text>(gameObject2, "name", true);
					ItemData.QualityInfo qualityInfo = itemData2.GetQualityInfo();
					itemData2.Count = list[j].count;
					comItem.Setup(itemData2, null);
					if (itemData2.Type == ItemTable.eType.INCOME)
					{
						text.text = itemData2.GetColorName(string.Empty, false);
					}
					else
					{
						text.text = itemData2.GetColorName(string.Empty, false);
					}
				}
			}
		}

		// Token: 0x06011599 RID: 71065 RVA: 0x00505244 File Offset: 0x00503644
		protected override void _OnCloseFrame()
		{
			this.m_arrComItems.Clear();
			this.m_data = null;
			this.isSelected = false;
			this.OkBtnOriginText = string.Empty;
			this.bIsUpdate = false;
			this.fCountDownTime = 3f;
			this.fAddUpTime = 0f;
		}

		// Token: 0x0601159A RID: 71066 RVA: 0x00505294 File Offset: 0x00503694
		protected ComItem _CreateComItem(GameObject parent)
		{
			if (parent != null)
			{
				if (this.m_itemPrefab == null)
				{
					this.m_itemPrefab = Singleton<AssetLoader>.instance.LoadResAsGameObject("UI/Prefabs/Item/ItemPrefab", true, 0U);
				}
				this.m_itemPrefab.transform.SetParent(parent.transform, false);
				return this.m_itemPrefab.GetComponent<ComItem>();
			}
			return null;
		}

		// Token: 0x0601159B RID: 71067 RVA: 0x005052F9 File Offset: 0x005036F9
		[UIEventHandle("Mode0/close")]
		private void _OnClose()
		{
			this._OnClickClose();
		}

		// Token: 0x0601159C RID: 71068 RVA: 0x00505301 File Offset: 0x00503701
		[UIEventHandle("Mode1/close")]
		private void _OnClose2()
		{
			this._OnClickClose();
		}

		// Token: 0x0601159D RID: 71069 RVA: 0x00505309 File Offset: 0x00503709
		private void _OnClickClose()
		{
			if (this.isSelected)
			{
				return;
			}
			this.isSelected = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.StrengthenCanceled, null, null, null, null);
			this.frameMgr.CloseFrame<StrengthenConfirm>(this, false);
		}

		// Token: 0x0601159E RID: 71070 RVA: 0x0050533E File Offset: 0x0050373E
		[UIEventHandle("Mode0/ok")]
		private void _OnConfirm()
		{
			this.btnOk.enabled = false;
			this._OnClickConfirm();
		}

		// Token: 0x0601159F RID: 71071 RVA: 0x00505352 File Offset: 0x00503752
		[UIEventHandle("Mode1/ok")]
		private void _OnConfirm2()
		{
			this.btnOk2.enabled = false;
			this._OnClickConfirm();
		}

		// Token: 0x060115A0 RID: 71072 RVA: 0x00505368 File Offset: 0x00503768
		private void _OnClickConfirm()
		{
			if (this.isSelected)
			{
				return;
			}
			this.isSelected = true;
			this.frameMgr.CloseFrame<StrengthenConfirm>(this, false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnStrengthChanged, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.StrengthenDelay, null, null, null, null);
		}

		// Token: 0x060115A1 RID: 71073 RVA: 0x005053BB File Offset: 0x005037BB
		public override bool IsNeedUpdate()
		{
			return this.bIsUpdate;
		}

		// Token: 0x060115A2 RID: 71074 RVA: 0x005053C4 File Offset: 0x005037C4
		protected override void _OnUpdate(float timeElapsed)
		{
			int num = (int)this.fCountDownTime;
			if (this.okBtnText != null)
			{
				this.okBtnText.text = string.Format("{0}({1}s)", this.OkBtnOriginText, num);
			}
			this.fAddUpTime += timeElapsed;
			if (this.fAddUpTime > 1f)
			{
				this.fCountDownTime -= 1f;
				this.fAddUpTime = 0f;
			}
			if (num <= 0)
			{
				this.bIsUpdate = false;
				if (this.okBtnText != null)
				{
					this.okBtnText.text = this.OkBtnOriginText;
				}
				this._SetOkButtonEnabe(true);
			}
		}

		// Token: 0x060115A3 RID: 71075 RVA: 0x0050547D File Offset: 0x0050387D
		private void _SetOkButtonEnabe(bool bEnable)
		{
			if (this.btnOk2 != null)
			{
				this.btnOk2.enabled = bEnable;
			}
			if (this.okBtnGray2 != null)
			{
				this.okBtnGray2.enabled = !bEnable;
			}
		}

		// Token: 0x0400B3DD RID: 46045
		private StrengthenConfirmData m_data;

		// Token: 0x0400B3DE RID: 46046
		private GameObject m_itemPrefab;

		// Token: 0x0400B3DF RID: 46047
		private List<ComItem> m_arrComItems = new List<ComItem>();

		// Token: 0x0400B3E0 RID: 46048
		private Button btnOk;

		// Token: 0x0400B3E1 RID: 46049
		private Button btnOk2;

		// Token: 0x0400B3E2 RID: 46050
		private Text hintUsed;

		// Token: 0x0400B3E3 RID: 46051
		private Text hintUnUsed;

		// Token: 0x0400B3E4 RID: 46052
		private bool bUseModeNormal = true;

		// Token: 0x0400B3E5 RID: 46053
		private GameObject goMode0;

		// Token: 0x0400B3E6 RID: 46054
		private GameObject goMode1;

		// Token: 0x0400B3E7 RID: 46055
		private bool isSelected;

		// Token: 0x0400B3E8 RID: 46056
		private string OkBtnOriginText = string.Empty;

		// Token: 0x0400B3E9 RID: 46057
		private bool bIsUpdate;

		// Token: 0x0400B3EA RID: 46058
		private float fCountDownTime = 3f;

		// Token: 0x0400B3EB RID: 46059
		private float fAddUpTime;

		// Token: 0x0400B3EC RID: 46060
		private Text okBtnText;

		// Token: 0x0400B3ED RID: 46061
		private UIGray okBtnGray2;

		// Token: 0x02001BAE RID: 7086
		private class ItemObject
		{
			// Token: 0x0400B3EE RID: 46062
			public int id;

			// Token: 0x0400B3EF RID: 46063
			public int count;
		}
	}
}
