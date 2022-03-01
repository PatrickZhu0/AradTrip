using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001714 RID: 5908
	public class LegendFrame : ClientFrame
	{
		// Token: 0x0600E835 RID: 59445 RVA: 0x003D5A25 File Offset: 0x003D3E25
		public static void CommandOpen(object argv = null)
		{
			if (argv == null)
			{
				argv = new LegendFrameData();
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LegendFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600E836 RID: 59446 RVA: 0x003D5A48 File Offset: 0x003D3E48
		public static void OpenLinkFrame(string parms)
		{
			LegendFrameData legendFrameData = new LegendFrameData();
			int.TryParse(parms, out legendFrameData.iLegendID);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LegendFrame>(FrameLayer.Middle, legendFrameData, string.Empty);
		}

		// Token: 0x0600E837 RID: 59447 RVA: 0x003D5A7A File Offset: 0x003D3E7A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LegendFrame/LegendFrame";
		}

		// Token: 0x0600E838 RID: 59448 RVA: 0x003D5A81 File Offset: 0x003D3E81
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as LegendFrameData);
			if (this.data == null)
			{
				this.data = new LegendFrameData();
			}
			this._InitBinder();
			this._InitUIEvent();
			this._InitTabs();
		}

		// Token: 0x0600E839 RID: 59449 RVA: 0x003D5ABC File Offset: 0x003D3EBC
		protected override void _OnCloseFrame()
		{
			CachedSelectedObject<LegendTabData, LegendTab>.Clear();
			this.m_akLegendTabs.DestroyAllObjects();
			this.data = null;
			this._UnInitUIEvent();
			this._UnInitBinder();
		}

		// Token: 0x0600E83A RID: 59450 RVA: 0x003D5AE1 File Offset: 0x003D3EE1
		private void _InitBinder()
		{
			this.goChildFrameRoot = Utility.FindChild(this.frame, "ChildFrame");
		}

		// Token: 0x0600E83B RID: 59451 RVA: 0x003D5AF9 File Offset: 0x003D3EF9
		private void _UnInitBinder()
		{
			this.goChildFrameRoot = null;
		}

		// Token: 0x0600E83C RID: 59452 RVA: 0x003D5B04 File Offset: 0x003D3F04
		private void _InitTabs()
		{
			GameObject gameObject = Utility.FindThatChild("MainTab", this.frame, false);
			GameObject gameObject2 = Utility.FindThatChild("MainTab/Prefab", this.frame, false);
			if (gameObject2 == null)
			{
				gameObject2 = Utility.FindThatChild("Prefab", this.frame, false);
			}
			gameObject2.CustomActive(false);
			List<object> list = ListPool<object>.Get();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<LegendMainTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				LegendMainTable legendMainTable = keyValuePair.Value as LegendMainTable;
				if (legendMainTable != null)
				{
					list.Add(legendMainTable);
				}
			}
			list.Sort((object x, object y) => this._SortLegendMain(x as LegendMainTable, y as LegendMainTable));
			if (this.data.iLegendID == 0)
			{
				if (list.Count > 0)
				{
					this.data.iLegendID = (list[0] as LegendMainTable).ID;
				}
			}
			else
			{
				object obj = list.Find((object x) => (x as LegendMainTable).ID == this.data.iLegendID);
				if (obj == null)
				{
					if (list.Count > 0)
					{
						this.data.iLegendID = (list[0] as LegendMainTable).ID;
					}
					else
					{
						this.data.iLegendID = 0;
					}
				}
				else
				{
					int legendMainStatus = Utility.GetLegendMainStatus(obj as LegendMainTable);
					if (legendMainStatus == 1)
					{
						this.data.iLegendID = (list[0] as LegendMainTable).ID;
					}
				}
			}
			if (this.data.iLegendID == 0)
			{
				Logger.LogErrorFormat("can not find legal selected legendmain item !!!", new object[0]);
				ListPool<object>.Release(list);
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.m_akLegendTabs.Create(new object[]
				{
					gameObject,
					gameObject2,
					new LegendTabData
					{
						mainItem = (list[i] as LegendMainTable)
					},
					Delegate.CreateDelegate(typeof(CachedSelectedObject<LegendTabData, LegendTab>.OnSelectedDelegate), this, "_OnTabSelected"),
					false
				});
			}
			ListPool<object>.Release(list);
			LegendTab legendTab = this.m_akLegendTabs.Find((LegendTab x) => x.Value.mainItem.ID == this.data.iLegendID);
			if (legendTab != null)
			{
				legendTab.OnSelected();
			}
			else
			{
				if (this.m_akLegendTabs.ActiveObjects.Count > 0)
				{
					this.m_akLegendTabs.ActiveObjects[0].OnSelected();
				}
				Logger.LogErrorFormat("this can not be happened! please check code !", new object[0]);
			}
		}

		// Token: 0x0600E83D RID: 59453 RVA: 0x003D5D90 File Offset: 0x003D4190
		private void _SortTabs()
		{
			this.m_akLegendTabs.ActiveObjects.Sort((LegendTab x, LegendTab y) => this._SortLegendMain(x.Value.mainItem, y.Value.mainItem));
			for (int i = 0; i < this.m_akLegendTabs.ActiveObjects.Count; i++)
			{
				this.m_akLegendTabs.ActiveObjects[i].SetSiblingIndex(i);
			}
			for (int j = 0; j < this.m_akLegendTabs.ActiveObjects.Count; j++)
			{
				this.m_akLegendTabs.ActiveObjects[j].OnUpdate();
			}
		}

		// Token: 0x0600E83E RID: 59454 RVA: 0x003D5E28 File Offset: 0x003D4228
		private int _SortLegendMain(LegendMainTable left, LegendMainTable right)
		{
			int legendMainStatus = Utility.GetLegendMainStatus(left);
			int legendMainStatus2 = Utility.GetLegendMainStatus(right);
			if (legendMainStatus != legendMainStatus2)
			{
				return legendMainStatus - legendMainStatus2;
			}
			return left.SortID - right.SortID;
		}

		// Token: 0x0600E83F RID: 59455 RVA: 0x003D5E5C File Offset: 0x003D425C
		private void _OnTabSelected(LegendTabData data)
		{
			if (!(base._GetChildFrame(data.mainItem.ID) is LegendSeriesFrame))
			{
				LegendSeriesFrame clientFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<LegendSeriesFrame>(this.goChildFrameRoot, new LegendSeriesFrameData
				{
					mainItem = data.mainItem
				}, string.Format("LegendSeriesFrame_{0}", data.mainItem.ID)) as LegendSeriesFrame;
				base._AddChildFrame(data.mainItem.ID, clientFrame);
			}
			for (int i = 0; i < this.childFrames.Count; i++)
			{
				(this.childFrames[i].Value as LegendSeriesFrame).SetVisible(data.mainItem.ID == this.childFrames[i].Key);
			}
		}

		// Token: 0x0600E840 RID: 59456 RVA: 0x003D5F38 File Offset: 0x003D4338
		private void _InitUIEvent()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.DelegateAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.DelegateUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.DelegateDeleteMission));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance4.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			base._AddButton("ComWnd/Title/Close", delegate
			{
				this.frameMgr.CloseFrame<LegendFrame>(this, false);
			});
		}

		// Token: 0x0600E841 RID: 59457 RVA: 0x003D5FF4 File Offset: 0x003D43F4
		private void DelegateAddNewMission(uint taskID)
		{
			if (Utility.IsLegendMission(taskID))
			{
				this._SortTabs();
			}
		}

		// Token: 0x0600E842 RID: 59458 RVA: 0x003D6007 File Offset: 0x003D4407
		private void DelegateUpdateMission(uint taskID)
		{
			if (Utility.IsLegendMission(taskID))
			{
				this._SortTabs();
			}
		}

		// Token: 0x0600E843 RID: 59459 RVA: 0x003D601A File Offset: 0x003D441A
		private void DelegateDeleteMission(uint taskID)
		{
			if (Utility.IsLegendMission(taskID))
			{
				this._SortTabs();
			}
		}

		// Token: 0x0600E844 RID: 59460 RVA: 0x003D602D File Offset: 0x003D442D
		private void OnLevelChanged(int iPre, int iCur)
		{
			this._SortTabs();
		}

		// Token: 0x0600E845 RID: 59461 RVA: 0x003D6038 File Offset: 0x003D4438
		private void _UnInitUIEvent()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.DelegateAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance2.onUpdateMission, new MissionManager.DelegateUpdateMission(this.DelegateUpdateMission));
			MissionManager instance3 = DataManager<MissionManager>.GetInstance();
			instance3.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance3.onDeleteMission, new MissionManager.DelegateDeleteMission(this.DelegateDeleteMission));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance4.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x04008CC7 RID: 36039
		private LegendFrameData data;

		// Token: 0x04008CC8 RID: 36040
		private GameObject goChildFrameRoot;

		// Token: 0x04008CC9 RID: 36041
		private CachedObjectListManager<LegendTab> m_akLegendTabs = new CachedObjectListManager<LegendTab>();
	}
}
