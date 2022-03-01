using System;

namespace Protocol
{
	// Token: 0x020006FB RID: 1787
	[Protocol]
	public class BattleLockSomeOneReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A4F RID: 23119 RVA: 0x00112CA0 File Offset: 0x001110A0
		public uint GetMsgID()
		{
			return 2200013U;
		}

		// Token: 0x06005A50 RID: 23120 RVA: 0x00112CA7 File Offset: 0x001110A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A51 RID: 23121 RVA: 0x00112CAF File Offset: 0x001110AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A52 RID: 23122 RVA: 0x00112CB8 File Offset: 0x001110B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x06005A53 RID: 23123 RVA: 0x00112CE4 File Offset: 0x001110E4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x06005A54 RID: 23124 RVA: 0x00112D10 File Offset: 0x00111110
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x06005A55 RID: 23125 RVA: 0x00112D3C File Offset: 0x0011113C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x06005A56 RID: 23126 RVA: 0x00112D68 File Offset: 0x00111168
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			return num + 4;
		}

		// Token: 0x040024A8 RID: 9384
		public const uint MsgID = 2200013U;

		// Token: 0x040024A9 RID: 9385
		public uint Sequence;

		// Token: 0x040024AA RID: 9386
		public ulong roleId;

		// Token: 0x040024AB RID: 9387
		public ulong dstId;

		// Token: 0x040024AC RID: 9388
		public uint battleID;
	}
}
