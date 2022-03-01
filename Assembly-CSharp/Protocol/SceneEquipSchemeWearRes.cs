using System;

namespace Protocol
{
	// Token: 0x020009AC RID: 2476
	[Protocol]
	public class SceneEquipSchemeWearRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F55 RID: 28501 RVA: 0x00141A68 File Offset: 0x0013FE68
		public uint GetMsgID()
		{
			return 501089U;
		}

		// Token: 0x06006F56 RID: 28502 RVA: 0x00141A6F File Offset: 0x0013FE6F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F57 RID: 28503 RVA: 0x00141A77 File Offset: 0x0013FE77
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F58 RID: 28504 RVA: 0x00141A80 File Offset: 0x0013FE80
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isSync);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.overdueIds.Length);
			for (int i = 0; i < this.overdueIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.overdueIds[i]);
			}
		}

		// Token: 0x06006F59 RID: 28505 RVA: 0x00141B00 File Offset: 0x0013FF00
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSync);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.overdueIds = new ulong[(int)num];
			for (int i = 0; i < this.overdueIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.overdueIds[i]);
			}
		}

		// Token: 0x06006F5A RID: 28506 RVA: 0x00141B8C File Offset: 0x0013FF8C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isSync);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.overdueIds.Length);
			for (int i = 0; i < this.overdueIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.overdueIds[i]);
			}
		}

		// Token: 0x06006F5B RID: 28507 RVA: 0x00141C0C File Offset: 0x0014000C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSync);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.overdueIds = new ulong[(int)num];
			for (int i = 0; i < this.overdueIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.overdueIds[i]);
			}
		}

		// Token: 0x06006F5C RID: 28508 RVA: 0x00141C98 File Offset: 0x00140098
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			num++;
			return num + (2 + 8 * this.overdueIds.Length);
		}

		// Token: 0x04003284 RID: 12932
		public const uint MsgID = 501089U;

		// Token: 0x04003285 RID: 12933
		public uint Sequence;

		// Token: 0x04003286 RID: 12934
		public uint code;

		// Token: 0x04003287 RID: 12935
		public byte type;

		// Token: 0x04003288 RID: 12936
		public uint id;

		// Token: 0x04003289 RID: 12937
		public byte isSync;

		// Token: 0x0400328A RID: 12938
		public ulong[] overdueIds = new ulong[0];
	}
}
