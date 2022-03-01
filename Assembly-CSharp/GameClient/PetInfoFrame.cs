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
	// Token: 0x0200197A RID: 6522
	internal class PetInfoFrame : ClientFrame
	{
		// Token: 0x0600FD62 RID: 64866 RVA: 0x0045C92D File Offset: 0x0045AD2D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pet/PetInfoFrame";
		}

		// Token: 0x0600FD63 RID: 64867 RVA: 0x0045C934 File Offset: 0x0045AD34
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				Logger.LogError("PetInfoFrame can't Init without userData when OpenFrame! by wb");
				return;
			}
			this.initPetData = (InitPetData)this.userData;
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x0600FD64 RID: 64868 RVA: 0x0045C969 File Offset: 0x0045AD69
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.ClearData();
		}

		// Token: 0x0600FD65 RID: 64869 RVA: 0x0045C978 File Offset: 0x0045AD78
		private void ClearData()
		{
			this.MaxGoldFeedNum = 0;
			this.MaxTicketFeedNum = 0;
			this.MaxSatietyNum = 0;
			this.ExpChangeCoeffi = 0;
			this.MoneyChangeCoeffi = 0;
			this.PetFoodItemData = null;
			this.mAvatarRenderer.ClearAvatar();
			this.PetInfoList.Clear();
			this.initPetData.ClearData();
			this.CurSelMainType = PetInfoTabType.Pet_UpLevel;
			this.ReSelPropertyIndex = -1;
			this.EatPetInfoList.Clear();
			this.EatPetIDList.Clear();
			this.TotalNeedExp = 0UL;
			this.bSelAll = false;
			this.bCanPlayStarEffect = false;
			this.bPlayStar = false;
			this.StarEffectTime = 0f;
			this.iStarIndex = 0;
			for (int i = 0; i < this.PetEleObjList.Count; i++)
			{
				ComCommonBind component = this.PetEleObjList[i].GetComponent<ComCommonBind>();
				if (!(component == null))
				{
					Button com = component.GetCom<Button>("btPetItem");
					Toggle com2 = component.GetCom<Toggle>("tgSelect");
					if (com != null)
					{
						com.onClick.RemoveAllListeners();
					}
					if (com2 != null)
					{
						com2.onValueChanged.RemoveAllListeners();
					}
				}
			}
			this.PetEleObjList.Clear();
			this.PetPropObjList.Clear();
		}

		// Token: 0x0600FD66 RID: 64870 RVA: 0x0045CAC0 File Offset: 0x0045AEC0
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetItemsInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdatePetList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetFeedSuccess, new ClientEventSystem.UIEventHandler(this.OnPetFeedSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EatPetSuccess, new ClientEventSystem.UIEventHandler(this.OnPetFeedSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PetPropertyReselect, new ClientEventSystem.UIEventHandler(this.OnPetPropertyReselect));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdatePetFoodNum, new ClientEventSystem.UIEventHandler(this.OnUpdatePetFoodNum));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this.OnUpdatePetBuyUI));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TicketChanged, new ClientEventSystem.UIEventHandler(this.OnUpdatePetBuyUI));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x0600FD67 RID: 64871 RVA: 0x0045CBAC File Offset: 0x0045AFAC
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetItemsInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnUpdatePetList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetFeedSuccess, new ClientEventSystem.UIEventHandler(this.OnPetFeedSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EatPetSuccess, new ClientEventSystem.UIEventHandler(this.OnPetFeedSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PetPropertyReselect, new ClientEventSystem.UIEventHandler(this.OnPetPropertyReselect));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdatePetFoodNum, new ClientEventSystem.UIEventHandler(this.OnUpdatePetFoodNum));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this.OnUpdatePetBuyUI));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TicketChanged, new ClientEventSystem.UIEventHandler(this.OnUpdatePetBuyUI));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x0600FD68 RID: 64872 RVA: 0x0045CC96 File Offset: 0x0045B096
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this.UpdateEatNeedMoney();
		}

		// Token: 0x0600FD69 RID: 64873 RVA: 0x0045CC9E File Offset: 0x0045B09E
		private void OnUpdatePetList(UIEvent iEvent)
		{
			this.UpdatePetList(false);
		}

		// Token: 0x0600FD6A RID: 64874 RVA: 0x0045CCA8 File Offset: 0x0045B0A8
		private void OnPetFeedSuccess(UIEvent iEvent)
		{
			this.TotalNeedExp = 0UL;
			this.bSelAll = false;
			this.EatPetIDList.Clear();
			this.UpdatePreAddedExp();
			if (this.CurSelMainType != PetInfoTabType.Pet_Property)
			{
				this.UpdateSelPetInfo(false);
			}
			if (this.CurSelMainType == PetInfoTabType.Pet_UpLevel)
			{
				this.RefreshPetItemListCount();
				if (this.mEatPet.isOn)
				{
					this.UpdateEatPetList();
					this.UpdateEatNeedMoney();
				}
				uint num = (uint)iEvent.Param1;
				byte bIsCritical = (byte)iEvent.Param2;
				if (num > 0U)
				{
					this.PlayCritEffect(num, bIsCritical);
				}
			}
			else if (this.CurSelMainType == PetInfoTabType.Pet_Feed)
			{
				this.UpdatePetFoodItemData();
				this.SetPetFoodComItem();
			}
		}

		// Token: 0x0600FD6B RID: 64875 RVA: 0x0045CD5C File Offset: 0x0045B15C
		private void OnPetPropertyReselect(UIEvent iEvent)
		{
			ulong num = (ulong)iEvent.Param1;
			if (num != this.CurSelPetInfo.id)
			{
				return;
			}
			if (this.CurSelMainType != PetInfoTabType.Pet_Property)
			{
				return;
			}
			this.UpdateShowCurSelProperty();
			this.UpdatePropertyList();
			this.RefreshPetItemListCount();
		}

		// Token: 0x0600FD6C RID: 64876 RVA: 0x0045CDA6 File Offset: 0x0045B1A6
		private void OnUpdatePetFoodNum(UIEvent iEvent)
		{
			if (this.CurSelMainType != PetInfoTabType.Pet_Feed)
			{
				return;
			}
			this.UpdatePetFoodItemData();
			this.SetPetFoodComItem();
		}

		// Token: 0x0600FD6D RID: 64877 RVA: 0x0045CDC1 File Offset: 0x0045B1C1
		private void OnUpdatePetBuyUI(UIEvent iEvent)
		{
			this.UpdateSelPetInfo(true);
		}

		// Token: 0x0600FD6E RID: 64878 RVA: 0x0045CDCC File Offset: 0x0045B1CC
		[UIEventHandle("MainTab/Func{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void OnSwitchMainTab(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			this.ReSelPropertyIndex = -1;
			this.CurSelMainType = (PetInfoTabType)iIndex;
			this.ClearStarEffect(this.iStarIndex + 1);
			this.UpdateShowMiddleType();
			if (this.CurSelMainType == PetInfoTabType.Pet_Property)
			{
				this.UpdateShowCurSelProperty();
				this.UpdatePropertyList();
			}
			else
			{
				this.UpdateSelPetInfo(true);
				this.UpdateActor((int)this.CurSelPetInfo.dataId);
				if (this.CurSelMainType == PetInfoTabType.Pet_Feed)
				{
					this.UpdatePetFoodItemData();
					this.SetPetFoodComItem();
				}
			}
		}

		// Token: 0x0600FD6F RID: 64879 RVA: 0x0045CE58 File Offset: 0x0045B258
		private void OnSelectPet(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			if (iIndex >= this.PetInfoList.Count)
			{
				return;
			}
			this.ClearStarEffect(this.iStarIndex + 1);
			this.ReSelPropertyIndex = -1;
			DataManager<PetDataManager>.GetInstance().SetPetData(this.CurSelPetInfo, this.PetInfoList[iIndex]);
			if (this.CurSelMainType != PetInfoTabType.Pet_Property)
			{
				this.UpdateSelPetInfo(true);
				this.UpdateActor((int)this.CurSelPetInfo.dataId);
			}
			if (this.CurSelMainType == PetInfoTabType.Pet_UpLevel)
			{
				if (this.mEatPet.isOn)
				{
					this.UpdateEatPetIDList();
					this.UpdateEatPetList();
					this.UpdateEatNeedMoney();
				}
			}
			else if (this.CurSelMainType == PetInfoTabType.Pet_Property)
			{
				this.UpdateShowCurSelProperty();
				this.UpdatePropertyList();
			}
		}

		// Token: 0x0600FD70 RID: 64880 RVA: 0x0045CF24 File Offset: 0x0045B324
		private void OnSelectEatPet(int iIndex, bool value, Toggle tgSelectPet)
		{
			if (iIndex < 0 || iIndex >= this.EatPetInfoList.Count)
			{
				return;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if ((int)this.CurSelPetInfo.level >= tableItem.MaxLv)
			{
				if (value)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("该宠物已满级,无法继续吞噬宠物", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					tgSelectPet.isOn = false;
				}
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.EatPetIDList.Count; i++)
			{
				if (this.EatPetIDList[i].id == this.EatPetInfoList[iIndex].id)
				{
					if (!value)
					{
						this.EatPetIDList.RemoveAt(i);
						this.TotalNeedExp -= this.GetExpByEatPet(this.EatPetInfoList[iIndex]);
					}
					flag = true;
					break;
				}
			}
			if (!flag && value)
			{
				int addedLv = this.GetAddedLv();
				if ((int)this.CurSelPetInfo.level + addedLv >= tableItem.MaxLv)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("等级加成已达上限,无法继续吞噬宠物", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					tgSelectPet.isOn = false;
					return;
				}
				PetInfo petInfo = new PetInfo();
				DataManager<PetDataManager>.GetInstance().SetPetData(petInfo, this.EatPetInfoList[iIndex]);
				this.EatPetIDList.Add(petInfo);
				this.TotalNeedExp += this.GetExpByEatPet(this.EatPetInfoList[iIndex]);
			}
			this.UpdatePreAddedExp();
			this.UpdateEatNeedMoney();
			DataManager<PetDataManager>.GetInstance().UpdateStarsShow(tableItem, this.CurSelPetInfo, this.GetAddedLv(), ref this.starsGray, ref this.HalfStars, ref this.HalfShadowStars, this.bCanPlayStarEffect, this.iStarIndex);
		}

		// Token: 0x0600FD71 RID: 64881 RVA: 0x0045D0E9 File Offset: 0x0045B4E9
		private void OnSelectProperty(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				this.ReSelPropertyIndex = -1;
				return;
			}
			this.ReSelPropertyIndex = iIndex;
		}

		// Token: 0x0600FD72 RID: 64882 RVA: 0x0045D107 File Offset: 0x0045B507
		private void OnPetFoodItemTips()
		{
			if (this.PetFoodItemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(this.PetFoodItemData, null, 4, true, false, true);
		}

		// Token: 0x0600FD73 RID: 64883 RVA: 0x0045D12A File Offset: 0x0045B52A
		private void InitInterface()
		{
			this.InitData();
			this.InitPetItemScrollListBind();
			this.RefreshPetItemListCount();
			this.UpdateMainTab();
		}

		// Token: 0x0600FD74 RID: 64884 RVA: 0x0045D144 File Offset: 0x0045B544
		private void InitData()
		{
			this.CurSelMainType = this.initPetData.PetTabType;
			this.CurSelPetInfo = this.initPetData.petinfo;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(221, string.Empty, string.Empty);
			this.MaxSatietyNum = tableItem.Value;
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(228, string.Empty, string.Empty);
			this.MaxGoldFeedNum = tableItem2.Value;
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(227, string.Empty, string.Empty);
			this.MaxTicketFeedNum = tableItem3.Value;
			SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(225, string.Empty, string.Empty);
			this.ExpChangeCoeffi = tableItem4.Value;
			SystemValueTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(224, string.Empty, string.Empty);
			this.MoneyChangeCoeffi = tableItem5.Value;
			SystemValueTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(361, string.Empty, string.Empty);
			int value = tableItem6.Value;
			ItemTable tableItem7 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(value, string.Empty, string.Empty);
			if (tableItem7 != null)
			{
				ETCImageLoader.LoadSprite(ref this.mPointIcon, tableItem7.Icon, true);
			}
			SystemValueTable tableItem8 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(362, string.Empty, string.Empty);
			int value2 = tableItem8.Value;
			this.mPointCount.text = value2.ToString();
			this.UpdatePetList(true);
		}

		// Token: 0x0600FD75 RID: 64885 RVA: 0x0045D2D0 File Offset: 0x0045B6D0
		private void InitPetItemScrollListBind()
		{
			this.mPetScrollList.Initialize();
			this.mPetScrollList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.UpdatePetItemScrollListBind(item);
				}
			};
			this.mPetScrollList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Toggle com = component.GetCom<Toggle>("tgSelect");
				com.onValueChanged.RemoveAllListeners();
				Button com2 = component.GetCom<Button>("btPetItem");
				com2.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600FD76 RID: 64886 RVA: 0x0045D328 File Offset: 0x0045B728
		private void UpdatePetItemScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.PetInfoList.Count)
			{
				return;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.PetInfoList[item.m_index].dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			DataManager<PetDataManager>.GetInstance().SetPetItemData(item.gameObject, this.PetInfoList[item.m_index], DataManager<PlayerBaseData>.GetInstance().JobTableID, PetTipsType.None, false);
			Text com = component.GetCom<Text>("Name");
			Text com2 = component.GetCom<Text>("Level2");
			Text com3 = component.GetCom<Text>("Carry");
			com.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, tableItem.Quality);
			com2.text = this.PetInfoList[item.m_index].level.ToString();
			bool flag = false;
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				if (onUsePetList[i].id == this.PetInfoList[item.m_index].id)
				{
					com3.gameObject.CustomActive(true);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				com3.gameObject.CustomActive(false);
			}
			Toggle com4 = component.GetCom<Toggle>("tgSelect");
			GameObject goSelectImage = component.GetGameObject("SelectImage");
			if (this.PetInfoList[item.m_index].id == this.CurSelPetInfo.id)
			{
				com4.isOn = true;
				if (goSelectImage != null)
				{
					goSelectImage.CustomActive(true);
				}
			}
			else if (goSelectImage != null)
			{
				goSelectImage.CustomActive(false);
			}
			com4.onValueChanged.RemoveAllListeners();
			int iIndex = item.m_index;
			com4.onValueChanged.AddListener(delegate(bool value)
			{
				this.OnSelectPet(iIndex, value);
				if (goSelectImage != null)
				{
					goSelectImage.CustomActive(true);
				}
			});
		}

		// Token: 0x0600FD77 RID: 64887 RVA: 0x0045D57A File Offset: 0x0045B97A
		private void RefreshPetItemListCount()
		{
			this.mPetScrollList.SetElementAmount(this.PetInfoList.Count);
		}

		// Token: 0x0600FD78 RID: 64888 RVA: 0x0045D594 File Offset: 0x0045B994
		private void UpdateMainTab()
		{
			for (int i = 0; i < this.MainTabs.Length; i++)
			{
				this.MainTabs[i].isOn = false;
				if (i == (int)this.CurSelMainType)
				{
					this.MainTabs[i].isOn = true;
				}
			}
		}

		// Token: 0x0600FD79 RID: 64889 RVA: 0x0045D5E4 File Offset: 0x0045B9E4
		private void UpdateShowMiddleType()
		{
			if (this.CurSelMainType == PetInfoTabType.Pet_UpLevel)
			{
				this.mPet.isOn = true;
				this.mEatPet.isOn = false;
				this.mEatPet.gameObject.CustomActive(true);
				this.mPetListName.text = "日常训练";
				this.mUpLevelTips.gameObject.CustomActive(true);
			}
			else
			{
				this.mEatPet.gameObject.CustomActive(false);
				this.mPetListName.text = "宠物";
				this.mUpLevelTips.gameObject.CustomActive(false);
			}
			if (this.CurSelMainType == PetInfoTabType.Pet_Property)
			{
				this.mUpObj.CustomActive(false);
			}
			else
			{
				this.mUpObj.CustomActive(true);
			}
			for (int i = 0; i < this.MiddleShowTypeRoots.Length; i++)
			{
				if (i == (int)this.CurSelMainType)
				{
					this.MiddleShowTypeRoots[i].gameObject.CustomActive(true);
				}
				else
				{
					this.MiddleShowTypeRoots[i].gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600FD7A RID: 64890 RVA: 0x0045D6F8 File Offset: 0x0045BAF8
		private void UpdateSelPetInfo(bool bForce = true)
		{
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.mName.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, tableItem.Quality);
			this.mLevel.text = string.Format("{0}/{1}", this.CurSelPetInfo.level, tableItem.MaxLv);
			DataManager<PetDataManager>.GetInstance().UpdateStarsShow(tableItem, this.CurSelPetInfo, 0, ref this.starsGray, ref this.HalfStars, ref this.HalfShadowStars, this.bCanPlayStarEffect, this.iStarIndex);
			if (this.CurSelMainType == PetInfoTabType.Pet_UpLevel)
			{
				this.mSatietyRoot.CustomActive(false);
				this.mExp.gameObject.CustomActive(true);
				this.DrawPetExpBar((int)this.CurSelPetInfo.level, (ulong)this.CurSelPetInfo.exp, tableItem.Quality, bForce);
				List<int> petSkillIDsByJob = DataManager<PetDataManager>.GetInstance().GetPetSkillIDsByJob(tableItem, DataManager<PlayerBaseData>.GetInstance().JobTableID);
				if (petSkillIDsByJob.Count <= 0 || (int)this.CurSelPetInfo.skillIndex >= petSkillIDsByJob.Count)
				{
					this.mCurPropertyContent.text = string.Empty;
					this.mNextPropertyContent.text = string.Empty;
				}
				else
				{
					this.mCurPropertyContent.text = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(tableItem.InnateSkill, (byte)this.CurSelPetInfo.level, (byte)this.CurSelPetInfo.level, FightTypeLabel.PVE);
					Text text = this.mCurPropertyContent;
					text.text = text.text + " \n" + DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(petSkillIDsByJob[(int)this.CurSelPetInfo.skillIndex], (byte)this.CurSelPetInfo.level, (byte)this.CurSelPetInfo.level, FightTypeLabel.PVE);
					this.mNextPropertyContent.text = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(tableItem.InnateSkill, (byte)this.CurSelPetInfo.level, (byte)(this.CurSelPetInfo.level + 1), FightTypeLabel.PVE);
					Text text2 = this.mNextPropertyContent;
					text2.text = text2.text + " \n" + DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(petSkillIDsByJob[(int)this.CurSelPetInfo.skillIndex], (byte)this.CurSelPetInfo.level, (byte)(this.CurSelPetInfo.level + 1), FightTypeLabel.PVE);
				}
				int num = 0;
				int feedNeedMoney = DataManager<PetDataManager>.GetInstance().GetFeedNeedMoney(this.CurSelPetInfo, PetFeedTable.eType.PET_FEED_GOLD, ref num);
				if (feedNeedMoney < 0)
				{
					this.mGoldTrainCost.text = "0";
					this.mGoldTrainExp.text = "0";
					this.mGoldTrainGray.enabled = true;
					this.mBtGoldTrain.interactable = false;
				}
				else
				{
					if ((int)this.CurSelPetInfo.goldFeedCount >= this.MaxGoldFeedNum)
					{
						this.mGoldTrainExp.text = string.Format("<color=#9FA2B8FF>{0}</color>", num);
						this.mGoldTrainRestNum.text = string.Format("<color=#9FA2B8FF>{0}/{1}</color>", this.MaxGoldFeedNum - (int)this.CurSelPetInfo.goldFeedCount, this.MaxGoldFeedNum);
						this.mGoldTrainGray.enabled = true;
						this.mBtGoldTrain.interactable = false;
					}
					else
					{
						this.mGoldTrainExp.text = string.Format("<color=#FFFFFFFF>{0}</color>", num);
						this.mGoldTrainRestNum.text = string.Format("<color=#FFFFFFFF>{0}/{1}</color>", this.MaxGoldFeedNum - (int)this.CurSelPetInfo.goldFeedCount, this.MaxGoldFeedNum);
						this.mGoldTrainGray.enabled = false;
						this.mBtGoldTrain.interactable = true;
					}
					if ((int)DataManager<PlayerBaseData>.GetInstance().Gold < feedNeedMoney)
					{
						this.mGoldTrainCost.text = string.Format("<color=#FF0000FF>{0}</color>", feedNeedMoney);
					}
					else
					{
						this.mGoldTrainCost.text = feedNeedMoney.ToString();
					}
				}
				int num2 = 0;
				int feedNeedMoney2 = DataManager<PetDataManager>.GetInstance().GetFeedNeedMoney(this.CurSelPetInfo, PetFeedTable.eType.PET_FEED_POINT, ref num2);
				if (feedNeedMoney2 < 0)
				{
					this.mTicketTrainCost.text = "0";
					this.mTicketTrainExp.text = "0";
					this.mTicketTrainGray.enabled = true;
					this.mBtTicketTrain.interactable = false;
				}
				else
				{
					if ((int)this.CurSelPetInfo.pointFeedCount >= this.MaxTicketFeedNum)
					{
						this.mTicketTrainExp.text = string.Format("<color=#9FA2B8FF>{0}</color>", num2);
						this.mTicketTrainRestNum.text = string.Format("<color=#9FA2B8FF>{0}/{1}</color>", this.MaxTicketFeedNum - (int)this.CurSelPetInfo.pointFeedCount, this.MaxTicketFeedNum);
						this.mTicketTrainGray.enabled = true;
						this.mBtTicketTrain.interactable = false;
					}
					else
					{
						this.mTicketTrainExp.text = string.Format("<color=#FFFFFFFF>{0}</color>", num2);
						this.mTicketTrainRestNum.text = string.Format("<color=#FFFFFFFF>{0}/{1}</color>", this.MaxTicketFeedNum - (int)this.CurSelPetInfo.pointFeedCount, this.MaxTicketFeedNum);
						this.mTicketTrainGray.enabled = false;
						this.mBtTicketTrain.interactable = true;
					}
					if ((int)DataManager<PlayerBaseData>.GetInstance().Ticket < feedNeedMoney2)
					{
						this.mTicketTrainCost.text = string.Format("<color=#FF0000FF>{0}</color>", feedNeedMoney2);
					}
					else
					{
						this.mTicketTrainCost.text = feedNeedMoney2.ToString();
					}
				}
			}
			else
			{
				this.mSatietyRoot.CustomActive(true);
				this.mExp.gameObject.CustomActive(false);
				this.DrawPetSatietyBar();
			}
		}

		// Token: 0x0600FD7B RID: 64891 RVA: 0x0045DCB4 File Offset: 0x0045C0B4
		private void UpdateEatPetList()
		{
			this.EatPetInfoList.Clear();
			List<PetInfo> petList = DataManager<PetDataManager>.GetInstance().GetPetList();
			List<PetInfo> list = new List<PetInfo>();
			for (int i = 0; i < petList.Count; i++)
			{
				if (petList[i].id != this.CurSelPetInfo.id)
				{
					PetInfo petInfo = new PetInfo();
					DataManager<PetDataManager>.GetInstance().SetPetData(petInfo, petList[i]);
					list.Add(petInfo);
				}
			}
			int num = list.Count - this.PetEleObjList.Count;
			for (int j = 0; j < num; j++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.EatPetItemPath, true, 0U);
				if (!(gameObject == null))
				{
					Utility.AttachTo(gameObject, this.mEatPetListObjRoot, false);
					gameObject.CustomActive(false);
					this.PetEleObjList.Add(gameObject);
				}
			}
			int num2 = 0;
			this.EatPetInfoList = DataManager<PetDataManager>.GetInstance().GetPetSortListBySortType(list, ref num2, PetItemSortType.QualitySort, 0);
			for (int k = 0; k < this.PetEleObjList.Count; k++)
			{
				if (k < this.EatPetInfoList.Count)
				{
					ComCommonBind component = this.PetEleObjList[k].GetComponent<ComCommonBind>();
					if (!(component == null))
					{
						if (Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.EatPetInfoList[k].dataId, string.Empty, string.Empty) != null)
						{
							DataManager<PetDataManager>.GetInstance().SetPetItemData(this.PetEleObjList[k].gameObject, this.EatPetInfoList[k], DataManager<PlayerBaseData>.GetInstance().JobTableID, PetTipsType.None, false);
							Toggle tgSelectPet = component.GetCom<Toggle>("tgSelect");
							tgSelectPet.onValueChanged.RemoveAllListeners();
							int iIndex = k;
							tgSelectPet.onValueChanged.AddListener(delegate(bool value)
							{
								this.OnSelectEatPet(iIndex, value, tgSelectPet);
							});
							if (this.bSelAll)
							{
								tgSelectPet.isOn = true;
							}
							else
							{
								bool flag = false;
								for (int l = 0; l < this.EatPetIDList.Count; l++)
								{
									if (this.EatPetIDList[l].id == this.EatPetInfoList[k].id)
									{
										tgSelectPet.isOn = true;
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									tgSelectPet.isOn = false;
								}
							}
							this.PetEleObjList[k].CustomActive(true);
						}
					}
				}
				else
				{
					this.PetEleObjList[k].CustomActive(false);
				}
			}
			if (petList.Count <= 0)
			{
				this.mNonePetRoot.CustomActive(true);
			}
			else
			{
				this.mNonePetRoot.CustomActive(false);
			}
		}

		// Token: 0x0600FD7C RID: 64892 RVA: 0x0045DFC4 File Offset: 0x0045C3C4
		private void UpdatePropertyList()
		{
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			List<int> petSkillIDsByJob = DataManager<PetDataManager>.GetInstance().GetPetSkillIDsByJob(tableItem, DataManager<PlayerBaseData>.GetInstance().JobTableID);
			int num = petSkillIDsByJob.Count - this.PetPropObjList.Count;
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.PetPropertyPath, true, 0U);
				if (!(gameObject == null))
				{
					Utility.AttachTo(gameObject, this.mPropertyListRoot, false);
					gameObject.CustomActive(false);
					this.PetPropObjList.Add(gameObject);
				}
			}
			bool flag = false;
			for (int j = 0; j < this.PetPropObjList.Count; j++)
			{
				if (j < petSkillIDsByJob.Count)
				{
					ComCommonBind component = this.PetPropObjList[j].GetComponent<ComCommonBind>();
					if (component == null)
					{
						this.PetPropObjList[j].CustomActive(false);
					}
					else
					{
						SkillDescriptionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(petSkillIDsByJob[j], string.Empty, string.Empty);
						if (tableItem2 == null)
						{
							this.PetPropObjList[j].CustomActive(false);
						}
						else
						{
							Text com = component.GetCom<Text>("Name");
							Text com2 = component.GetCom<Text>("Des");
							Text com3 = component.GetCom<Text>("Skill");
							Text com4 = component.GetCom<Text>("CurProperty");
							Toggle com5 = component.GetCom<Toggle>("Select");
							com.text = string.Format("[{0}]", tableItem2.Name);
							com2.text = tableItem2.Description;
							List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(petSkillIDsByJob[j], (byte)this.CurSelPetInfo.level, FightTypeLabel.PVE);
							com3.text = string.Empty;
							for (int k = 0; k < skillDesList.Count; k++)
							{
								if (k < skillDesList.Count - 1)
								{
									Text text = com3;
									text.text += string.Format("{0}\n", skillDesList[k]);
								}
								else
								{
									Text text2 = com3;
									text2.text += string.Format("{0}", skillDesList[k]);
								}
							}
							int idex = j;
							com5.onValueChanged.RemoveAllListeners();
							com5.isOn = false;
							com5.onValueChanged.AddListener(delegate(bool value)
							{
								this.OnSelectProperty(idex, value);
							});
							if (j == (int)this.CurSelPetInfo.skillIndex)
							{
								flag = true;
								com4.gameObject.CustomActive(true);
								com5.gameObject.CustomActive(false);
							}
							else
							{
								com4.gameObject.CustomActive(false);
								com5.gameObject.CustomActive(true);
							}
							com5.group = this.mPropToggleGroup;
							this.PetPropObjList[j].CustomActive(true);
						}
					}
				}
				else
				{
					this.PetPropObjList[j].CustomActive(false);
				}
			}
			if (!flag)
			{
				ComCommonBind component2 = this.PetPropObjList[0].GetComponent<ComCommonBind>();
				if (component2 == null)
				{
					return;
				}
				if (Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(petSkillIDsByJob[0], string.Empty, string.Empty) == null)
				{
					return;
				}
				Text com6 = component2.GetCom<Text>("CurProperty");
				Toggle com7 = component2.GetCom<Toggle>("Select");
				com6.gameObject.CustomActive(true);
				com7.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600FD7D RID: 64893 RVA: 0x0045E384 File Offset: 0x0045C784
		private void UpdateActor(int iPetID)
		{
			PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>(iPetID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find PetTable with id:{0}", new object[]
				{
					iPetID
				});
			}
			else if (Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.ModeID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
				{
					tableItem.ModeID
				});
			}
			else
			{
				PlayerUtility.LoadPetAvatarRenderEx(iPetID, this.mAvatarRenderer, true);
				Vector3 avatarPos = this.mAvatarRenderer.avatarPos;
				avatarPos.y = (float)tableItem.ChangedHeight / 1000f;
				this.mAvatarRenderer.avatarPos = avatarPos;
				Quaternion avatarRoation = this.mAvatarRenderer.avatarRoation;
				this.mAvatarRenderer.avatarRoation = Quaternion.Euler(avatarRoation.x, (float)tableItem.ModelOrientation / 1000f, avatarRoation.z);
				Vector3 avatarScale = this.mAvatarRenderer.avatarScale;
				Vector3 avatarScale2 = this.mAvatarRenderer.avatarScale;
				avatarScale2.y = (avatarScale2.x = (avatarScale2.z = (float)tableItem.PetModelSize / 1000f));
				this.mAvatarRenderer.avatarScale = avatarScale2;
			}
		}

		// Token: 0x0600FD7E RID: 64894 RVA: 0x0045E4D4 File Offset: 0x0045C8D4
		private void DrawPetExpBar(int iLevel, ulong PetExp, PetTable.eQuality ePetQuality, bool force)
		{
			this.mExp.SetExp(PetExp, force, (ulong exp) => Singleton<TableManager>.instance.GetCurPetExpBar(iLevel, exp, ePetQuality));
		}

		// Token: 0x0600FD7F RID: 64895 RVA: 0x0045E510 File Offset: 0x0045C910
		private void DrawPetSatietyBar()
		{
			if (this.MaxSatietyNum != 0)
			{
				this.mSatietySlider.value = (float)this.CurSelPetInfo.hunger / (float)this.MaxSatietyNum;
			}
			this.mSatietyProcess.text = string.Format("{0}/{1}", this.CurSelPetInfo.hunger, this.MaxSatietyNum);
		}

		// Token: 0x0600FD80 RID: 64896 RVA: 0x0045E578 File Offset: 0x0045C978
		private void UpdateEatNeedMoney()
		{
			if (DataManager<PlayerBaseData>.GetInstance().Gold < this.GetNeedTotalMoney())
			{
				this.mTotalEatCost.text = string.Format("<color=#FF0000FF>{0}</color>", this.GetNeedTotalMoney());
			}
			else
			{
				this.mTotalEatCost.text = this.GetNeedTotalMoney().ToString();
			}
		}

		// Token: 0x0600FD81 RID: 64897 RVA: 0x0045E5E0 File Offset: 0x0045C9E0
		private void UpdateShowCurSelProperty()
		{
			this.mFreeSelectTips.CustomActive(false);
			this.mPointSelectTips.CustomActive(false);
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null || tableItem.Skills.Count <= (int)this.CurSelPetInfo.skillIndex)
			{
				return;
			}
			int petSkillIDByIndex = DataManager<PetDataManager>.GetInstance().GetPetSkillIDByIndex(tableItem, (int)this.CurSelPetInfo.skillIndex, DataManager<PlayerBaseData>.GetInstance().JobTableID);
			if (petSkillIDByIndex <= 0)
			{
				return;
			}
			SkillDescriptionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(petSkillIDByIndex, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			this.mTitle.text = tableItem2.Name;
			if (this.CurSelPetInfo.selectSkillCount == 0)
			{
				this.mReSelectGray.enabled = false;
				this.mReSelect.interactable = true;
				this.mReSelectText.text = "重选";
				this.mFreeSelectTips.CustomActive(true);
				this.CurSelPetIsFree = true;
			}
			else if (this.CurSelPetInfo.selectSkillCount > 0)
			{
				this.mReSelectGray.enabled = false;
				this.mReSelect.interactable = true;
				this.mReSelectText.text = "重选";
				this.mPointSelectTips.CustomActive(true);
				this.CurSelPetIsFree = false;
			}
		}

		// Token: 0x0600FD82 RID: 64898 RVA: 0x0045E73C File Offset: 0x0045CB3C
		private void UpdatePetList(bool bInit = false)
		{
			this.PetInfoList.Clear();
			List<PetInfo> onUsePetList = DataManager<PetDataManager>.GetInstance().GetOnUsePetList();
			for (int i = 0; i < onUsePetList.Count; i++)
			{
				PetInfo petInfo = new PetInfo();
				DataManager<PetDataManager>.GetInstance().SetPetData(petInfo, onUsePetList[i]);
				this.PetInfoList.Add(petInfo);
				if (!bInit && onUsePetList[i].id == this.CurSelPetInfo.id)
				{
					this.CheckPlayStarEffectData(onUsePetList[i].level);
					DataManager<PetDataManager>.GetInstance().SetPetData(this.CurSelPetInfo, onUsePetList[i]);
				}
			}
			List<PetInfo> petList = DataManager<PetDataManager>.GetInstance().GetPetList();
			int num = 0;
			List<PetInfo> petSortListBySortType = DataManager<PetDataManager>.GetInstance().GetPetSortListBySortType(petList, ref num, PetItemSortType.QualitySort, 0);
			for (int j = 0; j < petSortListBySortType.Count; j++)
			{
				PetInfo petInfo2 = new PetInfo();
				DataManager<PetDataManager>.GetInstance().SetPetData(petInfo2, petSortListBySortType[j]);
				this.PetInfoList.Add(petInfo2);
			}
			if (!bInit)
			{
				for (int k = 0; k < petList.Count; k++)
				{
					if (petList[k].id == this.CurSelPetInfo.id)
					{
						this.CheckPlayStarEffectData(petList[k].level);
						DataManager<PetDataManager>.GetInstance().SetPetData(this.CurSelPetInfo, petList[k]);
					}
				}
			}
		}

		// Token: 0x0600FD83 RID: 64899 RVA: 0x0045E8B2 File Offset: 0x0045CCB2
		private void UpdateEatPetIDList()
		{
			this.EatPetIDList.Clear();
			this.TotalNeedExp = 0UL;
			this.UpdatePreAddedExp();
		}

		// Token: 0x0600FD84 RID: 64900 RVA: 0x0045E8D0 File Offset: 0x0045CCD0
		private void UpdatePreAddedExp()
		{
			int addedLv = this.GetAddedLv();
			if (addedLv > 0)
			{
				this.mPreAddedLv.text = string.Format("+{0}", addedLv);
			}
			else
			{
				this.mPreAddedLv.text = string.Empty;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				this.mPreAddedExp.text = string.Empty;
				return;
			}
			if (this.TotalNeedExp > 0UL && (int)this.CurSelPetInfo.level < tableItem.MaxLv)
			{
				this.mPreAddedExp.text = string.Format("+{0}", this.TotalNeedExp / 100UL);
			}
			else
			{
				this.mPreAddedExp.text = string.Empty;
			}
		}

		// Token: 0x0600FD85 RID: 64901 RVA: 0x0045E9B0 File Offset: 0x0045CDB0
		private void UpdatePetFoodItemData()
		{
			int tableId = 0;
			int petFoodNum = DataManager<PetDataManager>.GetInstance().GetPetFoodNum(ref tableId);
			if (petFoodNum > 0)
			{
				this.PetFoodItemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
				this.PetFoodItemData.Count = 1;
				this.mItemNum.text = string.Format("{0}/1", petFoodNum);
			}
			else
			{
				this.mItemNum.text = string.Empty;
			}
		}

		// Token: 0x0600FD86 RID: 64902 RVA: 0x0045EA20 File Offset: 0x0045CE20
		private void SetPetFoodComItem()
		{
			int num = 0;
			int petFoodNum = DataManager<PetDataManager>.GetInstance().GetPetFoodNum(ref num);
			ComItem comItem = this.mPetFoodItemPos.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.mPetFoodItemPos);
			}
			if (petFoodNum <= 0)
			{
				comItem.gameObject.CustomActive(false);
			}
			else
			{
				comItem.gameObject.CustomActive(true);
			}
			comItem.Setup(this.PetFoodItemData, delegate(GameObject Obj, ItemData sitem)
			{
				this.OnPetFoodItemTips();
			});
		}

		// Token: 0x0600FD87 RID: 64903 RVA: 0x0045EAA0 File Offset: 0x0045CEA0
		private void CheckPlayStarEffectData(ushort ChangedLevel)
		{
			if (ChangedLevel % 10 == 0 && this.CurSelPetInfo.level != ChangedLevel)
			{
				this.bCanPlayStarEffect = true;
				this.bPlayStar = true;
				this.StarEffectTime = 0f;
				this.iStarIndex = (int)(ChangedLevel / 10 - 1);
			}
		}

		// Token: 0x0600FD88 RID: 64904 RVA: 0x0045EAEC File Offset: 0x0045CEEC
		private void ClickEatPetOk()
		{
			this.SendEatPetReq();
		}

		// Token: 0x0600FD89 RID: 64905 RVA: 0x0045EAF4 File Offset: 0x0045CEF4
		private void PlayCritEffect(uint CritExp, byte bIsCritical)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.CritNumPath, true, 0U);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.MiddleLayer, false);
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			GameObject gameObject2 = component.GetGameObject("CriticalRoot");
			Text com = component.GetCom<Text>("Crit");
			Text com2 = component.GetCom<Text>("NoCrit");
			if (bIsCritical == 1)
			{
				gameObject2.CustomActive(true);
				com.text = "+" + CritExp.ToString();
				com.gameObject.CustomActive(true);
				com2.gameObject.CustomActive(false);
			}
			else
			{
				gameObject2.CustomActive(false);
				com.gameObject.CustomActive(false);
				com2.text = "+" + CritExp.ToString();
				com2.gameObject.CustomActive(true);
			}
			GameObject gameObject3 = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.CritEffectPath, true, 0U);
			if (gameObject3 == null)
			{
				return;
			}
			gameObject3.name = "CritEffect";
			Utility.AttachTo(gameObject3, this.mExp.gameObject, false);
		}

		// Token: 0x0600FD8A RID: 64906 RVA: 0x0045EC28 File Offset: 0x0045D028
		private void PlayStarEffect(int iIndex)
		{
			this.ClearStarEffect(iIndex + 1);
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.StarEffectPath, true, 0U);
			if (gameObject == null)
			{
				return;
			}
			gameObject.name = "StarEffect";
			if (this.starsGray[iIndex] == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.starsGray[iIndex].gameObject, false);
		}

		// Token: 0x0600FD8B RID: 64907 RVA: 0x0045EC94 File Offset: 0x0045D094
		private void ClearStarEffect(int iIndex)
		{
			string path = string.Format(this.StarExistEffectPath, iIndex);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.DestroyImmediate(gameObject);
			}
		}

		// Token: 0x0600FD8C RID: 64908 RVA: 0x0045ECD3 File Offset: 0x0045D0D3
		private ulong GetNeedTotalMoney()
		{
			return (ulong)(this.TotalNeedExp * (ulong)((long)this.MoneyChangeCoeffi) / 100f);
		}

		// Token: 0x0600FD8D RID: 64909 RVA: 0x0045ECEC File Offset: 0x0045D0EC
		private ulong GetExpByEatPet(PetInfo pet)
		{
			ulong num = 0UL;
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)pet.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0UL;
			}
			ulong num2 = (ulong)((long)tableItem.ToDevourExp * 100L);
			if (pet.level <= 1)
			{
				return num2;
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetLevelTable>();
			if (table == null)
			{
				return num2;
			}
			num += (ulong)pet.exp;
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				PetLevelTable petLevelTable = keyValuePair.Value as PetLevelTable;
				if (petLevelTable != null)
				{
					if (petLevelTable.Quality == (int)tableItem.Quality)
					{
						if (petLevelTable.Level < (int)pet.level)
						{
							num += (ulong)((long)petLevelTable.UplevelExp);
						}
					}
				}
			}
			return num2 + num * (ulong)((long)this.ExpChangeCoeffi);
		}

		// Token: 0x0600FD8E RID: 64910 RVA: 0x0045EDD8 File Offset: 0x0045D1D8
		private int GetAddedLv()
		{
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.CurSelPetInfo.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			ulong num = this.TotalNeedExp / 100UL + (ulong)this.CurSelPetInfo.exp;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetLevelTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			ulong num2 = 0UL;
			int result = 0;
			bool flag = true;
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				PetLevelTable petLevelTable = keyValuePair.Value as PetLevelTable;
				if (petLevelTable != null)
				{
					if (petLevelTable.Quality == (int)tableItem.Quality)
					{
						if (petLevelTable.Level >= (int)this.CurSelPetInfo.level)
						{
							num2 += (ulong)((long)petLevelTable.UplevelExp);
							if (num2 > num)
							{
								result = petLevelTable.Level - (int)this.CurSelPetInfo.level;
								flag = false;
								break;
							}
						}
					}
				}
			}
			if (flag)
			{
				result = tableItem.MaxLv - (int)this.CurSelPetInfo.level;
			}
			return result;
		}

		// Token: 0x0600FD8F RID: 64911 RVA: 0x0045EEFC File Offset: 0x0045D2FC
		private void SendEatPetReq()
		{
			SceneDevourPetReq sceneDevourPetReq = new SceneDevourPetReq();
			sceneDevourPetReq.id = this.CurSelPetInfo.id;
			sceneDevourPetReq.petIds = new ulong[this.EatPetIDList.Count];
			for (int i = 0; i < this.EatPetIDList.Count; i++)
			{
				sceneDevourPetReq.petIds[i] = this.EatPetIDList[i].id;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneDevourPetReq>(ServerType.GATE_SERVER, sceneDevourPetReq);
		}

		// Token: 0x0600FD90 RID: 64912 RVA: 0x0045EF7C File Offset: 0x0045D37C
		private void SendReselectPropertyReq()
		{
			if (this.CurSelPetIsFree)
			{
				SceneChangePetSkillReq sceneChangePetSkillReq = new SceneChangePetSkillReq();
				sceneChangePetSkillReq.id = this.CurSelPetInfo.id;
				sceneChangePetSkillReq.skillIndex = (byte)this.ReSelPropertyIndex;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneChangePetSkillReq>(ServerType.GATE_SERVER, sceneChangePetSkillReq);
			}
			else
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(361, string.Empty, string.Empty);
				int value = tableItem.Value;
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(value, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return;
				}
				string name = tableItem2.Name;
				SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(362, string.Empty, string.Empty);
				int price = tableItem3.Value;
				ItemTable.eSubType itemSubtype = tableItem2.SubType;
				string msgContent = string.Format(TR.Value("pet_reselect_tips"), price, name);
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
					costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(itemSubtype);
					DataManager<ItemTipManager>.GetInstance().CloseAll();
					costInfo.nCount = price;
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
					{
						SceneChangePetSkillReq sceneChangePetSkillReq2 = new SceneChangePetSkillReq();
						sceneChangePetSkillReq2.id = this.CurSelPetInfo.id;
						sceneChangePetSkillReq2.skillIndex = (byte)this.ReSelPropertyIndex;
						NetManager netManager2 = NetManager.Instance();
						netManager2.SendCommand<SceneChangePetSkillReq>(ServerType.GATE_SERVER, sceneChangePetSkillReq2);
					}, "common_money_cost", null);
				}, null, 0f, false);
			}
		}

		// Token: 0x0600FD91 RID: 64913 RVA: 0x0045F091 File Offset: 0x0045D491
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FD92 RID: 64914 RVA: 0x0045F094 File Offset: 0x0045D494
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.bCanPlayStarEffect)
			{
				this.StarEffectTime += timeElapsed;
				if (this.StarEffectTime > this.fStartEffectTimeIntaval && this.bPlayStar)
				{
					this.PlayStarEffect(this.iStarIndex);
					this.bPlayStar = false;
				}
				if (this.StarEffectTime > this.fStartEffectTimeIntaval + 1.3f)
				{
					DataManager<PetDataManager>.GetInstance().UpdatePetStarImage(this.iStarIndex, ref this.HalfStars);
					this.bCanPlayStarEffect = false;
					this.StarEffectTime = 0f;
				}
			}
			if (null != this.mAvatarRenderer)
			{
				while (Global.Settings.avatarLightDir.x > 360f)
				{
					GlobalSetting settings = Global.Settings;
					settings.avatarLightDir.x = settings.avatarLightDir.x - 360f;
				}
				while (Global.Settings.avatarLightDir.x < 0f)
				{
					GlobalSetting settings2 = Global.Settings;
					settings2.avatarLightDir.x = settings2.avatarLightDir.x + 360f;
				}
				while (Global.Settings.avatarLightDir.y > 360f)
				{
					GlobalSetting settings3 = Global.Settings;
					settings3.avatarLightDir.y = settings3.avatarLightDir.y - 360f;
				}
				while (Global.Settings.avatarLightDir.y < 0f)
				{
					GlobalSetting settings4 = Global.Settings;
					settings4.avatarLightDir.y = settings4.avatarLightDir.y + 360f;
				}
				while (Global.Settings.avatarLightDir.z > 360f)
				{
					GlobalSetting settings5 = Global.Settings;
					settings5.avatarLightDir.z = settings5.avatarLightDir.z - 360f;
				}
				while (Global.Settings.avatarLightDir.z < 0f)
				{
					GlobalSetting settings6 = Global.Settings;
					settings6.avatarLightDir.z = settings6.avatarLightDir.z + 360f;
				}
				this.mAvatarRenderer.m_LightRot = Global.Settings.avatarLightDir;
			}
		}

		// Token: 0x0600FD93 RID: 64915 RVA: 0x0045F2A4 File Offset: 0x0045D6A4
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mPetScrollList = this.mBind.GetCom<ComUIListScript>("PetScrollList");
			this.mAvatarRenderer = this.mBind.GetCom<GeAvatarRendererEx>("AvatarRenderer");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mLevel = this.mBind.GetCom<Text>("Level");
			this.mExp = this.mBind.GetCom<ComExpBar>("Exp");
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mReSelect = this.mBind.GetCom<Button>("ReSelect");
			this.mReSelect.onClick.AddListener(new UnityAction(this._onReSelectButtonClick));
			this.mReSelectGray = this.mBind.GetCom<UIGray>("ReSelectGray");
			this.mCurPropertyContent = this.mBind.GetCom<Text>("CurPropertyContent");
			this.mNextPropertyContent = this.mBind.GetCom<Text>("NextPropertyContent");
			this.mUpObj = this.mBind.GetGameObject("UpObj");
			this.mPetFoodItemPos = this.mBind.GetGameObject("PetFoodItemPos");
			this.mFeed = this.mBind.GetCom<Button>("Feed");
			this.mFeed.onClick.AddListener(new UnityAction(this._onFeedButtonClick));
			this.mSatietyRoot = this.mBind.GetGameObject("SatietyRoot");
			this.mSatietySlider = this.mBind.GetCom<Slider>("SatietySlider");
			this.mSatietyProcess = this.mBind.GetCom<Text>("SatietyProcess");
			this.mItemNum = this.mBind.GetCom<Text>("ItemNum");
			this.mBtGoldTrain = this.mBind.GetCom<Button>("btGoldTrain");
			this.mBtGoldTrain.onClick.AddListener(new UnityAction(this._onBtGoldTrainButtonClick));
			this.mBtTicketTrain = this.mBind.GetCom<Button>("btTicketTrain");
			this.mBtTicketTrain.onClick.AddListener(new UnityAction(this._onBtTicketTrainButtonClick));
			this.mGoldTrainGray = this.mBind.GetCom<UIGray>("GoldTrainGray");
			this.mTicketTrainGray = this.mBind.GetCom<UIGray>("TicketTrainGray");
			this.mGoldTrainCost = this.mBind.GetCom<Text>("GoldTrainCost");
			this.mTicketTrainCost = this.mBind.GetCom<Text>("TicketTrainCost");
			this.mGoldTrainRestNum = this.mBind.GetCom<Text>("GoldTrainRestNum");
			this.mTicketTrainRestNum = this.mBind.GetCom<Text>("TicketTrainRestNum");
			this.mGoldTrainExp = this.mBind.GetCom<Text>("GoldTrainExp");
			this.mTicketTrainExp = this.mBind.GetCom<Text>("TicketTrainExp");
			this.mPet = this.mBind.GetCom<Toggle>("Pet");
			this.mPet.onValueChanged.AddListener(new UnityAction<bool>(this._onPetToggleValueChange));
			this.mEatPet = this.mBind.GetCom<Toggle>("EatPet");
			this.mEatPet.onValueChanged.AddListener(new UnityAction<bool>(this._onEatPetToggleValueChange));
			this.mMiddleObjRoot = this.mBind.GetGameObject("MiddleObjRoot");
			this.mDownObjRoot = this.mBind.GetGameObject("DownObjRoot");
			this.mEatPetRoot = this.mBind.GetGameObject("EatPetRoot");
			this.mBtEat = this.mBind.GetCom<Button>("btEat");
			this.mBtEat.onClick.AddListener(new UnityAction(this._onBtEatButtonClick));
			this.mTotalEatCost = this.mBind.GetCom<Text>("TotalEatCost");
			this.mEatPetListObjRoot = this.mBind.GetGameObject("EatPetListObjRoot");
			this.mOneKeySel = this.mBind.GetCom<Button>("OneKeySel");
			this.mOneKeySel.onClick.AddListener(new UnityAction(this._onOneKeySelButtonClick));
			this.mPetListName = this.mBind.GetCom<Text>("PetListName");
			this.mUpLevelTips = this.mBind.GetCom<Text>("UpLevelTips");
			this.mPreAddedLv = this.mBind.GetCom<Text>("PreAddedLv");
			this.mPreAddedExp = this.mBind.GetCom<Text>("PreAddedExp");
			this.mFeedGoTo = this.mBind.GetCom<Button>("FeedGoTo");
			this.mFeedGoTo.onClick.AddListener(new UnityAction(this._onFeedGoToButtonClick));
			this.mReSelectText = this.mBind.GetCom<Text>("ReSelectText");
			this.mPropertyListRoot = this.mBind.GetGameObject("PropertyListRoot");
			this.mPropToggleGroup = this.mBind.GetCom<ToggleGroup>("PropToggleGroup");
			this.mPetWayBtn = this.mBind.GetCom<Button>("PetWayBtn");
			this.mPetWayBtn.onClick.AddListener(new UnityAction(this._onPetWayBtnButtonClick));
			this.mNonePetRoot = this.mBind.GetGameObject("NonePetRoot");
			this.mFreeSelectTips = this.mBind.GetGameObject("FreeSelectTips");
			this.mPointSelectTips = this.mBind.GetGameObject("PointSelectTips");
			this.mPointIcon = this.mBind.GetCom<Image>("PointIcon");
			this.mPointCount = this.mBind.GetCom<Text>("PointCount");
			this.mReSelectNum = this.mBind.GetCom<Text>("ReSelectNum");
		}

		// Token: 0x0600FD94 RID: 64916 RVA: 0x0045F860 File Offset: 0x0045DC60
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mPetScrollList = null;
			this.mAvatarRenderer = null;
			this.mName = null;
			this.mLevel = null;
			this.mExp = null;
			this.mTitle = null;
			this.mReSelect.onClick.RemoveListener(new UnityAction(this._onReSelectButtonClick));
			this.mReSelect = null;
			this.mReSelectGray = null;
			this.mCurPropertyContent = null;
			this.mNextPropertyContent = null;
			this.mUpObj = null;
			this.mPetFoodItemPos = null;
			this.mFeed.onClick.RemoveListener(new UnityAction(this._onFeedButtonClick));
			this.mFeed = null;
			this.mSatietyRoot = null;
			this.mSatietySlider = null;
			this.mSatietyProcess = null;
			this.mItemNum = null;
			this.mBtGoldTrain.onClick.RemoveListener(new UnityAction(this._onBtGoldTrainButtonClick));
			this.mBtGoldTrain = null;
			this.mBtTicketTrain.onClick.RemoveListener(new UnityAction(this._onBtTicketTrainButtonClick));
			this.mBtTicketTrain = null;
			this.mGoldTrainGray = null;
			this.mTicketTrainGray = null;
			this.mGoldTrainCost = null;
			this.mTicketTrainCost = null;
			this.mGoldTrainRestNum = null;
			this.mTicketTrainRestNum = null;
			this.mGoldTrainExp = null;
			this.mTicketTrainExp = null;
			this.mPet.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPetToggleValueChange));
			this.mPet = null;
			this.mEatPet.onValueChanged.RemoveListener(new UnityAction<bool>(this._onEatPetToggleValueChange));
			this.mEatPet = null;
			this.mMiddleObjRoot = null;
			this.mDownObjRoot = null;
			this.mEatPetRoot = null;
			this.mBtEat.onClick.RemoveListener(new UnityAction(this._onBtEatButtonClick));
			this.mBtEat = null;
			this.mTotalEatCost = null;
			this.mEatPetListObjRoot = null;
			this.mOneKeySel.onClick.RemoveListener(new UnityAction(this._onOneKeySelButtonClick));
			this.mOneKeySel = null;
			this.mPetListName = null;
			this.mUpLevelTips = null;
			this.mPreAddedLv = null;
			this.mPreAddedExp = null;
			this.mFeedGoTo.onClick.RemoveListener(new UnityAction(this._onFeedGoToButtonClick));
			this.mFeedGoTo = null;
			this.mReSelectText = null;
			this.mPropertyListRoot = null;
			this.mPropToggleGroup = null;
			this.mPetWayBtn.onClick.RemoveListener(new UnityAction(this._onPetWayBtnButtonClick));
			this.mPetWayBtn = null;
			this.mNonePetRoot = null;
			this.mFreeSelectTips = null;
			this.mPointSelectTips = null;
			this.mPointIcon = null;
			this.mPointCount = null;
			this.mReSelectNum = null;
		}

		// Token: 0x0600FD95 RID: 64917 RVA: 0x0045FB0D File Offset: 0x0045DF0D
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<PetInfoFrame>(this, false);
		}

		// Token: 0x0600FD96 RID: 64918 RVA: 0x0045FB1C File Offset: 0x0045DF1C
		private void _onReSelectButtonClick()
		{
			if (this.ReSelPropertyIndex < 0)
			{
				SystemNotifyManager.SystemNotify(9059, string.Empty);
				return;
			}
			if (this.ReSelPropertyIndex == (int)this.CurSelPetInfo.skillIndex)
			{
				SystemNotifyManager.SystemNotify(9059, string.Empty);
				return;
			}
			this.SendReselectPropertyReq();
		}

		// Token: 0x0600FD97 RID: 64919 RVA: 0x0045FB74 File Offset: 0x0045DF74
		private void _onFeedButtonClick()
		{
			if (this.PetFoodItemData == null)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("宠物口粮不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.PetFoodItemData.Count <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("宠物口粮不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<PetDataManager>.GetInstance().SendFeedPetReq(PetFeedTable.eType.PET_FEED_ITEM, this.CurSelPetInfo.id, false);
		}

		// Token: 0x0600FD98 RID: 64920 RVA: 0x0045FBD0 File Offset: 0x0045DFD0
		private void _onBtGoldTrainButtonClick()
		{
			if ((int)this.CurSelPetInfo.goldFeedCount >= this.MaxGoldFeedNum)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("今日金币喂养次数已用完", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int num = 0;
			int feedNeedMoney = DataManager<PetDataManager>.GetInstance().GetFeedNeedMoney(this.CurSelPetInfo, PetFeedTable.eType.PET_FEED_GOLD, ref num);
			if (feedNeedMoney < 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("所需金币计算错误", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD);
			costInfo.nCount = feedNeedMoney;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				DataManager<PetDataManager>.GetInstance().SendFeedPetReq(PetFeedTable.eType.PET_FEED_GOLD, this.CurSelPetInfo.id, false);
			}, "common_money_cost", null);
		}

		// Token: 0x0600FD99 RID: 64921 RVA: 0x0045FC68 File Offset: 0x0045E068
		private void _onBtTicketTrainButtonClick()
		{
			if ((int)this.CurSelPetInfo.pointFeedCount >= this.MaxTicketFeedNum)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("今日点券喂养次数已用完", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int num = 0;
			int feedNeedMoney = DataManager<PetDataManager>.GetInstance().GetFeedNeedMoney(this.CurSelPetInfo, PetFeedTable.eType.PET_FEED_POINT, ref num);
			if (feedNeedMoney < 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("所需点券计算错误", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			costInfo.nCount = feedNeedMoney;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				DataManager<PetDataManager>.GetInstance().SendFeedPetReq(PetFeedTable.eType.PET_FEED_POINT, this.CurSelPetInfo.id, false);
			}, "common_money_cost", null);
		}

		// Token: 0x0600FD9A RID: 64922 RVA: 0x0045FD10 File Offset: 0x0045E110
		private void _onPetToggleValueChange(bool changed)
		{
			if (!changed)
			{
				return;
			}
			this.mMiddleObjRoot.CustomActive(true);
			this.mDownObjRoot.CustomActive(true);
			this.mEatPetRoot.CustomActive(false);
			this.TotalNeedExp = 0UL;
			this.bSelAll = false;
			this.EatPetIDList.Clear();
		}

		// Token: 0x0600FD9B RID: 64923 RVA: 0x0045FD62 File Offset: 0x0045E162
		private void _onEatPetToggleValueChange(bool changed)
		{
			if (!changed)
			{
				return;
			}
			this.mMiddleObjRoot.CustomActive(false);
			this.mDownObjRoot.CustomActive(false);
			this.mEatPetRoot.CustomActive(true);
			this.UpdateEatPetList();
			this.UpdateEatNeedMoney();
		}

		// Token: 0x0600FD9C RID: 64924 RVA: 0x0045FD9C File Offset: 0x0045E19C
		private void _onBtEatButtonClick()
		{
			if (this.EatPetIDList.Count <= 0)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().Gold < this.GetNeedTotalMoney())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("吞噬宠物所需金币不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.EatPetIDList.Count; i++)
			{
				PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)this.EatPetIDList[i].dataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.Quality >= PetTable.eQuality.QL_PINK)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel("吞噬的宠物中包含粉色品质，是否确认吞噬？", new UnityAction(this.ClickEatPetOk), null, 0f, false);
				return;
			}
			this.SendEatPetReq();
		}

		// Token: 0x0600FD9D RID: 64925 RVA: 0x0045FE7B File Offset: 0x0045E27B
		private void _onOneKeySelButtonClick()
		{
			this.bSelAll = !this.bSelAll;
			this.UpdateEatPetList();
		}

		// Token: 0x0600FD9E RID: 64926 RVA: 0x0045FE94 File Offset: 0x0045E294
		private void _onFeedGoToButtonClick()
		{
			int num = 0;
			int petFoodNum = DataManager<PetDataManager>.GetInstance().GetPetFoodNum(ref num);
			if (petFoodNum <= 0)
			{
				ItemComeLink.OnLink(811000004, 0, true, null, false, false, false, null, string.Empty);
			}
		}

		// Token: 0x0600FD9F RID: 64927 RVA: 0x0045FED0 File Offset: 0x0045E2D0
		private void _onPetWayBtnButtonClick()
		{
			ItemComeLink.OnLink(102, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x04009F43 RID: 40771
		private string EatPetItemPath = "UIFlatten/Prefabs/Pet/EatPetEle";

		// Token: 0x04009F44 RID: 40772
		private string CritEffectPath = "Effects/Scene_effects/EffectUI/EffUI_cwkl_baoji";

		// Token: 0x04009F45 RID: 40773
		private string CritNumPath = "UIFlatten/Prefabs/Pet/PetCritEffect";

		// Token: 0x04009F46 RID: 40774
		private string StarEffectPath = "Effects/Scene_effects/EffectUI/EffUI_ui_xing";

		// Token: 0x04009F47 RID: 40775
		private string StarExistEffectPath = "middle/up/ShowInfo/stars/star{0}/StarEffect";

		// Token: 0x04009F48 RID: 40776
		private string PetPropertyPath = "UIFlatten/Prefabs/Pet/PetPropertyEle";

		// Token: 0x04009F49 RID: 40777
		private const int MaxMainTypeNum = 3;

		// Token: 0x04009F4A RID: 40778
		private const int MaxStarNum = 5;

		// Token: 0x04009F4B RID: 40779
		private int MaxGoldFeedNum;

		// Token: 0x04009F4C RID: 40780
		private int MaxTicketFeedNum;

		// Token: 0x04009F4D RID: 40781
		private int MaxSatietyNum;

		// Token: 0x04009F4E RID: 40782
		private int ExpChangeCoeffi;

		// Token: 0x04009F4F RID: 40783
		private int MoneyChangeCoeffi;

		// Token: 0x04009F50 RID: 40784
		private List<GameObject> PetEleObjList = new List<GameObject>();

		// Token: 0x04009F51 RID: 40785
		private List<GameObject> PetPropObjList = new List<GameObject>();

		// Token: 0x04009F52 RID: 40786
		private ItemData PetFoodItemData = new ItemData(0);

		// Token: 0x04009F53 RID: 40787
		private InitPetData initPetData = default(InitPetData);

		// Token: 0x04009F54 RID: 40788
		private List<PetInfo> PetInfoList = new List<PetInfo>();

		// Token: 0x04009F55 RID: 40789
		private List<PetInfo> EatPetInfoList = new List<PetInfo>();

		// Token: 0x04009F56 RID: 40790
		private List<PetInfo> EatPetIDList = new List<PetInfo>();

		// Token: 0x04009F57 RID: 40791
		private PetInfo CurSelPetInfo = new PetInfo();

		// Token: 0x04009F58 RID: 40792
		private PetInfoTabType CurSelMainType;

		// Token: 0x04009F59 RID: 40793
		private int ReSelPropertyIndex = -1;

		// Token: 0x04009F5A RID: 40794
		private ulong TotalNeedExp;

		// Token: 0x04009F5B RID: 40795
		private bool bSelAll;

		// Token: 0x04009F5C RID: 40796
		private bool bCanPlayStarEffect;

		// Token: 0x04009F5D RID: 40797
		private bool bPlayStar;

		// Token: 0x04009F5E RID: 40798
		private bool CurSelPetIsFree = true;

		// Token: 0x04009F5F RID: 40799
		private float fStartEffectTimeIntaval = 1f;

		// Token: 0x04009F60 RID: 40800
		private float StarEffectTime;

		// Token: 0x04009F61 RID: 40801
		private int iStarIndex;

		// Token: 0x04009F62 RID: 40802
		[UIControl("MainTab/Func{0}", typeof(Toggle), 1)]
		private Toggle[] MainTabs = new Toggle[3];

		// Token: 0x04009F63 RID: 40803
		[UIControl("middle/ShowType{0}", typeof(RectTransform), 1)]
		private RectTransform[] MiddleShowTypeRoots = new RectTransform[3];

		// Token: 0x04009F64 RID: 40804
		[UIControl("middle/up/ShowInfo/stars/star{0}", typeof(UIGray), 1)]
		private UIGray[] starsGray = new UIGray[5];

		// Token: 0x04009F65 RID: 40805
		[UIControl("middle/up/ShowInfo/stars/starroot/star{0}", typeof(Image), 1)]
		private Image[] HalfStars = new Image[10];

		// Token: 0x04009F66 RID: 40806
		[UIControl("middle/up/ShowInfo/stars/starrootshadow/star{0}", typeof(Image), 1)]
		private Image[] HalfShadowStars = new Image[10];

		// Token: 0x04009F67 RID: 40807
		private Button mBtClose;

		// Token: 0x04009F68 RID: 40808
		private ComUIListScript mPetScrollList;

		// Token: 0x04009F69 RID: 40809
		private GeAvatarRendererEx mAvatarRenderer;

		// Token: 0x04009F6A RID: 40810
		private Text mName;

		// Token: 0x04009F6B RID: 40811
		private Text mLevel;

		// Token: 0x04009F6C RID: 40812
		private ComExpBar mExp;

		// Token: 0x04009F6D RID: 40813
		private Text mTitle;

		// Token: 0x04009F6E RID: 40814
		private Button mReSelect;

		// Token: 0x04009F6F RID: 40815
		private UIGray mReSelectGray;

		// Token: 0x04009F70 RID: 40816
		private Text mCurPropertyContent;

		// Token: 0x04009F71 RID: 40817
		private Text mNextPropertyContent;

		// Token: 0x04009F72 RID: 40818
		private GameObject mUpObj;

		// Token: 0x04009F73 RID: 40819
		private GameObject mPetFoodItemPos;

		// Token: 0x04009F74 RID: 40820
		private Button mFeed;

		// Token: 0x04009F75 RID: 40821
		private GameObject mSatietyRoot;

		// Token: 0x04009F76 RID: 40822
		private Slider mSatietySlider;

		// Token: 0x04009F77 RID: 40823
		private Text mSatietyProcess;

		// Token: 0x04009F78 RID: 40824
		private Text mItemNum;

		// Token: 0x04009F79 RID: 40825
		private Button mBtGoldTrain;

		// Token: 0x04009F7A RID: 40826
		private Button mBtTicketTrain;

		// Token: 0x04009F7B RID: 40827
		private UIGray mGoldTrainGray;

		// Token: 0x04009F7C RID: 40828
		private UIGray mTicketTrainGray;

		// Token: 0x04009F7D RID: 40829
		private Text mGoldTrainCost;

		// Token: 0x04009F7E RID: 40830
		private Text mTicketTrainCost;

		// Token: 0x04009F7F RID: 40831
		private Text mGoldTrainRestNum;

		// Token: 0x04009F80 RID: 40832
		private Text mTicketTrainRestNum;

		// Token: 0x04009F81 RID: 40833
		private Text mGoldTrainExp;

		// Token: 0x04009F82 RID: 40834
		private Text mTicketTrainExp;

		// Token: 0x04009F83 RID: 40835
		private Toggle mPet;

		// Token: 0x04009F84 RID: 40836
		private Toggle mEatPet;

		// Token: 0x04009F85 RID: 40837
		private GameObject mMiddleObjRoot;

		// Token: 0x04009F86 RID: 40838
		private GameObject mDownObjRoot;

		// Token: 0x04009F87 RID: 40839
		private GameObject mEatPetRoot;

		// Token: 0x04009F88 RID: 40840
		private Button mBtEat;

		// Token: 0x04009F89 RID: 40841
		private Text mTotalEatCost;

		// Token: 0x04009F8A RID: 40842
		private GameObject mEatPetListObjRoot;

		// Token: 0x04009F8B RID: 40843
		private Button mOneKeySel;

		// Token: 0x04009F8C RID: 40844
		private Text mPetListName;

		// Token: 0x04009F8D RID: 40845
		private Text mUpLevelTips;

		// Token: 0x04009F8E RID: 40846
		private Text mPreAddedLv;

		// Token: 0x04009F8F RID: 40847
		private Text mPreAddedExp;

		// Token: 0x04009F90 RID: 40848
		private Button mFeedGoTo;

		// Token: 0x04009F91 RID: 40849
		private Text mReSelectText;

		// Token: 0x04009F92 RID: 40850
		private GameObject mPropertyListRoot;

		// Token: 0x04009F93 RID: 40851
		private ToggleGroup mPropToggleGroup;

		// Token: 0x04009F94 RID: 40852
		private Button mPetWayBtn;

		// Token: 0x04009F95 RID: 40853
		private GameObject mNonePetRoot;

		// Token: 0x04009F96 RID: 40854
		private GameObject mFreeSelectTips;

		// Token: 0x04009F97 RID: 40855
		private GameObject mPointSelectTips;

		// Token: 0x04009F98 RID: 40856
		private Image mPointIcon;

		// Token: 0x04009F99 RID: 40857
		private Text mPointCount;

		// Token: 0x04009F9A RID: 40858
		private Text mReSelectNum;
	}
}
