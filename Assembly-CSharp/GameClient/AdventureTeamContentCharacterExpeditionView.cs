using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200140B RID: 5131
	public class AdventureTeamContentCharacterExpeditionView : AdventureTeamContentBaseView
	{
		// Token: 0x0600C6A6 RID: 50854 RVA: 0x002FF490 File Offset: 0x002FD890
		private void Awake()
		{
			this._InitTR();
			this.BindEvents();
			this._bindEvents();
			this._InitTimeToggleScrollListBind();
			this._InitMiniMapToggleScrollListBind();
			this._InitRewardScrollListBind();
			this._InitCharacterSelectScrollListBind();
		}

		// Token: 0x0600C6A7 RID: 50855 RVA: 0x002FF4BC File Offset: 0x002FD8BC
		private void OnDestroy()
		{
			this._ClearTR();
			this._unBindEvents();
			this.UnBindEvents();
			this.mExpeditionMiniMaps = null;
			this.mExpeditionTimeList = null;
			this.mMiniMapToggleRoot.UnInitialize();
			this.mTimeToggleRoot.UnInitialize();
			this.mCharacterSelectScrollList.UnInitialize();
			this.mRewardScrollList.UnInitialize();
			this.rewardCount = 0;
			this.ResetMapId();
			this.thisButtonTypeName = string.Empty;
			this.tempMemBer = null;
			this.hasTriedShowExpeditionResultFrame = false;
			this.hasTriedShowExpeditionOnekeyFrame = false;
			this.lastRewardReqExpeditionMapId = 0;
		}

		// Token: 0x0600C6A8 RID: 50856 RVA: 0x002FF549 File Offset: 0x002FD949
		private void BindEvents()
		{
		}

		// Token: 0x0600C6A9 RID: 50857 RVA: 0x002FF54B File Offset: 0x002FD94B
		private void UnBindEvents()
		{
			this.mExpeditionButton.onClick.RemoveAllListeners();
		}

		// Token: 0x0600C6AA RID: 50858 RVA: 0x002FF560 File Offset: 0x002FD960
		private void _InitTR()
		{
			this.tr_expedition_btn_dispatch = TR.Value("adventure_team_expedition_dispatch");
			this.tr_expedition_btn_cancel = TR.Value("adventure_team_expedition_cancel");
			this.tr_expedition_btn_get_reward = TR.Value("adventure_team_expedition_get_reward");
			this.tr_expedition_map_role_level_limit = TR.Value("adventure_team_expedition_map_role_level_limit");
			this.tr_expedition_timer_finish = TR.Value("adventure_team_expedition_timer_finish");
			this.tr_expedition_timer_tips = TR.Value("adventure_team_expedition_timer_tips");
			this.tr_expedition_dispatch_tips = TR.Value("adventure_team_expeidtion_dispatch_tips");
			this.tr_expeidtion_cancel_tips = TR.Value("adventure_team_expeidtion_cancel_tips");
			this.tr_expedition_no_roles_tips = TR.Value("adventure_team_expedition_no_roles_tips");
		}

		// Token: 0x0600C6AB RID: 50859 RVA: 0x002FF600 File Offset: 0x002FDA00
		private void _ClearTR()
		{
			this.tr_expedition_btn_dispatch = string.Empty;
			this.tr_expedition_btn_cancel = string.Empty;
			this.tr_expedition_btn_get_reward = string.Empty;
			this.tr_expedition_map_role_level_limit = string.Empty;
			this.tr_expedition_timer_finish = string.Empty;
			this.tr_expedition_timer_tips = string.Empty;
			this.tr_expedition_dispatch_tips = string.Empty;
			this.tr_expeidtion_cancel_tips = string.Empty;
			this.tr_expedition_no_roles_tips = string.Empty;
		}

		// Token: 0x0600C6AC RID: 50860 RVA: 0x002FF670 File Offset: 0x002FDA70
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionMapInfoChanged, new ClientEventSystem.UIEventHandler(this._MapNetInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionRolesChanged, new ClientEventSystem.UIEventHandler(this._OnCharacterChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionMiniMapChanged, new ClientEventSystem.UIEventHandler(this._ExpeditionMiniMapInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionRolesSelected, new ClientEventSystem.UIEventHandler(this._OnExpeditionCharacterSelectFrameChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionDispatch, new ClientEventSystem.UIEventHandler(this._OnExpeditionDispatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeddtionCancel, new ClientEventSystem.UIEventHandler(this._OnExpeditionCancel));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionGetReward, new ClientEventSystem.UIEventHandler(this._OnExpeditionGetReward));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionTimeChanged, new ClientEventSystem.UIEventHandler(this._OnExpeditionTimeChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionIDChanged, new ClientEventSystem.UIEventHandler(this._OnExpeditionMapIdChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionTimerFinish, new ClientEventSystem.UIEventHandler(this._OnGetExpeditionFinishMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionResultFrameClose, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamExpeditionResultFrameClose));
		}

		// Token: 0x0600C6AD RID: 50861 RVA: 0x002FF7A8 File Offset: 0x002FDBA8
		private void _unBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionMapInfoChanged, new ClientEventSystem.UIEventHandler(this._MapNetInfoChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionRolesChanged, new ClientEventSystem.UIEventHandler(this._OnCharacterChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionMiniMapChanged, new ClientEventSystem.UIEventHandler(this._ExpeditionMiniMapInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionRolesSelected, new ClientEventSystem.UIEventHandler(this._OnExpeditionCharacterSelectFrameChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionDispatch, new ClientEventSystem.UIEventHandler(this._OnExpeditionDispatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeddtionCancel, new ClientEventSystem.UIEventHandler(this._OnExpeditionCancel));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionGetReward, new ClientEventSystem.UIEventHandler(this._OnExpeditionGetReward));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionTimeChanged, new ClientEventSystem.UIEventHandler(this._OnExpeditionTimeChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionIDChanged, new ClientEventSystem.UIEventHandler(this._OnExpeditionMapIdChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionTimerFinish, new ClientEventSystem.UIEventHandler(this._OnGetExpeditionFinishMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamExpeditionResultFrameClose, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamExpeditionResultFrameClose));
		}

		// Token: 0x0600C6AE RID: 50862 RVA: 0x002FF8DE File Offset: 0x002FDCDE
		public override void InitData()
		{
			this.hasTriedShowExpeditionResultFrame = false;
			this.hasTriedShowExpeditionOnekeyFrame = false;
			this._UpdateExpeditionAllMapsInfo();
		}

		// Token: 0x0600C6AF RID: 50863 RVA: 0x002FF8F4 File Offset: 0x002FDCF4
		public override void OnEnableView()
		{
			this.hasTriedShowExpeditionResultFrame = false;
			this.hasTriedShowExpeditionOnekeyFrame = false;
			this._UpdateExpeditionAllMapsInfo();
		}

		// Token: 0x0600C6B0 RID: 50864 RVA: 0x002FF90C File Offset: 0x002FDD0C
		private void ResetMapId()
		{
			byte[] allExpeditionMapsId = DataManager<AdventureTeamDataManager>.GetInstance().GetAllExpeditionMapsId();
			if (allExpeditionMapsId.Length > 0)
			{
				DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId = allExpeditionMapsId[0];
			}
		}

		// Token: 0x0600C6B1 RID: 50865 RVA: 0x002FF940 File Offset: 0x002FDD40
		private void _UpdateTimerFinish()
		{
			Text component = this.mExpeditionTimer.GetComponent<Text>();
			if (component)
			{
				component.text = this.tr_expedition_timer_finish;
			}
		}

		// Token: 0x0600C6B2 RID: 50866 RVA: 0x002FF970 File Offset: 0x002FDD70
		private void _UpdateMapInfo(byte index)
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)index))
			{
				ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)index];
				if (null != this.mMapName)
				{
					this.mMapName.text = expeditionMapModel.mapName;
				}
				if (null != this.mMapLevelLimit)
				{
					this.mMapLevelLimit.text = string.Format(this.tr_expedition_map_role_level_limit, expeditionMapModel.playerLevelLimit);
				}
				if (this.mMapBackground && !string.IsNullOrEmpty(expeditionMapModel.mapImagePath))
				{
					ETCImageLoader.LoadSprite(ref this.mMapBackground, expeditionMapModel.mapImagePath, true);
				}
			}
		}

		// Token: 0x0600C6B3 RID: 50867 RVA: 0x002FFA34 File Offset: 0x002FDE34
		private void _UpdateExpeditionBtnEvent(ExpeditionStatus tempStatus)
		{
			if (this.mExpeditionButton == null)
			{
				return;
			}
			this.mExpeditionButton.enabled = true;
			Image component = this.mExpeditionButton.GetComponent<Image>();
			if (component == null)
			{
				return;
			}
			this.mExpeditionButton.onClick.RemoveAllListeners();
			switch (tempStatus)
			{
			case ExpeditionStatus.EXPEDITION_STATUS_PREPARE:
				this.mExpeditionButton.onClick.AddListener(new UnityAction(this._TryReqExpeditionStart));
				this.mExpeditionButtonText.text = this.tr_expedition_btn_dispatch;
				ETCImageLoader.LoadSprite(ref component, "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_02", true);
				this.thisButtonTypeName = "BtnGoExpedition";
				break;
			case ExpeditionStatus.EXPEDITION_STATUS_IN:
				this.mExpeditionButton.onClick.AddListener(new UnityAction(this._TryReqExpeditionCancel));
				this.mExpeditionButtonText.text = this.tr_expedition_btn_cancel;
				ETCImageLoader.LoadSprite(ref component, "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_02", true);
				this.thisButtonTypeName = "BtnCancelExpedtion";
				break;
			case ExpeditionStatus.EXPEDITION_STATUS_OVER:
				this.mExpeditionButton.onClick.AddListener(new UnityAction(this._TryReqExpeditionFinish));
				this.mExpeditionButtonText.text = this.tr_expedition_btn_get_reward;
				ETCImageLoader.LoadSprite(ref component, "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_01", true);
				this.thisButtonTypeName = "BtnGetRewardExpedition";
				break;
			}
		}

		// Token: 0x0600C6B4 RID: 50868 RVA: 0x002FFB88 File Offset: 0x002FDF88
		private void _StartButtonCD()
		{
			if (this.mExpeditionButton)
			{
				SetComButtonCD component = this.mExpeditionButton.gameObject.GetComponent<SetComButtonCD>();
				if (component)
				{
					component.StartBtCD();
				}
			}
		}

		// Token: 0x0600C6B5 RID: 50869 RVA: 0x002FFBC7 File Offset: 0x002FDFC7
		private void _UpdateExpeditionAllMapsInfo()
		{
			this._TryReqAllExpeditionMapInfo();
			this._TryReqGetAllExpeditionMaps();
		}

		// Token: 0x0600C6B6 RID: 50870 RVA: 0x002FFBD5 File Offset: 0x002FDFD5
		private void _UpdateExpeditionCurrentMapInfo()
		{
			this._TryReqExpeditionMapInfo(DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId);
			this._TryReqGetAllExpeditionMaps();
		}

		// Token: 0x0600C6B7 RID: 50871 RVA: 0x002FFBF4 File Offset: 0x002FDFF4
		private void _UpdateExpeditionCurrentMapInfo(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ExpeditionMapNetInfo expeditionMapNetInfo = uiEvent.Param1 as ExpeditionMapNetInfo;
			if (expeditionMapNetInfo != null && DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo != null && expeditionMapNetInfo.mapId == DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId)
			{
				this._TryReqExpeditionMapInfo(expeditionMapNetInfo.mapId);
			}
			this._TryReqGetAllExpeditionMaps();
		}

		// Token: 0x0600C6B8 RID: 50872 RVA: 0x002FFC60 File Offset: 0x002FE060
		private void _InitTimeToggleScrollListBind()
		{
			this.mTimeToggleRoot.Initialize();
			this.mTimeToggleRoot.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (this.mTimeToggleGroup != null && item != null && item.m_index >= 0)
				{
					this.mTimeToggleGroup.allowSwitchOff = true;
					this._UpdateTimeToggleScrollListBind(item);
					this.mTimeToggleGroup.allowSwitchOff = false;
				}
			};
			this.mTimeToggleRoot.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (this.mTimeToggleGroup != null && item != null)
				{
					this.mTimeToggleGroup.allowSwitchOff = true;
					AdventureTeamExpeditionTimeToggle component = item.GetComponent<AdventureTeamExpeditionTimeToggle>();
					if (null == component)
					{
						return;
					}
					component.OnItemRecycle();
					this.mTimeToggleGroup.allowSwitchOff = false;
				}
			};
		}

		// Token: 0x0600C6B9 RID: 50873 RVA: 0x002FFC9C File Offset: 0x002FE09C
		private void _UpdateTimeToggleScrollListBind(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (!DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId))
			{
				return;
			}
			ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId];
			AdventureTeamExpeditionTimeToggle component = item.GetComponent<AdventureTeamExpeditionTimeToggle>();
			if (null == component)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.mExpeditionTimeList.Count)
			{
				return;
			}
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapStatus == ExpeditionStatus.EXPEDITION_STATUS_PREPARE)
			{
				component.InitItemView(this.mExpeditionTimeList[item.m_index], true, false);
			}
			else
			{
				component.InitItemView(this.mExpeditionTimeList[item.m_index], false, false);
			}
			if ((uint)this.mExpeditionTimeList[item.m_index] == DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.durationOfExpedition)
			{
				component.ChangeToggleState(true);
			}
			else
			{
				component.ChangeToggleState(false);
			}
			component.UpdateItemInfo();
		}

		// Token: 0x0600C6BA RID: 50874 RVA: 0x002FFDC3 File Offset: 0x002FE1C3
		private void _InitMiniMapToggleScrollListBind()
		{
			this.mMiniMapToggleRoot.Initialize();
			this.mMiniMapToggleRoot.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (this.mMiniMapToggleGroup != null && (item != null & item.m_index >= 0))
				{
					this.mMiniMapToggleGroup.allowSwitchOff = true;
					this._UpdateMiniMapToggleScrollListBind(item);
					this.mMiniMapToggleGroup.allowSwitchOff = false;
				}
			};
			this.mMiniMapToggleRoot.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (this.mMiniMapToggleGroup != null && item != null)
				{
					this.mMiniMapToggleGroup.allowSwitchOff = true;
					AdventureTeamExpeditionMinimapToggle component = item.GetComponent<AdventureTeamExpeditionMinimapToggle>();
					if (null == component)
					{
						return;
					}
					component.OnItemRecycle();
					this.mMiniMapToggleGroup.allowSwitchOff = false;
				}
			};
		}

		// Token: 0x0600C6BB RID: 50875 RVA: 0x002FFE00 File Offset: 0x002FE200
		private void _UpdateMiniMapToggleScrollListBind(ComUIListElementScript item)
		{
			AdventureTeamExpeditionMinimapToggle component = item.GetComponent<AdventureTeamExpeditionMinimapToggle>();
			if (null == component)
			{
				return;
			}
			byte[] allExpeditionMapsId = DataManager<AdventureTeamDataManager>.GetInstance().GetAllExpeditionMapsId();
			if (item.m_index < 0 || item.m_index >= allExpeditionMapsId.Length)
			{
				return;
			}
			ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)allExpeditionMapsId[item.m_index]];
			byte b = allExpeditionMapsId[item.m_index];
			ExpeditionStatus expeditionStatus = (ExpeditionStatus)this.mExpeditionMiniMaps[item.m_index].expeditionStatus;
			component.InitItemView(this.mExpeditionMiniMaps[item.m_index], b);
			if (b == DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId)
			{
				component.ChangeToggleState(true);
			}
			component.UpdateItemInfo();
		}

		// Token: 0x0600C6BC RID: 50876 RVA: 0x002FFEB8 File Offset: 0x002FE2B8
		private void _InitRewardScrollListBind()
		{
			this.mRewardScrollList.Initialize();
			this.mRewardScrollList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null && item.m_index >= 0)
				{
					this._UpdateRewardScrollListBind(item);
				}
			};
			this.mRewardScrollList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (item == null)
				{
					return;
				}
				AdventureTeamExpeditionRewardItem component = item.GetComponent<AdventureTeamExpeditionRewardItem>();
				if (component == null)
				{
					return;
				}
				component.OnItemRecycle();
			};
		}

		// Token: 0x0600C6BD RID: 50877 RVA: 0x002FFF10 File Offset: 0x002FE310
		private void _UpdateRewardScrollListBind(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionRewardItem component = item.GetComponent<AdventureTeamExpeditionRewardItem>();
			if (component == null)
			{
				return;
			}
			if (!DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId))
			{
				return;
			}
			ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId];
			if (item.m_index < 0 || item.m_index >= expeditionMapModel.rewardList.Count)
			{
				return;
			}
			ExpeditionRewardCondition rewardCondition = expeditionMapModel.rewardList[item.m_index].rewardCondition;
			component.InitItemView(item.m_index, expeditionMapModel, rewardCondition);
			if (this.isChangeMapid)
			{
				component.UpdateExpeditionMapBaseDate();
			}
			if ((DataManager<AdventureTeamDataManager>.GetInstance().IsChangeExpeditionTime && DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.durationOfExpedition != 0U) || DataManager<AdventureTeamDataManager>.GetInstance().IsChangedExpeditionMap)
			{
				component.OnExpeditionTimeChanged();
			}
			if (DataManager<AdventureTeamDataManager>.GetInstance().IsChangedExpedtionRoles)
			{
				component.OnExpeditionRolesChanged();
			}
			if (component.IsReach() && (DataManager<AdventureTeamDataManager>.GetInstance().IsChangedExpedtionRoles || this.isChangeMapid || DataManager<AdventureTeamDataManager>.GetInstance().IsChangeExpeditionTime))
			{
				this.rewardCount++;
			}
		}

		// Token: 0x0600C6BE RID: 50878 RVA: 0x00300078 File Offset: 0x002FE478
		private void _InitCharacterSelectScrollListBind()
		{
			this.mCharacterSelectScrollList.Initialize();
			this.mCharacterSelectScrollList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null && item.m_index >= 0)
				{
					this._UpdateCharacterSelectScrollListBind(item);
				}
			};
			this.mCharacterSelectScrollList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (item == null)
				{
					return;
				}
				AdventureTeamExpeditionRoleSelectItem component = item.GetComponent<AdventureTeamExpeditionRoleSelectItem>();
				if (null == component)
				{
					return;
				}
				component.OnItemRecycle();
			};
		}

		// Token: 0x0600C6BF RID: 50879 RVA: 0x003000D0 File Offset: 0x002FE4D0
		private void _UpdateCharacterSelectScrollListBind(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionRoleSelectItem component = item.GetComponent<AdventureTeamExpeditionRoleSelectItem>();
			if (null == component)
			{
				return;
			}
			if (!DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId))
			{
				return;
			}
			ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId];
			if (item.m_index < 0 || item.m_index >= expeditionMapModel.rolesCapacity)
			{
				return;
			}
			if (item.m_index < DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.roles.Count)
			{
				this.tempMemBer = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.roles[item.m_index];
			}
			else
			{
				this.tempMemBer = null;
			}
			component.InitItemView(item.m_index, this.tempMemBer);
		}

		// Token: 0x0600C6C0 RID: 50880 RVA: 0x003001C6 File Offset: 0x002FE5C6
		private void _TryReqExpeditionMapInfo(byte id)
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ReqExpeditionMapInfo(id);
		}

		// Token: 0x0600C6C1 RID: 50881 RVA: 0x003001D3 File Offset: 0x002FE5D3
		private void _TryReqAllExpeditionMapInfo()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ReqExpeditionAllMapInfo();
		}

		// Token: 0x0600C6C2 RID: 50882 RVA: 0x003001DF File Offset: 0x002FE5DF
		private void _TryReqExpeditionTeamCharacterInfo()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ReqExpeditionRolesInfo();
		}

		// Token: 0x0600C6C3 RID: 50883 RVA: 0x003001EC File Offset: 0x002FE5EC
		private void _TryReqExpeditionStart()
		{
			int num = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionRoleListCount();
			if (num != 0)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(string.Format(this.tr_expedition_dispatch_tips, this.rewardCount, DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.durationOfExpedition), delegate()
				{
					DataManager<AdventureTeamDataManager>.GetInstance().ReqDispatchExpeditionTeam();
					this._SetBuryPoint();
				}, null, 0f, false);
			}
			else
			{
				DataManager<AdventureTeamDataManager>.GetInstance().TryOpenExpeditionRoleSelectFrame(this.tempMemBer);
			}
			this._StartButtonCD();
		}

		// Token: 0x0600C6C4 RID: 50884 RVA: 0x00300268 File Offset: 0x002FE668
		private void _TryReqExpeditionCancel()
		{
			Text component = this.mExpeditionTimer.GetComponent<Text>();
			string arg = string.Empty;
			if (component)
			{
				arg = component.text.Replace(this.tr_expedition_timer_tips + "\n", string.Empty);
			}
			string msgContent = string.Format(this.tr_expeidtion_cancel_tips, arg);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<AdventureTeamDataManager>.GetInstance().ReqCancelExpeditionTeam();
				this._SetBuryPoint();
			}, null, 0f, false);
			this._StartButtonCD();
		}

		// Token: 0x0600C6C5 RID: 50885 RVA: 0x003002DF File Offset: 0x002FE6DF
		private void _TryReqExpeditionFinish()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ReqGetExpeditionRewards();
			this._StartButtonCD();
			this._SetBuryPoint();
		}

		// Token: 0x0600C6C6 RID: 50886 RVA: 0x003002F7 File Offset: 0x002FE6F7
		private void _TryReqGetAllExpeditionMaps()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ReqGetAllExpeditionMaps();
		}

		// Token: 0x0600C6C7 RID: 50887 RVA: 0x00300304 File Offset: 0x002FE704
		private void _MapNetInfoChanged(UIEvent ui)
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId))
			{
				ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId];
				if (this.mRewardScrollList != null)
				{
					this.rewardCount = 0;
					this.mRewardScrollList.SetElementAmount(expeditionMapModel.rewardList.Count);
				}
				if (this.mCharacterSelectScrollList != null)
				{
					this.mCharacterSelectScrollList.SetElementAmount(expeditionMapModel.rolesCapacity);
				}
				DataManager<AdventureTeamDataManager>.GetInstance().IsChangedExpedtionRoles = false;
				if (this.mExpeditionTimeList != null)
				{
					this.mExpeditionTimeList.Clear();
					string[] array = expeditionMapModel.expeditionTime.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						int value = 1;
						if (int.TryParse(array[i], out value))
						{
							this.mExpeditionTimeList.Add(BitConverter.GetBytes(value)[0]);
						}
					}
					if (this.mTimeToggleRoot != null)
					{
						this.mTimeToggleRoot.SetElementAmount(this.mExpeditionTimeList.Count);
					}
				}
				if (this.mExpeditionTimer != null)
				{
					AdventureTeamExpeditionTimer component = this.mExpeditionTimer.GetComponent<AdventureTeamExpeditionTimer>();
					switch (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapStatus)
					{
					case ExpeditionStatus.EXPEDITION_STATUS_PREPARE:
						this.mExpeditionTimer.SetActive(false);
						break;
					case ExpeditionStatus.EXPEDITION_STATUS_IN:
						this.mExpeditionTimer.SetActive(true);
						if (component)
						{
							uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
							double num = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.endTimeOfExpedition - serverTime;
							component.SetCountdown((int)num);
							component.StartTimer();
						}
						break;
					case ExpeditionStatus.EXPEDITION_STATUS_OVER:
						this.mExpeditionTimer.SetActive(true);
						if (component)
						{
							component.StopTimer();
						}
						this._UpdateTimerFinish();
						break;
					}
				}
			}
		}

		// Token: 0x0600C6C8 RID: 50888 RVA: 0x0030051C File Offset: 0x002FE91C
		private void _OnCharacterChanged(UIEvent ui)
		{
			if (!this.hasTriedShowExpeditionOnekeyFrame)
			{
				List<ExpeditionMapModel> readyExpeditionMapModels = DataManager<AdventureTeamDataManager>.GetInstance().GetReadyExpeditionMapModels();
				if (readyExpeditionMapModels != null && readyExpeditionMapModels.Count > 0)
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamExpeditionCharacterSelectFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdventureTeamExpeditionCharacterSelectFrame>(null, false);
					}
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamExpeditionOnekeyFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventureTeamExpeditionOnekeyFrame>(FrameLayer.Middle, readyExpeditionMapModels, string.Empty);
					}
				}
				this.hasTriedShowExpeditionOnekeyFrame = true;
			}
			else if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamExpeditionCharacterSelectFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventureTeamExpeditionCharacterSelectFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600C6C9 RID: 50889 RVA: 0x003005C0 File Offset: 0x002FE9C0
		private void _ExpeditionMiniMapInfo(UIEvent ui)
		{
			this.mExpeditionMiniMaps = (ui.Param1 as ExpeditionMapBaseInfo[]);
			if (this.mExpeditionMiniMaps != null)
			{
				if (this.mMiniMapToggleRoot != null)
				{
					this.mMiniMapToggleRoot.SetElementAmount(DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.Count);
				}
				if (this.mExpeditionMiniMaps != null)
				{
					for (int i = 0; i < this.mExpeditionMiniMaps.Length; i++)
					{
						if (this.mExpeditionMiniMaps[i].mapId == DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId)
						{
							this._UpdateExpeditionBtnEvent((ExpeditionStatus)this.mExpeditionMiniMaps[i].expeditionStatus);
						}
						if (this.mExpeditionMiniMaps[i].mapId == this.lastRewardReqExpeditionMapId && !this.hasTriedShowExpeditionOnekeyFrame)
						{
							this._TryReqExpeditionTeamCharacterInfo();
							this.lastRewardReqExpeditionMapId = 0;
						}
					}
				}
			}
			if (!this.hasTriedShowExpeditionResultFrame)
			{
				List<ExpeditionMapModel> finishedExpeditionMapModels = DataManager<AdventureTeamDataManager>.GetInstance().GetFinishedExpeditionMapModels();
				if (finishedExpeditionMapModels != null && finishedExpeditionMapModels.Count > 0)
				{
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AdventureTeamExpeditionResultFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdventureTeamExpeditionResultFrame>(FrameLayer.Middle, finishedExpeditionMapModels, string.Empty);
					}
				}
				else
				{
					this._TryReqExpeditionTeamCharacterInfo();
				}
				this.hasTriedShowExpeditionResultFrame = true;
			}
		}

		// Token: 0x0600C6CA RID: 50890 RVA: 0x00300700 File Offset: 0x002FEB00
		private void _OnExpeditionCharacterSelectFrameChanged(UIEvent ui)
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId))
			{
				ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId];
				if (this.mRewardScrollList != null)
				{
					this.rewardCount = 0;
					this.mRewardScrollList.SetElementAmount(expeditionMapModel.rewardList.Count);
				}
				if (this.mCharacterSelectScrollList != null)
				{
					this.mCharacterSelectScrollList.SetElementAmount(expeditionMapModel.rolesCapacity);
				}
				DataManager<AdventureTeamDataManager>.GetInstance().IsChangedExpedtionRoles = false;
			}
		}

		// Token: 0x0600C6CB RID: 50891 RVA: 0x003007B4 File Offset: 0x002FEBB4
		private void _OnExpeditionDispatch(UIEvent ui)
		{
			this._UpdateExpeditionCurrentMapInfo(ui);
		}

		// Token: 0x0600C6CC RID: 50892 RVA: 0x003007BD File Offset: 0x002FEBBD
		private void _OnExpeditionCancel(UIEvent ui)
		{
			this._UpdateExpeditionCurrentMapInfo(ui);
		}

		// Token: 0x0600C6CD RID: 50893 RVA: 0x003007C6 File Offset: 0x002FEBC6
		private void _OnExpeditionGetReward(UIEvent ui)
		{
			this._UpdateExpeditionCurrentMapInfo(ui);
		}

		// Token: 0x0600C6CE RID: 50894 RVA: 0x003007D0 File Offset: 0x002FEBD0
		private void _OnExpeditionTimeChanged(UIEvent ui)
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId))
			{
				ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId];
				if (this.mRewardScrollList != null)
				{
					this.rewardCount = 0;
					this.mRewardScrollList.SetElementAmount(expeditionMapModel.rewardList.Count);
				}
				DataManager<AdventureTeamDataManager>.GetInstance().IsChangeExpeditionTime = false;
			}
		}

		// Token: 0x0600C6CF RID: 50895 RVA: 0x00300864 File Offset: 0x002FEC64
		private void _OnExpeditionMapIdChange(UIEvent ui)
		{
			this._UpdateMapInfo(DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId);
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId))
			{
				ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId];
				this.isChangeMapid = true;
				if (this.mRewardScrollList != null)
				{
					this.rewardCount = 0;
					this.mRewardScrollList.SetElementAmount(expeditionMapModel.rewardList.Count);
				}
				this.isChangeMapid = false;
			}
			if (this.mExpeditionMiniMaps != null)
			{
				for (int i = 0; i < this.mExpeditionMiniMaps.Length; i++)
				{
					if (this.mExpeditionMiniMaps[i].mapId == DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.mapId)
					{
						this._UpdateExpeditionBtnEvent((ExpeditionStatus)this.mExpeditionMiniMaps[i].expeditionStatus);
					}
				}
			}
		}

		// Token: 0x0600C6D0 RID: 50896 RVA: 0x00300966 File Offset: 0x002FED66
		private void _OnGetExpeditionFinishMessage(UIEvent ui)
		{
			this._UpdateExpeditionCurrentMapInfo();
		}

		// Token: 0x0600C6D1 RID: 50897 RVA: 0x00300970 File Offset: 0x002FED70
		private void _OnAdventureTeamExpeditionResultFrameClose(UIEvent uiEvent)
		{
			if (uiEvent != null && uiEvent.Param1 != null)
			{
				ExpeditionMapNetInfo expeditionMapNetInfo = uiEvent.Param1 as ExpeditionMapNetInfo;
				if (expeditionMapNetInfo != null)
				{
					this.lastRewardReqExpeditionMapId = expeditionMapNetInfo.mapId;
				}
			}
			else
			{
				this._TryReqExpeditionTeamCharacterInfo();
			}
		}

		// Token: 0x0600C6D2 RID: 50898 RVA: 0x003009B7 File Offset: 0x002FEDB7
		private void _SetBuryPoint()
		{
			if (this.mBuryPoint)
			{
				this.mBuryPoint.ButtonName = this.thisButtonTypeName;
				this.mBuryPoint.OnSendBuryingPoint();
			}
		}

		// Token: 0x040071F9 RID: 29177
		[SerializeField]
		private Button mExpeditionButton;

		// Token: 0x040071FA RID: 29178
		[SerializeField]
		private ComUIListScript mTimeToggleRoot;

		// Token: 0x040071FB RID: 29179
		[SerializeField]
		private Image mMapBackground;

		// Token: 0x040071FC RID: 29180
		[SerializeField]
		private Text mMapName;

		// Token: 0x040071FD RID: 29181
		[SerializeField]
		private Text mMapLevelLimit;

		// Token: 0x040071FE RID: 29182
		[SerializeField]
		private ComUIListScript mMiniMapToggleRoot;

		// Token: 0x040071FF RID: 29183
		[SerializeField]
		private ComUIListScript mRewardScrollList;

		// Token: 0x04007200 RID: 29184
		[SerializeField]
		private GameObject mRoleUnitRoot;

		// Token: 0x04007201 RID: 29185
		[SerializeField]
		private Text mExpeditionButtonText;

		// Token: 0x04007202 RID: 29186
		[SerializeField]
		private ComUIListScript mCharacterSelectScrollList;

		// Token: 0x04007203 RID: 29187
		[SerializeField]
		private GameObject mExpeditionTimer;

		// Token: 0x04007204 RID: 29188
		[SerializeField]
		private ToggleGroup mTimeToggleGroup;

		// Token: 0x04007205 RID: 29189
		[SerializeField]
		private ToggleGroup mMiniMapToggleGroup;

		// Token: 0x04007206 RID: 29190
		[SerializeField]
		private CommonFrameButtonBuryPoint mBuryPoint;

		// Token: 0x04007207 RID: 29191
		private string thisButtonTypeName = string.Empty;

		// Token: 0x04007208 RID: 29192
		private string tr_expedition_btn_dispatch = string.Empty;

		// Token: 0x04007209 RID: 29193
		private string tr_expedition_btn_cancel = string.Empty;

		// Token: 0x0400720A RID: 29194
		private string tr_expedition_btn_get_reward = string.Empty;

		// Token: 0x0400720B RID: 29195
		private string tr_expedition_map_role_level_limit = string.Empty;

		// Token: 0x0400720C RID: 29196
		private string tr_expedition_timer_finish = string.Empty;

		// Token: 0x0400720D RID: 29197
		private string tr_expedition_timer_tips = string.Empty;

		// Token: 0x0400720E RID: 29198
		private string tr_expedition_dispatch_tips = string.Empty;

		// Token: 0x0400720F RID: 29199
		private string tr_expeidtion_cancel_tips = string.Empty;

		// Token: 0x04007210 RID: 29200
		private string tr_expedition_no_roles_tips = string.Empty;

		// Token: 0x04007211 RID: 29201
		private ExpeditionMapBaseInfo[] mExpeditionMiniMaps;

		// Token: 0x04007212 RID: 29202
		private List<byte> mExpeditionTimeList = new List<byte>();

		// Token: 0x04007213 RID: 29203
		private bool isChangeMapid;

		// Token: 0x04007214 RID: 29204
		private int rewardCount;

		// Token: 0x04007215 RID: 29205
		private ExpeditionMemberInfo tempMemBer;

		// Token: 0x04007216 RID: 29206
		private bool hasTriedShowExpeditionResultFrame;

		// Token: 0x04007217 RID: 29207
		private bool hasTriedShowExpeditionOnekeyFrame;

		// Token: 0x04007218 RID: 29208
		private byte lastRewardReqExpeditionMapId;

		// Token: 0x04007219 RID: 29209
		private const string Yello_Btn_Path = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_01";

		// Token: 0x0400721A RID: 29210
		private const string Blue_Btn_Path = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_02";
	}
}
