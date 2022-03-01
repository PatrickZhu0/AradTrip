using System;

namespace Protocol
{
	// Token: 0x020008DD RID: 2269
	[Protocol]
	public class SceneSellItemRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006835 RID: 26677 RVA: 0x0013523C File Offset: 0x0013363C
		public uint GetMsgID()
		{
			return 500904U;
		}

		// Token: 0x06006836 RID: 26678 RVA: 0x00135243 File Offset: 0x00133643
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006837 RID: 26679 RVA: 0x0013524B File Offset: 0x0013364B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006838 RID: 26680 RVA: 0x00135254 File Offset: 0x00133654
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006839 RID: 26681 RVA: 0x00135264 File Offset: 0x00133664
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600683A RID: 26682 RVA: 0x00135274 File Offset: 0x00133674
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600683B RID: 26683 RVA: 0x00135284 File Offset: 0x00133684
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600683C RID: 26684 RVA: 0x00135294 File Offset: 0x00133694
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F4F RID: 12111
		public const uint MsgID = 500904U;

		// Token: 0x04002F50 RID: 12112
		public uint Sequence;

		// Token: 0x04002F51 RID: 12113
		public uint code;
	}
}
