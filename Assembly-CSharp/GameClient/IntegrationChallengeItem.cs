using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F8 RID: 6392
	public class IntegrationChallengeItem : MonoBehaviour, IActivityCommonItem, IDisposable
	{
		// Token: 0x0600F925 RID: 63781 RVA: 0x0043F328 File Offset: 0x0043D728
		public void Init(uint id, uint activityId, ILimitTimeActivityTaskDataModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mNameTxt.SafeSetText(data.Desc);
			if (data.ParamNums2.Count >= 2)
			{
				int num = (int)data.ParamNums2[0];
				int num2 = (int)data.ParamNums2[1];
				if (num > 0)
				{
					this.mSingleIntegrationTxt.SafeSetText(string.Format(TR.Value("IntegrationChallenge_In", num), new object[0]));
				}
				else
				{
					this.mSingleIntegrationTxt.SafeSetText("/");
				}
			}
			this.mMutilIntegrationTxt.SafeSetText(data.taskName);
			if (data.ParamNums.Count > 0)
			{
				switch (data.ParamNums[0])
				{
				case 0U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time1"));
					break;
				case 1U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time2"));
					break;
				case 2U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time3"));
					break;
				case 3U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time4"));
					break;
				case 4U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time5"));
					break;
				case 5U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time6"));
					break;
				case 6U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time7"));
					break;
				case 7U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time8"));
					break;
				case 8U:
					this.mChallengeTimeTxt.SafeSetText(TR.Value("IntegrationChallenge_Time9"));
					break;
				}
			}
		}

		// Token: 0x0600F926 RID: 63782 RVA: 0x0043F4FB File Offset: 0x0043D8FB
		public void Destroy()
		{
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F927 RID: 63783 RVA: 0x0043F508 File Offset: 0x0043D908
		public void Dispose()
		{
		}

		// Token: 0x0600F928 RID: 63784 RVA: 0x0043F50A File Offset: 0x0043D90A
		public void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
		}

		// Token: 0x0600F929 RID: 63785 RVA: 0x0043F50C File Offset: 0x0043D90C
		public void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
		}

		// Token: 0x04009AD9 RID: 39641
		[SerializeField]
		private Text mNameTxt;

		// Token: 0x04009ADA RID: 39642
		[SerializeField]
		private Text mChallengeTimeTxt;

		// Token: 0x04009ADB RID: 39643
		[SerializeField]
		private Text mSingleIntegrationTxt;

		// Token: 0x04009ADC RID: 39644
		[SerializeField]
		private Text mMutilIntegrationTxt;
	}
}
