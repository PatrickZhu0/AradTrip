using System;

namespace Protocol
{
	// Token: 0x02000996 RID: 2454
	[Protocol]
	public class SceneEquipInscriptionOpenRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E98 RID: 28312 RVA: 0x0013FE44 File Offset: 0x0013E244
		public uint GetMsgID()
		{
			return 501076U;
		}

		// Token: 0x06006E99 RID: 28313 RVA: 0x0013FE4B File Offset: 0x0013E24B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E9A RID: 28314 RVA: 0x0013FE53 File Offset: 0x0013E253
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E9B RID: 28315 RVA: 0x0013FE5C File Offset: 0x0013E25C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E9C RID: 28316 RVA: 0x0013FE88 File Offset: 0x0013E288
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E9D RID: 28317 RVA: 0x0013FEB4 File Offset: 0x0013E2B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E9E RID: 28318 RVA: 0x0013FEE0 File Offset: 0x0013E2E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E9F RID: 28319 RVA: 0x0013FF0C File Offset: 0x0013E30C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003217 RID: 12823
		public const uint MsgID = 501076U;

		// Token: 0x04003218 RID: 12824
		public uint Sequence;

		// Token: 0x04003219 RID: 12825
		public ulong guid;

		// Token: 0x0400321A RID: 12826
		public uint index;

		// Token: 0x0400321B RID: 12827
		public uint code;
	}
}
