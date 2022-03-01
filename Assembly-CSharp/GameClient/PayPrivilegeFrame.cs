using System;
using System.Collections;
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
	// Token: 0x02001959 RID: 6489
	public class PayPrivilegeFrame
	{
		// Token: 0x0600FC3E RID: 64574 RVA: 0x004546A0 File Offset: 0x00452AA0
		public PayPrivilegeFrame(PayPrivilegeFrameData data, GameObject parent, ClientFrame frame)
		{
			if (data != null)
			{
				this.frameData = data;
			}
			else
			{
				this.frameData = new PayPrivilegeFrameData();
				this._InitSelfData();
			}
			this.parent = parent;
			this.THIS = frame;
			if (this.root == null)
			{
				this.root = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Vip/PayPrivilegeView", true, 0U);
				if (this.root != null)
				{
					Utility.AttachTo(this.root, parent, false);
					this.mBind = this.root.GetComponent<ComCommonBind>();
					this._bindExUI();
				}
			}
			this.BindEvent();
		}

		// Token: 0x0600FC3F RID: 64575 RVA: 0x0045478C File Offset: 0x00452B8C
		public void UpdateView(PayPrivilegeFrameData data = null)
		{
			if (data != null)
			{
				this.frameData = data;
			}
			this.InitData();
			this.InitEffectRoot();
			this.UpdateVipPrivilege(false);
		}

		// Token: 0x0600FC40 RID: 64576 RVA: 0x004547B0 File Offset: 0x00452BB0
		public void DestroyView()
		{
			this.CloseView();
			this._unbindExUI();
			this.UnBindEvent();
			if (this.frameData != null)
			{
				this.frameData.ClearData();
			}
			this.frameData = null;
			this.parent = null;
			this.THIS = null;
			this.root = null;
			this.mBind = null;
			this._vipZeroControl = null;
		}

		// Token: 0x0600FC41 RID: 64577 RVA: 0x0045480F File Offset: 0x00452C0F
		public void CloseView()
		{
			this.Reset();
		}

		// Token: 0x0600FC42 RID: 64578 RVA: 0x00454817 File Offset: 0x00452C17
		private void InitEffectRoot()
		{
			if (this.effect_guizu_go == null)
			{
				this.effect_guizu_go = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guizu", true, 0U);
				Utility.AttachTo(this.effect_guizu_go, this.mEffectRoot_Envior, false);
			}
		}

		// Token: 0x0600FC43 RID: 64579 RVA: 0x00454854 File Offset: 0x00452C54
		private void ClearEffectRoot()
		{
			if (this.effect_guizu_go)
			{
				Object.Destroy(this.effect_guizu_go);
				this.effect_guizu_go = null;
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
		}

		// Token: 0x0600FC44 RID: 64580 RVA: 0x004548C8 File Offset: 0x00452CC8
		private void Reset()
		{
			this.mVipScrollState = PayPrivilegeFrame.VipSrcollState.Middle_Right;
			this.mVipScorllIndex = -1;
			if (this.mVipDescDataList != null)
			{
				this.mVipDescDataList.Clear();
			}
			if (this.mVipGiftIdList != null)
			{
				this.mVipGiftIdList.Clear();
			}
			if (this.mVipGiftItemList != null)
			{
				this.mVipGiftItemList.Clear();
			}
			if (this.mVipPrivilegeItems != null)
			{
				for (int i = 0; i < this.mVipPrivilegeItems.Count; i++)
				{
					this.mVipPrivilegeItems[i].Clear();
				}
				this.mVipPrivilegeItems.Clear();
			}
			if (this.mVipGiftItems != null)
			{
				for (int j = 0; j < this.mVipGiftItems.Count; j++)
				{
					this.mVipGiftItems[j].Clear();
				}
				this.mVipGiftItems.Clear();
			}
			this.ClearEffectRoot();
		}

		// Token: 0x0600FC45 RID: 64581 RVA: 0x004549B1 File Offset: 0x00452DB1
		private void BindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600FC46 RID: 64582 RVA: 0x004549CE File Offset: 0x00452DCE
		private void UnBindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600FC47 RID: 64583 RVA: 0x004549EC File Offset: 0x00452DEC
		private void InitData()
		{
			if (this.frameData == null)
			{
				Logger.LogErrorFormat("{0} frame data is null !", new object[]
				{
					"PayPrivilegeFrame"
				});
				return;
			}
			this.UpdateVipGiftInfo();
			if (this.mVipGiftIdList != null)
			{
				for (int i = 0; i < this.mVipGiftIdList.Count; i++)
				{
					if (this.mVipGiftIdList[i] == this.frameData.CurShowVipLevel)
					{
						if (this.mNowRMBBtn)
						{
							this.mNowRMBBtn.interactable = false;
						}
						if (this.mNowRMBBtnGray)
						{
							this.mNowRMBBtnGray.enabled = true;
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600FC48 RID: 64584 RVA: 0x00454AA4 File Offset: 0x00452EA4
		private void UpdateVipGiftInfo()
		{
			if (this.mVipGiftIdList == null)
			{
				return;
			}
			CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo("vip_gift_buy_bit");
			if (countInfo != null)
			{
				this.mVipGiftIdList.Clear();
				BitArray bitArray = new BitArray(BitConverter.GetBytes((int)countInfo.value));
				for (int i = 0; i < bitArray.Length; i++)
				{
					bool flag = bitArray[i];
					if (flag)
					{
						this.mVipGiftIdList.Add(i);
					}
				}
			}
		}

		// Token: 0x0600FC49 RID: 64585 RVA: 0x00454B20 File Offset: 0x00452F20
		private void UpdateVipLevelView()
		{
			if (this.frameData == null)
			{
				Logger.LogError("Pay Privilege frame data is null");
				return;
			}
			if (this.frameData.MaxVipLevel <= 0)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.frameData.MaxVipLevel = tableItem.Value;
				}
			}
			if (this.frameData.CurShowVipLevel < 0)
			{
				this.frameData.CurShowVipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
			}
			if (this.frameData.CurShowVipLevel >= this.frameData.MaxVipLevel)
			{
				if (this.mTargetLvRootObj)
				{
					this.mTargetLvRootObj.CustomActive(false);
				}
				if (this.mVipMaxText)
				{
					this.mVipMaxText.gameObject.CustomActive(true);
				}
			}
			this.SetVipZeroShow(this.frameData.CurShowVipLevel == 0);
			if (this.mRechargeMoneyNum)
			{
				string format = TR.Value("vip_month_card_first_buy_cost_desc");
				VipTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<VipTable>(DataManager<PlayerBaseData>.GetInstance().VipLevel, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					this.mRechargeMoneyNum.text = string.Format(format, tableItem2.TotalRmb - DataManager<PlayerBaseData>.GetInstance().CurVipLvRmb);
				}
			}
			if (this.mCurVipLvSingle)
			{
				this.mCurVipLvSingle.gameObject.CustomActive(this.frameData.CurShowVipLevel < 10);
			}
			if (this.mCurVipLvSec)
			{
				this.mCurVipLvSec.gameObject.CustomActive(this.frameData.CurShowVipLevel >= 10);
			}
			if (this.mCurVipLv)
			{
				this.mCurVipLv.gameObject.CustomActive(this.frameData.CurShowVipLevel >= 10);
			}
			if (this.mCurVipLvSingle && this.mCurVipLv)
			{
				if (this.frameData.CurShowVipLevel < 10)
				{
					ETCImageLoader.LoadSprite(ref this.mCurVipLvSingle, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", this.frameData.CurShowVipLevel), true);
				}
				else
				{
					ETCImageLoader.LoadSprite(ref this.mCurVipLvSec, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", this.frameData.CurShowVipLevel / 10), true);
					ETCImageLoader.LoadSprite(ref this.mCurVipLv, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", this.frameData.CurShowVipLevel % 10), true);
				}
			}
			int num = this.frameData.CurShowVipLevel + 1;
			if (this.mCurVipLvSec2)
			{
				this.mCurVipLvSec2.gameObject.CustomActive(true);
			}
			if (this.mCurVipLv2)
			{
				this.mCurVipLv2.gameObject.CustomActive(num >= 10);
			}
			if (this.mCurVipLvSec2 && this.mCurVipLv2)
			{
				if (num < 10)
				{
					ETCImageLoader.LoadSprite(ref this.mCurVipLvSec2, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", num), true);
				}
				else
				{
					ETCImageLoader.LoadSprite(ref this.mCurVipLvSec2, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", num / 10), true);
					ETCImageLoader.LoadSprite(ref this.mCurVipLv2, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", num % 10), true);
				}
			}
			this.DrawVipLevelExpBar(DataManager<PlayerBaseData>.GetInstance().VipLevel, (ulong)((long)DataManager<PlayerBaseData>.GetInstance().CurVipLvRmb), true);
		}

		// Token: 0x0600FC4A RID: 64586 RVA: 0x00454EBC File Offset: 0x004532BC
		private void DrawVipLevelExpBar(int iVipLevel, ulong CurVipLvExp, bool force = false)
		{
			if (this.mCostExp)
			{
				this.mCostExp.SetExp(CurVipLvExp, force, (ulong exp) => Singleton<TableManager>.instance.GetCurVipLevelExp(iVipLevel, exp));
			}
		}

		// Token: 0x0600FC4B RID: 64587 RVA: 0x00454F00 File Offset: 0x00453300
		private void UpdateVipPrivilege(bool bForceUpdate = false)
		{
			if (this.frameData == null)
			{
				Logger.LogError("Pay Privilege frame data is null");
				return;
			}
			int maxVipLevel = this.frameData.MaxVipLevel;
			if (bForceUpdate)
			{
				int num = -1;
				switch (this.mVipScrollState)
				{
				case PayPrivilegeFrame.VipSrcollState.Head_Left_Most:
				case PayPrivilegeFrame.VipSrcollState.Tail_Right_Most:
					num = this.mVipScorllIndex;
					break;
				case PayPrivilegeFrame.VipSrcollState.Middle_Left:
					num = this.mVipScorllIndex - 1;
					if (num < 0)
					{
						num = 0;
					}
					break;
				case PayPrivilegeFrame.VipSrcollState.Middle_Right:
					num = this.mVipScorllIndex + 1;
					if (num > maxVipLevel + 1)
					{
						num = maxVipLevel + 1;
					}
					break;
				}
				this.mVipScorllIndex = num;
			}
			else
			{
				this.mVipScorllIndex = this.frameData.CurShowVipLevel;
			}
			if (this.mVipLevel)
			{
				this.mVipLevel.text = string.Format(TR.Value("vip_month_card_first_buy_privilege_format"), this.mVipScorllIndex);
			}
			this.SetVipZeroShow(this.mVipScorllIndex == 0);
			this.mVipDescDataList = Singleton<PayManager>.GetInstance().GetPrivilegeDescDataListByVipLevel(this.mVipScorllIndex);
			if (this.mVipDescDataList != null)
			{
				this.mVipDescDataList.Sort((VipDescData x, VipDescData y) => x.index.CompareTo(y.index));
				this.RefreshVipDescView(this.mVipScorllIndex == 0);
			}
			VipTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipTable>(this.mVipScorllIndex, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("VipTable hasn't [vip level = {0}] data!", new object[]
				{
					this.mVipScorllIndex
				});
				return;
			}
			if (tableItem.GiftItems == null)
			{
				return;
			}
			bool bActive = true;
			if (tableItem.GiftItems.Count > 0)
			{
				if (tableItem.GiftItems[0] == "-" || tableItem.GiftItems[0] == string.Empty)
				{
					bActive = false;
				}
				if (this.mVipGiftItemList != null)
				{
					this.mVipGiftItemList.Clear();
				}
				for (int i = 0; i < tableItem.GiftItems.Count; i++)
				{
					string[] array = tableItem.GiftItems[i].Split(new char[]
					{
						'_'
					});
					if (array.Length >= 2)
					{
						int tableId = -1;
						int count = 0;
						if (int.TryParse(array[0], out tableId))
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
							if (itemData != null)
							{
								if (int.TryParse(array[1], out count))
								{
									itemData.Count = count;
								}
								if (this.mVipGiftItemList != null)
								{
									this.mVipGiftItemList.Add(itemData);
								}
							}
						}
					}
				}
				this.RefreshVipGiftView();
			}
			else
			{
				bActive = false;
			}
			if (this.mNowRMBBtn)
			{
				this.mNowRMBBtn.gameObject.CustomActive(bActive);
			}
			if (this.mOriginalRMB)
			{
				this.mOriginalRMB.text = tableItem.GiftPrePrice.ToString();
			}
			if (this.mNowRMB)
			{
				this.mNowRMB.text = tableItem.GiftDiscountPrice.ToString();
			}
			this.UpdateGiftBuyButtonState();
			if (this.mVipScorllIndex == 0)
			{
				this.mVipScrollState = PayPrivilegeFrame.VipSrcollState.Head_Left_Most;
				this.SetPayReturnLeftBtnActive(false);
				this.SetPayReturnRightBtnActive(true);
			}
			else if (this.mVipScorllIndex == maxVipLevel)
			{
				this.mVipScrollState = PayPrivilegeFrame.VipSrcollState.Tail_Right_Most;
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(false);
			}
			else
			{
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(true);
			}
			if (this.mPreviewBtn != null)
			{
				this.mPreviewBtn.CustomActive(this.mVipScorllIndex == 2);
			}
		}

		// Token: 0x0600FC4C RID: 64588 RVA: 0x004552C0 File Offset: 0x004536C0
		private void RefreshVipDescView(bool bHide = false)
		{
			if (this.mTopMainView)
			{
				this.mTopMainView.gameObject.CustomActive(!bHide);
			}
			if (this.mSpecialItem)
			{
				this.mSpecialItem.gameObject.CustomActive(!bHide);
			}
			if (bHide)
			{
				return;
			}
			if (this.mVipDescDataList == null)
			{
				return;
			}
			List<VipDescData> tempVipDescDataList = new List<VipDescData>();
			VipDescData vipDescData = null;
			int num = 0;
			for (int i = 0; i < this.mVipDescDataList.Count; i++)
			{
				VipDescData vipDescData2 = this.mVipDescDataList[i];
				if (vipDescData2.bSpecialDisplay)
				{
					num++;
					vipDescData = vipDescData2;
				}
				else if (tempVipDescDataList != null && !tempVipDescDataList.Contains(vipDescData2))
				{
					tempVipDescDataList.Add(vipDescData2);
				}
			}
			if (num > 1)
			{
				Logger.LogErrorFormat("RefreshVipDescView countVipSpecialNum is more than one !!! Please Check VIP Privilege Table", new object[0]);
				return;
			}
			if (num == 0)
			{
				Logger.LogErrorFormat("RefreshVipDescView countVipSpecialNum is zero !!! Please Check VIP Privilege Table", new object[0]);
				return;
			}
			if (tempVipDescDataList == null)
			{
				return;
			}
			if (this.mTopMainView == null)
			{
				return;
			}
			if (!this.mTopMainView.IsInitialised())
			{
				this.mTopMainView.Initialize();
				this.mTopMainView.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mTopMainView.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				int index = var.m_index;
				if (index >= 0 && index < tempVipDescDataList.Count)
				{
					if (tempVipDescDataList[index].bSpecialDisplay)
					{
						return;
					}
					PayRewardItem payRewardItem = var.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this.THIS, null, false, true);
						payRewardItem.SetItemIcon(tempVipDescDataList[index].icon);
						payRewardItem.SetItemName(string.Format("{0}.{1}", index + 1, tempVipDescDataList[index].desc));
						if (this.mVipPrivilegeItems != null && !this.mVipPrivilegeItems.Contains(payRewardItem))
						{
							this.mVipPrivilegeItems.Add(payRewardItem);
						}
					}
				}
			};
			this.mTopMainView.SetElementAmount(tempVipDescDataList.Count);
			this.mTopMainView.ResetContentPosition();
			if (this.mSpecialItem != null && vipDescData != null)
			{
				this.mSpecialItem.Initialize(this.THIS, null, false, true);
				this.mSpecialItem.SetItemIcon(vipDescData.icon);
				this.mSpecialItem.SetItemName(vipDescData.desc);
			}
		}

		// Token: 0x0600FC4D RID: 64589 RVA: 0x004554C8 File Offset: 0x004538C8
		private void RefreshVipGiftView()
		{
			if (this.mVipGiftItemList == null)
			{
				return;
			}
			if (this.mBottomMainView == null)
			{
				return;
			}
			if (!this.mBottomMainView.IsInitialised())
			{
				this.mBottomMainView.Initialize();
				this.mBottomMainView.onBindItem = delegate(GameObject go)
				{
					PayRewardItem result = null;
					if (go)
					{
						result = go.GetComponent<PayRewardItem>();
					}
					return result;
				};
			}
			this.mBottomMainView.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var == null)
				{
					return;
				}
				int index = var.m_index;
				if (index >= 0 && index < this.mVipGiftItemList.Count)
				{
					PayRewardItem payRewardItem = var.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this.THIS, this.mVipGiftItemList[index], true, false);
						payRewardItem.RefreshView(false, false);
						if (this.mVipGiftItems != null && !this.mVipGiftItems.Contains(payRewardItem))
						{
							this.mVipGiftItems.Add(payRewardItem);
						}
					}
				}
			};
			this.mBottomMainView.SetElementAmount(this.mVipGiftItemList.Count);
		}

		// Token: 0x0600FC4E RID: 64590 RVA: 0x00455564 File Offset: 0x00453964
		private void UpdateGiftBuyButtonState()
		{
			bool flag = false;
			if (this.mVipScorllIndex < 0)
			{
				this.mVipScorllIndex = this.frameData.CurShowVipLevel;
			}
			for (int i = 0; i < this.mVipGiftIdList.Count; i++)
			{
				VipTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipTable>(this.mVipScorllIndex, string.Empty, string.Empty);
				if (tableItem == null || this.mVipGiftIdList[i] == tableItem.GiftID)
				{
					flag = true;
					break;
				}
			}
			if (this.mNowRMBBtnGray)
			{
				this.mNowRMBBtnGray.enabled = flag;
			}
			if (this.mNowRMBBtn)
			{
				this.mNowRMBBtn.interactable = !flag;
			}
		}

		// Token: 0x0600FC4F RID: 64591 RVA: 0x00455628 File Offset: 0x00453A28
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

		// Token: 0x0600FC50 RID: 64592 RVA: 0x004556B8 File Offset: 0x00453AB8
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

		// Token: 0x0600FC51 RID: 64593 RVA: 0x00455748 File Offset: 0x00453B48
		private void SetVipZeroShow(bool bShow)
		{
			if (this.mVip_zero == null)
			{
				return;
			}
			if (bShow)
			{
				CommonUtility.UpdateGameObjectVisible(this.mVip_zero, true);
				if (this._vipZeroControl == null)
				{
					GameObject gameObject = CommonUtility.LoadGameObject(this.mVip_zero);
					if (gameObject != null)
					{
						this._vipZeroControl = gameObject.GetComponent<VipZeroControl>();
					}
					if (this._vipZeroControl != null)
					{
						this._vipZeroControl.InitControl();
					}
				}
				else
				{
					this._vipZeroControl.OnEnableControl();
				}
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.mVip_zero, false);
			}
		}

		// Token: 0x0600FC52 RID: 64594 RVA: 0x004557EB File Offset: 0x00453BEB
		private void OnCounterChanged(UIEvent iEvent)
		{
			this.UpdateVipGiftInfo();
			this.UpdateGiftBuyButtonState();
		}

		// Token: 0x0600FC53 RID: 64595 RVA: 0x004557FC File Offset: 0x00453BFC
		private void _InitSelfData()
		{
			if (this.frameData == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<VipPrivilegeTable>();
			if (table != null)
			{
				this.frameData.PrivilegeNum = table.Count;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.frameData.MaxVipLevel = tableItem.Value;
			}
			this.frameData.CurShowVipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
		}

		// Token: 0x0600FC54 RID: 64596 RVA: 0x0045587C File Offset: 0x00453C7C
		private void _bindExUI()
		{
			if (this.mBind == null)
			{
				Logger.LogError("PayPrivilegeView ComCommonBind is null !!!");
				return;
			}
			this.mVipLevel = this.mBind.GetCom<Text>("vipLevel");
			this.mSpecialItem = this.mBind.GetCom<PayRewardItem>("specialItem");
			this.mTopMainView = this.mBind.GetCom<ComUIListScript>("topMainView");
			this.mVip_zero = this.mBind.GetGameObject("vip_zero");
			this.mBottomMainView = this.mBind.GetCom<ComUIListScript>("bottomMainView");
			this.mOriginalRMB = this.mBind.GetCom<Text>("originalRMB");
			this.mNowRMB = this.mBind.GetCom<Text>("nowRMB");
			this.mNowRMBBtn = this.mBind.GetCom<Button>("nowRMBBtn");
			if (null != this.mNowRMBBtn)
			{
				this.mNowRMBBtn.onClick.AddListener(new UnityAction(this._onNowRMBBtnButtonClick));
			}
			this.mNowRMBBtnGray = this.mBind.GetCom<UIGray>("nowRMBBtnGray");
			this.mPayReturnLeftBtn = this.mBind.GetCom<Button>("payReturnLeftBtn");
			if (null != this.mPayReturnLeftBtn)
			{
				this.mPayReturnLeftBtn.onClick.AddListener(new UnityAction(this._onPayReturnLeftBtnButtonClick));
			}
			this.mPayReturnRightBtn = this.mBind.GetCom<Button>("payReturnRightBtn");
			if (null != this.mPayReturnRightBtn)
			{
				this.mPayReturnRightBtn.onClick.AddListener(new UnityAction(this._onPayReturnRightBtnButtonClick));
			}
			this.mEffectRoot_LeftBtn = this.mBind.GetGameObject("EffectRoot_LeftBtn");
			this.mEffectRoot_RightBtn = this.mBind.GetGameObject("EffectRoot_RightBtn");
			this.mEffectRoot_Envior = this.mBind.GetGameObject("EffectRoot_Envior");
			this.mPreviewBtn = this.mBind.GetCom<Button>("PreviewBtn");
			if (this.mPreviewBtn != null)
			{
				this.mPreviewBtn.onClick.AddListener(new UnityAction(this.OnPreviewBtnClick));
			}
		}

		// Token: 0x0600FC55 RID: 64597 RVA: 0x00455AA4 File Offset: 0x00453EA4
		private void _unbindExUI()
		{
			this.mVipLevel = null;
			this.mSpecialItem = null;
			this.mTopMainView = null;
			this.mVip_zero = null;
			this.mBottomMainView = null;
			this.mOriginalRMB = null;
			this.mNowRMB = null;
			if (null != this.mNowRMBBtn)
			{
				this.mNowRMBBtn.onClick.RemoveListener(new UnityAction(this._onNowRMBBtnButtonClick));
			}
			this.mNowRMBBtn = null;
			this.mNowRMBBtnGray = null;
			if (null != this.mPayReturnLeftBtn)
			{
				this.mPayReturnLeftBtn.onClick.RemoveListener(new UnityAction(this._onPayReturnLeftBtnButtonClick));
			}
			this.mPayReturnLeftBtn = null;
			if (null != this.mPayReturnRightBtn)
			{
				this.mPayReturnRightBtn.onClick.RemoveListener(new UnityAction(this._onPayReturnRightBtnButtonClick));
			}
			this.mPayReturnRightBtn = null;
			this.mEffectRoot_LeftBtn = null;
			this.mEffectRoot_RightBtn = null;
			this.mEffectRoot_Envior = null;
			if (this.mPreviewBtn != null)
			{
				this.mPreviewBtn.onClick.RemoveListener(new UnityAction(this.OnPreviewBtnClick));
			}
			this.mPreviewBtn = null;
		}

		// Token: 0x0600FC56 RID: 64598 RVA: 0x00455BCE File Offset: 0x00453FCE
		private void _onBtnCloseButtonClick()
		{
		}

		// Token: 0x0600FC57 RID: 64599 RVA: 0x00455BD0 File Offset: 0x00453FD0
		private void _onNowRMBBtnButtonClick()
		{
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel < this.mVipScorllIndex)
			{
				SystemNotifyManager.SystemNotify(1084, string.Empty);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			string msgContent = TR.Value("vip_month_card_first_buy_privilege_gift");
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				VipTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipTable>(this.mVipScorllIndex, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
				costInfo.nCount = tableItem.GiftDiscountPrice;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
					SceneVipBuyItemReq sceneVipBuyItemReq = new SceneVipBuyItemReq();
					sceneVipBuyItemReq.vipLevel = (byte)this.mVipScorllIndex;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<SceneVipBuyItemReq>(ServerType.GATE_SERVER, sceneVipBuyItemReq);
				}, "common_money_cost", null);
			}, null, 0f, false);
		}

		// Token: 0x0600FC58 RID: 64600 RVA: 0x00455C38 File Offset: 0x00454038
		private void _onPayReturnLeftBtnButtonClick()
		{
			if (this.mVipScrollState == PayPrivilegeFrame.VipSrcollState.Head_Left_Most)
			{
				return;
			}
			this.mVipScrollState = PayPrivilegeFrame.VipSrcollState.Middle_Left;
			this.UpdateVipPrivilege(true);
		}

		// Token: 0x0600FC59 RID: 64601 RVA: 0x00455C54 File Offset: 0x00454054
		private void _onPayReturnRightBtnButtonClick()
		{
			if (this.mVipScrollState == PayPrivilegeFrame.VipSrcollState.Tail_Right_Most)
			{
				return;
			}
			this.mVipScrollState = PayPrivilegeFrame.VipSrcollState.Middle_Right;
			this.UpdateVipPrivilege(true);
		}

		// Token: 0x0600FC5A RID: 64602 RVA: 0x00455C74 File Offset: 0x00454074
		private void OnPreviewBtnClick()
		{
			if (this.mVipGiftItemList != null && this.mVipGiftItemList.Count > 0)
			{
				ItemData itemData = this.mVipGiftItemList[0];
				if (itemData != null)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, itemData.TableID, string.Empty);
				}
			}
		}

		// Token: 0x04009DF5 RID: 40437
		protected const string EffUI_shouchong_guizu_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_guizu";

		// Token: 0x04009DF6 RID: 40438
		protected const string EffUI_shouchong_jiantou01_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_jiantou01";

		// Token: 0x04009DF7 RID: 40439
		private const string UNUSED_VIP_GIFT_ICON_BG = "UI/Image/Packed/p_UI_Vip.png:UI_Vip_Meiyoujiangli";

		// Token: 0x04009DF8 RID: 40440
		private const string RES_PAY_PRIVILEGE_VIEW_PATH = "UIFlatten/Prefabs/Vip/PayPrivilegeView";

		// Token: 0x04009DF9 RID: 40441
		private PayPrivilegeFrameData frameData;

		// Token: 0x04009DFA RID: 40442
		private GameObject root;

		// Token: 0x04009DFB RID: 40443
		private GameObject parent;

		// Token: 0x04009DFC RID: 40444
		private ClientFrame THIS;

		// Token: 0x04009DFD RID: 40445
		private ComCommonBind mBind;

		// Token: 0x04009DFE RID: 40446
		private GameObject effect_left_jiantou_go;

		// Token: 0x04009DFF RID: 40447
		private GameObject effect_right_jiantou_go;

		// Token: 0x04009E00 RID: 40448
		private GameObject effect_guizu_go;

		// Token: 0x04009E01 RID: 40449
		private List<VipDescData> mVipDescDataList = new List<VipDescData>();

		// Token: 0x04009E02 RID: 40450
		private List<ItemData> mVipGiftItemList = new List<ItemData>();

		// Token: 0x04009E03 RID: 40451
		private List<int> mVipGiftIdList = new List<int>();

		// Token: 0x04009E04 RID: 40452
		private List<PayRewardItem> mVipPrivilegeItems = new List<PayRewardItem>();

		// Token: 0x04009E05 RID: 40453
		private List<PayRewardItem> mVipGiftItems = new List<PayRewardItem>();

		// Token: 0x04009E06 RID: 40454
		private VipZeroControl _vipZeroControl;

		// Token: 0x04009E07 RID: 40455
		private PayPrivilegeFrame.VipSrcollState mVipScrollState = PayPrivilegeFrame.VipSrcollState.Middle_Right;

		// Token: 0x04009E08 RID: 40456
		private int mVipScorllIndex = -1;

		// Token: 0x04009E09 RID: 40457
		private Button mBtnClose;

		// Token: 0x04009E0A RID: 40458
		private Image mCurVipLvSec;

		// Token: 0x04009E0B RID: 40459
		private Image mCurVipLv;

		// Token: 0x04009E0C RID: 40460
		private Image mCurVipLvSingle;

		// Token: 0x04009E0D RID: 40461
		private GameObject mTargetLvRootObj;

		// Token: 0x04009E0E RID: 40462
		private Text mRechargeMoneyNum;

		// Token: 0x04009E0F RID: 40463
		private Image mCurVipLvSec2;

		// Token: 0x04009E10 RID: 40464
		private Image mCurVipLv2;

		// Token: 0x04009E11 RID: 40465
		private GameObject mVipMaxText;

		// Token: 0x04009E12 RID: 40466
		private ComExpBar mCostExp;

		// Token: 0x04009E13 RID: 40467
		private Text mVipLevel;

		// Token: 0x04009E14 RID: 40468
		private PayRewardItem mSpecialItem;

		// Token: 0x04009E15 RID: 40469
		private ComUIListScript mTopMainView;

		// Token: 0x04009E16 RID: 40470
		private GameObject mVip_zero;

		// Token: 0x04009E17 RID: 40471
		private ComUIListScript mBottomMainView;

		// Token: 0x04009E18 RID: 40472
		private Text mOriginalRMB;

		// Token: 0x04009E19 RID: 40473
		private Text mNowRMB;

		// Token: 0x04009E1A RID: 40474
		private Button mNowRMBBtn;

		// Token: 0x04009E1B RID: 40475
		private UIGray mNowRMBBtnGray;

		// Token: 0x04009E1C RID: 40476
		private Button mPayReturnLeftBtn;

		// Token: 0x04009E1D RID: 40477
		private Button mPayReturnRightBtn;

		// Token: 0x04009E1E RID: 40478
		private GameObject mEffectRoot_LeftBtn;

		// Token: 0x04009E1F RID: 40479
		private GameObject mEffectRoot_RightBtn;

		// Token: 0x04009E20 RID: 40480
		private GameObject mEffectRoot_Envior;

		// Token: 0x04009E21 RID: 40481
		private Button mPreviewBtn;

		// Token: 0x0200195A RID: 6490
		private enum VipSrcollState
		{
			// Token: 0x04009E26 RID: 40486
			Head_Left_Most,
			// Token: 0x04009E27 RID: 40487
			Middle_Left,
			// Token: 0x04009E28 RID: 40488
			Middle_Right,
			// Token: 0x04009E29 RID: 40489
			Tail_Right_Most
		}
	}
}
