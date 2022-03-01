using System;

namespace Protocol
{
	// Token: 0x02000981 RID: 2433
	public class depositItem : IProtocolStream
	{
		// Token: 0x06006DDE RID: 28126 RVA: 0x0013EAA3 File Offset: 0x0013CEA3
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
			this.itemReward.encode(buffer, ref pos_);
		}

		// Token: 0x06006DDF RID: 28127 RVA: 0x0013EACE File Offset: 0x0013CECE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
			this.itemReward.decode(buffer, ref pos_);
		}

		// Token: 0x06006DE0 RID: 28128 RVA: 0x0013EAF9 File Offset: 0x0013CEF9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
			this.itemReward.encode(buffer, ref pos_);
		}

		// Token: 0x06006DE1 RID: 28129 RVA: 0x0013EB24 File Offset: 0x0013CF24
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
			this.itemReward.decode(buffer, ref pos_);
		}

		// Token: 0x06006DE2 RID: 28130 RVA: 0x0013EB50 File Offset: 0x0013CF50
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + this.itemReward.getLen();
		}

		// Token: 0x040031BF RID: 12735
		public ulong guid;

		// Token: 0x040031C0 RID: 12736
		public uint createTime;

		// Token: 0x040031C1 RID: 12737
		public ItemReward itemReward = new ItemReward();
	}
}
