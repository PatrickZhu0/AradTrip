using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200003D RID: 61
	internal class ComLegendLinkMissionItem : MonoBehaviour
	{
		// Token: 0x06000182 RID: 386 RVA: 0x0000E258 File Offset: 0x0000C658
		public void SetItems(List<ComLegendMaterialItemData> datas)
		{
			if (null != this.goMaterialPrefab)
			{
				this.goMaterialPrefab.CustomActive(false);
				for (int i = this.materials.Count; i < datas.Count; i++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.goMaterialPrefab);
					Utility.AttachTo(gameObject, this.goMaterialParent, false);
					gameObject.CustomActive(true);
					this.materials.Add(gameObject.GetComponent<ComLegendMaterialItem>());
				}
				for (int j = 0; j < this.materials.Count; j++)
				{
					this.materials[j].gameObject.CustomActive(j < datas.Count);
					if (j < datas.Count)
					{
						this.materials[j].SetItemData(datas[j]);
					}
				}
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000E334 File Offset: 0x0000C734
		private bool _CheckHasFinishAllPreMissions(MissionTable missionItem)
		{
			if (missionItem != null)
			{
				for (int i = 0; i < missionItem.PreIDs.Count; i++)
				{
					MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(missionItem.PreIDs[i], string.Empty, string.Empty);
					if (tableItem != null && tableItem.MissionOnOff != 0)
					{
						if (missionItem != tableItem)
						{
							MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)missionItem.PreIDs[i]);
							if (mission == null || mission.status != 5)
							{
								return false;
							}
						}
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000E3D4 File Offset: 0x0000C7D4
		private void _SetMainItemData()
		{
			if (null != this.missionDesc && this.missionValue != null && this.missionValue.missionItem != null)
			{
				this.missionDesc.text = this.missionValue.missionItem.TaskInitText;
			}
			List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(this.missionValue.missionItem.ID, -1);
			if (missionAwards != null && missionAwards.Count > 0)
			{
				if (this.missionValue.missionItem.MinPlayerLv > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					this.unLockHint.text = TR.Value("legend_need_lv", this.missionValue.missionItem.MinPlayerLv);
				}
				else
				{
					this.unLockHint.text = this.missionValue.missionItem.PreIDsConditionDesc;
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(missionAwards[0].ID, 100, 0);
				if (itemData != null)
				{
					itemData.Count = missionAwards[0].Num;
				}
				if (null == this.comItem)
				{
					this.comItem = ComItemManager.Create(this.goItemParent);
				}
				if (null != this.comItem)
				{
					this.comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
				}
				if (itemData != null)
				{
					this.itemName.text = itemData.GetColorName(string.Empty, false);
					this.mItemData = itemData;
				}
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000E584 File Offset: 0x0000C984
		private void _SetStaus()
		{
			switch (this.missionValue.status)
			{
			case 0:
				this.comStateController.Key = this.key_locked;
				this.comGray.enabled = true;
				return;
			case 1:
				this.comStateController.Key = this.key_unfinished;
				this.comGray.enabled = true;
				return;
			case 2:
				this.comStateController.Key = this.key_finished;
				this.comGray.enabled = false;
				return;
			case 5:
				this.comStateController.Key = this.key_acquired;
				this.comGray.enabled = false;
				return;
			}
			this.comStateController.Key = this.key_normal;
			this.comGray.enabled = false;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000E66C File Offset: 0x0000CA6C
		public void SetMissionData(MissionManager.SingleMissionInfo missionValue, int curLegendId = -1)
		{
			this.missionValue = missionValue;
			this.legendId = curLegendId;
			if (missionValue != null)
			{
				if (null != this.title)
				{
					this.title.text = missionValue.missionItem.TaskName;
				}
				this._SetMainItemData();
				List<ComLegendMaterialItemData> list = new List<ComLegendMaterialItemData>();
				List<ItemData> materials = DataManager<MissionManager>.GetInstance().GetMissionMaterials(missionValue.missionItem.ID);
				if (materials != null)
				{
					int i;
					for (i = 0; i < materials.Count; i++)
					{
						MissionManager.ParseObject parseObject = MissionManager.Parse(missionValue.missionItem.MissionMaterialsKeyValue[i], (MissionManager.MaterialMatchInfo matchInfo) => MissionManager._TokenMaterials(missionValue.missionItem.ID, materials[i], matchInfo));
						list.Add(new ComLegendMaterialItemData
						{
							itemData = materials[i],
							parseObject = parseObject
						});
					}
				}
				this.SetItems(list);
				this._SetStaus();
				this.UpdateOwnedFlag();
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000E7C4 File Offset: 0x0000CBC4
		private void UpdateOwnedFlag()
		{
			if (this.ownedFlag == null)
			{
				return;
			}
			if (this.missionValue.submitCount >= 1)
			{
				this.ownedFlag.CustomActive(true);
			}
			else
			{
				this.ownedFlag.CustomActive(false);
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000E814 File Offset: 0x0000CC14
		public void OnSubmitMission()
		{
			if (this.mItemData == null)
			{
				Logger.LogError("mItemData is null");
				return;
			}
			string contentLabel = string.Format(TR.Value("LengendceRoad_Equip_Exchange"), this.mItemData.GetColorName(string.Empty, false));
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentLabel,
				IsShowNotify = false,
				LeftButtonText = TR.Value("LengendceRoad_Equip_Exchange_Cancel"),
				RightButtonText = TR.Value("LengendceRoad_Equip_Exchange_OK"),
				OnRightButtonClickCallBack = new Action(this.OnSureClick)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000E8A8 File Offset: 0x0000CCA8
		private void OnSureClick()
		{
			if (this.missionValue == null)
			{
				return;
			}
			if (this.missionValue.status != 2)
			{
				return;
			}
			if (this.missionValue.submitCount <= 0)
			{
				this.OnSendSubmitMissionRequest();
			}
			else
			{
				SystemNotifyManager.SystemNotify(1293, new UnityAction(this.OnSendSubmitMissionRequest));
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000E905 File Offset: 0x0000CD05
		private void OnSendSubmitMissionRequest()
		{
			this.SetCdContent();
			DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(this.missionValue.taskID, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000E924 File Offset: 0x0000CD24
		private void SetCdContent()
		{
			this.isInCD = true;
			this.cdFinishedTime = Time.realtimeSinceStartup + 2f;
			this.cdLeftTimeGameObject.CustomActive(true);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000E94C File Offset: 0x0000CD4C
		private void Update()
		{
			if (this.isInCD)
			{
				this.cdLeftTime = this.cdFinishedTime - Time.realtimeSinceStartup;
				if (this.cdLeftTime > 0f)
				{
					this.cdLeftTimeLabel.text = string.Format("{0}", (int)this.cdLeftTime + 1);
					this.cdLeftTimeGameObject.CustomActive(true);
					this.receivedButton.CustomActive(false);
				}
				else
				{
					this.isInCD = false;
					this.cdLeftTime = 0f;
					this.cdLeftTimeGameObject.CustomActive(false);
					this._SetStaus();
				}
			}
		}

		// Token: 0x04000161 RID: 353
		public Text title;

		// Token: 0x04000162 RID: 354
		public Text itemName;

		// Token: 0x04000163 RID: 355
		public GameObject goItemParent;

		// Token: 0x04000164 RID: 356
		public GameObject goMaterialPrefab;

		// Token: 0x04000165 RID: 357
		public GameObject goMaterialParent;

		// Token: 0x04000166 RID: 358
		public Text unLockHint;

		// Token: 0x04000167 RID: 359
		public UIGray comGray;

		// Token: 0x04000168 RID: 360
		public StateController comStateController;

		// Token: 0x04000169 RID: 361
		public Text missionDesc;

		// Token: 0x0400016A RID: 362
		public GameObject ownedFlag;

		// Token: 0x0400016B RID: 363
		private ComItem comItem;

		// Token: 0x0400016C RID: 364
		private MissionManager.SingleMissionInfo missionValue;

		// Token: 0x0400016D RID: 365
		private int legendId = -1;

		// Token: 0x0400016E RID: 366
		private List<ComLegendMaterialItem> materials = new List<ComLegendMaterialItem>();

		// Token: 0x0400016F RID: 367
		private string key_locked = "locked";

		// Token: 0x04000170 RID: 368
		private string key_finished = "finished";

		// Token: 0x04000171 RID: 369
		private string key_acquired = "acquired";

		// Token: 0x04000172 RID: 370
		private string key_normal = "normal";

		// Token: 0x04000173 RID: 371
		private string key_unfinished = "un_finished";

		// Token: 0x04000174 RID: 372
		private bool isInCD;

		// Token: 0x04000175 RID: 373
		private const float CDTime = 2f;

		// Token: 0x04000176 RID: 374
		private float cdFinishedTime;

		// Token: 0x04000177 RID: 375
		private float cdLeftTime;

		// Token: 0x04000178 RID: 376
		public Text cdLeftTimeLabel;

		// Token: 0x04000179 RID: 377
		public GameObject cdLeftTimeGameObject;

		// Token: 0x0400017A RID: 378
		public Button receivedButton;

		// Token: 0x0400017B RID: 379
		private ItemData mItemData;
	}
}
