using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using GameClient;
using Network;
using Protocol;
using ProtoTable;

namespace AdsPush
{
	// Token: 0x02001806 RID: 6150
	public class LoginPushManager : Singleton<LoginPushManager>
	{
		// Token: 0x17001CF9 RID: 7417
		// (get) Token: 0x0600F273 RID: 62067 RVA: 0x004165D6 File Offset: 0x004149D6
		// (set) Token: 0x0600F272 RID: 62066 RVA: 0x004165CD File Offset: 0x004149CD
		public LoginPushManager.FinishCallBack Callback
		{
			get
			{
				return this.callback;
			}
			set
			{
				this.callback = value;
			}
		}

		// Token: 0x0600F274 RID: 62068 RVA: 0x004165E0 File Offset: 0x004149E0
		public override void Init()
		{
			this.UnInit();
			this.PushIndex = 0;
			this.FinalLoginPushList.Clear();
			this.OpenNextPush = false;
			this.TimeIntrval = 0f;
			NetProcess.AddMsgHandler(600308U, new Action<MsgDATA>(this.OnSyncPlayerLoginStatus));
		}

		// Token: 0x0600F275 RID: 62069 RVA: 0x0041662D File Offset: 0x00414A2D
		public override void UnInit()
		{
			this.FinalLoginPushList.Clear();
			this.OpenNextPush = false;
			this.TimeIntrval = 0f;
			NetProcess.RemoveMsgHandler(600308U, new Action<MsgDATA>(this.OnSyncPlayerLoginStatus));
		}

		// Token: 0x0600F276 RID: 62070 RVA: 0x00416662 File Offset: 0x00414A62
		public void ClearPushList()
		{
			this.LoginPushList.Clear();
		}

		// Token: 0x0600F277 RID: 62071 RVA: 0x00416670 File Offset: 0x00414A70
		public void SetLoginPushList(List<LoginPushManager.LoginPushData> DataList)
		{
			this.LoginPushList.Clear();
			this.PushIndex = 0;
			for (int i = 0; i < DataList.Count; i++)
			{
				LoginPushManager.LoginPushData loginPushData = new LoginPushManager.LoginPushData();
				loginPushData.name = DataList[i].name;
				loginPushData.iconPath = DataList[i].iconPath;
				loginPushData.linkInfo = DataList[i].linkInfo;
				loginPushData.loadingIconPath = DataList[i].loadingIconPath;
				loginPushData.sortNum = DataList[i].sortNum;
				loginPushData.unlockLevel = DataList[i].unlockLevel;
				loginPushData.startTime = DataList[i].startTime;
				loginPushData.endTime = DataList[i].endTime;
				loginPushData.needTime = DataList[i].needTime;
				loginPushData.IsSetNative = DataList[i].IsSetNative;
				this.LoginPushList.Add(loginPushData);
			}
			if (this.LoginPushList.Count >= 2)
			{
				this.SortLoginPushList();
			}
		}

		// Token: 0x0600F278 RID: 62072 RVA: 0x00416783 File Offset: 0x00414B83
		public void SortLoginPushList()
		{
			this.LoginPushList.Sort(delegate(LoginPushManager.LoginPushData x, LoginPushManager.LoginPushData y)
			{
				int result;
				if (x.sortNum.CompareTo(y.sortNum) < 0)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
				return result;
			});
		}

		// Token: 0x0600F279 RID: 62073 RVA: 0x004167AD File Offset: 0x00414BAD
		public string GetLoadingIconPath()
		{
			if (this.FinalLoginPushList != null && this.FinalLoginPushList.Count != 0)
			{
				return this.GetFirstEffectiveIconPath();
			}
			return string.Empty;
		}

		// Token: 0x0600F27A RID: 62074 RVA: 0x004167D8 File Offset: 0x00414BD8
		private string GetFirstEffectiveIconPath()
		{
			for (int i = 0; i < this.FinalLoginPushList.Count; i++)
			{
				if (this.FinalLoginPushList[i].sortNum > 0 && this.FinalLoginPushList[i].unlockLevel <= DataManager<PlayerBaseData>.GetInstance().Level)
				{
					return this.FinalLoginPushList[i].loadingIconPath;
				}
			}
			return string.Empty;
		}

