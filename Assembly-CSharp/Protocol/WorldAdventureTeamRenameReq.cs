using System;

namespace Protocol
{
	// Token: 0x02000696 RID: 1686
	[Protocol]
	public class WorldAdventureTeamRenameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005759 RID: 22361 RVA: 0x0010AAEA File Offset: 0x00108EEA
		public uint GetMsgID()
		{
			return 608601U;
		}

		// Token: 0x0600575A RID: 22362 RVA: 0x0010AAF1 File Offset: 0x00108EF1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600575B RID: 22363 RVA: 0x0010AAF9 File Offset: 0x00108EF9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600575C RID: 22364 RVA: 0x0010AB04 File Offset: 0x00108F04
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.costItemUId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costItemDataId);
		}

		// Token: 0x0600575D RID: 22365 RVA: 0x0010AB4C File Offset: 0x00108F4C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.costItemUId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costItemDataId);
		}

		// Token: 0x0600575E RID: 22366 RVA: 0x0010ABB8 File Offset: 0x00108FB8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.costItemUId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.costItemDataId);
		}

		// Token: 0x0600575F RID: 22367 RVA: 0x0010AC00 File Offset: 0x00109000
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.costItemUId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.costItemDataId);
		}

		// Token: 0x06005760 RID: 22368 RVA: 0x0010AC6C File Offset: 0x0010906C
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.newName);
			num += 2 + array.Length;
			num += 8;
			return num + 4;
		}

		// Token: 0x040022BA RID: 8890
		public const uint MsgID = 608601U;

		// Token: 0x040022BB RID: 8891
		public uint Sequence;

		// Token: 0x040022BC RID: 8892
		public string newName;

		// Token: 0x040022BD RID: 8893
		public ulong costItemUId;

		// Token: 0x040022BE RID: 8894
		public uint costItemDataId;
	}
}
