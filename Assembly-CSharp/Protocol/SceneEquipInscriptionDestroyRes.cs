using System;

namespace Protocol
{
	// Token: 0x0200099E RID: 2462
	[Protocol]
	public class SceneEquipInscriptionDestroyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EE0 RID: 28384 RVA: 0x00140858 File Offset: 0x0013EC58
		public uint GetMsgID()
		{
			return 501084U;
		}

		// Token: 0x06006EE1 RID: 28385 RVA: 0x0014085F File Offset: 0x0013EC5F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EE2 RID: 28386 RVA: 0x00140867 File Offset: 0x0013EC67
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EE3 RID: 28387 RVA: 0x00140870 File Offset: 0x0013EC70
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006EE4 RID: 28388 RVA: 0x001408AA File Offset: 0x0013ECAA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006EE5 RID: 28389 RVA: 0x001408E4 File Offset: 0x0013ECE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006EE6 RID: 28390 RVA: 0x0014091E File Offset: 0x0013ED1E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006EE7 RID: 28391 RVA: 0x00140958 File Offset: 0x0013ED58
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003240 RID: 12864
		public const uint MsgID = 501084U;

		// Token: 0x04003241 RID: 12865
		public uint Sequence;

		// Token: 0x04003242 RID: 12866
		public ulong guid;

		// Token: 0x04003243 RID: 12867
		public uint index;

		// Token: 0x04003244 RID: 12868
		public uint inscriptionId;

		// Token: 0x04003245 RID: 12869
		public uint code;
	}
}
