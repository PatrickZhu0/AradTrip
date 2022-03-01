using System;

namespace Protocol
{
	// Token: 0x0200097A RID: 2426
	[Protocol]
	public class SceneEquieUpdateRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DA2 RID: 28066 RVA: 0x0013E284 File Offset: 0x0013C684
		public uint GetMsgID()
		{
			return 501049U;
		}

		// Token: 0x06006DA3 RID: 28067 RVA: 0x0013E28B File Offset: 0x0013C68B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DA4 RID: 28068 RVA: 0x0013E293 File Offset: 0x0013C693
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DA5 RID: 28069 RVA: 0x0013E29C File Offset: 0x0013C69C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
		}

		// Token: 0x06006DA6 RID: 28070 RVA: 0x0013E2BA File Offset: 0x0013C6BA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
		}

		// Token: 0x06006DA7 RID: 28071 RVA: 0x0013E2D8 File Offset: 0x0013C6D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint64(buffer, ref pos_, this.equipUid);
		}

		// Token: 0x06006DA8 RID: 28072 RVA: 0x0013E2F6 File Offset: 0x0013C6F6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equipUid);
		}

		// Token: 0x06006DA9 RID: 28073 RVA: 0x0013E314 File Offset: 0x0013C714
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040031A2 RID: 12706
		public const uint MsgID = 501049U;

		// Token: 0x040031A3 RID: 12707
		public uint Sequence;

		// Token: 0x040031A4 RID: 12708
		public uint code;

		// Token: 0x040031A5 RID: 12709
		public ulong equipUid;
	}
}
