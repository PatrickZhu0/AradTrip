using System;

namespace Protocol
{
	// Token: 0x0200078F RID: 1935
	public class DigInfo : IProtocolStream
	{
		// Token: 0x06005EEA RID: 24298 RVA: 0x0011C964 File Offset: 0x0011AD64
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.refreshTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.changeStatusTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.openItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.openItemNum);
		}

		// Token: 0x06005EEB RID: 24299 RVA: 0x0011C9D4 File Offset: 0x0011ADD4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.refreshTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.changeStatusTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.openItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.openItemNum);
		}

		// Token: 0x06005EEC RID: 24300 RVA: 0x0011CA44 File Offset: 0x0011AE44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.refreshTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.changeStatusTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.openItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.openItemNum);
		}

		// Token: 0x06005EED RID: 24301 RVA: 0x0011CAB4 File Offset: 0x0011AEB4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.refreshTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.changeStatusTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.openItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.openItemNum);
		}

		// Token: 0x06005EEE RID: 24302 RVA: 0x0011CB24 File Offset: 0x0011AF24
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002722 RID: 10018
		public uint index;

		// Token: 0x04002723 RID: 10019
		public byte type;

		// Token: 0x04002724 RID: 10020
		public byte status;

		// Token: 0x04002725 RID: 10021
		public uint refreshTime;

		// Token: 0x04002726 RID: 10022
		public uint changeStatusTime;

		// Token: 0x04002727 RID: 10023
		public uint openItemId;

		// Token: 0x04002728 RID: 10024
		public uint openItemNum;
	}
}
