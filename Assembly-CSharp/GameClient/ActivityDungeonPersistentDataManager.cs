using System;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200138A RID: 5002
	public class ActivityDungeonPersistentDataManager : Singleton<ActivityDungeonPersistentDataManager>
	{
		// Token: 0x0600C1E9 RID: 49641 RVA: 0x002E3ADD File Offset: 0x002E1EDD
		private void _log(string msg)
		{
			Debug.LogFormat("[ActivityDungeonPersistentDataManager] {0}", new object[]
			{
				msg
			});
		}

		// Token: 0x0600C1EA RID: 49642 RVA: 0x002E3AF3 File Offset: 0x002E1EF3
		public void LoadData()
		{
			this.UnloadData();
			this._mapJsonStr2Object();
			this.mDirty = false;
			this._bindEvent();
		}

		// Token: 0x0600C1EB RID: 49643 RVA: 0x002E3B10 File Offset: 0x002E1F10
		private void _mapJsonStr2Object()
		{
			try
			{
				this.mPData = JsonMapper.ToObject<ActivityDungeonPersistentData>(this._loadDataString());
				this._log("从文件加载");
			}
			catch (Exception ex)
			{
				this._log(ex.ToString());
			}
			if (this.mPData == null)
			{
				this.mPData = new ActivityDungeonPersistentData();
				this._log("空的数据");
			}
		}

		// Token: 0x0600C1EC RID: 49644 RVA: 0x002E3B84 File Offset: 0x002E1F84
		public void UnloadData()
		{
			this.mPData = null;
			this._unbindEvent();
		}

		// Token: 0x0600C1ED RID: 49645 RVA: 0x002E3B93 File Offset: 0x002E1F93
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDeadTowerWipeoutTimeChange, new ClientEventSystem.UIEventHandler(this._onDeadTowerWipeoutTimeChange));
		}

		// Token: 0x0600C1EE RID: 49646 RVA: 0x002E3BB0 File Offset: 0x002E1FB0
		private void _unbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDeadTowerWipeoutTimeChange, new ClientEventSystem.UIEventHandler(this._onDeadTowerWipeoutTimeChange));
		}

		// Token: 0x0600C1EF RID: 49647 RVA: 0x002E3BCD File Offset: 0x002E1FCD
		private void _onDeadTowerWipeoutTimeChange(UIEvent ui)
		{
			this.UpdateWipeEndTimeAndSave(DataManager<PlayerBaseData>.GetInstance().RoleID, DataManager<PlayerBaseData>.GetInstance().DeathTowerWipeoutEndTime);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonDeadTowerWipeEnd, null, null, null, null);
		}

		// Token: 0x0600C1F0 RID: 49648 RVA: 0x002E3BFC File Offset: 0x002E1FFC
		public void Save()
		{
			if (this.mDirty)
			{
				string text = JsonMapper.ToJson(this.mPData);
				FileArchiveAccessor.SaveFileInPersistentFileArchive("activitydungeonpersistentdata.conf", text);
				this.mDirty = false;
				this._log(string.Format("写入 : {0}", text));
			}
			else
			{
				this._log("数据没有改变");
			}
		}

		// Token: 0x0600C1F1 RID: 49649 RVA: 0x002E3C54 File Offset: 0x002E2054
		private string _loadDataString()
		{
			string text = string.Empty;
			FileArchiveAccessor.LoadFileInPersistentFileArchive("activitydungeonpersistentdata.conf", out text);
			if (string.IsNullOrEmpty(text))
			{
				text = "{}";
			}
			this._log(text);
			return text;
		}

		// Token: 0x0600C1F2 RID: 49650 RVA: 0x002E3C90 File Offset: 0x002E2090
		public void UpdateWipeEndTimeAndSave(ulong roleId, uint wipeEndTime)
		{
			this._log(string.Format("更新死亡之塔时间 {0}", wipeEndTime));
			string roleId2 = roleId.ToString();
			ActivityDungeonDeadTowerWipeData activityDungeonDeadTowerWipeData = this._findActivityDungeonDeadTowerWipeData(roleId2);
			if (activityDungeonDeadTowerWipeData != null)
			{
				if (wipeEndTime > activityDungeonDeadTowerWipeData.wipetime)
				{
					activityDungeonDeadTowerWipeData.wipetime = wipeEndTime;
					activityDungeonDeadTowerWipeData.hasvisit = false;
					this.mDirty = true;
				}
			}
			else
			{
				this._addNewWipEndTime(roleId2, wipeEndTime);
			}
			this.Save();
		}

		// Token: 0x0600C1F3 RID: 49651 RVA: 0x002E3D04 File Offset: 0x002E2104
		private ActivityDungeonDeadTowerWipeData _findActivityDungeonDeadTowerWipeData(ulong roleId)
		{
			if (this.cachedRoleId != roleId || string.IsNullOrEmpty(this.cachedRoleIdString))
			{
				this.cachedRoleId = roleId;
				this.cachedRoleIdString = this.cachedRoleId.ToString();
			}
			return this._findActivityDungeonDeadTowerWipeData(this.cachedRoleIdString);
		}

		// Token: 0x0600C1F4 RID: 49652 RVA: 0x002E3D57 File Offset: 0x002E2157
		private ActivityDungeonDeadTowerWipeData _findActivityDungeonDeadTowerWipeData(string roleId)
		{
			this._findAllActivityDungeonDeadTowerWipeData(roleId);
			return this._getOneActivityDungeonDeadTowerWipeDataWithFilter();
		}

		// Token: 0x0600C1F5 RID: 49653 RVA: 0x002E3D68 File Offset: 0x002E2168
		private void _findAllActivityDungeonDeadTowerWipeData(string roleId)
		{
			if (this.mPData == null)
			{
				return;
			}
			this.mFindDatas.Clear();
			for (int i = 0; i < this.mPData.deadtowerwipe.Count; i++)
			{
				if (this.mPData.deadtowerwipe[i].roleId == roleId)
				{
					this.mFindDatas.Add(this.mPData.deadtowerwipe[i]);
				}
			}
		}

		// Token: 0x0600C1F6 RID: 49654 RVA: 0x002E3DEC File Offset: 0x002E21EC
		private ActivityDungeonDeadTowerWipeData _getOneActivityDungeonDeadTowerWipeDataWithFilter()
		{
			ActivityDungeonDeadTowerWipeData activityDungeonDeadTowerWipeData = null;
			for (int i = 0; i < this.mFindDatas.Count; i++)
			{
				if (activityDungeonDeadTowerWipeData == null)
				{
					activityDungeonDeadTowerWipeData = this.mFindDatas[i];
				}
				else if (activityDungeonDeadTowerWipeData.wipetime <= this.mFindDatas[i].wipetime)
				{
					activityDungeonDeadTowerWipeData = this.mFindDatas[i];
				}
			}
			for (int j = 0; j < this.mFindDatas.Count; j++)
			{
				if (activityDungeonDeadTowerWipeData != this.mFindDatas[j])
				{
					this._log("删除重复数据");
					this.mPData.deadtowerwipe.Remove(this.mFindDatas[j]);
					this.mDirty = true;
				}
			}
			this.mFindDatas.Clear();
			if (this.mDirty)
			{
				this.Save();
			}
			return activityDungeonDeadTowerWipeData;
		}

		// Token: 0x0600C1F7 RID: 49655 RVA: 0x002E3ED4 File Offset: 0x002E22D4
		private void _addNewWipEndTime(string roleId, uint wipeEndTime)
		{
			if (this._findActivityDungeonDeadTowerWipeData(roleId) != null)
			{
				return;
			}
			ActivityDungeonDeadTowerWipeData activityDungeonDeadTowerWipeData = new ActivityDungeonDeadTowerWipeData();
			activityDungeonDeadTowerWipeData.roleId = roleId;
			activityDungeonDeadTowerWipeData.wipetime = wipeEndTime;
			activityDungeonDeadTowerWipeData.hasvisit = false;
			this.mPData.deadtowerwipe.Add(activityDungeonDeadTowerWipeData);
			this.mDirty = true;
		}

		// Token: 0x0600C1F8 RID: 49656 RVA: 0x002E3F24 File Offset: 0x002E2324
		public uint GetWipeEndTime(ulong roleId)
		{
			ActivityDungeonDeadTowerWipeData activityDungeonDeadTowerWipeData = this._findActivityDungeonDeadTowerWipeData(roleId);
			if (activityDungeonDeadTowerWipeData == null)
			{
				return 0U;
			}
			return activityDungeonDeadTowerWipeData.wipetime;
		}

		// Token: 0x0600C1F9 RID: 49657 RVA: 0x002E3F48 File Offset: 0x002E2348
		public bool HasWipeEndVisited(ulong roleId)
		{
			ActivityDungeonDeadTowerWipeData activityDungeonDeadTowerWipeData = this._findActivityDungeonDeadTowerWipeData(roleId);
			return activityDungeonDeadTowerWipeData == null || activityDungeonDeadTowerWipeData.hasvisit;
		}

		// Token: 0x0600C1FA RID: 49658 RVA: 0x002E3F6C File Offset: 0x002E236C
		public void SetWipeEndTimeVistedAndSave(ulong roleId)
		{
			ActivityDungeonDeadTowerWipeData activityDungeonDeadTowerWipeData = this._findActivityDungeonDeadTowerWipeData(roleId);
			if (activityDungeonDeadTowerWipeData == null)
			{
				return;
			}
			if (!activityDungeonDeadTowerWipeData.hasvisit)
			{
				activityDungeonDeadTowerWipeData.hasvisit = true;
				this.mDirty = true;
			}
			this.Save();
		}

		// Token: 0x04006DE9 RID: 28137
		public const string kFileName = "activitydungeonpersistentdata.conf";

		// Token: 0x04006DEA RID: 28138
		private ActivityDungeonPersistentData mPData;

		// Token: 0x04006DEB RID: 28139
		private bool mDirty;

		// Token: 0x04006DEC RID: 28140
		private ulong cachedRoleId = (ulong)-1;

		// Token: 0x04006DED RID: 28141
		private string cachedRoleIdString;

		// Token: 0x04006DEE RID: 28142
		private List<ActivityDungeonDeadTowerWipeData> mFindDatas = new List<ActivityDungeonDeadTowerWipeData>();
	}
}
