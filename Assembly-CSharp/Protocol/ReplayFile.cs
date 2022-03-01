using System;

namespace Protocol
{
	// Token: 0x02000AB0 RID: 2736
	public class ReplayFile : IProtocolStream
	{
		// Token: 0x060076EA RID: 30442 RVA: 0x00157CD8 File Offset: 0x001560D8
		public void encode(byte[] buffer, ref int pos_)
		{
			this.header.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.results.Length);
			for (int j = 0; j < this.results.Length; j++)
			{
				this.results[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060076EB RID: 30443 RVA: 0x00157D64 File Offset: 0x00156164
		public void decode(byte[] buffer, ref int pos_)
		{
			this.header.decode(buffer, ref pos_);
			uint num = 0U;
			BaseDLL.decode_uint32(buffer, ref pos_, ref num);
			this.frames = new Frame[num];
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i] = new Frame();
				this.frames[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.results = new ReplayRaceResult[(int)num2];
			for (int j = 0; j < this.results.Length; j++)
			{
				this.results[j] = new ReplayRaceResult();
				this.results[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060076EC RID: 30444 RVA: 0x00157E1C File Offset: 0x0015621C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.header.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.frames.Length);
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.results.Length);
			for (int j = 0; j < this.results.Length; j++)
			{
				this.results[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060076ED RID: 30445 RVA: 0x00157EA8 File Offset: 0x001562A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.header.decode(buffer, ref pos_);
			uint num = 0U;
			BaseDLL.decode_uint32(buffer, ref pos_, ref num);
			this.frames = new Frame[num];
			for (int i = 0; i < this.frames.Length; i++)
			{
				this.frames[i] = new Frame();
				this.frames[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.results = new ReplayRaceResult[(int)num2];
			for (int j = 0; j < this.results.Length; j++)
			{
				this.results[j] = new ReplayRaceResult();
				this.results[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060076EE RID: 30446 RVA: 0x00157F60 File Offset: 0x00156360
		public int getLen()
		{
			int num = 0;
			num += this.header.getLen();
			num += 4;
			for (int i = 0; i < this.frames.Length; i++)
			{
				num += this.frames[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.results.Length; j++)
			{
				num += this.results[j].getLen();
			}
			return num;
		}

		// Token: 0x040037AC RID: 14252
		public ReplayHeader header = new ReplayHeader();

		// Token: 0x040037AD RID: 14253
		public Frame[] frames = new Frame[0];

		// Token: 0x040037AE RID: 14254
		public ReplayRaceResult[] results = new ReplayRaceResult[0];
	}
}
