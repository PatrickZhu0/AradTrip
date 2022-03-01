using System;

namespace Protocol
{
	// Token: 0x02000B3E RID: 2878
	[Protocol]
	public class SceneSyncServiceSwitch : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AF5 RID: 31477 RVA: 0x00160750 File Offset: 0x0015EB50
		public uint GetMsgID()
		{
			return 501214U;
		}

		// Token: 0x06007AF6 RID: 31478 RVA: 0x00160757 File Offset: 0x0015EB57
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007AF7 RID: 31479 RVA: 0x0016075F File Offset: 0x0015EB5F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007AF8 RID: 31480 RVA: 0x00160768 File Offset: 0x0015EB68
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.closedServices.Length);
			for (int i = 0; i < this.closedServices.Length; i++)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, this.closedServices[i]);
			}
		}

		// Token: 0x06007AF9 RID: 31481 RVA: 0x001607B0 File Offset: 0x0015EBB0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.closedServices = new ushort[(int)num];
			for (int i = 0; i < this.closedServices.Length; i++)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref this.closedServices[i]);
			}
		}

		// Token: 0x06007AFA RID: 31482 RVA: 0x00160804 File Offset: 0x0015EC04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.closedServices.Length);
			for (int i = 0; i < this.closedServices.Length; i++)
			{
				BaseDLL.encode_uint16(buffer, ref pos_, this.closedServices[i]);
			}
		}

		// Token: 0x06007AFB RID: 31483 RVA: 0x0016084C File Offset: 0x0015EC4C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.closedServices = new ushort[(int)num];
			for (int i = 0; i < this.closedServices.Length; i++)
			{
				BaseDLL.decode_uint16(buffer, ref pos_, ref this.closedServices[i]);
			}
		}

		// Token: 0x06007AFC RID: 31484 RVA: 0x001608A0 File Offset: 0x0015ECA0
		public int getLen()
		{
			int num = 0;
			return num + (2 + 2 * this.closedServices.Length);
		}

		// Token: 0x04003A44 RID: 14916
		public const uint MsgID = 501214U;

		// Token: 0x04003A45 RID: 14917
		public uint Sequence;

		// Token: 0x04003A46 RID: 14918
		public ushort[] closedServices = new ushort[0];
	}
}
