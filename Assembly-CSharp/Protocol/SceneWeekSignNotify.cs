using System;

namespace Protocol
{
	// Token: 0x02000A40 RID: 2624
	[Protocol]
	public class SceneWeekSignNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073A5 RID: 29605 RVA: 0x0014F83C File Offset: 0x0014DC3C
		public uint GetMsgID()
		{
			return 507406U;
		}

		// Token: 0x060073A6 RID: 29606 RVA: 0x0014F843 File Offset: 0x0014DC43
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073A7 RID: 29607 RVA: 0x0014F84B File Offset: 0x0014DC4B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073A8 RID: 29608 RVA: 0x0014F854 File Offset: 0x0014DC54
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.signWeekSum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.yetWeek.Length);
			for (int i = 0; i < this.yetWeek.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.yetWeek[i]);
			}
		}

		// Token: 0x060073A9 RID: 29609 RVA: 0x0014F8B8 File Offset: 0x0014DCB8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.signWeekSum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.yetWeek = new uint[(int)num];
			for (int i = 0; i < this.yetWeek.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.yetWeek[i]);
			}
		}

		// Token: 0x060073AA RID: 29610 RVA: 0x0014F928 File Offset: 0x0014DD28
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.signWeekSum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.yetWeek.Length);
			for (int i = 0; i < this.yetWeek.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.yetWeek[i]);
			}
		}

		// Token: 0x060073AB RID: 29611 RVA: 0x0014F98C File Offset: 0x0014DD8C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.signWeekSum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.yetWeek = new uint[(int)num];
			for (int i = 0; i < this.yetWeek.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.yetWeek[i]);
			}
		}

		// Token: 0x060073AC RID: 29612 RVA: 0x0014F9FC File Offset: 0x0014DDFC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + (2 + 4 * this.yetWeek.Length);
		}

		// Token: 0x040035AB RID: 13739
		public const uint MsgID = 507406U;

		// Token: 0x040035AC RID: 13740
		public uint Sequence;

		// Token: 0x040035AD RID: 13741
		public uint opActType;

		// Token: 0x040035AE RID: 13742
		public uint signWeekSum;

		// Token: 0x040035AF RID: 13743
		public uint[] yetWeek = new uint[0];
	}
}
