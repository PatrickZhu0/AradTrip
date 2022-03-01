using System;
using System.Collections.Generic;
using System.ComponentModel;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013A8 RID: 5032
	public class OPPOPrivilegeFrame : ClientFrame
	{
		// Token: 0x0600C353 RID: 50003 RVA: 0x002EA6EA File Offset: 0x002E8AEA
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/OPPOPrivilegeFrame";
		}

		// Token: 0x0600C354 RID: 50004 RVA: 0x002EA6F1 File Offset: 0x002E8AF1
		protected sealed override void _OnOpenFrame()
		{
			this._InitOPPOTABTabs();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			Singleton<GameStatisticManager>.GetInstance().DoStartOPPO(StartOPPOType.OPPOOPEN, string.Empty);
		}

		// Token: 0x0600C355 RID: 50005 RVA: 0x002EA730 File Offset: 0x002E8B30
		protected sealed override void _OnCloseFrame()
		{
			for (int i = 0; i < this.m_kFunctionObject.Length; i++)
			{
				this.m_kFunctionObject[i].Clear();
			}
			Array.Clear(this.m_acPrefabInits, 0, this.m_acPrefabInits.Length);
			this.m_akOPPOTABTabs.DestroyAllObjects();
			this._RemoveAllButtonDelegates();
			this.ClearData();
			this.myDailSevenActivityList.Clear();
			this.myprivilegeActivityList.Clear();
			this.myLuckyGuyTaskPairList.Clear();
			this.itemdata = null;
			this.iCost = 0;
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			this.mAmberPrivilegeView = null;
			this.mOPPOGrowthHaoLiView = null;
		}

		// Token: 0x0600C356 RID: 50006 RVA: 0x002EA7F1 File Offset: 0x002E8BF1
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			this.fTime += timeElapsed;
			if (this.fTime > 1f)
			{
				this.IsUpdate = false;
				this.RefreshPriviPickUpBtn();
			}
		}

		// Token: 0x0600C357 RID: 50007 RVA: 0x002EA81E File Offset: 0x002E8C1E
		public sealed override bool IsNeedUpdate()
		{
			return this.IsUpdate;
		}

		// Token: 0x0600C358 RID: 50008 RVA: 0x002EA828 File Offset: 0x002E8C28
		private bool _CheckActivityIsOpen(int index)
		{
			if (index < 0 || index >= this.activityIds.Length)
			{
				return false;
			}
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.activityIds[index]);
			return activeData != null && activeData.mainInfo.state == 1;
		}

		// Token: 0x0600C359 RID: 50009 RVA: 0x002EA87C File Offset: 0x002E8C7C
		private void _InitOPPOTABTabs()
		{
			this.m_eFunctionType = OPPOPrivilegeFrame.OPPOTABType.OTT_PRIVILRGR;
			GameObject gameObject = Utility.FindChild(this.frame, "TabScrollView/ViewPort/Content");
			GameObject gameObject2 = Utility.FindChild(gameObject, "Filter");
			gameObject2.CustomActive(false);
			Delegate @delegate = Delegate.CreateDelegate(typeof(OPPOPrivilegeFrame.OPPOTABTab.OnFunctionLoad), this, "_OnFunctionLoad");
			for (int i = 0; i < 6; i++)
			{
				if (this._CheckActivityIsOpen(i))
				{
					this.m_akOPPOTABTabs.Create((OPPOPrivilegeFrame.OPPOTABType)i, new object[]
					{
						gameObject,
						gameObject2,
						i,
						this,
						@delegate
					});
					this.m_kFunctionObject[i].Clear();
					this.m_aInits[i] = false;
				}
			}
			this.m_akOPPOTABTabs.Filter(null);
			this.m_akOPPOTABTabs.GetObject(this.m_eFunctionType).toggle.isOn = true;
		}

		// Token: 0x0600C35A RID: 50010 RVA: 0x002EA958 File Offset: 0x002E8D58
		private void _OnFunctionLoad(OPPOPrivilegeFrame.OPPOTABType eOPPOTABType)
		{
			switch (eOPPOTABType)
			{
			case OPPOPrivilegeFrame.OPPOTABType.OTT_PRIVILRGR:
				if (this.m_acPrefabInits[0] == '\0')
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes(this.m_Prefabs[0], typeof(GameObject), true, 0U).obj as GameObject;
					gameObject.name = "Privilege";
					Utility.AttachTo(gameObject, this.goChildFrame, false);
					this.m_kFunctionObject[0].Add(gameObject);
					this.m_acPrefabInits[0] = '\u0001';
				}
				break;
			case OPPOPrivilegeFrame.OPPOTABType.OTT_LUCKYGUY:
				if (this.m_acPrefabInits[1] == '\0')
				{
					GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadRes(this.m_Prefabs[1], typeof(GameObject), true, 0U).obj as GameObject;
					gameObject2.name = "LuckyTurnTable";
					Utility.AttachTo(gameObject2, this.goChildFrame, false);
					this.m_kFunctionObject[1].Add(gameObject2);
					this.m_acPrefabInits[1] = '\u0001';
				}
				break;
			case OPPOPrivilegeFrame.OPPOTABType.OTT_AMBERPRIVILEGE:
				if (this.m_acPrefabInits[4] == '\0')
				{
					GameObject gameObject3 = Singleton<AssetLoader>.instance.LoadRes(this.m_Prefabs[4], typeof(GameObject), true, 0U).obj as GameObject;
					gameObject3.name = "AmberPrivilege";
					Utility.AttachTo(gameObject3, this.goChildFrame, false);
					this.m_kFunctionObject[2].Add(gameObject3);
					this.m_acPrefabInits[4] = '\u0001';
				}
				break;
			case OPPOPrivilegeFrame.OPPOTABType.OTT_AMBERGIFTBAG:
				if (this.m_acPrefabInits[2] == '\0')
				{
					GameObject gameObject4 = Singleton<AssetLoader>.instance.LoadRes(this.m_Prefabs[2], typeof(GameObject), true, 0U).obj as GameObject;
					gameObject4.name = "AmbergiftBag";
					Utility.AttachTo(gameObject4, this.goChildFrame, false);
					this.m_kFunctionObject[3].Add(gameObject4);
					this.m_acPrefabInits[2] = '\u0001';
				}
				break;
			case OPPOPrivilegeFrame.OPPOTABType.OTT_DAILYCHECK:
				if (this.m_acPrefabInits[3] == '\0')
				{
					GameObject gameObject5 = Singleton<AssetLoader>.instance.LoadRes(this.m_Prefabs[3], typeof(GameObject), true, 0U).obj as GameObject;
					gameObject5.name = "DailyCheck";
					Utility.AttachTo(gameObject5, this.goChildFrame, false);
					this.m_kFunctionObject[4].Add(gameObject5);
					this.m_acPrefabInits[3] = '\u0001';
				}
				break;
			case OPPOPrivilegeFrame.OPPOTABType.OTT_OPPOGROWTHHAOLI:
				if (this.m_acPrefabInits[5] == '\0')
				{
					GameObject gameObject6 = Singleton<AssetLoader>.instance.LoadRes(this.m_Prefabs[5], typeof(GameObject), true, 0U).obj as GameObject;
					if (gameObject6 != null)
					{
						gameObject6.name = "OPPOGrowthHaoLiView";
						Utility.AttachTo(gameObject6, this.goChildFrame, false);
						this.m_kFunctionObject[5].Add(gameObject6);
						this.m_acPrefabInits[5] = '\u0001';
					}
				}
				break;
			}
		}

		// Token: 0x0600C35B RID: 50011 RVA: 0x002EAC1C File Offset: 0x002E901C
		private void ClearData()
		{
			this.DailyItemList.Clear();
			this.ProgresssList.Clear();
			this.GaoLiangs.Clear();
			this.CountersignList.Clear();
			this.Receives.Clear();
			this.ItemPosList.Clear();
			this.SignList.Clear();
			this.GrayLisy.Clear();
			this.ItemCountList.Clear();
			this.myActivityList.Clear();
			this.CtsSignBtnList.Clear();
		}

		// Token: 0x0600C35C RID: 50012 RVA: 0x002EACA4 File Offset: 0x002E90A4
		private void OnFunctionChanged(OPPOPrivilegeFrame.OPPOTABType eOPPOTABType)
		{
			this.m_eFunctionType = eOPPOTABType;
			for (int i = 0; i < this.m_kFunctionObject.Length; i++)
			{
				if (this.m_eFunctionType != (OPPOPrivilegeFrame.OPPOTABType)i)
				{
					for (int j = 0; j < this.m_kFunctionObject[i].Count; j++)
					{
						this.m_kFunctionObject[i][j].CustomActive(false);
					}
				}
			}
			for (int k = 0; k < this.m_kFunctionObject[(int)eOPPOTABType].Count; k++)
			{
				this.m_kFunctionObject[(int)eOPPOTABType][k].CustomActive(true);
			}
			if (!this.m_aInits[(int)this.m_eFunctionType])
			{
				if (this.m_eFunctionType == OPPOPrivilegeFrame.OPPOTABType.OTT_DAILYCHECK)
				{
					this.ClearData();
					this.DailyItems = Utility.FindChild(this.frame, "ChildFrame/DailyCheck/Items");
					this.Slider = Utility.FindChild(this.frame, "ChildFrame/DailyCheck/Buttom/Slider");
					this.Box = Utility.FindChild(this.frame, "ChildFrame/DailyCheck/Buttom/Box");
					this.ThisWeekNum = Utility.FindComponent<Text>(this.frame, "ChildFrame/DailyCheck/ThisWeek/Num", true);
					this.LeakageSignNum = Utility.FindComponent<Text>(this.frame, "ChildFrame/DailyCheck/LeakageSign/Num", true);
					this.RetroactiveGray = Utility.FindComponent<UIGray>(this.frame, "ChildFrame/DailyCheck/Button", true);
					this.RetroactiveBtn = Utility.FindComponent<Button>(this.frame, "ChildFrame/DailyCheck/Button", true);
					this.isDail = true;
					this._FinAllComponents();
					this.CreatDailItem();
					this.GetDailSevenItemData();
					this.UpdateCompomentState();
					this._AddButton("ChildFrame/DailyCheck/Button", new UnityAction(this.OnRapidRetroactiveClick));
				}
				else if (this.m_eFunctionType == OPPOPrivilegeFrame.OPPOTABType.OTT_PRIVILRGR)
				{
					this.m_comRewardItemList = Utility.FindComponent<ComUIListScript>(this.frame, "ChildFrame/Privilege/Items", true);
					this.gray = Utility.FindComponent<UIGray>(this.frame, "ChildFrame/Privilege/OK", true);
					this.OKText = Utility.FindComponent<Text>(this.frame, "ChildFrame/Privilege/OK/Text", true);
					this._InitRewardItemList();
					this.GetPriviItemData();
					this._AddButton("ChildFrame/Privilege/OK", new UnityAction(this.OnOKButtonClick));
				}
				else if (this.m_eFunctionType == OPPOPrivilegeFrame.OPPOTABType.OTT_LUCKYGUY)
				{
					this.Count = Utility.FindComponent<Text>(this.frame, "ChildFrame/LuckyTurnTable/Count", true);
					this.TotalCount = Utility.FindComponent<Text>(this.frame, "ChildFrame/LuckyTurnTable/TotalCount", true);
					this.items = Utility.FindChild(this.frame, "ChildFrame/LuckyTurnTable/Items");
					this.startGray = Utility.FindComponent<UIGray>(this.frame, "ChildFrame/LuckyTurnTable/Start", true);
					this.startBtn = Utility.FindComponent<Button>(this.frame, "ChildFrame/LuckyTurnTable/Start", true);
					this.zhizhen = Utility.FindChild(this.frame, "ChildFrame/LuckyTurnTable/ZhiZhen");
					this.theLuckyRoller = this.zhizhen.GetComponent<TheLuckyRoller>();
					this.zhizhen.transform.eulerAngles = new Vector3(0f, 0f, 0f);
					this.bIsLucky = true;
					this.GetLuckyGuyItemData();
					this.UpdateState();
					this.CreatLuckyItems();
					this._AddButton("ChildFrame/LuckyTurnTable/Start", new UnityAction(this.OnRaffleButtonClick));
				}
				else if (this.m_eFunctionType == OPPOPrivilegeFrame.OPPOTABType.OTT_AMBERGIFTBAG)
				{
					ComCommonBind comCommonBind = Utility.FindComponent<ComCommonBind>(this.frame, "ChildFrame/AmbergiftBag", true);
					if (comCommonBind != null)
					{
						this.okBtnText = comCommonBind.GetCom<Text>("OKBtnText");
						this.okBtn = comCommonBind.GetCom<Button>("OKBtn");
						this.okBtn.onClick.RemoveAllListeners();
						this.okBtn.onClick.AddListener(delegate()
						{
							DataManager<ActiveManager>.GetInstance().SendSubmitActivity(this.ActivityID, 0U);
							Singleton<GameStatisticManager>.GetInstance().DoStartOPPO(StartOPPOType.OPPOAMBERGIFT, this.StrAmberLevel);
						});
						this.AmberGiftBagComUIListScript = comCommonBind.GetCom<ComUIListScript>("AmberComUIListScript");
						this.desText = comCommonBind.GetCom<Text>("Des");
						this.okBtnGray = comCommonBind.GetCom<UIGray>("OKBtnUIGray");
					}
					this._InitAmberGiftBagInfo();
				}
				else if (this.m_eFunctionType == OPPOPrivilegeFrame.OPPOTABType.OTT_AMBERPRIVILEGE)
				{
					this.mAmberPrivilegeView = Utility.FindComponent<AmberPrivilegeView>(this.frame, "ChildFrame/AmberPrivilege", true);
					if (this.mAmberPrivilegeView != null)
					{
						this.mAmberPrivilegeView.InitView();
					}
				}
				else if (this.m_eFunctionType == OPPOPrivilegeFrame.OPPOTABType.OTT_OPPOGROWTHHAOLI)
				{
					this.mOPPOGrowthHaoLiView = Utility.FindComponent<OPPOGrowthHaoLiView>(this.frame, "ChildFrame/OPPOGrowthHaoLiView", true);
					if (this.mOPPOGrowthHaoLiView != null)
					{
						this.mOPPOGrowthHaoLiView.InitView();
					}
				}
				this.m_aInits[(int)this.m_eFunctionType] = true;
			}
			if (this.m_eFunctionType == OPPOPrivilegeFrame.OPPOTABType.OTT_LUCKYGUY)
			{
				this.bIsLucky = true;
				if (this.zhizhen != null)
				{
					this.zhizhen.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				}
			}
			else
			{
				this.bIsLucky = false;
			}
		}

		// Token: 0x0600C35D RID: 50013 RVA: 0x002EB150 File Offset: 0x002E9550
		private void _InitAmberGiftBagInfo()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.IActivitytEmplateID);
			if (activeData != null)
			{
				for (int i = 0; i < activeData.akChildItems.Count; i++)
				{
					if (activeData.akChildItems[i].status > 1)
					{
						this.ActivityID = activeData.akChildItems[i].ID;
						this.StatuIndex = activeData.akChildItems[i].status;
						this.StrAmberLevel = this.GetAmberLevel(this.ActivityID);
						if (this.desText != null)
						{
							if (this.ActivityID == 20001)
							{
								this.desText.text = this.StrAmberLevel;
							}
							else
							{
								this.desText.text = TR.Value("oppo_amberlevel_des", this.StrAmberLevel);
							}
						}
						this._InitAmberGiftBagReward(this.ActivityID);
						this._InitAmberGiftBagState(this.StatuIndex);
					}
				}
			}
		}

		// Token: 0x0600C35E RID: 50014 RVA: 0x002EB258 File Offset: 0x002E9658
		private void _InitAmberGiftBagState(byte byIndex)
		{
			if (byIndex == 5)
			{
				if (this.okBtnGray != null && this.okBtnText != null)
				{
					this.okBtnGray.enabled = true;
					this.okBtnText.text = "已领取";
				}
			}
			else if (byIndex == 2)
			{
				if (this.okBtnGray != null && this.okBtnText != null)
				{
					this.okBtnGray.enabled = false;
					this.okBtnText.text = "领取";
				}
			}
			else if (byIndex == 1)
			{
				if (this.okBtnGray != null && this.okBtnText != null)
				{
					this.okBtnGray.enabled = true;
					this.okBtnText.text = "领取";
				}
			}
			else if (byIndex == 3 && this.okBtnGray != null && this.okBtnText != null)
			{
				this.okBtnGray.enabled = true;
				this.okBtnText.text = "领取";
			}
		}

		// Token: 0x0600C35F RID: 50015 RVA: 0x002EB388 File Offset: 0x002E9788
		private string GetAmberLevel(int index)
		{
			if (index == 20001)
			{
				return TR.Value("oppo_notamber");
			}
			if (index == 20002)
			{
				return TR.Value("oppo_greenpearl");
			}
			if (index == 20003)
			{
				return TR.Value("oppo_bluepearl");
			}
			if (index == 20004)
			{
				return TR.Value("oppo_goldpearl");
			}
			if (index == 20005)
			{
				return TR.Value("oppo_redpearl");
			}
			if (index == 20006)
			{
				return TR.Value("oppo_purplepearl");
			}
			return TR.Value("oppo_notamber");
		}

		// Token: 0x0600C360 RID: 50016 RVA: 0x002EB424 File Offset: 0x002E9824
		private void _InitAmberGiftBagReward(int id)
		{
			List<AwardItemData> items = DataManager<ActiveManager>.GetInstance().GetActiveAwards(id);
			if (items != null && this.AmberGiftBagComUIListScript != null)
			{
				this.AmberGiftBagComUIListScript.Initialize();
				this.AmberGiftBagComUIListScript.onBindItem = ((GameObject var) => this.CreateComItem(Utility.FindGameObject(var, "itemPos", true)));
				this.AmberGiftBagComUIListScript.onItemVisiable = delegate(ComUIListElementScript var)
				{
					if (items != null && var.m_index >= 0 && var.m_index < items.Count)
					{
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(items[var.m_index].ID);
						commonItemTableDataByID.Count = items[var.m_index].Num;
						ComItem comItem = var.gameObjectBindScript as ComItem;
						comItem.Setup(commonItemTableDataByID, delegate(GameObject var1, ItemData var2)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
						});
						Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = commonItemTableDataByID.GetColorName(string.Empty, false);
					}
				};
				this.AmberGiftBagComUIListScript.SetElementAmount(items.Count);
			}
		}

		// Token: 0x0600C361 RID: 50017 RVA: 0x002EB4BA File Offset: 0x002E98BA
		private void RefreshPriviPickUpBtn()
		{
			if (!this._CheckPrivilrge())
			{
				return;
			}
			this.IsStartGameFromCenter();
		}

		// Token: 0x0600C362 RID: 50018 RVA: 0x002EB4D0 File Offset: 0x002E98D0
		public bool _CheckPrivilrge()
		{
			int num = 0;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(12000);
			if (activeData == null)
			{
				return false;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				if (activeData.akChildItems[i].status == 2)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600C363 RID: 50019 RVA: 0x002EB538 File Offset: 0x002E9938
		private void IsStartGameFromCenter()
		{
			if (SDKInterface.instance.IsStartFromGameCenter())
			{
				this.gray.enabled = false;
				this.OKText.text = "领取";
			}
			else
			{
				this.gray.enabled = false;
				this.OKText.text = "前往游戏中心";
			}
		}

		// Token: 0x0600C364 RID: 50020 RVA: 0x002EB594 File Offset: 0x002E9994
		private void OnOKButtonClick()
		{
			if (SDKInterface.instance.IsStartFromGameCenter())
			{
				DataManager<ActiveManager>.GetInstance().SendSubmitActivity(12001, 0U);
				Singleton<GameStatisticManager>.GetInstance().DoStartOPPO(StartOPPOType.OPPOPRIVILEGE, string.Empty);
			}
			else
			{
				this.IsUpdate = true;
				SDKInterface.instance.OpenGameCenter();
				Singleton<GameStatisticManager>.GetInstance().DoStartOPPO(StartOPPOType.OPPOJUMPGAMECENTER, string.Empty);
			}
		}

		// Token: 0x0600C365 RID: 50021 RVA: 0x002EB5F8 File Offset: 0x002E99F8
		private void GetPriviItemData()
		{
			this.myprivilegeActivityList.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(12000);
			if (activeData == null)
			{
				Logger.LogErrorFormat("activeData is null", new object[0]);
				return;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				this.myprivilegeActivityList.Add(activeData.akChildItems[i]);
			}
			this.UpdataPrivileState();
		}

		// Token: 0x0600C366 RID: 50022 RVA: 0x002EB670 File Offset: 0x002E9A70
		private void UpdataPrivileState()
		{
			for (int i = 0; i < this.myprivilegeActivityList.Count; i++)
			{
				if (this.myprivilegeActivityList[i].status == 5)
				{
					this.gray.enabled = true;
					this.OKText.text = "已领取";
				}
				else if (this.myprivilegeActivityList[i].status == 2)
				{
					this.IsStartGameFromCenter();
				}
				else if (this.myprivilegeActivityList[i].status == 1)
				{
					this.gray.enabled = false;
					this.OKText.text = "领取";
				}
			}
		}

		// Token: 0x0600C367 RID: 50023 RVA: 0x002EB728 File Offset: 0x002E9B28
		private void _InitRewardItemList()
		{
			List<AwardItemData> items = DataManager<ActiveManager>.GetInstance().GetActiveAwards(12001);
			if (items == null)
			{
				Logger.LogErrorFormat("PrivilegeItems is null ...", new object[0]);
				return;
			}
			this.m_comRewardItemList.Initialize();
			this.m_comRewardItemList.onBindItem = ((GameObject var) => this.CreateComItem(Utility.FindGameObject(var, "itemPos", true)));
			this.m_comRewardItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (items != null && var.m_index >= 0 && var.m_index < items.Count)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(items[var.m_index].ID);
					commonItemTableDataByID.Count = items[var.m_index].Num;
					ComItem comItem = var.gameObjectBindScript as ComItem;
					comItem.Setup(commonItemTableDataByID, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = commonItemTableDataByID.GetColorName(string.Empty, false);
				}
			};
			this.m_comRewardItemList.SetElementAmount(items.Count);
		}

		// Token: 0x0600C368 RID: 50024 RVA: 0x002EB7C4 File Offset: 0x002E9BC4
		private void CreatLuckyItems()
		{
			TheyLuckyData theLuckyData = DataManager<OPPOPrivilegeDataManager>.GetInstance().GetTheLuckyData(10001);
			if (theLuckyData == null)
			{
				Logger.LogErrorFormat("luckyData is Null", new object[0]);
			}
			for (int i = 0; i < theLuckyData.itemData.Count; i++)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(theLuckyData.itemData[i].ID);
				commonItemTableDataByID.Count = theLuckyData.itemData[i].Num;
				ComItem comItem = base.CreateComItem(Utility.FindChild(this.frame, string.Format("ChildFrame/LuckyTurnTable/Items/Pos{0}", i)));
				comItem.Setup(commonItemTableDataByID, delegate(GameObject var1, ItemData var2)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
				});
			}
		}

		// Token: 0x0600C369 RID: 50025 RVA: 0x002EB88C File Offset: 0x002E9C8C
		private void StartRotaryTable()
		{
			this.GetLuckyGuyItemData();
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(10001, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("DrawPrizeTabl is null", new object[0]);
				return;
			}
			if (this.myLuckyGuyTaskPairList.Count > 0 && this.bIsLucky)
			{
				int itemIndex = 0;
				for (int i = 0; i < this.myLuckyGuyTaskPairList.Count; i++)
				{
					if (this.myLuckyGuyTaskPairList[i].key == tableItem.RewardIDKey)
					{
						int.TryParse(this.myLuckyGuyTaskPairList[i].value, out itemIndex);
						this.theLuckyRoller.RotateUp(8, itemIndex, true, new Action(this.GetItem));
					}
				}
			}
		}

		// Token: 0x0600C36A RID: 50026 RVA: 0x002EB95E File Offset: 0x002E9D5E
		private void OnRaffleButtonClick()
		{
			DataManager<ActiveManager>.GetInstance().SendSubmitActivity(17001, 0U);
			this.startBtn.image.raycastTarget = false;
			Singleton<GameStatisticManager>.GetInstance().DoStartOPPO(StartOPPOType.OPPOLUCKYTABLE, string.Empty);
		}

		// Token: 0x0600C36B RID: 50027 RVA: 0x002EB994 File Offset: 0x002E9D94
		private void GetLuckyGuyItemData()
		{
			this.myLuckyGuyTaskPairList.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(17000);
			if (activeData == null)
			{
				Logger.LogErrorFormat("activeData is null", new object[0]);
				return;
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				for (int j = 0; j < activeData.akChildItems[i].akActivityValues.Count; j++)
				{
					this.myLuckyGuyTaskPairList.Add(activeData.akChildItems[i].akActivityValues[j]);
				}
			}
		}

		// Token: 0x0600C36C RID: 50028 RVA: 0x002EBA38 File Offset: 0x002E9E38
		private void ClearLuckyGuyRewardData()
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(17000);
			if (activeData == null)
			{
				Logger.LogErrorFormat("activeData is null", new object[0]);
			}
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(10001, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("DrawPrizeTabl is null", new object[0]);
			}
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				for (int j = 0; j < activeData.akChildItems[i].akActivityValues.Count; j++)
				{
					if (activeData.akChildItems[i].akActivityValues[j].key == tableItem.RewardIDKey)
					{
						activeData.akChildItems[i].akActivityValues.Remove(activeData.akChildItems[i].akActivityValues[j]);
					}
				}
			}
		}

		// Token: 0x0600C36D RID: 50029 RVA: 0x002EBB38 File Offset: 0x002E9F38
		private void UpdateState()
		{
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(10001, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("DrawPrizeTabl is null", new object[0]);
				return;
			}
			this.GetLuckyGuyItemData();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.myLuckyGuyTaskPairList.Count; i++)
			{
				if (this.myLuckyGuyTaskPairList[i].key == tableItem.RestCountKey)
				{
					int.TryParse(this.myLuckyGuyTaskPairList[i].value, out num);
				}
				else if (this.myLuckyGuyTaskPairList[i].key == tableItem.ContinuousKey)
				{
					int.TryParse(this.myLuckyGuyTaskPairList[i].value, out num2);
				}
			}
			if (this.Count != null)
			{
				this.Count.text = num.ToString();
			}
			if (this.TotalCount != null)
			{
				this.TotalCount.text = num2.ToString();
			}
			if (num > 0)
			{
				if (num2 == tableItem.ContinuousDays && num != 0)
				{
					SystemNotifyManager.SystemNotify(9202, string.Empty);
				}
				if (this.startGray != null && this.startBtn != null)
				{
					this.startGray.enabled = false;
					this.startBtn.image.raycastTarget = true;
				}
			}
			else if (this.startGray != null && this.startBtn != null)
			{
				this.startGray.enabled = true;
				this.startBtn.image.raycastTarget = false;
			}
		}

		// Token: 0x0600C36E RID: 50030 RVA: 0x002EBD14 File Offset: 0x002EA114
		private void GetItem()
		{
			this.GetLuckyGuyItemData();
			DrawPrizeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DrawPrizeTable>(10001, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("DrawPrizeTabl is null", new object[0]);
				return;
			}
			if (this.bIsLucky)
			{
				int id = 0;
				if (this.myLuckyGuyTaskPairList.Count > 0)
				{
					for (int i = 0; i < this.myLuckyGuyTaskPairList.Count; i++)
					{
						if (this.myLuckyGuyTaskPairList[i].key == tableItem.RewardIDKey)
						{
							int.TryParse(this.myLuckyGuyTaskPairList[i].value, out id);
							RewardPoolTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<RewardPoolTable>(id, string.Empty, string.Empty);
							if (tableItem2 == null)
							{
								Logger.LogErrorFormat(" RewardPoolTable No Find..", new object[0]);
							}
							else
							{
								ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem2.ItemID);
								if (commonItemTableDataByID == null)
								{
									Logger.LogErrorFormat("ItemData is Null", new object[0]);
								}
								SystemNotifyManager.SysNotifyFloatingEffect(commonItemTableDataByID.GetColorName(string.Empty, false) + "*" + tableItem2.ItemNum, CommonTipsDesc.eShowMode.SI_QUEUE, tableItem2.ItemID);
								this.UpdateState();
								this.ClearLuckyGuyRewardData();
								this.startBtn.image.raycastTarget = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C36F RID: 50031 RVA: 0x002EBE74 File Offset: 0x002EA274
		private void GetSignItemAndNumber()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(298, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.itemdata = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.Value);
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(299, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.iCost = tableItem2.Value;
			}
		}

		// Token: 0x0600C370 RID: 50032 RVA: 0x002EBEE4 File Offset: 0x002EA2E4
		private void OnRapidRetroactiveClick()
		{
			this.GetDailItemData();
			List<uint> akTaskIDs = new List<uint>();
			List<ActiveManager.ActivityData> list = new List<ActiveManager.ActivityData>();
			list.Clear();
			for (int i = 0; i < this.myActivityList.Count; i++)
			{
				if (this.myActivityList[i].status == 3)
				{
					list.Add(this.myActivityList[i]);
				}
			}
			akTaskIDs.Clear();
			for (int j = 0; j < list.Count; j++)
			{
				akTaskIDs.Add((uint)list[j].ID);
			}
			string msgContent = string.Format("您可以花费{0}{1}补签{2}天，是否确认？", this.iCost * akTaskIDs.Count, this.itemdata.Name, akTaskIDs.Count);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				if (akTaskIDs.Count > 0)
				{
					if ((int)DataManager<PlayerBaseData>.GetInstance().BindTicket >= this.iCost * akTaskIDs.Count)
					{
						SceneActiveTaskSubmitRp sceneActiveTaskSubmitRp = new SceneActiveTaskSubmitRp();
						sceneActiveTaskSubmitRp.taskId = akTaskIDs.ToArray();
						NetManager.Instance().SendCommand<SceneActiveTaskSubmitRp>(ServerType.GATE_SERVER, sceneActiveTaskSubmitRp);
					}
					else
					{
						SystemNotifyManager.SystemNotify(9206, string.Empty);
					}
				}
			}, null, 0f, false);
		}

		// Token: 0x0600C371 RID: 50033 RVA: 0x002EBFF4 File Offset: 0x002EA3F4
		private void GetDailItemData()
		{
			this.myActivityList.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(15000);
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				this.myActivityList.Add(activeData.akChildItems[i]);
			}
		}

		// Token: 0x0600C372 RID: 50034 RVA: 0x002EC050 File Offset: 0x002EA450
		private void GetDailSevenItemData()
		{
			this.myDailSevenActivityList.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(16000);
			for (int i = 0; i < activeData.akChildItems.Count; i++)
			{
				this.myDailSevenActivityList.Add(activeData.akChildItems[i]);
			}
		}

		// Token: 0x0600C373 RID: 50035 RVA: 0x002EC0AC File Offset: 0x002EA4AC
		private void CreatDailItem()
		{
			this.GetDailItemData();
			for (int i = 0; i < this.myActivityList.Count; i++)
			{
				List<AwardItemData> activeAwards = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.myActivityList[i].ID);
				if (activeAwards != null)
				{
					for (int j = 0; j < activeAwards.Count; j++)
					{
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(activeAwards[j].ID);
						commonItemTableDataByID.Count = 0;
						if (commonItemTableDataByID != null)
						{
							if (activeAwards[j].Num > 1)
							{
								this.ItemCountList[i].text = activeAwards[j].Num.ToString();
							}
							else
							{
								this.ItemCountList[i].CustomActive(false);
							}
							ComItem comItem = base.CreateComItem(this.ItemPosList[i].gameObject);
							comItem.Setup(commonItemTableDataByID, delegate(GameObject var1, ItemData var2)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
							});
						}
					}
					int index = i;
					this.SignList[i].onClick.RemoveAllListeners();
					this.SignList[index].onClick.AddListener(delegate()
					{
						DataManager<ActiveManager>.GetInstance().SendSubmitActivity(this.myActivityList[index].ID, 0U);
						Singleton<GameStatisticManager>.GetInstance().DoStartOPPO(StartOPPOType.OPPOSIGE, string.Empty);
					});
					this.CtsSignBtnList[i].onClick.RemoveAllListeners();
					this.CtsSignBtnList[index].onClick.AddListener(delegate()
					{
						List<uint> akTaskIDs = new List<uint>();
						akTaskIDs.Clear();
						if (this.myActivityList[index].status == 3)
						{
							akTaskIDs.Add((uint)this.myActivityList[index].ID);
						}
						string msgContent = string.Format("您可以花费{0}{1}补签{2}天，是否确认？", this.iCost, this.itemdata.Name, akTaskIDs.Count);
						SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
						{
							if ((int)DataManager<PlayerBaseData>.GetInstance().BindTicket >= <CreatDailItem>c__AnonStorey.iCost * akTaskIDs.Count)
							{
								SceneActiveTaskSubmitRp sceneActiveTaskSubmitRp = new SceneActiveTaskSubmitRp();
								sceneActiveTaskSubmitRp.taskId = akTaskIDs.ToArray();
								NetManager.Instance().SendCommand<SceneActiveTaskSubmitRp>(ServerType.GATE_SERVER, sceneActiveTaskSubmitRp);
							}
							else
							{
								SystemNotifyManager.SystemNotify(9206, string.Empty);
							}
						}, null, 0f, false);
					});
				}
			}
		}

		// Token: 0x0600C374 RID: 50036 RVA: 0x002EC264 File Offset: 0x002EA664
		private void UpdateCompomentState()
		{
			this.Hide();
			this.GetDailItemData();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < this.myActivityList.Count; i++)
			{
				if (this.myActivityList[i].status == 5)
				{
					if (this.GrayLisy.Count != 0 && this.Receives.Count != 0 && this.GrayLisy[i] != null && this.Receives[i] != null)
					{
						this.GrayLisy[i].enabled = true;
						this.Receives[i].CustomActive(true);
						num++;
					}
				}
				else if (this.myActivityList[i].status == 2)
				{
					if (this.GaoLiangs.Count != 0 && this.SignList.Count != 0 && this.GrayLisy.Count != 0 && this.GaoLiangs[i] != null && this.SignList[i] != null && this.GrayLisy[i] != null)
					{
						this.GaoLiangs[i].CustomActive(true);
						this.SignList[i].CustomActive(true);
						this.GrayLisy[i].enabled = false;
					}
				}
				else if (this.myActivityList[i].status == 3)
				{
					if (this.CountersignList.Count != 0 && this.GrayLisy.Count != 0 && this.CountersignList[i] != null && this.GrayLisy[i] != null)
					{
						this.CountersignList[i].CustomActive(true);
						this.GrayLisy[i].enabled = false;
						this.GrayLisy[i].enabled = true;
						num2++;
					}
				}
				else if (this.myActivityList[i].status == 1 && this.CountersignList.Count != 0 && this.GrayLisy.Count != 0 && this.GaoLiangs.Count != 0 && this.SignList.Count != 0 && this.Receives.Count != 0 && this.CountersignList[i] != null && this.GrayLisy[i] != null && this.GaoLiangs[i] != null && this.SignList[i] != null && this.Receives[i] != null)
				{
					this.Receives[i].CustomActive(false);
					this.CountersignList[i].CustomActive(false);
					this.SignList[i].CustomActive(false);
					this.GaoLiangs[i].CustomActive(false);
					this.GrayLisy[i].enabled = false;
				}
			}
			for (int j = 0; j < this.myDailSevenActivityList.Count; j++)
			{
				if (this.myDailSevenActivityList[j].status == 5)
				{
					if (this.boxComBind != null && this.boxBtn != null && this.boxTeXiao != null && this.boxBtnGray != null)
					{
						this.boxComBind.GetSprite("open", ref this.boxImag);
						this.boxBtn.enabled = false;
						this.boxBtnGray.enabled = false;
						this.boxBtnGray.enabled = true;
						this.boxTeXiao.CustomActive(false);
					}
				}
				else if (this.myDailSevenActivityList[j].status == 2 && this.boxBtnGray != null)
				{
					if (this.boxComBind != null && this.boxBtn != null && this.boxTeXiao != null)
					{
						this.boxComBind.GetSprite("close", ref this.boxImag);
						this.boxBtn.enabled = true;
						this.boxBtnGray.enabled = false;
						this.boxTeXiao.CustomActive(true);
					}
				}
				else if (this.myDailSevenActivityList[j].status == 1 && this.boxComBind != null && this.boxBtn != null && this.boxTeXiao != null && this.boxBtnGray != null)
				{
					this.boxComBind.GetSprite("close", ref this.boxImag);
					this.boxBtn.enabled = true;
					this.boxBtnGray.enabled = false;
					this.boxTeXiao.CustomActive(false);
				}
			}
			if (this.ThisWeekNum != null)
			{
				this.ThisWeekNum.text = num.ToString() + "次";
			}
			if (this.LeakageSignNum != null)
			{
				this.LeakageSignNum.text = num2.ToString() + "次";
			}
			if (num2 > 0)
			{
				if (this.RetroactiveGray != null && this.RetroactiveBtn != null)
				{
					this.RetroactiveGray.enabled = false;
					this.RetroactiveBtn.enabled = true;
				}
			}
			else if (this.RetroactiveGray != null && this.RetroactiveBtn != null)
			{
				this.RetroactiveGray.enabled = true;
				this.RetroactiveBtn.enabled = false;
			}
			for (int k = 0; k < num; k++)
			{
				if (this.ProgresssList[k] != null)
				{
					this.ProgresssList[k].CustomActive(true);
				}
			}
			if (num == 7)
			{
				if (this.boxBtn != null)
				{
					this.boxBtn.onClick.RemoveAllListeners();
					this.boxBtn.onClick.AddListener(delegate()
					{
						DataManager<ActiveManager>.GetInstance().SendSubmitActivity(16001, 0U);
					});
				}
			}
			else if (this.boxBtn != null)
			{
				this.boxBtn.onClick.RemoveAllListeners();
				this.boxBtn.onClick.AddListener(delegate()
				{
					this.GetDailSevenItemData();
					for (int l = 0; l < this.myDailSevenActivityList.Count; l++)
					{
						List<AwardItemData> activeAwards = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.myDailSevenActivityList[l].ID);
						if (activeAwards != null)
						{
							ActiveAwardFrameData activeAwardFrameData = new ActiveAwardFrameData();
							activeAwardFrameData.title = "七日签到宝箱";
							activeAwardFrameData.datas = activeAwards;
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveAwardFrame>(FrameLayer.Middle, activeAwardFrameData, string.Empty);
						}
					}
				});
			}
		}

		// Token: 0x0600C375 RID: 50037 RVA: 0x002EC980 File Offset: 0x002EAD80
		private void _FinAllComponents()
		{
			for (int i = 0; i < 7; i++)
			{
				GameObject gameObject = Utility.FindChild(this.frame, string.Format("ChildFrame/DailyCheck/Items/Item{0}", i));
				if (!(gameObject == null))
				{
					this.DailyItemList.Add(gameObject);
				}
			}
			for (int j = 0; j < this.DailyItemList.Count; j++)
			{
				ComCommonBind component = this.DailyItemList[j].GetComponent<ComCommonBind>();
				if (!(component == null))
				{
					GameObject gameObject2 = component.GetGameObject("Highlight");
					if (gameObject2 != null)
					{
						this.GaoLiangs.Add(gameObject2);
					}
					GameObject gameObject3 = component.GetGameObject("Countersign");
					if (gameObject3 != null)
					{
						this.CountersignList.Add(gameObject3);
					}
					GameObject gameObject4 = component.GetGameObject("Receive");
					if (gameObject4 != null)
					{
						this.Receives.Add(gameObject4);
					}
					GameObject gameObject5 = component.GetGameObject("ItemPos");
					if (gameObject5 != null)
					{
						this.ItemPosList.Add(gameObject5);
					}
					Button com = component.GetCom<Button>("Sign");
					if (com != null)
					{
						this.SignList.Add(com);
					}
					UIGray com2 = component.GetCom<UIGray>("InfoUIGray");
					if (com2 != null)
					{
						this.GrayLisy.Add(com2);
					}
					Text com3 = component.GetCom<Text>("Count");
					if (com3 != null)
					{
						this.ItemCountList.Add(com3);
					}
					Button com4 = component.GetCom<Button>("CtsSignBtn");
					if (com4 != null)
					{
						this.CtsSignBtnList.Add(com4);
					}
				}
			}
			for (int k = 0; k < 7; k++)
			{
				GameObject gameObject6 = Utility.FindChild(this.frame, string.Format("ChildFrame/DailyCheck/Buttom/Slider/Di{0}", k));
				if (!(gameObject6 == null))
				{
					this.ProgresssList.Add(gameObject6);
				}
			}
			this.Hide();
			this._TreasureBoxStatus();
			this.GetSignItemAndNumber();
		}

		// Token: 0x0600C376 RID: 50038 RVA: 0x002ECBB4 File Offset: 0x002EAFB4
		private void Hide()
		{
			for (int i = 0; i < this.GaoLiangs.Count; i++)
			{
				this.GaoLiangs[i].CustomActive(false);
			}
			for (int j = 0; j < this.CountersignList.Count; j++)
			{
				this.CountersignList[j].CustomActive(false);
			}
			for (int k = 0; k < this.Receives.Count; k++)
			{
				this.Receives[k].CustomActive(false);
			}
			for (int l = 0; l < this.SignList.Count; l++)
			{
				this.SignList[l].CustomActive(false);
			}
			for (int m = 0; m < this.ProgresssList.Count; m++)
			{
				this.ProgresssList[m].CustomActive(false);
			}
		}

		// Token: 0x0600C377 RID: 50039 RVA: 0x002ECCAC File Offset: 0x002EB0AC
		private void _TreasureBoxStatus()
		{
			this.boxComBind = this.Box.GetComponent<ComCommonBind>();
			if (this.boxComBind != null)
			{
				this.boxImag = this.boxComBind.GetCom<Image>("BoxState");
				this.selectGo = this.boxComBind.GetGameObject("image");
				this.boxTeXiao = this.boxComBind.GetGameObject("TeXiao");
				if (this.boxTeXiao != null)
				{
					this.boxTeXiao.CustomActive(false);
				}
				this.boxBtn = this.boxComBind.GetCom<Button>("Button");
				this.boxBtnGray = this.boxComBind.GetCom<UIGray>("BoxGray");
			}
		}

		// Token: 0x0600C378 RID: 50040 RVA: 0x002ECD68 File Offset: 0x002EB168
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this.GetPriviItemData();
			this.GetDailSevenItemData();
			this.UpdateCompomentState();
			this.StartRotaryTable();
			this.UpdateState();
			this._InitAmberGiftBagInfo();
			if (this.mAmberPrivilegeView != null)
			{
				this.mAmberPrivilegeView.UpdateElementAmount();
			}
			if (this.mOPPOGrowthHaoLiView != null)
			{
				this.mOPPOGrowthHaoLiView.UpdateElementAmount();
			}
		}

		// Token: 0x0600C379 RID: 50041 RVA: 0x002ECDD4 File Offset: 0x002EB1D4
		private new void _AddButton(string path, UnityAction events)
		{
			Button button = Utility.FindComponent<Button>(this.frame, path, true);
			if (null != button)
			{
				button.onClick.AddListener(events);
				this.m_kButtons.Add(button);
			}
		}

		// Token: 0x0600C37A RID: 50042 RVA: 0x002ECE14 File Offset: 0x002EB214
		private void _RemoveAllButtonDelegates()
		{
			for (int i = 0; i < this.m_kButtons.Count; i++)
			{
				(this.m_kButtons[i] as Button).onClick.RemoveAllListeners();
			}
			this.m_kButtons.Clear();
		}

		// Token: 0x0600C37B RID: 50043 RVA: 0x002ECE63 File Offset: 0x002EB263
		[UIEventHandle("close")]
		private void OnCloseClick()
		{
			this.frameMgr.CloseFrame<OPPOPrivilegeFrame>(this, false);
		}

		// Token: 0x04006EA0 RID: 28320
		private OPPOPrivilegeFrame.OPPOTABType m_eFunctionType = OPPOPrivilegeFrame.OPPOTABType.OTT_DAILYCHECK;

		// Token: 0x04006EA1 RID: 28321
		private int[] activityIds = new int[]
		{
			12000,
			17000,
			27000,
			20000,
			15000,
			26000
		};

		// Token: 0x04006EA2 RID: 28322
		private const int m_iConfigPrefabCount = 6;

		// Token: 0x04006EA3 RID: 28323
		private string[] m_Prefabs = new string[]
		{
			"UIFlatten/Prefabs/Activity/Privilege",
			"UIFlatten/Prefabs/Activity/LuckyTurnTable",
			"UIFlatten/Prefabs/Activity/AmbergiftBag",
			"UIFlatten/Prefabs/Activity/DailyCheck",
			"UIFlatten/Prefabs/Activity/AmberPrivilegeView",
			"UIFlatten/Prefabs/Activity/OPPOGrowthHaoLiView"
		};

		// Token: 0x04006EA4 RID: 28324
		private char[] m_acPrefabInits = new char[6];

		// Token: 0x04006EA5 RID: 28325
		private List<GameObject>[] m_kFunctionObject = new List<GameObject>[]
		{
			new List<GameObject>(),
			new List<GameObject>(),
			new List<GameObject>(),
			new List<GameObject>(),
			new List<GameObject>(),
			new List<GameObject>()
		};

		// Token: 0x04006EA6 RID: 28326
		private bool[] m_aInits = new bool[6];

		// Token: 0x04006EA7 RID: 28327
		[UIObject("ChildFrame")]
		private GameObject goChildFrame;

		// Token: 0x04006EA8 RID: 28328
		private CachedObjectDicManager<OPPOPrivilegeFrame.OPPOTABType, OPPOPrivilegeFrame.OPPOTABTab> m_akOPPOTABTabs = new CachedObjectDicManager<OPPOPrivilegeFrame.OPPOTABType, OPPOPrivilegeFrame.OPPOTABTab>();

		// Token: 0x04006EA9 RID: 28329
		private int IActivitytEmplateID = 20000;

		// Token: 0x04006EAA RID: 28330
		private int ActivityID;

		// Token: 0x04006EAB RID: 28331
		private byte StatuIndex;

		// Token: 0x04006EAC RID: 28332
		private string StrAmberLevel = string.Empty;

		// Token: 0x04006EAD RID: 28333
		private Text okBtnText;

		// Token: 0x04006EAE RID: 28334
		private Button okBtn;

		// Token: 0x04006EAF RID: 28335
		private ComUIListScript AmberGiftBagComUIListScript;

		// Token: 0x04006EB0 RID: 28336
		private Text desText;

		// Token: 0x04006EB1 RID: 28337
		private UIGray okBtnGray;

		// Token: 0x04006EB2 RID: 28338
		public const int privilegeRwerdID = 12001;

		// Token: 0x04006EB3 RID: 28339
		public const int privilegeID = 12000;

		// Token: 0x04006EB4 RID: 28340
		private bool IsUpdate;

		// Token: 0x04006EB5 RID: 28341
		private float fTime;

		// Token: 0x04006EB6 RID: 28342
		private ComUIListScript m_comRewardItemList;

		// Token: 0x04006EB7 RID: 28343
		private UIGray gray;

		// Token: 0x04006EB8 RID: 28344
		private Text OKText;

		// Token: 0x04006EB9 RID: 28345
		private List<ActiveManager.ActivityData> myprivilegeActivityList = new List<ActiveManager.ActivityData>();

		// Token: 0x04006EBA RID: 28346
		public const int tableID = 10001;

		// Token: 0x04006EBB RID: 28347
		public const int luckyGuyActiveID = 17001;

		// Token: 0x04006EBC RID: 28348
		public const int luckyTemPlateID = 17000;

		// Token: 0x04006EBD RID: 28349
		private int totleCount = -1;

		// Token: 0x04006EBE RID: 28350
		private bool bIsLucky;

		// Token: 0x04006EBF RID: 28351
		private Text TotalCount;

		// Token: 0x04006EC0 RID: 28352
		private Text Count;

		// Token: 0x04006EC1 RID: 28353
		private GameObject items;

		// Token: 0x04006EC2 RID: 28354
		private UIGray startGray;

		// Token: 0x04006EC3 RID: 28355
		private Button startBtn;

		// Token: 0x04006EC4 RID: 28356
		private GameObject zhizhen;

		// Token: 0x04006EC5 RID: 28357
		private TheLuckyRoller theLuckyRoller;

		// Token: 0x04006EC6 RID: 28358
		private OPPOPrivilegeFrame.DrawRetData drawRetData;

		// Token: 0x04006EC7 RID: 28359
		private List<TaskPair> myLuckyGuyTaskPairList = new List<TaskPair>();

		// Token: 0x04006EC8 RID: 28360
		public const int num = 7;

		// Token: 0x04006EC9 RID: 28361
		public const int dailID = 15000;

		// Token: 0x04006ECA RID: 28362
		public const int dailSevenID = 16000;

		// Token: 0x04006ECB RID: 28363
		public const int dailSevenActivityID = 16001;

		// Token: 0x04006ECC RID: 28364
		public const string retroactiveDes = "您可以花费{0}{1}补签{2}天，是否确认？";

		// Token: 0x04006ECD RID: 28365
		private int iCost;

		// Token: 0x04006ECE RID: 28366
		private bool isDail;

		// Token: 0x04006ECF RID: 28367
		private ItemData itemdata;

		// Token: 0x04006ED0 RID: 28368
		private GameObject DailyItems;

		// Token: 0x04006ED1 RID: 28369
		private List<GameObject> DailyItemList = new List<GameObject>();

		// Token: 0x04006ED2 RID: 28370
		private GameObject Slider;

		// Token: 0x04006ED3 RID: 28371
		private List<GameObject> ProgresssList = new List<GameObject>();

		// Token: 0x04006ED4 RID: 28372
		private GameObject Box;

		// Token: 0x04006ED5 RID: 28373
		private ComCommonBind boxComBind;

		// Token: 0x04006ED6 RID: 28374
		private Image boxImag;

		// Token: 0x04006ED7 RID: 28375
		private GameObject boxTeXiao;

		// Token: 0x04006ED8 RID: 28376
		private Button boxBtn;

		// Token: 0x04006ED9 RID: 28377
		private UIGray boxBtnGray;

		// Token: 0x04006EDA RID: 28378
		private GameObject selectGo;

		// Token: 0x04006EDB RID: 28379
		private Text ThisWeekNum;

		// Token: 0x04006EDC RID: 28380
		private Text LeakageSignNum;

		// Token: 0x04006EDD RID: 28381
		private UIGray RetroactiveGray;

		// Token: 0x04006EDE RID: 28382
		private Button RetroactiveBtn;

		// Token: 0x04006EDF RID: 28383
		private List<GameObject> GaoLiangs = new List<GameObject>();

		// Token: 0x04006EE0 RID: 28384
		private List<GameObject> CountersignList = new List<GameObject>();

		// Token: 0x04006EE1 RID: 28385
		private List<Button> CtsSignBtnList = new List<Button>();

		// Token: 0x04006EE2 RID: 28386
		private List<GameObject> Receives = new List<GameObject>();

		// Token: 0x04006EE3 RID: 28387
		private List<GameObject> ItemPosList = new List<GameObject>();

		// Token: 0x04006EE4 RID: 28388
		private List<Text> ItemCountList = new List<Text>();

		// Token: 0x04006EE5 RID: 28389
		private List<Button> SignList = new List<Button>();

		// Token: 0x04006EE6 RID: 28390
		private List<UIGray> GrayLisy = new List<UIGray>();

		// Token: 0x04006EE7 RID: 28391
		private List<ActiveManager.ActivityData> myActivityList = new List<ActiveManager.ActivityData>();

		// Token: 0x04006EE8 RID: 28392
		private List<ActiveManager.ActivityData> myDailSevenActivityList = new List<ActiveManager.ActivityData>();

		// Token: 0x04006EE9 RID: 28393
		private AmberPrivilegeView mAmberPrivilegeView;

		// Token: 0x04006EEA RID: 28394
		private OPPOGrowthHaoLiView mOPPOGrowthHaoLiView;

		// Token: 0x04006EEB RID: 28395
		private List<object> m_kButtons = new List<object>();

		// Token: 0x020013A9 RID: 5033
		public enum OPPOTABType
		{
			// Token: 0x04006EF0 RID: 28400
			[Description("OPPO_PRIVILRGR")]
			OTT_PRIVILRGR,
			// Token: 0x04006EF1 RID: 28401
			[Description("OPPO_LUCKYGUY")]
			OTT_LUCKYGUY,
			// Token: 0x04006EF2 RID: 28402
			[Description("OPPO_AMBERPRIVILEGE")]
			OTT_AMBERPRIVILEGE,
			// Token: 0x04006EF3 RID: 28403
			[Description("OPPO_AMBERGIFTBAG")]
			OTT_AMBERGIFTBAG,
			// Token: 0x04006EF4 RID: 28404
			[Description("OPPO_DAILYCHECK")]
			OTT_DAILYCHECK,
			// Token: 0x04006EF5 RID: 28405
			[Description("OPPO_GROWTHHAOLI")]
			OTT_OPPOGROWTHHAOLI,
			// Token: 0x04006EF6 RID: 28406
			OTT_COUNT
		}

		// Token: 0x020013AA RID: 5034
		private class OPPOTABTab : CachedObject
		{
			// Token: 0x17001BDD RID: 7133
			// (get) Token: 0x0600C382 RID: 50050 RVA: 0x002ECF54 File Offset: 0x002EB354
			public OPPOPrivilegeFrame.OPPOTABType OPPOTABType
			{
				get
				{
					return this.eOPPOTABType;
				}
			}

			// Token: 0x0600C383 RID: 50051 RVA: 0x002ECF5C File Offset: 0x002EB35C
			public sealed override void OnDestroy()
			{
				this.goLocal = null;
				this.goPrefab = null;
				this.goParent = null;
				this.frame = null;
				this.labelMark = null;
				this.labelCheckMark = null;
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle = null;
				this.onFunctionLoad = null;
				this.functionRedBinder = null;
			}

			// Token: 0x0600C384 RID: 50052 RVA: 0x002ECFB8 File Offset: 0x002EB3B8
			public sealed override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.eOPPOTABType = (OPPOPrivilegeFrame.OPPOTABType)param[2];
				this.frame = (OPPOPrivilegeFrame)param[3];
				this.onFunctionLoad = (param[4] as OPPOPrivilegeFrame.OPPOTABTab.OnFunctionLoad);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.toggle = this.goLocal.GetComponent<Toggle>();
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this._OnSelected();
						}
					});
					string enumDescription = Utility.GetEnumDescription<OPPOPrivilegeFrame.OPPOTABType>(this.eOPPOTABType);
					this.labelMark = Utility.FindComponent<Text>(this.goLocal, "Text", true);
					this.labelMark.text = TR.Value(enumDescription);
					this.labelCheckMark = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
					this.labelCheckMark.text = TR.Value(enumDescription);
					this.functionRedBinder = this.goLocal.GetComponent<OPPOFunctionRedBinder>();
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x0600C385 RID: 50053 RVA: 0x002ED0E5 File Offset: 0x002EB4E5
			public sealed override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C386 RID: 50054 RVA: 0x002ED104 File Offset: 0x002EB504
			public sealed override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600C387 RID: 50055 RVA: 0x002ED10D File Offset: 0x002EB50D
			public sealed override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600C388 RID: 50056 RVA: 0x002ED12C File Offset: 0x002EB52C
			public sealed override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x0600C389 RID: 50057 RVA: 0x002ED134 File Offset: 0x002EB534
			public sealed override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600C38A RID: 50058 RVA: 0x002ED154 File Offset: 0x002EB554
			private void _Update()
			{
				if (this.eOPPOTABType == OPPOPrivilegeFrame.OPPOTABType.OTT_PRIVILRGR)
				{
					this.functionRedBinder.AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType.OFT_PRIVILRGR);
				}
				else if (this.eOPPOTABType == OPPOPrivilegeFrame.OPPOTABType.OTT_LUCKYGUY)
				{
					this.functionRedBinder.AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType.OFT_LUCKYGUY);
				}
				else if (this.eOPPOTABType == OPPOPrivilegeFrame.OPPOTABType.OTT_DAILYCHECK)
				{
					this.functionRedBinder.AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType.OFT_DAILYCHECK);
				}
				else if (this.eOPPOTABType == OPPOPrivilegeFrame.OPPOTABType.OTT_AMBERGIFTBAG)
				{
					this.functionRedBinder.AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType.OFT_AMBERGIFTBAG);
				}
				else if (this.eOPPOTABType == OPPOPrivilegeFrame.OPPOTABType.OTT_AMBERPRIVILEGE)
				{
					this.functionRedBinder.AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType.OFT_AMBERPRIVILEGE);
				}
				else if (this.eOPPOTABType == OPPOPrivilegeFrame.OPPOTABType.OTT_OPPOGROWTHHAOLI)
				{
					this.functionRedBinder.AddCheckFunction(OPPOFunctionRedBinder.OPPOFunctionType.OFT_OPPOGROWTHHAOLI);
				}
				else
				{
					this.functionRedBinder.ClearCheckFunctions();
				}
			}

			// Token: 0x0600C38B RID: 50059 RVA: 0x002ED219 File Offset: 0x002EB619
			private void _OnSelected()
			{
				if (this.onFunctionLoad != null)
				{
					this.onFunctionLoad(this.eOPPOTABType);
					this.onFunctionLoad = null;
				}
				this.frame.OnFunctionChanged(this.eOPPOTABType);
			}

			// Token: 0x04006EF7 RID: 28407
			private GameObject goLocal;

			// Token: 0x04006EF8 RID: 28408
			private GameObject goPrefab;

			// Token: 0x04006EF9 RID: 28409
			private GameObject goParent;

			// Token: 0x04006EFA RID: 28410
			private OPPOPrivilegeFrame.OPPOTABType eOPPOTABType;

			// Token: 0x04006EFB RID: 28411
			private OPPOPrivilegeFrame frame;

			// Token: 0x04006EFC RID: 28412
			public Toggle toggle;

			// Token: 0x04006EFD RID: 28413
			private Text labelMark;

			// Token: 0x04006EFE RID: 28414
			private Text labelCheckMark;

			// Token: 0x04006EFF RID: 28415
			public OPPOPrivilegeFrame.OPPOTABTab.OnFunctionLoad onFunctionLoad;

			// Token: 0x04006F00 RID: 28416
			private OPPOFunctionRedBinder functionRedBinder;

			// Token: 0x020013AB RID: 5035
			// (Invoke) Token: 0x0600C38E RID: 50062
			public delegate void OnFunctionLoad(OPPOPrivilegeFrame.OPPOTABType eOPPOTABType);
		}

		// Token: 0x020013AC RID: 5036
		public enum AmberGiftBagType
		{
			// Token: 0x04006F02 RID: 28418
			AGBT_NONE = 20001,
			// Token: 0x04006F03 RID: 28419
			AGBT_GREENPEARL,
			// Token: 0x04006F04 RID: 28420
			AGBT_BLUEPEARL,
			// Token: 0x04006F05 RID: 28421
			AGBT_GOLDPEARL,
			// Token: 0x04006F06 RID: 28422
			AGBT_REDPEARL,
			// Token: 0x04006F07 RID: 28423
			AGBT_PURPLEPEARL
		}

		// Token: 0x020013AD RID: 5037
		private class DrawRetData
		{
			// Token: 0x04006F08 RID: 28424
			public uint drawPrizeTableId;

			// Token: 0x04006F09 RID: 28425
			public uint rewardId;
		}
	}
}
