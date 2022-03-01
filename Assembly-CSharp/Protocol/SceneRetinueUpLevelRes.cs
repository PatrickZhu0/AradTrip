using System;

namespace Protocol
{
	// Token: 0x02000ABE RID: 2750
	[Protocol]
	public class SceneRetinueUpLevelRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007753 RID: 30547 RVA: 0x00158DE0 File Offset: 0x001571E0
		public uint GetMsgID()
		{
			return 507010U;
		}

		// Token: 0x06007754 RID: 30548 RVA: 0x00158DE7 File Offset: 0x001571E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007755 RID: 30549 RVA: 0x00158DEF File Offset: 0x001571EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007756 RID: 30550 RVA: 0x00158DF8 File Offset: 0x001571F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007757 RID: 30551 RVA: 0x00158E24 File Offset: 0x00157224
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007758 RID: 30552 RVA: 0x00158E50 File Offset: 0x00157250
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007759 RID: 30553 RVA: 0x00158E7C File Offset: 0x0015727C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x0600775A RID: 30554 RVA: 0x00158EA8 File Offset: 0x001572A8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 8;
		}

		// Token: 0x040037DE RID: 14302
		public const uint MsgID = 507010U;

		// Token: 0x040037DF RID: 14303
		public uint Sequence;

		// Token: 0x040037E0 RID: 14304
		public uint result;

		// Token: 0x040037E1 RID: 14305
		public byte type;

		// Token: 0x040037E2 RID: 14306
		public ulong id;
	}
}
