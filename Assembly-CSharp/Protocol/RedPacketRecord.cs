using System;

namespace Protocol
{
	// Token: 0x02000A7A RID: 2682
	public class RedPacketRecord : IProtocolStream
	{
		// Token: 0x0600755E RID: 30046 RVA: 0x00153B68 File Offset: 0x00151F68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			byte[] str = StringHelper.StringToUTF8Bytes(this.redPackOwnerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.moneyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.moneyNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isBest);
		}

		// Token: 0x0600755F RID: 30047 RVA: 0x00153BD8 File Offset: 0x00151FD8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.redPackOwnerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.moneyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.moneyNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isBest);
		}

		// Token: 0x06007560 RID: 30048 RVA: 0x00153C6C File Offset: 0x0015206C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			byte[] str = StringHelper.StringToUTF8Bytes(this.redPackOwnerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.moneyId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.moneyNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isBest);
		}

		// Token: 0x06007561 RID: 30049 RVA: 0x00153CE0 File Offset: 0x001520E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.redPackOwnerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.moneyId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.moneyNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isBest);
		}

		// Token: 0x06007562 RID: 30050 RVA: 0x00153D74 File Offset: 0x00152174
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.redPackOwnerName);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x040036A8 RID: 13992
		public ulong guid;

		// Token: 0x040036A9 RID: 13993
		public uint time;

		// Token: 0x040036AA RID: 13994
		public string redPackOwnerName;

		// Token: 0x040036AB RID: 13995
		public uint moneyId;

		// Token: 0x040036AC RID: 13996
		public uint moneyNum;

		// Token: 0x040036AD RID: 13997
		public byte isBest;
	}
}
