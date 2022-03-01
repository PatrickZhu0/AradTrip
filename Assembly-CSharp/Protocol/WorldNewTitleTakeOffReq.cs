using System;

namespace Protocol
{
	// Token: 0x02000A20 RID: 2592
	[Protocol]
	public class WorldNewTitleTakeOffReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072D3 RID: 29395 RVA: 0x0014C3EC File Offset: 0x0014A7EC
		public uint GetMsgID()
		{
			return 609204U;
		}

		// Token: 0x060072D4 RID: 29396 RVA: 0x0014C3F3 File Offset: 0x0014A7F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072D5 RID: 29397 RVA: 0x0014C3FB File Offset: 0x0014A7FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072D6 RID: 29398 RVA: 0x0014C404 File Offset: 0x0014A804
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
		}

		// Token: 0x060072D7 RID: 29399 RVA: 0x0014C422 File Offset: 0x0014A822
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
		}

		// Token: 0x060072D8 RID: 29400 RVA: 0x0014C440 File Offset: 0x0014A840
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.titleGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.titleId);
		}

		// Token: 0x060072D9 RID: 29401 RVA: 0x0014C45E File Offset: 0x0014A85E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.titleGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.titleId);
		}

		// Token: 0x060072DA RID: 29402 RVA: 0x0014C47C File Offset: 0x0014A87C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040034C4 RID: 13508
		public const uint MsgID = 609204U;

		// Token: 0x040034C5 RID: 13509
		public uint Sequence;

		// Token: 0x040034C6 RID: 13510
		public ulong titleGuid;

		// Token: 0x040034C7 RID: 13511
		public uint titleId;
	}
}
