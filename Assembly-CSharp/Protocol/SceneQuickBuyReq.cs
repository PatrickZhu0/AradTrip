using System;

namespace Protocol
{
	// Token: 0x0200091E RID: 2334
	[Protocol]
	public class SceneQuickBuyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A7B RID: 27259 RVA: 0x00138A95 File Offset: 0x00136E95
		public uint GetMsgID()
		{
			return 507101U;
		}

		// Token: 0x06006A7C RID: 27260 RVA: 0x00138A9C File Offset: 0x00136E9C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A7D RID: 27261 RVA: 0x00138AA4 File Offset: 0x00136EA4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A7E RID: 27262 RVA: 0x00138AAD File Offset: 0x00136EAD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param2);
		}

		// Token: 0x06006A7F RID: 27263 RVA: 0x00138AD9 File Offset: 0x00136ED9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x06006A80 RID: 27264 RVA: 0x00138B05 File Offset: 0x00136F05
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param2);
		}

		// Token: 0x06006A81 RID: 27265 RVA: 0x00138B31 File Offset: 0x00136F31
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x06006A82 RID: 27266 RVA: 0x00138B60 File Offset: 0x00136F60
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			return num + 8;
		}

		// Token: 0x04003044 RID: 12356
		public const uint MsgID = 507101U;

		// Token: 0x04003045 RID: 12357
		public uint Sequence;

		// Token: 0x04003046 RID: 12358
		public byte type;

		// Token: 0x04003047 RID: 12359
		public ulong param1;

		// Token: 0x04003048 RID: 12360
		public ulong param2;
	}
}
