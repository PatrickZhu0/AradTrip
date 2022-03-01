using System;

namespace Protocol
{
	// Token: 0x02000998 RID: 2456
	[Protocol]
	public class SceneEquipInscriptionMountRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EAA RID: 28330 RVA: 0x00140058 File Offset: 0x0013E458
		public uint GetMsgID()
		{
			return 501078U;
		}

		// Token: 0x06006EAB RID: 28331 RVA: 0x0014005F File Offset: 0x0013E45F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EAC RID: 28332 RVA: 0x00140067 File Offset: 0x0013E467
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EAD RID: 28333 RVA: 0x00140070 File Offset: 0x0013E470
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.inscriptionGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006EAE RID: 28334 RVA: 0x001400C4 File Offset: 0x0013E4C4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inscriptionGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006EAF RID: 28335 RVA: 0x00140118 File Offset: 0x0013E518
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint64(buffer, ref pos_, this.inscriptionGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006EB0 RID: 28336 RVA: 0x0014016C File Offset: 0x0013E56C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inscriptionGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006EB1 RID: 28337 RVA: 0x001401C0 File Offset: 0x0013E5C0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003222 RID: 12834
		public const uint MsgID = 501078U;

		// Token: 0x04003223 RID: 12835
		public uint Sequence;

		// Token: 0x04003224 RID: 12836
		public ulong guid;

		// Token: 0x04003225 RID: 12837
		public uint index;

		// Token: 0x04003226 RID: 12838
		public ulong inscriptionGuid;

		// Token: 0x04003227 RID: 12839
		public uint inscriptionId;

		// Token: 0x04003228 RID: 12840
		public uint code;
	}
}
