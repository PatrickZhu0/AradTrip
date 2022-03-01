using System;

namespace Protocol
{
	// Token: 0x020007C4 RID: 1988
	[Protocol]
	public class SceneDungeonRaceEndReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006055 RID: 24661 RVA: 0x001215D4 File Offset: 0x0011F9D4
		public uint GetMsgID()
		{
			return 506811U;
		}

		// Token: 0x06006056 RID: 24662 RVA: 0x001215DB File Offset: 0x0011F9DB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006057 RID: 24663 RVA: 0x001215E3 File Offset: 0x0011F9E3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006058 RID: 24664 RVA: 0x001215EC File Offset: 0x0011F9EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.beHitCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint64(buffer, ref pos_, this.totalDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastChecksum);
		}

		// Token: 0x06006059 RID: 24665 RVA: 0x00121704 File Offset: 0x0011FB04
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.beHitCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.totalDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastChecksum);
		}

		// Token: 0x0600605A RID: 24666 RVA: 0x00121820 File Offset: 0x0011FC20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.beHitCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.maxDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.skillId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint64(buffer, ref pos_, this.totalDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastFrame);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossDamage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerRemainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2ID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss1RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.boss2RemainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastChecksum);
		}

		// Token: 0x0600605B RID: 24667 RVA: 0x00121938 File Offset: 0x0011FD38
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.score);
			for (int i = 0; i < this.md5.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.beHitCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.maxDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.totalDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastFrame);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossDamage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerRemainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2ID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss1RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.boss2RemainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastChecksum);
		}

		// Token: 0x0600605C RID: 24668 RVA: 0x00121A54 File Offset: 0x0011FE54
		public int getLen()
		{
			int num = 0;
			num++;
			num += this.md5.Length;
			num += 4;
			num += 2;
			num += 4;
			num += 4;
			num += 4;
			num += 8;
			num += 4;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400280A RID: 10250
		public const uint MsgID = 506811U;

		// Token: 0x0400280B RID: 10251
		public uint Sequence;

		// Token: 0x0400280C RID: 10252
		public byte score;

		// Token: 0x0400280D RID: 10253
		public byte[] md5 = new byte[16];

		// Token: 0x0400280E RID: 10254
		public uint usedTime;

		// Token: 0x0400280F RID: 10255
		public ushort beHitCount;

		// Token: 0x04002810 RID: 10256
		public uint maxDamage;

		// Token: 0x04002811 RID: 10257
		public uint skillId;

		// Token: 0x04002812 RID: 10258
		public uint param;

		// Token: 0x04002813 RID: 10259
		public ulong totalDamage;

		// Token: 0x04002814 RID: 10260
		public uint lastFrame;

		// Token: 0x04002815 RID: 10261
		public ulong bossDamage;

		// Token: 0x04002816 RID: 10262
		public uint playerRemainHp;

		// Token: 0x04002817 RID: 10263
		public uint playerRemainMp;

		// Token: 0x04002818 RID: 10264
		public uint boss1ID;

		// Token: 0x04002819 RID: 10265
		public uint boss2ID;

		// Token: 0x0400281A RID: 10266
		public uint boss1RemainHp;

		// Token: 0x0400281B RID: 10267
		public uint boss2RemainHp;

		// Token: 0x0400281C RID: 10268
		public uint lastChecksum;
	}
}
