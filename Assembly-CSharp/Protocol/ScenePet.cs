using System;

namespace Protocol
{
	// Token: 0x02000A4E RID: 2638
	public class ScenePet : IProtocolStream
	{
		// Token: 0x06007417 RID: 29719 RVA: 0x00150B7C File Offset: 0x0014EF7C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
		}

		// Token: 0x06007418 RID: 29720 RVA: 0x00150BA8 File Offset: 0x0014EFA8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06007419 RID: 29721 RVA: 0x00150BD4 File Offset: 0x0014EFD4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
		}

		// Token: 0x0600741A RID: 29722 RVA: 0x00150C00 File Offset: 0x0014F000
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
		}

		// Token: 0x0600741B RID: 29723 RVA: 0x00150C2C File Offset: 0x0014F02C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 2;
		}

		// Token: 0x040035EA RID: 13802
		public ulong id;

		// Token: 0x040035EB RID: 13803
		public uint dataId;

		// Token: 0x040035EC RID: 13804
		public ushort level;
	}
}
