using System;

namespace Protocol
{
	// Token: 0x0200078A RID: 1930
	public class DailyTodoInfo : IProtocolStream
	{
		// Token: 0x06005ED2 RID: 24274 RVA: 0x0011C540 File Offset: 0x0011A940
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayProgress);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayProgTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayProgMax);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekProgress);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekProgTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekProgMax);
		}

		// Token: 0x06005ED3 RID: 24275 RVA: 0x0011C5C0 File Offset: 0x0011A9C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayProgress);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayProgTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayProgMax);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekProgress);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekProgTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekProgMax);
		}

		// Token: 0x06005ED4 RID: 24276 RVA: 0x0011C640 File Offset: 0x0011AA40
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayProgress);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayProgTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dayProgMax);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekProgress);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekProgTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekProgMax);
		}

		// Token: 0x06005ED5 RID: 24277 RVA: 0x0011C6C0 File Offset: 0x0011AAC0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayProgress);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayProgTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dayProgMax);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekProgress);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekProgTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekProgMax);
		}

		// Token: 0x06005ED6 RID: 24278 RVA: 0x0011C740 File Offset: 0x0011AB40
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400270D RID: 9997
		public ulong id;

		// Token: 0x0400270E RID: 9998
		public uint dataId;

		// Token: 0x0400270F RID: 9999
		public uint dayProgress;

		// Token: 0x04002710 RID: 10000
		public uint dayProgTime;

		// Token: 0x04002711 RID: 10001
		public uint dayProgMax;

		// Token: 0x04002712 RID: 10002
		public uint weekProgress;

		// Token: 0x04002713 RID: 10003
		public uint weekProgTime;

		// Token: 0x04002714 RID: 10004
		public uint weekProgMax;
	}
}
