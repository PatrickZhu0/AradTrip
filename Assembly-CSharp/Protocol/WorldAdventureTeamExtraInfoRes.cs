using System;

namespace Protocol
{
	// Token: 0x0200069F RID: 1695
	[Protocol]
	public class WorldAdventureTeamExtraInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057AA RID: 22442 RVA: 0x0010B1C3 File Offset: 0x001095C3
		public uint GetMsgID()
		{
			return 608610U;
		}

		// Token: 0x060057AB RID: 22443 RVA: 0x0010B1CA File Offset: 0x001095CA
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057AC RID: 22444 RVA: 0x0010B1D2 File Offset: 0x001095D2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057AD RID: 22445 RVA: 0x0010B1DB File Offset: 0x001095DB
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			this.extraInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060057AE RID: 22446 RVA: 0x0010B1F8 File Offset: 0x001095F8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			this.extraInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060057AF RID: 22447 RVA: 0x0010B215 File Offset: 0x00109615
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			this.extraInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060057B0 RID: 22448 RVA: 0x0010B232 File Offset: 0x00109632
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			this.extraInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060057B1 RID: 22449 RVA: 0x0010B250 File Offset: 0x00109650
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.extraInfo.getLen();
		}

		// Token: 0x040022DA RID: 8922
		public const uint MsgID = 608610U;

		// Token: 0x040022DB RID: 8923
		public uint Sequence;

		// Token: 0x040022DC RID: 8924
		public uint resCode;

		// Token: 0x040022DD RID: 8925
		public AdventureTeamExtraInfo extraInfo = new AdventureTeamExtraInfo();
	}
}
