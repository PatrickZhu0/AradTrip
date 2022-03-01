using System;
using GameClient;

// Token: 0x020046B3 RID: 18099
public class FrameMarkData
{
	// Token: 0x06019A53 RID: 105043 RVA: 0x0081387C File Offset: 0x00811C7C
	public void Recycle()
	{
		this.frame = 0U;
		this.sequence = 0U;
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			MarkDataPool.Release(this.markDatas[i]);
		}
		this.markDatas = new MarkData[0];
	}

	// Token: 0x06019A54 RID: 105044 RVA: 0x008138CC File Offset: 0x00811CCC
	public void encode(byte[] buffer, ref int pos_)
	{
		BaseDLL.encode_uint32(buffer, ref pos_, this.frame);
		BaseDLL.encode_uint32(buffer, ref pos_, this.sequence);
		BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.markDatas.Length);
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i].encode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A55 RID: 105045 RVA: 0x00813930 File Offset: 0x00811D30
	public void decode(byte[] buffer, ref int pos_)
	{
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.frame);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.sequence);
		uint num = 0U;
		BaseDLL.decode_uint32(buffer, ref pos_, ref num);
		this.markDatas = new MarkData[num];
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i] = new MarkData();
			this.markDatas[i].decode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A56 RID: 105046 RVA: 0x008139A8 File Offset: 0x00811DA8
	public void encode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.encode_uint32(buffer, ref pos_, this.frame);
		BaseDLL.encode_uint32(buffer, ref pos_, this.sequence);
		BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.markDatas.Length);
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i].encode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A57 RID: 105047 RVA: 0x00813A0C File Offset: 0x00811E0C
	public void decode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.frame);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.sequence);
		uint num = 0U;
		BaseDLL.decode_uint32(buffer, ref pos_, ref num);
		this.markDatas = new MarkData[num];
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i] = new MarkData();
			this.markDatas[i].decode(buffer, ref pos_);
		}
	}

	// Token: 0x0401246C RID: 74860
	public uint frame;

	// Token: 0x0401246D RID: 74861
	public uint sequence;

	// Token: 0x0401246E RID: 74862
	public MarkData[] markDatas = new MarkData[0];
}
