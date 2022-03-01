using System;

namespace Protocol
{
	// Token: 0x02000717 RID: 1815
	[Protocol]
	public class SceneBattleNotifyBeTraped : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B42 RID: 23362 RVA: 0x00114D30 File Offset: 0x00113130
		public uint GetMsgID()
		{
			return 508932U;
		}

		// Token: 0x06005B43 RID: 23363 RVA: 0x00114D37 File Offset: 0x00113137
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B44 RID: 23364 RVA: 0x00114D3F File Offset: 0x0011313F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B45 RID: 23365 RVA: 0x00114D48 File Offset: 0x00113148
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownerID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x06005B46 RID: 23366 RVA: 0x00114D9C File Offset: 0x0011319C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownerID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06005B47 RID: 23367 RVA: 0x00114DF0 File Offset: 0x001131F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.ownerID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x06005B48 RID: 23368 RVA: 0x00114E44 File Offset: 0x00113244
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.ownerID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06005B49 RID: 23369 RVA: 0x00114E98 File Offset: 0x00113298
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400252E RID: 9518
		public const uint MsgID = 508932U;

		// Token: 0x0400252F RID: 9519
		public uint Sequence;

		// Token: 0x04002530 RID: 9520
		public uint battleID;

		// Token: 0x04002531 RID: 9521
		public ulong playerID;

		// Token: 0x04002532 RID: 9522
		public ulong ownerID;

		// Token: 0x04002533 RID: 9523
		public uint x;

		// Token: 0x04002534 RID: 9524
		public uint y;
	}
}
