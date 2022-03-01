using System;

namespace Protocol
{
	// Token: 0x02000CA9 RID: 3241
	[Protocol]
	public class QueryAddonPayMsgRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085A8 RID: 34216 RVA: 0x00176938 File Offset: 0x00174D38
		public uint GetMsgID()
		{
			return 501717U;
		}

		// Token: 0x060085A9 RID: 34217 RVA: 0x0017693F File Offset: 0x00174D3F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085AA RID: 34218 RVA: 0x00176947 File Offset: 0x00174D47
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085AB RID: 34219 RVA: 0x00176950 File Offset: 0x00174D50
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.words);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060085AC RID: 34220 RVA: 0x0017697C File Offset: 0x00174D7C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.words = StringHelper.BytesToString(array);
		}

		// Token: 0x060085AD RID: 34221 RVA: 0x001769CC File Offset: 0x00174DCC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.words);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060085AE RID: 34222 RVA: 0x001769F8 File Offset: 0x00174DF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.words = StringHelper.BytesToString(array);
		}

		// Token: 0x060085AF RID: 34223 RVA: 0x00176A48 File Offset: 0x00174E48
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.words);
			return num + (2 + array.Length);
		}

		// Token: 0x04004008 RID: 16392
		public const uint MsgID = 501717U;

		// Token: 0x04004009 RID: 16393
		public uint Sequence;

		// Token: 0x0400400A RID: 16394
		public string words;
	}
}
