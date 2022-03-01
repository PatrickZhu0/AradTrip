using System;

namespace Protocol
{
	// Token: 0x02000732 RID: 1842
	[Protocol]
	public class BetHorseRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C11 RID: 23569 RVA: 0x0011622C File Offset: 0x0011462C
		public uint GetMsgID()
		{
			return 708302U;
		}

		// Token: 0x06005C12 RID: 23570 RVA: 0x00116233 File Offset: 0x00114633
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C13 RID: 23571 RVA: 0x0011623B File Offset: 0x0011463B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C14 RID: 23572 RVA: 0x00116244 File Offset: 0x00114644
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.weather);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mysteryShooter);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phase);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stamp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shooterList.Length);
			for (int i = 0; i < this.shooterList.Length; i++)
			{
				this.shooterList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapList.Length);
			for (int j = 0; j < this.mapList.Length; j++)
			{
				this.mapList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C15 RID: 23573 RVA: 0x001162FC File Offset: 0x001146FC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weather);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mysteryShooter);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phase);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stamp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shooterList = new ShooterInfo[(int)num];
			for (int i = 0; i < this.shooterList.Length; i++)
			{
				this.shooterList[i] = new ShooterInfo();
				this.shooterList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.mapList = new MapInfo[(int)num2];
			for (int j = 0; j < this.mapList.Length; j++)
			{
				this.mapList[j] = new MapInfo();
				this.mapList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C16 RID: 23574 RVA: 0x001163DC File Offset: 0x001147DC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.weather);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mysteryShooter);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phase);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stamp);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.shooterList.Length);
			for (int i = 0; i < this.shooterList.Length; i++)
			{
				this.shooterList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapList.Length);
			for (int j = 0; j < this.mapList.Length; j++)
			{
				this.mapList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C17 RID: 23575 RVA: 0x00116494 File Offset: 0x00114894
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weather);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mysteryShooter);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phase);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stamp);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.shooterList = new ShooterInfo[(int)num];
			for (int i = 0; i < this.shooterList.Length; i++)
			{
				this.shooterList[i] = new ShooterInfo();
				this.shooterList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.mapList = new MapInfo[(int)num2];
			for (int j = 0; j < this.mapList.Length; j++)
			{
				this.mapList[j] = new MapInfo();
				this.mapList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005C18 RID: 23576 RVA: 0x00116574 File Offset: 0x00114974
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.shooterList.Length; i++)
			{
				num += this.shooterList[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.mapList.Length; j++)
			{
				num += this.mapList[j].getLen();
			}
			return num;
		}

		// Token: 0x04002594 RID: 9620
		public const uint MsgID = 708302U;

		// Token: 0x04002595 RID: 9621
		public uint Sequence;

		// Token: 0x04002596 RID: 9622
		public uint weather;

		// Token: 0x04002597 RID: 9623
		public uint mysteryShooter;

		// Token: 0x04002598 RID: 9624
		public uint phase;

		// Token: 0x04002599 RID: 9625
		public uint stamp;

		// Token: 0x0400259A RID: 9626
		public ShooterInfo[] shooterList = new ShooterInfo[0];

		// Token: 0x0400259B RID: 9627
		public MapInfo[] mapList = new MapInfo[0];
	}
}
