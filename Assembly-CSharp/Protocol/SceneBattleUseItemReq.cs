using System;

namespace Protocol
{
	// Token: 0x020006F3 RID: 1779
	[Protocol]
	public class SceneBattleUseItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A07 RID: 23047 RVA: 0x0011234A File Offset: 0x0011074A
		public uint GetMsgID()
		{
			return 508901U;
		}

		// Token: 0x06005A08 RID: 23048 RVA: 0x00112351 File Offset: 0x00110751
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A09 RID: 23049 RVA: 0x00112359 File Offset: 0x00110759
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A0A RID: 23050 RVA: 0x00112364 File Offset: 0x00110764
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useAll);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x06005A0B RID: 23051 RVA: 0x001123B8 File Offset: 0x001107B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useAll);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x06005A0C RID: 23052 RVA: 0x0011240C File Offset: 0x0011080C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_int8(buffer, ref pos_, this.useAll);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x06005A0D RID: 23053 RVA: 0x00112460 File Offset: 0x00110860
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.useAll);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x06005A0E RID: 23054 RVA: 0x001124B4 File Offset: 0x001108B4
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002481 RID: 9345
		public const uint MsgID = 508901U;

		// Token: 0x04002482 RID: 9346
		public uint Sequence;

		// Token: 0x04002483 RID: 9347
		public ulong uid;

		// Token: 0x04002484 RID: 9348
		public byte useAll;

		// Token: 0x04002485 RID: 9349
		public uint param1;

		// Token: 0x04002486 RID: 9350
		public uint param2;

		// Token: 0x04002487 RID: 9351
		public uint battleID;
	}
}
