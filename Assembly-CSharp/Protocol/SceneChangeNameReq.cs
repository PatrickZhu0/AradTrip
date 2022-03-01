using System;

namespace Protocol
{
	// Token: 0x02000B3A RID: 2874
	[Protocol]
	public class SceneChangeNameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AD1 RID: 31441 RVA: 0x00160474 File Offset: 0x0015E874
		public uint GetMsgID()
		{
			return 501206U;
		}

		// Token: 0x06007AD2 RID: 31442 RVA: 0x0016047B File Offset: 0x0015E87B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007AD3 RID: 31443 RVA: 0x00160483 File Offset: 0x0015E883
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007AD4 RID: 31444 RVA: 0x0016048C File Offset: 0x0015E88C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007AD5 RID: 31445 RVA: 0x001604C4 File Offset: 0x0015E8C4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
		}

		// Token: 0x06007AD6 RID: 31446 RVA: 0x00160520 File Offset: 0x0015E920
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007AD7 RID: 31447 RVA: 0x0016055C File Offset: 0x0015E95C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
		}

		// Token: 0x06007AD8 RID: 31448 RVA: 0x001605B8 File Offset: 0x0015E9B8
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.newName);
			return num + (2 + array.Length);
		}

		// Token: 0x04003A37 RID: 14903
		public const uint MsgID = 501206U;

		// Token: 0x04003A38 RID: 14904
		public uint Sequence;

		// Token: 0x04003A39 RID: 14905
		public ulong itemUid;

		// Token: 0x04003A3A RID: 14906
		public string newName;
	}
}
