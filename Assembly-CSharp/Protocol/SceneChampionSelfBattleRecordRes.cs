using System;

namespace Protocol
{
	// Token: 0x0200075A RID: 1882
	[Protocol]
	public class SceneChampionSelfBattleRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D52 RID: 23890 RVA: 0x00118614 File Offset: 0x00116A14
		public uint GetMsgID()
		{
			return 509822U;
		}

		// Token: 0x06005D53 RID: 23891 RVA: 0x0011861B File Offset: 0x00116A1B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D54 RID: 23892 RVA: 0x00118623 File Offset: 0x00116A23
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D55 RID: 23893 RVA: 0x0011862C File Offset: 0x00116A2C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.win);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lose);
			BaseDLL.encode_int8(buffer, ref pos_, this.relive);
		}

		// Token: 0x06005D56 RID: 23894 RVA: 0x00118658 File Offset: 0x00116A58
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.win);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lose);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.relive);
		}

		// Token: 0x06005D57 RID: 23895 RVA: 0x00118684 File Offset: 0x00116A84
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.win);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lose);
			BaseDLL.encode_int8(buffer, ref pos_, this.relive);
		}

		// Token: 0x06005D58 RID: 23896 RVA: 0x001186B0 File Offset: 0x00116AB0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.win);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lose);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.relive);
		}

		// Token: 0x06005D59 RID: 23897 RVA: 0x001186DC File Offset: 0x00116ADC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002640 RID: 9792
		public const uint MsgID = 509822U;

		// Token: 0x04002641 RID: 9793
		public uint Sequence;

		// Token: 0x04002642 RID: 9794
		public uint win;

		// Token: 0x04002643 RID: 9795
		public uint lose;

		// Token: 0x04002644 RID: 9796
		public byte relive;
	}
}
