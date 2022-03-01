using System;

namespace Protocol
{
	// Token: 0x020006AE RID: 1710
	[Protocol]
	public class WorldQueryOwnOccupationsSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005831 RID: 22577 RVA: 0x0010C635 File Offset: 0x0010AA35
		public uint GetMsgID()
		{
			return 608625U;
		}

		// Token: 0x06005832 RID: 22578 RVA: 0x0010C63C File Offset: 0x0010AA3C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005833 RID: 22579 RVA: 0x0010C644 File Offset: 0x0010AA44
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005834 RID: 22580 RVA: 0x0010C650 File Offset: 0x0010AA50
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ownNewOccus.Length);
			for (int i = 0; i < this.ownNewOccus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.ownNewOccus[i]);
			}
		}

		// Token: 0x06005835 RID: 22581 RVA: 0x0010C698 File Offset: 0x0010AA98
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ownNewOccus = new byte[(int)num];
			for (int i = 0; i < this.ownNewOccus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.ownNewOccus[i]);
			}
		}

		// Token: 0x06005836 RID: 22582 RVA: 0x0010C6EC File Offset: 0x0010AAEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.ownNewOccus.Length);
			for (int i = 0; i < this.ownNewOccus.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.ownNewOccus[i]);
			}
		}

		// Token: 0x06005837 RID: 22583 RVA: 0x0010C734 File Offset: 0x0010AB34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.ownNewOccus = new byte[(int)num];
			for (int i = 0; i < this.ownNewOccus.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.ownNewOccus[i]);
			}
		}

		// Token: 0x06005838 RID: 22584 RVA: 0x0010C788 File Offset: 0x0010AB88
		public int getLen()
		{
			int num = 0;
			return num + (2 + this.ownNewOccus.Length);
		}

		// Token: 0x0400231A RID: 8986
		public const uint MsgID = 608625U;

		// Token: 0x0400231B RID: 8987
		public uint Sequence;

		// Token: 0x0400231C RID: 8988
		public byte[] ownNewOccus = new byte[0];
	}
}
