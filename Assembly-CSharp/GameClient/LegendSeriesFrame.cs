using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200171C RID: 5916
	public class LegendSeriesFrame : ClientFrame
	{
		// Token: 0x0600E874 RID: 59508 RVA: 0x003D757F File Offset: 0x003D597F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LegendFrame/LegendSeriesFrame";
		}

		// Token: 0x0600E875 RID: 59509 RVA: 0x003D7588 File Offset: 0x003D5988
		private void _InitMain()
		{
			if (this.data != null && this.data.mainItem != null)
			{
				Image image = Utility.FindComponent<Image>(this.frame, "BG", true);
				if (null != image && this.data.mainItem.Icons.Count >= 3)
				{
					ETCImageLoader.LoadSprite(ref image, this.data.mainItem.Icons[2], true);
				}
				Text text = Utility.FindComponent<Text>(this.frame, "Desc", true);
				if (null != text)
				{
					text.text = this.data.mainItem.Desc;
				}
				Text text2 = Utility.FindComponent<Text>(this.frame, "OpenCondition", true);
				bool flag = (int)DataManager<PlayerBaseData>.GetInstance().Level >= this.data.mainItem.UnLockLevel;
				text2.gameObject.CustomActive(!flag);
				if (!flag)
				{
					text2.text = TR.Value("legend_series_open_desc", this.data.mainItem.UnLockLevel);
				}
			}
		}

		// Token: 0x0600E876 RID: 59510 RVA: 0x003D76A8 File Offset: 0x003D5AA8
		private void _InitGuidance()
		{
			if (this.data != null && this.data.mainItem != null)
			{
				GameObject gameObject = Utility.FindChild(this.frame, "LinkItemParent/ScrollView/ViewPort/Content");
				GameObject gameObject2 = Utility.FindChild(this.frame, "LinkItemParent/ScrollView/ViewPort/Content/Prefab");
				GameObject gameObject3 = Utility.FindChild(this.frame, "LinkItemParent/ScrollView/ViewPort/Content/PrefabNew");
				gameObject2.CustomActive(false);
				if (gameObject3 != null)
				{
					gameObject3.CustomActive(false);
				}
				this.m_akLegendItems.RecycleAllObject();
				for (int i = 0; i < this.data.mainItem.LinkItems.Count; i++)
				{
					LegendTraceTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LegendTraceTable>(this.data.mainItem.LinkItems[i], string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.LinkMissionID > 0)
						{
							MissionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(tableItem.LinkMissionID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								GameObject gameObject4 = Object.Instantiate<GameObject>(gameObject3);
								Utility.AttachTo(gameObject4, gameObject, false);
								LegendMissionItemNew component = gameObject4.transform.GetComponent<LegendMissionItemNew>();
								if (component != null)
								{
									LegendMissionItemData legendMissionItemNewData = this.GetLegendMissionItemNewData(tableItem.LinkMissionID, this.data.mainItem.ID);
									component.Init(legendMissionItemNewData.missionValue);
								}
								gameObject4.CustomActive(true);
							}
						}
						else
						{
							this.m_akLegendItems.Create(new object[]
							{
								gameObject,
								gameObject2,
								new LegendItemData
								{
									methodItem = tableItem,
									bFirst = (i == 0)
								},
								false
							});
						}
					}
				}
			}
		}

		// Token: 0x0600E877 RID: 59511 RVA: 0x003D785B File Offset: 0x003D5C5B
		private void _InitLegendMissions()
		{
			this.goMissionParent = Utility.FindChild(this.frame, "LinkMissionParent/ScrollView/ViewPort/Content");
			this.goMissionPrefab = Utility.FindChild(this.frame, "LinkMissionParent/ScrollView/ViewPort/Content/Prefab");
			this.goMissionPrefab.CustomActive(false);
			this._RefreshLegendMissions();
		}

		// Token: 0x0600E878 RID: 59512 RVA: 0x003D789B File Offset: 0x003D5C9B
		private void _UnInitLegendMissions()
		{
			this.goMissionParent = null;
			this.goMissionPrefab = null;
			this.m_akLegendMissionItems.DestroyAllObjects();
		}

		// Token: 0x0600E879 RID: 59513 RVA: 0x003D78B8 File Offset: 0x003D5CB8
		private void _InitUIEvent()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.DelegateAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance2.onDeleteMission, new MissionManager.DelegateDeleteMission(this.DelegateDeleteMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance3.onUpdateMission, new MissionManager.DelegateUpdateMission(this.DelegateUpdateMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onSyncMission = (MissionManager.DelegateSyncMission)Delegate.Combine(instance4.onSyncMission, new MissionManager.DelegateSyncMission(this.DelegateSyncMission));
		}

		// Token: 0x0600E87A RID: 59514 RVA: 0x003D7960 File Offset: 0x003D5D60
		private void DelegateAddNewMission(uint taskID)
		{
			if (Utility.IsLegendMission(taskID) && this.data.mainItem.missionIds.Contains((int)taskID))
			{
				LegendMissionItem legendMissionItem = this.m_akLegendMissionItems.Find((LegendMissionItem x) => x.Value.missionValue.taskID == taskID);
				if (legendMissionItem != null)
				{
					MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission(taskID);
					if (mission != null)
					{
						LegendMissionItemData legendMissionItemData = this.CreateLegendMissionData(mission, this.data.mainItem.ID);
						legendMissionItem.OnRefresh(new object[]
						{
							legendMissionItemData
						});
					}
				}
				else
				{
					LegendMissionItemData legendMissionItemData2 = this._CreateLegendMissionData((int)taskID, this.data.mainItem.ID);
					if (legendMissionItemData2 != null)
					{
						this._CreateLegendMission(legendMissionItemData2);
					}
				}
				this._SortLegendMissions();
			}
		}

		// Token: 0x0600E87B RID: 59515 RVA: 0x003D7A40 File Offset: 0x003D5E40
		private void DelegateSyncMission(uint taskID)
		{
			if (Utility.IsLegendMission(taskID) && this.data.mainItem.missionIds.Contains((int)taskID))
			{
				LegendMissionItem legendMissionItem = this.m_akLegendMissionItems.Find((LegendMissionItem x) => x.Value.missionValue.taskID == taskID);
				MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission(taskID);
				if (mission == null)
				{
					return;
				}
				if (legendMissionItem == null)
				{
					return;
				}
				LegendMissionItemData legendMissionItemData = this.CreateLegendMissionData(mission, this.data.mainItem.ID);
				legendMissionItem.OnRefresh(new object[]
				{
					legendMissionItemData
				});
			}
		}

		// Token: 0x0600E87C RID: 59516 RVA: 0x003D7AEC File Offset: 0x003D5EEC
		private void DelegateUpdateMission(uint taskID)
		{
			if (Utility.IsLegendMission(taskID) && this.data.mainItem.missionIds.Contains((int)taskID))
			{
				LegendMissionItem legendMissionItem = this.m_akLegendMissionItems.Find((LegendMissionItem x) => x.Value.missionValue.taskID == taskID);
				MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission(taskID);
				if (mission == null)
				{
					return;
				}
				if (legendMissionItem == null)
				{
					return;
				}
				LegendMissionItemData legendMissionItemData = this.CreateLegendMissionData(mission, this.data.mainItem.ID);
				legendMissionItem.OnRefresh(new object[]
				{
					legendMissionItemData
				});
				this._SortLegendMissions();
			}
		}

		// Token: 0x0600E87D RID: 59517 RVA: 0x003D7B9C File Offset: 0x003D5F9C
		private void DelegateDeleteMission(uint taskID)
		{
			if (Utility.IsLegendMission(taskID) && this.data.mainItem.missionIds.Contains((int)taskID))
			{
				LegendMissionItem legendMissionItem = this.m_akLegendMissionItems.Find((LegendMissionItem x) => x.Value.missionValue.taskID == taskID);
				if (DataManager<MissionManager>.GetInstance().GetMission(taskID) == null)
				{
					return;
				}
				if (legendMissionItem == null)
				{
					return;
				}
				if (Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)taskID, string.Empty, string.Empty) == null)
				{
					return;
				}
				MissionManager.SingleMissionInfo curmissionValue = this._CreateMissionFromTable(taskID);
				LegendMissionItemData legendMissionItemData = this.CreateLegendMissionData(curmissionValue, this.data.mainItem.ID);
				legendMissionItem.OnRefresh(new object[]
				{
					legendMissionItemData
				});
				this._SortLegendMissions();
			}
		}

		// Token: 0x0600E87E RID: 59518 RVA: 0x003D7C7C File Offset: 0x003D607C
		private MissionManager.SingleMissionInfo _CreateMissionFromTable(uint taskID)
		{
			MissionManager.SingleMissionInfo result = null;
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)taskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				result = new MissionManager.SingleMissionInfo
				{
					taskID = taskID,
					missionItem = tableItem,
					status = 0
				};
			}
			return result;
		}

		// Token: 0x0600E87F RID: 59519 RVA: 0x003D7CC8 File Offset: 0x003D60C8
		private void _SortLegendMissions()
		{
			this.m_akLegendMissionItems.ActiveObjects.Sort((LegendMissionItem x, LegendMissionItem y) => x.Value.missionValue.LegendCompareTo(y.Value.missionValue));
			for (int i = 0; i < this.m_akLegendMissionItems.ActiveObjects.Count; i++)
			{
				this.m_akLegendMissionItems.ActiveObjects[i].SetSiblingIndex(i);
			}
		}

		// Token: 0x0600E880 RID: 59520 RVA: 0x003D7D3C File Offset: 0x003D613C
		private void _RefreshLegendMissions()
		{
			this.m_akLegendMissionItems.RecycleAllObject();
			List<object> list = ListPool<object>.Get();
			for (int i = 0; i < this.data.mainItem.missionIds.Count; i++)
			{
				LegendMissionItemData legendMissionItemData = this._CreateLegendMissionData(this.data.mainItem.missionIds[i], this.data.mainItem.ID);
				if (legendMissionItemData != null)
				{
					list.Add(legendMissionItemData);
				}
			}
			list.Sort((object x, object y) => (x as LegendMissionItemData).missionValue.LegendCompareTo((y as LegendMissionItemData).missionValue));
			for (int j = 0; j < list.Count; j++)
			{
				this._CreateLegendMission(list[j] as LegendMissionItemData);
			}
			ListPool<object>.Release(list);
		}

		// Token: 0x0600E881 RID: 59521 RVA: 0x003D7E0C File Offset: 0x003D620C
		private LegendMissionItemData GetLegendMissionItemNewData(int iTaskID, int legendId = -1)
		{
			return this._CreateLegendMissionData(iTaskID, legendId);
		}

		// Token: 0x0600E882 RID: 59522 RVA: 0x003D7E18 File Offset: 0x003D6218
		private LegendMissionItemData CreateLegendMissionData(MissionManager.SingleMissionInfo curmissionValue, int curLegendId)
		{
			return new LegendMissionItemData
			{
				missionValue = curmissionValue,
				LegendId = curLegendId
			};
		}

		// Token: 0x0600E883 RID: 59523 RVA: 0x003D7E3C File Offset: 0x003D623C
		private LegendMissionItemData _CreateLegendMissionData(int iTaskID, int legendId = -1)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (tableItem == null || tableItem.MissionOnOff != 1)
			{
				return null;
			}
			List<AwardItemData> missionAwards = DataManager<MissionManager>.GetInstance().GetMissionAwards(iTaskID, -1);
			if (missionAwards == null || missionAwards.Count <= 0)
			{
				return null;
			}
			MissionManager.SingleMissionInfo singleMissionInfo = DataManager<MissionManager>.GetInstance().GetMission((uint)tableItem.ID);
			if (singleMissionInfo == null)
			{
				singleMissionInfo = this._CreateMissionFromTable((uint)tableItem.ID);
			}
			return new LegendMissionItemData
			{
				LegendId = legendId,
				missionValue = singleMissionInfo
			};
		}

		// Token: 0x0600E884 RID: 59524 RVA: 0x003D7ECD File Offset: 0x003D62CD
		private void _CreateLegendMission(LegendMissionItemData lmiD)
		{
			this.m_akLegendMissionItems.Create(new object[]
			{
				this.goMissionParent,
				this.goMissionPrefab,
				lmiD,
				false
			});
		}

		// Token: 0x0600E885 RID: 59525 RVA: 0x003D7F00 File Offset: 0x003D6300
		private void _UnInitUIEvent()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.DelegateAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance2.onDeleteMission, new MissionManager.DelegateDeleteMission(this.DelegateDeleteMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance3.onUpdateMission, new MissionManager.DelegateUpdateMission(this.DelegateUpdateMission));
			MissionManager instance4 = DataManager<MissionManager>.GetInstance();
			instance4.onSyncMission = (MissionManager.DelegateSyncMission)Delegate.Remove(instance4.onSyncMission, new MissionManager.DelegateSyncMission(this.DelegateSyncMission));
		}

		// Token: 0x0600E886 RID: 59526 RVA: 0x003D7FA5 File Offset: 0x003D63A5
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as LegendSeriesFrameData);
			this._InitMain();
			this._InitGuidance();
			this._InitLegendMissions();
			this._InitUIEvent();
		}

		// Token: 0x0600E887 RID: 59527 RVA: 0x003D7FD0 File Offset: 0x003D63D0
		protected override void _OnCloseFrame()
		{
			this._UnInitUIEvent();
			this._UnInitLegendMissions();
			this.m_akLegendItems.DestroyAllObjects();
			this.data = null;
		}

		// Token: 0x04008CEE RID: 36078
		private LegendSeriesFrameData data;

		// Token: 0x04008CEF RID: 36079
		private GameObject goMissionParent;

		// Token: 0x04008CF0 RID: 36080
		private GameObject goMissionPrefab;

		// Token: 0x04008CF1 RID: 36081
		private CachedObjectListManager<LegendItem> m_akLegendItems = new CachedObjectListManager<LegendItem>();

		// Token: 0x04008CF2 RID: 36082
		private CachedObjectListManager<LegendMissionItem> m_akLegendMissionItems = new CachedObjectListManager<LegendMissionItem>();
	}
}
