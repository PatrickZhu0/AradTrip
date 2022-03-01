using System;

namespace Protocol
{
	// Token: 0x02000C12 RID: 3090
	[Protocol]
	public class TeamCopyGridSquadBattleNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008134 RID: 33076 RVA: 0x0016D3E7 File Offset: 0x0016B7E7
		public uint GetMsgID()
		{
			return 1100084U;
		}

		// Token: 0x06008135 RID: 33077 RVA: 0x0016D3EE File Offset: 0x0016B7EE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008136 RID: 33078 RVA: 0x0016D3F6 File Offset: 0x0016B7F6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008137 RID: 33079 RVA: 0x0016D3FF File Offset: 0x0016B7FF
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isBattle);
		}

		// Token: 0x06008138 RID: 33080 RVA: 0x0016D439 File Offset: 0x0016B839
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isBattle);
		}

		// Token: 0x06008139 RID: 33081 RVA: 0x0016D473 File Offset: 0x0016B873
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.squadGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldGridId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isBattle);
		}

		// Token: 0x0600813A RID: 33082 RVA: 0x0016D4AD File Offset: 0x0016B8AD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.squadGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldGridId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isBattle);
		}

		// Token: 0x0600813B RID: 33083 RVA: 0x0016D4E8 File Offset: 0x0016B8E8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003DAE RID: 15790
		public const uint MsgID = 1100084U;

		// Token: 0x04003DAF RID: 15791
		public uint Sequence;

		// Token: 0x04003DB0 RID: 15792
		public uint squadId;

		// Token: 0x04003DB1 RID: 15793
		public uint squadGridId;

		// Token: 0x04003DB2 RID: 15794
		public uint fieldGridId;

		// Token: 0x04003DB3 RID: 15795
		public uint isBattle;
	}
}
