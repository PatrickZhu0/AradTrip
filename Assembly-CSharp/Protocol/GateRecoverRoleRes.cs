using System;

namespace Protocol
{
	// Token: 0x020009CA RID: 2506
	[Protocol]
	public class GateRecoverRoleRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007042 RID: 28738 RVA: 0x00144FFC File Offset: 0x001433FC
		public uint GetMsgID()
		{
			return 300314U;
		}

		// Token: 0x06007043 RID: 28739 RVA: 0x00145003 File Offset: 0x00143403
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007044 RID: 28740 RVA: 0x0014500B File Offset: 0x0014340B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007045 RID: 28741 RVA: 0x00145014 File Offset: 0x00143414
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str = StringHelper.StringToUTF8Bytes(this.roleUpdateLimit);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007046 RID: 28742 RVA: 0x0014505C File Offset: 0x0014345C
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

		// Token: 0x06007047 RID: 28743 RVA: 0x001450C8 File Offset: 0x001434C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str = StringHelper.StringToUTF8Bytes(this.roleUpdateLimit);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007048 RID: 28744 RVA: 0x00145110 File Offset: 0x00143510
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

		// Token: 0x06007049 RID: 28745 RVA: 0x0014517C File Offset: 0x0014357C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.roleUpdateLimit);
			return num + (2 + array.Length);
		}

		// Token: 0x04003327 RID: 13095
		public const uint MsgID = 300314U;

		// Token: 0x04003328 RID: 13096
		public uint Sequence;

		// Token: 0x04003329 RID: 13097
		public ulong roleId;

		// Token: 0x0400332A RID: 13098
		public uint result;

		// Token: 0x0400332B RID: 13099
		public string roleUpdateLimit;
	}
}
