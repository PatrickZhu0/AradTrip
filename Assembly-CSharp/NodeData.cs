using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020046B1 RID: 18097
public class NodeData
{
	// Token: 0x06019A45 RID: 105029 RVA: 0x008131C4 File Offset: 0x008115C4
	public NodeData Add(params int[] args)
	{
		List<int> list = ListPool<int>.Get();
		list.AddRange(this.paramDatas);
		list.AddRange(args);
		this.paramDatas = list.ToArray();
		ListPool<int>.Release(list);
		return this;
	}

	// Token: 0x06019A46 RID: 105030 RVA: 0x00813200 File Offset: 0x00811600
	public NodeData Add(params string[] args)
	{
		List<string> list = ListPool<string>.Get();
		list.AddRange(this.paramStrings);
		list.AddRange(args);
		this.paramStrings = list.ToArray();
		ListPool<string>.Release(list);
		return this;
	}

	// Token: 0x06019A47 RID: 105031 RVA: 0x00813239 File Offset: 0x00811639
	public void Recycle()
	{
		this.callNum = 0U;
		this.totalCallNum = 0U;
		this.timeStamp = 0UL;
		this.randCallNum = 0U;
		this.randSeed = 0U;
		this.paramDatas = new int[0];
		this.paramStrings = new string[0];
	}

	// Token: 0x06019A48 RID: 105032 RVA: 0x00813278 File Offset: 0x00811678
	public void encode(byte[] buffer, ref int pos_)
	{
		BaseDLL.encode_uint32(buffer, ref pos_, this.callNum);
		BaseDLL.encode_uint32(buffer, ref pos_, this.totalCallNum);
		BaseDLL.encode_uint64(buffer, ref pos_, this.timeStamp);
		BaseDLL.encode_uint32(buffer, ref pos_, this.randCallNum);
		BaseDLL.encode_uint32(buffer, ref pos_, this.randSeed);
		BaseDLL.encode_int8(buffer, ref pos_, (byte)this.paramDatas.Length);
		for (int i = 0; i < this.paramDatas.Length; i++)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.paramDatas[i]);
		}
		BaseDLL.encode_int8(buffer, ref pos_, (byte)this.paramStrings.Length);
		for (int j = 0; j < this.paramStrings.Length; j++)
		{
			if (this.paramStrings[j] == null)
			{
				this.paramStrings[j] = string.Empty;
			}
			byte[] str = StringHelper.StringToUTF8Bytes(this.paramStrings[j]);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}
	}

	// Token: 0x06019A49 RID: 105033 RVA: 0x00813368 File Offset: 0x00811768
	public void decode(byte[] buffer, ref int pos_)
	{
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.callNum);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCallNum);
		BaseDLL.decode_uint64(buffer, ref pos_, ref this.timeStamp);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.randCallNum);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.randSeed);
		byte b = 0;
		BaseDLL.decode_int8(buffer, ref pos_, ref b);
		this.paramDatas = new int[(int)b];
		for (int i = 0; i < this.paramDatas.Length; i++)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.paramDatas[i]);
		}
		byte b2 = 0;
		BaseDLL.decode_int8(buffer, ref pos_, ref b2);
		this.paramStrings = new string[(int)b2];
		for (int j = 0; j < this.paramStrings.Length; j++)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int k = 0; k < (int)num; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[k]);
			}
			this.paramStrings[j] = StringHelper.BytesToString(array);
		}
	}

	// Token: 0x06019A4A RID: 105034 RVA: 0x00813480 File Offset: 0x00811880
	public void encode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.encode_uint32(buffer, ref pos_, this.callNum);
		BaseDLL.encode_uint32(buffer, ref pos_, this.totalCallNum);
		BaseDLL.encode_uint64(buffer, ref pos_, this.timeStamp);
		BaseDLL.encode_uint32(buffer, ref pos_, this.randCallNum);
		BaseDLL.encode_uint32(buffer, ref pos_, this.randSeed);
		BaseDLL.encode_int8(buffer, ref pos_, (byte)this.paramDatas.Length);
		for (int i = 0; i < this.paramDatas.Length; i++)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.paramDatas[i]);
		}
		BaseDLL.encode_int8(buffer, ref pos_, (byte)this.paramStrings.Length);
		for (int j = 0; j < this.paramStrings.Length; j++)
		{
			if (this.paramStrings[j] == null)
			{
				this.paramStrings[j] = string.Empty;
			}
			byte[] str = StringHelper.StringToUTF8Bytes(this.paramStrings[j]);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}
	}

	// Token: 0x06019A4B RID: 105035 RVA: 0x00813574 File Offset: 0x00811974
	public void decode(MapViewStream buffer, ref int pos_)
	{
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.callNum);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCallNum);
		BaseDLL.decode_uint64(buffer, ref pos_, ref this.timeStamp);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.randCallNum);
		BaseDLL.decode_uint32(buffer, ref pos_, ref this.randSeed);
		byte b = 0;
		BaseDLL.decode_int8(buffer, ref pos_, ref b);
		this.paramDatas = new int[(int)b];
		for (int i = 0; i < this.paramDatas.Length; i++)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.paramDatas[i]);
		}
		byte b2 = 0;
		BaseDLL.decode_int8(buffer, ref pos_, ref b2);
		this.paramStrings = new string[(int)b2];
		for (int j = 0; j < this.paramStrings.Length; j++)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int k = 0; k < (int)num; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[k]);
			}
			this.paramStrings[j] = StringHelper.BytesToString(array);
		}
	}

	// Token: 0x04012463 RID: 74851
	public uint callNum;

	// Token: 0x04012464 RID: 74852
	public uint totalCallNum;

	// Token: 0x04012465 RID: 74853
	public ulong timeStamp;

	// Token: 0x04012466 RID: 74854
	public uint randCallNum;

	// Token: 0x04012467 RID: 74855
	public uint randSeed;

	// Token: 0x04012468 RID: 74856
	public int[] paramDatas = new int[0];

	// Token: 0x04012469 RID: 74857
	public string[] paramStrings = new string[0];
}
