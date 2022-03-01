using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001249 RID: 4681
	public class EquipPlanDataManager : DataManager<EquipPlanDataManager>
	{
		// Token: 0x0600B3CD RID: 46029 RVA: 0x002824E3 File Offset: 0x002808E3
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600B3CE RID: 46030 RVA: 0x002824EB File Offset: 0x002808EB
		public override void Clear()
		{
			this.UnBindNetEvents();
			this.ClearData();
		}

		// Token: 0x0600B3CF RID: 46031 RVA: 0x002824F9 File Offset: 0x002808F9
		private void ClearData()
		{
			this.ResetEquipPlanDataModel();
			this._equipPlanUnLockLevel = 0;
			this.beforeDisplayAttribute = null;
			this.EquipPlanSwitchCountDownLeftTime = 0f;
			this.ResetUpdateCountDownTimeAction();
		}

		// Token: 0x0600B3D0 RID: 46032 RVA: 0x00282520 File Offset: 0x00280920
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(501087U, new Action<MsgDATA>(this.OnReceiveSceneEquipSchemeSync));
			NetProcess.AddMsgHandler(501089U, new Action<MsgDATA>(this.OnReceiveSceneEquipSchemeWearRes));
		}

		// Token: 0x0600B3D1 RID: 46033 RVA: 0x0028254E File Offset: 0x0028094E
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(501087U, new Action<MsgDATA>(this.OnReceiveSceneEquipSchemeSync));
			NetProcess.RemoveMsgHandler(501089U, new Action<MsgDATA>(this.OnReceiveSceneEquipSchemeWearRes));
		}

		// Token: 0x0600B3D2 RID: 46034 RVA: 0x0028257C File Offset: 0x0028097C
		private void OnReceiveSceneEquipSchemeSync(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneEquipSchemeSync sceneEquipSchemeSync = new SceneEquipSchemeSync();
			sceneEquipSchemeSync.decode(msgData.bytes);
			if (sceneEquipSchemeSync.schemes == null || sceneEquipSchemeSync.schemes.Length <= 0)
			{
				return;
			}
			if (this.EquipPlanDataModelList == null)
			{
				this.EquipPlanDataModelList = new List<EquipPlanDataModel>();
			}
			for (int i = 0; i < sceneEquipSchemeSync.schemes.Length; i++)
			{
				EquipSchemeInfo equipSchemeInfo = sceneEquipSchemeSync.schemes[i];
				if (equipSchemeInfo != null)
				{
					EquipPlanDataModel equipPlanDataModel = null;
					for (int j = 0; j < this.EquipPlanDataModelList.Count; j++)
					{
						EquipPlanDataModel equipPlanDataModel2 = this.EquipPlanDataModelList[j];
						if (equipPlanDataModel2 != null)
						{
							if (equipPlanDataModel2.EquipPlanId == equipSchemeInfo.id)
							{
								equipPlanDataModel = equipPlanDataModel2;
								break;
							}
						}
					}
					if (equipPlanDataModel == null)
					{
						equipPlanDataModel = EquipPlanUtility.CreateEquipPlanDataModel(equipSchemeInfo);
						this.EquipPlanDataModelList.Add(equipPlanDataModel);
					}
					else
					{
						EquipPlanUtility.UpdateEquipPlanDataModel(equipPlanDataModel, equipSchemeInfo);
					}
				}
			}
			int currentSelectedEquipPlanId = this.CurrentSelectedEquipPlanId;
			this.IsAlreadySwitchEquipPlan = false;
			this.UnSelectedEquipPlanId = 0;
			this.UnSelectedEquipPlanItemGuidList = null;
			this.CurrentSelectedEquipPlanItemGuidList = null;
			for (int k = 0; k < this.EquipPlanDataModelList.Count; k++)
			{
				EquipPlanDataModel equipPlanDataModel3 = this.EquipPlanDataModelList[k];
				if (equipPlanDataModel3 != null)
				{
					if (equipPlanDataModel3.IsWear)
					{
						this.CurrentSelectedEquipPlanId = (int)equipPlanDataModel3.EquipPlanId;
						this.CurrentSelectedEquipPlanItemGuidList = equipPlanDataModel3.EquipItemGuidList;
					}
					if (equipPlanDataModel3.EquipPlanType == EquipSchemeType.EQST_EQUIP && equipPlanDataModel3.EquipPlanId == 2U)
					{
						this.IsAlreadySwitchEquipPlan = true;
					}
					if (!equipPlanDataModel3.IsWear)
					{
						this.UnSelectedEquipPlanId = (int)equipPlanDataModel3.EquipPlanId;
						this.UnSelectedEquipPlanItemGuidList = equipPlanDataModel3.EquipItemGuidList;
					}
				}
			}
			if (currentSelectedEquipPlanId != this.CurrentSelectedEquipPlanId)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveEquipPlanSwitchMessage, null, null, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveEquipPlanSyncMessage, null, null, null, null);
		}

		// Token: 0x0600B3D3 RID: 46035 RVA: 0x0028277C File Offset: 0x00280B7C
		public void OnSendSceneEquipSchemeWearReq(int equipPlanId, bool isSync, EquipSchemeType equipSchemeType = EquipSchemeType.EQST_EQUIP)
		{
			this.beforeDisplayAttribute = BeUtility.GetMainPlayerActorAttribute(false, false);
			SceneEquipSchemeWearReq sceneEquipSchemeWearReq = new SceneEquipSchemeWearReq();
			sceneEquipSchemeWearReq.id = (uint)equipPlanId;
			sceneEquipSchemeWearReq.isSync = ((!isSync) ? 0 : 1);
			sceneEquipSchemeWearReq.type = (byte)equipSchemeType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneEquipSchemeWearReq>(ServerType.GATE_SERVER, sceneEquipSchemeWearReq);
			}
			this.EquipPlanSwitchCountDownLeftTime = 3f;
			this.DoUpdateCountDownTimeAction();
		}

		// Token: 0x0600B3D4 RID: 46036 RVA: 0x002827EC File Offset: 0x00280BEC
		private void OnReceiveSceneEquipSchemeWearRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				this.beforeDisplayAttribute = null;
				return;
			}
			SceneEquipSchemeWearRes sceneEquipSchemeWearRes = new SceneEquipSchemeWearRes();
			sceneEquipSchemeWearRes.decode(msgData.bytes);
			if (sceneEquipSchemeWearRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneEquipSchemeWearRes.code, string.Empty);
				this.beforeDisplayAttribute = null;
				return;
			}
			string equipPlanIdStr = EquipPlanUtility.GetEquipPlanIdStr(1);
			string equipPlanIdStr2 = EquipPlanUtility.GetEquipPlanIdStr(2);
			string msgContent = string.Empty;
			if (sceneEquipSchemeWearRes.id == 2U)
			{
				if (sceneEquipSchemeWearRes.isSync == 1)
				{
					msgContent = TR.Value("Equip_Plan_First_Used_Plan_Two_And_Sync_Tip", equipPlanIdStr2, equipPlanIdStr);
				}
				else
				{
					msgContent = TR.Value("Equip_Plan_Used_Plan_Tip", equipPlanIdStr2);
				}
			}
			else if (sceneEquipSchemeWearRes.id == 1U)
			{
				msgContent = TR.Value("Equip_Plan_Used_Plan_Tip", equipPlanIdStr);
			}
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			this.ShowDisplayAttributeChangeFloatingEffect();
			this.DealWithEndTimeItemList(sceneEquipSchemeWearRes.overdueIds);
		}

		// Token: 0x0600B3D5 RID: 46037 RVA: 0x002828C0 File Offset: 0x00280CC0
		private void DealWithEndTimeItemList(ulong[] overDueIds)
		{
			if (overDueIds == null || overDueIds.Length <= 0)
			{
				return;
			}
			bool flag = false;
			foreach (ulong num in overDueIds)
			{
				if (num > 0UL)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(num);
					if (item != null)
					{
						if (item.IsItemInUnUsedEquipPlan)
						{
							item.IsItemInUnUsedEquipPlan = false;
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveEquipPlanItemEndTimeMessage, null, null, null, null);
			}
		}

		// Token: 0x0600B3D6 RID: 46038 RVA: 0x00282950 File Offset: 0x00280D50
		private void ShowDisplayAttributeChangeFloatingEffect()
		{
			if (!EquipPlanUtility.IsEquipPlanOwnerDifferentItem())
			{
				this.beforeDisplayAttribute = null;
				return;
			}
			DisplayAttribute mainPlayerActorAttribute = BeUtility.GetMainPlayerActorAttribute(false, false);
			List<BetterEquipmentData> playerAttributeDisplayChangeList = ItemDataUtility.GetPlayerAttributeDisplayChangeList(this.beforeDisplayAttribute, mainPlayerActorAttribute);
			if (playerAttributeDisplayChangeList != null)
			{
				DataManager<ItemDataManager>.GetInstance().PopUpChangedAttrbutes(playerAttributeDisplayChangeList);
			}
			this.beforeDisplayAttribute = null;
		}

		// Token: 0x0600B3D7 RID: 46039 RVA: 0x002829A0 File Offset: 0x00280DA0
		private void ResetEquipPlanDataModel()
		{
			this.CurrentSelectedEquipPlanId = 0;
			this.UnSelectedEquipPlanId = 0;
			this.UnSelectedEquipPlanItemGuidList = null;
			this.CurrentSelectedEquipPlanItemGuidList = null;
			this.IsAlreadySwitchEquipPlan = false;
			if (this.EquipPlanDataModelList == null || this.EquipPlanDataModelList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.EquipPlanDataModelList.Count; i++)
			{
				EquipPlanDataModel equipPlanDataModel = this.EquipPlanDataModelList[i];
				if (equipPlanDataModel != null)
				{
					if (equipPlanDataModel.EquipItemGuidList != null && equipPlanDataModel.EquipItemGuidList.Count > 0)
					{
						equipPlanDataModel.EquipItemGuidList.Clear();
					}
				}
			}
			this.EquipPlanDataModelList.Clear();
		}

		// Token: 0x0600B3D8 RID: 46040 RVA: 0x00282A54 File Offset: 0x00280E54
		public void OnSwitchEquipPlanWithSyncFirstEquipPlan()
		{
			int switchToEquipPlanId = EquipPlanUtility.GetSwitchToEquipPlanId();
			this.OnSendSceneEquipSchemeWearReq(switchToEquipPlanId, true, EquipSchemeType.EQST_EQUIP);
		}

		// Token: 0x0600B3D9 RID: 46041 RVA: 0x00282A70 File Offset: 0x00280E70
		public void OnSwitchEquipPlanByCommonAction()
		{
			int switchToEquipPlanId = EquipPlanUtility.GetSwitchToEquipPlanId();
			this.OnSendSceneEquipSchemeWearReq(switchToEquipPlanId, false, EquipSchemeType.EQST_EQUIP);
		}

		// Token: 0x0600B3DA RID: 46042 RVA: 0x00282A8C File Offset: 0x00280E8C
		public int GetEquipPlanUnLockLevel()
		{
			if (this._equipPlanUnLockLevel > 0)
			{
				return this._equipPlanUnLockLevel;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(650, string.Empty, string.Empty);
			this._equipPlanUnLockLevel = ((tableItem != null) ? tableItem.Value : 50);
			return this._equipPlanUnLockLevel;
		}

		// Token: 0x0600B3DB RID: 46043 RVA: 0x00282AE5 File Offset: 0x00280EE5
		public void SetUpdateCountDownTimeAction(Action updateCountDownTimeAction)
		{
			this._updateCountDownTimeAction = updateCountDownTimeAction;
		}

		// Token: 0x0600B3DC RID: 46044 RVA: 0x00282AEE File Offset: 0x00280EEE
		public void ResetUpdateCountDownTimeAction()
		{
			this._updateCountDownTimeAction = null;
		}

		// Token: 0x0600B3DD RID: 46045 RVA: 0x00282AF7 File Offset: 0x00280EF7
		private void DoUpdateCountDownTimeAction()
		{
			if (this._updateCountDownTimeAction != null)
			{
				this._updateCountDownTimeAction();
			}
		}

		// Token: 0x0600B3DE RID: 46046 RVA: 0x00282B10 File Offset: 0x00280F10
		public override void Update(float time)
		{
			if (this.EquipPlanSwitchCountDownLeftTime <= 0f)
			{
				return;
			}
			this.EquipPlanSwitchCountDownLeftTime -= time;
			if (this.EquipPlanSwitchCountDownLeftTime <= 0f)
			{
				this.EquipPlanSwitchCountDownLeftTime = 0f;
			}
			this.DoUpdateCountDownTimeAction();
		}

		// Token: 0x0400656E RID: 25966
		private int _equipPlanUnLockLevel;

		// Token: 0x0400656F RID: 25967
		public int CurrentSelectedEquipPlanId;

		// Token: 0x04006570 RID: 25968
		public bool IsAlreadySwitchEquipPlan;

		// Token: 0x04006571 RID: 25969
		public int UnSelectedEquipPlanId;

		// Token: 0x04006572 RID: 25970
		public List<ulong> UnSelectedEquipPlanItemGuidList;

		// Token: 0x04006573 RID: 25971
		public List<ulong> CurrentSelectedEquipPlanItemGuidList;

		// Token: 0x04006574 RID: 25972
		public List<EquipPlanDataModel> EquipPlanDataModelList = new List<EquipPlanDataModel>();

		// Token: 0x04006575 RID: 25973
		private DisplayAttribute beforeDisplayAttribute;

		// Token: 0x04006576 RID: 25974
		public const float EquipPlanSwitchCountDownInterval = 3f;

		// Token: 0x04006577 RID: 25975
		public float EquipPlanSwitchCountDownLeftTime;

		// Token: 0x04006578 RID: 25976
		private Action _updateCountDownTimeAction;
	}
}
