using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001410 RID: 5136
	public class AdventureTeamExpeditionMinimapToggle : MonoBehaviour
	{
		// Token: 0x0600C702 RID: 50946 RVA: 0x003014BE File Offset: 0x002FF8BE
		private void Awake()
		{
			this.ClearData();
		}

		// Token: 0x0600C703 RID: 50947 RVA: 0x003014C6 File Offset: 0x002FF8C6
		private void OnDestroy()
		{
			this.ClearData();
			this.mDispatchObjArray = null;
		}

		// Token: 0x0600C704 RID: 50948 RVA: 0x003014D8 File Offset: 0x002FF8D8
		public void InitItemView(ExpeditionMapBaseInfo mapBaseInfo, byte id)
		{
			this.tempMapBaseInfo = mapBaseInfo;
			this.tempMapId = id;
			this.tempStatus = (ExpeditionStatus)mapBaseInfo.expeditionStatus;
			this.mMinimapToggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnChangeMapToggleClick));
			this.isSelect = false;
			this._TrySetSendBuryPointInfo();
		}

		// Token: 0x0600C705 RID: 50949 RVA: 0x00301528 File Offset: 0x002FF928
		public void UpdateItemInfo()
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)this.tempMapId))
			{
				ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)this.tempMapId];
				if (this.mAdventureTeamLvText)
				{
					this.mAdventureTeamLvText.text = expeditionMapModel.playerLevelLimit + "级";
				}
				if (this.mMinimapImage && !string.IsNullOrEmpty(expeditionMapModel.miniMapImagePath))
				{
					ETCImageLoader.LoadSprite(ref this.mMinimapImage, expeditionMapModel.miniMapImagePath, true);
				}
				if (this.mDispatchObjArray == null)
				{
					this.mDispatchObjArray = new GameObject[expeditionMapModel.rolesCapacity];
					for (int i = 0; i < expeditionMapModel.rolesCapacity; i++)
					{
						this.mDispatchObjArray[i] = this.LoadEffect("UIFlatten/Prefabs/AdventureTeam/ExpeditionDispathcRole", this.mDispatchStateObj);
					}
				}
				if (null != this.mMinimapToggle && expeditionMapModel.playerLevelLimit <= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv)
				{
					this.mMinimapToggle.enabled = true;
					this.mIsLock = false;
					this._UpdateMiniMapState();
				}
				else if (null != this.mMinimapToggle)
				{
					this.mMinimapToggle.enabled = false;
					this.mIsLock = true;
					this._UpdateMiniMapState();
				}
				if (this.mMinimapToggle)
				{
					bool enabled = this.mMinimapToggle.enabled;
					this.mMinimapToggle.enabled = true;
					this.mMinimapToggle.enabled = enabled;
				}
			}
		}

		// Token: 0x0600C706 RID: 50950 RVA: 0x003016C0 File Offset: 0x002FFAC0
		public void ChangeToggleState(bool isOn)
		{
			this.mMinimapToggle.isOn = isOn;
		}

		// Token: 0x0600C707 RID: 50951 RVA: 0x003016D0 File Offset: 0x002FFAD0
		private void _UpdateMiniMapState()
		{
			if (this.mIsLock)
			{
				this.mAdventureTeamLvText.text = "敬请期待";
				this.mLockStateObj.SetActive(true);
				this.mGetRewardStateObj.SetActive(false);
				this.mDispatchStateObj.SetActive(false);
			}
			else
			{
				switch (this.tempStatus)
				{
				case ExpeditionStatus.EXPEDITION_STATUS_PREPARE:
					this.mLockStateObj.SetActive(false);
					this.mGetRewardStateObj.SetActive(false);
					this.mDispatchStateObj.SetActive(false);
					break;
				case ExpeditionStatus.EXPEDITION_STATUS_IN:
					this.mLockStateObj.SetActive(false);
					this.mGetRewardStateObj.SetActive(false);
					this.mDispatchStateObj.SetActive(true);
					this.SetDispatchNum((int)this.tempMapBaseInfo.memberNum);
					break;
				case ExpeditionStatus.EXPEDITION_STATUS_OVER:
					this.mLockStateObj.SetActive(false);
					this.mGetRewardStateObj.SetActive(true);
					this.mDispatchStateObj.SetActive(false);
					break;
				}
			}
		}

		// Token: 0x0600C708 RID: 50952 RVA: 0x003017D0 File Offset: 0x002FFBD0
		private void SetDispatchNum(int num)
		{
			for (int i = 0; i < this.mDispatchObjArray.Length; i++)
			{
				if (this.mDispatchObjArray[i] != null)
				{
					if (i < num)
					{
						this.mDispatchObjArray[i].SetActive(true);
					}
					else
					{
						this.mDispatchObjArray[i].SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600C709 RID: 50953 RVA: 0x00301834 File Offset: 0x002FFC34
		private void _OnChangeMapToggleClick(bool isOn)
		{
			if (isOn == this.isSelect)
			{
				return;
			}
			this.isSelect = isOn;
			if (isOn)
			{
				DataManager<AdventureTeamDataManager>.GetInstance().SetExpeditionMapId(this.tempMapId);
				DataManager<AdventureTeamDataManager>.GetInstance().ReqExpeditionMapInfo(this.tempMapId);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamExpeditionIDChanged, null, null, null, null);
				if (this.mBuryPoint != null)
				{
					this.mBuryPoint.ButtonName = this.thisToggleTypeName;
					this.mBuryPoint.OnSendBuryingPoint();
				}
			}
		}

		// Token: 0x0600C70A RID: 50954 RVA: 0x003018BC File Offset: 0x002FFCBC
		public void OnItemRecycle()
		{
			this.ClearData();
			this.mMinimapToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnChangeMapToggleClick));
			this.mLockStateObj.SetActive(false);
			this.mGetRewardStateObj.SetActive(false);
			this.mDispatchStateObj.SetActive(false);
		}

		// Token: 0x0600C70B RID: 50955 RVA: 0x0030190F File Offset: 0x002FFD0F
		private void ClearData()
		{
			this.tempMapBaseInfo = null;
			this.tempMapId = 0;
			this.tempStatus = ExpeditionStatus.EXPEDITION_STATUS_PREPARE;
			this.mIsLock = false;
			this.thisToggleTypeName = string.Empty;
		}

		// Token: 0x0600C70C RID: 50956 RVA: 0x00301938 File Offset: 0x002FFD38
		private GameObject LoadEffect(string effectPath, GameObject parent)
		{
			if (string.IsNullOrEmpty(effectPath) || null == parent)
			{
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(effectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, parent, false);
			}
			return gameObject;
		}

		// Token: 0x0600C70D RID: 50957 RVA: 0x00301984 File Offset: 0x002FFD84
		private void _TrySetSendBuryPointInfo()
		{
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo == null)
			{
				return;
			}
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic == null)
			{
				return;
			}
			if (DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic.ContainsKey((int)this.tempMapId))
			{
				ExpeditionMapModel expeditionMapModel = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapBaseInfo.expeditionMapDic[(int)this.tempMapId];
				if (expeditionMapModel != null)
				{
					this.thisToggleTypeName = string.Format("Toggle{0}", expeditionMapModel.playerLevelLimit);
				}
			}
		}

		// Token: 0x04007237 RID: 29239
		[SerializeField]
		private Text mAdventureTeamLvText;

		// Token: 0x04007238 RID: 29240
		[SerializeField]
		private Toggle mMinimapToggle;

		// Token: 0x04007239 RID: 29241
		[SerializeField]
		private Image mMinimapImage;

		// Token: 0x0400723A RID: 29242
		[SerializeField]
		private GameObject mLockStateObj;

		// Token: 0x0400723B RID: 29243
		[SerializeField]
		private GameObject mGetRewardStateObj;

		// Token: 0x0400723C RID: 29244
		[SerializeField]
		private GameObject mDispatchStateObj;

		// Token: 0x0400723D RID: 29245
		[SerializeField]
		private ExpeditionMapBaseInfo tempMapBaseInfo;

		// Token: 0x0400723E RID: 29246
		[SerializeField]
		private byte tempMapId;

		// Token: 0x0400723F RID: 29247
		[SerializeField]
		private ExpeditionStatus tempStatus;

		// Token: 0x04007240 RID: 29248
		[SerializeField]
		private CommonFrameButtonBuryPoint mBuryPoint;

		// Token: 0x04007241 RID: 29249
		private string thisToggleTypeName = string.Empty;

		// Token: 0x04007242 RID: 29250
		private GameObject[] mDispatchObjArray;

		// Token: 0x04007243 RID: 29251
		private bool mIsLock;

		// Token: 0x04007244 RID: 29252
		private const string ExpeditionDispathcRolePath = "UIFlatten/Prefabs/AdventureTeam/ExpeditionDispathcRole";

		// Token: 0x04007245 RID: 29253
		private bool isSelect;

		// Token: 0x04007246 RID: 29254
		private string tr_expedition_map_role_level_limit;
	}
}
