using System;
using System.Net;
using System.Runtime.InteropServices;
using GamePool;

namespace Network
{
	// Token: 0x020001C4 RID: 452
	public class NetOutputBuffer
	{
		// Token: 0x06000E7F RID: 3711 RVA: 0x0004A15C File Offset: 0x0004855C
		public NetOutputBuffer(NetWorkBase netWork)
		{
			this.netWorkBase = netWork;
			this.m_Head = 0;
			this.m_Tail = 0;
			this.m_Buffer = new byte[NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE];
			this.m_BufferLen = NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE;
			this.m_MaxBufferLen = NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE;
			this.m_SendData = new byte[NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE];
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x0004A1BA File Offset: 0x000485BA
		public static void Init(int maxCacheObjNum)
		{
			NetOutputBuffer.msgPool.Init(maxCacheObjNum);
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x0004A1C7 File Offset: 0x000485C7
		public static MutexObjectPool<MsgBuffer> GetMsgPool()
		{
			return NetOutputBuffer.msgPool;
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x0004A1D0 File Offset: 0x000485D0
		public int Write(ref byte[] buf, int len)
		{
			int num = (this.m_Head > this.m_Tail) ? (this.m_Head - this.m_Tail - 1) : (this.m_BufferLen - this.m_Tail + this.m_Head - 1);
			if (len >= num && !this.Resize(len - num + 1))
			{
				return 0;
			}
			for (int i = 0; i < len; i++)
			{
				this.m_Buffer[this.m_Tail++] = buf[i];
				if (this.m_Tail == this.m_BufferLen)
				{
					this.m_Tail -= this.m_BufferLen;
				}
			}
			return len;
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x0004A288 File Offset: 0x00048688
		public int WriteByte(byte buf)
		{
			int num = (this.m_Head > this.m_Tail) ? (this.m_Head - this.m_Tail - 1) : (this.m_BufferLen - this.m_Tail + this.m_Head - 1);
			if (1 >= num && !this.Resize(1 - num + 1))
			{
				return 0;
			}
			this.m_Buffer[this.m_Tail++] = buf;
			if (this.m_Tail == this.m_BufferLen)
			{
				this.m_Tail -= this.m_BufferLen;
			}
			return 1;
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x0004A328 File Offset: 0x00048728
		public int WriteSByte(sbyte buf)
		{
			return this.WriteByte((byte)buf);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x0004A334 File Offset: 0x00048734
		public int WriteShort(short buf)
		{
			int num = (this.m_Head > this.m_Tail) ? (this.m_Head - this.m_Tail - 1) : (this.m_BufferLen - this.m_Tail + this.m_Head - 1);
			if (2 >= num && !this.Resize(2 - num + 1))
			{
				return 0;
			}
			buf = IPAddress.HostToNetworkOrder(buf);
			this.m_Buffer[this.m_Tail++] = (byte)(buf >> 0 & 255);
			if (this.m_Tail == this.m_BufferLen)
			{
				this.m_Tail -= this.m_BufferLen;
			}
			this.m_Buffer[this.m_Tail++] = (byte)(buf >> 8 & 255);
			if (this.m_Tail == this.m_BufferLen)
			{
				this.m_Tail -= this.m_BufferLen;
			}
			return 2;
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x0004A42B File Offset: 0x0004882B
		public int WriteUShort(ushort buf)
		{
			return this.WriteShort((short)buf);
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x0004A438 File Offset: 0x00048838
		public int WriteInt(int buf)
		{
			int num = (this.m_Head > this.m_Tail) ? (this.m_Head - this.m_Tail - 1) : (this.m_BufferLen - this.m_Tail + this.m_Head - 1);
			if (4 >= num && !this.Resize(4 - num + 1))
			{
				return 0;
			}
			buf = IPAddress.HostToNetworkOrder(buf);
			this.m_Buffer[this.m_Tail++] = (byte)(buf >> 0 & 255);
			if (this.m_Tail == this.m_BufferLen)
			{
				this.m_Tail -= this.m_BufferLen;
			}
			this.m_Buffer[this.m_Tail++] = (byte)(buf >> 8 & 255);
			if (this.m_Tail == this.m_BufferLen)
			{
				this.m_Tail -= this.m_BufferLen;
			}
			this.m_Buffer[this.m_Tail++] = (byte)(buf >> 16 & 255);
			if (this.m_Tail == this.m_BufferLen)
			{
				this.m_Tail -= this.m_BufferLen;
			}
			this.m_Buffer[this.m_Tail++] = (byte)(buf >> 24 & 255);
			if (this.m_Tail == this.m_BufferLen)
			{
				this.m_Tail -= this.m_BufferLen;
			}
			return 4;
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x0004A5BD File Offset: 0x000489BD
		public int WriteUint(uint buf)
		{
			return this.WriteInt((int)buf);
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x0004A5C8 File Offset: 0x000489C8
		public int WriteFloat(float buf)
		{
			byte[] bytes = BitConverter.GetBytes(buf);
			return this.Write(ref bytes, bytes.Length);
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x0004A5E8 File Offset: 0x000489E8
		public int WriteStruct(object InType)
		{
			int num = Marshal.SizeOf(InType);
			byte[] array = new byte[num];
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.StructureToPtr(InType, intPtr, false);
			Marshal.Copy(intPtr, array, 0, num);
			Marshal.FreeHGlobal(intPtr);
			if (this.Write(ref array, array.Length) == 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x0004A634 File Offset: 0x00048A34
		protected bool Send(int buffLen)
		{
			MsgBuffer msgBuffer = NetOutputBuffer.GetMsgPool().Get();
			msgBuffer.length = buffLen;
			byte[] data = msgBuffer.data;
			Array.Clear(data, 0, data.Length);
			Array.Copy(this.m_Buffer, this.m_Head, data, 0, buffLen);
			this.netWorkBase.SendByPool(msgBuffer, null);
			return true;
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x0004A688 File Offset: 0x00048A88
		public int Flush()
		{
			int num = 0;
			if (NetManager.Instance().Show)
			{
			}
			if (this.m_BufferLen > this.m_MaxBufferLen)
			{
				this.Initsize();
				return -1;
			}
			if (this.m_Head < this.m_Tail)
			{
				int i = this.m_Tail - this.m_Head;
				while (i > 0)
				{
					this.Send(i);
					int num2 = i;
					num += num2;
					i -= num2;
					this.m_Head += num2;
				}
			}
			else if (this.m_Head > this.m_Tail)
			{
				int i = this.m_BufferLen - this.m_Head;
				while (i > 0)
				{
					this.Send(i);
					int num2 = i;
					num += num2;
					i -= num2;
					this.m_Head += num2;
				}
				this.m_Head = 0;
				i = this.m_Tail;
				while (i > 0)
				{
					this.Send(i);
					int num2 = i;
					num += num2;
					i -= num2;
					this.m_Head += num2;
				}
			}
			this.m_Head = (this.m_Tail = 0);
			return num;
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x0004A7A8 File Offset: 0x00048BA8
		public void Initsize()
		{
			this.m_Head = (this.m_Tail = 0);
			this.m_Buffer = new byte[NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE];
			this.m_BufferLen = NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE;
			this.m_MaxBufferLen = NetOutputBuffer.DEFAULTSOCKETOUTPUTBUFFERSIZE;
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x0004A7EB File Offset: 0x00048BEB
		public bool Resize(int size)
		{
			return false;
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x0004A7EE File Offset: 0x00048BEE
		public int Capacity()
		{
			return this.m_BufferLen;
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x0004A7F8 File Offset: 0x00048BF8
		public int Length()
		{
			if (this.m_Head < this.m_Tail)
			{
				return this.m_Tail - this.m_Head;
			}
			if (this.m_Head > this.m_Tail)
			{
				return this.m_BufferLen - this.m_Head + this.m_Tail;
			}
			return 0;
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x0004A84B File Offset: 0x00048C4B
		public bool IsEmpty()
		{
			return this.m_Head == this.m_Tail;
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x0004A85C File Offset: 0x00048C5C
		public void CleanUp()
		{
			this.m_Head = (this.m_Tail = 0);
			Array.Clear(this.m_Buffer, 0, this.m_Buffer.Length);
			Array.Clear(this.m_SendData, 0, this.m_SendData.Length);
		}

		// Token: 0x04000A09 RID: 2569
		public static readonly int DEFAULTSOCKETOUTPUTBUFFERSIZE = 65536;

		// Token: 0x04000A0A RID: 2570
		public int m_BufferLen;

		// Token: 0x04000A0B RID: 2571
		public int m_MaxBufferLen;

		// Token: 0x04000A0C RID: 2572
		private static MutexObjectPool<MsgBuffer> msgPool = new MutexObjectPool<MsgBuffer>();

		// Token: 0x04000A0D RID: 2573
		public byte[] m_Buffer;

		// Token: 0x04000A0E RID: 2574
		public byte[] m_SendData;

		// Token: 0x04000A0F RID: 2575
		public int m_Head;

		// Token: 0x04000A10 RID: 2576
		public int m_Tail;

		// Token: 0x04000A11 RID: 2577
		protected NetWorkBase netWorkBase;
	}
}
