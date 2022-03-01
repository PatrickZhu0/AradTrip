using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200171A RID: 5914
	public class LegendMissionItemNew : MonoBehaviour
	{
		// Token: 0x0600E862 RID: 59490 RVA: 0x003D6F1E File Offset: 0x003D531E
		private void Start()
		{
			if (this.exchangeButton != null)
			{
				this.exchangeButton.onClick.RemoveAllListeners();
				this.exchangeButton.onClick.AddListener(new UnityAction(this.OnExChangeButtonClick));
			}
		}

		// Token: 0x0600E863 RID: 59491 RVA: 0x003D6F60 File Offset: 0x003D5360
		private void OnDestroy()
		{
			if (this.exchangeButton != null)
			{
				this.exchangeButton.onClick.RemoveAllListeners();
			}
			if (null != this._comItem)
			{
				ComItemManager.Destroy(this._comItem);
				this._comItem = null;
			}
		}

		// Token: 0x0600E864 RID: 59492 RVA: 0x003D6FB1 File Offset: 0x003D53B1
		public void Init(MissionManager.SingleMissionInfo singleMissionInfo)
		{
			this._singleMissionInfo = singleMissionInfo;
			this._taskId = singleMissionInfo.taskID;
		}

		// Token: 0x0600E865 RID: 59493 RVA: 0x003D6FC6 File Offset: 0x003D53C6
		private void OnEnable()
		{
			this.BindEvents();
			this.OnUpdateData();
		}

		// Token: 0x0600E866 RID: 59494 RVA: 0x003D6FD4 File Offset: 0x003D53D4
		private void OnDisable()
		{
			this.UnBindEvents();
		}

		// Token: 0x0600E867 RID: 59495 RVA: 0x003D6FDC File Offset: 0x003D53DC
		private void BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MissionSync, new ClientEventSystem.UIEventHandler(this.OnMissionSync));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this.OnMissionUpdate));
		}

		// Token: 0x0600E868 RID: 59496 RVA: 0x003D7014 File Offset: 0x003D5414
		private void UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MissionSync, new ClientEventSystem.UIEventHandler(this.OnMissionSync));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MissionUpdated, new ClientEventSystem.UIEventHandler(this.OnMissionUpdate));
		}

		// Token: 0x0600E869 RID: 59497 RVA: 0x003D704C File Offset: 0x003D544C
		private void OnMissionUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (num != this._taskId)
			{
				return;
			}
			this.OnUpdateData();
		}

		// Token: 0x0600E86A RID: 59498 RVA: 0x003D7080 File Offset: 0x003D5480
		private void OnMissionSync(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (num != this._taskId)
			{
				return;
			}
			this.OnUpdateData();
		}

		// Token: 0x0600E86B RID: 59499 RVA: 0x003D70B3 File Offset: 0x003D54B3
		private void OnUpdateData()
		{
			this._singleMissionInfo = DataManager<MissionManager>.GetInstance().GetMission(this._taskId);
			if (this._singleMissionInfo == null)
			{
				return;
			}
			this.UpdateMissionTitle();
			this.UpdateMissionItemContent();
			this.UpdateMissionStatus();
		}

		// Token: 0x0600E86C RID: 59500 RVA: 0x003D70EC File Offset: 0x003D54EC
		private void UpdateMissionTitle()
		{
			if (this._singleMissionInfo.missionItem == null)
			{
				return;
			}
			int maxSubmitCount = this._singleMissionInfo.missionItem.MaxSubmitCount;
			byte submitCount = this._singleMissionInfo.submitCount;
			this.titleText.text = string.Format(this._singleMissionInfo.missionItem.TaskInitText, submitCount, maxSubmitCount);
		}

		// Token: 0x0600E86D RID: 59501 RVA: 0x003D7154 File Offset: 0x003D5554
		private void UpdateMissionStatus()
		{
			if (this._singleMissionInfo.status == 2)
			{
				this.unfinish.CustomActive(false);
				this.taskOver.CustomActive(false);
				this.exchangeButton.CustomActive(true);
			}
			else if (this._singleMissionInfo.status == 5)
			{
				this.unfinish.CustomActive(false);
				this.taskOver.CustomActive(true);
				this.exchangeButton.CustomActive(false);
			}
			else
			{
				this.unfinish.CustomActive(true);
				this.taskOver.CustomActive(false);
				this.exchangeButton.CustomActive(false);
			}
		}

		// Token: 0x0600E86E RID: 59502 RVA: 0x003D71FC File Offset: 0x003D55FC
		private void UpdateMissionItemContent()
		{
			if (this._singleMissionInfo.missionItem == null)
			{
				return;
			}
			this.SetMissionAwardItem();
			List<ComLegendMaterialItemData> list = new List<ComLegendMaterialItemData>();
			List<ItemData> missionMaterialList = DataManager<MissionManager>.GetInstance().GetMissionMaterials(this._singleMissionInfo.missionItem.ID);
			if (missionMaterialList != null)
			{
				int i;
				for (i = 0; i < missionMaterialList.Count; i++)
				{
					MissionManager.ParseObject parseObject = MissionManager.Parse(this._singleMissionInfo.missionItem.MissionMaterialsKeyValue[i], (MissionManager.MaterialMatchInfo matchInfo) => MissionManager._TokenMaterials(this._singleMissionInfo.missionItem.ID, missionMaterialList[i], matchInfo));
					list.Add(new ComLegendMaterialItemData
					{
						itemData = missionMaterialList[i],
						parseObject = parseObject
					});
				}
			}
			this.SetMissionMaterialItems(list);
		}

		// Token: 0x0600E86F RID: 59503 RVA: 0x003D7300 File Offset: 0x003D5700
		private void SetMissionAwardItem()
		{
			List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(this._singleMissionInfo.missionItem.ID, -1);
			if (missionAwards != null && missionAwards.Count > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(missionAwards[0].ID, 100, 0);
				if (itemData != null)
				{
					itemData.Count = missionAwards[0].Num;
				}
				if (this.goItemParent == null)
				{
					return;
				}
				if (null == this._comItem)
				{
					this._comItem = ComItemManager.Create(this.goItemParent);
				}
				if (null != this._comItem)
				{
					this._comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
				}
			}
		}

		// Token: 0x0600E870 RID: 59504 RVA: 0x003D73E0 File Offset: 0x003D57E0
		public void SetMissionMaterialItems(List<ComLegendMaterialItemData> datas)
		{
			if (null != this.goMaterialPrefab && null != this.goMaterialParent)
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

		// Token: 0x0600E871 RID: 59505 RVA: 0x003D74CC File Offset: 0x003D58CC
		private void OnExChangeButtonClick()
		{
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(this._taskId, TaskSubmitType.TASK_SUBMIT_AUTO, 0U);
		}

		// Token: 0x04008CE2 RID: 36066
		private MissionManager.SingleMissionInfo _singleMissionInfo;

		// Token: 0x04008CE3 RID: 36067
		private uint _taskId;

		// Token: 0x04008CE4 RID: 36068
		private List<ComLegendMaterialItem> materials = new List<ComLegendMaterialItem>();

		// Token: 0x04008CE5 RID: 36069
		private ComItem _comItem;

		// Token: 0x04008CE6 RID: 36070
		[SerializeField]
		private GameObject goItemParent;

		// Token: 0x04008CE7 RID: 36071
		[SerializeField]
		private GameObject goMaterialPrefab;

		// Token: 0x04008CE8 RID: 36072
		[SerializeField]
		private GameObject goMaterialParent;

		// Token: 0x04008CE9 RID: 36073
		[SerializeField]
		private Text titleText;

		// Token: 0x04008CEA RID: 36074
		[SerializeField]
		private Button exchangeButton;

		// Token: 0x04008CEB RID: 36075
		[SerializeField]
		private GameObject unfinish;

		// Token: 0x04008CEC RID: 36076
		[SerializeField]
		private GameObject taskOver;
	}
}
