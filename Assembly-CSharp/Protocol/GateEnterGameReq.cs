using System;

namespace Protocol
{
	// Token: 0x020009C4 RID: 2500
	[Protocol]
	public class GateEnterGameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600700C RID: 28684 RVA: 0x00144A08 File Offset: 0x00142E08
		public uint GetMsgID()
		{
			return 300306U;
		}

		// Token: 0x0600700D RID: 28685 RVA: 0x00144A0F File Offset: 0x00142E0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600700E RID: 28686 RVA: 0x00144A17 File Offset: 0x00142E17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600700F RID: 28687 RVA: 0x00144A20 File Offset: 0x00142E20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.option);
			byte[] str = StringHelper.StringToUTF8Bytes(this.city);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.inviter);
		}

		// Token: 0x06007010 RID: 28688 RVA: 0x00144A74 File Offset: 0x00142E74
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.option);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.city = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inviter);
		}

		// Token: 0x06007011 RID: 28689 RVA: 0x00144AEC File Offset: 0x00142EEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_int8(buffer, ref pos_, this.option);
			byte[] str = StringHelper.StringToUTF8Bytes(this.city);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.inviter);
		}

		// Token: 0x06007012 RID: 28690 RVA: 0x00144B44 File Offset: 0x00142F44
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.option);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.city = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inviter);
		}

		// Token: 0x06007013 RID: 28691 RVA: 0x00144BBC File Offset: 0x00142FBC
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.city);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x0400330F RID: 13071
		public const uint MsgID = 300306U;

		// Token: 0x04003310 RID: 13072
		public uint Sequence;

		// Token: 0x04003311 RID: 13073
		public ulong roleId;

		// Token: 0x04003312 RID: 13074
		public byte option;

		// Token: 0x04003313 RID: 13075
		public string city;

		// Token: 0x04003314 RID: 13076
		public uint inviter;
	}
}
