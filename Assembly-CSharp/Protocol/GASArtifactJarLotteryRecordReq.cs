using System;

namespace Protocol
{
	// Token: 0x02000969 RID: 2409
	[Protocol]
	public class GASArtifactJarLotteryRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D12 RID: 27922 RVA: 0x0013CFCD File Offset: 0x0013B3CD
		public uint GetMsgID()
		{
			return 700901U;
		}

		// Token: 0x06006D13 RID: 27923 RVA: 0x0013CFD4 File Offset: 0x0013B3D4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D14 RID: 27924 RVA: 0x0013CFDC File Offset: 0x0013B3DC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D15 RID: 27925 RVA: 0x0013CFE5 File Offset: 0x0013B3E5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
		}

		// Token: 0x06006D16 RID: 27926 RVA: 0x0013CFF5 File Offset: 0x0013B3F5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
		}

		// Token: 0x06006D17 RID: 27927 RVA: 0x0013D005 File Offset: 0x0013B405
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
		}

		// Token: 0x06006D18 RID: 27928 RVA: 0x0013D015 File Offset: 0x0013B415
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
		}

		// Token: 0x06006D19 RID: 27929 RVA: 0x0013D028 File Offset: 0x0013B428
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003164 RID: 12644
		public const uint MsgID = 700901U;

		// Token: 0x04003165 RID: 12645
		public uint Sequence;

		// Token: 0x04003166 RID: 12646
		public uint jarId;
	}
}
