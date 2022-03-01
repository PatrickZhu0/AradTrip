using System;

namespace Protocol
{
	// Token: 0x020009BD RID: 2493
	[Protocol]
	public class AdminLoginVerifyRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FC7 RID: 28615 RVA: 0x001430B4 File Offset: 0x001414B4
		public uint GetMsgID()
		{
			return 200202U;
		}

		// Token: 0x06006FC8 RID: 28616 RVA: 0x001430BB File Offset: 0x001414BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FC9 RID: 28617 RVA: 0x001430C3 File Offset: 0x001414C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FCA RID: 28618 RVA: 0x001430CC File Offset: 0x001414CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.phoneBindRoleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.errMsg);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.dirSig);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.addr.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.replayAgentAddr);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isEncryptProtocol);
			BaseDLL.encode_int8(buffer, ref pos_, this.openBugly);
			BaseDLL.encode_uint32(buffer, ref pos_, this.voiceFlag);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.activityYearSortListUrl);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.openNewReconnectAlgo);
			BaseDLL.encode_int8(buffer, ref pos_, this.openNewReportFrameAlgo);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.webActivityUrl);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			byte[] str6 = StringHelper.StringToUTF8Bytes(this.commentServerAddr);
			BaseDLL.encode_string(buffer, ref pos_, str6, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.serverId);
			byte[] str7 = StringHelper.StringToUTF8Bytes(this.redPacketRankUrl);
			BaseDLL.encode_string(buffer, ref pos_, str7, (ushort)(buffer.Length - pos_));
			byte[] str8 = StringHelper.StringToUTF8Bytes(this.convertUrl);
			BaseDLL.encode_string(buffer, ref pos_, str8, (ushort)(buffer.Length - pos_));
			byte[] str9 = StringHelper.StringToUTF8Bytes(this.reportUrl);
			BaseDLL.encode_string(buffer, ref pos_, str9, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.battleUseTcp);
			byte[] str10 = StringHelper.StringToUTF8Bytes(this.writeQuestionnaireUrl);
			BaseDLL.encode_string(buffer, ref pos_, str10, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06006FCB RID: 28619 RVA: 0x00143298 File Offset: 0x00141698
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.phoneBindRoleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.errMsg = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.dirSig = StringHelper.BytesToString(array2);
			this.addr.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.replayAgentAddr = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isEncryptProtocol);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openBugly);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voiceFlag);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.activityYearSortListUrl = StringHelper.BytesToString(array4);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openNewReconnectAlgo);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openNewReportFrameAlgo);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array5 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[m]);
			}
			this.webActivityUrl = StringHelper.BytesToString(array5);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			byte[] array6 = new byte[(int)num6];
			for (int n = 0; n < (int)num6; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array6[n]);
			}
			this.commentServerAddr = StringHelper.BytesToString(array6);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.serverId);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			byte[] array7 = new byte[(int)num7];
			for (int num8 = 0; num8 < (int)num7; num8++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array7[num8]);
			}
			this.redPacketRankUrl = StringHelper.BytesToString(array7);
			ushort num9 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num9);
			byte[] array8 = new byte[(int)num9];
			for (int num10 = 0; num10 < (int)num9; num10++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array8[num10]);
			}
			this.convertUrl = StringHelper.BytesToString(array8);
			ushort num11 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num11);
			byte[] array9 = new byte[(int)num11];
			for (int num12 = 0; num12 < (int)num11; num12++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array9[num12]);
			}
			this.reportUrl = StringHelper.BytesToString(array9);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.battleUseTcp);
			ushort num13 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num13);
			byte[] array10 = new byte[(int)num13];
			for (int num14 = 0; num14 < (int)num13; num14++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array10[num14]);
			}
			this.writeQuestionnaireUrl = StringHelper.BytesToString(array10);
		}

		// Token: 0x06006FCC RID: 28620 RVA: 0x00143620 File Offset: 0x00141A20
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.phoneBindRoleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.errMsg);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.dirSig);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.addr.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.replayAgentAddr);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isEncryptProtocol);
			BaseDLL.encode_int8(buffer, ref pos_, this.openBugly);
			BaseDLL.encode_uint32(buffer, ref pos_, this.voiceFlag);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.activityYearSortListUrl);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.openNewReconnectAlgo);
			BaseDLL.encode_int8(buffer, ref pos_, this.openNewReportFrameAlgo);
			byte[] str5 = StringHelper.StringToUTF8Bytes(this.webActivityUrl);
			BaseDLL.encode_string(buffer, ref pos_, str5, (ushort)(buffer.Length - pos_));
			byte[] str6 = StringHelper.StringToUTF8Bytes(this.commentServerAddr);
			BaseDLL.encode_string(buffer, ref pos_, str6, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.serverId);
			byte[] str7 = StringHelper.StringToUTF8Bytes(this.redPacketRankUrl);
			BaseDLL.encode_string(buffer, ref pos_, str7, (ushort)(buffer.Length - pos_));
			byte[] str8 = StringHelper.StringToUTF8Bytes(this.convertUrl);
			BaseDLL.encode_string(buffer, ref pos_, str8, (ushort)(buffer.Length - pos_));
			byte[] str9 = StringHelper.StringToUTF8Bytes(this.reportUrl);
			BaseDLL.encode_string(buffer, ref pos_, str9, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.battleUseTcp);
			byte[] str10 = StringHelper.StringToUTF8Bytes(this.writeQuestionnaireUrl);
			BaseDLL.encode_string(buffer, ref pos_, str10, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06006FCD RID: 28621 RVA: 0x00143808 File Offset: 0x00141C08
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.phoneBindRoleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.errMsg = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.dirSig = StringHelper.BytesToString(array2);
			this.addr.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.replayAgentAddr = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isEncryptProtocol);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openBugly);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voiceFlag);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.activityYearSortListUrl = StringHelper.BytesToString(array4);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openNewReconnectAlgo);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openNewReportFrameAlgo);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array5 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array5[m]);
			}
			this.webActivityUrl = StringHelper.BytesToString(array5);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			byte[] array6 = new byte[(int)num6];
			for (int n = 0; n < (int)num6; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array6[n]);
			}
			this.commentServerAddr = StringHelper.BytesToString(array6);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.serverId);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			byte[] array7 = new byte[(int)num7];
			for (int num8 = 0; num8 < (int)num7; num8++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array7[num8]);
			}
			this.redPacketRankUrl = StringHelper.BytesToString(array7);
			ushort num9 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num9);
			byte[] array8 = new byte[(int)num9];
			for (int num10 = 0; num10 < (int)num9; num10++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array8[num10]);
			}
			this.convertUrl = StringHelper.BytesToString(array8);
			ushort num11 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num11);
			byte[] array9 = new byte[(int)num11];
			for (int num12 = 0; num12 < (int)num11; num12++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array9[num12]);
			}
			this.reportUrl = StringHelper.BytesToString(array9);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.battleUseTcp);
			ushort num13 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num13);
			byte[] array10 = new byte[(int)num13];
			for (int num14 = 0; num14 < (int)num13; num14++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array10[num14]);
			}
			this.writeQuestionnaireUrl = StringHelper.BytesToString(array10);
		}

		// Token: 0x06006FCE RID: 28622 RVA: 0x00143B90 File Offset: 0x00141F90
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.errMsg);
			num += 2 + array.Length;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.dirSig);
			num += 2 + array2.Length;
			num += this.addr.getLen();
			num += 4;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.replayAgentAddr);
			num += 2 + array3.Length;
			num++;
			num++;
			num += 4;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.activityYearSortListUrl);
			num += 2 + array4.Length;
			num++;
			num++;
			byte[] array5 = StringHelper.StringToUTF8Bytes(this.webActivityUrl);
			num += 2 + array5.Length;
			byte[] array6 = StringHelper.StringToUTF8Bytes(this.commentServerAddr);
			num += 2 + array6.Length;
			num += 4;
			byte[] array7 = StringHelper.StringToUTF8Bytes(this.redPacketRankUrl);
			num += 2 + array7.Length;
			byte[] array8 = StringHelper.StringToUTF8Bytes(this.convertUrl);
			num += 2 + array8.Length;
			byte[] array9 = StringHelper.StringToUTF8Bytes(this.reportUrl);
			num += 2 + array9.Length;
			num++;
			byte[] array10 = StringHelper.StringToUTF8Bytes(this.writeQuestionnaireUrl);
			return num + (2 + array10.Length);
		}

		// Token: 0x040032D5 RID: 13013
		public const uint MsgID = 200202U;

		// Token: 0x040032D6 RID: 13014
		public uint Sequence;

		// Token: 0x040032D7 RID: 13015
		public ulong phoneBindRoleId;

		// Token: 0x040032D8 RID: 13016
		public string errMsg;

		// Token: 0x040032D9 RID: 13017
		public uint accid;

		// Token: 0x040032DA RID: 13018
		public string dirSig;

		// Token: 0x040032DB RID: 13019
		public SockAddr addr = new SockAddr();

		// Token: 0x040032DC RID: 13020
		public uint result;

		// Token: 0x040032DD RID: 13021
		public string replayAgentAddr;

		// Token: 0x040032DE RID: 13022
		public byte isEncryptProtocol;

		// Token: 0x040032DF RID: 13023
		public byte openBugly;

		// Token: 0x040032E0 RID: 13024
		public uint voiceFlag;

		// Token: 0x040032E1 RID: 13025
		public string activityYearSortListUrl;

		// Token: 0x040032E2 RID: 13026
		public byte openNewReconnectAlgo;

		// Token: 0x040032E3 RID: 13027
		public byte openNewReportFrameAlgo;

		// Token: 0x040032E4 RID: 13028
		public string webActivityUrl;

		// Token: 0x040032E5 RID: 13029
		public string commentServerAddr;

		// Token: 0x040032E6 RID: 13030
		public uint serverId;

		// Token: 0x040032E7 RID: 13031
		public string redPacketRankUrl;

		// Token: 0x040032E8 RID: 13032
		public string convertUrl;

		// Token: 0x040032E9 RID: 13033
		public string reportUrl;

		// Token: 0x040032EA RID: 13034
		public byte battleUseTcp;

		// Token: 0x040032EB RID: 13035
		public string writeQuestionnaireUrl;
	}
}
