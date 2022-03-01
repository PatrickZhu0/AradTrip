using System;

namespace Protocol
{
	// Token: 0x02000995 RID: 2453
	[Protocol]
	public class SceneEquipInscriptionOpenReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E8F RID: 28303 RVA: 0x0013FD94 File Offset: 0x0013E194
		public uint GetMsgID()
		{
			return 501075U;
		}

		// Token: 0x06006E90 RID: 28304 RVA: 0x0013FD9B File Offset: 0x0013E19B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E91 RID: 28305 RVA: 0x0013FDA3 File Offset: 0x0013E1A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E92 RID: 28306 RVA: 0x0013FDAC File Offset: 0x0013E1AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06006E93 RID: 28307 RVA: 0x0013FDCA File Offset: 0x0013E1CA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06006E94 RID: 28308 RVA: 0x0013FDE8 File Offset: 0x0013E1E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06006E95 RID: 28309 RVA: 0x0013FE06 File Offset: 0x0013E206
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06006E96 RID: 28310 RVA: 0x0013FE24 File Offset: 0x0013E224
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04003213 RID: 12819
		public const uint MsgID = 501075U;

		// Token: 0x04003214 RID: 12820
		public uint Sequence;

		// Token: 0x04003215 RID: 12821
		public ulong guid;

		// Token: 0x04003216 RID: 12822
		public uint index;
	}
}
