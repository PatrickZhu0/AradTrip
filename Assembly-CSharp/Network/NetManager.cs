using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using GameClient;
using Protocol;
using UnityEngine;

namespace Network
{
	// Token: 0x020001C2 RID: 450
	public class NetManager : MonoSingleton<NetManager>
	{
		// Token: 0x06000E4F RID: 3663 RVA: 0x000497BC File Offset: 0x00047BBC
		public void RecordSendedMsg(string content)
		{
			if (this.recordSendedMsg.Count >= 100)
			{
				this.recordSendedMsg.RemoveAt(0);
			}
			this.recordSendedMsg.Add(content);
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x000497E8 File Offset: 0x00047BE8
		public void RecordReceivedMsg(MsgDATA data)
		{
			if (this.recordReceivedMsg.Count >= 100)
			{
				this.recordReceivedMsg.RemoveAt(0);
			}
			this.recordReceivedMsg.Add(string.Format("msg:{0}({1})", Singleton<ProtocolHelper>.instance.GetName(data.id), data.id));
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x00049843 File Offset: 0x00047C43
		public static NetManager Instance()
		{
			return MonoSingleton<NetManager>.instance;
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x0004984A File Offset: 0x00047C4A
		public void SetIsTcp(bool useTcpRelay)
		{
			this.isTcpRelay = useTcpRelay;
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00049854 File Offset: 0x00047C54
		public sealed override void Init()
		{
			Object.DontDestroyOnLoad(base.gameObject);
			NetOutputBuffer.Init(10);
			this.cli2AdminServer = new NetworkSocket(ServerType.ADMIN_SERVER);
			this.cli2GateServer = new NetworkSocket(ServerType.GATE_SERVER);
			this.cli2RelayServer = new UdpClient(ServerType.RELAY_SERVER);
			this.cli2TcpRelayServer = new NetworkSocket(ServerType.RELAY_SERVER);
			this.socketEvents = new Queue<SocketEvent>();
			this.reSendMsgIDList = new Dictionary<uint, uint>();
			this.InitReSendMsgs();
			NetProcess.Instance().Init();
			this.RegisterBaseHandler();
			Singleton<ProtocolHelper>.CreateInstance(true);
			this.mCurNetworkState = Application.internetReachability;
			this.mStateChangeTime = 0L;
			this.bInit = true;
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x000498F8 File Offset: 0x00047CF8
		// (set) Token: 0x06000E54 RID: 3668 RVA: 0x000498EF File Offset: 0x00047CEF
		public bool AllowForceReconnect
		{
			get
			{
				return this.m_AllowForceReconnect;
			}
			set
			{
				this.m_AllowForceReconnect = value;
			}
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x00049900 File Offset: 0x00047D00
		private bool _isTimeNeedReconnect()
		{
			return this.mResumeFregroundTime - this.mEnterBackgroundTime > this.kNeedReconnectGapTime;
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x00049917 File Offset: 0x00047D17
		private bool _isResumeTimeOut()
		{
			return this.mResumeFregroundTime - this.mEnterBackgroundTime > this.kResumeTime;
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x00049930 File Offset: 0x00047D30
		private void InitReSendMsgs()
		{
			this.SetMsgNeedReSend(606809U);
			this.SetMsgNeedReSend(506807U);
			this.SetMsgNeedReSend(606811U);
			this.SetMsgNeedReSend(506821U);
			this.SetMsgNeedReSend(1300008U);
			this.SetMsgNeedReSend(506811U);
			this.SetMsgNeedReSend(300306U);
			this.SetMsgNeedReSend(506819U);
			this.SetMsgNeedReSend(506809U);
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x000499A0 File Offset: 0x00047DA0
		public void SetMsgNeedReSend(uint msgId)
		{
			uint num;
			if (this.reSendMsgIDList.TryGetValue(msgId, out num))
			{
				return;
			}
			this.reSendMsgIDList.Add(msgId, 0U);
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x000499CE File Offset: 0x00047DCE
		public void Awake()
		{
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x000499D0 File Offset: 0x00047DD0
		public void OnEnable()
		{
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x000499D2 File Offset: 0x00047DD2
		public void OnDisable()
		{
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x000499D4 File Offset: 0x00047DD4
		protected sealed override void OnDestroy()
		{
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x000499D8 File Offset: 0x00047DD8
		public void OnApplicationPause(bool pause)
		{
			if (pause)
			{
				this.mEnterBackgroundTime = Time.realtimeSinceStartup;
			}
			else
			{
				this.mResumeFregroundTime = Time.realtimeSinceStartup;
				if (!this.cli2RelayServer.IsConnected())
				{
					this.cli2RelayServer.Reset();
				}
				if (this._isResumeTimeOut())
				{
					Singleton<ClientReconnectManager>.instance.ResumeTimeOut();
				}
				if (this._isTimeNeedReconnect())
				{
					this.cli2RelayServer.Disconnect();
					MonoSingleton<NetManager>.instance.PushSocketEvent(ServerType.RELAY_SERVER, SocketEventType.DISCONNECT, 0U, 0U);
				}
			}
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x00049A5A File Offset: 0x00047E5A
		private void _tryForceDisconnectServer()
		{
			if (this._canForceDisconnectServer())
			{
				this.cli2GateServer.Disconnect();
				MonoSingleton<NetManager>.instance.PushSocketEvent(ServerType.GATE_SERVER, SocketEventType.DISCONNECT, 0U, 0U);
				this.cli2RelayServer.Disconnect();
				MonoSingleton<NetManager>.instance.PushSocketEvent(ServerType.RELAY_SERVER, SocketEventType.DISCONNECT, 0U, 0U);
			}
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x00049A99 File Offset: 0x00047E99
		public void RegisterBaseHandler()
		{
			NetProcess.AddMsgHandler(0U, new Action<MsgDATA>(this.OnHeartBeat));
			NetProcess.AddMsgHandler(300309U, new Action<MsgDATA>(this.OnRecvGateSyncServerTime));
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x00049AC4 File Offset: 0x00047EC4
		public void Update()
		{
			if (!this.bInit)
			{
				return;
			}
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (realtimeSinceStartup - NetManager.lastShowTime >= 1f)
			{
				this.Show = true;
				NetManager.lastShowTime = realtimeSinceStartup;
			}
			uint num = (uint)(Time.deltaTime * (float)GlobalLogic.VALUE_1000);
			this.cli2AdminServer.Tick();
			this.cli2GateServer.Tick();
			this.cli2RelayServer.Tick();
			NetProcess.Instance().Tick(num);
			this._updateNetworkstate(num);
			this.DispatchSocketEvent();
			this.Show = false;
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x00049B50 File Offset: 0x00047F50
		private void _updateNetworkstate(uint delta)
		{
			this.mStateChangeTime += (long)((ulong)delta);
			if (this.mStateChangeTime > 2000L)
			{
				this.mStateChangeTime = 0L;
				NetworkReachability internetReachability = Application.internetReachability;
				if (internetReachability != this.mCurNetworkState)
				{
					this.mCurNetworkState = internetReachability;
					if (this.AllowForceReconnect)
					{
						this._tryForceDisconnectServer();
					}
				}
			}
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x00049BAF File Offset: 0x00047FAF
		private bool _isNetworkReachabilityValid()
		{
			return true;
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x00049BB2 File Offset: 0x00047FB2
		public void Reset()
		{
			this.cli2RelayServer.Disconnect();
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x00049BC0 File Offset: 0x00047FC0
		public bool IsConnected(ServerType serverType)
		{
			if (!this._isNetworkReachabilityValid())
			{
				return false;
			}
			if (serverType == ServerType.ADMIN_SERVER)
			{
				return this.cli2AdminServer.IsConnected();
			}
			if (serverType == ServerType.GATE_SERVER)
			{
				return this.cli2GateServer.IsConnected();
			}
			return serverType == ServerType.RELAY_SERVER && this.cli2RelayServer.IsConnected();
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x00049C14 File Offset: 0x00048014
		public bool ConnectToAdmainServer(string ip, ushort port, uint timeout)
		{
			return this._isNetworkReachabilityValid() && this.cli2AdminServer.ConnectToServer(ip, (int)port, (int)timeout);
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x00049C31 File Offset: 0x00048031
		public void ConnectToAdmainServerAsync(string ip, ushort port, uint timeout, ConnectCallback cb)
		{
			if (!this._isNetworkReachabilityValid() && cb != null)
			{
				cb(false);
			}
			else
			{
				this.cli2AdminServer.ConnectToServerAsync(ip, (int)port, (int)timeout, cb, 0);
			}
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x00049C63 File Offset: 0x00048063
		public bool ConnectToGateServer(string ip, ushort port, uint timeout)
		{
			return this._isNetworkReachabilityValid() && this.cli2GateServer.ConnectToServer(ip, (int)port, (int)timeout);
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x00049C80 File Offset: 0x00048080
		public void ConnectToGateServerAsync(string ip, ushort port, uint timeout, ConnectCallback cb)
		{
			if (!this._isNetworkReachabilityValid() && cb != null)
			{
				cb(false);
			}
			else
			{
				this.cli2GateServer.ConnectToServerAsync(ip, (int)port, (int)timeout, cb, 0);
			}
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00049CB2 File Offset: 0x000480B2
		public bool ConnectToRelayServer(string ip, ushort port, uint accid, uint timeout)
		{
			return this._isNetworkReachabilityValid() && this.cli2RelayServer.Connect(ip, port, accid, timeout);
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00049CD4 File Offset: 0x000480D4
		public int SendCommand<CommandType>(ServerType serverType, CommandType cmd) where CommandType : IProtocolStream, IGetMsgID
		{
			int result = -1;
			if (cmd == null)
			{
				return result;
			}
			if (Global.Settings.isDebug)
			{
				this.RecordSendedMsg(string.Format("{0}({1})", cmd.GetType(), cmd.GetMsgID()));
			}
			if (serverType == ServerType.ADMIN_SERVER)
			{
				result = this.cli2AdminServer.SendCommand<CommandType>(cmd);
			}
			else if (serverType == ServerType.GATE_SERVER)
			{
				if (this.IsMsgNeedReSend(cmd.GetMsgID()))
				{
					cmd.SetSequence(this.GenSequence());
				}
				result = this.cli2GateServer.SendCommand<CommandType>(cmd);
			}
			else if (serverType == ServerType.RELAY_SERVER)
			{
				result = this.cli2RelayServer.SendCommand<CommandType>(cmd);
			}
			return result;
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x00049DA0 File Offset: 0x000481A0
		private uint GenSequence()
		{
			return this.sequenceSeed += 1U;
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x00049DBE File Offset: 0x000481BE
		public bool ReSendCommand(uint sequence)
		{
			return this.cli2GateServer == null || this.cli2GateServer.ReSendData(sequence);
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x00049DDC File Offset: 0x000481DC
		private bool IsMsgNeedReSend(uint msgid)
		{
			uint num;
			return this.reSendMsgIDList.TryGetValue(msgid, out num);
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x00049DF7 File Offset: 0x000481F7
		public void ClearReSendData()
		{
			if (this.cli2GateServer != null)
			{
				this.cli2GateServer.ClearReSendData();
			}
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x00049E0F File Offset: 0x0004820F
		public void ResetResend()
		{
			if (this.cli2GateServer != null)
			{
				this.cli2GateServer.ResetResend();
			}
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x00049E28 File Offset: 0x00048228
		public void Disconnect(ServerType serverType)
		{
			if (serverType == ServerType.ADMIN_SERVER)
			{
				this.cli2AdminServer.Disconnect();
			}
			else if (serverType == ServerType.GATE_SERVER)
			{
				this.cli2GateServer.Disconnect();
			}
			else if (serverType == ServerType.RELAY_SERVER)
			{
				this.cli2RelayServer.Disconnect();
			}
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x00049E7A File Offset: 0x0004827A
		public int GetPingToRelayServer()
		{
			return this.cli2RelayServer.Ping();
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x00049E87 File Offset: 0x00048287
		private bool _canForceDisconnectServer()
		{
			return true;
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00049E8A File Offset: 0x0004828A
		public void OnCanSendData(ServerType serverType)
		{
			if (serverType == ServerType.GATE_SERVER)
			{
				this.cli2GateServer.canSend = true;
			}
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x00049EA0 File Offset: 0x000482A0
		public void OnDisconnected(ServerType serverType)
		{
			if (serverType == ServerType.GATE_SERVER || serverType == ServerType.RELAY_SERVER)
			{
				if (serverType == ServerType.GATE_SERVER)
				{
					this.cli2GateServer.canSend = false;
				}
				if (this._canForceDisconnectServer())
				{
					IClientNet instance = Singleton<ClientReconnectManager>.instance;
					if (instance != null)
					{
						instance.OnDisconnect(serverType);
					}
				}
			}
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x00049EF1 File Offset: 0x000482F1
		private void OnConnected(ServerType serverType)
		{
			if (serverType == ServerType.ADMIN_SERVER)
			{
				this.cli2AdminServer.StartRecv();
			}
			else if (serverType == ServerType.GATE_SERVER)
			{
				this.cli2GateServer.StartRecv();
			}
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00049F1C File Offset: 0x0004831C
		private void DispatchSocketEvent()
		{
			this.socketEventsMutex.WaitOne();
			while (this.socketEvents.Count > 0)
			{
				SocketEvent socketEvent = this.socketEvents.Dequeue();
				if (socketEvent.eventType == SocketEventType.DISCONNECT)
				{
					this.OnDisconnected(socketEvent.serverType);
				}
				else if (socketEvent.eventType == SocketEventType.CONNECTED)
				{
				}
			}
			this.socketEventsMutex.ReleaseMutex();
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x00049F94 File Offset: 0x00048394
		public void PushSocketEvent(ServerType serverType, SocketEventType eventType, uint param1 = 0U, uint param2 = 0U)
		{
			SocketEvent item = new SocketEvent
			{
				serverType = serverType,
				eventType = eventType,
				param1 = param1,
				param2 = param2
			};
			this.socketEventsMutex.WaitOne();
			this.socketEvents.Enqueue(item);
			this.socketEventsMutex.ReleaseMutex();
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x00049FEF File Offset: 0x000483EF
		public void UploadUdpLogs()
		{
			this.cli2RelayServer.SendLog2Http();
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x00049FFC File Offset: 0x000483FC
		private void OnHeartBeat(MsgDATA msg)
		{
			HeartBeatMsg cmd = new HeartBeatMsg();
			NetManager.Instance().SendCommand<HeartBeatMsg>(msg.serverType, cmd);
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x0004A021 File Offset: 0x00048421
		private void OnRecvGateSyncServerTime(MsgDATA msgData)
		{
			DataManager<TimeManager>.GetInstance().OnRecvGateSyncServerTime(msgData);
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x0004A030 File Offset: 0x00048430
		[Conditional("NET_LOG")]
		public void Log(string str, params object[] args)
		{
			DateTime now = DateTime.Now;
			string str2 = string.Format("[{0}-{1}-{2} {3}:{4}:{5}:{6}] ", new object[]
			{
				now.Year,
				now.Month,
				now.Day,
				now.Hour,
				now.Minute,
				now.Second,
				now.Millisecond
			});
			string str3 = string.Format(str, args);
			this.netLogsMutex.WaitOne();
			this.netLogs.Enqueue(str2 + str3);
			this.netLogsMutex.ReleaseMutex();
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x0004A0F0 File Offset: 0x000484F0
		[Conditional("NET_LOG")]
		private void RecordLogs()
		{
			this.netLogsMutex.WaitOne();
			while (this.netLogs.Count > 0)
			{
				string log = this.netLogs.Dequeue();
				Singleton<ExceptionManager>.GetInstance().RecordLog(log);
			}
			this.netLogsMutex.ReleaseMutex();
		}

		// Token: 0x040009EE RID: 2542
		private NetworkSocket cli2AdminServer;

		// Token: 0x040009EF RID: 2543
		private NetworkSocket cli2GateServer;

		// Token: 0x040009F0 RID: 2544
		private UdpClient cli2RelayServer;

		// Token: 0x040009F1 RID: 2545
		private NetworkSocket cli2TcpRelayServer;

		// Token: 0x040009F2 RID: 2546
		private Queue<SocketEvent> socketEvents;

		// Token: 0x040009F3 RID: 2547
		private Mutex socketEventsMutex = new Mutex();

		// Token: 0x040009F4 RID: 2548
		private Queue<string> netLogs = new Queue<string>();

		// Token: 0x040009F5 RID: 2549
		private Mutex netLogsMutex = new Mutex();

		// Token: 0x040009F6 RID: 2550
		private uint sequenceSeed;

		// Token: 0x040009F7 RID: 2551
		private Dictionary<uint, uint> reSendMsgIDList;

		// Token: 0x040009F8 RID: 2552
		[HideInInspector]
		public List<string> recordSendedMsg = new List<string>();

		// Token: 0x040009F9 RID: 2553
		[HideInInspector]
		public List<string> recordReceivedMsg = new List<string>();

		// Token: 0x040009FA RID: 2554
		private bool isTcpRelay;

		// Token: 0x040009FB RID: 2555
		private bool bInit;

		// Token: 0x040009FC RID: 2556
		private bool m_AllowForceReconnect;

		// Token: 0x040009FD RID: 2557
		private NetworkReachability mCurNetworkState;

		// Token: 0x040009FE RID: 2558
		private float mEnterBackgroundTime;

		// Token: 0x040009FF RID: 2559
		private float mResumeFregroundTime;

		// Token: 0x04000A00 RID: 2560
		private float kNeedReconnectGapTime = 6f;

		// Token: 0x04000A01 RID: 2561
		private float kResumeTime = 480f;

		// Token: 0x04000A02 RID: 2562
		public bool Show;

		// Token: 0x04000A03 RID: 2563
		private static long lastTime;

		// Token: 0x04000A04 RID: 2564
		private static float lastShowTime;

		// Token: 0x04000A05 RID: 2565
		private long mStateChangeTime;

		// Token: 0x04000A06 RID: 2566
		private const long kStateLoginChange = 2000L;
	}
}