		// Token: 0x0600F27B RID: 62075 RVA: 0x00416854 File Offset: 0x00414C54
		public string GetPushIconPath()
		{
			if (this.PushIndexIsOutOfRange())
			{
				Logger.LogErrorFormat("PushIndex is out of range", new object[0]);
				return string.Empty;
			}
			return this.FinalLoginPushList[this.PushIndex].iconPath;
		}

		// Token: 0x0600F27C RID: 62076 RVA: 0x00416890 File Offset: 0x00414C90
		public bool IsSetNative()
		{
			if (this.PushIndexIsOutOfRange())
			{
				return false;
			}
			int isSetNative = this.FinalLoginPushList[this.PushIndex].IsSetNative;
			return isSetNative == 1;
		}

		// Token: 0x0600F27D RID: 62077 RVA: 0x004168C8 File Offset: 0x00414CC8
		public string GetPushTime()
		{
			if (this.PushIndexIsOutOfRange())
			{
				return null;
			}
			if (this.FinalLoginPushList[this.PushIndex].needTime)
			{
				return Function.GetMonthDate(this.FinalLoginPushList[this.PushIndex].startTime, this.FinalLoginPushList[this.PushIndex].endTime);
			}
			return null;
		}

		// Token: 0x0600F27E RID: 62078 RVA: 0x00416930 File Offset: 0x00414D30
		public Type GetCurrAdsDataFrameType(string framelink)
		{
			if (string.IsNullOrEmpty(framelink))
			{
				return null;
			}
			Regex regex = new Regex("<type=framename value=(.+)>");
			if (!regex.IsMatch(framelink))
			{
				return null;
			}
			Match match = regex.Match(framelink);
			if (!string.IsNullOrEmpty(match.Groups[0].Value))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				return executingAssembly.GetType(match.Groups[1].Value);
			}
			return null;
		}

		// Token: 0x0600F27F RID: 62079 RVA: 0x004169AC File Offset: 0x00414DAC
		public Type getLinkType()
		{
			if (this.PushIndexIsOutOfRange())
			{
				return null;
			}
			return this.GetCurrAdsDataFrameType(this.FinalLoginPushList[this.PushIndex].linkInfo);
		}

