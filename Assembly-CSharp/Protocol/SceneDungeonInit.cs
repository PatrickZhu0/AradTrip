using System;

namespace Protocol
{
	// Token: 0x020007AC RID: 1964
	[Protocol]
	public class SceneDungeonInit : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005FA4 RID: 24484 RVA: 0x0011E2A1 File Offset: 0x0011C6A1
		public uint GetMsgID()
		{
			return 506801U;
		}

		// Token: 0x06005FA5 RID: 24485 RVA: 0x0011E2A8 File Offset: 0x0011C6A8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005FA6 RID: 24486 RVA: 0x0011E2B0 File Offset: 0x0011C6B0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005FA7 RID: 24487 RVA: 0x0011E2BC File Offset: 0x0011C6BC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.allInfo.Length);
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FA8 RID: 24488 RVA: 0x0011E304 File Offset: 0x0011C704
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.allInfo = new SceneDungeonInfo[(int)num];
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i] = new SceneDungeonInfo();
				this.allInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FA9 RID: 24489 RVA: 0x0011E360 File Offset: 0x0011C760
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.allInfo.Length);
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FAA RID: 24490 RVA: 0x0011E3A8 File Offset: 0x0011C7A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.allInfo = new SceneDungeonInfo[(int)num];
			for (int i = 0; i < this.allInfo.Length; i++)
			{
				this.allInfo[i] = new SceneDungeonInfo();
				this.allInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005FAB RID: 24491 RVA: 0x0011E404 File Offset: 0x0011C804
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

		// Token: 0x0400279B RID: 10139
		public const uint MsgID = 506801U;

		// Token: 0x0400279C RID: 10140
		public uint Sequence;

		// Token: 0x0400279D RID: 10141
		public SceneDungeonInfo[] allInfo = new SceneDungeonInfo[0];
	}
}
