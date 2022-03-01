using System;

namespace Protocol
{
	// Token: 0x02000701 RID: 1793
	[Protocol]
	public class BattleNotifyBattleInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A82 RID: 23170 RVA: 0x001135AC File Offset: 0x001119AC
		public uint GetMsgID()
		{
			return 2200010U;
		}

		// Token: 0x06005A83 RID: 23171 RVA: 0x001135B3 File Offset: 0x001119B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A84 RID: 23172 RVA: 0x001135BB File Offset: 0x001119BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A85 RID: 23173 RVA: 0x001135C4 File Offset: 0x001119C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerNum);
		}

		// Token: 0x06005A86 RID: 23174 RVA: 0x001135E2 File Offset: 0x001119E2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerNum);
		}

		// Token: 0x06005A87 RID: 23175 RVA: 0x00113600 File Offset: 0x00111A00
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerNum);
		}

		// Token: 0x06005A88 RID: 23176 RVA: 0x0011361E File Offset: 0x00111A1E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerNum);
		}

		// Token: 0x06005A89 RID: 23177 RVA: 0x0011363C File Offset: 0x00111A3C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040024CA RID: 9418
		public const uint MsgID = 2200010U;

		// Token: 0x040024CB RID: 9419
		public uint Sequence;

		// Token: 0x040024CC RID: 9420
		public uint battleID;

		// Token: 0x040024CD RID: 9421
		public uint playerNum;
	}
}
