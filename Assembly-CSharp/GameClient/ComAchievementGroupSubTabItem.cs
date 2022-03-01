using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013D2 RID: 5074
	public class ComAchievementGroupSubTabItem : MonoBehaviour
	{
		// Token: 0x0600C4BB RID: 50363 RVA: 0x002F407B File Offset: 0x002F247B
		public void SetValue(string value)
		{
			if (null != this.label)
			{
				this.label.text = value;
			}
			if (null != this.checkLabel)
			{
				this.checkLabel.text = value;
			}
		}

		// Token: 0x0600C4BC RID: 50364 RVA: 0x002F40B8 File Offset: 0x002F24B8
		public void OnValueChanged(bool bValue)
		{
			if (null != this.comState)
			{
				this.comState.Key = ((!bValue) ? "Disable" : "Enable");
			}
			if (bValue && this.menuItem != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementSecondMenuTabChanged, this.menuItem, null, null, null);
			}
		}

		// Token: 0x0600C4BD RID: 50365 RVA: 0x002F411F File Offset: 0x002F251F
		public void OnItemVisible(int itemId)
		{
			this.menuItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSecondMenuTable>(itemId, string.Empty, string.Empty);
			if (this.menuItem != null)
			{
				this.SetValue(this.menuItem.Name);
			}
		}

		// Token: 0x0600C4BE RID: 50366 RVA: 0x002F4158 File Offset: 0x002F2558
		private void Awake()
		{
		}

		// Token: 0x0600C4BF RID: 50367 RVA: 0x002F415A File Offset: 0x002F255A
		private void OnDestroy()
		{
		}

		// Token: 0x0400700B RID: 28683
		public Text label;

		// Token: 0x0400700C RID: 28684
		public Text checkLabel;

		// Token: 0x0400700D RID: 28685
		public StateController comState;

		// Token: 0x0400700E RID: 28686
		private AchievementGroupSecondMenuTable menuItem;
	}
}
