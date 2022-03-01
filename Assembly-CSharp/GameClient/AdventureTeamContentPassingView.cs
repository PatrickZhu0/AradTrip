using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001423 RID: 5155
	public class AdventureTeamContentPassingView : AdventureTeamContentBaseView
	{
		// Token: 0x0600C7CC RID: 51148 RVA: 0x00305DA9 File Offset: 0x003041A9
		private void Awake()
		{
			this.BindEvents();
			this._InitTR();
			this._InitPassingBlessInfo();
			this._InitExpItemScrollListBind();
			this._InitEffectHandler();
		}

		// Token: 0x0600C7CD RID: 51149 RVA: 0x00305DC9 File Offset: 0x003041C9
		private void OnDestroy()
		{
			this.UnBindEvents();
			this._ClearTR();
			this._ClearExpItemScrollListBind();
			this._UnInitEffectHandler();
			this.currEmptyExpFlyTargetBind = null;
			DataManager<AdventureTeamDataManager>.GetInstance().ResetUiTempPassBlessModel();
			this.isEffectPlaying = false;
		}

		// Token: 0x0600C7CE RID: 51150 RVA: 0x00305DFC File Offset: 0x003041FC
		private void BindEvents()
		{
			if (null != this.mExpBtn)
			{
				this.mExpBtn.onClick.AddListener(new UnityAction(this.ExpRewardMsgBox));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamInheritBlessInfoRes, new ClientEventSystem.UIEventHandler(this._InitPassingBlessNetInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._RefreshPassBlessContent));
		}

		// Token: 0x0600C7CF RID: 51151 RVA: 0x00305E6C File Offset: 0x0030426C
		private void UnBindEvents()
		{
			if (null != this.mExpBtn)
			{
				this.mExpBtn.onClick.RemoveListener(new UnityAction(this.ExpRewardMsgBox));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamInheritBlessInfoRes, new ClientEventSystem.UIEventHandler(this._InitPassingBlessNetInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._RefreshPassBlessContent));
		}

		// Token: 0x0600C7D0 RID: 51152 RVA: 0x00305EDC File Offset: 0x003042DC
		private void _InitTR()
		{
			this.tr_pass_bless_exp_can_get_format = TR.Value("adventure_team_pass_bless_Exp_Can_Get");
			this.tr_pass_bless_count_format = TR.Value("adventure_team_pass_bless_count");
			this.tr_pass_bless_exp_accumulate_format = TR.Value("adventure_team_pass_bless_CumulativeEXP");
			this.tr_pass_bless_role_level_format = TR.Value("adventure_team_pass_bless_role_level");
			this.tr_pass_bless_get_exp_level_info = TR.Value("adventure_team_pass_bless_get_exp_level_info");
			this.tr_pass_bless_reset_time_desc = TR.Value("adventure_team_pass_bless_reset_time_desc");
			this.tr_pass_bless_exp_btn_desc_get_one = TR.Value("adventure_team_pass_bless_btn_get_one");
			this.tr_pass_bless_exp_btn_desc_get_oneten = TR.Value("adventure_team_pass_bless_btn_get_oneten");
			this.tr_pass_bless_exp_btn_desc_get_some = TR.Value("adventure_team_pass_bless_btn_get_someexp");
			this.tr_pass_bless_exp_btn_is_playing_anim = TR.Value("adventure_team_pass_bless_btn_is_effect_playing");
		}

		// Token: 0x0600C7D1 RID: 51153 RVA: 0x00305F8C File Offset: 0x0030438C
		private void _ClearTR()
		{
			this.tr_pass_bless_exp_can_get_format = string.Empty;
			this.tr_pass_bless_count_format = string.Empty;
			this.tr_pass_bless_exp_accumulate_format = string.Empty;
			this.tr_pass_bless_role_level_format = string.Empty;
			this.tr_pass_bless_get_exp_level_info = string.Empty;
			this.tr_pass_bless_reset_time_desc = string.Empty;
			this.tr_pass_bless_exp_btn_desc_get_one = string.Empty;
			this.tr_pass_bless_exp_btn_desc_get_oneten = string.Empty;
			this.tr_pass_bless_exp_btn_desc_get_some = string.Empty;
			this.tr_pass_bless_exp_btn_is_playing_anim = string.Empty;
		}

		// Token: 0x0600C7D2 RID: 51154 RVA: 0x00306008 File Offset: 0x00304408
		private void _InitExpItemScrollListBind()
		{
			if (this.mItemListRoot != null && !this.mItemListRoot.IsInitialised())
			{
				this.mItemListRoot.Initialize();
				ComUIListScript comUIListScript = this.mItemListRoot;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnExpItemVisible));
				ComUIListScript comUIListScript2 = this.mItemListRoot;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnExpItemUpdate));
			}
		}

		// Token: 0x0600C7D3 RID: 51155 RVA: 0x00306090 File Offset: 0x00304490
		private void _ClearExpItemScrollListBind()
		{
			if (this.mItemListRoot == null)
			{
				ComUIListScript comUIListScript = this.mItemListRoot;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnExpItemVisible));
				ComUIListScript comUIListScript2 = this.mItemListRoot;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnExpItemUpdate));
				this.mItemListRoot.UnInitialize();
			}
		}

		// Token: 0x0600C7D4 RID: 51156 RVA: 0x00306108 File Offset: 0x00304508
		private void _OnExpItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (item.m_index < 0 || (long)item.m_index >= (long)((ulong)this.passBlessItemMaxCount))
			{
				return;
			}
			AdventureTeamPassBlessExpPotionBind component = item.GetComponent<AdventureTeamPassBlessExpPotionBind>();
			if (null == component)
			{
				return;
			}
			string unitNumWithHeadZero = Utility.GetUnitNumWithHeadZero(item.m_index, true);
			bool bEmpty = false;
			if (this.isSkipAnim)
			{
				bEmpty = ((ulong)this.passBlessItemOwnCount <= (ulong)((long)item.m_index));
			}
			else
			{
				int num = DataManager<AdventureTeamDataManager>.GetInstance().CheckNeedFlyExpTimes();
				if (num > 0)
				{
					InheritBlessModel uiTempInheritBlessModel = DataManager<AdventureTeamDataManager>.GetInstance().UiTempInheritBlessModel;
					if (uiTempInheritBlessModel != null)
					{
						bEmpty = ((ulong)uiTempInheritBlessModel.ownInheritBlessNum <= (ulong)((long)item.m_index));
					}
				}
				else
				{
					bEmpty = ((ulong)this.passBlessItemOwnCount <= (ulong)((long)item.m_index));
				}
			}
			component.InitView(unitNumWithHeadZero, bEmpty);
			if (component.GetDrugIsEmpty())
			{
				if (this.currEmptyExpFlyTargetBind == null)
				{
					this.currEmptyExpFlyTargetBind = component;
					this.currEmptyExpFlyTargetIndex = item.m_index;
				}
				else if (!this.currEmptyExpFlyTargetBind.GetDrugIsEmpty())
				{
					this.currEmptyExpFlyTargetBind = component;
					this.currEmptyExpFlyTargetIndex = item.m_index;
				}
				else if (item.m_index < this.currEmptyExpFlyTargetIndex && component != this.currEmptyExpFlyTargetBind)
				{
					this.currEmptyExpFlyTargetBind = component;
					this.currEmptyExpFlyTargetIndex = item.m_index;
				}
			}
		}

		// Token: 0x0600C7D5 RID: 51157 RVA: 0x0030628C File Offset: 0x0030468C
		private void _OnExpItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (item.m_index < 0 || (long)item.m_index >= (long)((ulong)this.passBlessItemMaxCount))
			{
				return;
			}
			AdventureTeamPassBlessExpPotionBind component = item.GetComponent<AdventureTeamPassBlessExpPotionBind>();
			if (null == component)
			{
				return;
			}
			bool flag = false;
			if (this.isSkipAnim)
			{
				flag = ((ulong)this.passBlessItemOwnCount <= (ulong)((long)item.m_index));
			}
			else
			{
				int num = DataManager<AdventureTeamDataManager>.GetInstance().CheckNeedFlyExpTimes();
				if (num > 0)
				{
					InheritBlessModel uiTempInheritBlessModel = DataManager<AdventureTeamDataManager>.GetInstance().UiTempInheritBlessModel;
					if (uiTempInheritBlessModel != null)
					{
						flag = ((ulong)uiTempInheritBlessModel.ownInheritBlessNum <= (ulong)((long)item.m_index));
					}
				}
				else
				{
					flag = ((ulong)this.passBlessItemOwnCount <= (ulong)((long)item.m_index));
				}
			}
			if (flag)
			{
				component.Useup();
			}
			else
			{
				component.Fillup();
			}
			if (component.GetDrugIsEmpty())
			{
				if (this.currEmptyExpFlyTargetBind == null)
				{
					this.currEmptyExpFlyTargetBind = component;
					this.currEmptyExpFlyTargetIndex = item.m_index;
				}
				else if (!this.currEmptyExpFlyTargetBind.GetDrugIsEmpty())
				{
					this.currEmptyExpFlyTargetBind = component;
					this.currEmptyExpFlyTargetIndex = item.m_index;
				}
				else if (item.m_index < this.currEmptyExpFlyTargetIndex && component != this.currEmptyExpFlyTargetBind)
				{
					this.currEmptyExpFlyTargetBind = component;
					this.currEmptyExpFlyTargetIndex = item.m_index;
				}
			}
		}

		// Token: 0x0600C7D6 RID: 51158 RVA: 0x00306410 File Offset: 0x00304810
		private void _InitPassingBlessInfo()
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			ItemTable passBlessItem = DataManager<AdventureTeamDataManager>.GetInstance().PassBlessItem;
			if (passBlessItem != null)
			{
				text = passBlessItem.Name;
				text2 = passBlessItem.NeedLevel.ToString();
				text3 = passBlessItem.MaxLevel.ToString();
				int id = passBlessItem.ID;
			}
			int playerMaxLv = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(488, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(489, string.Empty, string.Empty);
			if (tableItem != null && tableItem2 != null && tableItem2.Value != 0)
			{
				this.rewardMaxExp = tableItem.Value;
				this.rewardUnitExp = tableItem2.Value;
				if (this.rewardMaxExp != 0)
				{
					int num = this.rewardMaxExp / this.rewardUnitExp;
				}
			}
			if (null != this.mItemName)
			{
				this.mItemName.text = text;
			}
			if (this.mPlayerLevelNotify)
			{
				this.mPlayerLevelNotify.text = string.Format(this.tr_pass_bless_get_exp_level_info, text2.ToString(), text3.ToString());
			}
			if (this.mResetTimeDesc)
			{
				this.mResetTimeDesc.text = this.tr_pass_bless_reset_time_desc;
			}
		}

		// Token: 0x0600C7D7 RID: 51159 RVA: 0x00306588 File Offset: 0x00304988
		private void _RefreshPassBlessBtnInfo(bool hasInited = false)
		{
			InheritBlessModel inheritBlessModel = DataManager<AdventureTeamDataManager>.GetInstance().InheritBlessModel;
			if (inheritBlessModel == null)
			{
				return;
			}
			InheritExpModel inheritExpModel = DataManager<AdventureTeamDataManager>.GetInstance().InheritExpModel;
			if (inheritExpModel == null)
			{
				return;
			}
			this.passBlessItemOwnCount = inheritBlessModel.ownInheritBlessNum;
			this.passBlessItemMaxCount = inheritBlessModel.inheritBlessMaxNum;
			ulong ownInheritBlessExp = inheritExpModel.ownInheritBlessExp;
			ulong num = inheritExpModel.inheritBlessUnitExp;
			ulong num2 = inheritExpModel.inheritBlessMaxExp;
			this.inheritBlessUnitExp = num;
			this.inheritBlessMaxExp = num2;
			if (!hasInited)
			{
				if (this.mItemListRoot)
				{
					this.mItemListRoot.SetElementAmount((int)this.passBlessItemMaxCount);
				}
			}
			else if (this.mItemListRoot)
			{
				this.mItemListRoot.UpdateElement();
			}
			this._UpdateExpBtnState(ownInheritBlessExp, this.inheritBlessUnitExp);
			this._UpdatePlayerInfo();
		}

		// Token: 0x0600C7D8 RID: 51160 RVA: 0x00306650 File Offset: 0x00304A50
		private void _UpdateExpBtnState(ulong ownExp, ulong unitExp)
		{
			if (null != this.mItemNumCount)
			{
				this.mItemNumCount.text = string.Format(this.tr_pass_bless_count_format, this.passBlessItemOwnCount.ToString(), this.passBlessItemMaxCount.ToString());
			}
			if (null != this.mCrystalIntroucation)
			{
				this.mCrystalIntroucation.text = string.Format(this.tr_pass_bless_exp_accumulate_format, Utility.ToThousandsSeparator(ownExp), Utility.ToThousandsSeparator(this.inheritBlessMaxExp));
			}
			if (this.passBlessItemOwnCount > 0U)
			{
				this._SetRewardExpGetDesc(Utility.ToThousandsSeparator((ulong)((long)this.rewardMaxExp)));
				this._SetExpBtnDesc(this.tr_pass_bless_exp_btn_desc_get_one);
			}
			else if (this.passBlessItemOwnCount <= 0U && ownExp > unitExp)
			{
				this._SetRewardExpGetDesc(Utility.ToThousandsSeparator((ulong)(ownExp * 0.1)));
				this._SetExpBtnDesc(this.tr_pass_bless_exp_btn_desc_get_oneten);
			}
			else
			{
				this._SetRewardExpGetDesc("0");
				this._SetExpBtnDesc(this.tr_pass_bless_exp_btn_desc_get_some);
			}
			if (!DataManager<AdventureTeamDataManager>.GetInstance().IsEnableToUsePassBless())
			{
				this._SetExpBtnEnable(false);
				this._SetExpBtnActive(false);
			}
			else if (ownExp < unitExp && this.passBlessItemOwnCount == 0U)
			{
				this._SetExpBtnEnable(false);
				this._SetExpBtnActive(true);
			}
			else
			{
				this._SetExpBtnEnable(true);
				this._SetExpBtnActive(true);
			}
		}

		// Token: 0x0600C7D9 RID: 51161 RVA: 0x003067B8 File Offset: 0x00304BB8
		private void _SetExpBtnEnable(bool bEnable)
		{
			if (this.mExpBtn)
			{
				this.mExpBtn.enabled = bEnable;
			}
			if (this.mExpBtnUIGray)
			{
				this.mExpBtnUIGray.enabled = !bEnable;
			}
		}

		// Token: 0x0600C7DA RID: 51162 RVA: 0x003067F8 File Offset: 0x00304BF8
		private void _SetExpBtnActive(bool bActive)
		{
			if (this.mExpBtn)
			{
				this.mExpBtn.CustomActive(bActive);
			}
			if (this.mPlayerLevelNotify)
			{
				this.mPlayerLevelNotify.CustomActive(!bActive);
			}
			if (this.mExpReward)
			{
				this.mExpReward.CustomActive(bActive);
			}
		}

		// Token: 0x0600C7DB RID: 51163 RVA: 0x0030685C File Offset: 0x00304C5C
		private void _SetRewardExpGetDesc(string rewardExpStr)
		{
			if (this.mExpReward)
			{
				this.mExpReward.text = string.Format(this.tr_pass_bless_exp_can_get_format, rewardExpStr);
			}
		}

		// Token: 0x0600C7DC RID: 51164 RVA: 0x00306885 File Offset: 0x00304C85
		private void _SetExpBtnDesc(string desc)
		{
			if (this.mExpBtnText)
			{
				this.mExpBtnText.text = desc;
			}
		}

		// Token: 0x0600C7DD RID: 51165 RVA: 0x003068A3 File Offset: 0x00304CA3
		private void _InitPlayerBaseInfo()
		{
			this.SetPlayerIcon();
			this.SetPlayerName();
			this._UpdatePlayerInfo();
		}

		// Token: 0x0600C7DE RID: 51166 RVA: 0x003068B8 File Offset: 0x00304CB8
		private void _UpdatePlayerInfo()
		{
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			ulong currLevelExp = Singleton<TableManager>.GetInstance().GetExpByLevel((int)level);
			ulong curExp = DataManager<PlayerBaseData>.GetInstance().CurExp;
			if (this.mPlayerLV)
			{
				this.mPlayerLV.text = string.Format(this.tr_pass_bless_role_level_format, level.ToString());
			}
			if (this.mExpSlider)
			{
				this.mExpSlider.SetExp(curExp, true, (ulong exp) => new KeyValuePair<ulong, ulong>(exp, currLevelExp));
			}
		}

		// Token: 0x0600C7DF RID: 51167 RVA: 0x0030694E File Offset: 0x00304D4E
		private void SetPlayerName()
		{
			if (this.mPlayerName)
			{
				this.mPlayerName.text = DataManager<PlayerBaseData>.GetInstance().Name;
			}
		}

		// Token: 0x0600C7E0 RID: 51168 RVA: 0x00306978 File Offset: 0x00304D78
		private void SetPlayerIcon()
		{
			string text = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					text = tableItem2.IconPath;
				}
			}
			if (this.mPlayerIcon && !string.IsNullOrEmpty(text))
			{
				ETCImageLoader.LoadSprite(ref this.mPlayerIcon, text, true);
			}
		}

		// Token: 0x0600C7E1 RID: 51169 RVA: 0x00306A01 File Offset: 0x00304E01
		private void _TryQueryPassBlessData()
		{
			this._SetExpBtnEnable(false);
			this._SetExpBtnActive(true);
			DataManager<AdventureTeamDataManager>.GetInstance().ReqPassBlessInfo();
		}

		// Token: 0x0600C7E2 RID: 51170 RVA: 0x00306A1B File Offset: 0x00304E1B
		public override void InitData()
		{
			this._InitEffectView();
			this._InitPlayerBaseInfo();
			this._TryQueryPassBlessData();
			DataManager<AdventureTeamDataManager>.GetInstance().OnFirstCheckPassBlessFlag = false;
		}

		// Token: 0x0600C7E3 RID: 51171 RVA: 0x00306A3A File Offset: 0x00304E3A
		public override void OnEnableView()
		{
			this._TryQueryPassBlessData();
			DataManager<AdventureTeamDataManager>.GetInstance().OnFirstCheckPassBlessFlag = false;
		}

		// Token: 0x0600C7E4 RID: 51172 RVA: 0x00306A4D File Offset: 0x00304E4D
		public override void OnDisableView()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ResetUiTempPassBlessModel();
		}

		// Token: 0x0600C7E5 RID: 51173 RVA: 0x00306A59 File Offset: 0x00304E59
		private void _InitPassingBlessNetInfo(UIEvent ui)
		{
			this._RefreshPassBlessBtnInfo(false);
			this._RefreshEffectView();
		}

		// Token: 0x0600C7E6 RID: 51174 RVA: 0x00306A68 File Offset: 0x00304E68
		private void _RefreshPassBlessContent(UIEvent uiEvent)
		{
			this._RefreshPassBlessBtnInfo(true);
			this._RefreshEffectView();
		}

		// Token: 0x0600C7E7 RID: 51175 RVA: 0x00306A78 File Offset: 0x00304E78
		private void ExpRewardMsgBox()
		{
			if (this.isEffectPlaying)
			{
				SystemNotifyManager.SysNotifyTextAnimation(this.tr_pass_bless_exp_btn_is_playing_anim, CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			string msgContent = string.Empty;
			ulong curExp = DataManager<PlayerBaseData>.GetInstance().CurExp;
			int num = (this.passBlessItemOwnCount <= 0U) ? this.rewardUnitExp : this.rewardMaxExp;
			ushort num2 = 0;
			ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
			double num3 = (double)num + curExp;
			TableManager instance = Singleton<TableManager>.GetInstance();
			int num4 = (int)level;
			ushort num5 = num2;
			num2 = num5 + 1;
			double num6 = num3 - instance.GetExpByLevel(num4 + (int)num5);
			double num7 = 0.0;
			if (num6 < 0.0)
			{
				double num8 = Singleton<TableManager>.GetInstance().GetExpByLevel((int)level);
				if (num8 != 0.0)
				{
					num7 = ((long)num + (long)curExp) * 100L / num8;
					num2 -= 1;
				}
			}
			else
			{
				while (num6 > Singleton<TableManager>.GetInstance().GetExpByLevel((int)(level + num2)))
				{
					double num9 = num6;
					TableManager instance2 = Singleton<TableManager>.GetInstance();
					int num10 = (int)level;
					ushort num11 = num2;
					num2 = num11 + 1;
					num6 = num9 - instance2.GetExpByLevel(num10 + (int)num11);
				}
				double num12 = Singleton<TableManager>.GetInstance().GetExpByLevel((int)(level + num2));
				if (num12 != 0.0)
				{
					num7 = num6 * 100.0 / num12;
				}
			}
			msgContent = TR.Value("adventure_team_pass_bless_button_tips", num, (int)(level + num2), num7);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, new UnityAction(this.OnExpRewardBtnClick), null, 0f, false);
		}

		// Token: 0x0600C7E8 RID: 51176 RVA: 0x00306BF0 File Offset: 0x00304FF0
		private void OnExpRewardBtnClick()
		{
			if (this.mExpBtnCD != null && this.mExpBtnCD.IsBtnWork())
			{
				DataManager<AdventureTeamDataManager>.GetInstance().ReqUsePassBlessExp();
				if (this.mBuryPoint != null)
				{
					this.mBuryPoint.OnSendBuryingPoint();
				}
			}
		}

		// Token: 0x0600C7E9 RID: 51177 RVA: 0x00306C44 File Offset: 0x00305044
		private void _InitEffectView()
		{
			if (this.mExpPoolEffectBind != null)
			{
				this.mExpPoolEffectBind.InitExpPoolIdleEffect();
				this.mExpPoolEffectBind.InitExpPoolFullFlyingEffect();
				this.mExpPoolEffectBind.InitExpPoolFillupEffect();
				this.mExpPoolEffectBind.InitExpPoolRiseupEffect();
			}
		}

		// Token: 0x0600C7EA RID: 51178 RVA: 0x00306C84 File Offset: 0x00305084
		private void _InitEffectHandler()
		{
			if (this.mExpPoolEffectBind != null)
			{
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind.ExpRiseupToFullHandler = (Action)Delegate.Combine(adventureTeamPassBlessExpPoolBind.ExpRiseupToFullHandler, new Action(this._OnExpRiseUpToFull));
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind2 = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind2.ExpFlyToTargetHandler = (Action)Delegate.Combine(adventureTeamPassBlessExpPoolBind2.ExpFlyToTargetHandler, new Action(this._OnExpFlyToTarget));
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind3 = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind3.ExpRiseupStartHandler = (Action)Delegate.Combine(adventureTeamPassBlessExpPoolBind3.ExpRiseupStartHandler, new Action(this._OnExpStartRiseup));
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind4 = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind4.ExpRiseupEndHandler = (Action)Delegate.Combine(adventureTeamPassBlessExpPoolBind4.ExpRiseupEndHandler, new Action(this._OnExpEndRiseUp));
			}
		}

		// Token: 0x0600C7EB RID: 51179 RVA: 0x00306D40 File Offset: 0x00305140
		private void _UnInitEffectHandler()
		{
			if (this.mExpPoolEffectBind != null)
			{
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind.ExpRiseupToFullHandler = (Action)Delegate.Remove(adventureTeamPassBlessExpPoolBind.ExpRiseupToFullHandler, new Action(this._OnExpRiseUpToFull));
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind2 = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind2.ExpFlyToTargetHandler = (Action)Delegate.Remove(adventureTeamPassBlessExpPoolBind2.ExpFlyToTargetHandler, new Action(this._OnExpFlyToTarget));
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind3 = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind3.ExpRiseupStartHandler = (Action)Delegate.Remove(adventureTeamPassBlessExpPoolBind3.ExpRiseupStartHandler, new Action(this._OnExpStartRiseup));
				AdventureTeamPassBlessExpPoolBind adventureTeamPassBlessExpPoolBind4 = this.mExpPoolEffectBind;
				adventureTeamPassBlessExpPoolBind4.ExpRiseupEndHandler = (Action)Delegate.Remove(adventureTeamPassBlessExpPoolBind4.ExpRiseupEndHandler, new Action(this._OnExpEndRiseUp));
			}
		}

		// Token: 0x0600C7EC RID: 51180 RVA: 0x00306DFC File Offset: 0x003051FC
		private void _RefreshEffectView()
		{
			InheritBlessModel uiTempInheritBlessModel = DataManager<AdventureTeamDataManager>.GetInstance().UiTempInheritBlessModel;
			InheritExpModel uiTempInheritExpModel = DataManager<AdventureTeamDataManager>.GetInstance().UiTempInheritExpModel;
			ulong num = 0UL;
			if (uiTempInheritBlessModel != null)
			{
				int ownInheritBlessNum = (int)uiTempInheritBlessModel.ownInheritBlessNum;
			}
			if (uiTempInheritExpModel != null)
			{
				num = uiTempInheritExpModel.ownInheritBlessExp;
			}
			ulong num2 = 0UL;
			InheritBlessModel inheritBlessModel = DataManager<AdventureTeamDataManager>.GetInstance().InheritBlessModel;
			if (inheritBlessModel != null)
			{
				int ownInheritBlessNum2 = (int)inheritBlessModel.ownInheritBlessNum;
			}
			InheritExpModel inheritExpModel = DataManager<AdventureTeamDataManager>.GetInstance().InheritExpModel;
			if (inheritExpModel != null)
			{
				num2 = inheritExpModel.ownInheritBlessExp;
			}
			if (this.inheritBlessMaxExp == 0UL)
			{
				return;
			}
			if (uiTempInheritBlessModel == null || uiTempInheritExpModel == null)
			{
				double num3 = num2 * 100UL / this.inheritBlessMaxExp;
				this.currExpPercent = (int)num3;
				if (this.mExpPoolEffectBind != null)
				{
					this.mExpPoolEffectBind.StartExpRiseupToHeight(0, this.currExpPercent, false);
				}
			}
			else
			{
				double num4 = num * 100UL / this.inheritBlessMaxExp;
				double num5 = num2 * 100UL / this.inheritBlessMaxExp;
				this.lastExpPercent = (int)num4;
				this.currExpPercent = (int)num5;
				if (this.isSkipAnim)
				{
					if (this.mExpPoolEffectBind != null)
					{
						this.mExpPoolEffectBind.StartExpRiseupToHeight(this.lastExpPercent, this.currExpPercent, false);
					}
				}
				else
				{
					int num6 = DataManager<AdventureTeamDataManager>.GetInstance().CheckNeedFlyExpTimes();
					if (num6 > 0)
					{
						if (this.mExpPoolEffectBind != null)
						{
							this.mExpPoolEffectBind.StartExpRiseupToHeight(this.currExpPercent, 100, true);
						}
					}
					else if (this.mExpPoolEffectBind != null)
					{
						this.mExpPoolEffectBind.StartExpRiseupToHeight(this.lastExpPercent, this.currExpPercent, false);
					}
				}
			}
		}

		// Token: 0x0600C7ED RID: 51181 RVA: 0x00306FB4 File Offset: 0x003053B4
		private void _OnExpRiseUpToFull()
		{
			if (this.mExpPoolEffectBind != null && this.currEmptyExpFlyTargetBind != null)
			{
				this.mExpPoolEffectBind.SetExpPoolFillupShow(true);
				this.mExpPoolEffectBind.StartFullExpFlyingToTarget(this.currEmptyExpFlyTargetBind.GetEmptyExpFlyTarget());
			}
		}

		// Token: 0x0600C7EE RID: 51182 RVA: 0x00307008 File Offset: 0x00305408
		private void _OnExpFlyToTarget()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().AddupOneExpTempNum();
			if (this.mItemListRoot)
			{
				this.mItemListRoot.UpdateElement();
			}
			int num = DataManager<AdventureTeamDataManager>.GetInstance().CheckNeedFlyExpTimes();
			if (num > 0)
			{
				if (this.mExpPoolEffectBind != null && this.currEmptyExpFlyTargetBind != null)
				{
					this.mExpPoolEffectBind.SetExpPoolFillupShow(true);
					this.mExpPoolEffectBind.StartFullExpFlyingToTarget(this.currEmptyExpFlyTargetBind.GetEmptyExpFlyTarget());
				}
			}
			else if (this.mExpPoolEffectBind != null)
			{
				this.mExpPoolEffectBind.StartExpRiseupToHeight(0, this.currExpPercent, false);
			}
		}

		// Token: 0x0600C7EF RID: 51183 RVA: 0x003070B9 File Offset: 0x003054B9
		private void _OnExpStartRiseup()
		{
			if (this.mExpPoolEffectBind != null)
			{
				this.mExpPoolEffectBind.SetExpPoolRiseupShow(true);
			}
			this.isEffectPlaying = true;
		}

		// Token: 0x0600C7F0 RID: 51184 RVA: 0x003070DF File Offset: 0x003054DF
		private void _OnExpEndRiseUp()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ResetUiTempPassBlessModel();
			this.isEffectPlaying = false;
		}

		// Token: 0x040072DD RID: 29405
		[Header("Item")]
		[SerializeField]
		private Text mItemName;

		// Token: 0x040072DE RID: 29406
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x040072DF RID: 29407
		[SerializeField]
		private Text mItemNumCount;

		// Token: 0x040072E0 RID: 29408
		[SerializeField]
		private Text mCrystalIntroucation;

		// Token: 0x040072E1 RID: 29409
		[Header("Exp")]
		[SerializeField]
		private ComExpBar mExpSlider;

		// Token: 0x040072E2 RID: 29410
		[SerializeField]
		private Text mExpReward;

		// Token: 0x040072E3 RID: 29411
		[SerializeField]
		private Button mExpBtn;

		// Token: 0x040072E4 RID: 29412
		[SerializeField]
		private UIGray mExpBtnUIGray;

		// Token: 0x040072E5 RID: 29413
		[SerializeField]
		private SetComButtonCD mExpBtnCD;

		// Token: 0x040072E6 RID: 29414
		[SerializeField]
		private Text mExpBtnText;

		// Token: 0x040072E7 RID: 29415
		[Header("Player")]
		[SerializeField]
		private Image mPlayerIcon;

		// Token: 0x040072E8 RID: 29416
		[SerializeField]
		private Text mPlayerName;

		// Token: 0x040072E9 RID: 29417
		[SerializeField]
		private Text mPlayerLV;

		// Token: 0x040072EA RID: 29418
		[Header("Other")]
		[SerializeField]
		private ComUIListScript mItemListRoot;

		// Token: 0x040072EB RID: 29419
		[SerializeField]
		private Text mPlayerLevelNotify;

		// Token: 0x040072EC RID: 29420
		[SerializeField]
		private Text mResetTimeDesc;

		// Token: 0x040072ED RID: 29421
		[Header("Effect")]
		[SerializeField]
		private AdventureTeamPassBlessExpPoolBind mExpPoolEffectBind;

		// Token: 0x040072EE RID: 29422
		[SerializeField]
		private CommonFrameButtonBuryPoint mBuryPoint;

		// Token: 0x040072EF RID: 29423
		private int rewardMaxExp;

		// Token: 0x040072F0 RID: 29424
		private int rewardUnitExp;

		// Token: 0x040072F1 RID: 29425
		private ulong inheritBlessUnitExp;

		// Token: 0x040072F2 RID: 29426
		private ulong inheritBlessMaxExp;

		// Token: 0x040072F3 RID: 29427
		private uint passBlessItemOwnCount;

		// Token: 0x040072F4 RID: 29428
		private uint passBlessItemMaxCount;

		// Token: 0x040072F5 RID: 29429
		private string tr_pass_bless_exp_can_get_format = string.Empty;

		// Token: 0x040072F6 RID: 29430
		private string tr_pass_bless_count_format = string.Empty;

		// Token: 0x040072F7 RID: 29431
		private string tr_pass_bless_exp_accumulate_format = string.Empty;

		// Token: 0x040072F8 RID: 29432
		private string tr_pass_bless_role_level_format = string.Empty;

		// Token: 0x040072F9 RID: 29433
		private string tr_pass_bless_get_exp_level_info = string.Empty;

		// Token: 0x040072FA RID: 29434
		private string tr_pass_bless_reset_time_desc = string.Empty;

		// Token: 0x040072FB RID: 29435
		private string tr_pass_bless_exp_btn_desc_get_one = string.Empty;

		// Token: 0x040072FC RID: 29436
		private string tr_pass_bless_exp_btn_desc_get_oneten = string.Empty;

		// Token: 0x040072FD RID: 29437
		private string tr_pass_bless_exp_btn_desc_get_some = string.Empty;

		// Token: 0x040072FE RID: 29438
		private string tr_pass_bless_exp_btn_is_playing_anim = string.Empty;

		// Token: 0x040072FF RID: 29439
		private int currEmptyExpFlyTargetIndex;

		// Token: 0x04007300 RID: 29440
		private AdventureTeamPassBlessExpPotionBind currEmptyExpFlyTargetBind;

		// Token: 0x04007301 RID: 29441
		private int lastExpPercent;

		// Token: 0x04007302 RID: 29442
		private int currExpPercent;

		// Token: 0x04007303 RID: 29443
		private bool isEffectPlaying;

		// Token: 0x04007304 RID: 29444
		private bool isSkipAnim;
	}
}
