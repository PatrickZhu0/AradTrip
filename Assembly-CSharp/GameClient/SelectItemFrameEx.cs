using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016FC RID: 5884
	internal class SelectItemFrameEx : ClientFrame
	{
		// Token: 0x0600E716 RID: 59158 RVA: 0x003CC77C File Offset: 0x003CAB7C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/SelectItemEx";
		}

		// Token: 0x0600E717 RID: 59159 RVA: 0x003CC784 File Offset: 0x003CAB84
		public GiftBagItemEx Create(GameObject parent)
		{
			if (parent == null)
			{
				Logger.LogError("SelectItemFrameEx Create function param parent is null!");
				return null;
			}
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Tip/GiftBagItemEx", enResourceType.UIPrefab, 2U);
			if (gameObject != null)
			{
				GiftBagItemEx component = gameObject.GetComponent<GiftBagItemEx>();
				if (component != null)
				{
					component.gameObject.transform.SetParent(parent.transform, false);
					return component;
				}
			}
			return null;
		}

		// Token: 0x0600E718 RID: 59160 RVA: 0x003CC7F4 File Offset: 0x003CABF4
		public void Destroy(GiftBagItemEx a_comItem)
		{
			if (a_comItem != null && a_comItem.gameObject != null)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(a_comItem.gameObject);
			}
		}

		// Token: 0x0600E719 RID: 59161 RVA: 0x003CC824 File Offset: 0x003CAC24
		private GiftBagItemEx CreateGiftBagItem(GameObject goParent)
		{
			GiftBagItemEx giftBagItemEx = this.Create(goParent);
			if (giftBagItemEx != null)
			{
				if (this.m_akGifgBagItemList == null)
				{
					this.m_akGifgBagItemList = new List<GiftBagItemEx>();
				}
				this.m_akGifgBagItemList.Add(giftBagItemEx);
			}
			return giftBagItemEx;
		}

		// Token: 0x0600E71A RID: 59162 RVA: 0x003CC868 File Offset: 0x003CAC68
		private void DestroyGifgBagItems()
		{
			if (this.m_akGifgBagItemList != null)
			{
				for (int i = 0; i < this.m_akGifgBagItemList.Count; i++)
				{
					if (this.m_akGifgBagItemList[i] != null)
					{
						this.m_akGifgBagItemList[i].IsSelect = false;
						this.Destroy(this.m_akGifgBagItemList[i]);
					}
				}
				this.m_akGifgBagItemList.Clear();
			}
		}

		// Token: 0x0600E71B RID: 59163 RVA: 0x003CC8E4 File Offset: 0x003CACE4
		protected override void _OnOpenFrame()
		{
			if (this.imgGetGiftText != null)
			{
				this.imgGetGiftText.CustomActive(false);
			}
			this.m_giftItem = (this.userData as ItemData);
			if (this.m_giftItem == null)
			{
				Logger.LogError("open SelectItemFrame, user data is invalid!!");
				return;
			}
			List<GiftTable> gifts = this.m_giftItem.GetGifts();
			if (gifts == null || gifts.Count <= 0)
			{
				Logger.LogErrorFormat("礼包{0}不包含任何道具，请检查礼包表", new object[]
				{
					this.m_giftItem.TableID
				});
				return;
			}
			for (int i = 0; i < gifts.Count; i++)
			{
				if (gifts[i].Levels.Count <= 0 || ((int)DataManager<PlayerBaseData>.GetInstance().Level >= gifts[i].Levels[0] && (int)DataManager<PlayerBaseData>.GetInstance().Level <= gifts[i].Levels[1]))
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(gifts[i].ItemID, 100, 0);
					itemData.Count = gifts[i].ItemCount;
					this.m_arrItems.Add(itemData);
				}
			}
			this.m_labName.text = this.m_giftItem.Name;
			this.m_giftPackTable = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(this.m_giftItem.PackID, string.Empty, string.Empty);
			if (this.txtSelectInfo != null)
			{
				this.txtSelectInfo.text = string.Format("{0}选{1}", this.m_arrItems.Count, this.m_giftPackTable.FilterCount);
			}
			if (this.txtSelectInfo2 != null)
			{
				if (this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount)
				{
					if (this.imgGetGiftText != null)
					{
						this.imgGetGiftText.CustomActive(true);
					}
					this.txtSelectInfo2.text = string.Empty;
				}
				else
				{
					this.txtSelectInfo2.text = TR.Value("select_info", this._GetSelectItemsCount(), this.m_giftPackTable.FilterCount);
					if (this.imgGetGiftText != null)
					{
						this.imgGetGiftText.CustomActive(false);
					}
				}
			}
			this.m_comItemList.Initialize();
			this.m_comItemList.onBindItem = delegate(GameObject var)
			{
				GiftBagItemEx giftBagItemEx = this.CreateGiftBagItem(Utility.FindGameObject(var, "Item", true));
				giftBagItemEx.IsSelect = false;
				return giftBagItemEx;
			};
			this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var.m_index >= 0 && var.m_index < this.m_arrItems.Count)
				{
					if (this.m_curSelectIndexs.Contains(var.m_index))
					{
						(var.gameObjectBindScript as GiftBagItemEx).IsSelect = true;
					}
					else
					{
						(var.gameObjectBindScript as GiftBagItemEx).IsSelect = false;
					}
					GiftBagItemEx giftBagItemEx = var.gameObjectBindScript as GiftBagItemEx;
					giftBagItemEx.Setup(var.m_index, this.m_arrItems[var.m_index], delegate(GameObject var1, ItemData var2)
					{
						if (this.m_giftPackTable.FilterCount <= 0)
						{
							return;
						}
						SelectItemFrameEx $this = this;
						if (this.m_giftPackTable.FilterCount == 1)
						{
							for (int j = 0; j < this.m_arrItems.Count; j++)
							{
								this.m_arrItems[j].IsSelected = false;
							}
							for (int k = 0; k < this.m_akGifgBagItemList.Count; k++)
							{
								this.m_akGifgBagItemList[k].IsSelect = false;
							}
							var2.IsSelected = true;
							this.m_curSelectIndexs.Clear();
							GiftBagItemEx giftBagItemEx2 = var.gameObjectBindScript as GiftBagItemEx;
							if (giftBagItemEx2 != null)
							{
								giftBagItemEx2.IsSelect = !giftBagItemEx2.IsSelect;
								if (giftBagItemEx2.IsSelect)
								{
									this.m_curSelectIndexs.Add(var.m_index);
								}
							}
							this.m_comBtnOkEnable.SetEnable(this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount);
							if (this.uiGray != null)
							{
								this.uiGray.SetEnable(this._GetSelectItemsCount() != this.m_giftPackTable.FilterCount);
							}
							this.m_comItemList.SetElementAmount(this.m_arrItems.Count);
							if (this.txtSelectInfo != null)
							{
								this.txtSelectInfo.text = string.Format("{0}选{1}", this.m_arrItems.Count, this.m_giftPackTable.FilterCount);
							}
							if (this.txtSelectInfo2 != null)
							{
								if (this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount)
								{
									if (this.imgGetGiftText != null)
									{
										this.imgGetGiftText.CustomActive(true);
									}
									this.txtSelectInfo2.text = string.Empty;
								}
								else
								{
									this.txtSelectInfo2.text = TR.Value("select_info", this._GetSelectItemsCount(), this.m_giftPackTable.FilterCount);
									if (this.imgGetGiftText != null)
									{
										this.imgGetGiftText.CustomActive(false);
									}
								}
							}
						}
						else
						{
							var2.IsSelected = !var2.IsSelected;
							GiftBagItemEx giftBagItemEx3 = var.gameObjectBindScript as GiftBagItemEx;
							if (giftBagItemEx3 != null)
							{
								giftBagItemEx3.IsSelect = !giftBagItemEx3.IsSelect;
								if (giftBagItemEx3.IsSelect)
								{
									this.m_curSelectIndexs.Add(var.m_index);
								}
								else
								{
									this.m_curSelectIndexs.Remove(var.m_index);
								}
							}
							if (this._GetSelectItemsCount() > this.m_giftPackTable.FilterCount)
							{
								var2.IsSelected = !var2.IsSelected;
								if (giftBagItemEx3 != null)
								{
									giftBagItemEx3.IsSelect = !giftBagItemEx3.IsSelect;
									if (giftBagItemEx3.IsSelect)
									{
										this.m_curSelectIndexs.Add(var.m_index);
									}
									else
									{
										this.m_curSelectIndexs.Remove(var.m_index);
									}
								}
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("gift_select_item_max_count"), CommonTipsDesc.eShowMode.SI_UNIQUE);
								return;
							}
							this.m_comBtnOkEnable.SetEnable(this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount);
							if (this.uiGray != null)
							{
								this.uiGray.SetEnable(this._GetSelectItemsCount() != this.m_giftPackTable.FilterCount);
							}
							if (this.txtSelectInfo != null)
							{
								this.txtSelectInfo.text = string.Format("{0}选{1}", this.m_arrItems.Count, this.m_giftPackTable.FilterCount);
							}
							if (this.txtSelectInfo2 != null)
							{
								if (this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount)
								{
									if (this.imgGetGiftText != null)
									{
										this.imgGetGiftText.CustomActive(true);
									}
									this.txtSelectInfo2.text = string.Empty;
								}
								else
								{
									this.txtSelectInfo2.text = TR.Value("select_info", this._GetSelectItemsCount(), this.m_giftPackTable.FilterCount);
									if (this.imgGetGiftText != null)
									{
										this.imgGetGiftText.CustomActive(false);
									}
								}
							}
						}
					});
				}
			};
			this.m_comItemList.SetElementAmount(this.m_arrItems.Count);
			this.m_btnOk.onClick.RemoveAllListeners();
			this.m_btnOk.onClick.AddListener(delegate()
			{
				if (this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount)
				{
					int a_nParam;
					int a_nParam2;
					this._GetSelectItemsMask(out a_nParam, out a_nParam2);
					DataManager<ItemDataManager>.GetInstance().UseItem(this.m_giftItem, false, a_nParam2, a_nParam);
					if (this.m_giftItem.Count <= 1 || this.m_giftItem.CD > 0)
					{
						DataManager<ItemTipManager>.GetInstance().CloseAll();
					}
					this.frameMgr.CloseFrame<SelectItemFrameEx>(this, false);
				}
			});
			this.m_comBtnOkEnable.SetEnable(false);
			if (this.uiGray != null)
			{
				this.uiGray.SetEnable(true);
			}
		}

		// Token: 0x0600E71C RID: 59164 RVA: 0x003CCBEA File Offset: 0x003CAFEA
		protected override void _OnCloseFrame()
		{
			this.m_giftItem = null;
			this.m_giftPackTable = null;
			this.m_arrItems.Clear();
			this.m_curSelectIndexs.Clear();
			this.DestroyGifgBagItems();
		}

		// Token: 0x0600E71D RID: 59165 RVA: 0x003CCC18 File Offset: 0x003CB018
		private void _GetSelectItemsMask(out int a_nHith, out int a_nLow)
		{
			a_nHith = 0;
			a_nLow = 0;
			for (int i = 0; i < this.m_arrItems.Count; i++)
			{
				if (this.m_arrItems[i].IsSelected)
				{
					if (i >= 0 && i < 32)
					{
						a_nLow |= 1 << i;
					}
					else
					{
						a_nHith |= 1 << i - 32;
					}
				}
			}
		}

		// Token: 0x0600E71E RID: 59166 RVA: 0x003CCC8C File Offset: 0x003CB08C
		private int _GetSelectItemsCount()
		{
			int num = 0;
			for (int i = 0; i < this.m_arrItems.Count; i++)
			{
				if (this.m_arrItems[i].IsSelected)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x04008C13 RID: 35859
		[UIControl("Name", null, 0)]
		private Text m_labName;

		// Token: 0x04008C14 RID: 35860
		[UIControl("Items", null, 0)]
		private ComUIListScript m_comItemList;

		// Token: 0x04008C15 RID: 35861
		[UIControl("Ok", null, 0)]
		private Button m_btnOk;

		// Token: 0x04008C16 RID: 35862
		[UIControl("Ok", null, 0)]
		private ComButtonEnbale m_comBtnOkEnable;

		// Token: 0x04008C17 RID: 35863
		[UIControl("Tip", null, 0)]
		private Text m_labCountTip;

		// Token: 0x04008C18 RID: 35864
		[UIControl("Ok", null, 0)]
		private UIGray uiGray;

		// Token: 0x04008C19 RID: 35865
		[UIControl("SelectInfo", null, 0)]
		private Text txtSelectInfo;

		// Token: 0x04008C1A RID: 35866
		[UIControl("Ok/SelectInfo", null, 0)]
		private Text txtSelectInfo2;

		// Token: 0x04008C1B RID: 35867
		[UIControl("Ok/GetGiftText", null, 0)]
		private Image imgGetGiftText;

		// Token: 0x04008C1C RID: 35868
		private List<int> m_curSelectIndexs = new List<int>();

		// Token: 0x04008C1D RID: 35869
		private ItemData m_giftItem;

		// Token: 0x04008C1E RID: 35870
		private GiftPackTable m_giftPackTable;

		// Token: 0x04008C1F RID: 35871
		private List<ItemData> m_arrItems = new List<ItemData>();

		// Token: 0x04008C20 RID: 35872
		protected List<GiftBagItemEx> m_akGifgBagItemList;
	}
}
