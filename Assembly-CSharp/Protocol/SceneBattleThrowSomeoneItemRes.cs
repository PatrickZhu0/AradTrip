using System;

namespace Protocol
{
	// Token: 0x0200070D RID: 1805
	[Protocol]
	public class SceneBattleThrowSomeoneItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AEB RID: 23275 RVA: 0x00114124 File Offset: 0x00112524
		public uint GetMsgID()
		{
			return 508921U;
		}

		// Token: 0x06005AEC RID: 23276 RVA: 0x0011412B File Offset: 0x0011252B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AED RID: 23277 RVA: 0x00114133 File Offset: 0x00112533
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AEE RID: 23278 RVA: 0x0011413C File Offset: 0x0011253C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.attackID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.targetName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06005AEF RID: 23279 RVA: 0x001141BC File Offset: 0x001125BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.attackID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataID);
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

		// Token: 0x06005AF0 RID: 23280 RVA: 0x00114260 File Offset: 0x00112660
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.attackID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.targetName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06005AF1 RID: 23281 RVA: 0x001142E0 File Offset: 0x001126E0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.attackID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataID);
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

		// Token: 0x06005AF2 RID: 23282 RVA: 0x00114384 File Offset: 0x00112784
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			num += 8;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.targetName);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x04002500 RID: 9472
		public const uint MsgID = 508921U;

		// Token: 0x04002501 RID: 9473
		public uint Sequence;

		// Token: 0x04002502 RID: 9474
		public uint retCode;

		// Token: 0x04002503 RID: 9475
		public ulong attackID;

		// Token: 0x04002504 RID: 9476
		public ulong targetID;

		// Token: 0x04002505 RID: 9477
		public ulong itemGuid;

		// Token: 0x04002506 RID: 9478
		public uint itemDataID;

		// Token: 0x04002507 RID: 9479
		public string targetName;

		// Token: 0x04002508 RID: 9480
		public uint param;
	}
}
