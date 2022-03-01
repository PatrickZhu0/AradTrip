using System;

namespace Protocol
{
	// Token: 0x02000AB3 RID: 2739
	public class RetinueInfo : IProtocolStream
	{
		// Token: 0x060076F6 RID: 30454 RVA: 0x00158084 File Offset: 0x00156484
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.starLevel);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060076F7 RID: 30455 RVA: 0x00158104 File Offset: 0x00156504
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.starLevel);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skills = new RetinueSkill[(int)num];
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i] = new RetinueSkill();
				this.skills[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060076F8 RID: 30456 RVA: 0x00158198 File Offset: 0x00156598
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.starLevel);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060076F9 RID: 30457 RVA: 0x00158218 File Offset: 0x00156618
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.starLevel);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skills = new RetinueSkill[(int)num];
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i] = new RetinueSkill();
				this.skills[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060076FA RID: 30458 RVA: 0x001582AC File Offset: 0x001566AC
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num++;
			num++;
			num += 2;
			for (int i = 0; i < this.skills.Length; i++)
			{
				num += this.skills[i].getLen();
			}
			return num;
		}

		// Token: 0x040037B4 RID: 14260
		public ulong id;

		// Token: 0x040037B5 RID: 14261
		public uint dataId;

		// Token: 0x040037B6 RID: 14262
		public byte level;

		// Token: 0x040037B7 RID: 14263
		public byte starLevel;

		// Token: 0x040037B8 RID: 14264
		public RetinueSkill[] skills = new RetinueSkill[0];
	}
}
