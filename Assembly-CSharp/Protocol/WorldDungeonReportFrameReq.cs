using System;

namespace Protocol
{
	// Token: 0x020007E5 RID: 2021
	[Protocol]
	public class WorldDungeonReportFrameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006178 RID: 24952 RVA: 0x00123DB0 File Offset: 0x001221B0
		public uint GetMsgID()
		{
			return 606811U;
		}

		// Token: 0x06006179 RID: 24953 RVA: 0x00123DB7 File Offset: 0x001221B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600617A RID: 24954 RVA: 0x00123DBF File Offset: 0x001221BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600617B RID: 24955 RVA: 0x00123DC8 File Offset: 0x001221C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.checksums.Length);
			for (int j = 0; j < this.checksums.Length; j++)
			{
				this.checksums[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600617C RID: 24956 RVA: 0x00123E48 File Offset: 0x00122248
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
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.checksums = new FrameChecksum[(int)num2];
			for (int j = 0; j < this.checksums.Length; j++)
			{
				this.checksums[j] = new FrameChecksum();
				this.checksums[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600617D RID: 24957 RVA: 0x00123EF0 File Offset: 0x001222F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.checksums.Length);
			for (int j = 0; j < this.checksums.Length; j++)
			{
				this.checksums[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600617E RID: 24958 RVA: 0x00123F70 File Offset: 0x00122370
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
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.checksums = new FrameChecksum[(int)num2];
			for (int j = 0; j < this.checksums.Length; j++)
			{
				this.checksums[j] = new FrameChecksum();
				this.checksums[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600617F RID: 24959 RVA: 0x00124018 File Offset: 0x00122418
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.frames.Length; i++)
			{
				num += this.frames[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.checksums.Length; j++)
			{
				num += this.checksums[j].getLen();
			}
			return num;
		}

		// Token: 0x0400289B RID: 10395
		public const uint MsgID = 606811U;

		// Token: 0x0400289C RID: 10396
		public uint Sequence;

		// Token: 0x0400289D RID: 10397
		public Frame[] frames = new Frame[0];

		// Token: 0x0400289E RID: 10398
		public FrameChecksum[] checksums = new FrameChecksum[0];
	}
}
