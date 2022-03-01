using System;

namespace Protocol
{
	// Token: 0x0200098A RID: 2442
	[Protocol]
	public class SceneEquipEnhanceUpgrade : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E2C RID: 28204 RVA: 0x0013F57D File Offset: 0x0013D97D
		public uint GetMsgID()
		{
			return 501060U;
		}

		// Token: 0x06006E2D RID: 28205 RVA: 0x0013F584 File Offset: 0x0013D984
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E2E RID: 28206 RVA: 0x0013F58C File Offset: 0x0013D98C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E2F RID: 28207 RVA: 0x0013F595 File Offset: 0x0013D995
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useUnbreak);
			BaseDLL.encode_uint64(buffer, ref pos_, this.strTickt);
		}

		// Token: 0x06006E30 RID: 28208 RVA: 0x0013F5C1 File Offset: 0x0013D9C1
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useUnbreak);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.strTickt);
		}

		// Token: 0x06006E31 RID: 28209 RVA: 0x0013F5ED File Offset: 0x0013D9ED
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.euqipUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useUnbreak);
			BaseDLL.encode_uint64(buffer, ref pos_, this.strTickt);
		}

		// Token: 0x06006E32 RID: 28210 RVA: 0x0013F619 File Offset: 0x0013DA19
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.euqipUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useUnbreak);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.strTickt);
		}

		// Token: 0x06006E33 RID: 28211 RVA: 0x0013F648 File Offset: 0x0013DA48
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + 8;
		}

		// Token: 0x040031EA RID: 12778
		public const uint MsgID = 501060U;

		// Token: 0x040031EB RID: 12779
		public uint Sequence;

		// Token: 0x040031EC RID: 12780
		public ulong euqipUid;

		// Token: 0x040031ED RID: 12781
		public byte useUnbreak;

		// Token: 0x040031EE RID: 12782
		public ulong strTickt;
	}
}
