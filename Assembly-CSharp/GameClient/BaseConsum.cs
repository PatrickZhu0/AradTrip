using System;
using System.Diagnostics;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x02000F58 RID: 3928
	internal class BaseConsum
	{
		// Token: 0x060098A4 RID: 39076 RVA: 0x001D5896 File Offset: 0x001D3C96
		public BaseConsum(ClientFrameBinder comFrameBinder)
		{
			this.comFrameBinder = comFrameBinder;
		}

		// Token: 0x060098A5 RID: 39077 RVA: 0x001D58B1 File Offset: 0x001D3CB1
		public void OnCloseLinkFrame()
		{
			if (this.comFrameBinder != null)
			{
				this.comFrameBinder.CloseFrame(true);
			}
		}

		// Token: 0x17001926 RID: 6438
		// (get) Token: 0x060098A6 RID: 39078 RVA: 0x001D58D0 File Offset: 0x001D3CD0
		// (set) Token: 0x060098A7 RID: 39079 RVA: 0x001D58D8 File Offset: 0x001D3CD8
		public ulong sumCnt
		{
			get
			{
				return this.mSumCnt;
			}
			protected set
			{
				this.mSumCnt = value;
			}
		}

		// Token: 0x17001927 RID: 6439
		// (get) Token: 0x060098A8 RID: 39080 RVA: 0x001D58E1 File Offset: 0x001D3CE1
		// (set) Token: 0x060098A9 RID: 39081 RVA: 0x001D58E9 File Offset: 0x001D3CE9
		public ulong cnt
		{
			get
			{
				return this.mCnt;
			}
			protected set
			{
				this.mCnt = value;
			}
		}

		// Token: 0x060098AA RID: 39082 RVA: 0x001D58F2 File Offset: 0x001D3CF2
		public EUIEventID[] WatchEvents()
		{
			return this.mEvents;
		}

		// Token: 0x060098AB RID: 39083 RVA: 0x001D58FA File Offset: 0x001D3CFA
		public ulong GetCount()
		{
			return this.cnt;
		}

		// Token: 0x060098AC RID: 39084 RVA: 0x001D5902 File Offset: 0x001D3D02
		public ulong GetSumCount()
		{
			return this.sumCnt;
		}

		// Token: 0x060098AD RID: 39085 RVA: 0x001D590C File Offset: 0x001D3D0C
		[Conditional("UNITY_EDITOR")]
		protected void _send_gm(string msg)
		{
			SceneChat cmd = new SceneChat
			{
				channel = 1,
				targetId = 0UL,
				word = string.Format("!!{0}", msg)
			};
			MonoSingleton<NetManager>.instance.SendCommand<SceneChat>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x04004EB3 RID: 20147
		public ClientFrameBinder comFrameBinder;

		// Token: 0x04004EB4 RID: 20148
		private ulong mSumCnt;

		// Token: 0x04004EB5 RID: 20149
		private ulong mCnt;

		// Token: 0x04004EB6 RID: 20150
		protected EUIEventID[] mEvents = new EUIEventID[0];
	}
}
