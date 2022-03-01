using System;

namespace Protocol
{
	// Token: 0x02000770 RID: 1904
	public class GambleInfo : IProtocolStream
	{
		// Token: 0x06005E06 RID: 24070 RVA: 0x0011A100 File Offset: 0x00118500
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.options.Length);
			for (int i = 0; i < this.options.Length; i++)
			{
				this.options[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param);
		}

		// Token: 0x06005E07 RID: 24071 RVA: 0x0011A18C File Offset: 0x0011858C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.options = new GambleOption[(int)num];
			for (int i = 0; i < this.options.Length; i++)
			{
				this.options[i] = new GambleOption();
				this.options[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06005E08 RID: 24072 RVA: 0x0011A22C File Offset: 0x0011862C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.options.Length);
			for (int i = 0; i < this.options.Length; i++)
			{
				this.options[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint64(buffer, ref pos_, this.param);
		}

		// Token: 0x06005E09 RID: 24073 RVA: 0x0011A2B8 File Offset: 0x001186B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.options = new GambleOption[(int)num];
			for (int i = 0; i < this.options.Length; i++)
			{
				this.options[i] = new GambleOption();
				this.options[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06005E0A RID: 24074 RVA: 0x0011A358 File Offset: 0x00118758
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 2;
			for (int i = 0; i < this.options.Length; i++)
			{
				num += this.options[i].getLen();
			}
			num += 4;
			num += 4;
			return num + 8;
		}

		// Token: 0x0400268D RID: 9869
		public uint id;

		// Token: 0x0400268E RID: 9870
		public byte type;

		// Token: 0x0400268F RID: 9871
		public GambleOption[] options = new GambleOption[0];

		// Token: 0x04002690 RID: 9872
		public uint startTime;

		// Token: 0x04002691 RID: 9873
		public uint endTime;

		// Token: 0x04002692 RID: 9874
		public ulong param;
	}
}
