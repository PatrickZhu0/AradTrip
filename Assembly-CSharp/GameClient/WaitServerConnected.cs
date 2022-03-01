using System;
using System.Collections;
using Network;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E43 RID: 3651
	public class WaitServerConnected : BaseCustomEnum<WaitServerConnected.eResult>, IEnumerator
	{
		// Token: 0x0600917B RID: 37243 RVA: 0x001AEE84 File Offset: 0x001AD284
		public WaitServerConnected(ServerType type, string ip, ushort port, uint accid, float time = 4f, int reconnectcnt = 3, float gaptime = 1f)
		{
			this.mServerType = type;
			this.mWaitTime = time;
			this.mGapTime = gaptime;
			this.mTickTime = time;
			this.mAccid = accid;
			this.mPort = port;
			this.mIp = ip;
			this.mReCnt = reconnectcnt;
			this.mState = WaitServerConnected.eState.None;
			this.mResult = WaitServerConnected.eResult.Invalid;
		}

		// Token: 0x170018EA RID: 6378
		// (get) Token: 0x0600917C RID: 37244 RVA: 0x001AEF15 File Offset: 0x001AD315
		public object Current
		{
			get
			{
				return this.mState;
			}
		}

		// Token: 0x0600917D RID: 37245 RVA: 0x001AEF22 File Offset: 0x001AD322
		private void _connectGateServer(string ip, ushort port)
		{
			MonoSingleton<NetManager>.instance.ConnectToGateServerAsync(ip, port, 4000U, delegate(bool s)
			{
				if (s)
				{
					this.mResult = WaitServerConnected.eResult.Success;
				}
				else
				{
					this.mResult = WaitServerConnected.eResult.Fail;
				}
			});
		}

		// Token: 0x0600917E RID: 37246 RVA: 0x001AEF41 File Offset: 0x001AD341
		private void _connectAdminServer(string ip, ushort port)
		{
			MonoSingleton<NetManager>.instance.ConnectToAdmainServerAsync(ip, port, 4000U, delegate(bool s)
			{
				if (s)
				{
					this.mResult = WaitServerConnected.eResult.Success;
				}
				else
				{
					this.mResult = WaitServerConnected.eResult.Fail;
				}
			});
		}

		// Token: 0x0600917F RID: 37247 RVA: 0x001AEF60 File Offset: 0x001AD360
		private void _connectRelayServer(string ip, ushort port, uint accid)
		{
			bool flag = MonoSingleton<NetManager>.instance.ConnectToRelayServer(ip, port, accid, 4000U);
			if (flag)
			{
				this.mResult = WaitServerConnected.eResult.Success;
			}
			else
			{
				this.mResult = WaitServerConnected.eResult.Fail;
			}
		}

		// Token: 0x06009180 RID: 37248 RVA: 0x001AEF9C File Offset: 0x001AD39C
		public bool MoveNext()
		{
			switch (this.mState)
			{
			case WaitServerConnected.eState.None:
				WaitNetMessageFrame.TryOpen();
				this.mState = WaitServerConnected.eState.Start;
				break;
			case WaitServerConnected.eState.Start:
			{
				ServerType serverType = this.mServerType;
				if (serverType != ServerType.ADMIN_SERVER)
				{
					if (serverType != ServerType.GATE_SERVER)
					{
						if (serverType == ServerType.RELAY_SERVER)
						{
							this._connectRelayServer(this.mIp, this.mPort, this.mAccid);
						}
					}
					else
					{
						this._connectGateServer(this.mIp, this.mPort);
					}
				}
				else
				{
					this._connectAdminServer(this.mIp, this.mPort);
				}
				this.mState = WaitServerConnected.eState.Wait;
				break;
			}
			case WaitServerConnected.eState.Wait:
				if (this.mResult == WaitServerConnected.eResult.Invalid)
				{
					if (this._tryTickTime() && !this._tryNextReconnect())
					{
						this.mResult = WaitServerConnected.eResult.TimeOut;
						this.mState = WaitServerConnected.eState.Finish;
					}
				}
				else if (this.mResult != WaitServerConnected.eResult.Success)
				{
					if (!this._tryNextReconnect())
					{
						this.mState = WaitServerConnected.eState.Finish;
					}
				}
				else
				{
					this.mState = WaitServerConnected.eState.Finish;
				}
				break;
			case WaitServerConnected.eState.Gap:
				if (this._tryTickTime())
				{
					this.mState = WaitServerConnected.eState.Start;
					this.mTickTime = this.mWaitTime;
					this.mResult = WaitServerConnected.eResult.Invalid;
				}
				break;
			case WaitServerConnected.eState.Finish:
				WaitNetMessageFrame.TryClose();
				if (this.mResult == WaitServerConnected.eResult.Success)
				{
					ServerType serverType2 = this.mServerType;
					if (serverType2 != ServerType.ADMIN_SERVER)
					{
						if (serverType2 == ServerType.RELAY_SERVER)
						{
							Singleton<ClientReconnectManager>.instance.canReconnectRelay = true;
						}
					}
					else
					{
						Singleton<ClientReconnectManager>.instance.canRelogin = true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06009181 RID: 37249 RVA: 0x001AF133 File Offset: 0x001AD533
		private bool _tryTickTime()
		{
			if (this.mTickTime > 0f)
			{
				this.mTickTime -= Time.unscaledDeltaTime;
				return false;
			}
			return true;
		}

		// Token: 0x06009182 RID: 37250 RVA: 0x001AF15A File Offset: 0x001AD55A
		private bool _tryNextReconnect()
		{
			if (this.mReCnt > 0)
			{
				this.mReCnt--;
				this.mTickTime = this.mGapTime;
				this.mState = WaitServerConnected.eState.Gap;
				return true;
			}
			return false;
		}

		// Token: 0x06009183 RID: 37251 RVA: 0x001AF18C File Offset: 0x001AD58C
		public void Reset()
		{
			this.mState = WaitServerConnected.eState.None;
			this.mResult = WaitServerConnected.eResult.Invalid;
			this.mTickTime = this.mWaitTime;
		}

		// Token: 0x040048AD RID: 18605
		private const int kTimeOutSecond = 4;

		// Token: 0x040048AE RID: 18606
		private const int kGapTimeOutSecond = 1;

		// Token: 0x040048AF RID: 18607
		private const int kReconnectCount = 3;

		// Token: 0x040048B0 RID: 18608
		private const int kTimeOut = 4000;

		// Token: 0x040048B1 RID: 18609
		protected ServerType mServerType;

		// Token: 0x040048B2 RID: 18610
		protected float mWaitTime = -1f;

		// Token: 0x040048B3 RID: 18611
		protected float mGapTime = -1f;

		// Token: 0x040048B4 RID: 18612
		protected float mTickTime = -1f;

		// Token: 0x040048B5 RID: 18613
		protected string mIp = string.Empty;

		// Token: 0x040048B6 RID: 18614
		protected ushort mPort;

		// Token: 0x040048B7 RID: 18615
		protected uint mAccid;

		// Token: 0x040048B8 RID: 18616
		protected int mReCnt;

		// Token: 0x040048B9 RID: 18617
		private WaitServerConnected.eState mState = WaitServerConnected.eState.Start;

		// Token: 0x02000E44 RID: 3652
		public enum eResult
		{
			// Token: 0x040048BB RID: 18619
			Invalid,
			// Token: 0x040048BC RID: 18620
			TimeOut,
			// Token: 0x040048BD RID: 18621
			Success,
			// Token: 0x040048BE RID: 18622
			Fail
		}

		// Token: 0x02000E45 RID: 3653
		private enum eState
		{
			// Token: 0x040048C0 RID: 18624
			None,
			// Token: 0x040048C1 RID: 18625
			Start,
			// Token: 0x040048C2 RID: 18626
			Wait,
			// Token: 0x040048C3 RID: 18627
			Gap,
			// Token: 0x040048C4 RID: 18628
			Finish
		}
	}
}
