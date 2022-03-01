using System;

namespace Protocol
{
	// Token: 0x020007B2 RID: 1970
	[Protocol]
	public class SceneDungeonStartReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005FD4 RID: 24532 RVA: 0x0011E916 File Offset: 0x0011CD16
		public uint GetMsgID()
		{
			return 506805U;
		}

		// Token: 0x06005FD5 RID: 24533 RVA: 0x0011E91D File Offset: 0x0011CD1D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005FD6 RID: 24534 RVA: 0x0011E925 File Offset: 0x0011CD25
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005FD7 RID: 24535 RVA: 0x0011E930 File Offset: 0x0011CD30
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffDrugs.Length);
			for (int i = 0; i < this.buffDrugs.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.buffDrugs[i]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.isRestart);
			BaseDLL.encode_uint64(buffer, ref pos_, this.cityMonsterId);
		}

		// Token: 0x06005FD8 RID: 24536 RVA: 0x0011E9A4 File Offset: 0x0011CDA4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffDrugs = new uint[(int)num];
			for (int i = 0; i < this.buffDrugs.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffDrugs[i]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRestart);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cityMonsterId);
		}

		// Token: 0x06005FD9 RID: 24537 RVA: 0x0011EA20 File Offset: 0x0011CE20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffDrugs.Length);
			for (int i = 0; i < this.buffDrugs.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.buffDrugs[i]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.isRestart);
			BaseDLL.encode_uint64(buffer, ref pos_, this.cityMonsterId);
		}

		// Token: 0x06005FDA RID: 24538 RVA: 0x0011EA94 File Offset: 0x0011CE94
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffDrugs = new uint[(int)num];
			for (int i = 0; i < this.buffDrugs.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffDrugs[i]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRestart);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.cityMonsterId);
		}

		// Token: 0x06005FDB RID: 24539 RVA: 0x0011EB10 File Offset: 0x0011CF10
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2 + 4 * this.buffDrugs.Length;
			num++;
			return num + 8;
		}

		// Token: 0x040027AA RID: 10154
		public const uint MsgID = 506805U;

		// Token: 0x040027AB RID: 10155
		public uint Sequence;

		// Token: 0x040027AC RID: 10156
		public uint dungeonId;

		// Token: 0x040027AD RID: 10157
		public uint[] buffDrugs = new uint[0];

		// Token: 0x040027AE RID: 10158
		public byte isRestart;

		// Token: 0x040027AF RID: 10159
		public ulong cityMonsterId;
	}
}
