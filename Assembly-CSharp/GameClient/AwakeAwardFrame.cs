using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014A0 RID: 5280
	internal class AwakeAwardFrame : ClientFrame
	{
		// Token: 0x0600CCBC RID: 52412 RVA: 0x0032489C File Offset: 0x00322C9C
		protected override void _OnOpenFrame()
		{
			this.TaskID = (int)this.userData;
			this.InitInterface();
		}

		// Token: 0x0600CCBD RID: 52413 RVA: 0x003248B5 File Offset: 0x00322CB5
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600CCBE RID: 52414 RVA: 0x003248BD File Offset: 0x00322CBD
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/AwakeAwardFrame";
		}

		// Token: 0x0600CCBF RID: 52415 RVA: 0x003248C4 File Offset: 0x00322CC4
		private void ClearData()
		{
			this.TaskID = 0;
		}

		// Token: 0x0600CCC0 RID: 52416 RVA: 0x003248D0 File Offset: 0x00322CD0
		[UIEventHandle("btGoOnChallenge")]
		private void OnGoOnChallenge()
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.TaskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AwakeTaskFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AwakeTaskFrame>(null, false);
			}
			if (DataManager<PlayerBaseData>.GetInstance().AwakeState < 1 && tableItem.AfterID != 0)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AwakeTaskFrame>(FrameLayer.Middle, null, string.Empty);
			}
			if (DataManager<PlayerBaseData>.GetInstance().AwakeState == 1)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.AwakeChanged, null, null, null, null);
			}
			this.frameMgr.CloseFrame<AwakeAwardFrame>(this, false);
		}

		// Token: 0x0600CCC1 RID: 52417 RVA: 0x00324978 File Offset: 0x00322D78
		private void InitInterface()
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.TaskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.TaskName.text = tableItem.TaskName;
			string[] array = tableItem.Award.Split(new char[]
			{
				','
			});
			int num = 0;
			while (num < 6 && num < array.Length)
			{
				string[] array2 = array[num].Split(new char[]
				{
					'_'
				});
				if (array2.Length == 2)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array2[0]), 100, 0);
					if (itemData != null)
					{
						itemData.Count = int.Parse(array2[1]);
						ComItem comItem = base.CreateComItem(this.pos[num].gameObject);
						comItem.Setup(itemData, null);
					}
				}
				num++;
			}
			if (tableItem.AfterID == 0)
			{
				this.Challenge.text = "完成";
			}
		}

		// Token: 0x04007736 RID: 30518
		private const int MaxItemNum = 6;

		// Token: 0x04007737 RID: 30519
		private int TaskID;

		// Token: 0x04007738 RID: 30520
		[UIControl("TaskName", null, 0)]
		protected Text TaskName;

		// Token: 0x04007739 RID: 30521
		[UIControl("pos/pos{0}", typeof(RectTransform), 1)]
		protected RectTransform[] pos = new RectTransform[6];

		// Token: 0x0400773A RID: 30522
		[UIControl("btGoOnChallenge/Text", null, 0)]
		protected Text Challenge;
	}
}
