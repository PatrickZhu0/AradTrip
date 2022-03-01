using System;

namespace Protocol
{
	// Token: 0x02000C0F RID: 3087
	[Protocol]
	public class TeamCopyOtherSquadData : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008119 RID: 33049 RVA: 0x0016CEF1 File Offset: 0x0016B2F1
		public uint GetMsgID()
		{
			return 1100081U;
		}

		// Token: 0x0600811A RID: 33050 RVA: 0x0016CEF8 File Offset: 0x0016B2F8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600811B RID: 33051 RVA: 0x0016CF00 File Offset: 0x0016B300
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600811C RID: 33052 RVA: 0x0016CF0C File Offset: 0x0016B30C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadTargetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadMemberNum);
		}

		// Token: 0x0600811D RID: 33053 RVA: 0x0016CF60 File Offset: 0x0016B360
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadTargetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadMemberNum);
		}

		// Token: 0x0600811E RID: 33054 RVA: 0x0016CFB4 File Offset: 0x0016B3B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadTargetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadMemberNum);
		}

		// Token: 0x0600811F RID: 33055 RVA: 0x0016D008 File Offset: 0x0016B408
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadTargetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadMemberNum);
		}

		// Token: 0x06008120 RID: 33056 RVA: 0x0016D05C File Offset: 0x0016B45C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D9B RID: 15771
		public const uint MsgID = 1100081U;

		// Token: 0x04003D9C RID: 15772
		public uint Sequence;

		// Token: 0x04003D9D RID: 15773
		public uint squadId;

		// Token: 0x04003D9E RID: 15774
		public uint squadStatus;

		// Token: 0x04003D9F RID: 15775
		public uint squadGridId;

		// Token: 0x04003DA0 RID: 15776
		public uint squadTargetId;

		// Token: 0x04003DA1 RID: 15777
		public uint squadMemberNum;
	}
}
