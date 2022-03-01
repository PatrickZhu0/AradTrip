using System;

namespace Protocol
{
	// Token: 0x02000987 RID: 2439
	[Protocol]
	public class SceneMagicCardUpgradeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E11 RID: 28177 RVA: 0x0013EFEC File Offset: 0x0013D3EC
		public uint GetMsgID()
		{
			return 501056U;
		}

		// Token: 0x06006E12 RID: 28178 RVA: 0x0013EFF3 File Offset: 0x0013D3F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E13 RID: 28179 RVA: 0x0013EFFB File Offset: 0x0013D3FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E14 RID: 28180 RVA: 0x0013F004 File Offset: 0x0013D404
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardTypeId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cardLev);
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardGuid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
		}

		// Token: 0x06006E15 RID: 28181 RVA: 0x0013F058 File Offset: 0x0013D458
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardTypeId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cardLev);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardGuid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
		}

		// Token: 0x06006E16 RID: 28182 RVA: 0x0013F0AC File Offset: 0x0013D4AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.cardTypeId);
			BaseDLL.encode_int8(buffer, ref pos_, this.cardLev);
			BaseDLL.encode_uint64(buffer, ref pos_, this.cardGuid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
		}

		// Token: 0x06006E17 RID: 28183 RVA: 0x0013F100 File Offset: 0x0013D500
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.cardTypeId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.cardLev);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cardGuid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
		}

		// Token: 0x06006E18 RID: 28184 RVA: 0x0013F154 File Offset: 0x0013D554
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			num += 8;
			return num + 8;
		}

		// Token: 0x040031D5 RID: 12757
		public const uint MsgID = 501056U;

		// Token: 0x040031D6 RID: 12758
		public uint Sequence;

		// Token: 0x040031D7 RID: 12759
		public uint code;

		// Token: 0x040031D8 RID: 12760
		public uint cardTypeId;

		// Token: 0x040031D9 RID: 12761
		public byte cardLev;

		// Token: 0x040031DA RID: 12762
		public ulong cardGuid;

		// Token: 0x040031DB RID: 12763
		public ulong equipUid;
	}
}
