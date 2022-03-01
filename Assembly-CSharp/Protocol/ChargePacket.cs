using System;

namespace Protocol
{
	// Token: 0x02000C2E RID: 3118
	public class ChargePacket : IProtocolStream
	{
		// Token: 0x06008209 RID: 33289 RVA: 0x0016E9BC File Offset: 0x0016CDBC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.oldPrice);
			BaseDLL.encode_uint16(buffer, ref pos_, this.money);
			BaseDLL.encode_uint16(buffer, ref pos_, this.vipScore);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.icon);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitDailyNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitTotalNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewards.Length);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600820A RID: 33290 RVA: 0x0016EAAC File Offset: 0x0016CEAC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.oldPrice);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.money);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.vipScore);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.icon = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitDailyNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitTotalNum);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.rewards = new ItemReward[(int)num3];
			for (int k = 0; k < this.rewards.Length; k++)
			{
				this.rewards[k] = new ItemReward();
				this.rewards[k].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600820B RID: 33291 RVA: 0x0016EC08 File Offset: 0x0016D008
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.oldPrice);
			BaseDLL.encode_uint16(buffer, ref pos_, this.money);
			BaseDLL.encode_uint16(buffer, ref pos_, this.vipScore);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.icon);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitDailyNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.limitTotalNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewards.Length);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				this.rewards[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600820C RID: 33292 RVA: 0x0016ECFC File Offset: 0x0016D0FC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.oldPrice);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.money);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.vipScore);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.icon = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitDailyNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.limitTotalNum);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.rewards = new ItemReward[(int)num3];
			for (int k = 0; k < this.rewards.Length; k++)
			{
				this.rewards[k] = new ItemReward();
				this.rewards[k].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600820D RID: 33293 RVA: 0x0016EE58 File Offset: 0x0016D258
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num += 2;
			num += 2;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.icon);
			num += 2 + array2.Length;
			num += 4;
			num += 4;
			num += 2;
			num += 2;
			num += 2;
			for (int i = 0; i < this.rewards.Length; i++)
			{
				num += this.rewards[i].getLen();
			}
			return num;
		}

		// Token: 0x04003E1E RID: 15902
		public byte id;

		// Token: 0x04003E1F RID: 15903
		public string name;

		// Token: 0x04003E20 RID: 15904
		public ushort oldPrice;

		// Token: 0x04003E21 RID: 15905
		public ushort money;

		// Token: 0x04003E22 RID: 15906
		public ushort vipScore;

		// Token: 0x04003E23 RID: 15907
		public string icon;

		// Token: 0x04003E24 RID: 15908
		public uint startTime;

		// Token: 0x04003E25 RID: 15909
		public uint endTime;

		// Token: 0x04003E26 RID: 15910
		public ushort limitDailyNum;

		// Token: 0x04003E27 RID: 15911
		public ushort limitTotalNum;

		// Token: 0x04003E28 RID: 15912
		public ItemReward[] rewards = new ItemReward[0];
	}
}
