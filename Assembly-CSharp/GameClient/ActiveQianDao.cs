using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GamePool;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000007 RID: 7
	internal class ActiveQianDao : MonoBehaviour
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00004F70 File Offset: 0x00003370
		private void Start()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			this._Update();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000501B File Offset: 0x0000341B
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			this._Update();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00005023 File Offset: 0x00003423
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			this._Update();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000502B File Offset: 0x0000342B
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this._Update();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00005033 File Offset: 0x00003433
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			this._Update();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000503C File Offset: 0x0000343C
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance2.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance3.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000050E4 File Offset: 0x000034E4
		private void _Update()
		{
			bool flag = -1 != this._GetSubmitID();
			if (null != this.comGray)
			{
				this.comGray.enabled = !flag;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00005120 File Offset: 0x00003520
		public void OnSubmitID()
		{
			int num = this._GetSubmitID();
			if (num != -1)
			{
				DataManager<ActiveManager>.GetInstance().SendSubmitActivity(num, 0U);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005148 File Offset: 0x00003548
		private int _GetSubmitID()
		{
			int result = -1;
			List<ActiveManager.ActivityData> list = ListPool<ActiveManager.ActivityData>.Get();
			for (int i = this.iBeginID; i <= this.iEndID; i++)
			{
				ActiveManager.ActivityData childActiveData = DataManager<ActiveManager>.GetInstance().GetChildActiveData(i);
				if (childActiveData != null)
				{
					list.Add(childActiveData);
				}
			}
			List<ActiveManager.ActivityData> list2 = list;
			if (ActiveQianDao.<>f__mg$cache0 == null)
			{
				ActiveQianDao.<>f__mg$cache0 = new Comparison<ActiveManager.ActivityData>(ActiveQianDao.Cmp);
			}
			list2.Sort(ActiveQianDao.<>f__mg$cache0);
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].status == 2)
				{
					result = list[j].ID;
					break;
				}
			}
			ListPool<ActiveManager.ActivityData>.Release(list);
			return result;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00005200 File Offset: 0x00003600
		public static int Cmp(ActiveManager.ActivityData left, ActiveManager.ActivityData right)
		{
			if (left.activeItem.SortPriority != right.activeItem.SortPriority)
			{
				return left.activeItem.SortPriority - right.activeItem.SortPriority;
			}
			if (left.status != right.status)
			{
				if (left.status == 5)
				{
					return 1;
				}
				if (right.status == 5)
				{
					return -1;
				}
				return (int)(right.status - left.status);
			}
			else
			{
				if (left.activeItem.SortPriority2 != right.activeItem.SortPriority2)
				{
					return left.activeItem.SortPriority2 - right.activeItem.SortPriority2;
				}
				return left.activeItem.ID - right.activeItem.ID;
			}
		}

		// Token: 0x04000013 RID: 19
		public UIGray comGray;

		// Token: 0x04000014 RID: 20
		public int iBeginID;

		// Token: 0x04000015 RID: 21
		public int iEndID;

		// Token: 0x04000016 RID: 22
		[CompilerGenerated]
		private static Comparison<ActiveManager.ActivityData> <>f__mg$cache0;
	}
}
