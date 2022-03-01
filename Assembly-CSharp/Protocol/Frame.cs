using System;

namespace Protocol
{
	// Token: 0x02000A91 RID: 2705
	public class Frame : IProtocolStream
	{
		// Token: 0x0600760F RID: 30223 RVA: 0x001553F8 File Offset: 0x001537F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sequence);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007610 RID: 30224 RVA: 0x0015544C File Offset: 0x0015384C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sequence);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new _fighterInput[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new _fighterInput();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007611 RID: 30225 RVA: 0x001554B4 File Offset: 0x001538B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sequence);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.data.Length);
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007612 RID: 30226 RVA: 0x00155508 File Offset: 0x00153908
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sequence);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.data = new _fighterInput[(int)num];
			for (int i = 0; i < this.data.Length; i++)
			{
				this.data[i] = new _fighterInput();
				this.data[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007613 RID: 30227 RVA: 0x00155570 File Offset: 0x00153970
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.data.Length; i++)
			{
				num += this.data[i].getLen();
			}
			return num;
		}

		// Token: 0x0400371F RID: 14111
		public uint sequence;

		// Token: 0x04003720 RID: 14112
		public _fighterInput[] data = new _fighterInput[0];
	}
}
