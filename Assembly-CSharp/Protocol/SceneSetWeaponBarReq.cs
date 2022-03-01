using System;

namespace Protocol
{
	// Token: 0x02000B40 RID: 2880
	[Protocol]
	public class SceneSetWeaponBarReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B07 RID: 31495 RVA: 0x00160978 File Offset: 0x0015ED78
		public uint GetMsgID()
		{
			return 501219U;
		}

		// Token: 0x06007B08 RID: 31496 RVA: 0x0016097F File Offset: 0x0015ED7F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B09 RID: 31497 RVA: 0x00160987 File Offset: 0x0015ED87
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B0A RID: 31498 RVA: 0x00160990 File Offset: 0x0015ED90
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.weaponId);
		}

		// Token: 0x06007B0B RID: 31499 RVA: 0x001609AE File Offset: 0x0015EDAE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.weaponId);
		}

		// Token: 0x06007B0C RID: 31500 RVA: 0x001609CC File Offset: 0x0015EDCC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.weaponId);
		}

		// Token: 0x06007B0D RID: 31501 RVA: 0x001609EA File Offset: 0x0015EDEA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.weaponId);
		}

		// Token: 0x06007B0E RID: 31502 RVA: 0x00160A08 File Offset: 0x0015EE08
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x04003A4B RID: 14923
		public const uint MsgID = 501219U;

		// Token: 0x04003A4C RID: 14924
		public uint Sequence;

		// Token: 0x04003A4D RID: 14925
		public byte index;

		// Token: 0x04003A4E RID: 14926
		public ulong weaponId;
	}
}
