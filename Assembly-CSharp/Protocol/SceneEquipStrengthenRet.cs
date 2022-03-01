using System;

namespace Protocol
{
	// Token: 0x020008EB RID: 2283
	[Protocol]
	public class SceneEquipStrengthenRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068B3 RID: 26803 RVA: 0x00135D84 File Offset: 0x00134184
		public uint GetMsgID()
		{
			return 500921U;
		}

		// Token: 0x060068B4 RID: 26804 RVA: 0x00135D8B File Offset: 0x0013418B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068B5 RID: 26805 RVA: 0x00135D93 File Offset: 0x00134193
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068B6 RID: 26806 RVA: 0x00135D9C File Offset: 0x0013419C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060068B7 RID: 26807 RVA: 0x00135DAC File Offset: 0x001341AC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060068B8 RID: 26808 RVA: 0x00135DBC File Offset: 0x001341BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060068B9 RID: 26809 RVA: 0x00135DCC File Offset: 0x001341CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060068BA RID: 26810 RVA: 0x00135DDC File Offset: 0x001341DC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F7F RID: 12159
		public const uint MsgID = 500921U;

		// Token: 0x04002F80 RID: 12160
		public uint Sequence;

		// Token: 0x04002F81 RID: 12161
		public uint code;
	}
}
