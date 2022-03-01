using System;

namespace Protocol
{
	// Token: 0x02000C88 RID: 3208
	[Protocol]
	public class WorldRemoveRelation : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600848E RID: 33934 RVA: 0x001739B5 File Offset: 0x00171DB5
		public uint GetMsgID()
		{
			return 601704U;
		}

		// Token: 0x0600848F RID: 33935 RVA: 0x001739BC File Offset: 0x00171DBC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008490 RID: 33936 RVA: 0x001739C4 File Offset: 0x00171DC4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008491 RID: 33937 RVA: 0x001739CD File Offset: 0x00171DCD
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06008492 RID: 33938 RVA: 0x001739EB File Offset: 0x00171DEB
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06008493 RID: 33939 RVA: 0x00173A09 File Offset: 0x00171E09
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06008494 RID: 33940 RVA: 0x00173A27 File Offset: 0x00171E27
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06008495 RID: 33941 RVA: 0x00173A48 File Offset: 0x00171E48
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x04003F73 RID: 16243
		public const uint MsgID = 601704U;

		// Token: 0x04003F74 RID: 16244
		public uint Sequence;

		// Token: 0x04003F75 RID: 16245
		public byte type;

		// Token: 0x04003F76 RID: 16246
		public ulong uid;
	}
}
