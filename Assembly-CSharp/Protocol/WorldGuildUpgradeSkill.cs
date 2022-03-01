using System;

namespace Protocol
{
	// Token: 0x02000847 RID: 2119
	[Protocol]
	public class WorldGuildUpgradeSkill : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063F1 RID: 25585 RVA: 0x0012B3DD File Offset: 0x001297DD
		public uint GetMsgID()
		{
			return 601931U;
		}

		// Token: 0x060063F2 RID: 25586 RVA: 0x0012B3E4 File Offset: 0x001297E4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063F3 RID: 25587 RVA: 0x0012B3EC File Offset: 0x001297EC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063F4 RID: 25588 RVA: 0x0012B3F5 File Offset: 0x001297F5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.skillId);
		}

		// Token: 0x060063F5 RID: 25589 RVA: 0x0012B405 File Offset: 0x00129805
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.skillId);
		}

		// Token: 0x060063F6 RID: 25590 RVA: 0x0012B415 File Offset: 0x00129815
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.skillId);
		}

		// Token: 0x060063F7 RID: 25591 RVA: 0x0012B425 File Offset: 0x00129825
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.skillId);
		}

		// Token: 0x060063F8 RID: 25592 RVA: 0x0012B438 File Offset: 0x00129838
		public int getLen()
		{
			int num = 0;
			return num + 2;
		}

		// Token: 0x04002CD6 RID: 11478
		public const uint MsgID = 601931U;

		// Token: 0x04002CD7 RID: 11479
		public uint Sequence;

		// Token: 0x04002CD8 RID: 11480
		public ushort skillId;
	}
}
