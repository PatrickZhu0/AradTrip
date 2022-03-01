using System;

namespace Protocol
{
	// Token: 0x02000B3D RID: 2877
	[Protocol]
	public class SceneSyncFuncUnlock : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AEC RID: 31468 RVA: 0x001606D0 File Offset: 0x0015EAD0
		public uint GetMsgID()
		{
			return 501213U;
		}

		// Token: 0x06007AED RID: 31469 RVA: 0x001606D7 File Offset: 0x0015EAD7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007AEE RID: 31470 RVA: 0x001606DF File Offset: 0x0015EADF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007AEF RID: 31471 RVA: 0x001606E8 File Offset: 0x0015EAE8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.funcId);
		}

		// Token: 0x06007AF0 RID: 31472 RVA: 0x001606F8 File Offset: 0x0015EAF8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.funcId);
		}

		// Token: 0x06007AF1 RID: 31473 RVA: 0x00160708 File Offset: 0x0015EB08
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.funcId);
		}

		// Token: 0x06007AF2 RID: 31474 RVA: 0x00160718 File Offset: 0x0015EB18
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.funcId);
		}

		// Token: 0x06007AF3 RID: 31475 RVA: 0x00160728 File Offset: 0x0015EB28
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003A41 RID: 14913
		public const uint MsgID = 501213U;

		// Token: 0x04003A42 RID: 14914
		public uint Sequence;

		// Token: 0x04003A43 RID: 14915
		public byte funcId;
	}
}
