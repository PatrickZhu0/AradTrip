using System;
using System.Diagnostics;

namespace ManualMD5
{
	// Token: 0x0200014D RID: 333
	public class MD5
	{
		// Token: 0x060009A5 RID: 2469 RVA: 0x00032A7D File Offset: 0x00030E7D
		public MD5()
		{
			this.Value = string.Empty;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060009A6 RID: 2470 RVA: 0x00032AA0 File Offset: 0x00030EA0
		// (remove) Token: 0x060009A7 RID: 2471 RVA: 0x00032AD8 File Offset: 0x00030ED8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event MD5.ValueChanging OnValueChanging;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060009A8 RID: 2472 RVA: 0x00032B10 File Offset: 0x00030F10
		// (remove) Token: 0x060009A9 RID: 2473 RVA: 0x00032B48 File Offset: 0x00030F48
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event MD5.ValueChanged OnValueChanged;

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060009AA RID: 2474 RVA: 0x00032B80 File Offset: 0x00030F80
		// (set) Token: 0x060009AB RID: 2475 RVA: 0x00032BC8 File Offset: 0x00030FC8
		public string Value
		{
			get
			{
				char[] array = new char[this.m_byteInput.Length];
				for (int i = 0; i < this.m_byteInput.Length; i++)
				{
					array[i] = (char)this.m_byteInput[i];
				}
				return new string(array);
			}
			set
			{
				this.m_byteInput = new byte[value.Length];
				for (int i = 0; i < value.Length; i++)
				{
					this.m_byteInput[i] = (byte)value[i];
				}
				this.dgFingerPrint = this.CalculateMD5Value();
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x00032C19 File Offset: 0x00031019
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x00032C21 File Offset: 0x00031021
		public byte[] ValueAsByte
		{
			get
			{
				return this.m_byteInput;
			}
			set
			{
				this.m_byteInput = value;
				this.dgFingerPrint = this.CalculateMD5Value();
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x00032C36 File Offset: 0x00031036
		public string FingerPrint
		{
			get
			{
				return this.dgFingerPrint.ToString();
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x00032C44 File Offset: 0x00031044
		public byte[] FingerBytes
		{
			get
			{
				byte[] array = new byte[16];
				this._revertInt2Bytes(this.dgFingerPrint.A, array, 0);
				this._revertInt2Bytes(this.dgFingerPrint.B, array, 4);
				this._revertInt2Bytes(this.dgFingerPrint.C, array, 8);
				this._revertInt2Bytes(this.dgFingerPrint.D, array, 12);
				return array;
			}
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x00032CA8 File Offset: 0x000310A8
		private void _revertInt2Bytes(uint value, byte[] array, int offset)
		{
			if (array == null)
			{
				return;
			}
			if (offset + 4 > array.Length)
			{
				return;
			}
			array[offset] = (byte)(value & 255U);
			array[offset + 1] = (byte)((value & 65280U) >> 8);
			array[offset + 2] = (byte)((value & 16711680U) >> 16);
			array[offset + 3] = (byte)((value & 4278190080U) >> 24);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00032D04 File Offset: 0x00031104
		protected Digest CalculateMD5Value()
		{
			Digest digest = new Digest();
			byte[] array = this.CreatePaddedBuffer();
			uint num = (uint)(array.Length * 8 / 32);
			for (uint num2 = 0U; num2 < num / 16U; num2 += 1U)
			{
				this.CopyBlock(array, num2);
				this.PerformTransformation(ref digest.A, ref digest.B, ref digest.C, ref digest.D);
			}
			return digest;
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00032D63 File Offset: 0x00031163
		protected void TransF(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
		{
			a = b + MD5Helper.RotateLeft(a + ((b & c) | (~b & d)) + this.X[(int)((UIntPtr)k)] + MD5.T[(int)((UIntPtr)(i - 1U))], s);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00032D93 File Offset: 0x00031193
		protected void TransG(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
		{
			a = b + MD5Helper.RotateLeft(a + ((b & d) | (c & ~d)) + this.X[(int)((UIntPtr)k)] + MD5.T[(int)((UIntPtr)(i - 1U))], s);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00032DC4 File Offset: 0x000311C4
		protected void TransH(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
		{
			a = b + MD5Helper.RotateLeft(a + (b ^ c ^ d) + this.X[(int)((UIntPtr)k)] + MD5.T[(int)((UIntPtr)(i - 1U))], s);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00032DF1 File Offset: 0x000311F1
		protected void TransI(ref uint a, uint b, uint c, uint d, uint k, ushort s, uint i)
		{
			a = b + MD5Helper.RotateLeft(a + (c ^ (b | ~d)) + this.X[(int)((UIntPtr)k)] + MD5.T[(int)((UIntPtr)(i - 1U))], s);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00032E20 File Offset: 0x00031220
		protected void PerformTransformation(ref uint A, ref uint B, ref uint C, ref uint D)
		{
			uint num = A;
			uint num2 = B;
			uint num3 = C;
			uint num4 = D;
			this.TransF(ref A, B, C, D, 0U, 7, 1U);
			this.TransF(ref D, A, B, C, 1U, 12, 2U);
			this.TransF(ref C, D, A, B, 2U, 17, 3U);
			this.TransF(ref B, C, D, A, 3U, 22, 4U);
			this.TransF(ref A, B, C, D, 4U, 7, 5U);
			this.TransF(ref D, A, B, C, 5U, 12, 6U);
			this.TransF(ref C, D, A, B, 6U, 17, 7U);
			this.TransF(ref B, C, D, A, 7U, 22, 8U);
			this.TransF(ref A, B, C, D, 8U, 7, 9U);
			this.TransF(ref D, A, B, C, 9U, 12, 10U);
			this.TransF(ref C, D, A, B, 10U, 17, 11U);
			this.TransF(ref B, C, D, A, 11U, 22, 12U);
			this.TransF(ref A, B, C, D, 12U, 7, 13U);
			this.TransF(ref D, A, B, C, 13U, 12, 14U);
			this.TransF(ref C, D, A, B, 14U, 17, 15U);
			this.TransF(ref B, C, D, A, 15U, 22, 16U);
			this.TransG(ref A, B, C, D, 1U, 5, 17U);
			this.TransG(ref D, A, B, C, 6U, 9, 18U);
			this.TransG(ref C, D, A, B, 11U, 14, 19U);
			this.TransG(ref B, C, D, A, 0U, 20, 20U);
			this.TransG(ref A, B, C, D, 5U, 5, 21U);
			this.TransG(ref D, A, B, C, 10U, 9, 22U);
			this.TransG(ref C, D, A, B, 15U, 14, 23U);
			this.TransG(ref B, C, D, A, 4U, 20, 24U);
			this.TransG(ref A, B, C, D, 9U, 5, 25U);
			this.TransG(ref D, A, B, C, 14U, 9, 26U);
			this.TransG(ref C, D, A, B, 3U, 14, 27U);
			this.TransG(ref B, C, D, A, 8U, 20, 28U);
			this.TransG(ref A, B, C, D, 13U, 5, 29U);
			this.TransG(ref D, A, B, C, 2U, 9, 30U);
			this.TransG(ref C, D, A, B, 7U, 14, 31U);
			this.TransG(ref B, C, D, A, 12U, 20, 32U);
			this.TransH(ref A, B, C, D, 5U, 4, 33U);
			this.TransH(ref D, A, B, C, 8U, 11, 34U);
			this.TransH(ref C, D, A, B, 11U, 16, 35U);
			this.TransH(ref B, C, D, A, 14U, 23, 36U);
			this.TransH(ref A, B, C, D, 1U, 4, 37U);
			this.TransH(ref D, A, B, C, 4U, 11, 38U);
			this.TransH(ref C, D, A, B, 7U, 16, 39U);
			this.TransH(ref B, C, D, A, 10U, 23, 40U);
			this.TransH(ref A, B, C, D, 13U, 4, 41U);
			this.TransH(ref D, A, B, C, 0U, 11, 42U);
			this.TransH(ref C, D, A, B, 3U, 16, 43U);
			this.TransH(ref B, C, D, A, 6U, 23, 44U);
			this.TransH(ref A, B, C, D, 9U, 4, 45U);
			this.TransH(ref D, A, B, C, 12U, 11, 46U);
			this.TransH(ref C, D, A, B, 15U, 16, 47U);
			this.TransH(ref B, C, D, A, 2U, 23, 48U);
			this.TransI(ref A, B, C, D, 0U, 6, 49U);
			this.TransI(ref D, A, B, C, 7U, 10, 50U);
			this.TransI(ref C, D, A, B, 14U, 15, 51U);
			this.TransI(ref B, C, D, A, 5U, 21, 52U);
			this.TransI(ref A, B, C, D, 12U, 6, 53U);
			this.TransI(ref D, A, B, C, 3U, 10, 54U);
			this.TransI(ref C, D, A, B, 10U, 15, 55U);
			this.TransI(ref B, C, D, A, 1U, 21, 56U);
			this.TransI(ref A, B, C, D, 8U, 6, 57U);
			this.TransI(ref D, A, B, C, 15U, 10, 58U);
			this.TransI(ref C, D, A, B, 6U, 15, 59U);
			this.TransI(ref B, C, D, A, 13U, 21, 60U);
			this.TransI(ref A, B, C, D, 4U, 6, 61U);
			this.TransI(ref D, A, B, C, 11U, 10, 62U);
			this.TransI(ref C, D, A, B, 2U, 15, 63U);
			this.TransI(ref B, C, D, A, 9U, 21, 64U);
			A += num;
			B += num2;
			C += num3;
			D += num4;
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x00033318 File Offset: 0x00031718
		protected byte[] CreatePaddedBuffer()
		{
			int num = 448 - this.m_byteInput.Length * 8 % 512;
			uint num2 = (uint)((num + 512) % 512);
			if (num2 == 0U)
			{
				num2 = 512U;
			}
			uint num3 = (uint)((long)this.m_byteInput.Length + (long)((ulong)(num2 / 8U)) + 8L);
			ulong num4 = (ulong)((long)this.m_byteInput.Length * 8L);
			byte[] array = new byte[num3];
			for (int i = 0; i < this.m_byteInput.Length; i++)
			{
				array[i] = this.m_byteInput[i];
			}
			byte[] array2 = array;
			int num5 = this.m_byteInput.Length;
			array2[num5] |= 128;
			for (int j = 8; j > 0; j--)
			{
				array[(int)(checked((IntPtr)(unchecked((ulong)num3 - (ulong)((long)j)))))] = (byte)(num4 >> (8 - j) * 8 & 255UL);
			}
			return array;
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x000333F8 File Offset: 0x000317F8
		protected void CopyBlock(byte[] bMsg, uint block)
		{
			block <<= 6;
			for (uint num = 0U; num < 61U; num += 4U)
			{
				this.X[(int)((UIntPtr)(num >> 2))] = (uint)((int)bMsg[(int)((UIntPtr)(block + (num + 3U)))] << 24 | (int)bMsg[(int)((UIntPtr)(block + (num + 2U)))] << 16 | (int)bMsg[(int)((UIntPtr)(block + (num + 1U)))] << 8 | (int)bMsg[(int)((UIntPtr)(block + num))]);
			}
		}

		// Token: 0x04000742 RID: 1858
		protected static readonly uint[] T = new uint[]
		{
			3614090360U,
			3905402710U,
			606105819U,
			3250441966U,
			4118548399U,
			1200080426U,
			2821735955U,
			4249261313U,
			1770035416U,
			2336552879U,
			4294925233U,
			2304563134U,
			1804603682U,
			4254626195U,
			2792965006U,
			1236535329U,
			4129170786U,
			3225465664U,
			643717713U,
			3921069994U,
			3593408605U,
			38016083U,
			3634488961U,
			3889429448U,
			568446438U,
			3275163606U,
			4107603335U,
			1163531501U,
			2850285829U,
			4243563512U,
			1735328473U,
			2368359562U,
			4294588738U,
			2272392833U,
			1839030562U,
			4259657740U,
			2763975236U,
			1272893353U,
			4139469664U,
			3200236656U,
			681279174U,
			3936430074U,
			3572445317U,
			76029189U,
			3654602809U,
			3873151461U,
			530742520U,
			3299628645U,
			4096336452U,
			1126891415U,
			2878612391U,
			4237533241U,
			1700485571U,
			2399980690U,
			4293915773U,
			2240044497U,
			1873313359U,
			4264355552U,
			2734768916U,
			1309151649U,
			4149444226U,
			3174756917U,
			718787259U,
			3951481745U
		};

		// Token: 0x04000743 RID: 1859
		protected uint[] X = new uint[16];

		// Token: 0x04000744 RID: 1860
		protected Digest dgFingerPrint;

		// Token: 0x04000745 RID: 1861
		protected byte[] m_byteInput;

		// Token: 0x0200014E RID: 334
		// (Invoke) Token: 0x060009BB RID: 2491
		public delegate void ValueChanging(object sender, MD5ChangingEventArgs Changing);

		// Token: 0x0200014F RID: 335
		// (Invoke) Token: 0x060009BF RID: 2495
		public delegate void ValueChanged(object sender, MD5ChangedEventArgs Changed);
	}
}
