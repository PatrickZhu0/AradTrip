using System;

namespace Protocol
{
	// Token: 0x020007CE RID: 1998
	[Protocol]
	public class SceneDungeonClearAreaMonsters : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060AC RID: 24748 RVA: 0x001229FC File Offset: 0x00120DFC
		public uint GetMsgID()
		{
			return 506821U;
		}

		// Token: 0x060060AD RID: 24749 RVA: 0x00122A03 File Offset: 0x00120E03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060AE RID: 24750 RVA: 0x00122A0B File Offset: 0x00120E0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060AF RID: 24751 RVA: 0x00122A14 File Offset: 0x00120E14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
		}

		// Token: 0x060060B0 RID: 24752 RVA: 0x00122A84 File Offset: 0x00120E84
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
		}

		// Token: 0x060060B1 RID: 24753 RVA: 0x00122AF8 File Offset: 0x00120EF8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
		}

		// Token: 0x060060B2 RID: 24754 RVA: 0x00122B68 File Offset: 0x00120F68
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
		}

		// Token: 0x060060B3 RID: 24755 RVA: 0x00122BDC File Offset: 0x00120FDC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += this.md5.Length;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002851 RID: 10321
		public const uint MsgID = 506821U;

		// Token: 0x04002852 RID: 10322
		public uint Sequence;

		// Token: 0x04002853 RID: 10323
		public uint usedTime;

		// Token: 0x04002854 RID: 10324
		public uint remainMp;

		// Token: 0x04002855 RID: 10325
		public byte[] md5 = new byte[16];

		// Token: 0x04002856 RID: 10326
		public uint remainHp;

		// Token: 0x04002857 RID: 10327
		public uint lastFrame;
	}
}
