using System;

namespace Protocol
{
	// Token: 0x02000A22 RID: 2594
	[Protocol]
	public class WorldNewTitleSyncUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072E5 RID: 29413 RVA: 0x0014C564 File Offset: 0x0014A964
		public uint GetMsgID()
		{
			return 609206U;
		}

		// Token: 0x060072E6 RID: 29414 RVA: 0x0014C56B File Offset: 0x0014A96B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072E7 RID: 29415 RVA: 0x0014C573 File Offset: 0x0014A973
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072E8 RID: 29416 RVA: 0x0014C57C File Offset: 0x0014A97C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.adds.Length);
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dels.Length);
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.dels[j]);
			}
		}

		// Token: 0x060072E9 RID: 29417 RVA: 0x0014C5FC File Offset: 0x0014A9FC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.adds = new PlayerTitleInfo[(int)num];
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i] = new PlayerTitleInfo();
				this.adds[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.dels = new ulong[(int)num2];
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.dels[j]);
			}
		}

		// Token: 0x060072EA RID: 29418 RVA: 0x0014C69C File Offset: 0x0014AA9C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.adds.Length);
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dels.Length);
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.dels[j]);
			}
		}

		// Token: 0x060072EB RID: 29419 RVA: 0x0014C71C File Offset: 0x0014AB1C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.adds = new PlayerTitleInfo[(int)num];
			for (int i = 0; i < this.adds.Length; i++)
			{
				this.adds[i] = new PlayerTitleInfo();
				this.adds[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.dels = new ulong[(int)num2];
			for (int j = 0; j < this.dels.Length; j++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.dels[j]);
			}
		}

		// Token: 0x060072EC RID: 29420 RVA: 0x0014C7BC File Offset: 0x0014ABBC
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.adds.Length; i++)
			{
				num += this.adds[i].getLen();
			}
			return num + (2 + 8 * this.dels.Length);
		}

		// Token: 0x040034CC RID: 13516
		public const uint MsgID = 609206U;

		// Token: 0x040034CD RID: 13517
		public uint Sequence;

		// Token: 0x040034CE RID: 13518
		public PlayerTitleInfo[] adds = new PlayerTitleInfo[0];

		// Token: 0x040034CF RID: 13519
		public ulong[] dels = new ulong[0];
	}
}
