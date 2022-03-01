using System;

namespace Protocol
{
	// Token: 0x02000B1A RID: 2842
	[Protocol]
	public class SceneBattleBirthTransfer : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079F9 RID: 31225 RVA: 0x0015EA98 File Offset: 0x0015CE98
		public uint GetMsgID()
		{
			return 508916U;
		}

		// Token: 0x060079FA RID: 31226 RVA: 0x0015EA9F File Offset: 0x0015CE9F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079FB RID: 31227 RVA: 0x0015EAA7 File Offset: 0x0015CEA7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079FC RID: 31228 RVA: 0x0015EAB0 File Offset: 0x0015CEB0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.regionID);
		}

		// Token: 0x060079FD RID: 31229 RVA: 0x0015EACE File Offset: 0x0015CECE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.regionID);
		}

		// Token: 0x060079FE RID: 31230 RVA: 0x0015EAEC File Offset: 0x0015CEEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.regionID);
		}

		// Token: 0x060079FF RID: 31231 RVA: 0x0015EB0A File Offset: 0x0015CF0A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.regionID);
		}

		// Token: 0x06007A00 RID: 31232 RVA: 0x0015EB28 File Offset: 0x0015CF28
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003983 RID: 14723
		public const uint MsgID = 508916U;

		// Token: 0x04003984 RID: 14724
		public uint Sequence;

		// Token: 0x04003985 RID: 14725
		public uint battleID;

		// Token: 0x04003986 RID: 14726
		public uint regionID;
	}
}
