using System;

namespace Protocol
{
	// Token: 0x020009AA RID: 2474
	[Protocol]
	public class SceneEquipSchemeSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F43 RID: 28483 RVA: 0x001417C7 File Offset: 0x0013FBC7
		public uint GetMsgID()
		{
			return 501087U;
		}

		// Token: 0x06006F44 RID: 28484 RVA: 0x001417CE File Offset: 0x0013FBCE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F45 RID: 28485 RVA: 0x001417D6 File Offset: 0x0013FBD6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F46 RID: 28486 RVA: 0x001417E0 File Offset: 0x0013FBE0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.schemes.Length);
			for (int i = 0; i < this.schemes.Length; i++)
			{
				this.schemes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006F47 RID: 28487 RVA: 0x00141828 File Offset: 0x0013FC28
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.schemes = new EquipSchemeInfo[(int)num];
			for (int i = 0; i < this.schemes.Length; i++)
			{
				this.schemes[i] = new EquipSchemeInfo();
				this.schemes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006F48 RID: 28488 RVA: 0x00141884 File Offset: 0x0013FC84
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.schemes.Length);
			for (int i = 0; i < this.schemes.Length; i++)
			{
				this.schemes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006F49 RID: 28489 RVA: 0x001418CC File Offset: 0x0013FCCC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.schemes = new EquipSchemeInfo[(int)num];
			for (int i = 0; i < this.schemes.Length; i++)
			{
				this.schemes[i] = new EquipSchemeInfo();
				this.schemes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006F4A RID: 28490 RVA: 0x00141928 File Offset: 0x0013FD28
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.schemes.Length; i++)
			{
				num += this.schemes[i].getLen();
			}
			return num;
		}

		// Token: 0x0400327C RID: 12924
		public const uint MsgID = 501087U;

		// Token: 0x0400327D RID: 12925
		public uint Sequence;

		// Token: 0x0400327E RID: 12926
		public EquipSchemeInfo[] schemes = new EquipSchemeInfo[0];
	}
}
