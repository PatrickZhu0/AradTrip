using System;
using System.Net;

namespace Network
{
	// Token: 0x020001D1 RID: 465
	public class PacketBuffer
	{
		// Token: 0x06000EE0 RID: 3808 RVA: 0x0004C46D File Offset: 0x0004A86D
		public PacketBuffer()
		{
			this.m_BufferLength = this.m_Buffer.Length;
			this.m_LengthMask = this.m_BufferLength - 1;
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x0004C4A4 File Offset: 0x0004A8A4
		public void WritePacket(uint msgId, uint sequence, byte[] data, ushort size)
		{
			int freeSize = this.GetFreeSize();
			int num = (int)(size + 10);
			int startPos = this.m_StartPos;
			int endPos = this.m_EndPos;
			if (freeSize < num)
			{
				this.Free(num);
				freeSize = this.GetFreeSize();
				if (this.GetFreeSize() < num)
				{
					string str = string.Format("Try Free {0} Size Failure {1} In {2} Seq {3}", new object[]
					{
						freeSize,
						num,
						msgId,
						sequence
					});
					Logger.LogError(str);
					return;
				}
			}
			startPos = this.m_StartPos;
			endPos = this.m_EndPos;
			this.WriteShort((short)size);
			this.WriteInt32((int)msgId);
			this.WriteInt32((int)sequence);
			this.WriteArray(data, size);
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x0004C55C File Offset: 0x0004A95C
		public int FetchPacket(uint startSequence, byte[] data)
		{
			if (startSequence == 0U || this.GetUsedSize() == 0)
			{
				return 0;
			}
			int num = 0;
			int i = this.m_StartPos;
			int num2 = (this.m_EndPos >= this.m_StartPos) ? this.m_EndPos : (this.m_EndPos + this.m_BufferLength);
			bool flag = false;
			while (i < num2)
			{
				short num3 = this.ReadShort(i);
				int num4 = this.ReadInt32(i + 2);
				int num5 = this.ReadInt32(i + 6);
				if ((long)num5 <= (long)((ulong)startSequence))
				{
					i += (int)(num3 + 10);
					if ((long)num5 == (long)((ulong)startSequence))
					{
						flag = true;
					}
				}
				else
				{
					if ((long)num5 == (long)((ulong)(startSequence + 1U)))
					{
						flag = true;
					}
					for (int j = 0; j < (int)(num3 + 10); j++)
					{
						data[num++] = this.ReadByte(i++);
						if (num >= data.Length)
						{
							return -1;
						}
					}
				}
			}
			if (flag)
			{
				return num;
			}
			return -1;
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0004C650 File Offset: 0x0004AA50
		private void WriteInt32(int value)
		{
			value = IPAddress.HostToNetworkOrder(value);
			for (int i = 0; i < 4; i++)
			{
				this.WriteByte((byte)(value >> i * 8 & 255));
			}
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x0004C68C File Offset: 0x0004AA8C
		private void WriteShort(short value)
		{
			value = IPAddress.HostToNetworkOrder(value);
			this.WriteByte((byte)(value >> 0 & 255));
			this.WriteByte((byte)(value >> 8 & 255));
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x0004C6B8 File Offset: 0x0004AAB8
		private void WriteByte(byte value)
		{
			this.m_Buffer[this.m_EndPos++] = value;
			this.m_EndPos &= this.m_LengthMask;
		}

		// Token: 0x06000EE6 RID: 3814 RVA: 0x0004C6F4 File Offset: 0x0004AAF4
		private void WriteArray(byte[] data, ushort size)
		{
			for (int i = 0; i < (int)size; i++)
			{
				this.WriteByte(data[i]);
			}
		}

		// Token: 0x06000EE7 RID: 3815 RVA: 0x0004C71C File Offset: 0x0004AB1C
		private int ReadInt32(int pos)
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				num |= (int)this.ReadByte(pos++) << i * 8;
			}
			return IPAddress.HostToNetworkOrder(num);
		}

		// Token: 0x06000EE8 RID: 3816 RVA: 0x0004C75C File Offset: 0x0004AB5C
		private short ReadShort(int pos)
		{
			short num = 0;
			for (int i = 0; i < 2; i++)
			{
				num |= (short)(this.ReadByte(pos++) << i * 8);
			}
			return IPAddress.HostToNetworkOrder(num);
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x0004C7A0 File Offset: 0x0004ABA0
		private byte ReadByte(int pos)
		{
			pos &= this.m_LengthMask;
			return this.m_Buffer[pos];
		}

		// Token: 0x06000EEA RID: 3818 RVA: 0x0004C7C1 File Offset: 0x0004ABC1
		public int GetUsedSize()
		{
			if (this.m_EndPos < this.m_StartPos)
			{
				return this.m_EndPos + this.m_BufferLength - this.m_StartPos;
			}
			return this.m_EndPos - this.m_StartPos;
		}

		// Token: 0x06000EEB RID: 3819 RVA: 0x0004C7F6 File Offset: 0x0004ABF6
		private int GetFreeSize()
		{
			return this.m_BufferLength - this.GetUsedSize();
		}

		// Token: 0x06000EEC RID: 3820 RVA: 0x0004C808 File Offset: 0x0004AC08
		private void Free(int size)
		{
			int startPos = this.m_StartPos;
			int num = (this.m_EndPos >= this.m_StartPos) ? this.m_EndPos : (this.m_EndPos + this.m_BufferLength);
			int num2 = 1000;
			while (this.GetFreeSize() < size)
			{
				if (--num2 <= 0)
				{
					break;
				}
				short num3 = this.ReadShort(this.m_StartPos);
				this.m_StartPos = (this.m_StartPos + (int)num3 + 10 & this.m_LengthMask);
			}
			if (this.GetFreeSize() < size)
			{
				this.Clear();
			}
		}

		// Token: 0x06000EED RID: 3821 RVA: 0x0004C8A8 File Offset: 0x0004ACA8
		public void Clear()
		{
			this.m_StartPos = (this.m_EndPos = 0);
		}

		// Token: 0x04000A43 RID: 2627
		private byte[] m_Buffer = new byte[65536];

		// Token: 0x04000A44 RID: 2628
		private int m_StartPos;

		// Token: 0x04000A45 RID: 2629
		private int m_EndPos;

		// Token: 0x04000A46 RID: 2630
		private int m_BufferLength;

		// Token: 0x04000A47 RID: 2631
		private int m_LengthMask;
	}
}
