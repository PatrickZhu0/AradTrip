using System;

namespace GameClient
{
	// Token: 0x020017E2 RID: 6114
	internal class ComMoneyRewardsRecordsData
	{
		// Token: 0x17001CF3 RID: 7411
		// (get) Token: 0x0600F0E3 RID: 61667 RVA: 0x0040DA16 File Offset: 0x0040BE16
		public bool selfRelation
		{
			get
			{
				return this.srcId == DataManager<PlayerBaseData>.GetInstance().RoleID;
			}
		}

		// Token: 0x17001CF4 RID: 7412
		// (get) Token: 0x0600F0E4 RID: 61668 RVA: 0x0040DA2A File Offset: 0x0040BE2A
		public bool HasSelfInfo
		{
			get
			{
				return this.srcId == DataManager<PlayerBaseData>.GetInstance().RoleID || this.tarId == DataManager<PlayerBaseData>.GetInstance().RoleID;
			}
		}

		// Token: 0x0600F0E5 RID: 61669 RVA: 0x0040DA56 File Offset: 0x0040BE56
		public string ToLeftName()
		{
			if (this.srcId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return string.Format("<color=#00ff00>我</color>", new object[0]);
			}
			return string.Format("<color=#ffff00>{0}</color>", this.srcName);
		}

		// Token: 0x0600F0E6 RID: 61670 RVA: 0x0040DA8E File Offset: 0x0040BE8E
		public string ToRightName()
		{
			if (this.tarId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return string.Format("<color=#00ff00>我</color>", new object[0]);
			}
			return string.Format("<color=#ffff00>{0}</color>", this.tarName);
		}

		// Token: 0x0600F0E7 RID: 61671 RVA: 0x0040DAC8 File Offset: 0x0040BEC8
		public string ToRecords()
		{
			if (this.selfRelation)
			{
				if (this.dstBeatCount <= 1)
				{
					if (this.srcBeatCount <= 1)
					{
						return TR.Value("money_rewards_records_self_once", new object[]
						{
							this.ToLeftName(),
							this.ToRightName(),
							TR.Value("money_rewards_my_score_add", this.scoreChanged)
						});
					}
					return TR.Value("money_rewards_records_self_mul", new object[]
					{
						this.ToLeftName(),
						this.ToRightName(),
						ComMoneyRewardsRecordsData._ToWinTimes(this.srcBeatCount),
						TR.Value("money_rewards_my_score_add", this.scoreChanged)
					});
				}
				else
				{
					if (this.srcBeatCount <= 1)
					{
						return TR.Value("money_rewards_records_self_once_break", new object[]
						{
							this.ToLeftName(),
							this.ToRightName(),
							ComMoneyRewardsRecordsData._ToWinTimes(this.dstBeatCount),
							TR.Value("money_rewards_my_score_add", this.scoreChanged)
						});
					}
					return TR.Value("money_rewards_records_self_mul_break", new object[]
					{
						this.ToLeftName(),
						this.ToRightName(),
						ComMoneyRewardsRecordsData._ToWinTimes(this.dstBeatCount),
						ComMoneyRewardsRecordsData._ToWinTimes(this.srcBeatCount),
						TR.Value("money_rewards_my_score_add", this.scoreChanged)
					});
				}
			}
			else if (this.dstBeatCount <= 1)
			{
				if (this.srcBeatCount <= 1)
				{
					return TR.Value("money_rewards_records_other_once", this.ToLeftName(), this.ToRightName());
				}
				return TR.Value("money_rewards_records_other_mul", new object[]
				{
					this.ToLeftName(),
					this.ToRightName(),
					ComMoneyRewardsRecordsData._ToWinTimes(this.srcBeatCount)
				});
			}
			else
			{
				if (this.srcBeatCount <= 1)
				{
					return TR.Value("money_rewards_records_other_once_break", new object[]
					{
						this.ToLeftName(),
						this.ToRightName(),
						ComMoneyRewardsRecordsData._ToWinTimes(this.dstBeatCount)
					});
				}
				return TR.Value("money_rewards_records_other_mul_break", new object[]
				{
					this.ToLeftName(),
					this.ToRightName(),
					ComMoneyRewardsRecordsData._ToWinTimes(this.dstBeatCount),
					ComMoneyRewardsRecordsData._ToWinTimes(this.srcBeatCount)
				});
			}
		}

		// Token: 0x0600F0E8 RID: 61672 RVA: 0x0040DD04 File Offset: 0x0040C104
		public static string _ToWinTimes(int times)
		{
			string text = string.Empty;
			if (times == 0)
			{
				text = ComMoneyRewardsRecordsData.ms_num_map[0];
			}
			else
			{
				int num = 0;
				while (times > 0 && num < ComMoneyRewardsRecordsData.attachs.Length)
				{
					AttachInfo attachInfo = ComMoneyRewardsRecordsData.attachs[num];
					int num2 = times % 10;
					if (!string.IsNullOrEmpty(attachInfo.attachWords) && num2 != 0)
					{
						text = attachInfo.attachWords + text;
					}
					if ((attachInfo.attachFlag & 1 << num2) == 1 << num2)
					{
						text = ComMoneyRewardsRecordsData.ms_num_map[num2] + text;
					}
					times /= 10;
					num++;
				}
			}
			return text;
		}

		// Token: 0x040093E6 RID: 37862
		public int iIndex;

		// Token: 0x040093E7 RID: 37863
		public uint time;

		// Token: 0x040093E8 RID: 37864
		public ulong srcId;

		// Token: 0x040093E9 RID: 37865
		public ulong tarId;

		// Token: 0x040093EA RID: 37866
		public string srcName;

		// Token: 0x040093EB RID: 37867
		public string tarName;

		// Token: 0x040093EC RID: 37868
		public int srcBeatCount;

		// Token: 0x040093ED RID: 37869
		public int dstBeatCount;

		// Token: 0x040093EE RID: 37870
		public int scoreChanged;

		// Token: 0x040093EF RID: 37871
		public bool measured;

		// Token: 0x040093F0 RID: 37872
		public float h;

		// Token: 0x040093F1 RID: 37873
		public float w;

		// Token: 0x040093F2 RID: 37874
		public string saveValue = string.Empty;

		// Token: 0x040093F3 RID: 37875
		public static string[] ms_num_map = new string[]
		{
			"零",
			"一",
			"二",
			"三",
			"四",
			"五",
			"六",
			"七",
			"八",
			"九"
		};

		// Token: 0x040093F4 RID: 37876
		private static AttachInfo[] attachs = new AttachInfo[]
		{
			new AttachInfo
			{
				attachFlag = 1022,
				attachWords = string.Empty
			},
			new AttachInfo
			{
				attachFlag = 1021,
				attachWords = "十"
			},
			new AttachInfo
			{
				attachFlag = 1023,
				attachWords = "百"
			}
		};
	}
}
