using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000082 RID: 130
	internal class MissionLinkTest : MonoBehaviour
	{
		// Token: 0x060002C9 RID: 713 RVA: 0x00015A08 File Offset: 0x00013E08
		public void OnClickToLink()
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.MissionID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				Logger.LogErrorFormat("link [{0}][{1}]", new object[]
				{
					tableItem.ID,
					tableItem.TaskName
				});
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(tableItem.LinkInfo, null, false);
			}
		}

		// Token: 0x040002C3 RID: 707
		public int MissionID;
	}
}
