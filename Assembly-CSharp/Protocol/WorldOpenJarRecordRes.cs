using System;

namespace Protocol
{
	// Token: 0x0200092D RID: 2349
	[Protocol]
	public class WorldOpenJarRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006AFF RID: 27391 RVA: 0x0013976C File Offset: 0x00137B6C
		public uint GetMsgID()
		{
			return 600902U;
		}

		// Token: 0x06006B00 RID: 27392 RVA: 0x00139773 File Offset: 0x00137B73
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B01 RID: 27393 RVA: 0x0013977B File Offset: 0x00137B7B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B02 RID: 27394 RVA: 0x00139784 File Offset: 0x00137B84
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B03 RID: 27395 RVA: 0x001397D8 File Offset: 0x00137BD8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new OpenJarRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new OpenJarRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B04 RID: 27396 RVA: 0x00139840 File Offset: 0x00137C40
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B05 RID: 27397 RVA: 0x00139894 File Offset: 0x00137C94
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new OpenJarRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new OpenJarRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B06 RID: 27398 RVA: 0x001398FC File Offset: 0x00137CFC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.records.Length; i++)
			{
				num += this.records[i].getLen();
			}
			return num;
		}

		// Token: 0x04003084 RID: 12420
		public const uint MsgID = 600902U;

		// Token: 0x04003085 RID: 12421
		public uint Sequence;

		// Token: 0x04003086 RID: 12422
		public uint jarId;

		// Token: 0x04003087 RID: 12423
		public OpenJarRecord[] records = new OpenJarRecord[0];
	}
}
