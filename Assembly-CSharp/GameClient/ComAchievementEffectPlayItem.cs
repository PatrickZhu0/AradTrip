using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013D0 RID: 5072
	public class ComAchievementEffectPlayItem : MonoBehaviour
	{
		// Token: 0x0600C4AF RID: 50351 RVA: 0x002F3E74 File Offset: 0x002F2274
		public void OnClickLink()
		{
			AchievementGroupDataManager.OnLink2FixedAchievementItemById(this._iId);
		}

		// Token: 0x0600C4B0 RID: 50352 RVA: 0x002F3E81 File Offset: 0x002F2281
		public void OnCreate()
		{
			if (this.onCreate != null)
			{
				this.onCreate.Invoke();
			}
		}

		// Token: 0x0600C4B1 RID: 50353 RVA: 0x002F3E99 File Offset: 0x002F2299
		public void OnRecycle()
		{
			if (this.onRecycle != null)
			{
				this.onRecycle.Invoke();
			}
		}

		// Token: 0x0600C4B2 RID: 50354 RVA: 0x002F3EB4 File Offset: 0x002F22B4
		public void SetValue(int iId)
		{
			this._iId = iId;
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (null != this.Name)
				{
					this.Name.text = tableItem.TaskName;
				}
				if (null != this.Point)
				{
					this.Point.text = string.Format(this.PointFmtString, tableItem.IntParam0);
				}
			}
			AchievementGroupSubItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AchievementGroupSubItemTable>(iId, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				if (null != this.Desc)
				{
					this.Desc.text = tableItem2.Desc;
				}
				ETCImageLoader.LoadSprite(ref this.Icon, tableItem2.Icon, true);
			}
		}

		// Token: 0x04007003 RID: 28675
		public Text Name;

		// Token: 0x04007004 RID: 28676
		public Text Desc;

		// Token: 0x04007005 RID: 28677
		public Text Point;

		// Token: 0x04007006 RID: 28678
		public Image Icon;

		// Token: 0x04007007 RID: 28679
		public string PointFmtString = string.Empty;

		// Token: 0x04007008 RID: 28680
		public UnityEvent onCreate;

		// Token: 0x04007009 RID: 28681
		public UnityEvent onRecycle;

		// Token: 0x0400700A RID: 28682
		private int _iId = -1;
	}
}
