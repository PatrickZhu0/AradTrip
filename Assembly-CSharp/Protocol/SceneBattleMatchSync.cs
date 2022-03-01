using System;

namespace Protocol
{
	// Token: 0x020006FF RID: 1791
	[Protocol]
	public class SceneBattleMatchSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A70 RID: 23152 RVA: 0x001132A8 File Offset: 0x001116A8
		public uint GetMsgID()
		{
			return 508906U;
		}

		// Token: 0x06005A71 RID: 23153 RVA: 0x001132AF File Offset: 0x001116AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A72 RID: 23154 RVA: 0x001132B7 File Offset: 0x001116B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A73 RID: 23155 RVA: 0x001132C0 File Offset: 0x001116C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.suvivalNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneNodeID);
		}

		// Token: 0x06005A74 RID: 23156 RVA: 0x00113330 File Offset: 0x00111730
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.suvivalNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new PlayerSubject[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new PlayerSubject();
				this.players[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneNodeID);
		}

		// Token: 0x06005A75 RID: 23157 RVA: 0x001133B4 File Offset: 0x001117B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.suvivalNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.sceneNodeID);
		}

		// Token: 0x06005A76 RID: 23158 RVA: 0x00113424 File Offset: 0x00111824
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.suvivalNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.players = new PlayerSubject[(int)num];
			for (int i = 0; i < this.players.Length; i++)
			{
				this.players[i] = new PlayerSubject();
				this.players[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sceneNodeID);
		}

		// Token: 0x06005A77 RID: 23159 RVA: 0x001134A8 File Offset: 0x001118A8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.players.Length; i++)
			{
				num += this.players[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x040024C0 RID: 9408
		public const uint MsgID = 508906U;

		// Token: 0x040024C1 RID: 9409
		public uint Sequence;

		// Token: 0x040024C2 RID: 9410
		public uint battleID;

		// Token: 0x040024C3 RID: 9411
		public uint suvivalNum;

		// Token: 0x040024C4 RID: 9412
		public PlayerSubject[] players = new PlayerSubject[0];

		// Token: 0x040024C5 RID: 9413
		public uint sceneNodeID;
	}
}
