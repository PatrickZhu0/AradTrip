using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020010F5 RID: 4341
	public sealed class ClientReconnectManager : Singleton<ClientReconnectManager>, IClientNet
	{
		// Token: 0x0600A458 RID: 42072 RVA: 0x0021CA03 File Offset: 0x0021AE03
		public void Clear()
		{
			this.mState = ClientReconnectManager.eState.onNormal;
			this.mLastReconnectType = ServerType.INVALID;
			this.canReconnectGate = false;
			this.canReconnectRelay = false;
			this.canRelogin = false;
			this.mDisconnectQueue.Clear();
		}

		// Token: 0x0600A459 RID: 42073 RVA: 0x0021CA33 File Offset: 0x0021AE33
		public override void Init()
		{
			this.Clear();
		}

		// Token: 0x0600A45A RID: 42074 RVA: 0x0021CA3B File Offset: 0x0021AE3B
		public override void UnInit()
		{
			this.Clear();
		}

		// Token: 0x170019A8 RID: 6568
		// (get) Token: 0x0600A45B RID: 42075 RVA: 0x0021CA43 File Offset: 0x0021AE43
		// (set) Token: 0x0600A45C RID: 42076 RVA: 0x0021CA4B File Offset: 0x0021AE4B
		public bool canRelogin
		{
			get
			{
				return this.mCanRelogin;
			}
			set
			{
				this.mCanRelogin = value;
			}
		}

		// Token: 0x170019A9 RID: 6569
		// (get) Token: 0x0600A45D RID: 42077 RVA: 0x0021CA54 File Offset: 0x0021AE54
		// (set) Token: 0x0600A45E RID: 42078 RVA: 0x0021CA5C File Offset: 0x0021AE5C
		public bool canReconnectRelay
		{
			get
			{
				return this.mCanReconnectRelay;
			}
			set
			{
				this.mCanReconnectRelay = value;
			}
		}

		// Token: 0x170019AA RID: 6570
		// (get) Token: 0x0600A45F RID: 42079 RVA: 0x0021CA65 File Offset: 0x0021AE65
		// (set) Token: 0x0600A460 RID: 42080 RVA: 0x0021CA6D File Offset: 0x0021AE6D
		public bool canReconnectGate
		{
			get
			{
				return this.mCanReconnectGate;
			}
			set
			{
				this.mCanReconnectGate = value;
			}
		}

		// Token: 0x0600A461 RID: 42081 RVA: 0x0021CA76 File Offset: 0x0021AE76
		public void ResumeTimeOut()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._forceQuit2Login());
		}

		// Token: 0x0600A462 RID: 42082 RVA: 0x0021CA89 File Offset: 0x0021AE89
		public void OnDisconnect(ServerType type)
		{
			if (this.mState == ClientReconnectManager.eState.onNormal)
			{
				this.mState = ClientReconnectManager.eState.onReconnect;
				this.mLastReconnectType = type;
				this._OnDisconnect(type);
			}
			else
			{
				this.mDisconnectQueue.Add(type);
			}
		}

		// Token: 0x0600A463 RID: 42083 RVA: 0x0021CABC File Offset: 0x0021AEBC
		private bool IsNeedResendMainRoleLoadRate()
		{
			if (BattleMain.mode == eDungeonMode.SyncFrame)
			{
				if (Singleton<ClientSystemManager>.GetInstance() == null)
				{
					return false;
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<DungeonLoadingFrame>(null) || Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkLoadingFrame>(null) || Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Dungeon3v3LoadingFrame>(null))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A464 RID: 42084 RVA: 0x0021CB14 File Offset: 0x0021AF14
		private void _OnDisconnect(ServerType type)
		{
			if (type != ServerType.RELAY_SERVER)
			{
				if (type != ServerType.GATE_SERVER)
				{
					this.OnReconnect();
				}
				else if (this.canRelogin)
				{
					this.OnReconnect();
					if (!ClientSystemLoginUtility.IsLogining())
					{
						ClientSystemLoginUtility.StartLoginAfterVerify();
					}
				}
				else if (this.canReconnectGate)
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._reconnectGateServer());
				}
				else
				{
					this.OnReconnect();
				}
			}
			else if (this.canReconnectRelay)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._reconnectRelayServer());
			}
			else
			{
				this.OnReconnect();
			}
		}

		// Token: 0x0600A465 RID: 42085 RVA: 0x0021CBC4 File Offset: 0x0021AFC4
		private bool _updateDisconnectQueue()
		{
			if (this.mState == ClientReconnectManager.eState.onNormal)
			{
				this.mDisconnectQueue.RemoveAll((ServerType x) => x == this.mLastReconnectType);
				this.mLastReconnectType = ServerType.INVALID;
				int count = this.mDisconnectQueue.Count;
				if (count > 0)
				{
					ServerType type = this.mDisconnectQueue[count - 1];
					this.mDisconnectQueue.RemoveAt(count - 1);
					this.OnDisconnect(type);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A466 RID: 42086 RVA: 0x0021CC35 File Offset: 0x0021B035
		public void OnReconnect()
		{
			if (this.mState == ClientReconnectManager.eState.onReconnect)
			{
				this.mState = ClientReconnectManager.eState.onNormal;
				this._tryPauseBattle(false);
				this._updateDisconnectQueue();
			}
		}

		// Token: 0x0600A467 RID: 42087 RVA: 0x0021CC58 File Offset: 0x0021B058
		public void OnReconnectError()
		{
			this.mState = ClientReconnectManager.eState.onError;
		}

		// Token: 0x0600A468 RID: 42088 RVA: 0x0021CC64 File Offset: 0x0021B064
		private void _tryPauseBattle(bool pause)
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (BattleMain.instance.GetDungeonManager() == null)
			{
				return;
			}
			if (pause)
			{
				BattleMain.instance.GetDungeonManager().PauseFight(true, "ClientReconnect", false);
			}
			else
			{
				BattleMain.instance.GetDungeonManager().ResumeFight(true, "ClientReconnect", false);
			}
		}

		// Token: 0x0600A469 RID: 42089 RVA: 0x0021CCC4 File Offset: 0x0021B0C4
		private IEnumerator _reconnectGateServerEnd()
		{
			this.OnReconnect();
			yield break;
		}

		// Token: 0x0600A46A RID: 42090 RVA: 0x0021CCE0 File Offset: 0x0021B0E0
		private IEnumerator _reconnectGateServerProcess()
		{
			for (int i = 0; i < 33; i++)
			{
				yield return null;
			}
			this._tryPauseBattle(true);
			bool isUserCancel = false;
			while (!isUserCancel)
			{
				WaitServerConnected waitConnect = new WaitServerConnected(ServerType.GATE_SERVER, ClientApplication.gateServer.ip, ClientApplication.gateServer.port, 0U, 4f, 3, 1f);
				yield return waitConnect;
				if (waitConnect.GetResult() == WaitServerConnected.eResult.Success)
				{
					break;
				}
				bool waitClick = false;
				SystemNotifyManager.SystemNotifyOkCancel(8503, delegate
				{
					waitClick = true;
				}, delegate
				{
					waitClick = true;
					isUserCancel = true;
				}, FrameLayer.TopMost, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DisConnect, null, null, null, null);
				while (!waitClick)
				{
					yield return null;
				}
			}
			if (isUserCancel)
			{
				yield return new NormalCustomEnumError(string.Format("[net] 用户取消重连，返回登录 {0}:{1}", ClientApplication.gateServer.ip, ClientApplication.gateServer.port), eEnumError.UserCancelReconnect2Login);
				yield break;
			}
			GateReconnectGameReq req = new GateReconnectGameReq
			{
				roleId = DataManager<PlayerBaseData>.GetInstance().RoleID,
				sequence = NetProcess.Instance().recvMaxSequence,
				accid = ClientApplication.playerinfo.accid,
				session = ClientApplication.playerinfo.hashValue
			};
			MessageEvents events = new MessageEvents();
			GateReconnectGameRes res = new GateReconnectGameRes();
			yield return MessageUtility.Wait<GateReconnectGameReq, GateReconnectGameRes>(ServerType.GATE_SERVER, events, req, res, true, 20f);
			if (events.IsAllMessageReceived())
			{
				if (res.result != 0U)
				{
					if (res.result == 1600003U)
					{
						yield return new NormalCustomEnumError(string.Format("[net] 玩家已经在线 {0}", res.result), eEnumError.ReconnectPlayerOnline);
					}
					else if (res.result == 1600001U)
					{
						yield return new NormalCustomEnumError(string.Format("[net] 玩家已经离线 {0}", res.result), eEnumError.ReconnectPlayerOffline);
					}
					else if (res.result == 1600002U)
					{
						yield return new NormalCustomEnumError(string.Format("[net] 重连发送的Seq无效 {0}", res.result), eEnumError.ReconnectPlayerInvalidSequence);
					}
					else
					{
						yield return new NormalCustomEnumError(string.Format("[net] 重连消息超时 {0}", res.result), eEnumError.ReconnectOtherError);
						SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
					}
					yield break;
				}
				if (!NetManager.Instance().ReSendCommand(res.lastRecvSequence))
				{
					NetManager.Instance().ClearReSendData();
					yield return new NormalCustomEnumError(string.Format("[net] 重连后重发消息失败 sequence:{0}", res.lastRecvSequence), eEnumError.ProcessError);
					yield break;
				}
				NetManager.Instance().OnCanSendData(ServerType.GATE_SERVER);
			}
			else
			{
				yield return new NormalCustomEnumError(string.Format("[net] 重连消息超时 GateReconnectGameRes {0}", res.result), eEnumError.ProcessError);
			}
			yield break;
		}

		// Token: 0x0600A46B RID: 42091 RVA: 0x0021CCFC File Offset: 0x0021B0FC
		private IEnumerator _reconnectServerErrorHandle(eEnumError error, string msg)
		{
			Logger.LogErrorFormat("{0}, {1}", new object[]
			{
				error,
				msg
			});
			this.OnReconnectError();
			switch (error)
			{
			case eEnumError.NetworkErrorDisconnect:
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8401);
				break;
			case eEnumError.ProcessError:
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8402);
				break;
			case eEnumError.ReconnectPlayerOnline:
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8405);
				break;
			case eEnumError.ReconnectPlayerOffline:
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8406);
				break;
			case eEnumError.ReconnectPlayerInvalidSequence:
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8403);
				break;
			case eEnumError.ReconnectOtherError:
				Singleton<ClientSystemManager>.instance.QuitToLoginSystem(8404);
				break;
			case eEnumError.UserCancelReconnect2Login:
			case eEnumError.ReloginFail:
			case eEnumError.ResumeTimeOut:
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._forceQuit2Login());
				break;
			}
			yield break;
		}

		// Token: 0x0600A46C RID: 42092 RVA: 0x0021CD28 File Offset: 0x0021B128
		private IEnumerator _forceQuit2Login()
		{
			yield return null;
			Singleton<ClientSystemManager>.instance._QuitToLoginImpl();
			yield break;
		}

		// Token: 0x0600A46D RID: 42093 RVA: 0x0021CD3C File Offset: 0x0021B13C
		private IEnumerator _reconnectGateServer()
		{
			IEnumerator process = this._reconnectGateServerProcess();
			ThreeStepProcess threeStepProcess = new ThreeStepProcess("ReconnectGateServer", Singleton<ClientSystemManager>.instance.enumeratorManager, process, null, this._reconnectGateServerEnd());
			threeStepProcess.SetErrorProcessHandle(new ThreeStepProcess.ErrorProcessHandle(this._reconnectServerErrorHandle));
			return threeStepProcess;
		}

		// Token: 0x0600A46E RID: 42094 RVA: 0x0021CD80 File Offset: 0x0021B180
		private IEnumerator _reconnectRelayServerProcess()
		{
			this._tryPauseBattle(true);
			for (int i = 0; i < 33; i++)
			{
				yield return null;
			}
			bool isUserCancel = false;
			while (!isUserCancel)
			{
				WaitServerConnected waitConnect = new WaitServerConnected(ServerType.RELAY_SERVER, ClientApplication.relayServer.ip, ClientApplication.relayServer.port, ClientApplication.playerinfo.accid, 4f, 3, 1f);
				yield return waitConnect;
				if (waitConnect.GetResult() == WaitServerConnected.eResult.Success)
				{
					break;
				}
				bool waitClick = false;
				SystemNotifyManager.SystemNotifyOkCancel(8503, delegate
				{
					waitClick = true;
				}, delegate
				{
					waitClick = true;
					isUserCancel = true;
				}, FrameLayer.TopMost, false);
				while (!waitClick)
				{
					yield return null;
				}
			}
			if (isUserCancel)
			{
				yield return new NormalCustomEnumError(string.Format("[net] 用户取消重连，返回登录", new object[0]), eEnumError.UserCancelReconnect2Login);
				yield break;
			}
			if (BattleMain.instance == null)
			{
				yield return new NormalCustomEnumError(string.Format("[net] relay 异常返回 BattleMain.instance == null", new object[0]), eEnumError.ProcessError);
				yield break;
			}
			if (BattleMain.instance.GetPlayerManager() == null)
			{
				yield return new NormalCustomEnumError(string.Format("[net] relay 异常返回 BattleMain.instance.GetPlayerManager() == null", new object[0]), eEnumError.ProcessError);
				yield break;
			}
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
			{
				yield return new NormalCustomEnumError(string.Format("[net] relay 异常返回 BattleMain.instance.GetPlayerManager().GetMainPlayer() == null", new object[0]), eEnumError.ProcessError);
				yield break;
			}
			RelaySvrReconnectReq req = new RelaySvrReconnectReq
			{
				accid = ClientApplication.playerinfo.accid,
				lastFrame = (ulong)FrameSync.instance.lastSvrFrame,
				seat = mainPlayer.playerInfo.seat,
				roleid = DataManager<PlayerBaseData>.GetInstance().RoleID,
				session = ClientApplication.playerinfo.session
			};
			MessageEvents msg = new MessageEvents();
			RelaySvrReconnectRes res = new RelaySvrReconnectRes();
			yield return MessageUtility.Wait<RelaySvrReconnectReq, RelaySvrReconnectRes>(ServerType.RELAY_SERVER, msg, req, res, true, 10f);
			if (!msg.IsAllMessageReceived())
			{
				yield return new NormalCustomEnumError(string.Format("[net] relay超时", new object[0]), eEnumError.ProcessError);
				yield break;
			}
			if (res.result != 0U)
			{
				yield return new NormalCustomEnumError(string.Format("[net] relay 异常返回", new object[0]), eEnumError.ProcessError);
				yield break;
			}
			if (this.IsNeedResendMainRoleLoadRate() && BattleMain.instance != null)
			{
				BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
				if (baseBattle != null && baseBattle.dungeonPlayerManager != null)
				{
					DungeonPlayerDataManager dungeonPlayerDataManager = baseBattle.dungeonPlayerManager as DungeonPlayerDataManager;
					if (dungeonPlayerDataManager != null)
					{
						dungeonPlayerDataManager.SendMainPlayerLoadRate((int)dungeonPlayerDataManager.LoadingRate);
					}
				}
			}
			yield break;
		}

		// Token: 0x0600A46F RID: 42095 RVA: 0x0021CD9C File Offset: 0x0021B19C
		private IEnumerator _reconnectRelayServer()
		{
			IEnumerator process = this._reconnectRelayServerProcess();
			ThreeStepProcess threeStepProcess = new ThreeStepProcess("ReconnectRelayServer", Singleton<ClientSystemManager>.instance.enumeratorManager, process, null, this._reconnectGateServerEnd());
			threeStepProcess.SetErrorProcessHandle(new ThreeStepProcess.ErrorProcessHandle(this._reconnectServerErrorHandle));
			return threeStepProcess;
		}

		// Token: 0x04005BDF RID: 23519
		private ClientReconnectManager.eState mState;

		// Token: 0x04005BE0 RID: 23520
		private List<ServerType> mDisconnectQueue = new List<ServerType>();

		// Token: 0x04005BE1 RID: 23521
		private ServerType mLastReconnectType;

		// Token: 0x04005BE2 RID: 23522
		private bool mCanRelogin;

		// Token: 0x04005BE3 RID: 23523
		private bool mCanReconnectRelay;

		// Token: 0x04005BE4 RID: 23524
		private bool mCanReconnectGate;

		// Token: 0x04005BE5 RID: 23525
		private const int kReconnectWaitGapFrameCount = 33;

		// Token: 0x020010F6 RID: 4342
		public enum eState
		{
			// Token: 0x04005BE7 RID: 23527
			onNormal,
			// Token: 0x04005BE8 RID: 23528
			onReconnect,
			// Token: 0x04005BE9 RID: 23529
			onError
		}
	}
}
