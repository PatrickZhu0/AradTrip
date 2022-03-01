using System;

namespace Protocol
{
	// Token: 0x020008ED RID: 2285
	[Protocol]
	public class SceneShopQueryRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068C5 RID: 26821 RVA: 0x00135EA8 File Offset: 0x001342A8
		public uint GetMsgID()
		{
			return 500923U;
		}

		// Token: 0x060068C6 RID: 26822 RVA: 0x00135EAF File Offset: 0x001342AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068C7 RID: 26823 RVA: 0x00135EB7 File Offset: 0x001342B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068C8 RID: 26824 RVA: 0x00135EC0 File Offset: 0x001342C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060068C9 RID: 26825 RVA: 0x00135ED0 File Offset: 0x001342D0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060068CA RID: 26826 RVA: 0x00135EE0 File Offset: 0x001342E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060068CB RID: 26827 RVA: 0x00135EF0 File Offset: 0x001342F0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060068CC RID: 26828 RVA: 0x00135F00 File Offset: 0x00134300
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F86 RID: 12166
		public const uint MsgID = 500923U;

		// Token: 0x04002F87 RID: 12167
		public uint Sequence;

		// Token: 0x04002F88 RID: 12168
		public uint code;
	}
}
