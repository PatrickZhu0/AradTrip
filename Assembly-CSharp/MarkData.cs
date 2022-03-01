using System;
using GameClient;

// Token: 0x020046B2 RID: 18098
public class MarkData
{
	// Token: 0x06019A4D RID: 105037 RVA: 0x008136A0 File Offset: 0x00811AA0
	public void Recycle()
	{
		this.id = 0U;
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			MarkNodeDataPool.Release(this.markDatas[i]);
		}
		this.markDatas = new NodeData[0];
	}

	// Token: 0x06019A4E RID: 105038 RVA: 0x008136E8 File Offset: 0x00811AE8
	public void encode(byte[] buffer, ref int pos_)
	{
		BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.markDatas.Length);
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i].encode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A4F RID: 105039 RVA: 0x0081373C File Offset: 0x00811B3C
	public void decode(byte[] buffer, ref int pos_)
	{
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		uint num = 0U;
		BaseDLL.decode_uint32(buffer, ref pos_, ref num);
		this.markDatas = new NodeData[num];
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i] = new NodeData();
			this.markDatas[i].decode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A50 RID: 105040 RVA: 0x008137A8 File Offset: 0x00811BA8
	public void encode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		BaseDLL.encode_uint32(buffer, ref pos_, (uint)this.markDatas.Length);
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i].encode(buffer, ref pos_);
		}
	}

	// Token: 0x06019A51 RID: 105041 RVA: 0x008137FC File Offset: 0x00811BFC
	public void decode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		uint num = 0U;
		BaseDLL.decode_uint32(buffer, ref pos_, ref num);
		this.markDatas = new NodeData[num];
		for (int i = 0; i < this.markDatas.Length; i++)
		{
			this.markDatas[i] = new NodeData();
			this.markDatas[i].decode(buffer, ref pos_);
		}
	}

	// Token: 0x0401246A RID: 74858
	public uint id;

	// Token: 0x0401246B RID: 74859
	public NodeData[] markDatas = new NodeData[0];
}
