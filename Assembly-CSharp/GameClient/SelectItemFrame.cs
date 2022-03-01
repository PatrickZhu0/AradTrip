using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016FB RID: 5883
	internal class SelectItemFrame : ClientFrame
	{
		// Token: 0x0600E708 RID: 59144 RVA: 0x003CBAE2 File Offset: 0x003C9EE2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/SelectItem";
		}

		// Token: 0x0600E709 RID: 59145 RVA: 0x003CBAEC File Offset: 0x003C9EEC
		public GiftBagItem Create(GameObject parent)
		{
			if (parent == null)
			{
				Logger.LogError("SelectItemFrame Create function param parent is null!");
				return null;
			}
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Tip/GiftBagItem", enResourceType.UIPrefab, 2U);
			if (gameObject != null)
			{
				GiftBagItem component = gameObject.GetComponent<GiftBagItem>();
				if (component != null)
				{
					component.gameObject.transform.SetParent(parent.transform, false);
					return component;
				}
			}
			return null;
		}

		// Token: 0x0600E70A RID: 59146 RVA: 0x003CBB5C File Offset: 0x003C9F5C
		public void Destroy(GiftBagItem a_comItem)
		{
			if (a_comItem != null && a_comItem.gameObject != null)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(a_comItem.gameObject);
			}
		}

		// Token: 0x0600E70B RID: 59147 RVA: 0x003CBB8C File Offset: 0x003C9F8C
		private GiftBagItem CreateGiftBagItem(GameObject goParent)
		{
			GiftBagItem giftBagItem = this.Create(goParent);
			if (giftBagItem != null)
			{
				if (this.m_akGifgBagItemList == null)
				{
					this.m_akGifgBagItemList = new List<GiftBagItem>();
				}
				giftBagItem.Index = this.m_akGifgBagItemList.Count;
				this.m_akGifgBagItemList.Add(giftBagItem);
			}
			return giftBagItem;
		}

		// Token: 0x0600E70C RID: 59148 RVA: 0x003CBBE4 File Offset: 0x003C9FE4
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

		// Token: 0x0600E70D RID: 59149 RVA: 0x003CBC60 File Offset: 0x003CA060
		protected override void _OnOpenFrame()
		{
			if (this.uiGray == null)
			{
				this.uiGray = this.m_btnOk.GetComponent<UIGray>();
				if (this.uiGray != null)
				{
					this.uiGray.bEnabled2Text = false;
				}
			}
			this.m_giftItem = (this.userData as ItemData);
			if (this.m_giftItem == null)
			{
				Logger.LogError("open SelectItemFrame, user data is invalid!!");
				return;
			}
			GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(this.m_giftItem.PackID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.UIType == 1)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.m_giftItem.GUID);
				base.SetVisible(false);
				InvokeMethod.Invoke(0.5f, delegate()
				{
					Singleton<ClientSystemManager>.instance.CloseFrame<SelectItemFrame>(this, true);
				});
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectItemFrameEx>(FrameLayer.Middle, item, string.Empty);
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
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(gifts[i].ItemID, 100, gifts[i].Strengthen);
					if (itemData != null)
					{
						itemData.Count = gifts[i].ItemCount;
						this.m_arrItems.Add(itemData);
					}
				}
			}
			if (this.m_labName != null)
			{
				this.m_labName.text = this.m_giftItem.Name;
			}
			this.m_giftPackTable = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(this.m_giftItem.PackID, string.Empty, string.Empty);
			if (this.m_giftPackTable == null)
			{
				return;
			}
			if (this.m_labCountTip != null)
			{
				this.m_labCountTip.text = TR.Value("gift_select_item_tip", this.m_giftPackTable.FilterCount);
			}
			if (this.txtSelectInfo != null)
			{
				if (this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount)
				{
					this.txtSelectInfo.text = TR.Value("select_ok");
				}
				else
				{
					this.txtSelectInfo.text = TR.Value("select_info", this._GetSelectItemsCount(), this.m_giftPackTable.FilterCount);
				}
			}
			if (this.m_comItemList != null)
			{
				this.m_comItemList.Initialize();
				if (this.m_arrItems.Count <= 5)
				{
					this.m_comItemList.m_elementPadding.y = 70f;
				}
				this.m_comItemList.onBindItem = delegate(GameObject var)
				{
					GiftBagItem giftBagItem = this.CreateGiftBagItem(Utility.FindGameObject(var, "Item", true));
					if (giftBagItem != null)
					{
						giftBagItem.IsSelect = false;
					}
					return giftBagItem;
				};
				this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript var)
				{
					if (var != null && var.m_index >= 0 && var.m_index < this.m_arrItems.Count)
					{
						if (this.m_curSelectIndexs.Contains(var.m_index))
						{
							(var.gameObjectBindScript as GiftBagItem).IsSelect = true;
						}
						else
						{
							(var.gameObjectBindScript as GiftBagItem).IsSelect = false;
						}
						GiftBagItem giftBagItem = var.gameObjectBindScript as GiftBagItem;
						giftBagItem.Setup(var.m_index, this.m_arrItems[var.m_index], delegate(GameObject var1, ItemData var2)
						{
							if (this.m_giftPackTable.FilterCount <= 0)
							{
								return;
							}
							SelectItemFrame $this = this;
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
								GiftBagItem giftBagItem2 = var.gameObjectBindScript as GiftBagItem;
								if (giftBagItem2 != null)
								{
									giftBagItem2.IsSelect = !giftBagItem2.IsSelect;
									if (giftBagItem2.IsSelect)
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
									if (this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount)
									{
										this.txtSelectInfo.text = TR.Value("select_ok");
									}
									else
									{
										this.txtSelectInfo.text = TR.Value("select_info", this._GetSelectItemsCount(), this.m_giftPackTable.FilterCount);
									}
								}
							}
							else
							{
								var2.IsSelected = !var2.IsSelected;
								GiftBagItem giftBagItem3 = var.gameObjectBindScript as GiftBagItem;
								if (giftBagItem3 != null)
								{
									giftBagItem3.IsSelect = !giftBagItem3.IsSelect;
									if (giftBagItem3.IsSelect)
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
									if (giftBagItem3 != null)
									{
										giftBagItem3.IsSelect = !giftBagItem3.IsSelect;
										if (giftBagItem3.IsSelect)
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
									if (this._GetSelectItemsCount() == this.m_giftPackTable.FilterCount)
									{
										this.txtSelectInfo.text = TR.Value("select_ok");
									}
									else
									{
										this.txtSelectInfo.text = TR.Value("select_info", this._GetSelectItemsCount(), this.m_giftPackTable.FilterCount);
									}
								}
							}
						});
					}
				};
				this.m_comItemList.SetElementAmount(this.m_arrItems.Count);
			}
			if (this.m_btnOk != null)
			{
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
						this.frameMgr.CloseFrame<SelectItemFrame>(this, false);
					}
				});
			}
			if (this.m_comBtnOkEnable != null)
			{
				this.m_comBtnOkEnable.SetEnable(false);
			}
			if (this.uiGray != null)
			{
				this.uiGray.SetEnable(true);
			}
		}

		// Token: 0x0600E70E RID: 59150 RVA: 0x003CC046 File Offset: 0x003CA446
		protected override void _OnCloseFrame()
		{
			this.m_giftItem = null;
			this.m_giftPackTable = null;
			this.m_arrItems.Clear();
			this.m_curSelectIndexs.Clear();
			this.DestroyGifgBagItems();
		}

		// Token: 0x0600E70F RID: 59151 RVA: 0x003CC074 File Offset: 0x003CA474
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

		// Token: 0x0600E710 RID: 59152 RVA: 0x003CC0E8 File Offset: 0x003CA4E8
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

		// Token: 0x04008C07 RID: 35847
		[UIControl("Name", null, 0)]
		private Text m_labName;

		// Token: 0x04008C08 RID: 35848
		[UIControl("Items", null, 0)]
		private ComUIListScript m_comItemList;

		// Token: 0x04008C09 RID: 35849
		[UIControl("Ok", null, 0)]
		private Button m_btnOk;

		// Token: 0x04008C0A RID: 35850
		[UIControl("Ok", null, 0)]
		private ComButtonEnbale m_comBtnOkEnable;

		// Token: 0x04008C0B RID: 35851
		[UIControl("Tip", null, 0)]
		private Text m_labCountTip;

		// Token: 0x04008C0C RID: 35852
		[UIControl("Ok", null, 0)]
		private UIGray uiGray;

		// Token: 0x04008C0D RID: 35853
		[UIControl("SelectInfo", null, 0)]
		private Text txtSelectInfo;

		// Token: 0x04008C0E RID: 35854
		private ItemData m_giftItem;

		// Token: 0x04008C0F RID: 35855
		private GiftPackTable m_giftPackTable;

		// Token: 0x04008C10 RID: 35856
		private List<ItemData> m_arrItems = new List<ItemData>();

		// Token: 0x04008C11 RID: 35857
		private List<int> m_curSelectIndexs = new List<int>();

		// Token: 0x04008C12 RID: 35858
		protected List<GiftBagItem> m_akGifgBagItemList;
	}
}
