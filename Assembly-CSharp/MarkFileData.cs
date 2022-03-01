using System;
using GameClient;

// Token: 0x020046B4 RID: 18100
public class MarkFileData
{
	// Token: 0x06019A59 RID: 105049 RVA: 0x00813AA4 File Offset: 0x00811EA4
	public void Recycle()
	{
		this.sessionId = 0UL;
		this.battleType = 0;
		this.dungeonMode = 0;
		this.version = string.Empty;
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			FrameMarkDataPool.Release(this.markDatas[i]);
		}
		this.markDatas = new FrameMarkData[0];
	}

	// Token: 0x06019A5A RID: 105050 RVA: 0x00813B04 File Offset: 0x00811F04
	public void encode(byte[] buffer, ref int pos_)
	{
		BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
		BaseDLL.encode_int8(buffer, ref pos_, this.battleType);
		BaseDLL.encode_int8(buffer, ref pos_, this.dungeonMode);
		byte[] str = StringHelper.StringToUTF8Bytes(this.version);
		BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.markDatas.Length);
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i].encode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A5B RID: 105051 RVA: 0x00813B90 File Offset: 0x00811F90
	public void decode(byte[] buffer, ref int pos_)
	{
		BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
		BaseDLL.decode_int8(buffer, ref pos_, ref this.battleType);
		BaseDLL.decode_int8(buffer, ref pos_, ref this.dungeonMode);
		ushort num = 0;
		BaseDLL.decode_uint16(buffer, ref pos_, ref num);
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
		}
		this.version = StringHelper.BytesToString(array);
		uint num2 = 0U;
		BaseDLL.decode_uint32(buffer, ref pos_, ref num2);
		this.markDatas = new FrameMarkData[num2];
		for (int j = 0; j < this.markDatas.Length; j++)
		{
			this.markDatas[j] = new FrameMarkData();
			this.markDatas[j].decode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A5C RID: 105052 RVA: 0x00813C5C File Offset: 0x0081205C
	public void encode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
		BaseDLL.encode_int8(buffer, ref pos_, this.battleType);
		BaseDLL.encode_int8(buffer, ref pos_, this.dungeonMode);
		byte[] str = StringHelper.StringToUTF8Bytes(this.version);
		BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.markDatas.Length);
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i].encode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A5D RID: 105053 RVA: 0x00813CEC File Offset: 0x008120EC
	public void decode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
		BaseDLL.decode_int8(buffer, ref pos_, ref this.battleType);
		BaseDLL.decode_int8(buffer, ref pos_, ref this.dungeonMode);
		ushort num = 0;
		BaseDLL.decode_uint16(buffer, ref pos_, ref num);
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
		}
		this.version = StringHelper.BytesToString(array);
		uint num2 = 0U;
		BaseDLL.decode_uint32(buffer, ref pos_, ref num2);
		this.markDatas = new FrameMarkData[num2];
		for (int j = 0; j < this.markDatas.Length; j++)
		{
			this.markDatas[j] = new FrameMarkData();
			this.markDatas[j].decode(buffer, ref pos_);
		}
	}

	// Token: 0x0401246F RID: 74863
	public ulong sessionId;

	// Token: 0x04012470 RID: 74864
	public byte battleType;

	// Token: 0x04012471 RID: 74865
	public byte dungeonMode;

	// Token: 0x04012472 RID: 74866
	public string version = string.Empty;

	// Token: 0x04012473 RID: 74867
	public FrameMarkData[] markDatas = new FrameMarkData[0];
}
