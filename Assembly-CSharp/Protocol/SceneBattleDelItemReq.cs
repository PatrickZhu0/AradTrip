using System;

namespace Protocol
{
	// Token: 0x0200070F RID: 1807
	[Protocol]
	public class SceneBattleDelItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AFD RID: 23293 RVA: 0x001145A0 File Offset: 0x001129A0
		public uint GetMsgID()
		{
			return 508923U;
		}

		// Token: 0x06005AFE RID: 23294 RVA: 0x001145A7 File Offset: 0x001129A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AFF RID: 23295 RVA: 0x001145AF File Offset: 0x001129AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B00 RID: 23296 RVA: 0x001145B8 File Offset: 0x001129B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005B01 RID: 23297 RVA: 0x001145C8 File Offset: 0x001129C8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005B02 RID: 23298 RVA: 0x001145D8 File Offset: 0x001129D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005B03 RID: 23299 RVA: 0x001145E8 File Offset: 0x001129E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005B04 RID: 23300 RVA: 0x001145F8 File Offset: 0x001129F8
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002511 RID: 9489
		public const uint MsgID = 508923U;

		// Token: 0x04002512 RID: 9490
		public uint Sequence;

		// Token: 0x04002513 RID: 9491
		public ulong itemGuid;
	}
}
