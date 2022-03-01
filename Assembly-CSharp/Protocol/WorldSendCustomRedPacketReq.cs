using System;

namespace Protocol
{
	// Token: 0x02000A85 RID: 2693
	[Protocol]
	public class WorldSendCustomRedPacketReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075BB RID: 30139 RVA: 0x00154702 File Offset: 0x00152B02
		public uint GetMsgID()
		{
			return 607310U;
		}

		// Token: 0x060075BC RID: 30140 RVA: 0x00154709 File Offset: 0x00152B09
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075BD RID: 30141 RVA: 0x00154711 File Offset: 0x00152B11
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075BE RID: 30142 RVA: 0x0015471C File Offset: 0x00152B1C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.reason);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x060075BF RID: 30143 RVA: 0x00154764 File Offset: 0x00152B64
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.reason);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060075C0 RID: 30144 RVA: 0x001547D0 File Offset: 0x00152BD0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.reason);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x060075C1 RID: 30145 RVA: 0x00154818 File Offset: 0x00152C18
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.reason);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060075C2 RID: 30146 RVA: 0x00154884 File Offset: 0x00152C84
		public int getLen()
		{
			int num = 0;
			num += 2;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x040036CF RID: 14031
		public const uint MsgID = 607310U;

		// Token: 0x040036D0 RID: 14032
		public uint Sequence;

		// Token: 0x040036D1 RID: 14033
		public ushort reason;

		// Token: 0x040036D2 RID: 14034
		public string name;

		// Token: 0x040036D3 RID: 14035
		public byte num;
	}
}
