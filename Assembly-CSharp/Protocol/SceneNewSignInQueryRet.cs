using System;

namespace Protocol
{
	// Token: 0x0200067B RID: 1659
	[Protocol]
	public class SceneNewSignInQueryRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600567E RID: 22142 RVA: 0x0010917C File Offset: 0x0010757C
		public uint GetMsgID()
		{
			return 501164U;
		}

		// Token: 0x0600567F RID: 22143 RVA: 0x00109183 File Offset: 0x00107583
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005680 RID: 22144 RVA: 0x0010918B File Offset: 0x0010758B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005681 RID: 22145 RVA: 0x00109194 File Offset: 0x00107594
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.signFlag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.collectFlag);
			BaseDLL.encode_int8(buffer, ref pos_, this.noFree);
			BaseDLL.encode_int8(buffer, ref pos_, this.free);
			BaseDLL.encode_int8(buffer, ref pos_, this.activite);
			BaseDLL.encode_int8(buffer, ref pos_, this.activiteCount);
		}

		// Token: 0x06005682 RID: 22146 RVA: 0x001091F8 File Offset: 0x001075F8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.signFlag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.collectFlag);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.noFree);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.free);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activite);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activiteCount);
		}

		// Token: 0x06005683 RID: 22147 RVA: 0x0010925C File Offset: 0x0010765C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.signFlag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.collectFlag);
			BaseDLL.encode_int8(buffer, ref pos_, this.noFree);
			BaseDLL.encode_int8(buffer, ref pos_, this.free);
			BaseDLL.encode_int8(buffer, ref pos_, this.activite);
			BaseDLL.encode_int8(buffer, ref pos_, this.activiteCount);
		}

		// Token: 0x06005684 RID: 22148 RVA: 0x001092C0 File Offset: 0x001076C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.signFlag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.collectFlag);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.noFree);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.free);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activite);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activiteCount);
		}

		// Token: 0x06005685 RID: 22149 RVA: 0x00109324 File Offset: 0x00107724
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x04002259 RID: 8793
		public const uint MsgID = 501164U;

		// Token: 0x0400225A RID: 8794
		public uint Sequence;

		// Token: 0x0400225B RID: 8795
		public uint signFlag;

		// Token: 0x0400225C RID: 8796
		public uint collectFlag;

		// Token: 0x0400225D RID: 8797
		public byte noFree;

		// Token: 0x0400225E RID: 8798
		public byte free;

		// Token: 0x0400225F RID: 8799
		public byte activite;

		// Token: 0x04002260 RID: 8800
		public byte activiteCount;
	}
}
