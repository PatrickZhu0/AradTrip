using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Protocol;
using UnityEngine;

namespace Network
{
	// Token: 0x020001D6 RID: 470
	internal class UdpClient
	{
		// Token: 0x06000EF6 RID: 3830 RVA: 0x0004C988 File Offset: 0x0004AD88
		public UdpClient(ServerType type)
		{
			this.serverType = type;
			this.isConnected = false;
			this.networkThread = new Thread(new ParameterizedThreadStart(UdpClient.NetworkdThreadLoop));
			this.networkThread.Start(this);
			this.Initialize();
			UdpClient.perf = new FramePerformance();
		}

		// Token: 0x06000EF7 RID: 3831 RVA: 0x0004CA02 File Offset: 0x0004AE02
		private void Lock()
		{
			this.mutex.WaitOne();
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x0004CA10 File Offset: 0x0004AE10
		private void Unlock()
		{
			this.mutex.ReleaseMutex();
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x0004CA20 File Offset: 0x0004AE20
		private void Initialize()
		{
			this.Lock();
			string str = Application.persistentDataPath + "/udp2.log";
			this.logFileName = StringHelper.StringToUTF8Bytes(str);
			this.handle = UdpDLL.avalon_udpconnector_initialize(this.logFileName);
			this.Unlock();
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0004CA68 File Offset: 0x0004AE68
		private static void NetworkdThreadLoop(object obj)
		{
			UdpClient udpClient = (UdpClient)obj;
			byte[] array = new byte[65535];
			for (;;)
			{
				udpClient.Lock();
				for (;;)
				{
					uint dataLen = (uint)array.Length;
					int num = UdpDLL.avalon_udpconnector_checkdata(udpClient.handle, array, ref dataLen);
					if (num <= 0)
					{
						break;
					}
					if (num == 2)
					{
						UdpEvent udpEvent = new UdpEvent();
						udpEvent.type = UdpEventType.Disconnect;
						udpClient.eventList.Enqueue(udpEvent);
					}
					else if (num == 3)
					{
						udpClient.OnReceived(array, dataLen);
					}
				}
				udpClient.Unlock();
				Thread.Sleep(3);
			}
		}

		// Token: 0x06000EFB RID: 3835 RVA: 0x0004CAFD File Offset: 0x0004AEFD
		public bool IsConnected()
		{
			return this.isConnected;
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x0004CB08 File Offset: 0x0004AF08
		public void SendLog2Http()
		{
			UdpDLL.avalon_udpconnector_save_log(this.logFileName);
			string url = string.Format("http://{0}:9527/udp?accid={1}", "121.41.17.47", ClientApplication.playerinfo.accid);
			Http.UploadFile(url, StringHelper.BytesToString(this.logFileName));
			UdpDLL.avalon_udpconnector_open_log(this.logFileName);
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x0004CB5B File Offset: 0x0004AF5B
		private ServerType GetServerType()
		{
			return this.serverType;
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x0004CB64 File Offset: 0x0004AF64
		public bool Connect(string ip, ushort port, uint accid, uint timeout)
		{
			byte[] ip2 = StringHelper.StringToUTF8Bytes(ip);
			this.Lock();
			int num = UdpDLL.avalon_udpconnector_connect(this.handle, ip2, port, accid, timeout);
			this.Unlock();
			if (num != 0)
			{
				Logger.LogErrorFormat("Connect To {0}:{1} failed, ret:{2}.", new object[]
				{
					ip,
					port,
					num
				});
				this.Reset();
				return false;
			}
			this.accountId = accid;
			this.serverIp = ip;
			this.serverPort = port;
			this.isConnected = true;
			return true;
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x0004CBE6 File Offset: 0x0004AFE6
		public void Disconnect()
		{
			this.Lock();
			UdpDLL.avalon_udpconnector_disconnect(this.handle, this.accountId);
			this.Unlock();
			this.Reset();
		}

		// Token: 0x06000F00 RID: 3840 RVA: 0x0004CC0C File Offset: 0x0004B00C
		public int SendCommandObject(object msgCmd)
		{
			IProtocolStream protocolStream = msgCmd as IProtocolStream;
			IGetMsgID getMsgID = msgCmd as IGetMsgID;
			if (getMsgID == null || protocolStream == null)
			{
				return -1;
			}
			int num = 10;
			protocolStream.encode(this.buffer, ref num);
			uint num2 = (uint)(num - 10);
			num = 0;
			BaseDLL.encode_uint16(this.buffer, ref num, (ushort)IPAddress.HostToNetworkOrder((short)num2));
			BaseDLL.encode_uint32(this.buffer, ref num, (uint)IPAddress.HostToNetworkOrder((int)getMsgID.GetMsgID()));
			return this.SendData(this.buffer, num2 + 10U);
		}

		// Token: 0x06000F01 RID: 3841 RVA: 0x0004CC8C File Offset: 0x0004B08C
		public int SendCommand<CommandType>(CommandType cmd) where CommandType : IProtocolStream, IGetMsgID
		{
			return this.SendCommandObject(cmd);
		}

		// Token: 0x06000F02 RID: 3842 RVA: 0x0004CC9C File Offset: 0x0004B09C
		public int SendData(byte[] data, uint len)
		{
			this.Lock();
			int result = UdpDLL.avalon_udpconnector_senddata(this.handle, data, len, 1);
			this.Unlock();
			return result;
		}

		// Token: 0x06000F03 RID: 3843 RVA: 0x0004CCC8 File Offset: 0x0004B0C8
		public int Ping()
		{
			this.Lock();
			int result = UdpDLL.avalon_udpconnector_ping(this.handle);
			this.Unlock();
			return result;
		}

		// Token: 0x06000F04 RID: 3844 RVA: 0x0004CCF0 File Offset: 0x0004B0F0
		public void Tick()
		{
			for (;;)
			{
				this.Lock();
				if (this.eventList.Count == 0)
				{
					break;
				}
				UdpEvent udpEvent = this.eventList.Dequeue();
				this.Unlock();
				if (udpEvent.type == UdpEventType.Disconnect)
				{
					this.OnDisconnected();
				}
			}
			this.Unlock();
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x0004CD47 File Offset: 0x0004B147
		protected void OnDisconnected()
		{
			NetManager.Instance().PushSocketEvent(ServerType.RELAY_SERVER, SocketEventType.DISCONNECT, 0U, 0U);
			this.Reset();
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x0004CD60 File Offset: 0x0004B160
		protected void OnReceived(byte[] data, uint dataLen)
		{
			if (dataLen < 10U)
			{
				Logger.LogErrorFormat("Recveived Error Data, DataLen = " + dataLen, new object[0]);
				return;
			}
			ushort num = 0;
			uint num2 = 0U;
			int num3 = 0;
			BaseDLL.decode_uint16(data, ref num3, ref num);
			num = (ushort)IPAddress.NetworkToHostOrder((short)num);
			BaseDLL.decode_uint32(data, ref num3, ref num2);
			num2 = (uint)IPAddress.NetworkToHostOrder((int)num2);
			uint num4 = (uint)(num + 10);
			if (num4 != dataLen)
			{
				Logger.LogErrorFormat("Recveived Error Data, DataLen = {0}, NeedLen = {1}", new object[]
				{
					dataLen,
					num4
				});
				return;
			}
			MsgDATA msgDATA = new MsgDATA((int)num);
			msgDATA.serverType = this.serverType;
			msgDATA.id = num2;
			for (int i = 0; i < (int)num; i++)
			{
				msgDATA.bytes[i] = data[(int)(checked((IntPtr)(unchecked((long)i + 10L))))];
			}
			if (msgDATA.id == 1300004U)
			{
				RelaySvrFrameDataNotify relaySvrFrameDataNotify = new RelaySvrFrameDataNotify();
				int num5 = 0;
				relaySvrFrameDataNotify.decode(msgDATA.bytes, ref num5);
				uint tickCount = (uint)Environment.TickCount;
				for (int j = 0; j < relaySvrFrameDataNotify.frames.Length; j++)
				{
					Frame frame = relaySvrFrameDataNotify.frames[j];
					for (int k = 0; k < frame.data.Length; k++)
					{
						_fighterInput fighterInput = frame.data[k];
						if (fighterInput.seat == ClientApplication.playerinfo.seat && fighterInput.input.sendTime != 0U)
						{
							uint delay = tickCount - fighterInput.input.sendTime;
							UdpClient.perf.AddDelay(delay);
						}
					}
				}
			}
			NetProcess.Instance().PushQueue(msgDATA);
		}

		// Token: 0x06000F07 RID: 3847 RVA: 0x0004CF0C File Offset: 0x0004B30C
		public void Reset()
		{
			this.Lock();
			this.accountId = 0U;
			this.serverIp = string.Empty;
			this.serverPort = 0;
			this.isConnected = false;
			UdpDLL.avalon_udpconnector_deinitialize(this.handle);
			this.handle = UdpDLL.avalon_udpconnector_initialize(this.logFileName);
			this.Unlock();
		}

		// Token: 0x04000A4D RID: 2637
		private ServerType serverType;

		// Token: 0x04000A4E RID: 2638
		private byte[] buffer = new byte[65535];

		// Token: 0x04000A4F RID: 2639
		private IntPtr handle;

		// Token: 0x04000A50 RID: 2640
		private uint accountId;

		// Token: 0x04000A51 RID: 2641
		private string serverIp;

		// Token: 0x04000A52 RID: 2642
		private ushort serverPort;

		// Token: 0x04000A53 RID: 2643
		private bool isConnected;

		// Token: 0x04000A54 RID: 2644
		private byte[] logFileName;

		// Token: 0x04000A55 RID: 2645
		public static FramePerformance perf = new FramePerformance();

		// Token: 0x04000A56 RID: 2646
		private Thread networkThread;

		// Token: 0x04000A57 RID: 2647
		private Mutex mutex = new Mutex();

		// Token: 0x04000A58 RID: 2648
		private Queue<UdpEvent> eventList = new Queue<UdpEvent>();
	}
}
