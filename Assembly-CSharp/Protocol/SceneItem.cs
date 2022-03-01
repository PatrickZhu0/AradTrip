using System;

namespace Protocol
{
	// Token: 0x02000B13 RID: 2835
	public class SceneItem : IProtocolStream
	{
		// Token: 0x060079C0 RID: 31168 RVA: 0x0015E0E7 File Offset: 0x0015C4E7
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data_id);
			this.pos.encode(buffer, ref pos_);
			BaseDLL.encode_uint64(buffer, ref pos_, this.owner);
		}

		// Token: 0x060079C1 RID: 31169 RVA: 0x0015E120 File Offset: 0x0015C520
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data_id);
			this.pos.decode(buffer, ref pos_);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.owner);
		}

		// Token: 0x060079C2 RID: 31170 RVA: 0x0015E159 File Offset: 0x0015C559
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.data_id);
			this.pos.encode(buffer, ref pos_);
			BaseDLL.encode_uint64(buffer, ref pos_, this.owner);
		}

		// Token: 0x060079C3 RID: 31171 RVA: 0x0015E192 File Offset: 0x0015C592
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.data_id);
			this.pos.decode(buffer, ref pos_);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.owner);
		}

		// Token: 0x060079C4 RID: 31172 RVA: 0x0015E1CC File Offset: 0x0015C5CC
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += this.pos.getLen();
			return num + 8;
		}

		// Token: 0x0400396A RID: 14698
		public ulong guid;

		// Token: 0x0400396B RID: 14699
		public uint data_id;

		// Token: 0x0400396C RID: 14700
		public SceneItemPos pos = new SceneItemPos();

		// Token: 0x0400396D RID: 14701
		public ulong owner;
	}
}
