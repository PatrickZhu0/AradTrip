using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015CD RID: 5581
	internal class EquipReturnFrame : ClientFrame
	{
		// Token: 0x0600DAA3 RID: 55971 RVA: 0x003700BA File Offset: 0x0036E4BA
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipRecovery/EquipReturnFrame";
		}

		// Token: 0x0600DAA4 RID: 55972 RVA: 0x003700C1 File Offset: 0x0036E4C1
		protected sealed override void _OnOpenFrame()
		{
			this._InitData();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DAA5 RID: 55973 RVA: 0x003700CF File Offset: 0x0036E4CF
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DAA6 RID: 55974 RVA: 0x003700E0 File Offset: 0x0036E4E0
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipRedeemSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipRedeemSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipRecoveryUpdateTime, new ClientEventSystem.UIEventHandler(this._OnEquipRecoveryUpdateTime));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipRecivertDeleteItem, new ClientEventSystem.UIEventHandler(this._OnUpdateDisplayList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipReturnFail, new ClientEventSystem.UIEventHandler(this._OnEquipReturnFail));
		}

		// Token: 0x0600DAA7 RID: 55975 RVA: 0x00370174 File Offset: 0x0036E574
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipRedeemSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipRedeemSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipRecoveryUpdateTime, new ClientEventSystem.UIEventHandler(this._OnEquipRecoveryUpdateTime));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipRecivertDeleteItem, new ClientEventSystem.UIEventHandler(this._OnUpdateDisplayList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipReturnFail, new ClientEventSystem.UIEventHandler(this._OnEquipReturnFail));
		}

		// Token: 0x0600DAA8 RID: 55976 RVA: 0x00370208 File Offset: 0x0036E608
		private void _InitData()
		{
			this.returnEquipList.Clear();
			this._SendTimeReq();
			this._InitReturnItemScrollListBind();
			this._UpdateScore();
			this._UpdateEquipList();
			this.canUseReturnBtn = true;
		}

		// Token: 0x0600DAA9 RID: 55977 RVA: 0x00370234 File Offset: 0x0036E634
		private void _ClearData()
		{
			this.lastTime = 0f;
			this.curTime = 1f;
			this.updateTime = 0UL;
			this.haveGetTime = false;
			this.canUseReturnBtn = true;
			this.nowScore = 0;
			this.canReturnScore = 0;
			this.returnEquipList.Clear();
		}

		// Token: 0x0600DAAA RID: 55978 RVA: 0x00370288 File Offset: 0x0036E688
		private void _UpdateScore()
		{
			this.nowScore = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_REWARD_SCORE);
			this.mHaveCount.text = this.nowScore.ToString();
			this.canReturnScore = this._GetReturnScore();
			this.mCanRedeemCount.text = this.canReturnScore.ToString();
			this._UpdateEquipList();
		}

		// Token: 0x0600DAAB RID: 55979 RVA: 0x003702F4 File Offset: 0x0036E6F4
		private void _UpdateTime(ulong time)
		{
			this.haveGetTime = true;
			this.updateTime = time;
		}

		// Token: 0x0600DAAC RID: 55980 RVA: 0x00370304 File Offset: 0x0036E704
		private int _GetReturnScore()
		{
			List<int> jarKeyList = DataManager<EquipRecoveryDataManager>.GetInstance().jarKeyList;
			int num = 0;
			for (int i = 0; i < jarKeyList.Count; i++)
			{
				if (DataManager<EquipRecoveryDataManager>.GetInstance()._GetJarState(i + 1) == RewardJarStatic.HaveOpen)
				{
					num = jarKeyList[i];
				}
			}
			return this.nowScore - num;
		}

		// Token: 0x0600DAAD RID: 55981 RVA: 0x00370358 File Offset: 0x0036E758
		private void _UpdateEquipList()
		{
			this._RefreshItemListCount();
		}

		// Token: 0x0600DAAE RID: 55982 RVA: 0x00370360 File Offset: 0x0036E760
		private void _RefreshItemListCount()
		{
			this.returnEquipList.Clear();
			List<ulong> list = new List<ulong>();
			list = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.EquipRecovery);
			for (int i = 0; i < list.Count; i++)
			{
				this.returnEquipList.Add(list[i]);
			}
			this.mTips.CustomActive(this.returnEquipList.Count == 0);
			this.mEquipUIList.SetElementAmount(this.returnEquipList.Count);
		}

		// Token: 0x0600DAAF RID: 55983 RVA: 0x003703E3 File Offset: 0x0036E7E3
		private void _SendTimeReq()
		{
			DataManager<EquipRecoveryDataManager>.GetInstance()._SendReturnTimeReq();
		}

		// Token: 0x0600DAB0 RID: 55984 RVA: 0x003703F0 File Offset: 0x0036E7F0
		private void _InitReturnItemScrollListBind()
		{
			this.mEquipUIList.Initialize();
			this.mEquipUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateItemScrollListBind(item);
				}
			};
			this.mEquipUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("redeem");
				if (com != null)
				{
					com.onClick.RemoveAllListeners();
				}
			};
		}

		// Token: 0x0600DAB1 RID: 55985 RVA: 0x00370448 File Offset: 0x0036E848
		private void _UpdateItemScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.returnEquipList.Count)
			{
				return;
			}
			ulong guid = this.returnEquipList[item.m_index];
			ItemData itemData = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (itemData == null)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("itemRoot");
			Text com = component.GetCom<Text>("itemName");
			Text com2 = component.GetCom<Text>("count");
			Button com3 = component.GetCom<Button>("redeem");
			GameObject gameObject2 = component.GetGameObject("cannotRedeem");
			float goldMoney = 0f;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(385, string.Empty, string.Empty);
			if (tableItem != null && tableItem2 != null)
			{
				goldMoney = (float)(tableItem.RecommendPrice * tableItem2.Value) * 0.01f;
			}
			com3.onClick.RemoveAllListeners();
			com3.onClick.AddListener(delegate()
			{
				if (this.canUseReturnBtn)
				{
					float goldCount = 0f;
					int goldID = 0;
					SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(384, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						goldCount = (float)tableItem3.Value;
						if (goldCount < goldMoney)
						{
							goldCount = goldMoney;
						}
					}
					SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(383, string.Empty, string.Empty);
					if (tableItem4 != null)
					{
						goldID = tableItem4.Value;
					}
					string msgContent = string.Format(TR.Value("equip_return_tip"), goldCount);
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
						costInfo.nMoneyID = goldID;
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						costInfo.nCount = (int)goldCount;
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
						{
							<_UpdateItemScrollListBind>c__AnonStorey.canUseReturnBtn = false;
							DataManager<EquipRecoveryDataManager>.GetInstance()._RedeemEquip(guid);
						}, "common_money_cost", null);
					}, null, 0f, false);
				}
			});
			if (ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0) != null)
			{
				ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = base.CreateComItem(gameObject);
				}
				int tableID = itemData.TableID;
				comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
				{
					this._OnShowTips(itemData);
				});
			}
			com.text = itemData.Name;
			com2.text = itemData.RecoScore.ToString();
			bool flag = itemData.RecoScore <= this.canReturnScore;
			com3.CustomActive(flag);
			gameObject2.CustomActive(!flag);
		}

		// Token: 0x0600DAB2 RID: 55986 RVA: 0x00370666 File Offset: 0x0036EA66
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600DAB3 RID: 55987 RVA: 0x0037067F File Offset: 0x0036EA7F
		private void _OnEquipRedeemSuccess(UIEvent eventID)
		{
			this._UpdateEquipList();
			this.canUseReturnBtn = true;
		}

		// Token: 0x0600DAB4 RID: 55988 RVA: 0x0037068E File Offset: 0x0036EA8E
		private void _OnCountValueChange(UIEvent eventID)
		{
			this._UpdateScore();
		}

		// Token: 0x0600DAB5 RID: 55989 RVA: 0x00370696 File Offset: 0x0036EA96
		private void _OnEquipRecoveryUpdateTime(UIEvent eventID)
		{
			this._UpdateTime((ulong)eventID.Param1);
		}

		// Token: 0x0600DAB6 RID: 55990 RVA: 0x003706A9 File Offset: 0x0036EAA9
		private void _OnUpdateDisplayList(UIEvent eventID)
		{
			this._RefreshItemListCount();
		}

		// Token: 0x0600DAB7 RID: 55991 RVA: 0x003706B1 File Offset: 0x0036EAB1
		private void _OnEquipReturnFail(UIEvent eventID)
		{
			this.canUseReturnBtn = true;
		}

		// Token: 0x0600DAB8 RID: 55992 RVA: 0x003706BA File Offset: 0x0036EABA
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600DAB9 RID: 55993 RVA: 0x003706C0 File Offset: 0x0036EAC0
		protected override void _OnUpdate(float _LastTime)
		{
			if (this.haveGetTime)
			{
				this.mTime.CustomActive(true);
				this.curTime = Time.time;
				if (this.curTime - this.lastTime >= 1f)
				{
					int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
					int num = (int)(this.updateTime / 1000UL);
					if (num - serverTime > 0)
					{
						this.mTime.text = Function.SetShowTimeHour((int)(this.updateTime / 1000UL));
						this.lastTime = this.curTime;
					}
					else
					{
						this._SendTimeReq();
					}
				}
			}
			else
			{
				this.mTime.CustomActive(false);
			}
		}

		// Token: 0x0600DABA RID: 55994 RVA: 0x00370770 File Offset: 0x0036EB70
		protected override void _bindExUI()
		{
			this.mEquipItem = this.mBind.GetCom<ComUIListElementScript>("equipItem");
			this.mCanRedeemCount = this.mBind.GetCom<Text>("canRedeemCount");
			this.mHaveCount = this.mBind.GetCom<Text>("haveCount");
			this.mEquipUIList = this.mBind.GetCom<ComUIListScript>("equipUIList");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mTime = this.mBind.GetCom<Text>("time");
			this.mTips = this.mBind.GetGameObject("tips");
		}

		// Token: 0x0600DABB RID: 55995 RVA: 0x00370834 File Offset: 0x0036EC34
		protected override void _unbindExUI()
		{
			this.mEquipItem = null;
			this.mCanRedeemCount = null;
			this.mHaveCount = null;
			this.mEquipUIList = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mTime = null;
			this.mTips = null;
		}

		// Token: 0x0600DABC RID: 55996 RVA: 0x0037088E File Offset: 0x0036EC8E
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<EquipReturnFrame>(this, false);
		}

		// Token: 0x0400809D RID: 32925
		private float lastTime;

		// Token: 0x0400809E RID: 32926
		private float curTime = 1f;

		// Token: 0x0400809F RID: 32927
		private ulong updateTime;

		// Token: 0x040080A0 RID: 32928
		private bool haveGetTime;

		// Token: 0x040080A1 RID: 32929
		private bool canUseReturnBtn = true;

		// Token: 0x040080A2 RID: 32930
		private int nowScore;

		// Token: 0x040080A3 RID: 32931
		private int canReturnScore;

		// Token: 0x040080A4 RID: 32932
		private List<ulong> returnEquipList = new List<ulong>();

		// Token: 0x040080A5 RID: 32933
		private ComUIListElementScript mEquipItem;

		// Token: 0x040080A6 RID: 32934
		private Text mCanRedeemCount;

		// Token: 0x040080A7 RID: 32935
		private Text mHaveCount;

		// Token: 0x040080A8 RID: 32936
		private ComUIListScript mEquipUIList;

		// Token: 0x040080A9 RID: 32937
		private Button mClose;

		// Token: 0x040080AA RID: 32938
		private Text mTime;

		// Token: 0x040080AB RID: 32939
		private GameObject mTips;
	}
}
