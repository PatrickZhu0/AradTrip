using System;

namespace Protocol
{
	// Token: 0x02000693 RID: 1683
	public class ExpeditionMemberInfo : IProtocolStream
	{
		// Token: 0x06005744 RID: 22340 RVA: 0x0010A738 File Offset: 0x00108B38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionMapId);
		}

		// Token: 0x06005745 RID: 22341 RVA: 0x0010A7A8 File Offset: 0x00108BA8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionMapId);
		}

		// Token: 0x06005746 RID: 22342 RVA: 0x0010A83C File Offset: 0x00108C3C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionMapId);
		}

		// Token: 0x06005747 RID: 22343 RVA: 0x0010A8B0 File Offset: 0x00108CB0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionMapId);
		}

		// Token: 0x06005748 RID: 22344 RVA: 0x0010A944 File Offset: 0x00108D44
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num++;
			num += this.avatar.getLen();
			return num + 1;
		}

		// Token: 0x040022AE RID: 8878
		public ulong roleid;

		// Token: 0x040022AF RID: 8879
		public string name;

		// Token: 0x040022B0 RID: 8880
		public ushort level;

		// Token: 0x040022B1 RID: 8881
		public byte occu;

		// Token: 0x040022B2 RID: 8882
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x040022B3 RID: 8883
		public byte expeditionMapId;
	}
}
