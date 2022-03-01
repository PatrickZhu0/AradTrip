using System;

namespace Protocol
{
	// Token: 0x020006ED RID: 1773
	[Protocol]
	public class SceneRequest : IProtocolStream, IGetMsgID
	{
		// Token: 0x060059D7 RID: 22999 RVA: 0x001113A0 File Offset: 0x0010F7A0
		public uint GetMsgID()
		{
			return 500804U;
		}

		// Token: 0x060059D8 RID: 23000 RVA: 0x001113A7 File Offset: 0x0010F7A7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060059D9 RID: 23001 RVA: 0x001113AF File Offset: 0x0010F7AF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060059DA RID: 23002 RVA: 0x001113B8 File Offset: 0x0010F7B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.target);
			byte[] str = StringHelper.StringToUTF8Bytes(this.targetName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x060059DB RID: 23003 RVA: 0x0011140C File Offset: 0x0010F80C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.target);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.targetName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x060059DC RID: 23004 RVA: 0x00111484 File Offset: 0x0010F884
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.target);
			byte[] str = StringHelper.StringToUTF8Bytes(this.targetName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x060059DD RID: 23005 RVA: 0x001114DC File Offset: 0x0010F8DC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.target);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.targetName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x060059DE RID: 23006 RVA: 0x00111554 File Offset: 0x0010F954
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.targetName);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x0400245A RID: 9306
		public const uint MsgID = 500804U;

		// Token: 0x0400245B RID: 9307
		public uint Sequence;

		// Token: 0x0400245C RID: 9308
		public byte type;

		// Token: 0x0400245D RID: 9309
		public ulong target;

		// Token: 0x0400245E RID: 9310
		public string targetName;

		// Token: 0x0400245F RID: 9311
		public uint param;
	}
}
