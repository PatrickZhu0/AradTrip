using System;

namespace Protocol
{
	// Token: 0x02000B8C RID: 2956
	[Protocol]
	public class WorldTeamChangePosStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D47 RID: 32071 RVA: 0x00164F9C File Offset: 0x0016339C
		public uint GetMsgID()
		{
			return 601630U;
		}

		// Token: 0x06007D48 RID: 32072 RVA: 0x00164FA3 File Offset: 0x001633A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D49 RID: 32073 RVA: 0x00164FAB File Offset: 0x001633AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D4A RID: 32074 RVA: 0x00164FB4 File Offset: 0x001633B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.open);
		}

		// Token: 0x06007D4B RID: 32075 RVA: 0x00164FD2 File Offset: 0x001633D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.open);
		}

		// Token: 0x06007D4C RID: 32076 RVA: 0x00164FF0 File Offset: 0x001633F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_int8(buffer, ref pos_, this.open);
		}

		// Token: 0x06007D4D RID: 32077 RVA: 0x0016500E File Offset: 0x0016340E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.open);
		}

		// Token: 0x06007D4E RID: 32078 RVA: 0x0016502C File Offset: 0x0016342C
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04003B6E RID: 15214
		public const uint MsgID = 601630U;

		// Token: 0x04003B6F RID: 15215
		public uint Sequence;

		// Token: 0x04003B70 RID: 15216
		public byte pos;

		// Token: 0x04003B71 RID: 15217
		public byte open;
	}
}
