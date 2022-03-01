using System;

namespace Protocol
{
	// Token: 0x02000945 RID: 2373
	[Protocol]
	public class SceneEquipTransferRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BD1 RID: 27601 RVA: 0x0013ABF0 File Offset: 0x00138FF0
		public uint GetMsgID()
		{
			return 501018U;
		}

		// Token: 0x06006BD2 RID: 27602 RVA: 0x0013ABF7 File Offset: 0x00138FF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BD3 RID: 27603 RVA: 0x0013ABFF File Offset: 0x00138FFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BD4 RID: 27604 RVA: 0x0013AC08 File Offset: 0x00139008
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006BD5 RID: 27605 RVA: 0x0013AC18 File Offset: 0x00139018
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006BD6 RID: 27606 RVA: 0x0013AC28 File Offset: 0x00139028
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006BD7 RID: 27607 RVA: 0x0013AC38 File Offset: 0x00139038
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006BD8 RID: 27608 RVA: 0x0013AC48 File Offset: 0x00139048
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040030D4 RID: 12500
		public const uint MsgID = 501018U;

		// Token: 0x040030D5 RID: 12501
		public uint Sequence;

		// Token: 0x040030D6 RID: 12502
		public uint code;
	}
}
