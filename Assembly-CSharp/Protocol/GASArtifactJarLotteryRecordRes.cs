using System;

namespace Protocol
{
	// Token: 0x0200096B RID: 2411
	[Protocol]
	public class GASArtifactJarLotteryRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D21 RID: 27937 RVA: 0x0013D2CC File Offset: 0x0013B6CC
		public uint GetMsgID()
		{
			return 700902U;
		}

		// Token: 0x06006D22 RID: 27938 RVA: 0x0013D2D3 File Offset: 0x0013B6D3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D23 RID: 27939 RVA: 0x0013D2DB File Offset: 0x0013B6DB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D24 RID: 27940 RVA: 0x0013D2E4 File Offset: 0x0013B6E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.lotteryRecordList.Length);
			for (int i = 0; i < this.lotteryRecordList.Length; i++)
			{
				this.lotteryRecordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D25 RID: 27941 RVA: 0x0013D338 File Offset: 0x0013B738
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.lotteryRecordList = new ArtifactJarLotteryRecord[(int)num];
			for (int i = 0; i < this.lotteryRecordList.Length; i++)
			{
				this.lotteryRecordList[i] = new ArtifactJarLotteryRecord();
				this.lotteryRecordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D26 RID: 27942 RVA: 0x0013D3A0 File Offset: 0x0013B7A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.lotteryRecordList.Length);
			for (int i = 0; i < this.lotteryRecordList.Length; i++)
			{
				this.lotteryRecordList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D27 RID: 27943 RVA: 0x0013D3F4 File Offset: 0x0013B7F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.lotteryRecordList = new ArtifactJarLotteryRecord[(int)num];
			for (int i = 0; i < this.lotteryRecordList.Length; i++)
			{
				this.lotteryRecordList[i] = new ArtifactJarLotteryRecord();
				this.lotteryRecordList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D28 RID: 27944 RVA: 0x0013D45C File Offset: 0x0013B85C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.lotteryRecordList.Length; i++)
			{
				num += this.lotteryRecordList[i].getLen();
			}
			return num;
		}

		// Token: 0x0400316B RID: 12651
		public const uint MsgID = 700902U;

		// Token: 0x0400316C RID: 12652
		public uint Sequence;

		// Token: 0x0400316D RID: 12653
		public uint jarId;

		// Token: 0x0400316E RID: 12654
		public ArtifactJarLotteryRecord[] lotteryRecordList = new ArtifactJarLotteryRecord[0];
	}
}
