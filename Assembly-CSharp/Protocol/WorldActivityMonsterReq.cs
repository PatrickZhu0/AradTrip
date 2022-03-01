using System;

namespace Protocol
{
	// Token: 0x02000686 RID: 1670
	[Protocol]
	public class WorldActivityMonsterReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056DE RID: 22238 RVA: 0x001099E6 File Offset: 0x00107DE6
		public uint GetMsgID()
		{
			return 607404U;
		}

		// Token: 0x060056DF RID: 22239 RVA: 0x001099ED File Offset: 0x00107DED
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056E0 RID: 22240 RVA: 0x001099F5 File Offset: 0x00107DF5
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056E1 RID: 22241 RVA: 0x00109A00 File Offset: 0x00107E00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.activityId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ids.Length);
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.ids[i]);
			}
		}

		// Token: 0x060056E2 RID: 22242 RVA: 0x00109A58 File Offset: 0x00107E58
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activityId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ids = new uint[(int)num];
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.ids[i]);
			}
		}

		// Token: 0x060056E3 RID: 22243 RVA: 0x00109AB8 File Offset: 0x00107EB8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.activityId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ids.Length);
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.ids[i]);
			}
		}

		// Token: 0x060056E4 RID: 22244 RVA: 0x00109B10 File Offset: 0x00107F10
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activityId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ids = new uint[(int)num];
			for (int i = 0; i < this.ids.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.ids[i]);
			}
		}

		// Token: 0x060056E5 RID: 22245 RVA: 0x00109B70 File Offset: 0x00107F70
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 4 * this.ids.Length);
		}

		// Token: 0x04002280 RID: 8832
		public const uint MsgID = 607404U;

		// Token: 0x04002281 RID: 8833
		public uint Sequence;

		// Token: 0x04002282 RID: 8834
		public uint activityId;

		// Token: 0x04002283 RID: 8835
		public uint[] ids = new uint[0];
	}
}
