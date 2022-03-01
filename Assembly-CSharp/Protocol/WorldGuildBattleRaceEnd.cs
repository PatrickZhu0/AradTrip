using System;

namespace Protocol
{
	// Token: 0x0200085E RID: 2142
	[Protocol]
	public class WorldGuildBattleRaceEnd : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064C0 RID: 25792 RVA: 0x0012C1C2 File Offset: 0x0012A5C2
		public uint GetMsgID()
		{
			return 601953U;
		}

		// Token: 0x060064C1 RID: 25793 RVA: 0x0012C1C9 File Offset: 0x0012A5C9
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064C2 RID: 25794 RVA: 0x0012C1D1 File Offset: 0x0012A5D1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064C3 RID: 25795 RVA: 0x0012C1DA File Offset: 0x0012A5DA
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newScore);
		}

		// Token: 0x060064C4 RID: 25796 RVA: 0x0012C206 File Offset: 0x0012A606
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newScore);
		}

		// Token: 0x060064C5 RID: 25797 RVA: 0x0012C232 File Offset: 0x0012A632
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newScore);
		}

		// Token: 0x060064C6 RID: 25798 RVA: 0x0012C25E File Offset: 0x0012A65E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newScore);
		}

		// Token: 0x060064C7 RID: 25799 RVA: 0x0012C28C File Offset: 0x0012A68C
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002D20 RID: 11552
		public const uint MsgID = 601953U;

		// Token: 0x04002D21 RID: 11553
		public uint Sequence;

		// Token: 0x04002D22 RID: 11554
		public byte result;

		// Token: 0x04002D23 RID: 11555
		public uint oldScore;

		// Token: 0x04002D24 RID: 11556
		public uint newScore;
	}
}
