using System;

namespace Protocol
{
	// Token: 0x0200077C RID: 1916
	[Protocol]
	public class SceneNotifyExecGmcmd : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E5A RID: 24154 RVA: 0x0011AE64 File Offset: 0x00119264
		public uint GetMsgID()
		{
			return 500802U;
		}

		// Token: 0x06005E5B RID: 24155 RVA: 0x0011AE6B File Offset: 0x0011926B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E5C RID: 24156 RVA: 0x0011AE73 File Offset: 0x00119273
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E5D RID: 24157 RVA: 0x0011AE7C File Offset: 0x0011927C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.suc);
		}

		// Token: 0x06005E5E RID: 24158 RVA: 0x0011AE8C File Offset: 0x0011928C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.suc);
		}

		// Token: 0x06005E5F RID: 24159 RVA: 0x0011AE9C File Offset: 0x0011929C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.suc);
		}

		// Token: 0x06005E60 RID: 24160 RVA: 0x0011AEAC File Offset: 0x001192AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.suc);
		}

		// Token: 0x06005E61 RID: 24161 RVA: 0x0011AEBC File Offset: 0x001192BC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x040026C2 RID: 9922
		public const uint MsgID = 500802U;

		// Token: 0x040026C3 RID: 9923
		public uint Sequence;

		// Token: 0x040026C4 RID: 9924
		public byte suc;
	}
}
