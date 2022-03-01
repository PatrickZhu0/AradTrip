using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001232 RID: 4658
	public class DailyTodoFunction : DailyTodoModel, IComparable<DailyTodoFunction>
	{
		// Token: 0x0600B2FA RID: 45818 RVA: 0x0027C47A File Offset: 0x0027A87A
		public DailyTodoFunction()
		{
			this.Clear();
			this.type = DailyTodoTable.eType.TP_FUNCTION;
		}

		// Token: 0x17001AC2 RID: 6850
		// (get) Token: 0x0600B2FB RID: 45819 RVA: 0x0027C490 File Offset: 0x0027A890
		// (set) Token: 0x0600B2FC RID: 45820 RVA: 0x0027C4B4 File Offset: 0x0027A8B4
		public int WeekRecommendFinishTimestamp
		{
			get
			{
				int num = this._GetLocalFuncWeekFinishTimeStamp();
				if (num < 0)
				{
					return this.weekRecommendFinishTimestamp;
				}
				return num;
			}
			set
			{
				this.weekRecommendFinishTimestamp = this._GetLocalFuncWeekFinishTimeStamp();
				if (this.weekRecommendFinishTimestamp > 0 && value > 0)
				{
					return;
				}
				if (this.weekRecommendFinishTimestamp != value)
				{
					Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.DailyTodoFunctionWeekFinishTime, value, new object[]
					{
						this.subType.ToString()
					});
					this.weekRecommendFinishTimestamp = value;
				}
			}
		}

		// Token: 0x17001AC3 RID: 6851
		// (get) Token: 0x0600B2FD RID: 45821 RVA: 0x0027C51A File Offset: 0x0027A91A
		public bool IsWeekRecommendShow
		{
			get
			{
				return this._GetLocalFuncWeekRecommendShow();
			}
		}

		// Token: 0x17001AC4 RID: 6852
		// (get) Token: 0x0600B2FE RID: 45822 RVA: 0x0027C524 File Offset: 0x0027A924
		// (set) Token: 0x0600B2FF RID: 45823 RVA: 0x0027C548 File Offset: 0x0027A948
		public DailyTodoFuncState RecommendState
		{
			get
			{
				DailyTodoFuncState dailyTodoFuncState = this._GetLocalFuncState();
				if (dailyTodoFuncState < DailyTodoFuncState.None)
				{
					return this.recommendState;
				}
				return dailyTodoFuncState;
			}
			set
			{
				this.recommendState = this._GetLocalFuncState();
				if (this.recommendState == DailyTodoFuncState.End && value == DailyTodoFuncState.Finishing)
				{
					return;
				}
				if (this.recommendState != value)
				{
					Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.DailyTodoFunctionRefreshState, (int)value, new object[]
					{
						this.subType.ToString()
					});
					this.recommendState = value;
				}
				if (value == DailyTodoFuncState.End)
				{
					this.NearlyRecommendEndTimeStamp = Function.GetCurrTimeStamp();
				}
				else
				{
					this.NearlyRecommendEndTimeStamp = 0;
				}
			}
		}

		// Token: 0x17001AC5 RID: 6853
		// (get) Token: 0x0600B300 RID: 45824 RVA: 0x0027C5CC File Offset: 0x0027A9CC
		// (set) Token: 0x0600B301 RID: 45825 RVA: 0x0027C5F0 File Offset: 0x0027A9F0
		public int NearlyRecommendEndTimeStamp
		{
			get
			{
				int num = this._GetLocalFuncEndStateTimeStamp();
				if (num < 0)
				{
					return this.nearlyRecommendEndTimeStamp;
				}
				return num;
			}
			set
			{
				this.nearlyRecommendEndTimeStamp = this._GetLocalFuncEndStateTimeStamp();
				if (this.nearlyRecommendEndTimeStamp != value)
				{
					Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.DailyTodoFunctionEndStateTime, value, new object[]
					{
						this.subType.ToString()
					});
					this.nearlyRecommendEndTimeStamp = value;
				}
			}
		}

		// Token: 0x0600B302 RID: 45826 RVA: 0x0027C644 File Offset: 0x0027AA44
		public override void Clear()
		{
			this.recommendType = DailyTodoTable.eRecommendNumType.RT_NONE;
			this.dayRecommendTotalCount = 0;
			this.weekRecommendFinishTimestamp = 0;
			this.characterDesc = string.Empty;
			this.recommendState = DailyTodoFuncState.None;
			this.dayRecommendDesc = string.Empty;
			if (this.gotoHandler != null)
			{
				Delegate[] invocationList = this.gotoHandler.GetInvocationList();
				if (invocationList != null && invocationList.Length > 0)
				{
					for (int i = 0; i < invocationList.Length; i++)
					{
						Action<DailyTodoFunction> value = invocationList[i] as Action<DailyTodoFunction>;
						this.gotoHandler = (Action<DailyTodoFunction>)Delegate.Remove(this.gotoHandler, value);
					}
				}
				this.gotoHandler = null;
			}
			base.Clear();
		}

		// Token: 0x0600B303 RID: 45827 RVA: 0x0027C6EA File Offset: 0x0027AAEA
		public int CompareTo(DailyTodoFunction other)
		{
			if (other == null)
			{
				return 0;
			}
			return this.tableId - other.tableId;
		}

		// Token: 0x0600B304 RID: 45828 RVA: 0x0027C704 File Offset: 0x0027AB04
		private DailyTodoFuncState _GetLocalFuncState()
		{
			return (DailyTodoFuncState)Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.DailyTodoFunctionRefreshState, new object[]
			{
				this.subType.ToString()
			});
		}

		// Token: 0x0600B305 RID: 45829 RVA: 0x0027C738 File Offset: 0x0027AB38
		private int _GetLocalFuncEndStateTimeStamp()
		{
			return Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.DailyTodoFunctionEndStateTime, new object[]
			{
				this.subType.ToString()
			});
		}

		// Token: 0x0600B306 RID: 45830 RVA: 0x0027C76C File Offset: 0x0027AB6C
		private int _GetLocalFuncWeekFinishTimeStamp()
		{
			return Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.DailyTodoFunctionWeekFinishTime, new object[]
			{
				this.subType.ToString()
			});
		}

		// Token: 0x0600B307 RID: 45831 RVA: 0x0027C7A0 File Offset: 0x0027ABA0
		private bool _GetLocalFuncWeekRecommendShow()
		{
			if (this.refreshHour < 0)
			{
				return false;
			}
			int num = this.WeekRecommendFinishTimestamp;
			return num <= 0 || num >= Function.GetRefreshHourTimeStamp(this.refreshHour);
		}

		// Token: 0x040064F2 RID: 25842
		public DailyTodoTable.eRecommendNumType recommendType;

		// Token: 0x040064F3 RID: 25843
		public int dayRecommendTotalCount;

		// Token: 0x040064F4 RID: 25844
		private int weekRecommendFinishTimestamp;

		// Token: 0x040064F5 RID: 25845
		public string characterDesc;

		// Token: 0x040064F6 RID: 25846
		private DailyTodoFuncState recommendState;

		// Token: 0x040064F7 RID: 25847
		private int nearlyRecommendEndTimeStamp;

		// Token: 0x040064F8 RID: 25848
		public string dayRecommendDesc;

		// Token: 0x040064F9 RID: 25849
		public Action<DailyTodoFunction> gotoHandler;
	}
}
