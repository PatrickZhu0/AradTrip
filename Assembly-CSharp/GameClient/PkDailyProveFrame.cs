using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001993 RID: 6547
	public class PkDailyProveFrame : ClientFrame
	{
		// Token: 0x0600FED7 RID: 65239 RVA: 0x00468552 File Offset: 0x00466952
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PkDailyProveFrame";
		}

		// Token: 0x0600FED8 RID: 65240 RVA: 0x00468559 File Offset: 0x00466959
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600FED9 RID: 65241 RVA: 0x0046857A File Offset: 0x0046697A
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.DailyProve);
		}

		// Token: 0x0600FEDA RID: 65242 RVA: 0x004685AC File Offset: 0x004669AC
		private void ClearData()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateDailyProve));
			this.DailyProveList.Clear();
			for (int i = 0; i < this.ComItems.Length; i++)
			{
				this.ComItems[i] = null;
			}
		}

		// Token: 0x0600FEDB RID: 65243 RVA: 0x0046860C File Offset: 0x00466A0C
		protected void BindUIEvent()
		{
		}

		// Token: 0x0600FEDC RID: 65244 RVA: 0x0046860E File Offset: 0x00466A0E
		protected void UnBindUIEvent()
		{
		}

		// Token: 0x0600FEDD RID: 65245 RVA: 0x00468610 File Offset: 0x00466A10
		[UIEventHandle("middle/title/btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<PkDailyProveFrame>(this, false);
		}

		// Token: 0x0600FEDE RID: 65246 RVA: 0x0046861F File Offset: 0x00466A1F
		[UIEventHandle("middle/greenback/Daily{0}/btReceive", typeof(Button), typeof(UnityAction<int>), 1, 2)]
		private void OnReceiveAwards(int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.DailyProveList.Count)
			{
				return;
			}
			DataManager<MissionManager>.GetInstance().sendCmdSubmitTask(this.DailyProveList[iIndex].taskID, TaskSubmitType.TASK_SUBMIT_UI, 0U);
		}

		// Token: 0x0600FEDF RID: 65247 RVA: 0x00468658 File Offset: 0x00466A58
		private void InitInterface()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateDailyProve));
			for (int i = 0; i < this.btReceive.Length; i++)
			{
				ComItem comItem = base.CreateComItem(this.pos[i].gameObject);
				this.ComItems[i] = comItem;
				this.btReceive[i].gameObject.AddComponent<UIGray>();
				this.btReceive[i].gameObject.GetComponent<UIGray>().enabled = true;
				this.btReceive[i].interactable = false;
			}
			List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			for (int j = 0; j < list.Count; j++)
			{
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)list[j].taskID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_DIALY && tableItem.SubType == MissionTable.eSubType.Daily_Prove)
				{
					this.DailyProveList.Add(list[j]);
				}
			}
			this.UpdateDailyProveInterface();
		}

		// Token: 0x0600FEE0 RID: 65248 RVA: 0x00468788 File Offset: 0x00466B88
		private void UpdateDailyProveInterface()
		{
			int num = 0;
			while (num < this.DailyProveList.Count && num < 2)
			{
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)this.DailyProveList[num].taskID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.Description[num].text = Utility.ParseMissionText((int)this.DailyProveList[num].taskID, true, false, false);
					string[] array = tableItem.Award.Split(new char[]
					{
						','
					});
					if (array.Length > 0)
					{
						string[] array2 = array[0].Split(new char[]
						{
							'_'
						});
						if (array2.Length == 2)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
							if (itemData != null)
							{
								this.ComItems[num].Setup(itemData, null);
							}
							this.num[num].text = array2[1];
						}
					}
					if (this.DailyProveList[num].status >= 5)
					{
						this.btReceive[num].gameObject.SetActive(false);
						Text text = this.Description[num];
						text.text += "<color=#01BC47FF>  (已完成)</color>";
					}
					else
					{
						this.btReceive[num].gameObject.SetActive(true);
						if (this.DailyProveList[num].status == 2)
						{
							this.btReceive[num].gameObject.GetComponent<UIGray>().enabled = false;
							this.btReceive[num].interactable = true;
						}
						else
						{
							this.btReceive[num].gameObject.GetComponent<UIGray>().enabled = true;
							this.btReceive[num].interactable = false;
						}
					}
				}
				num++;
			}
		}

		// Token: 0x0600FEE1 RID: 65249 RVA: 0x0046894C File Offset: 0x00466D4C
		public void OnUpdateDailyProve(uint iMissionID)
		{
			if (!Utility.IsDailyProve(iMissionID))
			{
				return;
			}
			this.UpdateDailyProveData(iMissionID);
			this.UpdateDailyProveInterface();
		}

		// Token: 0x0600FEE2 RID: 65250 RVA: 0x00468968 File Offset: 0x00466D68
		private void UpdateDailyProveData(uint iMissionID)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (!DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue(iMissionID, out singleMissionInfo))
			{
				return;
			}
			for (int i = 0; i < this.DailyProveList.Count; i++)
			{
				if (this.DailyProveList[i].taskID == iMissionID)
				{
					this.DailyProveList[i].status = singleMissionInfo.status;
					this.DailyProveList[i].taskContents = singleMissionInfo.taskContents;
					break;
				}
			}
		}

		// Token: 0x0400A0BC RID: 41148
		private const int DailyProveNum = 2;

		// Token: 0x0400A0BD RID: 41149
		private ComItem[] ComItems = new ComItem[2];

		// Token: 0x0400A0BE RID: 41150
		private List<MissionManager.SingleMissionInfo> DailyProveList = new List<MissionManager.SingleMissionInfo>();

		// Token: 0x0400A0BF RID: 41151
		[UIControl("middle/greenback/Daily{0}/Description", typeof(Text), 1)]
		protected Text[] Description = new Text[2];

		// Token: 0x0400A0C0 RID: 41152
		[UIControl("middle/greenback/Daily{0}/award/pos", typeof(RectTransform), 1)]
		protected RectTransform[] pos = new RectTransform[2];

		// Token: 0x0400A0C1 RID: 41153
		[UIControl("middle/greenback/Daily{0}/award/num", typeof(Text), 1)]
		protected Text[] num = new Text[2];

		// Token: 0x0400A0C2 RID: 41154
		[UIControl("middle/greenback/Daily{0}/btReceive", typeof(Button), 1)]
		protected Button[] btReceive = new Button[2];
	}
}
