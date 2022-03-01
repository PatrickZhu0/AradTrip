using System;

namespace Protocol
{
	// Token: 0x020009CB RID: 2507
	[Protocol]
	public class GateDeleteRoleRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600704B RID: 28747 RVA: 0x001451B0 File Offset: 0x001435B0
		public uint GetMsgID()
		{
			return 300315U;
		}

		// Token: 0x0600704C RID: 28748 RVA: 0x001451B7 File Offset: 0x001435B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600704D RID: 28749 RVA: 0x001451BF File Offset: 0x001435BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600704E RID: 28750 RVA: 0x001451C8 File Offset: 0x001435C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str = StringHelper.StringToUTF8Bytes(this.roleUpdateLimit);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600704F RID: 28751 RVA: 0x00145210 File Offset: 0x00143610
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.roleUpdateLimit = StringHelper.BytesToString(array);
		}

		// Token: 0x06007050 RID: 28752 RVA: 0x0014527C File Offset: 0x0014367C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str = StringHelper.StringToUTF8Bytes(this.roleUpdateLimit);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007051 RID: 28753 RVA: 0x001452C4 File Offset: 0x001436C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.roleUpdateLimit = StringHelper.BytesToString(array);
		}

		// Token: 0x06007052 RID: 28754 RVA: 0x00145330 File Offset: 0x00143730
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.roleUpdateLimit);
			return num + (2 + array.Length);
		}

		// Token: 0x0400332C RID: 13100
		public const uint MsgID = 300315U;

		// Token: 0x0400332D RID: 13101
		public uint Sequence;

		// Token: 0x0400332E RID: 13102
		public ulong roleId;

		// Token: 0x0400332F RID: 13103
		public uint result;

		// Token: 0x04003330 RID: 13104
		public string roleUpdateLimit;
	}
}
