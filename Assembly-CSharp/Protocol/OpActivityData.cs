using System;

namespace Protocol
{
	// Token: 0x02000A31 RID: 2609
	public class OpActivityData : IProtocolStream
	{
		// Token: 0x06007327 RID: 29479 RVA: 0x0014D8EC File Offset: 0x0014BCEC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tmpType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.prepareTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.desc);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.ruleDesc);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.circleType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.taskDesc);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.parm);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.parm2.Length);
			for (int j = 0; j < this.parm2.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.parm2[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevelLimit);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.logoDesc);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			byte[] str6 = StringHelper.StringToUTF8Bytes(this.countParam);
			BaseDLL.encode_string(buffer, ref pos_, str6, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.parm3.Length);
			for (int k = 0; k < this.parm3.Length; k++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.parm3[k]);
			}
			byte[] str7 = StringHelper.StringToUTF8Bytes(this.prefabPath);
			BaseDLL.encode_string(buffer, ref pos_, str7, (ushort)(buffer.Length - pos_));
			byte[] str8 = StringHelper.StringToUTF8Bytes(this.logoPath);
			BaseDLL.encode_string(buffer, ref pos_, str8, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.strParams.Length);
			for (int l = 0; l < this.strParams.Length; l++)
			{
				byte[] str9 = StringHelper.StringToUTF8Bytes(this.strParams[l]);
				BaseDLL.encode_string(buffer, ref pos_, str9, (ushort)(buffer.Length - pos_));
			}
		}

		// Token: 0x06007328 RID: 29480 RVA: 0x0014DB78 File Offset: 0x0014BF78
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tmpType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.prepareTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.desc = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.ruleDesc = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.circleType);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.tasks = new OpActTaskData[(int)num4];
			for (int l = 0; l < this.tasks.Length; l++)
			{
				this.tasks[l] = new OpActTaskData();
				this.tasks[l].decode(buffer, ref pos_);
			}
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array4 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[m]);
			}
			this.taskDesc = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.parm);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.parm2 = new uint[(int)num6];
			for (int n = 0; n < this.parm2.Length; n++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.parm2[n]);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevelLimit);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			byte[] array5 = new byte[(int)num7];
			for (int num8 = 0; num8 < (int)num7; num8++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[num8]);
			}
			this.logoDesc = StringHelper.BytesToString(array5);
			ushort num9 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num9);
			byte[] array6 = new byte[(int)num9];
			for (int num10 = 0; num10 < (int)num9; num10++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array6[num10]);
			}
			this.countParam = StringHelper.BytesToString(array6);
			ushort num11 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num11);
			this.parm3 = new uint[(int)num11];
			for (int num12 = 0; num12 < this.parm3.Length; num12++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.parm3[num12]);
			}
			ushort num13 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num13);
			byte[] array7 = new byte[(int)num13];
			for (int num14 = 0; num14 < (int)num13; num14++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array7[num14]);
			}
			this.prefabPath = StringHelper.BytesToString(array7);
			ushort num15 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num15);
			byte[] array8 = new byte[(int)num15];
			for (int num16 = 0; num16 < (int)num15; num16++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array8[num16]);
			}
			this.logoPath = StringHelper.BytesToString(array8);
			ushort num17 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num17);
			this.strParams = new string[(int)num17];
			for (int num18 = 0; num18 < this.strParams.Length; num18++)
			{
				ushort num19 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num19);
				byte[] array9 = new byte[(int)num19];
				for (int num20 = 0; num20 < (int)num19; num20++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array9[num20]);
				}
				this.strParams[num18] = StringHelper.BytesToString(array9);
			}
		}

		// Token: 0x06007329 RID: 29481 RVA: 0x0014DFD0 File Offset: 0x0014C3D0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
			BaseDLL.encode_uint32(buffer, ref pos_, this.tmpType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.prepareTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.desc);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.ruleDesc);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.circleType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tasks.Length);
			for (int i = 0; i < this.tasks.Length; i++)
			{
				this.tasks[i].encode(buffer, ref pos_);
			}
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.taskDesc);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.parm);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.parm2.Length);
			for (int j = 0; j < this.parm2.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.parm2[j]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevelLimit);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.logoDesc);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			byte[] str6 = StringHelper.StringToUTF8Bytes(this.countParam);
			BaseDLL.encode_string(buffer, ref pos_, str6, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.parm3.Length);
			for (int k = 0; k < this.parm3.Length; k++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.parm3[k]);
			}
			byte[] str7 = StringHelper.StringToUTF8Bytes(this.prefabPath);
			BaseDLL.encode_string(buffer, ref pos_, str7, (ushort)(buffer.Length - pos_));
			byte[] str8 = StringHelper.StringToUTF8Bytes(this.logoPath);
			BaseDLL.encode_string(buffer, ref pos_, str8, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.strParams.Length);
			for (int l = 0; l < this.strParams.Length; l++)
			{
				byte[] str9 = StringHelper.StringToUTF8Bytes(this.strParams[l]);
				BaseDLL.encode_string(buffer, ref pos_, str9, (ushort)(buffer.Length - pos_));
			}
		}

		// Token: 0x0600732A RID: 29482 RVA: 0x0014E274 File Offset: 0x0014C674
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.tmpType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.prepareTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.desc = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.ruleDesc = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.circleType);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.tasks = new OpActTaskData[(int)num4];
			for (int l = 0; l < this.tasks.Length; l++)
			{
				this.tasks[l] = new OpActTaskData();
				this.tasks[l].decode(buffer, ref pos_);
			}
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array4 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[m]);
			}
			this.taskDesc = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.parm);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.parm2 = new uint[(int)num6];
			for (int n = 0; n < this.parm2.Length; n++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.parm2[n]);
			}
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevelLimit);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			byte[] array5 = new byte[(int)num7];
			for (int num8 = 0; num8 < (int)num7; num8++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[num8]);
			}
			this.logoDesc = StringHelper.BytesToString(array5);
			ushort num9 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num9);
			byte[] array6 = new byte[(int)num9];
			for (int num10 = 0; num10 < (int)num9; num10++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array6[num10]);
			}
			this.countParam = StringHelper.BytesToString(array6);
			ushort num11 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num11);
			this.parm3 = new uint[(int)num11];
			for (int num12 = 0; num12 < this.parm3.Length; num12++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.parm3[num12]);
			}
			ushort num13 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num13);
			byte[] array7 = new byte[(int)num13];
			for (int num14 = 0; num14 < (int)num13; num14++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array7[num14]);
			}
			this.prefabPath = StringHelper.BytesToString(array7);
			ushort num15 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num15);
			byte[] array8 = new byte[(int)num15];
			for (int num16 = 0; num16 < (int)num15; num16++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array8[num16]);
			}
			this.logoPath = StringHelper.BytesToString(array8);
			ushort num17 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num17);
			this.strParams = new string[(int)num17];
			for (int num18 = 0; num18 < this.strParams.Length; num18++)
			{
				ushort num19 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num19);
				byte[] array9 = new byte[(int)num19];
				for (int num20 = 0; num20 < (int)num19; num20++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array9[num20]);
				}
				this.strParams[num18] = StringHelper.BytesToString(array9);
			}
		}

		// Token: 0x0600732B RID: 29483 RVA: 0x0014E6CC File Offset: 0x0014CACC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 4;
			num += 4;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.desc);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.ruleDesc);
			num += 2 + array3.Length;
			num++;
			num += 2;
			for (int i = 0; i < this.tasks.Length; i++)
			{
				num += this.tasks[i].getLen();
			}
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.taskDesc);
			num += 2 + array4.Length;
			num += 4;
			num += 2 + 4 * this.parm2.Length;
			num += 2;
			byte[] array5 = StringHelper.StringToUTF8Bytes(this.logoDesc);
			num += 2 + array5.Length;
			byte[] array6 = StringHelper.StringToUTF8Bytes(this.countParam);
			num += 2 + array6.Length;
			num += 2 + 4 * this.parm3.Length;
			byte[] array7 = StringHelper.StringToUTF8Bytes(this.prefabPath);
			num += 2 + array7.Length;
			byte[] array8 = StringHelper.StringToUTF8Bytes(this.logoPath);
			num += 2 + array8.Length;
			num += 2;
			for (int j = 0; j < this.strParams.Length; j++)
			{
				byte[] array9 = StringHelper.StringToUTF8Bytes(this.strParams[j]);
				num += 2 + array9.Length;
			}
			return num;
		}

		// Token: 0x04003564 RID: 13668
		public uint dataId;

		// Token: 0x04003565 RID: 13669
		public byte state;

		// Token: 0x04003566 RID: 13670
		public uint tmpType;

		// Token: 0x04003567 RID: 13671
		public string name;

		// Token: 0x04003568 RID: 13672
		public byte tag;

		// Token: 0x04003569 RID: 13673
		public uint prepareTime;

		// Token: 0x0400356A RID: 13674
		public uint startTime;

		// Token: 0x0400356B RID: 13675
		public uint endTime;

		// Token: 0x0400356C RID: 13676
		public string desc;

		// Token: 0x0400356D RID: 13677
		public string ruleDesc;

		// Token: 0x0400356E RID: 13678
		public byte circleType;

		// Token: 0x0400356F RID: 13679
		public OpActTaskData[] tasks = new OpActTaskData[0];

		// Token: 0x04003570 RID: 13680
		public string taskDesc;

		// Token: 0x04003571 RID: 13681
		public uint parm;

		// Token: 0x04003572 RID: 13682
		public uint[] parm2 = new uint[0];

		// Token: 0x04003573 RID: 13683
		public ushort playerLevelLimit;

		// Token: 0x04003574 RID: 13684
		public string logoDesc;

		// Token: 0x04003575 RID: 13685
		public string countParam;

		// Token: 0x04003576 RID: 13686
		public uint[] parm3 = new uint[0];

		// Token: 0x04003577 RID: 13687
		public string prefabPath;

		// Token: 0x04003578 RID: 13688
		public string logoPath;

		// Token: 0x04003579 RID: 13689
		public string[] strParams = new string[0];
	}
}
