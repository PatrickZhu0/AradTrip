using System;

namespace Protocol
{
	// Token: 0x02000988 RID: 2440
	[Protocol]
	public class SceneMagicCardCompOneKeyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E1A RID: 28186 RVA: 0x0013F180 File Offset: 0x0013D580
		public uint GetMsgID()
		{
			return 501057U;
		}

		// Token: 0x06006E1B RID: 28187 RVA: 0x0013F187 File Offset: 0x0013D587
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E1C RID: 28188 RVA: 0x0013F18F File Offset: 0x0013D58F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E1D RID: 28189 RVA: 0x0013F198 File Offset: 0x0013D598
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isCompWhite);
			BaseDLL.encode_int8(buffer, ref pos_, this.isCompBlue);
			BaseDLL.encode_int8(buffer, ref pos_, this.autoUseGold);
			BaseDLL.encode_int8(buffer, ref pos_, this.compNotBind);
		}

		// Token: 0x06006E1E RID: 28190 RVA: 0x0013F1D2 File Offset: 0x0013D5D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCompWhite);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCompBlue);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.autoUseGold);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.compNotBind);
		}

		// Token: 0x06006E1F RID: 28191 RVA: 0x0013F20C File Offset: 0x0013D60C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isCompWhite);
			BaseDLL.encode_int8(buffer, ref pos_, this.isCompBlue);
			BaseDLL.encode_int8(buffer, ref pos_, this.autoUseGold);
			BaseDLL.encode_int8(buffer, ref pos_, this.compNotBind);
		}

		// Token: 0x06006E20 RID: 28192 RVA: 0x0013F246 File Offset: 0x0013D646
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCompWhite);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCompBlue);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.autoUseGold);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.compNotBind);
		}

		// Token: 0x06006E21 RID: 28193 RVA: 0x0013F280 File Offset: 0x0013D680
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x040031DC RID: 12764
		public const uint MsgID = 501057U;

		// Token: 0x040031DD RID: 12765
		public uint Sequence;

		// Token: 0x040031DE RID: 12766
		public byte isCompWhite;

		// Token: 0x040031DF RID: 12767
		public byte isCompBlue;

		// Token: 0x040031E0 RID: 12768
		public byte autoUseGold;

		// Token: 0x040031E1 RID: 12769
		public byte compNotBind;
	}
}
