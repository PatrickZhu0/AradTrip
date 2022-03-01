using System;

namespace Protocol
{
	// Token: 0x02000B1B RID: 2843
	[Protocol]
	public class SceneBattleBirthTransferNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A02 RID: 31234 RVA: 0x0015EB48 File Offset: 0x0015CF48
		public uint GetMsgID()
		{
			return 508917U;
		}

		// Token: 0x06007A03 RID: 31235 RVA: 0x0015EB4F File Offset: 0x0015CF4F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A04 RID: 31236 RVA: 0x0015EB57 File Offset: 0x0015CF57
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A05 RID: 31237 RVA: 0x0015EB60 File Offset: 0x0015CF60
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.birthPosX);
			BaseDLL.encode_uint32(buffer, ref pos_, this.birthPosY);
		}

		// Token: 0x06007A06 RID: 31238 RVA: 0x0015EB9A File Offset: 0x0015CF9A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.birthPosX);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.birthPosY);
		}

		// Token: 0x06007A07 RID: 31239 RVA: 0x0015EBD4 File Offset: 0x0015CFD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.birthPosX);
			BaseDLL.encode_uint32(buffer, ref pos_, this.birthPosY);
		}

		// Token: 0x06007A08 RID: 31240 RVA: 0x0015EC0E File Offset: 0x0015D00E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.birthPosX);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.birthPosY);
		}

		// Token: 0x06007A09 RID: 31241 RVA: 0x0015EC48 File Offset: 0x0015D048
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003987 RID: 14727
		public const uint MsgID = 508917U;

		// Token: 0x04003988 RID: 14728
		public uint Sequence;

		// Token: 0x04003989 RID: 14729
		public uint battleID;

		// Token: 0x0400398A RID: 14730
		public ulong playerID;

		// Token: 0x0400398B RID: 14731
		public uint birthPosX;

		// Token: 0x0400398C RID: 14732
		public uint birthPosY;
	}
}
