using System;

namespace Protocol
{
	// Token: 0x02000AB9 RID: 2745
	[Protocol]
	public class SceneRetinueChangeSkillReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007726 RID: 30502 RVA: 0x001589E3 File Offset: 0x00156DE3
		public uint GetMsgID()
		{
			return 507005U;
		}

		// Token: 0x06007727 RID: 30503 RVA: 0x001589EA File Offset: 0x00156DEA
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007728 RID: 30504 RVA: 0x001589F2 File Offset: 0x00156DF2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007729 RID: 30505 RVA: 0x001589FC File Offset: 0x00156DFC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillIds.Length);
			for (int i = 0; i < this.skillIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.skillIds[i]);
			}
		}

		// Token: 0x0600772A RID: 30506 RVA: 0x00158A54 File Offset: 0x00156E54
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillIds = new uint[(int)num];
			for (int i = 0; i < this.skillIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillIds[i]);
			}
		}

		// Token: 0x0600772B RID: 30507 RVA: 0x00158AB4 File Offset: 0x00156EB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skillIds.Length);
			for (int i = 0; i < this.skillIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.skillIds[i]);
			}
		}

		// Token: 0x0600772C RID: 30508 RVA: 0x00158B0C File Offset: 0x00156F0C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.skillIds = new uint[(int)num];
			for (int i = 0; i < this.skillIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.skillIds[i]);
			}
		}

		// Token: 0x0600772D RID: 30509 RVA: 0x00158B6C File Offset: 0x00156F6C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + (2 + 4 * this.skillIds.Length);
		}

		// Token: 0x040037CC RID: 14284
		public const uint MsgID = 507005U;

		// Token: 0x040037CD RID: 14285
		public uint Sequence;

		// Token: 0x040037CE RID: 14286
		public ulong id;

		// Token: 0x040037CF RID: 14287
		public uint[] skillIds = new uint[0];
	}
}
