using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200160E RID: 5646
	public class GuildDungeonAwardShowFrame : ClientFrame
	{
		// Token: 0x0600DD36 RID: 56630 RVA: 0x00380113 File Offset: 0x0037E513
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonAwardShow";
		}

		// Token: 0x0600DD37 RID: 56631 RVA: 0x0038011A File Offset: 0x0037E51A
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.hasSecondPay = (bool)this.userData;
			}
			this.BindEvent();
			this.InitTRDesc();
			this.InitEffectRoot();
			this.UpdateFrame();
		}

		// Token: 0x0600DD38 RID: 56632 RVA: 0x00380150 File Offset: 0x0037E550
		protected override void _OnCloseFrame()
		{
			this.UnBindEvent();
			this.ClearData(true);
			this.ClearEffectRoot();
		}

		// Token: 0x0600DD39 RID: 56633 RVA: 0x00380168 File Offset: 0x0037E568
		private void BindEvent()
		{
			NetProcess.AddMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayRewardReceived, new ClientEventSystem.UIEventHandler(this.OnGotPayReward));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMallFrameClosed, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
		}

		// Token: 0x0600DD3A RID: 56634 RVA: 0x003801DC File Offset: 0x0037E5DC
		private void UnBindEvent()
		{
			NetProcess.RemoveMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayRewardReceived, new ClientEventSystem.UIEventHandler(this.OnGotPayReward));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMallFrameClosed, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
		}

		// Token: 0x0600DD3B RID: 56635 RVA: 0x00380250 File Offset: 0x0037E650
		private void InitEffectRoot()
		{
			if (this.effect_guang_go == null)
			{
				this.effect_guang_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guang", true, 0U);
				Utility.AttachTo(this.effect_guang_go, this.mEffectRoot_Backlight, false);
			}
			if (this.effect_qian_go == null)
			{
				this.effect_qian_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_qian", true, 0U);
				Utility.AttachTo(this.effect_qian_go, this.mEffectRoot_Envior, false);
			}
			if (this.effect_zi_go == null)
			{
				this.effect_zi_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_zi", true, 0U);
				Utility.AttachTo(this.effect_zi_go, this.mEffectRoot_TopTitle, false);
			}
			if (this.effect_goPayBtn_go == null)
			{
				this.effect_goPayBtn_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_anniu", true, 0U);
				Utility.AttachTo(this.effect_goPayBtn_go, this.mEffectRoot_GoPayBtn, false);
			}
		}

		// Token: 0x0600DD3C RID: 56636 RVA: 0x00380348 File Offset: 0x0037E748
		private void ClearEffectRoot()
		{
			if (this.effect_guang_go)
			{
				Object.Destroy(this.effect_guang_go);
				this.effect_guang_go = null;
			}
			if (this.effect_qian_go)
			{
				Object.Destroy(this.effect_qian_go);
				this.effect_qian_go = null;
			}
			if (this.effect_zi_go)
			{
				Object.Destroy(this.effect_zi_go);
				this.effect_zi_go = null;
			}
			if (this.effect_left_jiantou_go)
			{
				Object.Destroy(this.effect_left_jiantou_go);
				this.effect_left_jiantou_go = null;
			}
			if (this.effect_right_jiantou_go)
			{
				Object.Destroy(this.effect_right_jiantou_go);
				this.effect_right_jiantou_go = null;
			}
			if (this.effect_goPayBtn_go)
			{
				Object.Destroy(this.effect_goPayBtn_go);
				this.effect_goPayBtn_go = null;
			}
		}

		// Token: 0x0600DD3D RID: 56637 RVA: 0x00380421 File Offset: 0x0037E821
		private void InitTRDesc()
		{
			this.mToGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_toget");
			this.mNotGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_notget");
			this.mGotRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_got");
		}

		// Token: 0x0600DD3E RID: 56638 RVA: 0x00380453 File Offset: 0x0037E853
		public void OnUpdateData(UIEvent iEvent)
		{
			this.UpdateMainContent();
		}

		// Token: 0x0600DD3F RID: 56639 RVA: 0x0038045B File Offset: 0x0037E85B
		private void UpdateFrame()
		{
			this.UpdateMainContent();
		}

		// Token: 0x0600DD40 RID: 56640 RVA: 0x00380464 File Offset: 0x0037E864
		private void UpdateMainContent()
		{
			this.items = Singleton<PayManager>.GetInstance().GetConsumeItems(true);
			if (this.items == null)
			{
				return;
			}
			if (this.mHavePay != null)
			{
				this.mHavePay.text = string.Format("已充值：{0}元", Singleton<PayManager>.GetInstance().GetCurrentRolePayMoney());
			}
			this.UpdateIndex();
			if (this.index_canget != -1)
			{
				this.SetGetBtnShow(true);
				this.SetGoBtnShow(false);
			}
			else if (this.index_canget == -1 && this.index_unfinish != -1)
			{
				this.SetGetBtnShow(false);
				this.SetGoBtnShow(true);
			}
			if (this.index_canget != -1)
			{
				this.index_flag = this.index_canget;
			}
			else if (this.index_canget == -1 && this.index_unfinish != -1)
			{
				this.index_flag = this.index_unfinish;
			}
			this.UpdateItem(false);
		}

		// Token: 0x0600DD41 RID: 56641 RVA: 0x00380558 File Offset: 0x0037E958
		protected void UpdateIndex()
		{
			this.totalRewardLevelNum = this.items.Count;
			bool flag = false;
			int num = 0;
			while (num < this.items.Count && !flag)
			{
				if (this.items[num].status == 2)
				{
					this.index_canget = num;
					flag = true;
				}
				num++;
			}
			if (this.index_canget != -1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < this.items.Count && !this.flag)
			{
				if (this.items[num2].status == 1)
				{
					this.flag = true;
					this.index_unfinish = num2;
				}
				num2++;
			}
			if (this.payRewardLevelIndex != -1 && this.index_canget == -1)
			{
				this.index_unfinish = this.payRewardLevelIndex;
			}
		}

		// Token: 0x0600DD42 RID: 56642 RVA: 0x00380638 File Offset: 0x0037EA38
		private void UpdateItem(bool bForceScorll = false)
		{
			if (bForceScorll)
			{
				int num = -1;
				switch (this.mPayReturnScrollState)
				{
				case GuildDungeonAwardShowFrame.PayReturnSrcollState.Head_Left_Most:
				case GuildDungeonAwardShowFrame.PayReturnSrcollState.Tail_Right_Most:
					num = this.index_flag;
					break;
				case GuildDungeonAwardShowFrame.PayReturnSrcollState.Middle_Left:
					num = this.index_flag - 1;
					if (num < 1)
					{
						num = 1;
					}
					break;
				case GuildDungeonAwardShowFrame.PayReturnSrcollState.Middle_Right:
					num = this.index_flag + 1;
					if (num > this.totalRewardLevelNum)
					{
						num = this.totalRewardLevelNum - 1;
					}
					break;
				}
				this.index_flag = num;
			}
			if (this.index_flag < 1)
			{
				this.index_flag = 1;
			}
			else if (this.index_flag >= this.totalRewardLevelNum)
			{
				this.index_flag = this.totalRewardLevelNum - 1;
			}
			if (this.itemDataDic != null)
			{
				this.itemDataDic.Clear();
			}
			if (this.awardItemDataList != null)
			{
				this.awardItemDataList.Clear();
			}
			this.itemDataDic = Singleton<PayManager>.GetInstance().GetAwardItems(this.items[this.index_flag]);
			if (this.itemDataDic != null)
			{
				Dictionary<uint, int>.Enumerator enumerator = this.itemDataDic.GetEnumerator();
				while (enumerator.MoveNext())
				{
					AwardItemData awardItemData = new AwardItemData();
					AwardItemData awardItemData2 = awardItemData;
					KeyValuePair<uint, int> keyValuePair = enumerator.Current;
					awardItemData2.ID = (int)keyValuePair.Key;
					AwardItemData awardItemData3 = awardItemData;
					KeyValuePair<uint, int> keyValuePair2 = enumerator.Current;
					awardItemData3.Num = keyValuePair2.Value;
					if (awardItemData != null && !this.awardItemDataList.Contains(awardItemData))
					{
						this.awardItemDataList.Add(awardItemData);
					}
				}
			}
			ActiveManager.ActivityData activityData = this.items[this.index_flag];
			int id = this.items[this.index_flag].ID;
			if (this.mPayRMB)
			{
				this.mPayRMB.SetRMBNum(this.items[this.index_flag].activeItem.Desc);
			}
			if (this.totalRewardLevelNum < this.index_flag + this.payRewardLevelShowNum)
			{
				this.payRewardLevelShowNum = this.totalRewardLevelNum - this.index_flag;
			}
			this.UpdatePayRewardItems(id);
			if (activityData.status == 2)
			{
				this.SetGetBtnStatus(true);
				this.SetGetBtnText(this.mToGetRewardText);
			}
			else if (activityData.status < 2)
			{
				this.SetGoBtnShow(true);
				this.SetGetBtnShow(false);
			}
			else if (activityData.status > 2)
			{
				this.SetGetBtnStatus(false);
				this.SetGetBtnText(this.mGotRewardText);
			}
			if (this.index_flag == 1)
			{
				this.mPayReturnScrollState = GuildDungeonAwardShowFrame.PayReturnSrcollState.Head_Left_Most;
				this.SetPayReturnLeftBtnActive(false);
				this.SetPayReturnRightBtnActive(true);
			}
			else if (this.index_flag == this.totalRewardLevelNum - 1)
			{
				this.mPayReturnScrollState = GuildDungeonAwardShowFrame.PayReturnSrcollState.Tail_Right_Most;
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(false);
			}
			else
			{
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(true);
			}
		}

		// Token: 0x0600DD43 RID: 56643 RVA: 0x0038091C File Offset: 0x0037ED1C
		private List<AwardItemData> GetKillBossAwardList()
		{
			List<AwardItemData> list = new List<AwardItemData>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonRewardTable guildDungeonRewardTable = keyValuePair.Value as GuildDungeonRewardTable;
					if (guildDungeonRewardTable != null)
					{
						if (guildDungeonRewardTable.rewardType == 3)
						{
							for (int i = 0; i < guildDungeonRewardTable.rewardShowLength; i++)
							{
								string text = guildDungeonRewardTable.rewardShowArray(i);
								string[] array = text.Split(new char[]
								{
									'_'
								});
								if (array.Length >= 2)
								{
									AwardItemData awardItemData = new AwardItemData();
									int.TryParse(array[0], out awardItemData.ID);
									int.TryParse(array[1], out awardItemData.Num);
									list.Add(awardItemData);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600DD44 RID: 56644 RVA: 0x00380A00 File Offset: 0x0037EE00
		private List<AwardItemData> GetNotKillBossAwardList()
		{
			List<AwardItemData> list = new List<AwardItemData>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonRewardTable guildDungeonRewardTable = keyValuePair.Value as GuildDungeonRewardTable;
					if (guildDungeonRewardTable != null)
					{
						if (guildDungeonRewardTable.rewardType == 4)
						{
							for (int i = 0; i < guildDungeonRewardTable.rewardShowLength; i++)
							{
								string text = guildDungeonRewardTable.rewardShowArray(i);
								string[] array = text.Split(new char[]
								{
									'_'
								});
								if (array.Length >= 2)
								{
									AwardItemData awardItemData = new AwardItemData();
									int.TryParse(array[0], out awardItemData.ID);
									int.TryParse(array[1], out awardItemData.Num);
									list.Add(awardItemData);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600DD45 RID: 56645 RVA: 0x00380AE4 File Offset: 0x0037EEE4
		private void UpdatePayRewardItems(int selectPayActId)
		{
			if (this.mScrollUIListContentGrid)
			{
				this.mScrollUIListContentGrid.enabled = false;
			}
			if (this.awardItemDataList == null)
			{
				Logger.LogError("ItemdataList data is null");
			}
			if (this.mScrollUIList == null)
			{
				Logger.LogError("mScrollUIList obj is null");
				return;
			}
			if (!this.mScrollUIList.IsInitialised())
			{
				this.mScrollUIList.Initialize();
				this.mScrollUIList.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mScrollUIList.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && index < this.awardItemDataList.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataList[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataList[index].ID
						});
						return;
					}
					itemData.Count = this.awardItemDataList[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
						if (this.payRewardItems != null && !this.payRewardItems.Contains(payRewardItem))
						{
							this.payRewardItems.Add(payRewardItem);
						}
					}
				}
			};
			this.awardItemDataList = this.GetKillBossAwardList();
			this.mScrollUIList.SetElementAmount(this.awardItemDataList.Count);
			if (!this.mScrollUIList2.IsInitialised())
			{
				this.mScrollUIList2.Initialize();
				this.mScrollUIList2.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mScrollUIList2.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && index < this.awardItemDataList2.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataList2[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataList2[index].ID
						});
						return;
					}
					itemData.Count = this.awardItemDataList2[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
						if (this.payRewardItems != null && !this.payRewardItems.Contains(payRewardItem))
						{
							this.payRewardItems.Add(payRewardItem);
						}
					}
				}
			};
			this.awardItemDataList2 = this.GetKillBossAwardList();
			this.mScrollUIList2.SetElementAmount(this.awardItemDataList2.Count);
			if (this.mSpecialItem && selectPayActId > 0)
			{
				int payReturnSpecialResID = Singleton<PayManager>.GetInstance().GetPayReturnSpecialResID(selectPayActId, this.awardItemDataList);
				ItemData detailData = ItemDataManager.CreateItemDataFromTable(payReturnSpecialResID, 100, 0);
				if (detailData == null)
				{
					return;
				}
				this.mSpecialItem.Initialize(this, detailData, false, true);
				this.mSpecialItem.RefreshView(false, false);
				string payReturnSpecialResPath = Singleton<PayManager>.GetInstance().GetPayReturnSpecialResPath(selectPayActId, this.awardItemDataList);
				this.mSpecialItem.SetItemIcon(payReturnSpecialResPath);
				this.mSpecialItem.onPayItemClick = delegate()
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(detailData, null, 4, true, false, true);
				};
			}
			if (this.mScrollUIListContentGrid)
			{
				this.mScrollUIListContentGrid.enabled = true;
			}
		}

		// Token: 0x0600DD46 RID: 56646 RVA: 0x00380CF4 File Offset: 0x0037F0F4
		private float _CalAwardScorllListPadding(float listWidth, float itemWidth, float itemSpace, int itemNum)
		{
			return (listWidth - (itemWidth * (float)itemNum + (float)(itemNum - 1) * itemSpace)) * 0.5f;
		}

		// Token: 0x0600DD47 RID: 56647 RVA: 0x00380D20 File Offset: 0x0037F120
		private void UpdatePayRewardLevelTabs()
		{
			if (this.index_canget != -1 || this.hasSecondPay || this.payRewardLevelShowNum <= 1)
			{
				if (this.mPayTabs)
				{
					this.mPayTabs.CustomActive(false);
				}
				return;
			}
			if (this.mPayTabs)
			{
				this.mPayTabs.CustomActive(true);
			}
			if (this.items == null)
			{
				Logger.LogError("items data is null");
				return;
			}
			if (this.mTabScrollUIList == null)
			{
				Logger.LogError("mTabScrollUIList list is null");
				return;
			}
			this.mTabScrollUIList.Initialize();
			this.mTabScrollUIList.onBindItem = delegate(GameObject go)
			{
				PayRewardLevelTab result = null;
				if (go)
				{
					result = go.GetComponent<PayRewardLevelTab>();
				}
				return result;
			};
			this.mTabScrollUIList.onItemVisiable = delegate(ComUIListElementScript var2)
			{
				if (var2 == null)
				{
					return;
				}
				int index = var2.m_index;
				int addedIndex = index + this.index_flag;
				if (index >= 0 && addedIndex < this.items.Count)
				{
					PayRewardLevelTab payRewardLevelTab = var2.gameObjectBindScript as PayRewardLevelTab;
					if (payRewardLevelTab == null)
					{
						return;
					}
					payRewardLevelTab.Initialize();
					payRewardLevelTab.SetPayRewardLevelIndex(addedIndex);
					payRewardLevelTab.SetTabText(this.items[addedIndex].activeItem.Desc);
					payRewardLevelTab.onPayRewardLevelTabChanged = delegate()
					{
						this.payRewardLevelIndex = addedIndex;
						this.ClearData(false);
						this.UpdateMainContent();
					};
					if (index == 0)
					{
						payRewardLevelTab.SetTabActive(true);
					}
					if (this.payRewardLevelTabs != null && !this.payRewardLevelTabs.Contains(payRewardLevelTab))
					{
						this.payRewardLevelTabs.Add(payRewardLevelTab);
					}
				}
			};
			this.mTabScrollUIList.SetElementAmount(this.payRewardLevelShowNum);
		}

		// Token: 0x0600DD48 RID: 56648 RVA: 0x00380E18 File Offset: 0x0037F218
		private void ClearPayRewardItems()
		{
			if (this.payRewardItems != null)
			{
				for (int i = 0; i < this.payRewardItems.Count; i++)
				{
					this.payRewardItems[i].Clear();
				}
				this.payRewardItems.Clear();
			}
			if (this.mSpecialItem != null)
			{
				this.mSpecialItem.Clear();
			}
		}

		// Token: 0x0600DD49 RID: 56649 RVA: 0x00380E84 File Offset: 0x0037F284
		private void ClearPayRewardLevelTabs()
		{
			if (this.payRewardLevelTabs != null)
			{
				for (int i = 0; i < this.payRewardLevelTabs.Count; i++)
				{
					this.payRewardLevelTabs[i].Clear();
				}
				this.payRewardLevelTabs.Clear();
			}
		}

		// Token: 0x0600DD4A RID: 56650 RVA: 0x00380ED4 File Offset: 0x0037F2D4
		private void ClearData(bool isClearWithTabs = true)
		{
			this.hasSecondPay = false;
			this.bGotReward = false;
			this.index_flag = -1;
			this.index_unfinish = -1;
			this.index_canget = -1;
			this.NowID = -1;
			this.flag = false;
			if (this.itemDataDic != null)
			{
				this.itemDataDic.Clear();
			}
			if (this.awardItemDataList != null)
			{
				this.awardItemDataList.Clear();
			}
			if (this.awardItemDataList2 != null)
			{
				this.awardItemDataList2.Clear();
			}
			if (this.items != null)
			{
				this.items.Clear();
			}
			this.payRewardLevelShowNum = 3;
			this.totalRewardLevelNum = 0;
			this.ClearPayRewardItems();
			if (isClearWithTabs)
			{
				this.ClearPayRewardLevelTabs();
				this.payRewardLevelIndex = -1;
			}
			this.mPayReturnScrollState = GuildDungeonAwardShowFrame.PayReturnSrcollState.Middle_Right;
			if (this.mScrollUIList != null)
			{
				this.mScrollUIList.SetElementAmount(0);
			}
			if (this.mScrollUIList2 != null)
			{
				this.mScrollUIList2.SetElementAmount(0);
			}
			if (this.mTabScrollUIList != null)
			{
				this.mTabScrollUIList.SetElementAmount(0);
			}
		}

		// Token: 0x0600DD4B RID: 56651 RVA: 0x00380FEF File Offset: 0x0037F3EF
		private void SetGetBtnShow(bool bShow)
		{
			if (this.mBtnGet)
			{
				this.mBtnGet.CustomActive(bShow);
			}
		}

		// Token: 0x0600DD4C RID: 56652 RVA: 0x0038100D File Offset: 0x0037F40D
		private void SetGoBtnShow(bool bShow)
		{
			if (this.mBtnGo)
			{
				this.mBtnGo.CustomActive(bShow);
			}
			if (this.mEffectRoot_GoPayBtn && bShow)
			{
				this.mEffectRoot_GoPayBtn.CustomActive(true);
			}
		}

		// Token: 0x0600DD4D RID: 56653 RVA: 0x00381050 File Offset: 0x0037F450
		private void SetGetBtnStatus(bool active)
		{
			this.SetGoBtnShow(false);
			this.SetGetBtnShow(true);
			if (this.mBtnGetGray)
			{
				this.mBtnGetGray.enabled = !active;
			}
			if (this.mBtnGet)
			{
				this.mBtnGet.interactable = active;
			}
			if (this.mBtnGetPayCD && active)
			{
				this.mBtnGetPayCD.StopCountDown();
			}
			if (this.mEffectRoot_GoPayBtn)
			{
				this.mEffectRoot_GoPayBtn.CustomActive(active);
			}
		}

		// Token: 0x0600DD4E RID: 56654 RVA: 0x003810E3 File Offset: 0x0037F4E3
		private void SetGetBtnText(string desc)
		{
			if (this.mBtnGetText)
			{
				this.mBtnGetText.text = desc;
			}
		}

		// Token: 0x0600DD4F RID: 56655 RVA: 0x00381101 File Offset: 0x0037F501
		private bool BeGetBtnCDOver()
		{
			return !(this.mBtnGetPayCD != null) || this.mBtnGetPayCD.bCDOver;
		}

		// Token: 0x0600DD50 RID: 56656 RVA: 0x00381124 File Offset: 0x0037F524
		private void SetPayReturnLeftBtnActive(bool bActive)
		{
			if (this.mPayReturnLeftBtn)
			{
				UIGray uigray = this.mPayReturnLeftBtn.gameObject.GetComponent<UIGray>();
				if (uigray == null)
				{
					uigray = this.mPayReturnLeftBtn.gameObject.AddComponent<UIGray>();
				}
				uigray.enabled = !bActive;
				this.mPayReturnLeftBtn.interactable = bActive;
				this.mPayReturnLeftBtn.gameObject.CustomActive(bActive);
			}
			if (this.mEffectRoot_LeftBtn)
			{
				this.mEffectRoot_LeftBtn.CustomActive(bActive);
			}
		}

		// Token: 0x0600DD51 RID: 56657 RVA: 0x003811B4 File Offset: 0x0037F5B4
		private void SetPayReturnRightBtnActive(bool bActive)
		{
			if (this.mPayReturnRightBtn)
			{
				UIGray uigray = this.mPayReturnRightBtn.gameObject.GetComponent<UIGray>();
				if (uigray == null)
				{
					uigray = this.mPayReturnRightBtn.gameObject.AddComponent<UIGray>();
				}
				uigray.enabled = !bActive;
				this.mPayReturnRightBtn.interactable = bActive;
				this.mPayReturnRightBtn.gameObject.CustomActive(bActive);
			}
			if (this.mEffectRoot_RightBtn)
			{
				this.mEffectRoot_RightBtn.CustomActive(bActive);
			}
		}

		// Token: 0x0600DD52 RID: 56658 RVA: 0x00381244 File Offset: 0x0037F644
		private void OnRecvSceneNotifyActiveTaskStatus(MsgDATA data)
		{
			SceneNotifyActiveTaskStatus sceneNotifyActiveTaskStatus = new SceneNotifyActiveTaskStatus();
			sceneNotifyActiveTaskStatus.decode(data.bytes);
			if ((ulong)sceneNotifyActiveTaskStatus.taskId == (ulong)((long)this.NowID) && sceneNotifyActiveTaskStatus.status == 5)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdatePayText, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayRewardReceived, null, null, null, null);
			}
		}

		// Token: 0x0600DD53 RID: 56659 RVA: 0x003812A8 File Offset: 0x0037F6A8
		private void OnGotPayReward(UIEvent uiEvent)
		{
			if (Singleton<PayManager>.GetInstance().HasConsumePay())
			{
				this.ClearData(true);
				this.bGotReward = true;
				this.UpdateFrame();
				if (this.mBtnGet && !this.mBtnGet.gameObject.activeSelf)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<SecondPayFrame>(null, false);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SecondPayFrame>(null, false);
			}
		}

		// Token: 0x0600DD54 RID: 56660 RVA: 0x0038131A File Offset: 0x0037F71A
		private void OnClickClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<GuildDungeonAwardShowFrame>(this, false);
		}

		// Token: 0x0600DD55 RID: 56661 RVA: 0x00381328 File Offset: 0x0037F728
		private void OnShowTipsFromJob(int result)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600DD56 RID: 56662 RVA: 0x00381358 File Offset: 0x0037F758
		private void OnShowTips(int itemID)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600DD57 RID: 56663 RVA: 0x00381388 File Offset: 0x0037F788
		protected override void _bindExUI()
		{
			this.mBtnGo = this.mBind.GetCom<Button>("btnGo");
			if (null != this.mBtnGo)
			{
				this.mBtnGo.onClick.AddListener(new UnityAction(this._onBtnGoButtonClick));
			}
			this.btnClose = this.mBind.GetCom<Button>("btnClose");
			if (null != this.btnClose)
			{
				this.btnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mBtnGetGray = this.mBind.GetCom<UIGray>("btnGetGray");
			this.mBtnGetText = this.mBind.GetCom<Text>("btnGetText");
			this.mBtnGetPayCD = this.mBind.GetCom<PayButtonCountDown>("btnGetPayCD");
			this.mBtnGet = this.mBind.GetCom<Button>("btnGet");
			if (null != this.mBtnGet)
			{
				this.mBtnGet.onClick.AddListener(new UnityAction(this._onBtnGetButtonClick));
			}
			this.mRMBValue = this.mBind.GetCom<Text>("RMBValue");
			this.mTotalValue = this.mBind.GetCom<Text>("TotalValue");
			this.mHavePay = this.mBind.GetCom<Text>("HavePay");
			this.mSpecialItem = this.mBind.GetCom<PayRewardItem>("SpecialItem");
			this.mScrollUIList = this.mBind.GetCom<ComUIListScript>("ScrollUIList");
			this.mScrollUIList2 = this.mBind.GetCom<ComUIListScript>("ScrollUIList2");
			this.mTabScrollUIList = this.mBind.GetCom<ComUIListScript>("TabScrollUIList");
			this.mPayTabs = this.mBind.GetGameObject("PayTabs");
			this.mGotoMoneyplan = this.mBind.GetCom<Button>("gotoMoneyplan");
			if (null != this.mGotoMoneyplan)
			{
				this.mGotoMoneyplan.onClick.AddListener(new UnityAction(this._onGotoMoneyplanButtonClick));
			}
			this.mGotoMonthCard = this.mBind.GetCom<Button>("gotoMonthCard");
			if (null != this.mGotoMonthCard)
			{
				this.mGotoMonthCard.onClick.AddListener(new UnityAction(this._onGotoMonthCardButtonClick));
			}
			this.mPayReturnRightBtn = this.mBind.GetCom<Button>("payReturnRightBtn");
			if (null != this.mPayReturnRightBtn)
			{
				this.mPayReturnRightBtn.onClick.AddListener(new UnityAction(this._onPayReturnRightBtnButtonClick));
			}
			this.mPayReturnLeftBtn = this.mBind.GetCom<Button>("payReturnLeftBtn");
			if (null != this.mPayReturnLeftBtn)
			{
				this.mPayReturnLeftBtn.onClick.AddListener(new UnityAction(this._onPayReturnLeftBtnButtonClick));
			}
			this.mPayRMB = this.mBind.GetCom<PayRMBItem>("PayRMB");
			this.mScrollUIListContentGrid = this.mBind.GetCom<GridLayoutGroup>("ScrollUIListContentGrid");
			this.mEffectRoot_Backlight = this.mBind.GetGameObject("EffectRoot_Backlight");
			this.mEffectRoot_TopTitle = this.mBind.GetGameObject("EffectRoot_TopTitle");
			this.mEffectRoot_Envior = this.mBind.GetGameObject("EffectRoot_Envior");
			this.mEffectRoot_LeftBtn = this.mBind.GetGameObject("EffectRoot_LeftBtn");
			this.mEffectRoot_RightBtn = this.mBind.GetGameObject("EffectRoot_RightBtn");
			this.mEffectRoot_GoPayBtn = this.mBind.GetGameObject("EffectRoot_GoPayBtn");
		}

		// Token: 0x0600DD58 RID: 56664 RVA: 0x0038170C File Offset: 0x0037FB0C
		protected override void _unbindExUI()
		{
			if (null != this.mBtnGo)
			{
				this.mBtnGo.onClick.RemoveListener(new UnityAction(this._onBtnGoButtonClick));
			}
			this.mBtnGo = null;
			if (null != this.btnClose)
			{
				this.btnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.btnClose = null;
			this.mBtnGetGray = null;
			this.mBtnGetText = null;
			this.mBtnGetPayCD = null;
			if (null != this.mBtnGet)
			{
				this.mBtnGet.onClick.RemoveListener(new UnityAction(this._onBtnGetButtonClick));
			}
			this.mBtnGet = null;
			this.mRMBValue = null;
			this.mTotalValue = null;
			this.mHavePay = null;
			this.mSpecialItem = null;
			this.mScrollUIList = null;
			this.mScrollUIList2 = null;
			this.mTabScrollUIList = null;
			this.mPayTabs = null;
			if (null != this.mGotoMoneyplan)
			{
				this.mGotoMoneyplan.onClick.RemoveListener(new UnityAction(this._onGotoMoneyplanButtonClick));
			}
			this.mGotoMoneyplan = null;
			if (null != this.mGotoMonthCard)
			{
				this.mGotoMonthCard.onClick.RemoveListener(new UnityAction(this._onGotoMonthCardButtonClick));
			}
			this.mGotoMonthCard = null;
			if (null != this.mPayReturnRightBtn)
			{
				this.mPayReturnRightBtn.onClick.RemoveListener(new UnityAction(this._onPayReturnRightBtnButtonClick));
			}
			this.mPayReturnRightBtn = null;
			if (null != this.mPayReturnLeftBtn)
			{
				this.mPayReturnLeftBtn.onClick.RemoveListener(new UnityAction(this._onPayReturnLeftBtnButtonClick));
			}
			this.mPayReturnLeftBtn = null;
			this.mPayRMB = null;
			this.mScrollUIListContentGrid = null;
			this.mEffectRoot_Backlight = null;
			this.mEffectRoot_TopTitle = null;
			this.mEffectRoot_Envior = null;
			this.mEffectRoot_LeftBtn = null;
			this.mEffectRoot_RightBtn = null;
			this.mEffectRoot_GoPayBtn = null;
		}

		// Token: 0x0600DD59 RID: 56665 RVA: 0x0038190A File Offset: 0x0037FD0A
		private void _onBtnGoButtonClick()
		{
			this.OnClickClose();
		}

		// Token: 0x0600DD5A RID: 56666 RVA: 0x00381912 File Offset: 0x0037FD12
		private void _onBtnCloseButtonClick()
		{
			this.OnClickClose();
		}

		// Token: 0x0600DD5B RID: 56667 RVA: 0x0038191C File Offset: 0x0037FD1C
		private void _onBtnGetButtonClick()
		{
			if (this.items == null || this.items.Count <= this.index_flag)
			{
				return;
			}
			if (this.index_flag < 0)
			{
				Logger.LogError("try to click get reward btn , but get index is less than zero !");
				return;
			}
			this.NowID = this.items[this.index_flag].ID;
			Singleton<PayManager>.GetInstance().GetRewards(this.NowID);
			if (this.mBtnGetPayCD)
			{
				this.mBtnGetPayCD.StartCountDown();
				this.mBtnGetPayCD.onCDOverHandler = delegate()
				{
					if (this.bGotReward)
					{
						return;
					}
					this.SetGetBtnStatus(true);
				};
				this.SetGetBtnStatus(this.mBtnGetPayCD.bCDOver);
			}
		}

		// Token: 0x0600DD5C RID: 56668 RVA: 0x003819D4 File Offset: 0x0037FDD4
		private void _onGotoMoneyplanButtonClick()
		{
			string text = typeof(ActiveChargeFrame).Name + 9380.ToString();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(text))
			{
				ActiveChargeFrame activeChargeFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(text) as ActiveChargeFrame;
				activeChargeFrame.Close(true);
			}
			DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 8600);
		}

		// Token: 0x0600DD5D RID: 56669 RVA: 0x00381A48 File Offset: 0x0037FE48
		private void _onGotoMonthCardButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallNewFrame>(null, false);
			}
			MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
			{
				MallNewType = MallNewType.ReChargeMall
			}, string.Empty) as MallNewFrame;
		}

		// Token: 0x0600DD5E RID: 56670 RVA: 0x00381A95 File Offset: 0x0037FE95
		private void _onPayReturnRightBtnButtonClick()
		{
			if (this.mPayReturnScrollState == GuildDungeonAwardShowFrame.PayReturnSrcollState.Tail_Right_Most)
			{
				return;
			}
			this.mPayReturnScrollState = GuildDungeonAwardShowFrame.PayReturnSrcollState.Middle_Right;
			this.UpdateItem(true);
		}

		// Token: 0x0600DD5F RID: 56671 RVA: 0x00381AB2 File Offset: 0x0037FEB2
		private void _onPayReturnLeftBtnButtonClick()
		{
			if (this.mPayReturnScrollState == GuildDungeonAwardShowFrame.PayReturnSrcollState.Head_Left_Most)
			{
				return;
			}
			this.mPayReturnScrollState = GuildDungeonAwardShowFrame.PayReturnSrcollState.Middle_Left;
			this.UpdateItem(true);
		}

		// Token: 0x040082BB RID: 33467
		protected const string payRewardItemResPath = "UIFlatten/Prefabs/Vip/PayRewardItem";

		// Token: 0x040082BC RID: 33468
		protected const string EffUI_shouchong_guang_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guang";

		// Token: 0x040082BD RID: 33469
		protected const string EffUI_shouchong_qian_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_qian";

		// Token: 0x040082BE RID: 33470
		protected const string EffUI_shouchong_jiantou_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_jiantou";

		// Token: 0x040082BF RID: 33471
		protected const string EffUI_shouchong_zi_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_zi";

		// Token: 0x040082C0 RID: 33472
		protected const string EffUI_shouchong_anniu_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_anniu";

		// Token: 0x040082C1 RID: 33473
		private GuildDungeonAwardShowFrame.PayReturnSrcollState mPayReturnScrollState = GuildDungeonAwardShowFrame.PayReturnSrcollState.Middle_Right;

		// Token: 0x040082C2 RID: 33474
		private int payRewardLevelShowNum = 3;

		// Token: 0x040082C3 RID: 33475
		private int totalRewardLevelNum;

		// Token: 0x040082C4 RID: 33476
		private int payRewardLevelIndex = -1;

		// Token: 0x040082C5 RID: 33477
		private bool flag;

		// Token: 0x040082C6 RID: 33478
		private int index_flag = -1;

		// Token: 0x040082C7 RID: 33479
		private int index_unfinish = -1;

		// Token: 0x040082C8 RID: 33480
		private int index_canget = -1;

		// Token: 0x040082C9 RID: 33481
		private int NowID = -1;

		// Token: 0x040082CA RID: 33482
		private bool hasSecondPay;

		// Token: 0x040082CB RID: 33483
		private bool bGotReward;

		// Token: 0x040082CC RID: 33484
		private string mToGetRewardText = string.Empty;

		// Token: 0x040082CD RID: 33485
		private string mNotGetRewardText = string.Empty;

		// Token: 0x040082CE RID: 33486
		private string mGotRewardText = string.Empty;

		// Token: 0x040082CF RID: 33487
		private GameObject effect_guang_go;

		// Token: 0x040082D0 RID: 33488
		private GameObject effect_qian_go;

		// Token: 0x040082D1 RID: 33489
		private GameObject effect_zi_go;

		// Token: 0x040082D2 RID: 33490
		private GameObject effect_left_jiantou_go;

		// Token: 0x040082D3 RID: 33491
		private GameObject effect_right_jiantou_go;

		// Token: 0x040082D4 RID: 33492
		private GameObject effect_goPayBtn_go;

		// Token: 0x040082D5 RID: 33493
		private List<PayRewardItem> payRewardItems = new List<PayRewardItem>();

		// Token: 0x040082D6 RID: 33494
		private List<PayRewardLevelTab> payRewardLevelTabs = new List<PayRewardLevelTab>();

		// Token: 0x040082D7 RID: 33495
		private Dictionary<uint, int> itemDataDic = new Dictionary<uint, int>();

		// Token: 0x040082D8 RID: 33496
		private List<AwardItemData> awardItemDataList = new List<AwardItemData>();

		// Token: 0x040082D9 RID: 33497
		private List<ActiveManager.ActivityData> items = new List<ActiveManager.ActivityData>();

		// Token: 0x040082DA RID: 33498
		private List<AwardItemData> awardItemDataList2 = new List<AwardItemData>();

		// Token: 0x040082DB RID: 33499
		private Button mBtnGo;

		// Token: 0x040082DC RID: 33500
		private Button btnClose;

		// Token: 0x040082DD RID: 33501
		private UIGray mBtnGetGray;

		// Token: 0x040082DE RID: 33502
		private Text mBtnGetText;

		// Token: 0x040082DF RID: 33503
		private PayButtonCountDown mBtnGetPayCD;

		// Token: 0x040082E0 RID: 33504
		private Button mBtnGet;

		// Token: 0x040082E1 RID: 33505
		private Text mRMBValue;

		// Token: 0x040082E2 RID: 33506
		private Text mTotalValue;

		// Token: 0x040082E3 RID: 33507
		private Text mHavePay;

		// Token: 0x040082E4 RID: 33508
		private PayRewardItem mSpecialItem;

		// Token: 0x040082E5 RID: 33509
		private ComUIListScript mScrollUIList;

		// Token: 0x040082E6 RID: 33510
		private ComUIListScript mScrollUIList2;

		// Token: 0x040082E7 RID: 33511
		private ComUIListScript mTabScrollUIList;

		// Token: 0x040082E8 RID: 33512
		private GameObject mPayTabs;

		// Token: 0x040082E9 RID: 33513
		private Button mGotoMoneyplan;

		// Token: 0x040082EA RID: 33514
		private Button mGotoMonthCard;

		// Token: 0x040082EB RID: 33515
		private Button mPayReturnRightBtn;

		// Token: 0x040082EC RID: 33516
		private Button mPayReturnLeftBtn;

		// Token: 0x040082ED RID: 33517
		private PayRMBItem mPayRMB;

		// Token: 0x040082EE RID: 33518
		private GridLayoutGroup mScrollUIListContentGrid;

		// Token: 0x040082EF RID: 33519
		private GameObject mEffectRoot_Backlight;

		// Token: 0x040082F0 RID: 33520
		private GameObject mEffectRoot_TopTitle;

		// Token: 0x040082F1 RID: 33521
		private GameObject mEffectRoot_Envior;

		// Token: 0x040082F2 RID: 33522
		private GameObject mEffectRoot_LeftBtn;

		// Token: 0x040082F3 RID: 33523
		private GameObject mEffectRoot_RightBtn;

		// Token: 0x040082F4 RID: 33524
		private GameObject mEffectRoot_GoPayBtn;

		// Token: 0x0200160F RID: 5647
		private enum PayReturnSrcollState
		{
			// Token: 0x040082F9 RID: 33529
			Head_Left_Most,
			// Token: 0x040082FA RID: 33530
			Middle_Left,
			// Token: 0x040082FB RID: 33531
			Middle_Right,
			// Token: 0x040082FC RID: 33532
			Tail_Right_Most
		}
	}
}
