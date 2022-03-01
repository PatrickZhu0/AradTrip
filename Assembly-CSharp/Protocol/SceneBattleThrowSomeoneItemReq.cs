using System;

namespace Protocol
{
	// Token: 0x0200070C RID: 1804
	[Protocol]
	public class SceneBattleThrowSomeoneItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AE2 RID: 23266 RVA: 0x00114038 File Offset: 0x00112438
		public uint GetMsgID()
		{
			return 508920U;
		}

		// Token: 0x06005AE3 RID: 23267 RVA: 0x0011403F File Offset: 0x0011243F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AE4 RID: 23268 RVA: 0x00114047 File Offset: 0x00112447
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AE5 RID: 23269 RVA: 0x00114050 File Offset: 0x00112450
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005AE6 RID: 23270 RVA: 0x0011407C File Offset: 0x0011247C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005AE7 RID: 23271 RVA: 0x001140A8 File Offset: 0x001124A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005AE8 RID: 23272 RVA: 0x001140D4 File Offset: 0x001124D4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005AE9 RID: 23273 RVA: 0x00114100 File Offset: 0x00112500
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x040024FB RID: 9467
		public const uint MsgID = 508920U;

		// Token: 0x040024FC RID: 9468
		public uint Sequence;

		// Token: 0x040024FD RID: 9469
		public uint battleID;

		// Token: 0x040024FE RID: 9470
		public ulong targetID;

		// Token: 0x040024FF RID: 9471
		public ulong itemGuid;
	}
}
