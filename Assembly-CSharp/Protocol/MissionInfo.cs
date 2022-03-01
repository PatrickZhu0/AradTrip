using System;

namespace Protocol
{
	// Token: 0x02000C56 RID: 3158
	public class MissionInfo : IProtocolStream
	{
		// Token: 0x06008314 RID: 33556 RVA: 0x00170A58 File Offset: 0x0016EE58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.akMissionPairs.Length);
			for (int i = 0; i < this.akMissionPairs.Length; i++)
			{
				this.akMissionPairs[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.finTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.submitCount);
		}

		// Token: 0x06008315 RID: 33557 RVA: 0x00170AD8 File Offset: 0x0016EED8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.akMissionPairs = new MissionPair[(int)num];
			for (int i = 0; i < this.akMissionPairs.Length; i++)
			{
				this.akMissionPairs[i] = new MissionPair();
				this.akMissionPairs[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.finTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.submitCount);
		}

		// Token: 0x06008316 RID: 33558 RVA: 0x00170B6C File Offset: 0x0016EF6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.akMissionPairs.Length);
			for (int i = 0; i < this.akMissionPairs.Length; i++)
			{
				this.akMissionPairs[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.finTime);
			BaseDLL.encode_int8(buffer, ref pos_, this.submitCount);
		}

		// Token: 0x06008317 RID: 33559 RVA: 0x00170BEC File Offset: 0x0016EFEC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.akMissionPairs = new MissionPair[(int)num];
			for (int i = 0; i < this.akMissionPairs.Length; i++)
			{
				this.akMissionPairs[i] = new MissionPair();
				this.akMissionPairs[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.finTime);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.submitCount);
		}

		// Token: 0x06008318 RID: 33560 RVA: 0x00170C80 File Offset: 0x0016F080
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 2;
			for (int i = 0; i < this.akMissionPairs.Length; i++)
			{
				num += this.akMissionPairs[i].getLen();
			}
			num += 4;
			return num + 1;
		}

		// Token: 0x04003EB5 RID: 16053
		public uint taskID;

		// Token: 0x04003EB6 RID: 16054
		public byte status;

		// Token: 0x04003EB7 RID: 16055
		public MissionPair[] akMissionPairs = new MissionPair[0];

		// Token: 0x04003EB8 RID: 16056
		public uint finTime;

		// Token: 0x04003EB9 RID: 16057
		public byte submitCount;
	}
}
