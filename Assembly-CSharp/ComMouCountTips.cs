using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F0A RID: 3850
public class ComMouCountTips : MonoBehaviour
{
	// Token: 0x0600965B RID: 38491 RVA: 0x001C7524 File Offset: 0x001C5924
	public void SetMonsterNumber()
	{
		UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(this.monsterID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			this.mName.text = tableItem.Name;
		}
		if (BattleMain.instance != null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			BattleMain.instance.Main.FindMonsterByID(list, this.monsterID, true);
			if (list.Count > 0)
			{
				int num = list.Count % 10;
				this.mNumber.sprite = this.mNumbers[num];
				this.mNumber.SetNativeSize();
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x04004D2E RID: 19758
	public Image mNumber;

	// Token: 0x04004D2F RID: 19759
	public Text mName;

	// Token: 0x04004D30 RID: 19760
	public Sprite[] mNumbers;

	// Token: 0x04004D31 RID: 19761
	public int monsterID;
}
