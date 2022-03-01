using System;

namespace Protocol
{
	// Token: 0x02000CA0 RID: 3232
	[Protocol]
	public class ReplyAddonPay : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008557 RID: 34135 RVA: 0x0017608C File Offset: 0x0017448C
		public uint GetMsgID()
		{
			return 601725U;
		}

		// Token: 0x06008558 RID: 34136 RVA: 0x00176093 File Offset: 0x00174493
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008559 RID: 34137 RVA: 0x0017609B File Offset: 0x0017449B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600855A RID: 34138 RVA: 0x001760A4 File Offset: 0x001744A4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x0600855B RID: 34139 RVA: 0x001760C2 File Offset: 0x001744C2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x0600855C RID: 34140 RVA: 0x001760E0 File Offset: 0x001744E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x0600855D RID: 34141 RVA: 0x001760FE File Offset: 0x001744FE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x0600855E RID: 34142 RVA: 0x0017611C File Offset: 0x0017451C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04003FE5 RID: 16357
		public const uint MsgID = 601725U;

		// Token: 0x04003FE6 RID: 16358
		public uint Sequence;

		// Token: 0x04003FE7 RID: 16359
		public ulong id;

		// Token: 0x04003FE8 RID: 16360
		public byte agree;
	}
}
