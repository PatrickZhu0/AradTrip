using System;

namespace Protocol
{
	// Token: 0x02000986 RID: 2438
	[Protocol]
	public class SceneMagicCardUpgradeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E08 RID: 28168 RVA: 0x0013EEC4 File Offset: 0x0013D2C4
		public uint GetMsgID()
		{
			return 501055U;
		}

		// Token: 0x06006E09 RID: 28169 RVA: 0x0013EECB File Offset: 0x0013D2CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E0A RID: 28170 RVA: 0x0013EED3 File Offset: 0x0013D2D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E0B RID: 28171 RVA: 0x0013EEDC File Offset: 0x0013D2DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.upgradeUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.materialUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardId);
		}

		// Token: 0x06006E0C RID: 28172 RVA: 0x0013EF16 File Offset: 0x0013D316
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.upgradeUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.materialUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardId);
		}

		// Token: 0x06006E0D RID: 28173 RVA: 0x0013EF50 File Offset: 0x0013D350
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.upgradeUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.materialUid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardId);
		}

		// Token: 0x06006E0E RID: 28174 RVA: 0x0013EF8A File Offset: 0x0013D38A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.upgradeUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.materialUid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardId);
		}

		// Token: 0x06006E0F RID: 28175 RVA: 0x0013EFC4 File Offset: 0x0013D3C4
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num += 8;
			return num + 4;
		}

		// Token: 0x040031CF RID: 12751
		public const uint MsgID = 501055U;

		// Token: 0x040031D0 RID: 12752
		public uint Sequence;

		// Token: 0x040031D1 RID: 12753
		public ulong upgradeUid;

		// Token: 0x040031D2 RID: 12754
		public ulong materialUid;

		// Token: 0x040031D3 RID: 12755
		public ulong equipUid;

		// Token: 0x040031D4 RID: 12756
		public uint cardId;
	}
}
