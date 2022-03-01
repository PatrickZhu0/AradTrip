using System;

namespace Protocol
{
	// Token: 0x020007D0 RID: 2000
	[Protocol]
	public class SceneDungeonSyncNewOpenedList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060BB RID: 24763 RVA: 0x00122CC0 File Offset: 0x001210C0
		public uint GetMsgID()
		{
			return 506822U;
		}

		// Token: 0x060060BC RID: 24764 RVA: 0x00122CC7 File Offset: 0x001210C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060BD RID: 24765 RVA: 0x00122CCF File Offset: 0x001210CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060BE RID: 24766 RVA: 0x00122CD8 File Offset: 0x001210D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.newOpenedList.Length);
			for (int i = 0; i < this.newOpenedList.Length; i++)
			{
				this.newOpenedList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.newClosedList.Length);
			for (int j = 0; j < this.newClosedList.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.newClosedList[j]);
			}
		}

		// Token: 0x060060BF RID: 24767 RVA: 0x00122D58 File Offset: 0x00121158
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.newOpenedList = new DungeonOpenInfo[(int)num];
			for (int i = 0; i < this.newOpenedList.Length; i++)
			{
				this.newOpenedList[i] = new DungeonOpenInfo();
				this.newOpenedList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.newClosedList = new uint[(int)num2];
			for (int j = 0; j < this.newClosedList.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.newClosedList[j]);
			}
		}

		// Token: 0x060060C0 RID: 24768 RVA: 0x00122DF8 File Offset: 0x001211F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.newOpenedList.Length);
			for (int i = 0; i < this.newOpenedList.Length; i++)
			{
				this.newOpenedList[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.newClosedList.Length);
			for (int j = 0; j < this.newClosedList.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.newClosedList[j]);
			}
		}

		// Token: 0x060060C1 RID: 24769 RVA: 0x00122E78 File Offset: 0x00121278
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.newOpenedList = new DungeonOpenInfo[(int)num];
			for (int i = 0; i < this.newOpenedList.Length; i++)
			{
				this.newOpenedList[i] = new DungeonOpenInfo();
				this.newOpenedList[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.newClosedList = new uint[(int)num2];
			for (int j = 0; j < this.newClosedList.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.newClosedList[j]);
			}
		}

		// Token: 0x060060C2 RID: 24770 RVA: 0x00122F18 File Offset: 0x00121318
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.newOpenedList.Length; i++)
			{
				num += this.newOpenedList[i].getLen();
			}
			return num + (2 + 4 * this.newClosedList.Length);
		}

		// Token: 0x0400285A RID: 10330
		public const uint MsgID = 506822U;

		// Token: 0x0400285B RID: 10331
		public uint Sequence;

		// Token: 0x0400285C RID: 10332
		public DungeonOpenInfo[] newOpenedList = new DungeonOpenInfo[0];

		// Token: 0x0400285D RID: 10333
		public uint[] newClosedList = new uint[0];
	}
}
