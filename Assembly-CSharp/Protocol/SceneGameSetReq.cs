using System;

namespace Protocol
{
	// Token: 0x02000B46 RID: 2886
	[Protocol]
	public class SceneGameSetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B3D RID: 31549 RVA: 0x00160C6C File Offset: 0x0015F06C
		public uint GetMsgID()
		{
			return 501223U;
		}

		// Token: 0x06007B3E RID: 31550 RVA: 0x00160C73 File Offset: 0x0015F073
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B3F RID: 31551 RVA: 0x00160C7B File Offset: 0x0015F07B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B40 RID: 31552 RVA: 0x00160C84 File Offset: 0x0015F084
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gameSetType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.setValue);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007B41 RID: 31553 RVA: 0x00160CBC File Offset: 0x0015F0BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gameSetType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.setValue = StringHelper.BytesToString(array);
		}

		// Token: 0x06007B42 RID: 31554 RVA: 0x00160D18 File Offset: 0x0015F118
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gameSetType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.setValue);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007B43 RID: 31555 RVA: 0x00160D54 File Offset: 0x0015F154
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gameSetType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.setValue = StringHelper.BytesToString(array);
		}

		// Token: 0x06007B44 RID: 31556 RVA: 0x00160DB0 File Offset: 0x0015F1B0
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.setValue);
			return num + (2 + array.Length);
		}

		// Token: 0x04003A5E RID: 14942
		public const uint MsgID = 501223U;

		// Token: 0x04003A5F RID: 14943
		public uint Sequence;

		// Token: 0x04003A60 RID: 14944
		public uint gameSetType;

		// Token: 0x04003A61 RID: 14945
		public string setValue;
	}
}
