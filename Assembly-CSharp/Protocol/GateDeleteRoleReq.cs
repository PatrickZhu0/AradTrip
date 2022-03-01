using System;

namespace Protocol
{
	// Token: 0x020009C3 RID: 2499
	[Protocol]
	public class GateDeleteRoleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007003 RID: 28675 RVA: 0x00144894 File Offset: 0x00142C94
		public uint GetMsgID()
		{
			return 300304U;
		}

		// Token: 0x06007004 RID: 28676 RVA: 0x0014489B File Offset: 0x00142C9B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007005 RID: 28677 RVA: 0x001448A3 File Offset: 0x00142CA3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007006 RID: 28678 RVA: 0x001448AC File Offset: 0x00142CAC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceId);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007007 RID: 28679 RVA: 0x001448E4 File Offset: 0x00142CE4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceId = StringHelper.BytesToString(array);
		}

		// Token: 0x06007008 RID: 28680 RVA: 0x00144940 File Offset: 0x00142D40
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roldId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceId);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007009 RID: 28681 RVA: 0x0014497C File Offset: 0x00142D7C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roldId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceId = StringHelper.BytesToString(array);
		}

		// Token: 0x0600700A RID: 28682 RVA: 0x001449D8 File Offset: 0x00142DD8
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.deviceId);
			return num + (2 + array.Length);
		}

		// Token: 0x0400330B RID: 13067
		public const uint MsgID = 300304U;

		// Token: 0x0400330C RID: 13068
		public uint Sequence;

		// Token: 0x0400330D RID: 13069
		public ulong roldId;

		// Token: 0x0400330E RID: 13070
		public string deviceId;
	}
}
