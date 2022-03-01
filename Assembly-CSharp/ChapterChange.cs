using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

// Token: 0x02001525 RID: 5413
public class ChapterChange : Singleton<ChapterChange>
{
	// Token: 0x0600D2A7 RID: 53927 RVA: 0x003420B6 File Offset: 0x003404B6
	public static void Init()
	{
		Singleton<ChapterChange>.instance.onInit();
	}

	// Token: 0x0600D2A8 RID: 53928 RVA: 0x003420C2 File Offset: 0x003404C2
	public static void UnInit()
	{
		Singleton<ChapterChange>.instance.onClear();
	}

	// Token: 0x0600D2A9 RID: 53929 RVA: 0x003420CE File Offset: 0x003404CE
	private List<MissionManager.SingleMissionInfo> getChapterChangeMission()
	{
		return DataManager<MissionManager>.GetInstance().GetAllTaskByType(MissionTable.eTaskType.TT_MAIN, new MissionTable.eSubType[]
		{
			MissionTable.eSubType.Chapter_Change
		});
	}

	// Token: 0x0600D2AA RID: 53930 RVA: 0x003420E5 File Offset: 0x003404E5
	private bool isInTown()
	{
		return Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemTown;
	}

	// Token: 0x0600D2AB RID: 53931 RVA: 0x003420F9 File Offset: 0x003404F9
	private void ShowChapterChange(uint iTaskID, string comicPath)
	{
		if (this.CheckMissionCanSubmit(iTaskID))
		{
			this.submittaskid = iTaskID;
			DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(iTaskID, TaskSubmitType.TASK_SUBMIT_UI, 0U);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChapterChangeComic>(FrameLayer.Top, comicPath, string.Empty);
		}
	}

	// Token: 0x0600D2AC RID: 53932 RVA: 0x0034212D File Offset: 0x0034052D
	private bool isChapterChangeMission(MissionTable table)
	{
		return table.TaskType == MissionTable.eTaskType.TT_MAIN && table.SubType == MissionTable.eSubType.Chapter_Change;
	}

	// Token: 0x0600D2AD RID: 53933 RVA: 0x00342148 File Offset: 0x00340548
	private void CheckChapterChangeMission(uint iTaskID)
	{
		MissionManager.SingleMissionInfo missionInfo = DataManager<MissionManager>.GetInstance().GetMissionInfo(iTaskID);
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iTaskID, string.Empty, string.Empty);
		if (missionInfo != null && tableItem != null && missionInfo.status == 2 && this.isChapterChangeMission(tableItem) && this.isInTown())
		{
			this.ShowChapterChange(iTaskID, tableItem.MissionParam);
		}
	}

	// Token: 0x0600D2AE RID: 53934 RVA: 0x003421B3 File Offset: 0x003405B3
	private void OnDeleteMission(uint iTaskID)
	{
		if (this.submittaskid == iTaskID)
		{
			this.submittaskid = 0U;
		}
	}

	// Token: 0x0600D2AF RID: 53935 RVA: 0x003421C8 File Offset: 0x003405C8
	private bool CheckMissionCanSubmit(uint iTaskID)
	{
		return this.submittaskid != iTaskID;
	}

	// Token: 0x0600D2B0 RID: 53936 RVA: 0x003421DC File Offset: 0x003405DC
	private void OnSceneLoadEnd()
	{
		List<MissionManager.SingleMissionInfo> chapterChangeMission = this.getChapterChangeMission();
		for (int i = 0; i < chapterChangeMission.Count; i++)
		{
			this.CheckChapterChangeMission(chapterChangeMission[i].taskID);
		}
	}

	// Token: 0x0600D2B1 RID: 53937 RVA: 0x00342219 File Offset: 0x00340619
	private void CheckNewMission()
	{
	}

	// Token: 0x0600D2B2 RID: 53938 RVA: 0x0034221C File Offset: 0x0034061C
	public void onInit()
	{
		MissionManager instance = DataManager<MissionManager>.GetInstance();
		instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Combine(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.CheckChapterChangeMission));
		MissionManager instance2 = DataManager<MissionManager>.GetInstance();
		instance2.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance2.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
		Singleton<ClientSystemManager>.instance.OnSwitchSystemFinished.AddListener(new UnityAction(this.OnSceneLoadEnd));
	}

	// Token: 0x0600D2B3 RID: 53939 RVA: 0x00342290 File Offset: 0x00340690
	public void onClear()
	{
		MissionManager instance = DataManager<MissionManager>.GetInstance();
		instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.CheckChapterChangeMission));
		MissionManager instance2 = DataManager<MissionManager>.GetInstance();
		instance2.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance2.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnDeleteMission));
		Singleton<ClientSystemManager>.instance.OnSwitchSystemFinished.RemoveListener(new UnityAction(this.OnSceneLoadEnd));
	}

	// Token: 0x04007B45 RID: 31557
	private uint submittaskid;
}
