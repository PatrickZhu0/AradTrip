using System;

namespace Protocol
{
	// Token: 0x02000AFF RID: 2815
	public class SceneNpc : IProtocolStream
	{
		// Token: 0x06007915 RID: 30997 RVA: 0x0015CECC File Offset: 0x0015B2CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.funcType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			this.pos.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06007916 RID: 30998 RVA: 0x0015CF48 File Offset: 0x0015B348
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.funcType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			this.pos.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06007917 RID: 30999 RVA: 0x0015CFC4 File Offset: 0x0015B3C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.funcType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			this.pos.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06007918 RID: 31000 RVA: 0x0015D040 File Offset: 0x0015B440
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.funcType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			this.pos.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06007919 RID: 31001 RVA: 0x0015D0BC File Offset: 0x0015B4BC
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num++;
			num += 4;
			num += this.pos.getLen();
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003927 RID: 14631
		public ulong guid;

		// Token: 0x04003928 RID: 14632
		public byte type;

		// Token: 0x04003929 RID: 14633
		public byte funcType;

		// Token: 0x0400392A RID: 14634
		public uint id;

		// Token: 0x0400392B RID: 14635
		public NpcPos pos = new NpcPos();

		// Token: 0x0400392C RID: 14636
		public uint remainTimes;

		// Token: 0x0400392D RID: 14637
		public uint totalTimes;

		// Token: 0x0400392E RID: 14638
		public uint dungeonId;
	}
}
