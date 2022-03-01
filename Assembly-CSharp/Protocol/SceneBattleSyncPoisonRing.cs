using System;

namespace Protocol
{
	// Token: 0x02000704 RID: 1796
	[Protocol]
	public class SceneBattleSyncPoisonRing : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A9D RID: 23197 RVA: 0x00113780 File Offset: 0x00111B80
		public uint GetMsgID()
		{
			return 508910U;
		}

		// Token: 0x06005A9E RID: 23198 RVA: 0x00113787 File Offset: 0x00111B87
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A9F RID: 23199 RVA: 0x0011378F File Offset: 0x00111B8F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AA0 RID: 23200 RVA: 0x00113798 File Offset: 0x00111B98
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
			BaseDLL.encode_uint32(buffer, ref pos_, this.radius);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beginTimestamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.interval);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.radius1);
		}

		// Token: 0x06005AA1 RID: 23201 RVA: 0x00113824 File Offset: 0x00111C24
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.radius);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beginTimestamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.interval);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.radius1);
		}

		// Token: 0x06005AA2 RID: 23202 RVA: 0x001138B0 File Offset: 0x00111CB0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
			BaseDLL.encode_uint32(buffer, ref pos_, this.radius);
			BaseDLL.encode_uint32(buffer, ref pos_, this.beginTimestamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.interval);
			BaseDLL.encode_uint32(buffer, ref pos_, this.x1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.radius1);
		}

		// Token: 0x06005AA3 RID: 23203 RVA: 0x0011393C File Offset: 0x00111D3C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.radius);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.beginTimestamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.interval);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.radius1);
		}

		// Token: 0x06005AA4 RID: 23204 RVA: 0x001139C8 File Offset: 0x00111DC8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040024D5 RID: 9429
		public const uint MsgID = 508910U;

		// Token: 0x040024D6 RID: 9430
		public uint Sequence;

		// Token: 0x040024D7 RID: 9431
		public uint battleID;

		// Token: 0x040024D8 RID: 9432
		public uint x;

		// Token: 0x040024D9 RID: 9433
		public uint y;

		// Token: 0x040024DA RID: 9434
		public uint radius;

		// Token: 0x040024DB RID: 9435
		public uint beginTimestamp;

		// Token: 0x040024DC RID: 9436
		public uint interval;

		// Token: 0x040024DD RID: 9437
		public uint x1;

		// Token: 0x040024DE RID: 9438
		public uint y1;

		// Token: 0x040024DF RID: 9439
		public uint radius1;
	}
}
