using System;

namespace Protocol
{
	// Token: 0x020007B0 RID: 1968
	[Protocol]
	public class SceneDungeonHardInit : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005FC2 RID: 24514 RVA: 0x0011E6DF File Offset: 0x0011CADF
		public uint GetMsgID()
		{
			return 506803U;
		}

		// Token: 0x06005FC3 RID: 24515 RVA: 0x0011E6E6 File Offset: 0x0011CAE6
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005FC4 RID: 24516 RVA: 0x0011E6EE File Offset: 0x0011CAEE
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005FC5 RID: 24517 RVA: 0x0011E6F8 File Offset: 0x0011CAF8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.allInfo.Length);
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FC6 RID: 24518 RVA: 0x0011E740 File Offset: 0x0011CB40
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.allInfo = new SceneDungeonHardInfo[(int)num];
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i] = new SceneDungeonHardInfo();
				this.allInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FC7 RID: 24519 RVA: 0x0011E79C File Offset: 0x0011CB9C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.allInfo.Length);
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FC8 RID: 24520 RVA: 0x0011E7E4 File Offset: 0x0011CBE4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.allInfo = new SceneDungeonHardInfo[(int)num];
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i] = new SceneDungeonHardInfo();
				this.allInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FC9 RID: 24521 RVA: 0x0011E840 File Offset: 0x0011CC40
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				num += this.allInfo[i].getLen();
			}
			return num;
		}

		// Token: 0x040027A4 RID: 10148
		public const uint MsgID = 506803U;

		// Token: 0x040027A5 RID: 10149
		public uint Sequence;

		// Token: 0x040027A6 RID: 10150
		public SceneDungeonHardInfo[] allInfo = new SceneDungeonHardInfo[0];
	}
}
