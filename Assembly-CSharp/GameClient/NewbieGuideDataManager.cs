using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001067 RID: 4199
	[LoggerModel("NewbieGuide")]
	public class NewbieGuideDataManager : Singleton<NewbieGuideDataManager>
	{
		// Token: 0x06009D92 RID: 40338 RVA: 0x001F13E3 File Offset: 0x001EF7E3
		public NoviceGuideChooseFlag GetRoleNewbieguideState(int id)
		{
			if (this.roleNewbieGuideStateDic.ContainsKey(id))
			{
				return this.roleNewbieGuideStateDic[id];
			}
			return NoviceGuideChooseFlag.NGCF_INIT;
		}

		// Token: 0x06009D93 RID: 40339 RVA: 0x001F1404 File Offset: 0x001EF804
		public void SetRoleNewbieguideState(int id, NoviceGuideChooseFlag state)
		{
			if (this.roleNewbieGuideStateDic.ContainsKey(id))
			{
				this.roleNewbieGuideStateDic[id] = state;
			}
			else
			{
				this.roleNewbieGuideStateDic.Add(id, state);
			}
		}

		// Token: 0x06009D94 RID: 40340 RVA: 0x001F1438 File Offset: 0x001EF838
		public NewbieGuideDataUnit GetData(NewbieGuideTable resTable, NewbieGuideTable.eNewbieGuideTask taskID)
		{
			NewbieGuideDataUnit newbieGuideDataUnit = null;
			if (!string.IsNullOrEmpty(resTable.ScriptDataPath))
			{
				DNewbieGuideData dnewbieGuideData = Singleton<AssetLoader>.instance.LoadRes(resTable.ScriptDataPath, typeof(DNewbieGuideData), false, 0U).obj as DNewbieGuideData;
				if (dnewbieGuideData != null)
				{
					NewbieScriptDataGuide newbieScriptDataGuide = new NewbieScriptDataGuide(resTable.ID);
					newbieScriptDataGuide.LoadScriptData(dnewbieGuideData);
					newbieGuideDataUnit = newbieScriptDataGuide;
				}
			}
			if (newbieGuideDataUnit == null)
			{
				string text = "GameClient.Newbie" + taskID.ToString();
				if (text != null)
				{
					Type type = Type.GetType(text);
					if (type == null)
					{
						Logger.LogErrorFormat("NewbieGuideManager eNewbieGuideTask [{0}] is wrong, please check!", new object[]
						{
							text
						});
					}
					newbieGuideDataUnit = (NewbieGuideDataUnit)Activator.CreateInstance(type, new object[]
					{
						(int)taskID
					});
				}
			}
			if (newbieGuideDataUnit != null)
			{
				newbieGuideDataUnit.Init();
			}
			return newbieGuideDataUnit;
		}

		// Token: 0x06009D95 RID: 40341 RVA: 0x001F150F File Offset: 0x001EF90F
		private string _getForceGuideKey()
		{
			return string.Format("{0}:{1}", DataManager<PlayerBaseData>.GetInstance().RoleID, "NewbieForceGuideProcess");
		}

		// Token: 0x06009D96 RID: 40342 RVA: 0x001F1530 File Offset: 0x001EF930
		private string _getRecordKey(NewbieGuideTable.eNewbieGuideTask taskID)
		{
			object value = PlayerLocalSetting.GetValue("AccountDefault");
			if (value == null)
			{
				return string.Empty;
			}
			return string.Format("{0}:{1}", PlayerLocalSetting.GetValue(value as string), taskID);
		}

		// Token: 0x06009D97 RID: 40343 RVA: 0x001F1570 File Offset: 0x001EF970
		public NewbieGuideTable.eNewbieGuideTask GetLocalForceGuideProcess()
		{
			object value = PlayerLocalSetting.GetValue(this._getForceGuideKey());
			if (value == null)
			{
				return NewbieGuideTable.eNewbieGuideTask.None;
			}
			string s = string.Format("{0}", value);
			return (NewbieGuideTable.eNewbieGuideTask)int.Parse(s);
		}

		// Token: 0x06009D98 RID: 40344 RVA: 0x001F15A8 File Offset: 0x001EF9A8
		public bool GetRecordLocalProcess(NewbieGuideTable.eNewbieGuideTask taskID)
		{
			object value = PlayerLocalSetting.GetValue(this._getRecordKey(taskID));
			return value != null && (bool)value;
		}

		// Token: 0x06009D99 RID: 40345 RVA: 0x001F15D0 File Offset: 0x001EF9D0
		public void SetLocalForceGuideProcess(NewbieGuideTable.eNewbieGuideTask taskID)
		{
			int num = (int)taskID;
			string value = num.ToString();
			PlayerLocalSetting.SetValue(this._getForceGuideKey(), value);
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x06009D9A RID: 40346 RVA: 0x001F15FE File Offset: 0x001EF9FE
		public void RecordLocalProcess(NewbieGuideTable.eNewbieGuideTask taskID, bool state)
		{
			PlayerLocalSetting.SetValue(this._getRecordKey(taskID), state);
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x04005662 RID: 22114
		private Dictionary<int, NoviceGuideChooseFlag> roleNewbieGuideStateDic = new Dictionary<int, NoviceGuideChooseFlag>();
	}
}