		// Token: 0x0600F280 RID: 62080 RVA: 0x004169E4 File Offset: 0x00414DE4
		private bool CheckFramesOpen(Type frameType)
		{
			if (frameType == null)
			{
				return false;
			}
			if (frameType == typeof(ActivityJarFrame))
			{
				bool flag = DataManager<JarDataManager>.GetInstance().HasActivityJar() && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.ActivityJar);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600F281 RID: 62081 RVA: 0x00416A2C File Offset: 0x00414E2C
		public bool EffectiveData()
		{
			if (this.PushIndexIsOutOfRange())
			{
				Logger.LogErrorFormat("PushIndex is out of range", new object[0]);
				return false;
			}
			if (this.FinalLoginPushList[this.PushIndex].linkInfo != string.Empty && this.FinalLoginPushList[this.PushIndex].linkInfo != "-")
			{
				Type currAdsDataFrameType = this.GetCurrAdsDataFrameType(this.FinalLoginPushList[this.PushIndex].linkInfo);
				if (!this.CheckFramesOpen(currAdsDataFrameType))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600F282 RID: 62082 RVA: 0x00416ACC File Offset: 0x00414ECC
		private void OpenLoginPushFrame()
		{
			if (!this.IsFirstLogin())
			{
				if (this.Callback != null)
				{
					this.Callback();
					this.Callback = null;
				}
				return;
			}
			if (this.PushIndexIsOutOfRange())
			{
				return;
			}
			this.TimeIntrval = 0f;
			this.OpenNextPush = true;
		}

		// Token: 0x0600F283 RID: 62083 RVA: 0x00416B20 File Offset: 0x00414F20
		private void FliterFinalLoginPushList()
		{
			this.FinalLoginPushList.Clear();
			for (int i = 0; i < this.LoginPushList.Count; i++)
			{
				if (!(this.LoginPushList[i].iconPath == "-") && !(this.LoginPushList[i].iconPath == string.Empty))
				{
					if (this.LoginPushList[i].unlockLevel <= DataManager<PlayerBaseData>.GetInstance().Level)
					{
						this.FinalLoginPushList.Add(this.LoginPushList[i]);
					}
				}
			}
		}

		// Token: 0x0600F284 RID: 62084 RVA: 0x00416BD5 File Offset: 0x00414FD5
		public int getUnlockLevel()
		{
			if (this.PushIndexIsOutOfRange())
			{
				return 0;
			}
			return (int)this.FinalLoginPushList[this.PushIndex].unlockLevel;
		}

		// Token: 0x0600F285 RID: 62085 RVA: 0x00416BFA File Offset: 0x00414FFA
		public void SetFirstRoot(bool flag)
		{
			this.FirstRoot = flag;
		}

		// Token: 0x0600F286 RID: 62086 RVA: 0x00416C03 File Offset: 0x00415003
		public bool IsFirstLogin()
		{
			return this.FirstRoot;
		}

		// Token: 0x0600F287 RID: 62087 RVA: 0x00416C0C File Offset: 0x0041500C
		public void TryOpenLoginPushFrame()
		{
			if (this.PushIndex == 0)
			{
				this.FliterFinalLoginPushList();
			}
			if (this.PushIndexIsOutOfRange())
			{
				if (this.Callback != null)
				{
					this.Callback();
					this.Callback = null;
				}
				return;
			}
			if (!this.EffectiveData())
			{
				return;
			}
			if (this.getUnlockLevel() > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				return;
			}
			this.OpenLoginPushFrame();
		}

		// Token: 0x0600F288 RID: 62088 RVA: 0x00416C7C File Offset: 0x0041507C
		private void OnSyncPlayerLoginStatus(MsgDATA msg)
		{
			SyncPlayerLoginStatus syncPlayerLoginStatus = new SyncPlayerLoginStatus();
			syncPlayerLoginStatus.decode(msg.bytes);
			if (syncPlayerLoginStatus.playerLoginStatus == 1)
			{
				this.SetFirstRoot(true);
				this.HavePush = true;
			}
			else
			{
				this.SetFirstRoot(false);
				this.HavePush = false;
			}
		}

		// Token: 0x0600F289 RID: 62089 RVA: 0x00416CC8 File Offset: 0x004150C8
		public void OnUpdate(float timeElapsed)
		{
			if (this.OpenNextPush)
			{
				this.TimeIntrval += timeElapsed;
				if (this.TimeIntrval > 0.3f && !this.PushIndexIsOutOfRange())
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<LoginPushFrame>(FrameLayer.Middle, null, string.Empty);
					this.OpenNextPush = false;
					this.PushIndex++;
					this.TimeIntrval = 0f;
				}
			}
		}

		// Token: 0x0600F28A RID: 62090 RVA: 0x00416D3B File Offset: 0x0041513B
		private bool PushIndexIsOutOfRange()
		{
			return this.PushIndex < 0 || this.PushIndex >= this.FinalLoginPushList.Count;
		}

		// Token: 0x040094FC RID: 38140
		private int PushIndex;

		// Token: 0x040094FD RID: 38141
		private bool FirstRoot;

		// Token: 0x040094FE RID: 38142
		public bool HavePush;

		// Token: 0x040094FF RID: 38143
		private bool OpenNextPush;

		// Token: 0x04009500 RID: 38144
		private float TimeIntrval;

		// Token: 0x04009501 RID: 38145
		public List<LoginPushManager.LoginPushData> LoginPushList = new List<LoginPushManager.LoginPushData>();

		// Token: 0x04009502 RID: 38146
		private List<LoginPushManager.LoginPushData> FinalLoginPushList = new List<LoginPushManager.LoginPushData>();

		// Token: 0x04009503 RID: 38147
		private LoginPushManager.FinishCallBack callback;

		// Token: 0x02001807 RID: 6151
		// (Invoke) Token: 0x0600F28D RID: 62093
		public delegate void FinishCallBack();

		// Token: 0x02001808 RID: 6152
		public class LoginPushData
		{
			// Token: 0x04009505 RID: 38149
			public string name;

			// Token: 0x04009506 RID: 38150
			public string iconPath;

			// Token: 0x04009507 RID: 38151
			public string linkInfo;

			// Token: 0x04009508 RID: 38152
			public string loadingIconPath;

			// Token: 0x04009509 RID: 38153
			public byte sortNum;

			// Token: 0x0400950A RID: 38154
			public ushort unlockLevel;

			// Token: 0x0400950B RID: 38155
			public int IsSetNative;

			// Token: 0x0400950C RID: 38156
			public int startTime;

			// Token: 0x0400950D RID: 38157
			public int endTime;

			// Token: 0x0400950E RID: 38158
			public bool needTime;
		}
	}
}
