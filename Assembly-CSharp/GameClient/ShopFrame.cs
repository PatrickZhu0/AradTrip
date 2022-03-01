using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A50 RID: 6736
	internal class ShopFrame : ClientFrame
	{
		// Token: 0x0601089E RID: 67742 RVA: 0x004AA424 File Offset: 0x004A8824
		public static void CloseMulteFrame(int iShopID)
		{
			IClientFrame frame = Singleton<ClientSystemManager>.GetInstance().GetFrame("ShopFrame" + iShopID);
			if (frame != null)
			{
				frame.Close(true);
			}
		}

		// Token: 0x0601089F RID: 67743 RVA: 0x004AA45C File Offset: 0x004A885C
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length == 3)
				{
					int num = int.Parse(array[0]);
					int shopLinkID = int.Parse(array[1]);
					int shopTabID = int.Parse(array[2]);
					ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(num, string.Empty, string.Empty);
					if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.OpenLevel)
					{
						string msgContent = string.Format(TR.Value("exchange_mall_not_open"), tableItem.OpenLevel, tableItem.ShopName);
						SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						DataManager<ShopDataManager>.GetInstance().OpenShop(num, shopLinkID, shopTabID, null, null, ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, 0, -1);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("ShopFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x060108A0 RID: 67744 RVA: 0x004AA54C File Offset: 0x004A894C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/ShopFrame";
		}

		// Token: 0x17001D53 RID: 7507
		// (get) Token: 0x060108A1 RID: 67745 RVA: 0x004AA553 File Offset: 0x004A8953
		public ShopFrame.ShopFrameMode EShopFrameMode
		{
			get
			{
				return this.m_eShopFrameMode;
			}
		}

		// Token: 0x060108A2 RID: 67746 RVA: 0x004AA55C File Offset: 0x004A895C
		private void _FreshModeInfo(int iCount)
		{
			this.m_iCurGoodsCount = iCount;
			if (this.m_iCurGoodsCount <= 8)
			{
				this.m_bNeedMod = false;
				this.m_fCurMod = 1f;
			}
			else
			{
				this.m_bNeedMod = true;
				int num = ((this.m_iCurGoodsCount & 1) != 1) ? (this.m_iCurGoodsCount / 2) : (this.m_iCurGoodsCount / 2 + 1);
				num -= 4;
				this.m_fCurMod = 1f / (float)num;
			}
		}

		// Token: 0x060108A3 RID: 67747 RVA: 0x004AA5D2 File Offset: 0x004A89D2
		protected void _OnSetPageInfo()
		{
			if (!this.m_bNeedMod)
			{
			}
		}

		// Token: 0x060108A4 RID: 67748 RVA: 0x004AA5E4 File Offset: 0x004A89E4
		private void _SetFilter(ShopTable.eFilter eFilter)
		{
			if (this.m_kDropdown != null)
			{
				this.m_kDropdown.CustomActive(eFilter != ShopTable.eFilter.SF_NONE);
				this.m_kDropdown.onValueChanged.RemoveAllListeners();
				this.m_kDropdown.options.Clear();
				if (eFilter == ShopTable.eFilter.SF_OCCU)
				{
					List<JobTable> orgJobTables = Utility.OrgJobTables;
					if (orgJobTables != null && orgJobTables.Count > 0)
					{
						for (int i = 0; i < orgJobTables.Count; i++)
						{
							if (orgJobTables[i] != null)
							{
								ShopFrame.GoodOptionData goodOptionData = new ShopFrame.GoodOptionData();
								goodOptionData.text = orgJobTables[i].Name;
								goodOptionData.jobItem = orgJobTables[i];
								this.m_kDropdown.options.Add(goodOptionData);
								if (goodOptionData.jobItem.ID == DataManager<PlayerBaseData>.GetInstance().JobTableID / 10 * 10)
								{
									this.m_kDropdown.value = i;
								}
							}
						}
						if (orgJobTables != null && orgJobTables.Count > 0 && this.m_kDropdown != null && this.m_kDropdown.value >= 0 && this.m_kDropdown.value < this.m_kDropdown.options.Count)
						{
							ShopFrame.GoodOptionData goodOptionData2 = this.m_kDropdown.options[this.m_kDropdown.value] as ShopFrame.GoodOptionData;
							this.m_kDropdown.captionText.text = goodOptionData2.text;
							this.m_kGoodOptionData = goodOptionData2;
						}
					}
					this.m_kDropdown.onValueChanged.AddListener(new UnityAction<int>(this._OnDropDownValueChanged));
				}
				else if (eFilter == ShopTable.eFilter.SF_ARMOR)
				{
					bool flag = false;
					for (int j = 0; j < this.armorLists.Length; j++)
					{
						ShopFrame.GoodOptionData goodOptionData3 = new ShopFrame.GoodOptionData();
						goodOptionData3.text = this.armorNames[j];
						goodOptionData3.eFilter = this.armorLists[j];
						this.m_kDropdown.options.Add(goodOptionData3);
						JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
						if (tableItem != null && !flag && (tableItem.SuitArmorType == 0 || tableItem.SuitArmorType - 4 + ItemTable.eThirdType.CLOTH == goodOptionData3.eFilter))
						{
							this.m_kDropdown.value = j;
							flag = true;
						}
					}
					if (this.m_kDropdown != null && this.m_kDropdown.value >= 0 && this.m_kDropdown.value < this.m_kDropdown.options.Count)
					{
						ShopFrame.GoodOptionData goodOptionData4 = this.m_kDropdown.options[this.m_kDropdown.value] as ShopFrame.GoodOptionData;
						this.m_kDropdown.captionText.text = goodOptionData4.text;
						this.m_kGoodOptionData = goodOptionData4;
					}
					this.m_kDropdown.onValueChanged.AddListener(new UnityAction<int>(this._OnDropDownValueChanged));
				}
				else if (eFilter == ShopTable.eFilter.SF_OCCU2)
				{
					int betterJobId = Utility.GetBetterJobId(DataManager<PlayerBaseData>.GetInstance().JobTableID);
					List<JobTable> bettleJobIds = Utility.BettleJobIds;
					if (bettleJobIds != null && bettleJobIds.Count > 0)
					{
						for (int k = 0; k < bettleJobIds.Count; k++)
						{
							if (bettleJobIds[k] != null)
							{
								ShopFrame.GoodOptionData goodOptionData5 = new ShopFrame.GoodOptionData();
								goodOptionData5.text = bettleJobIds[k].Name;
								goodOptionData5.jobItem = bettleJobIds[k];
								this.m_kDropdown.options.Add(goodOptionData5);
								if (goodOptionData5.jobItem.ID == betterJobId)
								{
									this.m_kDropdown.value = k;
								}
							}
						}
						if (bettleJobIds.Count > 0 && this.m_kDropdown != null && this.m_kDropdown.value >= 0 && this.m_kDropdown.value < this.m_kDropdown.options.Count)
						{
							ShopFrame.GoodOptionData goodOptionData6 = this.m_kDropdown.options[this.m_kDropdown.value] as ShopFrame.GoodOptionData;
							if (goodOptionData6 != null)
							{
								this.m_kDropdown.captionText.text = goodOptionData6.text;
								this.m_kGoodOptionData = goodOptionData6;
							}
						}
					}
					this.m_kDropdown.onValueChanged.AddListener(new UnityAction<int>(this._OnDropDownValueChanged));
				}
			}
		}

		// Token: 0x060108A5 RID: 67749 RVA: 0x004AAA68 File Offset: 0x004A8E68
		protected void _PlayNpcSound(NpcVoiceComponent.SoundEffectType eSound)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (this.m_kShopData == null)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this.m_kShopData.iLinkNpcId, string.Empty, string.Empty) == null)
			{
				return;
			}
			clientSystemTown.PlayNpcSound(this.m_kShopData.iLinkNpcId, eSound);
		}

		// Token: 0x060108A6 RID: 67750 RVA: 0x004AAAD4 File Offset: 0x004A8ED4
		protected void _InitDropDown()
		{
			this.comTimeRefresh = Utility.FindComponent<TimeRefresh>(this.frame, "middleback/Goods/Title/RefreshTime", true);
			this.m_kDropdown = Utility.FindComponent<Dropdown>(this.frame, "middleback/Goods/Title/job_select", true);
			this.m_fPreValue = 0f;
			this.m_bNeedMod = false;
			this.m_animation = Utility.FindComponent<DOTweenAnimation>(this.frame, "middleback/Goods/Scroll View/Viewport/Content", true);
			this.m_goScrollView = Utility.FindChild(this.frame, "middleback/Goods/Scroll View");
			this.m_fScrollViewWidth = RectTransformUtility.CalculateRelativeRectTransformBounds(this.m_goScrollView.transform).size.x;
			this.m_kHistroyRecord = Utility.FindComponent<Text>(this.frame, "middleback/Goods/HistroyRecord", true);
			this.m_kHistroyRecord.enabled = false;
			this.m_iCurrentPage = 0;
			this.m_iMaxPage = 1;
			this.m_iPageCount = 8;
			this.m_bNeedMod = false;
			this._SetFilter(ShopTable.eFilter.SF_NONE);
		}

		// Token: 0x060108A7 RID: 67751 RVA: 0x004AABBC File Offset: 0x004A8FBC
		private void _OnDropDownValueChanged(int iValue)
		{
			ShopFrame.ComShopTab shopTab = ShopFrame.ShopTab.GetShopTab(this);
			if (shopTab != null && this.m_kDropdown != null && this.m_kDropdown.value >= 0 && this.m_kDropdown.value < this.m_kDropdown.options.Count)
			{
				ShopFrame.GoodOptionData goodOptionData = this.m_kDropdown.options[this.m_kDropdown.value] as ShopFrame.GoodOptionData;
				this.m_kGoodOptionData = goodOptionData;
				this.UpdateMallItemsByType();
				this.m_akGoodsDataItems.Filter(new object[]
				{
					shopTab.tab.ShopType,
					goodOptionData,
					this.GetShopTabFilter(shopTab.tab.ShopType)
				});
			}
			this._SortPage();
			this._OnPageItemCountChanged();
		}

		// Token: 0x060108A8 RID: 67752 RVA: 0x004AAC93 File Offset: 0x004A9093
		private void _OnPageItemCountChanged()
		{
		}

		// Token: 0x060108A9 RID: 67753 RVA: 0x004AAC98 File Offset: 0x004A9098
		private int GetEnabledCount()
		{
			int num = 0;
			foreach (KeyValuePair<ulong, ShopFrame.GoodsDataItem> keyValuePair in this.m_akGoodsDataItems.ActiveObjects)
			{
				ShopFrame.GoodsDataItem value = keyValuePair.Value;
				if (value != null && value.IsEnable())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x060108AA RID: 67754 RVA: 0x004AACF0 File Offset: 0x004A90F0
		private void _InitTabRefreshTime(ShopTable.eSubType eShopTab)
		{
			bool flag = false;
			int num = -1;
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.m_kShopData.ID.Value, string.Empty, string.Empty);
			if (tableItem != null && (tableItem.Refresh == 2 || tableItem.Refresh == 1) && tableItem.NeedRefreshTabs.Count == tableItem.SubType.Count && tableItem.SubType.Count == tableItem.RefreshCycle.Count)
			{
				for (int i = 0; i < tableItem.SubType.Count; i++)
				{
					if (tableItem.SubType[i] == eShopTab)
					{
						num = i;
						break;
					}
				}
			}
			if (num != -1 && tableItem.NeedRefreshTabs[num] == 1)
			{
				flag = true;
			}
			if (flag)
			{
				this.m_resetText.enabled = false;
				ShopTable.eRefreshCycle eRefreshCycle = tableItem.RefreshCycle[num];
				if (eRefreshCycle != ShopTable.eRefreshCycle.REFRESH_CYCLE_DAILY)
				{
					if (eRefreshCycle != ShopTable.eRefreshCycle.REFRESH_CYCLE_WEEK)
					{
						if (eRefreshCycle == ShopTable.eRefreshCycle.REFRESH_CYCLE_MONTH)
						{
							this.m_resetText.enabled = true;
							this.comTimeRefresh.Initialize();
							this.comTimeRefresh.Time = this.m_kShopData.MonthRefreshTime;
							this.comTimeRefresh.Enable = true;
						}
					}
					else
					{
						this.m_resetText.enabled = true;
						this.m_resetText.text = TR.Value("shop_refresh_week_hint");
						this.comTimeRefresh.Initialize();
						this.comTimeRefresh.Time = this.m_kShopData.WeekRefreshTime;
						this.comTimeRefresh.Enable = true;
					}
				}
				else
				{
					this.m_resetText.enabled = true;
					this.comTimeRefresh.Initialize();
					this.comTimeRefresh.Time = this.m_kShopData.RefreshTime;
					this.comTimeRefresh.Enable = true;
				}
			}
			else if (tableItem.Refresh == 1)
			{
				this.m_resetText.enabled = true;
				this.comTimeRefresh.Initialize();
				this.comTimeRefresh.Time = this.m_kShopData.RefreshTime;
				this.comTimeRefresh.Enable = true;
			}
			else
			{
				this.comTimeRefresh.Initialize();
				this.m_resetText.enabled = false;
			}
		}

		// Token: 0x060108AB RID: 67755 RVA: 0x004AAF3C File Offset: 0x004A933C
		private ShopTable.eFilter GetShopTabFilter(ShopTable.eSubType eShopTab)
		{
			ShopTable.eFilter result = ShopTable.eFilter.SF_NONE;
			if (this.m_kShopData != null)
			{
				ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.m_kShopData.ID.Value, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int num = -1;
					for (int i = 0; i < tableItem.SubType.Count; i++)
					{
						if (tableItem.SubType[i] == eShopTab)
						{
							num = i;
							break;
						}
					}
					if (num >= 0 && num < tableItem.Filter.Count)
					{
						result = tableItem.Filter[num];
					}
				}
			}
			return result;
		}

		// Token: 0x060108AC RID: 67756 RVA: 0x004AAFE0 File Offset: 0x004A93E0
		private void OnShopTabChanged(ShopTable.eSubType eShopTab)
		{
			this.m_akMoneyIds.Clear();
			this._SetFilter(this.GetShopTabFilter(eShopTab));
			List<GoodsData> list = this.m_kShopData.Goods.FindAll((GoodsData x) => x.Type == eShopTab);
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					this._TryToCreateMoneyObject(list[i].CostItemData.TableID);
				}
				if (this.m_kShopData.NeedRefresh != null && this.m_kShopData.NeedRefresh.Value == 1)
				{
					int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
					this._TryToCreateMoneyObject(moneyIDByType);
				}
			}
			this._TryAddExtraMoneyToTab((int)eShopTab, ref this.m_akMoneyIds);
			this.m_akMoneyItemObjects.RecycleAllObject();
			this.m_akMoneyIds.Sort(delegate(int x, int y)
			{
				ShopFrame.MoneySort moneySort = Array.Find<ShopFrame.MoneySort>(ShopFrame.ms_money_sorts, (ShopFrame.MoneySort target) => target.iId == x);
				ShopFrame.MoneySort moneySort2 = Array.Find<ShopFrame.MoneySort>(ShopFrame.ms_money_sorts, (ShopFrame.MoneySort target) => target.iId == y);
				if (moneySort == null != (moneySort2 == null))
				{
					return (moneySort != null) ? 1 : -1;
				}
				if (moneySort == null)
				{
					return x - y;
				}
				return moneySort.iOrder - moneySort2.iOrder;
			});
			this.m_akMoneyIds.ForEach(delegate(int money)
			{
				this.m_akMoneyItemObjects.Create(money, new object[]
				{
					this.m_goMoneyParent,
					this.m_goMoneyPrefab,
					money,
					(!ShopFrame.ms_money_show_name.ToList<int>().Contains(money)) ? MoneyBinder.MoneyShowType.MST_NORMAL : MoneyBinder.MoneyShowType.MST_MONEY_NAME,
					this
				});
			});
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenShopRefreshConsumeItem, this.m_akMoneyIds, null, null, null);
			this.UpdateMallItemsByType();
			this.m_akGoodsDataItems.Filter(new object[]
			{
				eShopTab,
				this.m_kGoodOptionData,
				this.GetShopTabFilter(eShopTab)
			});
			this._InitTabRefreshTime(eShopTab);
			this._CheckSetParticular(list);
			this._SortPage();
			this._OnPageItemCountChanged();
		}

		// Token: 0x060108AD RID: 67757 RVA: 0x004AB184 File Offset: 0x004A9584
		private void _CheckSetParticular(List<GoodsData> datas)
		{
			this.m_kHistroyRecord.enabled = false;
			for (int i = 0; i < datas.Count; i++)
			{
				if (datas[i].eGoodsLimitButyType == GoodsLimitButyType.GLBT_FIGHT_SCORE)
				{
					this.m_kHistroyRecord.enabled = true;
					int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
					string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(seasonLevel, true);
					this.m_kHistroyRecord.text = string.Format(TR.Value("shop_max_fight_score"), rankName);
					break;
				}
				if (datas[i].eGoodsLimitButyType == GoodsLimitButyType.GLBT_TOWER_LEVEL)
				{
					this.m_kHistroyRecord.enabled = true;
					int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
					this.m_kHistroyRecord.text = string.Format(TR.Value("shop_max_tower_level"), count);
					break;
				}
			}
		}

		// Token: 0x060108AE RID: 67758 RVA: 0x004AB260 File Offset: 0x004A9660
		private void _TryToCreateMoneyObject(int iTableID)
		{
			if (!this.m_akMoneyIds.Contains(iTableID))
			{
				this.m_akMoneyIds.Add(iTableID);
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(iTableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int i = 0; i < tableItem.RelationID.Count; i++)
					{
						if (tableItem.RelationID[i] > 0 && !this.m_akMoneyIds.Contains(tableItem.RelationID[i]))
						{
							this.m_akMoneyIds.Add(tableItem.RelationID[i]);
						}
					}
				}
			}
		}

		// Token: 0x060108AF RID: 67759 RVA: 0x004AB308 File Offset: 0x004A9708
		private void _TryAddExtraMoneyToTab(int iTab, ref List<int> MoneyIDs)
		{
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.m_kShopData.ID.Value, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string[] array = tableItem.ExtraShowMoneys.Split(new char[]
				{
					','
				});
				if (array.Length != tableItem.SubType.Count)
				{
					return;
				}
				int num = -1;
				for (int i = 0; i < tableItem.SubType.Count; i++)
				{
					if (iTab == (int)tableItem.SubType[i])
					{
						num = i;
						break;
					}
				}
				if (num == -1)
				{
					return;
				}
				string[] array2 = array[num].Split(new char[]
				{
					'|'
				});
				for (int j = 0; j < array2.Length; j++)
				{
					int num2 = 0;
					if (int.TryParse(array2[j], out num2))
					{
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num2, string.Empty, string.Empty);
						if (tableItem2 != null && !MoneyIDs.Contains(num2))
						{
							MoneyIDs.Add(num2);
						}
					}
				}
			}
		}

		// Token: 0x060108B0 RID: 67760 RVA: 0x004AB428 File Offset: 0x004A9828
		private void _InitShopTabs()
		{
			ShopFrame.ShopTab.CreateTab(this);
			GameObject gameObject = Utility.FindChild(this.frame, "middleback/MainTabChild");
			GameObject gameObject2 = Utility.FindChild(this.frame, "middleback/MainTabChild/Prefab");
			gameObject2.CustomActive(false);
			GameObject gameObject3 = Utility.FindChild(this.frame, "middleback/MainTab");
			GameObject gameObject4 = Utility.FindChild(this.frame, "middleback/MainTab/Prefab");
			gameObject4.CustomActive(false);
			this.m_kShopData.GoodsTypes.Sort((ShopTable.eSubType x, ShopTable.eSubType y) => x - y);
			for (int i = 0; i < this.m_kShopData.GoodsTypes.Count; i++)
			{
				if (this.m_eShopFrameMode != ShopFrame.ShopFrameMode.SFM_MAIN_FRAME)
				{
					this.m_akShopTabObjects.Create(this.m_kShopData.GoodsTypes[i], new object[]
					{
						gameObject,
						gameObject2,
						this.m_kShopData.GoodsTypes[i],
						this
					});
				}
				else
				{
					this.m_akShopTabObjects.Create(this.m_kShopData.GoodsTypes[i], new object[]
					{
						gameObject3,
						gameObject4,
						this.m_kShopData.GoodsTypes[i],
						this
					});
				}
			}
		}

		// Token: 0x060108B1 RID: 67761 RVA: 0x004AB583 File Offset: 0x004A9983
		private void _InitMoney()
		{
			this.m_goMoneyParent = Utility.FindChild(this.frame, "ComMoneys/Title/Moneys");
			this.m_goMoneyPrefab = Utility.FindChild(this.m_goMoneyParent, "MoneyObject");
			this.m_goMoneyPrefab.CustomActive(false);
			this._UpdateJarScore();
		}

		// Token: 0x060108B2 RID: 67762 RVA: 0x004AB5C4 File Offset: 0x004A99C4
		private void _UpdateJarScore()
		{
			ShopFrame.ShopFrameData shopFrameData = this.userData as ShopFrame.ShopFrameData;
			if (shopFrameData != null && shopFrameData.m_kShopData != null && this.jarScore != null)
			{
				this.jarScore.enabled = false;
				if (shopFrameData.m_kShopData.ID.Value == 8)
				{
					this.jarScore.text = TR.Value("jar_shop_gold_jar_score", DataManager<PlayerBaseData>.GetInstance().GoldJarScore);
					this.jarScore.enabled = true;
				}
				else if (shopFrameData.m_kShopData.ID.Value == 7)
				{
					this.jarScore.text = TR.Value("jar_shop_magic_jar_score", DataManager<PlayerBaseData>.GetInstance().MagicJarScore);
					this.jarScore.enabled = true;
				}
				this.jarScore.text = TR.Value("jar_shop_refresh_time");
			}
		}

		// Token: 0x060108B3 RID: 67763 RVA: 0x004AB6B4 File Offset: 0x004A9AB4
		private void _UpdateFriendlyHint()
		{
			bool bActive = false;
			ShopFrame.ShopFrameData shopFrameData = this.userData as ShopFrame.ShopFrameData;
			if (shopFrameData != null && shopFrameData.m_kShopData != null)
			{
				int num = (shopFrameData.m_kShopData.ID == null) ? 0 : shopFrameData.m_kShopData.ID.Value;
				bActive = (11 == num);
			}
			this.m_friendlyHint.CustomActive(bActive);
		}

		// Token: 0x060108B4 RID: 67764 RVA: 0x004AB720 File Offset: 0x004A9B20
		private void OnAddGoodsData(GoodsData data)
		{
			CachedObjectDicManager<ulong, ShopFrame.GoodsDataItem> akGoodsDataItems = this.m_akGoodsDataItems;
			int? id = data.ID;
			akGoodsDataItems.Create((ulong)((long)id.Value), new object[]
			{
				this.m_goGoodsDataParent,
				this.m_goGoodsDataPefabs,
				data,
				this
			});
		}

		// Token: 0x060108B5 RID: 67765 RVA: 0x004AB768 File Offset: 0x004A9B68
		private void _InitGoodsData()
		{
			if (this.m_iEnumerator != null)
			{
				base.StopCoroutine(this.m_iEnumerator);
				this.m_iEnumerator = null;
			}
			this.m_goGoodsDataParent = Utility.FindChild(this.frame, "middleback/Goods/Scroll View/Viewport/Content");
			this.m_goGoodsDataPefabs = Utility.FindChild(this.m_goGoodsDataParent, "Prefab");
			this.m_goGoodsDataPefabs.CustomActive(false);
			if (this.m_kShopData != null)
			{
				this.m_iEnumerator = base.StartCoroutine(this._AnsyCreateGoodsData());
			}
		}

		// Token: 0x060108B6 RID: 67766 RVA: 0x004AB7E8 File Offset: 0x004A9BE8
		private IEnumerator _AnsyCreateGoodsData()
		{
			ShopFrame.ComShopTab shopTab = ShopFrame.ShopTab.GetShopTab(this);
			this.m_kShopData.Goods.Sort(delegate(GoodsData x, GoodsData y)
			{
				if (this.m_iShopLinkID != 0 && x.ItemData.TableID == this.m_iShopLinkID != (y.ItemData.TableID == this.m_iShopLinkID))
				{
					return (x.ItemData.TableID != this.m_iShopLinkID) ? 1 : -1;
				}
				if (x.shopItem.SubType != y.shopItem.SubType)
				{
					if (this.m_iShopTabID != -1)
					{
						bool flag3 = x.shopItem.SubType == (ShopItemTable.eSubType)this.m_iShopTabID;
						bool flag4 = y.shopItem.SubType == (ShopItemTable.eSubType)this.m_iShopTabID;
						if (flag3 != flag4)
						{
							bool flag5 = x.shopItem.SubType == (ShopItemTable.eSubType)this.m_iShopTabID;
							return (!flag5) ? 1 : -1;
						}
					}
					return x.shopItem.SubType - y.shopItem.SubType;
				}
				return x.shopItem.SortID - y.shopItem.SortID;
			});
			yield return Yielders.EndOfFrame;
			if (this.m_kShopData.Goods.Count > 0)
			{
				ShopTable.eSubType? type = this.m_kShopData.Goods[0].Type;
				ShopTable.eSubType eCurrentTab = type.Value;
				this.m_akShopTabObjects.GetObject(eCurrentTab).OnSelected();
				ShopTable.eFilter Filter = this.GetShopTabFilter(eCurrentTab);
				this.m_akGoodsDataItems.RecycleAllObject();
				List<GoodsData> tempGoods = new List<GoodsData>();
				for (int i = 0; i < this.m_kShopData.Goods.Count; i++)
				{
					if (!(this.m_kShopData.Goods[i].Type != eCurrentTab))
					{
						ShopFrame.GoodOptionData optionData = null;
						if (this.m_kDropdown.value >= 0 && this.m_kDropdown.value < this.m_kDropdown.options.Count)
						{
							optionData = (this.m_kDropdown.options[this.m_kDropdown.value] as ShopFrame.GoodOptionData);
						}
						ItemTable item = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_kShopData.Goods[i].ItemData.TableID, string.Empty, string.Empty);
						if (item != null)
						{
							if (optionData != null)
							{
								if (Filter == ShopTable.eFilter.SF_OCCU)
								{
									if (item.Occu.Count > 0)
									{
										bool flag = false;
										for (int j = 0; j < item.Occu.Count; j++)
										{
											if (item.Occu[j] / 10 * 10 == optionData.jobItem.ID || item.Occu[j] == 0)
											{
												flag = true;
												break;
											}
										}
										if (!flag)
										{
											goto IL_40B;
										}
									}
								}
								else if (Filter == ShopTable.eFilter.SF_ARMOR)
								{
									if (optionData.eFilter != this.m_kShopData.Goods[i].ItemData.ThirdType)
									{
										goto IL_40B;
									}
								}
								else if (Filter == ShopTable.eFilter.SF_OCCU2 && item.Occu2.Count > 0)
								{
									bool flag2 = false;
									for (int k = 0; k < item.Occu2.Count; k++)
									{
										if (item.Occu2[k] == optionData.jobItem.ID)
										{
											flag2 = true;
											break;
										}
									}
									if (!flag2)
									{
										goto IL_40B;
									}
								}
							}
							this.OnAddGoodsData(this.m_kShopData.Goods[i]);
							yield return Yielders.EndOfFrame;
							yield return Yielders.EndOfFrame;
						}
					}
					IL_40B:;
				}
			}
			this._OnPageItemCountChanged();
			if (this.m_akGoodsDataItems.ActiveObjects.Count > 0)
			{
				if (this.m_iShopLinkID != 0)
				{
					foreach (KeyValuePair<ulong, ShopFrame.GoodsDataItem> keyValuePair in this.m_akGoodsDataItems.ActiveObjects)
					{
						if (keyValuePair.Value.GoodsData.ItemData.TableID == this.m_iShopLinkID)
						{
							keyValuePair.Value.OnClickBuy();
							break;
						}
					}
				}
				this.m_iShopLinkID = 0;
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x060108B7 RID: 67767 RVA: 0x004AB804 File Offset: 0x004A9C04
		private void _SortPage()
		{
			ShopFrame.GoodOptionData goodOptionData = null;
			if (this.m_kDropdown.value >= 0 && this.m_kDropdown.value < this.m_kDropdown.options.Count)
			{
				goodOptionData = (this.m_kDropdown.options[this.m_kDropdown.value] as ShopFrame.GoodOptionData);
			}
			ShopFrame.ComShopTab shopTab = ShopFrame.ShopTab.GetShopTab(this);
			if (shopTab.tab == null)
			{
				Logger.LogErrorFormat("tap selected is null!", new object[0]);
				return;
			}
			List<ShopFrame.GoodsDataItem> objectListByFilter = this.m_akGoodsDataItems.GetObjectListByFilter(new object[]
			{
				shopTab.tab.ShopType,
				goodOptionData,
				this.GetShopTabFilter(shopTab.tab.ShopType)
			});
			if (objectListByFilter != null)
			{
				objectListByFilter.Sort(delegate(ShopFrame.GoodsDataItem left, ShopFrame.GoodsDataItem right)
				{
					GoodsData goodsData = left.GoodsData;
					GoodsData goodsData2 = right.GoodsData;
					if (this.m_iShopLinkID != 0 && goodsData.ItemData.TableID == this.m_iShopLinkID != (goodsData2.ItemData.TableID == this.m_iShopLinkID))
					{
						return (goodsData.ItemData.TableID != this.m_iShopLinkID) ? 1 : -1;
					}
					if (goodsData.shopItem.SubType == goodsData2.shopItem.SubType)
					{
						return goodsData.shopItem.SortID - goodsData2.shopItem.SortID;
					}
					if (this.m_iShopTabID != -1)
					{
						return (goodsData.shopItem.SubType != (ShopItemTable.eSubType)this.m_iShopLinkID) ? 1 : -1;
					}
					return goodsData.shopItem.SubType - goodsData2.shopItem.SubType;
				});
				for (int i = 0; i < objectListByFilter.Count; i++)
				{
					objectListByFilter[i].SetAsLastSibling();
				}
			}
		}

		// Token: 0x060108B8 RID: 67768 RVA: 0x004AB908 File Offset: 0x004A9D08
		private void _OnGoodsClicked(GoodsData goodsData)
		{
			if (!this.frameMgr.IsFrameOpen<PurchaseCommonFrame>(null))
			{
				this.frameMgr.OpenFrame<PurchaseCommonFrame>(FrameLayer.Middle, null, string.Empty);
			}
			UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
			if (idleUIEvent != null)
			{
				idleUIEvent.EventID = EUIEventID.PurchaseCommanUpdate;
				idleUIEvent.EventParams.kPurchaseCommonData.iShopID = ((this.m_kShopData.ID == null) ? 0 : this.m_kShopData.ID.Value);
				idleUIEvent.EventParams.kPurchaseCommonData.iGoodID = ((goodsData.ID == null) ? 0 : goodsData.ID.Value);
				idleUIEvent.EventParams.kPurchaseCommonData.iItemID = goodsData.ItemData.TableID;
				idleUIEvent.EventParams.kPurchaseCommonData.iCount = goodsData.ItemData.Count;
				UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
			}
		}

		// Token: 0x060108B9 RID: 67769 RVA: 0x004ABA04 File Offset: 0x004A9E04
		private void UpdateMallItemsByType()
		{
			ShopFrame.ComShopTab shopTab = ShopFrame.ShopTab.GetShopTab(this);
			if (shopTab == null)
			{
				return;
			}
			if (this.m_kShopData.Goods.Count <= 0)
			{
				return;
			}
			ShopFrame.GoodOptionData goodOptionData = null;
			if (this.m_kDropdown.value >= 0 && this.m_kDropdown.value < this.m_kDropdown.options.Count)
			{
				goodOptionData = (this.m_kDropdown.options[this.m_kDropdown.value] as ShopFrame.GoodOptionData);
			}
			ShopTable.eFilter shopTabFilter = this.GetShopTabFilter(shopTab.tab.ShopType);
			for (int i = 0; i < this.m_kShopData.Goods.Count; i++)
			{
				if (!(this.m_kShopData.Goods[i].Type != shopTab.tab.ShopType))
				{
					int? id = this.m_kShopData.Goods[i].ID;
					if (id != null)
					{
						if (!this.m_akGoodsDataItems.HasObject((ulong)((long)id.Value)))
						{
							ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_kShopData.Goods[i].ItemData.TableID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								if (goodOptionData != null)
								{
									if (shopTabFilter == ShopTable.eFilter.SF_OCCU)
									{
										if (tableItem.Occu.Count > 0)
										{
											bool flag = false;
											for (int j = 0; j < tableItem.Occu.Count; j++)
											{
												if (tableItem.Occu[j] / 10 * 10 == goodOptionData.jobItem.ID || tableItem.Occu[j] == 0)
												{
													flag = true;
													break;
												}
											}
											if (!flag)
											{
												goto IL_2AB;
											}
										}
									}
									else if (shopTabFilter == ShopTable.eFilter.SF_ARMOR)
									{
										if (goodOptionData.eFilter != this.m_kShopData.Goods[i].ItemData.ThirdType)
										{
											goto IL_2AB;
										}
									}
									else if (shopTabFilter == ShopTable.eFilter.SF_OCCU2 && tableItem.Occu2.Count > 0)
									{
										bool flag2 = false;
										for (int k = 0; k < tableItem.Occu2.Count; k++)
										{
											if (tableItem.Occu2[k] == goodOptionData.jobItem.ID)
											{
												flag2 = true;
												break;
											}
										}
										if (!flag2)
										{
											goto IL_2AB;
										}
									}
								}
								this.OnAddGoodsData(this.m_kShopData.Goods[i]);
							}
						}
					}
				}
				IL_2AB:;
			}
		}

		// Token: 0x060108BA RID: 67770 RVA: 0x004ABCD8 File Offset: 0x004AA0D8
		protected void _InitRefreshItems()
		{
			this.m_friendlyHint = Utility.FindComponent<Text>(this.frame, "middleback/Goods/FriendlyHint", true);
			this.m_refreshBtn = Utility.FindComponent<Button>(this.frame, "middleback/Goods/Title/BtnRefresh", true);
			this.m_grayRefresh = this.m_refreshBtn.GetComponent<UIGray>();
			this.m_refreshText = Utility.FindComponent<Text>(this.frame, "middleback/Goods/Title/BtnRefresh/gold", true);
			this.m_colOrg = this.m_refreshText.color;
			this.m_refreshPrefixed = Utility.FindComponent<Text>(this.frame, "middleback/Goods/Title/BtnRefresh/text", true);
			this.m_resetText = Utility.FindComponent<Text>(this.frame, "middleback/Goods/Title/RefreshTime", true);
			this.m_resetText.enabled = false;
			this.m_refreshTimes = Utility.FindComponent<Text>(this.frame, "middleback/Goods/RefreshTimeRoot/RefreshTimes", true);
			this.m_refreshBtn.onClick.RemoveAllListeners();
			this.m_refreshBtn.onClick.AddListener(delegate()
			{
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
				if (this.m_kShopData.RefreshCost.Value <= 0)
				{
					ShopDataManager instance = DataManager<ShopDataManager>.GetInstance();
					int? id = this.m_kShopData.ID;
					instance.RefreshShop(id.Value);
				}
				else
				{
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
					{
						nMoneyID = moneyIDByType,
						nCount = this.m_kShopData.RefreshCost.Value
					}, delegate
					{
						ShopDataManager instance2 = DataManager<ShopDataManager>.GetInstance();
						int? id2 = this.m_kShopData.ID;
						instance2.RefreshShop(id2.Value);
					}, "common_money_cost", null);
				}
			});
		}

		// Token: 0x060108BB RID: 67771 RVA: 0x004ABDCC File Offset: 0x004AA1CC
		private void _InitHelpAssistant()
		{
			GameObject gameObject = Utility.FindChild(this.frame, "ComWnd/Title/Horizen/Help");
			if (null != gameObject)
			{
				ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.m_kShopData.ID.Value, string.Empty, string.Empty);
				if (tableItem != null && tableItem.HelpID > 0)
				{
					HelpAssistant helpAssistant = gameObject.GetComponent<HelpAssistant>();
					if (null == helpAssistant)
					{
						helpAssistant = gameObject.AddComponent<HelpAssistant>();
					}
					if (null != helpAssistant)
					{
						helpAssistant.eType = (HelpFrame.HelpType)tableItem.HelpID;
					}
					gameObject.CustomActive(true);
				}
				else
				{
					gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x060108BC RID: 67772 RVA: 0x004ABE74 File Offset: 0x004AA274
		protected void _RefreshButton()
		{
			if (this.m_kShopData.RefreshCost.Value > 0)
			{
				this.m_kRefreshBinder.ChangeStatus(1);
			}
			else
			{
				this.m_kRefreshBinder.ChangeStatus(2);
			}
			if (this.m_kShopData.NeedRefresh != 0)
			{
				this.m_refreshTimes.CustomActive(this.m_kShopData.NeedRefresh == 1);
				this.m_refreshBtn.CustomActive(this.m_kShopData.NeedRefresh == 1 || this.m_kShopData.NeedRefresh == 3);
				if (this.m_refreshText != null)
				{
					this.m_refreshText.text = this.m_kShopData.RefreshCost.ToString();
					int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
					if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, true) >= this.m_kShopData.RefreshCost)
					{
						this.m_refreshText.color = this.m_colOrg;
					}
					else
					{
						this.m_refreshText.color = Color.red;
					}
					if (this.m_refreshPrefixed != null)
					{
						this.m_refreshPrefixed.color = this.m_refreshText.color;
					}
				}
				this.m_refreshTimes.text = string.Format(TR.Value((this.m_kShopData.RefreshLeftTimes <= 0) ? "shop_refresh_time_disable" : "shop_refresh_time_enable"), this.m_kShopData.RefreshLeftTimes, this.m_kShopData.RefreshTotalTimes);
				this.m_refreshTimes.enabled = true;
				this.m_refreshBtn.enabled = (this.m_kShopData.RefreshLeftTimes > 0);
				this.m_grayRefresh.enabled = !this.m_refreshBtn.enabled;
			}
			else
			{
				this.m_refreshTimes.enabled = false;
				this.m_refreshBtn.CustomActive(false);
				this.m_refreshTimes.CustomActive(false);
			}
		}

		// Token: 0x060108BD RID: 67773 RVA: 0x004AC0E4 File Offset: 0x004AA4E4
		private void _OnVipLvChanged(UIEvent uiEvent)
		{
			if (this.m_kShopData.NeedRefresh == 1)
			{
				SceneShopRefreshNumReq sceneShopRefreshNumReq = new SceneShopRefreshNumReq();
				sceneShopRefreshNumReq.shopId = (byte)this.m_kShopData.ID.Value;
				NetManager.Instance().SendCommand<SceneShopRefreshNumReq>(ServerType.GATE_SERVER, sceneShopRefreshNumReq);
				Logger.LogErrorFormat("send refresh shopid = {0}", new object[]
				{
					sceneShopRefreshNumReq.shopId
				});
				DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneShopRefreshNumRes>(delegate(SceneShopRefreshNumRes msgRet)
				{
					ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop((int)msgRet.shopId);
					if (goodsDataFromShop != null)
					{
						goodsDataFromShop.RefreshLeftTimes = (int)msgRet.restRefreshNum;
						goodsDataFromShop.RefreshTotalTimes = (int)msgRet.maxRefreshNum;
						Logger.LogErrorFormat("shop refresh times changed lefttimes = {0} , maxTimes = {1}", new object[]
						{
							msgRet.restRefreshNum,
							msgRet.maxRefreshNum
						});
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ShopRefreshTimesChanged, goodsDataFromShop.ID.Value, null, null, null);
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x060108BE RID: 67774 RVA: 0x004AC190 File Offset: 0x004AA590
		protected void _ControlRefreshTime(ShopTable.eSubType eShopTab)
		{
			bool enabled = false;
			if (this.m_kShopData.NeedRefresh != 0)
			{
				ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.m_kShopData.ID.Value, string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int i = 0; i < tableItem.SubType.Count; i++)
					{
						if (tableItem.SubType[i] == eShopTab)
						{
							enabled = (tableItem.NeedRefreshTabs[i] == 1);
							break;
						}
					}
				}
			}
			this.m_resetText.enabled = enabled;
		}

		// Token: 0x060108BF RID: 67775 RVA: 0x004AC241 File Offset: 0x004AA641
		private void _OnAddVipTimes()
		{
			SystemNotifyManager.SystemNotify(7004, new UnityAction(this._OnAddVipOk));
		}

		// Token: 0x060108C0 RID: 67776 RVA: 0x004AC25C File Offset: 0x004AA65C
		private void _OnAddVipOk()
		{
			VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
			if (vipFrame != null)
			{
				vipFrame.OpenPayTab();
			}
		}

		// Token: 0x060108C1 RID: 67777 RVA: 0x004AC28C File Offset: 0x004AA68C
		protected override void _OnOpenFrame()
		{
			this.m_iEnumerator = null;
			ShopFrame.ShopFrameData shopFrameData = this.userData as ShopFrame.ShopFrameData;
			this.m_kShopData = shopFrameData.m_kShopData;
			this.m_iShopLinkID = shopFrameData.m_iShopLinkID;
			this.m_iShopTabID = shopFrameData.m_iShopTabID;
			StateController component = this.frame.GetComponent<StateController>();
			this.m_eShopFrameMode = shopFrameData.eShopFrameMode;
			component.Key = this.m_eShopFrameMode.ToString();
			this.m_kShopName = Utility.FindComponent<Text>(this.frame, "ComWnd/Title/Horizen/Name", true);
			this.m_kShopName.text = this.m_kShopData.Name;
			this.btnVipAddTimes = Utility.FindComponent<Button>(this.frame, "middleback/Goods/RefreshTimeRoot/RefreshTimes/BtnAddTimes", true);
			this.btnVipAddTimes.onClick.AddListener(new UnityAction(this._OnAddVipTimes));
			this._PlayNpcSound(NpcVoiceComponent.SoundEffectType.SET_Start);
			this._InitRefreshItems();
			this._InitDropDown();
			this._InitMoney();
			this._InitShopTabs();
			this._InitGoodsData();
			this._RefreshButton();
			this._InitHelpAssistant();
			this._UpdateFriendlyHint();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopRefreshSuccess, new ClientEventSystem.UIEventHandler(this._RebuildAllObjects));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopRefreshTimesChanged, new ClientEventSystem.UIEventHandler(this._OnShopRefreshTimesChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this._OnVipLvChanged));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x060108C2 RID: 67778 RVA: 0x004AC4AD File Offset: 0x004AA8AD
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._UpdateJarScore();
			this._RefreshAllObjects();
		}

		// Token: 0x060108C3 RID: 67779 RVA: 0x004AC4BC File Offset: 0x004AA8BC
		private void _OnShopRefreshTimesChanged(UIEvent uiEvent)
		{
			Logger.LogErrorFormat("event param1 = {0}", new object[]
			{
				(int)uiEvent.Param1
			});
			if (this.m_kShopData.ID.Value == (int)uiEvent.Param1)
			{
				Logger.LogErrorFormat("_OnShopRefreshTimesChanged Invoke succeed !", new object[0]);
				this._RefreshButton();
			}
		}

		// Token: 0x060108C4 RID: 67780 RVA: 0x004AC524 File Offset: 0x004AA924
		protected override void _OnCloseFrame()
		{
			this._PlayNpcSound(NpcVoiceComponent.SoundEffectType.SET_End);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
			ShopFrame.ShopTab.Clear(this, true);
			this.m_akShopTabObjects.Clear();
			this.m_akMoneyItemObjects.Clear();
			this.m_akMoneyIds.Clear();
			this.m_akGoodsDataItems.DestroyAllObjects();
			if (this.btnVipAddTimes != null)
			{
				this.btnVipAddTimes.onClick.RemoveAllListeners();
				this.btnVipAddTimes = null;
			}
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopRefreshSuccess, new ClientEventSystem.UIEventHandler(this._RebuildAllObjects));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopRefreshTimesChanged, new ClientEventSystem.UIEventHandler(this._OnShopRefreshTimesChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this._OnVipLvChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance4 = DataManager<ItemDataManager>.GetInstance();
			instance4.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance4.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			this.m_kShopData = null;
		}

		// Token: 0x060108C5 RID: 67781 RVA: 0x004AC6B1 File Offset: 0x004AAAB1
		private void OnAddNewItem(List<Item> items)
		{
			this._RefreshAllObjects();
		}

		// Token: 0x060108C6 RID: 67782 RVA: 0x004AC6B9 File Offset: 0x004AAAB9
		private void OnUpdateItem(List<Item> items)
		{
			this._RefreshAllObjects();
		}

		// Token: 0x060108C7 RID: 67783 RVA: 0x004AC6C1 File Offset: 0x004AAAC1
		private void OnRemoveItem(ItemData data)
		{
			this._RefreshAllObjects();
		}

		// Token: 0x060108C8 RID: 67784 RVA: 0x004AC6C9 File Offset: 0x004AAAC9
		private void _RereshAllGoods(UIEvent uiEvent)
		{
			this._RefreshAllObjects();
		}

		// Token: 0x060108C9 RID: 67785 RVA: 0x004AC6D1 File Offset: 0x004AAAD1
		private void _RefreshAllObjects()
		{
			this.m_akGoodsDataItems.RefreshAllObjects(null);
		}

		// Token: 0x060108CA RID: 67786 RVA: 0x004AC6DF File Offset: 0x004AAADF
		private void _RebuildAllObjects(UIEvent uiEvent)
		{
			this.m_akGoodsDataItems.RecycleAllObject();
			ShopFrame.ShopTab.Clear(this, false);
			this._InitGoodsData();
			this._RefreshButton();
		}

		// Token: 0x060108CB RID: 67787 RVA: 0x004AC700 File Offset: 0x004AAB00
		[UIEventHandle("ComWnd/Title/Close")]
		private void _OnReturnClicked()
		{
			ShopFrame.ShopFrameData shopFrameData = this.userData as ShopFrame.ShopFrameData;
			if (shopFrameData.onShopReturn != null)
			{
				shopFrameData.onShopReturn();
			}
			this.frameMgr.CloseFrame<ShopFrame>(this, false);
		}

		// Token: 0x0400A867 RID: 43111
		public static ShopFrame.MoneySort[] ms_money_sorts = new ShopFrame.MoneySort[]
		{
			new ShopFrame.MoneySort
			{
				iId = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT),
				iOrder = 1
			},
			new ShopFrame.MoneySort
			{
				iId = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT),
				iOrder = 2
			},
			new ShopFrame.MoneySort
			{
				iId = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD),
				iOrder = 3
			},
			new ShopFrame.MoneySort
			{
				iId = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD),
				iOrder = 4
			},
			new ShopFrame.MoneySort
			{
				iId = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.MagicJarPoint),
				iOrder = 1
			},
			new ShopFrame.MoneySort
			{
				iId = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GoldJarPoint),
				iOrder = 2
			}
		};

		// Token: 0x0400A868 RID: 43112
		public static int[] ms_money_show_name = new int[]
		{
			600000064,
			600000065
		};

		// Token: 0x0400A869 RID: 43113
		private ItemTable.eThirdType[] armorLists = new ItemTable.eThirdType[]
		{
			ItemTable.eThirdType.CLOTH,
			ItemTable.eThirdType.SKIN,
			ItemTable.eThirdType.LIGHT,
			ItemTable.eThirdType.HEAVY,
			ItemTable.eThirdType.PLATE
		};

		// Token: 0x0400A86A RID: 43114
		private string[] armorNames = new string[]
		{
			TR.Value("goldjar_sub_type_cloth"),
			TR.Value("goldjar_sub_type_skin"),
			TR.Value("goldjar_sub_type_lightd"),
			TR.Value("goldjar_sub_type_heavy"),
			TR.Value("goldjar_sub_type_plate")
		};

		// Token: 0x0400A86B RID: 43115
		[UIControl("middleback/Goods/Title/BtnRefresh", typeof(StatusBinder), 0)]
		private StatusBinder m_kRefreshBinder;

		// Token: 0x0400A86C RID: 43116
		private ShopData m_kShopData;

		// Token: 0x0400A86D RID: 43117
		private int m_iShopLinkID;

		// Token: 0x0400A86E RID: 43118
		private int m_iShopTabID;

		// Token: 0x0400A86F RID: 43119
		private ShopFrame.ShopFrameMode m_eShopFrameMode;

		// Token: 0x0400A870 RID: 43120
		private Text m_kShopName;

		// Token: 0x0400A871 RID: 43121
		private Dropdown m_kDropdown;

		// Token: 0x0400A872 RID: 43122
		[UIControl("middleback/Goods/JarScore", typeof(Text), 0)]
		private Text jarScore;

		// Token: 0x0400A873 RID: 43123
		private bool m_bNeedMod;

		// Token: 0x0400A874 RID: 43124
		private DOTweenAnimation m_animation;

		// Token: 0x0400A875 RID: 43125
		private float m_fPreValue;

		// Token: 0x0400A876 RID: 43126
		private GameObject m_goPointArray;

		// Token: 0x0400A877 RID: 43127
		private GameObject m_goArrowLeft;

		// Token: 0x0400A878 RID: 43128
		private GameObject m_goArrowRight;

		// Token: 0x0400A879 RID: 43129
		private GameObject m_goScrollView;

		// Token: 0x0400A87A RID: 43130
		private float m_fScrollViewWidth;

		// Token: 0x0400A87B RID: 43131
		private int m_iCurrentPage;

		// Token: 0x0400A87C RID: 43132
		private int m_iMaxPage;

		// Token: 0x0400A87D RID: 43133
		private int m_iPageCount;

		// Token: 0x0400A87E RID: 43134
		private float m_fCurMod;

		// Token: 0x0400A87F RID: 43135
		private int m_iCurGoodsCount;

		// Token: 0x0400A880 RID: 43136
		private TimeRefresh comTimeRefresh;

		// Token: 0x0400A881 RID: 43137
		private ShopFrame.GoodOptionData m_kGoodOptionData;

		// Token: 0x0400A882 RID: 43138
		private Text m_kHistroyRecord;

		// Token: 0x0400A883 RID: 43139
		private CachedObjectDicManager<ShopTable.eSubType, ShopFrame.ShopTab> m_akShopTabObjects = new CachedObjectDicManager<ShopTable.eSubType, ShopFrame.ShopTab>();

		// Token: 0x0400A884 RID: 43140
		private ShopTable.eSubType m_eGoodType;

		// Token: 0x0400A885 RID: 43141
		private CachedObjectDicManager<int, ShopFrame.MoneyItemObject> m_akMoneyItemObjects = new CachedObjectDicManager<int, ShopFrame.MoneyItemObject>();

		// Token: 0x0400A886 RID: 43142
		private List<int> m_akMoneyIds = new List<int>();

		// Token: 0x0400A887 RID: 43143
		private GameObject m_goMoneyParent;

		// Token: 0x0400A888 RID: 43144
		private GameObject m_goMoneyPrefab;

		// Token: 0x0400A889 RID: 43145
		private GameObject m_goGoodsDataParent;

		// Token: 0x0400A88A RID: 43146
		private GameObject m_goGoodsDataPefabs;

		// Token: 0x0400A88B RID: 43147
		private CachedObjectDicManager<ulong, ShopFrame.GoodsDataItem> m_akGoodsDataItems = new CachedObjectDicManager<ulong, ShopFrame.GoodsDataItem>();

		// Token: 0x0400A88C RID: 43148
		private IEnumerator m_iEnumerator;

		// Token: 0x0400A88D RID: 43149
		private Button m_refreshBtn;

		// Token: 0x0400A88E RID: 43150
		private UIGray m_grayRefresh;

		// Token: 0x0400A88F RID: 43151
		private Text m_refreshText;

		// Token: 0x0400A890 RID: 43152
		private Text m_refreshPrefixed;

		// Token: 0x0400A891 RID: 43153
		private Text m_resetText;

		// Token: 0x0400A892 RID: 43154
		private Text m_refreshTimes;

		// Token: 0x0400A893 RID: 43155
		private Color m_colOrg;

		// Token: 0x0400A894 RID: 43156
		private Text m_friendlyHint;

		// Token: 0x0400A895 RID: 43157
		private Button btnVipAddTimes;

		// Token: 0x02001A51 RID: 6737
		public enum ShopFrameMode
		{
			// Token: 0x0400A89A RID: 43162
			SFM_MAIN_FRAME,
			// Token: 0x0400A89B RID: 43163
			SFM_CHILD_FRAME,
			// Token: 0x0400A89C RID: 43164
			SFM_GUILD_CHILD_FRAME,
			// Token: 0x0400A89D RID: 43165
			SFM_MALL_CHILD_FRAME,
			// Token: 0x0400A89E RID: 43166
			SFM_QUERY_NON_FRAME
		}

		// Token: 0x02001A52 RID: 6738
		public class MoneySort
		{
			// Token: 0x0400A89F RID: 43167
			public int iId;

			// Token: 0x0400A8A0 RID: 43168
			public int iOrder;
		}

		// Token: 0x02001A53 RID: 6739
		// (Invoke) Token: 0x060108D5 RID: 67797
		public delegate void OnShopReturn();

		// Token: 0x02001A54 RID: 6740
		public class ShopFrameData
		{
			// Token: 0x0400A8A1 RID: 43169
			public ShopData m_kShopData;

			// Token: 0x0400A8A2 RID: 43170
			public int m_iShopLinkID;

			// Token: 0x0400A8A3 RID: 43171
			public int m_iShopTabID;

			// Token: 0x0400A8A4 RID: 43172
			public ShopFrame.OnShopReturn onShopReturn;

			// Token: 0x0400A8A5 RID: 43173
			public ShopFrame.ShopFrameMode eShopFrameMode;
		}

		// Token: 0x02001A55 RID: 6741
		public enum PageConfig
		{
			// Token: 0x0400A8A7 RID: 43175
			PC_COUNT = 8,
			// Token: 0x0400A8A8 RID: 43176
			PC_HALF = 4
		}

		// Token: 0x02001A56 RID: 6742
		public class GoodOptionData : Dropdown.OptionData
		{
			// Token: 0x0400A8A9 RID: 43177
			public JobTable jobItem;

			// Token: 0x0400A8AA RID: 43178
			public ItemTable.eThirdType eFilter;
		}

		// Token: 0x02001A57 RID: 6743
		private class ComShopTab
		{
			// Token: 0x0400A8AB RID: 43179
			public IClientFrame target;

			// Token: 0x0400A8AC RID: 43180
			public ShopFrame.ShopTab tab;
		}

		// Token: 0x02001A58 RID: 6744
		private class ShopTab : CachedObject
		{
			// Token: 0x17001D54 RID: 7508
			// (get) Token: 0x060108DC RID: 67804 RVA: 0x004ACB2A File Offset: 0x004AAF2A
			public ShopTable.eSubType ShopTabType
			{
				get
				{
					return this.eShopTab;
				}
			}

			// Token: 0x060108DD RID: 67805 RVA: 0x004ACB32 File Offset: 0x004AAF32
			public override void OnDestroy()
			{
				if (this.toggle != null)
				{
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle = null;
				}
			}

			// Token: 0x17001D55 RID: 7509
			// (get) Token: 0x060108DE RID: 67806 RVA: 0x004ACB5C File Offset: 0x004AAF5C
			public ShopTable.eSubType ShopType
			{
				get
				{
					return this.eShopTab;
				}
			}

			// Token: 0x060108DF RID: 67807 RVA: 0x004ACB64 File Offset: 0x004AAF64
			public static ShopFrame.ComShopTab GetShopTab(IClientFrame target)
			{
				return ShopFrame.ShopTab.ms_akSelectedTabs.Find((ShopFrame.ComShopTab x) => x.target == target);
			}

			// Token: 0x060108E0 RID: 67808 RVA: 0x004ACB98 File Offset: 0x004AAF98
			public static void CreateTab(IClientFrame target)
			{
				if (ShopFrame.ShopTab.GetShopTab(target) == null)
				{
					ShopFrame.ComShopTab comShopTab = new ShopFrame.ComShopTab();
					comShopTab.tab = null;
					comShopTab.target = target;
					ShopFrame.ShopTab.ms_akSelectedTabs.Add(comShopTab);
				}
			}

			// Token: 0x060108E1 RID: 67809 RVA: 0x004ACBD4 File Offset: 0x004AAFD4
			public static void Clear(IClientFrame target, bool bRemove = false)
			{
				ShopFrame.ComShopTab shopTab = ShopFrame.ShopTab.GetShopTab(target);
				if (shopTab != null)
				{
					if (shopTab.tab != null)
					{
						shopTab.tab.SetSelected(false);
						shopTab.tab = null;
					}
					if (bRemove)
					{
						shopTab.target = null;
					}
				}
			}

			// Token: 0x060108E2 RID: 67810 RVA: 0x004ACC1C File Offset: 0x004AB01C
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.eShopTab = (ShopTable.eSubType)param[2];
				this.frame = (param[3] as ShopFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.toggle = this.goLocal.GetComponent<Toggle>();
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this.OnSelected();
						}
					});
					this.label = Utility.FindComponent<Text>(this.goLocal, "Label", true);
					this.labelCheck = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Label", true);
					Text text = this.label;
					string text2 = TR.Value(string.Format(TR.Value("shop_tab_format"), (int)this.eShopTab));
					this.labelCheck.text = text2;
					text.text = text2;
					this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x060108E3 RID: 67811 RVA: 0x004ACD4A File Offset: 0x004AB14A
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060108E4 RID: 67812 RVA: 0x004ACD69 File Offset: 0x004AB169
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x060108E5 RID: 67813 RVA: 0x004ACD72 File Offset: 0x004AB172
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x060108E6 RID: 67814 RVA: 0x004ACD7A File Offset: 0x004AB17A
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x060108E7 RID: 67815 RVA: 0x004ACD99 File Offset: 0x004AB199
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060108E8 RID: 67816 RVA: 0x004ACDB8 File Offset: 0x004AB1B8
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x060108E9 RID: 67817 RVA: 0x004ACDBB File Offset: 0x004AB1BB
			private void _Update()
			{
			}

			// Token: 0x060108EA RID: 67818 RVA: 0x004ACDBD File Offset: 0x004AB1BD
			private void SetSelected(bool bSelected)
			{
				this.goCheckMark.CustomActive(bSelected);
			}

			// Token: 0x060108EB RID: 67819 RVA: 0x004ACDCC File Offset: 0x004AB1CC
			public void OnSelected()
			{
				ShopFrame.ComShopTab shopTab = ShopFrame.ShopTab.GetShopTab(this.frame);
				if (this != shopTab.tab)
				{
					if (shopTab.tab != null)
					{
						shopTab.tab.SetSelected(false);
					}
					shopTab.tab = this;
					this.SetSelected(true);
				}
				this.frame.OnShopTabChanged(this.eShopTab);
			}

			// Token: 0x0400A8AD RID: 43181
			private GameObject goLocal;

			// Token: 0x0400A8AE RID: 43182
			private GameObject goPrefab;

			// Token: 0x0400A8AF RID: 43183
			private GameObject goParent;

			// Token: 0x0400A8B0 RID: 43184
			private ShopTable.eSubType eShopTab;

			// Token: 0x0400A8B1 RID: 43185
			private ShopFrame frame;

			// Token: 0x0400A8B2 RID: 43186
			private Toggle toggle;

			// Token: 0x0400A8B3 RID: 43187
			private Text label;

			// Token: 0x0400A8B4 RID: 43188
			private Text labelCheck;

			// Token: 0x0400A8B5 RID: 43189
			private GameObject goCheckMark;

			// Token: 0x0400A8B6 RID: 43190
			public static List<ShopFrame.ComShopTab> ms_akSelectedTabs = new List<ShopFrame.ComShopTab>();
		}

		// Token: 0x02001A59 RID: 6745
		private class MoneyItemObject : CachedObject
		{
			// Token: 0x060108EF RID: 67823 RVA: 0x004ACE64 File Offset: 0x004AB264
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.iTableID = (int)param[2];
				this.eMoneyBinder = (MoneyBinder.MoneyShowType)param[3];
				this.frame = (param[4] as ShopFrame);
				this.itemData = ItemDataManager.CreateItemDataFromTable(this.iTableID, 100, 0);
				this.bLocked = false;
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.kIcon = Utility.FindComponent<Image>(this.goLocal, "Icon", true);
					this.kNum = Utility.FindComponent<Text>(this.goLocal, "Cnt", true);
					this.kName = Utility.FindComponent<Text>(this.goLocal, "Name", true);
					this.comItemLink = Utility.FindComponent<ItemComeLink>(this.goLocal, "Add", true);
					this.comItemLink.bNotEnough = false;
					ItemComeLink itemComeLink = this.comItemLink;
					itemComeLink.onClick = (ComLinkFrame.OnClick)Delegate.Combine(itemComeLink.onClick, new ComLinkFrame.OnClick(this._OnClick));
					this.btnCoinTips = Utility.FindComponent<Button>(this.goLocal, "btnCoinTips", true);
					this.btnCoinTips.onClick.RemoveAllListeners();
					this.btnCoinTips.onClick.AddListener(delegate()
					{
						if (this.itemData != null && !this.bLocked)
						{
							DataManager<ItemTipManager>.GetInstance().CloseAll();
							DataManager<ItemTipManager>.GetInstance().ShowTip(this.itemData, null, 4, true, false, true);
							this.bLocked = true;
							InvokeMethod.Invoke(this, 0.3f, new UnityAction(this._UnLock));
						}
					});
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x060108F0 RID: 67824 RVA: 0x004ACFE4 File Offset: 0x004AB3E4
			private void _UnLock()
			{
				this.bLocked = false;
			}

			// Token: 0x060108F1 RID: 67825 RVA: 0x004ACFF0 File Offset: 0x004AB3F0
			private void _OnClick()
			{
				if (this.frame != null)
				{
					switch (this.frame.EShopFrameMode)
					{
					case ShopFrame.ShopFrameMode.SFM_MAIN_FRAME:
						this.frame.Close(false);
						break;
					case ShopFrame.ShopFrameMode.SFM_CHILD_FRAME:
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ShopMainFrameClose, null, null, null, null);
						break;
					case ShopFrame.ShopFrameMode.SFM_GUILD_CHILD_FRAME:
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ShopGuildFrameClose, null, null, null, null);
						break;
					case ShopFrame.ShopFrameMode.SFM_MALL_CHILD_FRAME:
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ShopMallFrameClose, null, null, null, null);
						break;
					}
				}
			}

			// Token: 0x060108F2 RID: 67826 RVA: 0x004AD088 File Offset: 0x004AB488
			public override void OnDestroy()
			{
				ItemComeLink itemComeLink = this.comItemLink;
				itemComeLink.onClick = (ComLinkFrame.OnClick)Delegate.Remove(itemComeLink.onClick, new ComLinkFrame.OnClick(this._OnClick));
				this.btnCoinTips.onClick.RemoveAllListeners();
				this.btnCoinTips = null;
				InvokeMethod.RemoveInvokeCall(this);
				this.bLocked = false;
			}

			// Token: 0x060108F3 RID: 67827 RVA: 0x004AD0E0 File Offset: 0x004AB4E0
			public override void OnRecycle()
			{
				InvokeMethod.RemoveInvokeCall(this);
				this.bLocked = false;
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060108F4 RID: 67828 RVA: 0x004AD10C File Offset: 0x004AB50C
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x060108F5 RID: 67829 RVA: 0x004AD115 File Offset: 0x004AB515
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x060108F6 RID: 67830 RVA: 0x004AD11D File Offset: 0x004AB51D
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x060108F7 RID: 67831 RVA: 0x004AD13C File Offset: 0x004AB53C
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060108F8 RID: 67832 RVA: 0x004AD15C File Offset: 0x004AB55C
			public override bool NeedFilter(object[] param)
			{
				List<GoodsData> list = param[0] as List<GoodsData>;
				if (list != null)
				{
					GoodsData goodsData = list.Find(delegate(GoodsData x)
					{
						if (x.CostItemData.TableID == this.iTableID)
						{
							return true;
						}
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(x.CostItemData.TableID, string.Empty, string.Empty);
						return tableItem != null && tableItem.RelationID.Contains(this.iTableID);
					});
					return goodsData == null;
				}
				return true;
			}

			// Token: 0x060108F9 RID: 67833 RVA: 0x004AD194 File Offset: 0x004AB594
			private void _Update()
			{
				this.comItemLink.iItemLinkID = this.iTableID;
				ETCImageLoader.LoadSprite(ref this.kIcon, this.itemData.Icon, true);
				this.comMoneyBinder = MoneyBinder.Create(this.goLocal, this.kIcon, this.kNum, this.kName, this.iTableID, this.eMoneyBinder);
			}

			// Token: 0x0400A8B7 RID: 43191
			private GameObject goLocal;

			// Token: 0x0400A8B8 RID: 43192
			private GameObject goPrefab;

			// Token: 0x0400A8B9 RID: 43193
			private GameObject goParent;

			// Token: 0x0400A8BA RID: 43194
			private int iTableID;

			// Token: 0x0400A8BB RID: 43195
			private ShopFrame frame;

			// Token: 0x0400A8BC RID: 43196
			private Image kIcon;

			// Token: 0x0400A8BD RID: 43197
			private Text kNum;

			// Token: 0x0400A8BE RID: 43198
			private Text kName;

			// Token: 0x0400A8BF RID: 43199
			private ItemComeLink comItemLink;

			// Token: 0x0400A8C0 RID: 43200
			private MoneyBinder comMoneyBinder;

			// Token: 0x0400A8C1 RID: 43201
			private ItemData itemData;

			// Token: 0x0400A8C2 RID: 43202
			private Button btnCoinTips;

			// Token: 0x0400A8C3 RID: 43203
			private bool bLocked;

			// Token: 0x0400A8C4 RID: 43204
			private MoneyBinder.MoneyShowType eMoneyBinder;
		}

		// Token: 0x02001A5A RID: 6746
		private class GoodsDataItem : CachedObject
		{
			// Token: 0x17001D56 RID: 7510
			// (get) Token: 0x060108FD RID: 67837 RVA: 0x004AD2C2 File Offset: 0x004AB6C2
			public GoodsData GoodsData
			{
				get
				{
					return this.goodsData;
				}
			}

			// Token: 0x17001D57 RID: 7511
			// (get) Token: 0x060108FE RID: 67838 RVA: 0x004AD2CA File Offset: 0x004AB6CA
			// (set) Token: 0x060108FF RID: 67839 RVA: 0x004AD2D2 File Offset: 0x004AB6D2
			public int SortID { get; set; }

			// Token: 0x06010900 RID: 67840 RVA: 0x004AD2DC File Offset: 0x004AB6DC
			public override void OnDestroy()
			{
				if (this.btnBuy != null)
				{
					this.btnBuy.onClick.RemoveAllListeners();
					this.btnBuy = null;
				}
				if (null != this.btnBuy2)
				{
					this.btnBuy2.onClick.RemoveAllListeners();
					this.btnBuy2 = null;
				}
				if (this.btnOtherHint != null)
				{
					this.btnOtherHint.onClick.RemoveAllListeners();
					this.btnOtherHint = null;
				}
				if (this.comItem != null)
				{
					this.comItem.Setup(null, null);
					this.comItem = null;
				}
			}

			// Token: 0x06010901 RID: 67841 RVA: 0x004AD388 File Offset: 0x004AB788
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.goodsData = (param[2] as GoodsData);
				this.frame = (param[3] as ShopFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.name = Utility.FindComponent<Text>(this.goLocal, "titleback/name", true);
					this.price = Utility.FindComponent<Text>(this.goLocal, "btBuy/Horizen/curprice", true);
					this.colorPrice = this.price.color;
					this.icon = Utility.FindComponent<Image>(this.goLocal, "btBuy/Horizen/TicketIcon", true);
					this.moneyName = Utility.FindComponent<Text>(this.goLocal, "btBuy/Horizen/MoneyName", true);
					this.comItem = this.frame.CreateComItem(Utility.FindChild(this.goLocal, "ItemParent"));
					this.goVip = Utility.FindChild(this.goLocal, "VipMark");
					this.vipLevel = Utility.FindComponent<Text>(this.goVip, "Text", true);
					this.goOtherHint = Utility.FindChild(this.goLocal, "OtherHint");
					this.otherHintText = Utility.FindComponent<Text>(this.goOtherHint, "Text", true);
					this.goSellOver = Utility.FindChild(this.goLocal, "btBuy/SellOver");
					this.goNormalPrice = Utility.FindChild(this.goLocal, "btBuy/Horizen");
					this.timesLmt = Utility.FindChild(this.goLocal, "titleback/timesLmt");
					this.timesHint = Utility.FindComponent<Text>(this.timesLmt, "Text", true);
					this.limitName = Utility.FindComponent<Text>(this.timesLmt, "name", true);
					this.btnBuy = this.goLocal.GetComponent<Button>();
					this.btnBuy.onClick.AddListener(new UnityAction(this.OnClickBuy));
					this.btnBuy2 = Utility.FindComponent<Button>(this.goLocal, "btBuy", true);
					this.btnBuy2.onClick.AddListener(new UnityAction(this.OnClickBuy));
					this.gray2 = Utility.FindComponent<UIGray>(this.goLocal, "btBuy", true);
					this.goOrgBtBuy = Utility.FindChild(this.goLocal, "btBuy");
					this.btnOtherHint = Utility.FindComponent<Button>(this.goLocal, "OtherHint", true);
					this.btnOtherHint.onClick.AddListener(new UnityAction(this.OnClickBuy));
					this.discount = Utility.FindComponent<Text>(this.goLocal, "vipCountInfo/discount", true);
					this.goDisCount = Utility.FindChild(this.goLocal, "vipCountInfo");
					this.goCheckCanBuyMask = Utility.FindChild(this.goLocal, "CanNotBuyMask");
					this.goOldChangeNew = Utility.FindChild(this.goLocal, "btBuy/Horizen/oldChangeNew");
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x06010902 RID: 67842 RVA: 0x004AD67E File Offset: 0x004ABA7E
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06010903 RID: 67843 RVA: 0x004AD69D File Offset: 0x004ABA9D
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06010904 RID: 67844 RVA: 0x004AD6A6 File Offset: 0x004ABAA6
			public override void OnRefresh(object[] param)
			{
				if (param != null && param.Length > 0)
				{
					this.goodsData = (param[0] as GoodsData);
				}
				this._Update();
			}

			// Token: 0x06010905 RID: 67845 RVA: 0x004AD6CB File Offset: 0x004ABACB
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x06010906 RID: 67846 RVA: 0x004AD6EA File Offset: 0x004ABAEA
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06010907 RID: 67847 RVA: 0x004AD70D File Offset: 0x004ABB0D
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06010908 RID: 67848 RVA: 0x004AD72C File Offset: 0x004ABB2C
			public override bool NeedFilter(object[] param)
			{
				if (this.goodsData == null)
				{
					return true;
				}
				if (param == null || param.Length != 3)
				{
					return true;
				}
				if (this.goodsData.Type != (ShopTable.eSubType)param[0])
				{
					return true;
				}
				ShopFrame.GoodOptionData goodOptionData = param[1] as ShopFrame.GoodOptionData;
				if (goodOptionData == null)
				{
					return false;
				}
				ShopTable.eFilter eFilter = (ShopTable.eFilter)param[2];
				if (eFilter == ShopTable.eFilter.SF_OCCU)
				{
					bool flag = false;
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.goodsData.ItemData.TableID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Occu.Count > 0)
					{
						for (int i = 0; i < tableItem.Occu.Count; i++)
						{
							if (tableItem.Occu[i] / 10 * 10 == goodOptionData.jobItem.ID || tableItem.Occu[i] == 0)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						return true;
					}
				}
				else
				{
					if (eFilter == ShopTable.eFilter.SF_ARMOR)
					{
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.goodsData.ItemData.TableID, string.Empty, string.Empty);
						return tableItem2 == null || this.goodsData.ItemData.ThirdType != goodOptionData.eFilter;
					}
					if (eFilter == ShopTable.eFilter.SF_OCCU2)
					{
						ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.goodsData.ItemData.TableID, string.Empty, string.Empty);
						if (tableItem3 == null)
						{
							return true;
						}
						if (tableItem3.Occu2.Count <= 0)
						{
							return true;
						}
						for (int j = 0; j < tableItem3.Occu2.Count; j++)
						{
							if (goodOptionData.jobItem.ID == tableItem3.Occu2[j])
							{
								return false;
							}
						}
						return true;
					}
				}
				return false;
			}

			// Token: 0x06010909 RID: 67849 RVA: 0x004AD936 File Offset: 0x004ABD36
			public bool IsEnable()
			{
				return this.goLocal != null && this.goLocal.activeSelf;
			}

			// Token: 0x0601090A RID: 67850 RVA: 0x004AD958 File Offset: 0x004ABD58
			private void OnItemClicked(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					if (this._CheckCanBuy(this.GoodsData))
					{
						List<TipFuncButon> list = new List<TipFuncButon>();
						list.Add(new TipFuncButonSpecial
						{
							text = TR.Value("tip_buy"),
							callback = delegate(ItemData data, object param1)
							{
								if (data != null)
								{
									GoodsData goodsData = data.userData as GoodsData;
									if (goodsData != null)
									{
										this.OnClickBuy();
									}
								}
							}
						});
						DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
					}
					else
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
					}
				}
			}

			// Token: 0x0601090B RID: 67851 RVA: 0x004AD9D8 File Offset: 0x004ABDD8
			public void OnClickBuy()
			{
				if (this.goodsData.eGoodsLimitButyType != GoodsLimitButyType.GLBT_NONE)
				{
					if (this.goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_TOWER_LEVEL)
					{
						int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
						if (count < this.goodsData.iLimitValue)
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_tower_level"), this.goodsData.iLimitValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
					}
					else if (this.goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_FIGHT_SCORE)
					{
						int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
						if (seasonLevel < this.goodsData.iLimitValue)
						{
							string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(this.goodsData.iLimitValue, true);
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_fight_score"), rankName), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
					}
					else if (this.goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_GUILD_LEVEL)
					{
						int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.SHOP);
						if (buildingLevel < this.goodsData.iLimitValue)
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_guild_level"), this.goodsData.iLimitValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
					}
				}
				if (this.goodsData.VipLimitLevel > 0 && this.goodsData.VipLimitLevel > DataManager<PlayerBaseData>.GetInstance().VipLevel)
				{
					SystemNotifyManager.SystemNotify(1800011, delegate()
					{
						VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
						vipFrame.OpenPayTab();
					});
					return;
				}
				this.frame._OnGoodsClicked(this.goodsData);
			}

			// Token: 0x0601090C RID: 67852 RVA: 0x004ADBA0 File Offset: 0x004ABFA0
			private void _UpdateLimitBuy()
			{
				try
				{
					bool flag = false;
					int num = -1;
					ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.frame.m_kShopData.ID.Value, string.Empty, string.Empty);
					if (tableItem != null && (tableItem.Refresh == 2 || tableItem.Refresh == 1) && tableItem.NeedRefreshTabs.Count == tableItem.SubType.Count && tableItem.SubType.Count == tableItem.RefreshCycle.Count)
					{
						for (int i = 0; i < tableItem.SubType.Count; i++)
						{
							if (tableItem.SubType[i] == (ShopTable.eSubType)this.goodsData.shopItem.SubType)
							{
								num = i;
								break;
							}
						}
					}
					if (num != -1 && tableItem.NeedRefreshTabs[num] == 1)
					{
						flag = true;
					}
					if (flag)
					{
						switch (tableItem.RefreshCycle[num])
						{
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_NONE:
							this.timesHint.text = TR.Value("shop_item_limit_buy_forever", this.goodsData.LimitBuyTimes);
							break;
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_DAILY:
							this.timesHint.text = TR.Value("shop_item_limit_buy_daily", this.goodsData.LimitBuyTimes);
							if (tableItem.Refresh == 1)
							{
								this.timesHint.text = TR.Value("shop_item_limit_buy_mystery", this.goodsData.LimitBuyTimes);
							}
							break;
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_WEEK:
							this.timesHint.text = TR.Value("shop_item_limit_buy_weekly", this.goodsData.LimitBuyTimes);
							break;
						case ShopTable.eRefreshCycle.REFRESH_CYCLE_MONTH:
							this.timesHint.text = TR.Value("shop_item_limit_buy_monthly", this.goodsData.LimitBuyTimes);
							break;
						}
					}
					else if (this.goodsData.LimitBuyTimes > 0)
					{
						this.timesHint.text = TR.Value("shop_item_limit_buy_forever", this.goodsData.LimitBuyTimes);
					}
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat(ex.ToString(), new object[0]);
				}
			}

			// Token: 0x0601090D RID: 67853 RVA: 0x004ADE0C File Offset: 0x004AC20C
			private bool _CheckCanBuy(GoodsData goodsData)
			{
				bool flag = true;
				switch (goodsData.eGoodsLimitButyType)
				{
				case GoodsLimitButyType.GLBT_FIGHT_SCORE:
				{
					int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
					flag = (seasonLevel >= goodsData.iLimitValue);
					break;
				}
				case GoodsLimitButyType.GLBT_TOWER_LEVEL:
				{
					int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
					flag = (count >= goodsData.iLimitValue);
					break;
				}
				case GoodsLimitButyType.GLBT_GUILD_LEVEL:
				{
					int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.SHOP);
					flag = (buildingLevel >= goodsData.iLimitValue);
					break;
				}
				}
				if (flag && this.GoodsData.VipLimitLevel != null && this.GoodsData.VipLimitLevel.Value > 0 && this.GoodsData.VipLimitLevel.Value > DataManager<PlayerBaseData>.GetInstance().VipLevel)
				{
					flag = false;
				}
				if (flag && goodsData.LimitBuyTimes <= 0)
				{
					flag = false;
				}
				return flag;
			}

			// Token: 0x0601090E RID: 67854 RVA: 0x004ADF08 File Offset: 0x004AC308
			private void _Update()
			{
				this._UpdateLimitBuy();
				this.showType = this.goodsData.GetShowType(DataManager<PlayerBaseData>.GetInstance().VipLevel);
				this.goodsData.ItemData.userData = this.goodsData;
				this.comItem.Setup(this.goodsData.ItemData, new ComItem.OnItemClicked(this.OnItemClicked));
				Text text = this.name;
				string colorName = this.goodsData.ItemData.GetColorName(string.Empty, false);
				this.limitName.text = colorName;
				text.text = colorName;
				this.goodsData.ItemData.userData = this.goodsData;
				ETCImageLoader.LoadSprite(ref this.icon, this.goodsData.CostItemData.Icon, true);
				this.moneyName.text = this.goodsData.CostItemData.Name;
				bool flag = ShopFrame.ms_money_show_name.ToList<int>().Contains(this.goodsData.CostItemData.TableID);
				this.moneyName.CustomActive(flag);
				this.icon.CustomActive(!flag);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.goodsData.CostItemData.TableID, true);
				this.price.text = this.goodsData.CostItemCount.Value.ToString();
				this.price.color = ((!(ownedItemCount >= this.goodsData.CostItemCount)) ? Color.red : this.colorPrice);
				bool flag2 = ownedItemCount >= this.goodsData.CostItemCount;
				this.timesLmt.CustomActive(this.goodsData.LimitBuyTimes > 0);
				this.name.CustomActive(!this.timesLmt.activeSelf);
				this.goSellOver.CustomActive(this.goodsData.LimitBuyTimes == 0);
				this.btnBuy.enabled = (this.goodsData.LimitBuyTimes != 0);
				this.btnBuy2.enabled = this.btnBuy.enabled;
				this.gray2.enabled = !this.btnBuy2.enabled;
				this.goNormalPrice.CustomActive(!this.goSellOver.activeSelf);
				bool flag3 = true;
				switch (this.goodsData.eGoodsLimitButyType)
				{
				case GoodsLimitButyType.GLBT_NONE:
					this.goOtherHint.CustomActive(false);
					break;
				case GoodsLimitButyType.GLBT_FIGHT_SCORE:
				{
					int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
					this.goOtherHint.CustomActive(seasonLevel < this.goodsData.iLimitValue);
					string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(this.goodsData.iLimitValue, true);
					this.otherHintText.text = string.Format(TR.Value("shop_refresh_need_fight_score"), rankName);
					flag3 = (seasonLevel >= this.goodsData.iLimitValue);
					break;
				}
				case GoodsLimitButyType.GLBT_TOWER_LEVEL:
				{
					int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
					this.goOtherHint.CustomActive(count < this.goodsData.iLimitValue);
					this.otherHintText.text = string.Format(TR.Value("shop_refresh_need_tower_level"), this.goodsData.iLimitValue);
					flag3 = (count >= this.goodsData.iLimitValue);
					break;
				}
				case GoodsLimitButyType.GLBT_GUILD_LEVEL:
				{
					int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.SHOP);
					this.goOtherHint.CustomActive(buildingLevel < this.goodsData.iLimitValue);
					this.otherHintText.text = string.Format(TR.Value("shop_refresh_need_guild_level"), this.goodsData.iLimitValue);
					flag3 = (buildingLevel >= this.goodsData.iLimitValue);
					break;
				}
				}
				this.goVip.CustomActive(this.showType == GoodsData.GoodsDataShowType.GDST_VIP);
				this.goOrgBtBuy.CustomActive(!this.goOtherHint.activeSelf);
				if (this.showType != GoodsData.GoodsDataShowType.GDST_LIMIT_COUNT)
				{
					if (this.showType == GoodsData.GoodsDataShowType.GDST_VIP)
					{
						this.vipLevel.text = string.Format(TR.Value("VipFormat"), this.goodsData.VipLimitLevel);
					}
				}
				if (flag3 && this.GoodsData.VipLimitLevel != null && this.GoodsData.VipLimitLevel.Value > 0 && this.GoodsData.VipLimitLevel.Value > DataManager<PlayerBaseData>.GetInstance().VipLevel)
				{
					flag3 = false;
				}
				this.goDisCount.CustomActive(this.goodsData.VipDiscount != null && this.goodsData.VipDiscount.Value < 100 && this.goodsData.VipDiscount.Value > 0);
				if (this.goodsData.VipDiscount != null && this.goodsData.VipDiscount.Value < 100 && this.goodsData.VipDiscount.Value > 0)
				{
					int num = Mathf.CeilToInt((float)this.goodsData.VipDiscount.Value / 100f * (float)this.goodsData.CostItemCount.Value);
					this.price.text = num.ToString();
					this.price.color = ((!(ownedItemCount >= this.goodsData.CostItemCount)) ? Color.red : this.colorPrice);
					this.discount.text = TR.Value("shop_item_discount_info", this.goodsData.VipDiscount.Value);
					bool flag4 = ownedItemCount >= this.goodsData.CostItemCount;
				}
				this.goCheckCanBuyMask.CustomActive(!flag3);
				bool flag5 = DataManager<ShopDataManager>.GetInstance()._IsShowOldChangeNew(this.goodsData) && !this.goSellOver.activeSelf;
				this.goOldChangeNew.CustomActive(flag5);
				if (flag5)
				{
					ComOldChangeNewItem component = this.goOldChangeNew.GetComponent<ComOldChangeNewItem>();
					component.SetItemId(this.goodsData.shopItem.ID);
				}
			}

			// Token: 0x0400A8C5 RID: 43205
			private GameObject goLocal;

			// Token: 0x0400A8C6 RID: 43206
			private GameObject goPrefab;

			// Token: 0x0400A8C7 RID: 43207
			private GameObject goParent;

			// Token: 0x0400A8C8 RID: 43208
			private GoodsData goodsData;

			// Token: 0x0400A8C9 RID: 43209
			private ShopFrame frame;

			// Token: 0x0400A8CB RID: 43211
			private Text name;

			// Token: 0x0400A8CC RID: 43212
			private Text limitName;

			// Token: 0x0400A8CD RID: 43213
			private Text price;

			// Token: 0x0400A8CE RID: 43214
			private Color colorPrice;

			// Token: 0x0400A8CF RID: 43215
			private Image icon;

			// Token: 0x0400A8D0 RID: 43216
			private Text moneyName;

			// Token: 0x0400A8D1 RID: 43217
			private ComItem comItem;

			// Token: 0x0400A8D2 RID: 43218
			private Button btnBuy2;

			// Token: 0x0400A8D3 RID: 43219
			private UIGray gray2;

			// Token: 0x0400A8D4 RID: 43220
			private GameObject goVip;

			// Token: 0x0400A8D5 RID: 43221
			private Text vipLevel;

			// Token: 0x0400A8D6 RID: 43222
			private GameObject goOtherHint;

			// Token: 0x0400A8D7 RID: 43223
			private Text otherHintText;

			// Token: 0x0400A8D8 RID: 43224
			private Text discount;

			// Token: 0x0400A8D9 RID: 43225
			private GameObject goDisCount;

			// Token: 0x0400A8DA RID: 43226
			private GameObject goSellOver;

			// Token: 0x0400A8DB RID: 43227
			private GameObject goNormalPrice;

			// Token: 0x0400A8DC RID: 43228
			private GameObject timesLmt;

			// Token: 0x0400A8DD RID: 43229
			private Text timesHint;

			// Token: 0x0400A8DE RID: 43230
			private GameObject goOrgBtBuy;

			// Token: 0x0400A8DF RID: 43231
			private Button btnBuy;

			// Token: 0x0400A8E0 RID: 43232
			private Button btnOtherHint;

			// Token: 0x0400A8E1 RID: 43233
			private GoodsData.GoodsDataShowType showType;

			// Token: 0x0400A8E2 RID: 43234
			private GameObject goCheckCanBuyMask;

			// Token: 0x0400A8E3 RID: 43235
			private GameObject goOldChangeNew;
		}
	}
}
