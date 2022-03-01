using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200190E RID: 6414
	public class SummerMedalItem : MonoBehaviour, IActivityCommonItem, IDisposable
	{
		// Token: 0x0600F9BA RID: 63930 RVA: 0x00444A94 File Offset: 0x00442E94
		public void Init(uint id, uint activityId, ILimitTimeActivityTaskDataModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mNameTxt.SafeSetText(data.Desc);
			if (data.ParamNums2.Count >= 2)
			{
				int num = (int)data.ParamNums2[0];
				int num2 = (int)data.ParamNums2[1];
				this.mMedalRewardTxt.SafeSetText(string.Format(TR.Value("SpringChallenge_In", num), new object[0]));
			}
			string str = string.Empty;
			string str2 = string.Empty;
			string[] array = data.taskName.Split(new char[]
			{
				'|'
			});
			if (array.Length >= 2)
			{
				str = array[0];
				str2 = array[1];
			}
			this.mActivityTimeTxt.SafeSetText(str);
			this.mMedalLimitNumTxt.SafeSetText(str2);
			if (data.TotalNum > 0U)
			{
				this.mProgressTxt.SafeSetText(string.Format("{0}/{1}", data.DoneNum, data.TotalNum));
			}
			else
			{
				this.mProgressTxt.SafeSetText(string.Empty);
			}
		}

		// Token: 0x0600F9BB RID: 63931 RVA: 0x00444B9F File Offset: 0x00442F9F
		public void Destroy()
		{
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F9BC RID: 63932 RVA: 0x00444BAC File Offset: 0x00442FAC
		public void Dispose()
		{
		}

		// Token: 0x0600F9BD RID: 63933 RVA: 0x00444BAE File Offset: 0x00442FAE
		public void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x0600F9BE RID: 63934 RVA: 0x00444BB0 File Offset: 0x00442FB0
		public void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
		}

		// Token: 0x04009BD8 RID: 39896
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009BD9 RID: 39897
		[SerializeField]
		private Text mActivityTimeTxt;

		// Token: 0x04009BDA RID: 39898
		[SerializeField]
		private Text mMedalRewardTxt;

		// Token: 0x04009BDB RID: 39899
		[SerializeField]
		private Text mMedalLimitNumTxt;

		// Token: 0x04009BDC RID: 39900
		[SerializeField]
		private Text mProgressTxt;
	}
}
