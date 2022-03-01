using System;

namespace Protocol
{
	// Token: 0x0200092C RID: 2348
	[Protocol]
	public class WorldOpenJarRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006AF6 RID: 27382 RVA: 0x001396EC File Offset: 0x00137AEC
		public uint GetMsgID()
		{
			return 600901U;
		}

		// Token: 0x06006AF7 RID: 27383 RVA: 0x001396F3 File Offset: 0x00137AF3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006AF8 RID: 27384 RVA: 0x001396FB File Offset: 0x00137AFB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006AF9 RID: 27385 RVA: 0x00139704 File Offset: 0x00137B04
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
		}

		// Token: 0x06006AFA RID: 27386 RVA: 0x00139714 File Offset: 0x00137B14
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
		}

		// Token: 0x06006AFB RID: 27387 RVA: 0x00139724 File Offset: 0x00137B24
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
		}

		// Token: 0x06006AFC RID: 27388 RVA: 0x00139734 File Offset: 0x00137B34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
		}

		// Token: 0x06006AFD RID: 27389 RVA: 0x00139744 File Offset: 0x00137B44
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003081 RID: 12417
		public const uint MsgID = 600901U;

		// Token: 0x04003082 RID: 12418
		public uint Sequence;

		// Token: 0x04003083 RID: 12419
		public uint jarId;
	}
}
