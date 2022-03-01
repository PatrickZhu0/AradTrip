using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017E5 RID: 6117
	internal class ComMoneyRewardsResultInfo : MonoBehaviour
	{
		// Token: 0x0600F0EF RID: 61679 RVA: 0x0040DED9 File Offset: 0x0040C2D9
		public void OnWatchRecord()
		{
		}

		// Token: 0x0600F0F0 RID: 61680 RVA: 0x0040DEDC File Offset: 0x0040C2DC
		public void SetValue(ComMoneyRewardsResultData value)
		{
			this.data = value;
			if (this.data != null)
			{
				if (null != this.comState)
				{
					if (this.data.winTimes < 0)
					{
						this.comState.Key = ComMoneyRewardsResultInfo.ms_key_init;
					}
					else if (this.data.winTimes == 0)
					{
						ComMoneyRewardsResultData otherResultData = DataManager<MoneyRewardsDataManager>.GetInstance().GetOtherResultData(value);
						if (otherResultData == null)
						{
							this.comState.Key = ComMoneyRewardsResultInfo.ms_key_init;
						}
						else if (otherResultData.winTimes <= 0)
						{
							this.comState.Key = ComMoneyRewardsResultInfo.ms_key_init;
						}
						else
						{
							this.comState.Key = ComMoneyRewardsResultInfo.ms_key_lose;
						}
					}
					else if (this.data.winTimes == 1)
					{
						if (!this.data.losed)
						{
							this.comState.Key = ComMoneyRewardsResultInfo.ms_key_win1;
						}
						else
						{
							this.comState.Key = ComMoneyRewardsResultInfo.ms_key_win1_lose;
						}
					}
					else if (this.data.winTimes == 2)
					{
						if (!this.data.losed)
						{
							this.comState.Key = ComMoneyRewardsResultInfo.ms_key_win2;
						}
						else
						{
							this.comState.Key = ComMoneyRewardsResultInfo.ms_key_win2_lose;
						}
					}
					else if (this.data.winTimes == 3)
					{
						this.comState.Key = ComMoneyRewardsResultInfo.ms_key_win3;
					}
					else
					{
						this.comState.Key = ComMoneyRewardsResultInfo.ms_key_win3;
						Logger.LogErrorFormat("status error winTimes = {0}", new object[]
						{
							this.data.winTimes
						});
					}
				}
				if (null != this.Name)
				{
					this.Name.text = this.data.name;
				}
				if (null != this.Icon)
				{
					string path = string.Empty;
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.data.occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							path = tableItem2.IconPath;
						}
					}
					ETCImageLoader.LoadSprite(ref this.Icon, path, true);
				}
			}
			else if (null != this.comState)
			{
				this.comState.Key = ComMoneyRewardsResultInfo.ms_key_null;
			}
		}

		// Token: 0x0600F0F1 RID: 61681 RVA: 0x0040E150 File Offset: 0x0040C550
		public void OnWatchPlayerInfo()
		{
			if (this.data != null && this.data.recordId > 0UL && this.data.recordId != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this.data.recordId, 0U, 0U);
			}
		}

		// Token: 0x040093FD RID: 37885
		private static string ms_key_lose = "lose";

		// Token: 0x040093FE RID: 37886
		private static string ms_key_win1 = "win1";

		// Token: 0x040093FF RID: 37887
		private static string ms_key_win2 = "win2";

		// Token: 0x04009400 RID: 37888
		private static string ms_key_win3 = "win3";

		// Token: 0x04009401 RID: 37889
		private static string ms_key_null = "null";

		// Token: 0x04009402 RID: 37890
		private static string ms_key_init = "unstarted";

		// Token: 0x04009403 RID: 37891
		private static string ms_key_win1_lose = "win1_lose";

		// Token: 0x04009404 RID: 37892
		private static string ms_key_win2_lose = "win2_lose";

		// Token: 0x04009405 RID: 37893
		public Image Icon;

		// Token: 0x04009406 RID: 37894
		public Text Name;

		// Token: 0x04009407 RID: 37895
		public StateController comState;

		// Token: 0x04009408 RID: 37896
		public Image LoseIcon;

		// Token: 0x04009409 RID: 37897
		private ComMoneyRewardsResultData data;
	}
}
