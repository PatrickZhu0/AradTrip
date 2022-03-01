using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200190B RID: 6411
	public class SpringChallengeItem : MonoBehaviour, IActivityCommonItem, IDisposable
	{
		// Token: 0x0600F9AC RID: 63916 RVA: 0x004444C0 File Offset: 0x004428C0
		public void Init(uint id, uint activityId, ILimitTimeActivityTaskDataModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mNameTxt.SafeSetText(data.taskName);
			this.mChallengeDesTxt.SafeSetText(data.Desc);
			if (data.ParamNums2.Count >= 2)
			{
				this.mIntegrationTxt.SafeSetText(TR.Value("SpringChallenge_In", data.ParamNums2[1]));
			}
		}

		// Token: 0x0600F9AD RID: 63917 RVA: 0x00444526 File Offset: 0x00442926
		public void Destroy()
		{
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F9AE RID: 63918 RVA: 0x00444533 File Offset: 0x00442933
		public void Dispose()
		{
		}

		// Token: 0x0600F9AF RID: 63919 RVA: 0x00444535 File Offset: 0x00442935
		public void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x0600F9B0 RID: 63920 RVA: 0x00444537 File Offset: 0x00442937
		public void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
		}

		// Token: 0x0600F9B1 RID: 63921 RVA: 0x00444539 File Offset: 0x00442939
		public void SetBackground(int index)
		{
			this.mImg1.CustomActive(index % 2 != 0);
			this.mImg2.CustomActive(index % 2 == 0);
		}

		// Token: 0x04009BC2 RID: 39874
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009BC3 RID: 39875
		[SerializeField]
		private Text mChallengeDesTxt;

		// Token: 0x04009BC4 RID: 39876
		[SerializeField]
		private Text mIntegrationTxt;

		// Token: 0x04009BC5 RID: 39877
		[SerializeField]
		private GameObject mImg1;

		// Token: 0x04009BC6 RID: 39878
		[SerializeField]
		private GameObject mImg2;
	}
}
