using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016BC RID: 5820
	internal class GoldJarFrame : ClientFrame
	{
		// Token: 0x0600E43B RID: 58427 RVA: 0x003B09C9 File Offset: 0x003AEDC9
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Jar/GoldJar";
		}

		// Token: 0x0600E43C RID: 58428 RVA: 0x003B09D0 File Offset: 0x003AEDD0
		protected override void _OnOpenFrame()
		{
			DataManager<JarDataManager>.GetInstance().RequestQuaryJarShopSocre();
			this._InitUI();
			this._UpdateRedPoint();
			this._RegisterUIEvent();
		}

		// Token: 0x0600E43D RID: 58429 RVA: 0x003B09EE File Offset: 0x003AEDEE
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E43E RID: 58430 RVA: 0x003B09FC File Offset: 0x003AEDFC
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
		}

		// Token: 0x0600E43F RID: 58431 RVA: 0x003B0A31 File Offset: 0x003AEE31
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnJarUseSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnMoneyChanged));
		}

		// Token: 0x0600E440 RID: 58432 RVA: 0x003B0A68 File Offset: 0x003AEE68
		private void _InitUI()
		{
			this.m_objBuyTemplate.SetActive(false);
			this.m_objBuyTemplate.transform.SetParent(this.frame.transform, false);
			this.m_objMainTypeTemplate.SetActive(false);
			this.m_objMainTypeTemplate.transform.SetParent(this.frame.transform, false);
			this.m_objSubTypeTemplate.SetActive(false);
			this.m_objSubTypeTemplate.transform.SetParent(this.frame.transform, false);
			this.m_objLevelTabTemplate.SetActive(false);
			this.m_objLevelTabTemplate.transform.SetParent(this.frame.transform, false);
			this.m_comItemList.Initialize();
			this.m_comItemList.onBindItem = ((GameObject var) => base.CreateComItem(Utility.FindGameObject(var, "Item", true)));
			this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_currentData != null)
				{
					List<ItemSimpleData> arrBonusItems = this.m_currentData.arrBonusItems;
					if (var.m_index >= 0 && var.m_index < arrBonusItems.Count)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(arrBonusItems[var.m_index].ItemID, 100, 0);
						if (itemData != null)
						{
							itemData.Count = arrBonusItems[var.m_index].Count;
							ComItem comItem = var.gameObjectBindScript as ComItem;
							comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
							});
							Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = itemData.GetColorName(string.Empty, false);
						}
					}
				}
			};
			this._ClearLevelTypes();
			this._ClearGoods();
		}

		// Token: 0x0600E441 RID: 58433 RVA: 0x003B0B5A File Offset: 0x003AEF5A
		private void _ClearUI()
		{
			this.m_arrLevelTypeObjs.Clear();
			this.m_arrBuyObjs.Clear();
			this.m_currentData = null;
			this.m_arrLevelRedPoints.Clear();
		}

		// Token: 0x0600E442 RID: 58434 RVA: 0x003B0B84 File Offset: 0x003AEF84
		private void _InitLevelTypes(int a_nSubType)
		{
			this.m_arrLevelRedPoints.Clear();
			List<Toggle> list = new List<Toggle>();
			bool isToggleInited = false;
			List<JarTreeNode> goldJarLevels = DataManager<JarDataManager>.GetInstance().GetGoldJarLevels(a_nSubType);
			for (int i = 0; i < goldJarLevels.Count; i++)
			{
				int nLevelType = goldJarLevels[i].nKey;
				GameObject objLevelType;
				if (i < this.m_arrLevelTypeObjs.Count)
				{
					objLevelType = this.m_arrLevelTypeObjs[i];
				}
				else
				{
					objLevelType = Object.Instantiate<GameObject>(this.m_objLevelTabTemplate);
					objLevelType.transform.SetParent(this.m_objLevelTabRoot.transform, false);
					this.m_arrLevelTypeObjs.Add(objLevelType);
				}
				objLevelType.SetActive(true);
				Toggle component = objLevelType.GetComponent<Toggle>();
				component.onValueChanged.RemoveAllListeners();
				component.onValueChanged.AddListener(delegate(bool var)
				{
					if (isToggleInited && var)
					{
						this.m_currentData = DataManager<JarDataManager>.GetInstance().GetGoldJarData(a_nSubType, nLevelType);
						this._ClearGoods();
						this._InitGoods(this.m_currentData);
					}
				});
				list.Add(component);
				Utility.GetComponetInChild<Text>(objLevelType, "Label").text = TR.Value("goldjar_level_type", nLevelType);
				this.m_arrLevelRedPoints.Add(delegate
				{
					Utility.FindGameObject(objLevelType, "RedPoint", true).SetActive(DataManager<JarDataManager>.GetInstance().CheckGoldJarLevelRedPoint(a_nSubType, nLevelType));
				});
			}
			Toggle toggle = null;
			for (int j = 0; j < list.Count; j++)
			{
				if (j == 0)
				{
					list[j].group.SetAllTogglesOff();
					toggle = list[j];
				}
				else
				{
					list[j].isOn = true;
				}
			}
			isToggleInited = true;
			if (toggle != null)
			{
				toggle.isOn = true;
			}
		}

		// Token: 0x0600E443 RID: 58435 RVA: 0x003B0D70 File Offset: 0x003AF170
		private void _ClearLevelTypes()
		{
			for (int i = 0; i < this.m_arrLevelTypeObjs.Count; i++)
			{
				this.m_arrLevelTypeObjs[i].SetActive(false);
			}
		}

		// Token: 0x0600E444 RID: 58436 RVA: 0x003B0DAC File Offset: 0x003AF1AC
		private void _InitGoods(JarData a_data)
		{
			if (a_data == null)
			{
				return;
			}
			this.m_comItemList.SetElementAmount(a_data.arrBonusItems.Count);
			ETCImageLoader.LoadSprite(ref this.m_imgJarIcon, a_data.strJarImagePath, true);
			this.m_labJarName.text = a_data.strName;
			ComItem comItem = base.CreateComItem(this.m_objBuyItemRoot);
			ItemData itemData = a_data.arrBuyItems[0];
			comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			this.m_labBuyItemTitle.text = TR.Value("goldjar_buy_item_title", itemData.GetColorName(string.Empty, false));
			this.m_labBuyItemDesc.text = TR.Value("goldjar_buy_desc");
			for (int i = 0; i < this.m_arrBuyObjs.Count; i++)
			{
				this.m_arrBuyObjs[i].SetActive(false);
			}
			for (int j = 0; j < a_data.arrBuyInfos.Count; j++)
			{
				GameObject gameObject;
				if (j < this.m_arrBuyObjs.Count)
				{
					gameObject = this.m_arrBuyObjs[j];
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objBuyTemplate);
					gameObject.transform.SetParent(this.m_objBuyRoot.transform, false);
					this.m_arrBuyObjs.Add(gameObject);
				}
				gameObject.SetActive(true);
				JarBuyInfo buyInfo = a_data.arrBuyInfos[j];
				GameObject gameObject2 = Utility.FindGameObject(gameObject, "RedPoint", true);
				gameObject2.SetActive(false);
				Button component = gameObject.GetComponent<Button>();
				component.onClick.RemoveAllListeners();
				component.onClick.AddListener(delegate()
				{
					ShowItemsFrame.bSkipExplode = false;
					CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
					for (int l = 0; l < buyInfo.arrCosts.Count; l++)
					{
						JarBuyCost jarBuyCost2 = buyInfo.arrCosts[l];
						int realCostCount2 = jarBuyCost2.GetRealCostCount(buyInfo.nBuyCount);
						if (realCostCount2 <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost2.item.TableID, true))
						{
							costInfo.nMoneyID = jarBuyCost2.item.TableID;
							costInfo.nCount = realCostCount2;
							break;
						}
						if (l == buyInfo.arrCosts.Count - 1)
						{
							costInfo.nMoneyID = jarBuyCost2.item.TableID;
							costInfo.nCount = realCostCount2;
						}
					}
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
					{
						DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_data, buyInfo, 0U, 0U);
					}, "common_money_cost", null);
				});
				Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_times", buyInfo.nBuyCount);
				Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
				for (int k = 0; k < buyInfo.arrCosts.Count; k++)
				{
					JarBuyCost jarBuyCost = buyInfo.arrCosts[k];
					int realCostCount = jarBuyCost.GetRealCostCount(buyInfo.nBuyCount);
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = realCostCount.ToString();
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						break;
					}
					if (k == buyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					}
				}
				if (buyInfo.arrCosts.Count > 0)
				{
					this.m_comConsume.SetData(ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue, buyInfo.arrCosts[0].item.TableID);
				}
			}
		}

		// Token: 0x0600E445 RID: 58437 RVA: 0x003B111F File Offset: 0x003AF51F
		private void _ClearGoods()
		{
			this.m_comItemList.SetElementAmount(0);
		}

		// Token: 0x0600E446 RID: 58438 RVA: 0x003B1130 File Offset: 0x003AF530
		private void _UpdateGoods(JarData a_data)
		{
			for (int i = 0; i < a_data.arrBuyInfos.Count; i++)
			{
				GameObject gameObject;
				if (i < this.m_arrBuyObjs.Count)
				{
					gameObject = this.m_arrBuyObjs[i];
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objBuyTemplate);
					gameObject.transform.SetParent(this.m_objBuyRoot.transform, false);
					this.m_arrBuyObjs.Add(gameObject);
				}
				gameObject.SetActive(true);
				JarBuyInfo jarBuyInfo = a_data.arrBuyInfos[i];
				GameObject gameObject2 = Utility.FindGameObject(gameObject, "RedPoint", true);
				gameObject2.SetActive(DataManager<JarDataManager>.GetInstance().CheckRedPoint(a_data, jarBuyInfo));
				Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
				for (int j = 0; j < jarBuyInfo.arrCosts.Count; j++)
				{
					JarBuyCost jarBuyCost = jarBuyInfo.arrCosts[j];
					int realCostCount = jarBuyCost.GetRealCostCount(jarBuyInfo.nBuyCount);
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = realCostCount.ToString();
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						break;
					}
					if (j == jarBuyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					}
				}
			}
		}

		// Token: 0x0600E447 RID: 58439 RVA: 0x003B12C4 File Offset: 0x003AF6C4
		private void _UpdateRedPoint()
		{
			for (int i = 0; i < this.m_arrLevelRedPoints.Count; i++)
			{
				this.m_arrLevelRedPoints[i]();
			}
		}

		// Token: 0x0600E448 RID: 58440 RVA: 0x003B12FE File Offset: 0x003AF6FE
		private void _OnJarUseSuccess(UIEvent a_event)
		{
			this._UpdateGoods(this.m_currentData);
			this._UpdateRedPoint();
		}

		// Token: 0x0600E449 RID: 58441 RVA: 0x003B1312 File Offset: 0x003AF712
		private void _OnMoneyChanged(UIEvent a_event)
		{
			this._UpdateGoods(this.m_currentData);
		}

		// Token: 0x0600E44A RID: 58442 RVA: 0x003B1320 File Offset: 0x003AF720
		private void _OnItemGet(UIEvent a_event)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0600E44B RID: 58443 RVA: 0x003B1328 File Offset: 0x003AF728
		[UIEventHandle("BG/Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GoldJarFrame>(this, false);
		}

		// Token: 0x0600E44C RID: 58444 RVA: 0x003B1337 File Offset: 0x003AF737
		[UIEventHandle("Content/TabGroup/Page/Left/Shop")]
		private void _OnShopClicked()
		{
		}

		// Token: 0x04008920 RID: 35104
		[UIObject("Content/TreeList/Viewport/Content")]
		private GameObject m_objMainTypeRoot;

		// Token: 0x04008921 RID: 35105
		[UIObject("Content/TreeList/Viewport/Content/Group")]
		private GameObject m_objMainTypeTemplate;

		// Token: 0x04008922 RID: 35106
		[UIObject("Content/TreeList/Viewport/Content/Group/SubTypes/SubType")]
		private GameObject m_objSubTypeTemplate;

		// Token: 0x04008923 RID: 35107
		[UIObject("Content/TabGroup/Tabs")]
		private GameObject m_objLevelTabRoot;

		// Token: 0x04008924 RID: 35108
		[UIObject("Content/TabGroup/Tabs/Tab")]
		private GameObject m_objLevelTabTemplate;

		// Token: 0x04008925 RID: 35109
		[UIControl("Content/TabGroup/Page/Right/Items", null, 0)]
		private ComUIListScript m_comItemList;

		// Token: 0x04008926 RID: 35110
		[UIControl("Content/TabGroup/Page/Left/Jar", null, 0)]
		private Image m_imgJarIcon;

		// Token: 0x04008927 RID: 35111
		[UIControl("Content/TabGroup/Page/Left/Jar/Name", null, 0)]
		private Text m_labJarName;

		// Token: 0x04008928 RID: 35112
		[UIControl("Content/TabGroup/Page/Left/BuyDesc/Title", null, 0)]
		private Text m_labBuyItemTitle;

		// Token: 0x04008929 RID: 35113
		[UIObject("Content/TabGroup/Page/Left/BuyDesc/ItemRoot")]
		private GameObject m_objBuyItemRoot;

		// Token: 0x0400892A RID: 35114
		[UIControl("Content/TabGroup/Page/Left/BuyDesc/Desc", null, 0)]
		private Text m_labBuyItemDesc;

		// Token: 0x0400892B RID: 35115
		[UIObject("Content/TabGroup/Page/Right/Buy")]
		private GameObject m_objBuyRoot;

		// Token: 0x0400892C RID: 35116
		[UIObject("Content/TabGroup/Page/Right/Buy/Func")]
		private GameObject m_objBuyTemplate;

		// Token: 0x0400892D RID: 35117
		[UIControl("Content/TabGroup/Page/Left/CommonConsume", typeof(ComCommonConsume), 0)]
		private ComCommonConsume m_comConsume;

		// Token: 0x0400892E RID: 35118
		private List<GameObject> m_arrLevelTypeObjs = new List<GameObject>();

		// Token: 0x0400892F RID: 35119
		private List<GameObject> m_arrBuyObjs = new List<GameObject>();

		// Token: 0x04008930 RID: 35120
		private JarData m_currentData;

		// Token: 0x04008931 RID: 35121
		private List<GoldJarFrame.OnRedPointChanged> m_arrLevelRedPoints = new List<GoldJarFrame.OnRedPointChanged>();

		// Token: 0x020016BD RID: 5821
		// (Invoke) Token: 0x0600E452 RID: 58450
		private delegate void OnRedPointChanged();
	}
}
