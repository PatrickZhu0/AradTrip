using System;

namespace Protocol
{
	// Token: 0x020007AB RID: 1963
	public class DungeonAdditionInfo : IProtocolStream
	{
		// Token: 0x06005F9E RID: 24478 RVA: 0x0011E188 File Offset: 0x0011C588
		public void encode(byte[] buffer, ref int pos_)
		{
			for (int i = 0; i < this.addition.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.addition[i]);
			}
		}

		// Token: 0x06005F9F RID: 24479 RVA: 0x0011E1C0 File Offset: 0x0011C5C0
		public void decode(byte[] buffer, ref int pos_)
		{
			for (int i = 0; i < this.addition.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.addition[i]);
			}
		}

		// Token: 0x06005FA0 RID: 24480 RVA: 0x0011E1FC File Offset: 0x0011C5FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			for (int i = 0; i < this.addition.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.addition[i]);
			}
		}

		// Token: 0x06005FA1 RID: 24481 RVA: 0x0011E234 File Offset: 0x0011C634
		public void decode(MapViewStream buffer, ref int pos_)
		{
			for (int i = 0; i < this.addition.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.addition[i]);
			}
		}

		// Token: 0x06005FA2 RID: 24482 RVA: 0x0011E270 File Offset: 0x0011C670
		public int getLen()
		{
			int num = 0;
			return num + 4 * this.addition.Length;
		}

		// Token: 0x0400279A RID: 10138
		public uint[] addition = new uint[10];
	}
}
