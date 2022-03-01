using System;

namespace Protocol
{
	// Token: 0x0200066F RID: 1647
	public class ActivityMonsterInfo : IProtocolStream
	{
		// Token: 0x06005618 RID: 22040 RVA: 0x00107E4C File Offset: 0x0010624C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.activity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.pointType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.nextRollStartTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.drops.Length);
			for (int i = 0; i < this.drops.Length; i++)
			{
				this.drops[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005619 RID: 22041 RVA: 0x00107F10 File Offset: 0x00106310
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pointType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.nextRollStartTime);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.drops = new DropItem[(int)num2];
			for (int j = 0; j < this.drops.Length; j++)
			{
				this.drops[j] = new DropItem();
				this.drops[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600561A RID: 22042 RVA: 0x00108014 File Offset: 0x00106414
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.activity);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.pointType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.nextRollStartTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.drops.Length);
			for (int i = 0; i < this.drops.Length; i++)
			{
				this.drops[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600561B RID: 22043 RVA: 0x001080DC File Offset: 0x001064DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activity);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pointType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.nextRollStartTime);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.drops = new DropItem[(int)num2];
			for (int j = 0; j < this.drops.Length; j++)
			{
				this.drops[j] = new DropItem();
				this.drops[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600561C RID: 22044 RVA: 0x001081E0 File Offset: 0x001065E0
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.drops.Length; i++)
			{
				num += this.drops[i].getLen();
			}
			return num;
		}

		// Token: 0x04002225 RID: 8741
		public string name;

		// Token: 0x04002226 RID: 8742
		public byte activity;

		// Token: 0x04002227 RID: 8743
		public uint id;

		// Token: 0x04002228 RID: 8744
		public byte pointType;

		// Token: 0x04002229 RID: 8745
		public uint startTime;

		// Token: 0x0400222A RID: 8746
		public uint endTime;

		// Token: 0x0400222B RID: 8747
		public uint remainNum;

		// Token: 0x0400222C RID: 8748
		public uint nextRollStartTime;

		// Token: 0x0400222D RID: 8749
		public DropItem[] drops = new DropItem[0];
	}
}
