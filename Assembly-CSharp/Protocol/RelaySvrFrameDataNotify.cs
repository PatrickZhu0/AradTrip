using System;

namespace Protocol
{
	// Token: 0x02000A93 RID: 2707
	[Protocol]
	public class RelaySvrFrameDataNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600761B RID: 30235 RVA: 0x00155660 File Offset: 0x00153A60
		public uint GetMsgID()
		{
			return 1300004U;
		}

		// Token: 0x0600761C RID: 30236 RVA: 0x00155667 File Offset: 0x00153A67
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600761D RID: 30237 RVA: 0x0015566F File Offset: 0x00153A6F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600761E RID: 30238 RVA: 0x00155678 File Offset: 0x00153A78
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600761F RID: 30239 RVA: 0x001556C0 File Offset: 0x00153AC0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.frames = new Frame[(int)num];
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i] = new Frame();
				this.frames[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007620 RID: 30240 RVA: 0x0015571C File Offset: 0x00153B1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007621 RID: 30241 RVA: 0x00155764 File Offset: 0x00153B64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.frames = new Frame[(int)num];
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i] = new Frame();
				this.frames[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007622 RID: 30242 RVA: 0x001557C0 File Offset: 0x00153BC0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.frames.Length; i++)
			{
				num += this.frames[i].getLen();
			}
			return num;
		}

		// Token: 0x04003723 RID: 14115
		public const uint MsgID = 1300004U;

		// Token: 0x04003724 RID: 14116
		public uint Sequence;

		// Token: 0x04003725 RID: 14117
		public Frame[] frames = new Frame[0];
	}
}
