using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200180F RID: 6159
	public class AnniversaryBuffPrayItem : MonoBehaviour, IActivityCommonItem, IDisposable
	{
		// Token: 0x0600F2AD RID: 62125 RVA: 0x0041780C File Offset: 0x00415C0C
		public void Init(uint id, uint activityId, ILimitTimeActivityTaskDataModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mNameTxt.SafeSetText(data.taskName);
			string str = string.Empty;
			if (data.TotalNum == 2U || data.TotalNum == 3U)
			{
				if (data.ParamNums != null && data.ParamNums2.Count >= 2)
				{
					int num = (int)data.ParamNums2[0];
					int num2 = 0;
					if (data.TotalNum == 2U)
					{
						num2 = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.DUNGEON_HELL_TIMES);
					}
					else if (data.TotalNum == 3U)
					{
						num2 = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.DUNGEON_YUANGU_TIMES);
					}
					if (num2 > num)
					{
						num2 = num;
					}
					int num3 = num - num2;
					str = string.Format("{0}({1}/{2})", data.Desc, num3, num);
				}
			}
			else
			{
				str = data.Desc;
			}
			this.mDesTxt.SafeSetText(str);
			if (activityId == 1482U)
			{
				if (data.TotalNum == 6U || data.TotalNum == 7U)
				{
					this.mTimeTxt.CustomActive(true);
				}
				else
				{
					this.mTimeTxt.CustomActive(false);
				}
			}
			else if (activityId == 1584U)
			{
				if (data.TotalNum == 5U)
				{
					this.mTimeTxt.CustomActive(true);
				}
				else
				{
					this.mTimeTxt.CustomActive(false);
				}
			}
		}

		// Token: 0x0600F2AE RID: 62126 RVA: 0x0041796D File Offset: 0x00415D6D
		public void ShowTime(string timeStr)
		{
			this.mTimeTxt.SafeSetText(timeStr);
		}

		// Token: 0x0600F2AF RID: 62127 RVA: 0x0041797B File Offset: 0x00415D7B
		public void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x0600F2B0 RID: 62128 RVA: 0x0041797D File Offset: 0x00415D7D
		public void Destroy()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F2B1 RID: 62129 RVA: 0x00417990 File Offset: 0x00415D90
		public void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
		}

		// Token: 0x0600F2B2 RID: 62130 RVA: 0x00417992 File Offset: 0x00415D92
		public void Dispose()
		{
		}

		// Token: 0x04009524 RID: 38180
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009525 RID: 38181
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009526 RID: 38182
		[SerializeField]
		private Text mDesTxt;
	}
}
