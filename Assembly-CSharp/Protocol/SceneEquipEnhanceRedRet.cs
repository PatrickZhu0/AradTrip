using System;

namespace Protocol
{
	// Token: 0x0200098F RID: 2447
	[Protocol]
	public class SceneEquipEnhanceRedRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E59 RID: 28249 RVA: 0x0013FA28 File Offset: 0x0013DE28
		public uint GetMsgID()
		{
			return 501065U;
		}

		// Token: 0x06006E5A RID: 28250 RVA: 0x0013FA2F File Offset: 0x0013DE2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E5B RID: 28251 RVA: 0x0013FA37 File Offset: 0x0013DE37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E5C RID: 28252 RVA: 0x0013FA40 File Offset: 0x0013DE40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E5D RID: 28253 RVA: 0x0013FA50 File Offset: 0x0013DE50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E5E RID: 28254 RVA: 0x0013FA60 File Offset: 0x0013DE60
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E5F RID: 28255 RVA: 0x0013FA70 File Offset: 0x0013DE70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E60 RID: 28256 RVA: 0x0013FA80 File Offset: 0x0013DE80
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040031FE RID: 12798
		public const uint MsgID = 501065U;

		// Token: 0x040031FF RID: 12799
		public uint Sequence;

		// Token: 0x04003200 RID: 12800
		public uint code;
	}
}
