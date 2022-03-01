using System;

namespace Protocol
{
	// Token: 0x02000857 RID: 2135
	[Protocol]
	public class WorldGuildBattleReceiveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006481 RID: 25729 RVA: 0x0012BC10 File Offset: 0x0012A010
		public uint GetMsgID()
		{
			return 601946U;
		}

		// Token: 0x06006482 RID: 25730 RVA: 0x0012BC17 File Offset: 0x0012A017
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006483 RID: 25731 RVA: 0x0012BC1F File Offset: 0x0012A01F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006484 RID: 25732 RVA: 0x0012BC28 File Offset: 0x0012A028
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.boxId);
		}

		// Token: 0x06006485 RID: 25733 RVA: 0x0012BC38 File Offset: 0x0012A038
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.boxId);
		}

		// Token: 0x06006486 RID: 25734 RVA: 0x0012BC48 File Offset: 0x0012A048
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.boxId);
		}

		// Token: 0x06006487 RID: 25735 RVA: 0x0012BC58 File Offset: 0x0012A058
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.boxId);
		}

		// Token: 0x06006488 RID: 25736 RVA: 0x0012BC68 File Offset: 0x0012A068
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002D06 RID: 11526
		public const uint MsgID = 601946U;

		// Token: 0x04002D07 RID: 11527
		public uint Sequence;

		// Token: 0x04002D08 RID: 11528
		public byte boxId;
	}
}
