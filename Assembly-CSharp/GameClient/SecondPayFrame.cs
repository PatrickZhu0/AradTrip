using System;
using System.Collections.Generic;
using Network;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001960 RID: 6496
	public class SecondPayFrame : ClientFrame
	{
		// Token: 0x0600FC84 RID: 64644 RVA: 0x00456948 File Offset: 0x00454D48
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Vip/SecondPayFrame";
		}

		// Token: 0x0600FC85 RID: 64645 RVA: 0x00456950 File Offset: 0x00454D50
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
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SecondPayFrameOpen, null, null, null, null);
		}

		// Token: 0x0600FC86 RID: 64646 RVA: 0x004569A4 File Offset: 0x00454DA4
		protected override void _OnCloseFrame()
		{
			this.UnBindEvent();
			this.ClearData(true);
			this.ClearEffectRoot();
		}

		// Token: 0x0600FC87 RID: 64647 RVA: 0x004569BC File Offset: 0x00454DBC
		private void BindEvent()
		{
			NetProcess.AddMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayRewardReceived, new ClientEventSystem.UIEventHandler(this.OnGotPayReward));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMallFrameClosed, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
		}

		// Token: 0x0600FC88 RID: 64648 RVA: 0x00456A30 File Offset: 0x00454E30
		private void UnBindEvent()
		{
			NetProcess.RemoveMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayRewardReceived, new ClientEventSystem.UIEventHandler(this.OnGotPayReward));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.WelfareFrameClose, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMallFrameClosed, new ClientEventSystem.UIEventHandler(this.OnUpdateData));
		}

		// Token: 0x0600FC89 RID: 64649 RVA: 0x00456AA4 File Offset: 0x00454EA4
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

		// Token: 0x0600FC8A RID: 64650 RVA: 0x00456B9C File Offset: 0x00454F9C
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

		// Token: 0x0600FC8B RID: 64651 RVA: 0x00456C75 File Offset: 0x00455075
		private void InitTRDesc()
		{
			this.mToGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_toget");
			this.mNotGetRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_notget");
			this.mGotRewardText = TR.Value("vip_month_card_first_buy_next_pay_return_got");
		}

		// Token: 0x0600FC8C RID: 64652 RVA: 0x00456CA7 File Offset: 0x004550A7
		public void OnUpdateData(UIEvent iEvent)
		{
			this.UpdateMainContent();
		}

		// Token: 0x0600FC8D RID: 64653 RVA: 0x00456CAF File Offset: 0x004550AF
		private void UpdateFrame()
		{
			this.UpdateMainContent();
		}

		// Token: 0x0600FC8E RID: 64654 RVA: 0x00456CB8 File Offset: 0x004550B8
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

		// Token: 0x0600FC8F RID: 64655 RVA: 0x00456DAC File Offset: 0x004551AC
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

		// Token: 0x0600FC90 RID: 64656 RVA: 0x00456E8C File Offset: 0x0045528C
		private void UpdateItem(bool bForceScorll = false)
		{
			if (bForceScorll)
			{
				int num = -1;
				switch (this.mPayReturnScrollState)
				{
				case SecondPayFrame.PayReturnSrcollState.Head_Left_Most:
				case SecondPayFrame.PayReturnSrcollState.Tail_Right_Most:
					num = this.index_flag;
					break;
				case SecondPayFrame.PayReturnSrcollState.Middle_Left:
					num = this.index_flag - 1;
					if (num < 1)
					{
						num = 1;
					}
					break;
				case SecondPayFrame.PayReturnSrcollState.Middle_Right:
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
				this.mPayReturnScrollState = SecondPayFrame.PayReturnSrcollState.Head_Left_Most;
				this.SetPayReturnLeftBtnActive(false);
				this.SetPayReturnRightBtnActive(true);
			}
			else if (this.index_flag == this.totalRewardLevelNum - 1)
			{
				this.mPayReturnScrollState = SecondPayFrame.PayReturnSrcollState.Tail_Right_Most;
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(false);
			}
			else
			{
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(true);
			}
		}

		// Token: 0x0600FC91 RID: 64657 RVA: 0x00457170 File Offset: 0x00455570
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
			this.mScrollUIList.SetElementAmount(this.awardItemDataList.Count);
			if (this.mSpecialItem && selectPayActId > 0)
			{
				int payReturnSpecialResID = Singleton<PayManager>.GetInstance().GetPayReturnSpecialResID(selectPayActId, this.awardItemDataList);
				ItemData detailData = ItemDataManager.CreateItemDataFromTable(payReturnSpecialResID, 100, 0);
				if (detailData == null)
				{
					this.mSpecialItem.gameObject.SetActive(false);
					Logger.LogErrorFormat("Can find !!! Please Check item data id {0} !!!", new object[]
					{
						payReturnSpecialResID
					});
					return;
				}
				this.mSpecialItem.gameObject.SetActive(true);
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

		// Token: 0x0600FC92 RID: 64658 RVA: 0x00457334 File Offset: 0x00455734
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

		// Token: 0x0600FC93 RID: 64659 RVA: 0x0045742C File Offset: 0x0045582C
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

		// Token: 0x0600FC94 RID: 64660 RVA: 0x00457498 File Offset: 0x00455898
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

		// Token: 0x0600FC95 RID: 64661 RVA: 0x004574E8 File Offset: 0x004558E8
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
			this.mPayReturnScrollState = SecondPayFrame.PayReturnSrcollState.Middle_Right;
		}

		// Token: 0x0600FC96 RID: 64662 RVA: 0x00457596 File Offset: 0x00455996
		private void SetGetBtnShow(bool bShow)
		{
			if (this.mBtnGet)
			{
				this.mBtnGet.CustomActive(bShow);
			}
		}

		// Token: 0x0600FC97 RID: 64663 RVA: 0x004575B4 File Offset: 0x004559B4
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

		// Token: 0x0600FC98 RID: 64664 RVA: 0x004575F4 File Offset: 0x004559F4
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

		// Token: 0x0600FC99 RID: 64665 RVA: 0x00457687 File Offset: 0x00455A87
		private void SetGetBtnText(string desc)
		{
			if (this.mBtnGetText)
			{
				this.mBtnGetText.text = desc;
			}
		}

		// Token: 0x0600FC9A RID: 64666 RVA: 0x004576A5 File Offset: 0x00455AA5
		private bool BeGetBtnCDOver()
		{
			return !(this.mBtnGetPayCD != null) || this.mBtnGetPayCD.bCDOver;
		}

		// Token: 0x0600FC9B RID: 64667 RVA: 0x004576C8 File Offset: 0x00455AC8
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

		// Token: 0x0600FC9C RID: 64668 RVA: 0x00457758 File Offset: 0x00455B58
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

		// Token: 0x0600FC9D RID: 64669 RVA: 0x004577E8 File Offset: 0x00455BE8
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

		// Token: 0x0600FC9E RID: 64670 RVA: 0x0045784C File Offset: 0x00455C4C
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

		// Token: 0x0600FC9F RID: 64671 RVA: 0x004578BE File Offset: 0x00455CBE
		[UIEventHandle("btnClose")]
		private void OnClickClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<SecondPayFrame>(null, false);
		}

		// Token: 0x0600FCA0 RID: 64672 RVA: 0x004578CC File Offset: 0x00455CCC
		private void OnShowTipsFromJob(int result)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600FCA1 RID: 64673 RVA: 0x004578FC File Offset: 0x00455CFC
		private void OnShowTips(int itemID)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600FCA2 RID: 64674 RVA: 0x0045792C File Offset: 0x00455D2C
		protected override void _bindExUI()
		{
			this.mBtnGo = this.mBind.GetCom<Button>("btnGo");
			if (null != this.mBtnGo)
			{
				this.mBtnGo.onClick.AddListener(new UnityAction(this._onBtnGoButtonClick));
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

		// Token: 0x0600FCA3 RID: 64675 RVA: 0x00457C58 File Offset: 0x00456058
		protected override void _unbindExUI()
		{
			if (null != this.mBtnGo)
			{
				this.mBtnGo.onClick.RemoveListener(new UnityAction(this._onBtnGoButtonClick));
			}
			this.mBtnGo = null;
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

		// Token: 0x0600FCA4 RID: 64676 RVA: 0x00457E1C File Offset: 0x0045621C
		private void _onBtnGoButtonClick()
		{
			this.OnClickClose();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallNewFrame>(null, false);
			}
			MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
			{
				MallNewType = MallNewType.ReChargeMall
			}, string.Empty) as MallNewFrame;
		}

		// Token: 0x0600FCA5 RID: 64677 RVA: 0x00457E70 File Offset: 0x00456270
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

		// Token: 0x0600FCA6 RID: 64678 RVA: 0x00457F28 File Offset: 0x00456328
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

		// Token: 0x0600FCA7 RID: 64679 RVA: 0x00457F9C File Offset: 0x0045639C
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

		// Token: 0x0600FCA8 RID: 64680 RVA: 0x00457FE9 File Offset: 0x004563E9
		private void _onPayReturnRightBtnButtonClick()
		{
			if (this.mPayReturnScrollState == SecondPayFrame.PayReturnSrcollState.Tail_Right_Most)
			{
				return;
			}
			this.mPayReturnScrollState = SecondPayFrame.PayReturnSrcollState.Middle_Right;
			this.UpdateItem(true);
		}

		// Token: 0x0600FCA9 RID: 64681 RVA: 0x00458006 File Offset: 0x00456406
		private void _onPayReturnLeftBtnButtonClick()
		{
			if (this.mPayReturnScrollState == SecondPayFrame.PayReturnSrcollState.Head_Left_Most)
			{
				return;
			}
			this.mPayReturnScrollState = SecondPayFrame.PayReturnSrcollState.Middle_Left;
			this.UpdateItem(true);
		}

		// Token: 0x04009E40 RID: 40512
		protected const string payRewardItemResPath = "UIFlatten/Prefabs/Vip/PayRewardItem";

		// Token: 0x04009E41 RID: 40513
		protected const string EffUI_shouchong_guang_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guang";

		// Token: 0x04009E42 RID: 40514
		protected const string EffUI_shouchong_qian_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_qian";

		// Token: 0x04009E43 RID: 40515
		protected const string EffUI_shouchong_jiantou_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_jiantou";

		// Token: 0x04009E44 RID: 40516
		protected const string EffUI_shouchong_zi_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_zi";

		// Token: 0x04009E45 RID: 40517
		protected const string EffUI_shouchong_anniu_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_anniu";

		// Token: 0x04009E46 RID: 40518
		private SecondPayFrame.PayReturnSrcollState mPayReturnScrollState = SecondPayFrame.PayReturnSrcollState.Middle_Right;

		// Token: 0x04009E47 RID: 40519
		private int payRewardLevelShowNum = 3;

		// Token: 0x04009E48 RID: 40520
		private int totalRewardLevelNum;

		// Token: 0x04009E49 RID: 40521
		private int payRewardLevelIndex = -1;

		// Token: 0x04009E4A RID: 40522
		private bool flag;

		// Token: 0x04009E4B RID: 40523
		private int index_flag = -1;

		// Token: 0x04009E4C RID: 40524
		private int index_unfinish = -1;

		// Token: 0x04009E4D RID: 40525
		private int index_canget = -1;

		// Token: 0x04009E4E RID: 40526
		private int NowID = -1;

		// Token: 0x04009E4F RID: 40527
		private bool hasSecondPay;

		// Token: 0x04009E50 RID: 40528
		private bool bGotReward;

		// Token: 0x04009E51 RID: 40529
		private string mToGetRewardText = string.Empty;

		// Token: 0x04009E52 RID: 40530
		private string mNotGetRewardText = string.Empty;

		// Token: 0x04009E53 RID: 40531
		private string mGotRewardText = string.Empty;

		// Token: 0x04009E54 RID: 40532
		private GameObject effect_guang_go;

		// Token: 0x04009E55 RID: 40533
		private GameObject effect_qian_go;

		// Token: 0x04009E56 RID: 40534
		private GameObject effect_zi_go;

		// Token: 0x04009E57 RID: 40535
		private GameObject effect_left_jiantou_go;

		// Token: 0x04009E58 RID: 40536
		private GameObject effect_right_jiantou_go;

		// Token: 0x04009E59 RID: 40537
		private GameObject effect_goPayBtn_go;

		// Token: 0x04009E5A RID: 40538
		private List<PayRewardItem> payRewardItems = new List<PayRewardItem>();

		// Token: 0x04009E5B RID: 40539
		private List<PayRewardLevelTab> payRewardLevelTabs = new List<PayRewardLevelTab>();

		// Token: 0x04009E5C RID: 40540
		private Dictionary<uint, int> itemDataDic = new Dictionary<uint, int>();

		// Token: 0x04009E5D RID: 40541
		private List<AwardItemData> awardItemDataList = new List<AwardItemData>();

		// Token: 0x04009E5E RID: 40542
		private List<ActiveManager.ActivityData> items = new List<ActiveManager.ActivityData>();

		// Token: 0x04009E5F RID: 40543
		private Button mBtnGo;

		// Token: 0x04009E60 RID: 40544
		private UIGray mBtnGetGray;

		// Token: 0x04009E61 RID: 40545
		private Text mBtnGetText;

		// Token: 0x04009E62 RID: 40546
		private PayButtonCountDown mBtnGetPayCD;

		// Token: 0x04009E63 RID: 40547
		private Button mBtnGet;

		// Token: 0x04009E64 RID: 40548
		private Text mRMBValue;

		// Token: 0x04009E65 RID: 40549
		private Text mTotalValue;

		// Token: 0x04009E66 RID: 40550
		private Text mHavePay;

		// Token: 0x04009E67 RID: 40551
		private PayRewardItem mSpecialItem;

		// Token: 0x04009E68 RID: 40552
		private ComUIListScript mScrollUIList;

		// Token: 0x04009E69 RID: 40553
		private ComUIListScript mTabScrollUIList;

		// Token: 0x04009E6A RID: 40554
		private GameObject mPayTabs;

		// Token: 0x04009E6B RID: 40555
		private Button mGotoMoneyplan;

		// Token: 0x04009E6C RID: 40556
		private Button mGotoMonthCard;

		// Token: 0x04009E6D RID: 40557
		private Button mPayReturnRightBtn;

		// Token: 0x04009E6E RID: 40558
		private Button mPayReturnLeftBtn;

		// Token: 0x04009E6F RID: 40559
		private PayRMBItem mPayRMB;

		// Token: 0x04009E70 RID: 40560
		private GridLayoutGroup mScrollUIListContentGrid;

		// Token: 0x04009E71 RID: 40561
		private GameObject mEffectRoot_Backlight;

		// Token: 0x04009E72 RID: 40562
		private GameObject mEffectRoot_TopTitle;

		// Token: 0x04009E73 RID: 40563
		private GameObject mEffectRoot_Envior;

		// Token: 0x04009E74 RID: 40564
		private GameObject mEffectRoot_LeftBtn;

		// Token: 0x04009E75 RID: 40565
		private GameObject mEffectRoot_RightBtn;

		// Token: 0x04009E76 RID: 40566
		private GameObject mEffectRoot_GoPayBtn;

		// Token: 0x02001961 RID: 6497
		private enum PayReturnSrcollState
		{
			// Token: 0x04009E7A RID: 40570
			Head_Left_Most,
			// Token: 0x04009E7B RID: 40571
			Middle_Left,
			// Token: 0x04009E7C RID: 40572
			Middle_Right,
			// Token: 0x04009E7D RID: 40573
			Tail_Right_Most
		}
	}
}
