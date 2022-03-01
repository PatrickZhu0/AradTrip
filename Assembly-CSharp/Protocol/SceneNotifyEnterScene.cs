using System;

namespace Protocol
{
	// Token: 0x02000B01 RID: 2817
	[Protocol]
	public class SceneNotifyEnterScene : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007921 RID: 31009 RVA: 0x0015D2E3 File Offset: 0x0015B6E3
		public uint GetMsgID()
		{
			return 500303U;
		}

		// Token: 0x06007922 RID: 31010 RVA: 0x0015D2EA File Offset: 0x0015B6EA
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007923 RID: 31011 RVA: 0x0015D2F2 File Offset: 0x0015B6F2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007924 RID: 31012 RVA: 0x0015D2FC File Offset: 0x0015B6FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			this.pos.encode(buffer, ref pos_);
			this.dir.encode(buffer, ref pos_);
		}

		// Token: 0x06007925 RID: 31013 RVA: 0x0015D35C File Offset: 0x0015B75C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			this.pos.decode(buffer, ref pos_);
			this.dir.decode(buffer, ref pos_);
		}

		// Token: 0x06007926 RID: 31014 RVA: 0x0015D3E0 File Offset: 0x0015B7E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			this.pos.encode(buffer, ref pos_);
			this.dir.encode(buffer, ref pos_);
		}

		// Token: 0x06007927 RID: 31015 RVA: 0x0015D444 File Offset: 0x0015B844
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			this.pos.decode(buffer, ref pos_);
			this.dir.decode(buffer, ref pos_);
		}

		// Token: 0x06007928 RID: 31016 RVA: 0x0015D4C8 File Offset: 0x0015B8C8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += this.pos.getLen();
			return num + this.dir.getLen();
		}

		// Token: 0x04003931 RID: 14641
		public const uint MsgID = 500303U;

		// Token: 0x04003932 RID: 14642
		public uint Sequence;

		// Token: 0x04003933 RID: 14643
		public uint result;

		// Token: 0x04003934 RID: 14644
		public uint mapid;

		// Token: 0x04003935 RID: 14645
		public string name;

		// Token: 0x04003936 RID: 14646
		public ScenePosition pos = new ScenePosition();

		// Token: 0x04003937 RID: 14647
		public SceneDir dir = new SceneDir();
	}
}
