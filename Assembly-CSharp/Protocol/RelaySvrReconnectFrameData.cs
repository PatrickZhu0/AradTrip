using System;

namespace Protocol
{
	// Token: 0x02000AA1 RID: 2721
	[Protocol]
	public class RelaySvrReconnectFrameData : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600768A RID: 30346 RVA: 0x00156B2C File Offset: 0x00154F2C
		public uint GetMsgID()
		{
			return 1300014U;
		}

		// Token: 0x0600768B RID: 30347 RVA: 0x00156B33 File Offset: 0x00154F33
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600768C RID: 30348 RVA: 0x00156B3B File Offset: 0x00154F3B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600768D RID: 30349 RVA: 0x00156B44 File Offset: 0x00154F44
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.finish);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600768E RID: 30350 RVA: 0x00156B98 File Offset: 0x00154F98
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.finish);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.frames = new Frame[(int)num];
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i] = new Frame();
				this.frames[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600768F RID: 30351 RVA: 0x00156C00 File Offset: 0x00155000
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.finish);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007690 RID: 30352 RVA: 0x00156C54 File Offset: 0x00155054
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.finish);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.frames = new Frame[(int)num];
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i] = new Frame();
				this.frames[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007691 RID: 30353 RVA: 0x00156CBC File Offset: 0x001550BC
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.frames.Length; i++)
			{
				num += this.frames[i].getLen();
			}
			return num;
		}

		// Token: 0x04003767 RID: 14183
		public const uint MsgID = 1300014U;

		// Token: 0x04003768 RID: 14184
		public uint Sequence;

		// Token: 0x04003769 RID: 14185
		public byte finish;

		// Token: 0x0400376A RID: 14186
		public Frame[] frames = new Frame[0];
	}
}
