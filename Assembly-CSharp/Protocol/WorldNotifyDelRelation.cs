using System;

namespace Protocol
{
	// Token: 0x02000C84 RID: 3204
	[Protocol]
	public class WorldNotifyDelRelation : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600846D RID: 33901 RVA: 0x0017304C File Offset: 0x0017144C
		public uint GetMsgID()
		{
			return 601706U;
		}

		// Token: 0x0600846E RID: 33902 RVA: 0x00173053 File Offset: 0x00171453
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600846F RID: 33903 RVA: 0x0017305B File Offset: 0x0017145B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008470 RID: 33904 RVA: 0x00173064 File Offset: 0x00171464
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06008471 RID: 33905 RVA: 0x00173082 File Offset: 0x00171482
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06008472 RID: 33906 RVA: 0x001730A0 File Offset: 0x001714A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06008473 RID: 33907 RVA: 0x001730BE File Offset: 0x001714BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06008474 RID: 33908 RVA: 0x001730DC File Offset: 0x001714DC
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 8;
		}

		// Token: 0x04003F5A RID: 16218
		public const uint MsgID = 601706U;

		// Token: 0x04003F5B RID: 16219
		public uint Sequence;

		// Token: 0x04003F5C RID: 16220
		public byte type;

		// Token: 0x04003F5D RID: 16221
		public ulong id;
	}
}
