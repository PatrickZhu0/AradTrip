using System;

namespace Protocol
{
	// Token: 0x02000864 RID: 2148
	[Protocol]
	public class WorldGuildChallengeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064F6 RID: 25846 RVA: 0x0012CB75 File Offset: 0x0012AF75
		public uint GetMsgID()
		{
			return 601959U;
		}

		// Token: 0x060064F7 RID: 25847 RVA: 0x0012CB7C File Offset: 0x0012AF7C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064F8 RID: 25848 RVA: 0x0012CB84 File Offset: 0x0012AF84
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064F9 RID: 25849 RVA: 0x0012CB8D File Offset: 0x0012AF8D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x060064FA RID: 25850 RVA: 0x0012CBB9 File Offset: 0x0012AFB9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x060064FB RID: 25851 RVA: 0x0012CBE5 File Offset: 0x0012AFE5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x060064FC RID: 25852 RVA: 0x0012CC11 File Offset: 0x0012B011
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x060064FD RID: 25853 RVA: 0x0012CC40 File Offset: 0x0012B040
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D3F RID: 11583
		public const uint MsgID = 601959U;

		// Token: 0x04002D40 RID: 11584
		public uint Sequence;

		// Token: 0x04002D41 RID: 11585
		public byte terrId;

		// Token: 0x04002D42 RID: 11586
		public uint itemId;

		// Token: 0x04002D43 RID: 11587
		public uint itemNum;
	}
}
