using System;

namespace Protocol
{
	// Token: 0x02000687 RID: 1671
	[Protocol]
	public class WorldActivityMonsterRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056E7 RID: 22247 RVA: 0x00109BA7 File Offset: 0x00107FA7
		public uint GetMsgID()
		{
			return 607405U;
		}

		// Token: 0x060056E8 RID: 22248 RVA: 0x00109BAE File Offset: 0x00107FAE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056E9 RID: 22249 RVA: 0x00109BB6 File Offset: 0x00107FB6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056EA RID: 22250 RVA: 0x00109BC0 File Offset: 0x00107FC0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.activityId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsters.Length);
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060056EB RID: 22251 RVA: 0x00109C14 File Offset: 0x00108014
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activityId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsters = new ActivityMonsterInfo[(int)num];
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i] = new ActivityMonsterInfo();
				this.monsters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060056EC RID: 22252 RVA: 0x00109C7C File Offset: 0x0010807C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.activityId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsters.Length);
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060056ED RID: 22253 RVA: 0x00109CD0 File Offset: 0x001080D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activityId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsters = new ActivityMonsterInfo[(int)num];
			for (int i = 0; i < this.monsters.Length; i++)
			{
				this.monsters[i] = new ActivityMonsterInfo();
				this.monsters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060056EE RID: 22254 RVA: 0x00109D38 File Offset: 0x00108138
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.monsters.Length; i++)
			{
				num += this.monsters[i].getLen();
			}
			return num;
		}

		// Token: 0x04002284 RID: 8836
		public const uint MsgID = 607405U;

		// Token: 0x04002285 RID: 8837
		public uint Sequence;

		// Token: 0x04002286 RID: 8838
		public uint activityId;

		// Token: 0x04002287 RID: 8839
		public ActivityMonsterInfo[] monsters = new ActivityMonsterInfo[0];
	}
}
