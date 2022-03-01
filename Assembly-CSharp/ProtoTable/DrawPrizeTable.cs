using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000384 RID: 900
	public class DrawPrizeTable : IFlatbufferObject
	{
		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06002685 RID: 9861 RVA: 0x000959C8 File Offset: 0x00093DC8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002686 RID: 9862 RVA: 0x000959D5 File Offset: 0x00093DD5
		public static DrawPrizeTable GetRootAsDrawPrizeTable(ByteBuffer _bb)
		{
			return DrawPrizeTable.GetRootAsDrawPrizeTable(_bb, new DrawPrizeTable());
		}

		// Token: 0x06002687 RID: 9863 RVA: 0x000959E2 File Offset: 0x00093DE2
		public static DrawPrizeTable GetRootAsDrawPrizeTable(ByteBuffer _bb, DrawPrizeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002688 RID: 9864 RVA: 0x000959FE File Offset: 0x00093DFE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002689 RID: 9865 RVA: 0x00095A18 File Offset: 0x00093E18
		public DrawPrizeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x0600268A RID: 9866 RVA: 0x00095A24 File Offset: 0x00093E24
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x0600268B RID: 9867 RVA: 0x00095A70 File Offset: 0x00093E70
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600268C RID: 9868 RVA: 0x00095AB2 File Offset: 0x00093EB2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x0600268D RID: 9869 RVA: 0x00095AC0 File Offset: 0x00093EC0
		public int ActivityId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x0600268E RID: 9870 RVA: 0x00095B0C File Offset: 0x00093F0C
		public int OpActivityType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x0600268F RID: 9871 RVA: 0x00095B58 File Offset: 0x00093F58
		public int Type
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x06002690 RID: 9872 RVA: 0x00095BA4 File Offset: 0x00093FA4
		public string ChannelName
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002691 RID: 9873 RVA: 0x00095BE7 File Offset: 0x00093FE7
		public ArraySegment<byte>? GetChannelNameBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x06002692 RID: 9874 RVA: 0x00095BF8 File Offset: 0x00093FF8
		public int Open
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x06002693 RID: 9875 RVA: 0x00095C44 File Offset: 0x00094044
		public int BaseCount
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x06002694 RID: 9876 RVA: 0x00095C90 File Offset: 0x00094090
		public int ContinuousDays
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x06002695 RID: 9877 RVA: 0x00095CDC File Offset: 0x000940DC
		public int RewardCount
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x06002696 RID: 9878 RVA: 0x00095D28 File Offset: 0x00094128
		public int RefreshInterval
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x06002697 RID: 9879 RVA: 0x00095D74 File Offset: 0x00094174
		public int RefreshTime
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1049420298 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x06002698 RID: 9880 RVA: 0x00095DC0 File Offset: 0x000941C0
		public string CountKey
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002699 RID: 9881 RVA: 0x00095E03 File Offset: 0x00094203
		public ArraySegment<byte>? GetCountKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x0600269A RID: 9882 RVA: 0x00095E14 File Offset: 0x00094214
		public string AllCountKey
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600269B RID: 9883 RVA: 0x00095E57 File Offset: 0x00094257
		public ArraySegment<byte>? GetAllCountKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x0600269C RID: 9884 RVA: 0x00095E68 File Offset: 0x00094268
		public string ContinuousKey
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600269D RID: 9885 RVA: 0x00095EAB File Offset: 0x000942AB
		public ArraySegment<byte>? GetContinuousKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x0600269E RID: 9886 RVA: 0x00095EBC File Offset: 0x000942BC
		public string RestCountKey
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600269F RID: 9887 RVA: 0x00095EFF File Offset: 0x000942FF
		public ArraySegment<byte>? GetRestCountKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x060026A0 RID: 9888 RVA: 0x00095F10 File Offset: 0x00094310
		public string RewardIDKey
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026A1 RID: 9889 RVA: 0x00095F53 File Offset: 0x00094353
		public ArraySegment<byte>? GetRewardIDKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x060026A2 RID: 9890 RVA: 0x00095F64 File Offset: 0x00094364
		public string GetCountKey
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026A3 RID: 9891 RVA: 0x00095FA7 File Offset: 0x000943A7
		public ArraySegment<byte>? GetGetCountKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x060026A4 RID: 9892 RVA: 0x00095FB8 File Offset: 0x000943B8
		public DrawPrizeTable.eRaffleTicketType RaffleTicketType
		{
			get
			{
				int num = this.__p.__offset(40);
				return (DrawPrizeTable.eRaffleTicketType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x060026A5 RID: 9893 RVA: 0x00095FFC File Offset: 0x000943FC
		public string Prams
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026A6 RID: 9894 RVA: 0x0009603F File Offset: 0x0009443F
		public ArraySegment<byte>? GetPramsBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x060026A7 RID: 9895 RVA: 0x00096050 File Offset: 0x00094450
		public string RaffleTicketIconPath
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026A8 RID: 9896 RVA: 0x00096093 File Offset: 0x00094493
		public ArraySegment<byte>? GetRaffleTicketIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x060026A9 RID: 9897 RVA: 0x000960A4 File Offset: 0x000944A4
		public string RaffleTicketNickName
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026AA RID: 9898 RVA: 0x000960E7 File Offset: 0x000944E7
		public ArraySegment<byte>? GetRaffleTicketNickNameBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x060026AB RID: 9899 RVA: 0x000960F8 File Offset: 0x000944F8
		public static Offset<DrawPrizeTable> CreateDrawPrizeTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int ActivityId = 0, int OpActivityType = 0, int Type = 0, StringOffset ChannelNameOffset = default(StringOffset), int Open = 0, int BaseCount = 0, int ContinuousDays = 0, int RewardCount = 0, int RefreshInterval = 0, int RefreshTime = 0, StringOffset CountKeyOffset = default(StringOffset), StringOffset AllCountKeyOffset = default(StringOffset), StringOffset ContinuousKeyOffset = default(StringOffset), StringOffset RestCountKeyOffset = default(StringOffset), StringOffset RewardIDKeyOffset = default(StringOffset), StringOffset GetCountKeyOffset = default(StringOffset), DrawPrizeTable.eRaffleTicketType RaffleTicketType = DrawPrizeTable.eRaffleTicketType.RaffleTicketType_None, StringOffset PramsOffset = default(StringOffset), StringOffset RaffleTicketIconPathOffset = default(StringOffset), StringOffset RaffleTicketNickNameOffset = default(StringOffset))
		{
			builder.StartObject(22);
			DrawPrizeTable.AddRaffleTicketNickName(builder, RaffleTicketNickNameOffset);
			DrawPrizeTable.AddRaffleTicketIconPath(builder, RaffleTicketIconPathOffset);
			DrawPrizeTable.AddPrams(builder, PramsOffset);
			DrawPrizeTable.AddRaffleTicketType(builder, RaffleTicketType);
			DrawPrizeTable.AddGetCountKey(builder, GetCountKeyOffset);
			DrawPrizeTable.AddRewardIDKey(builder, RewardIDKeyOffset);
			DrawPrizeTable.AddRestCountKey(builder, RestCountKeyOffset);
			DrawPrizeTable.AddContinuousKey(builder, ContinuousKeyOffset);
			DrawPrizeTable.AddAllCountKey(builder, AllCountKeyOffset);
			DrawPrizeTable.AddCountKey(builder, CountKeyOffset);
			DrawPrizeTable.AddRefreshTime(builder, RefreshTime);
			DrawPrizeTable.AddRefreshInterval(builder, RefreshInterval);
			DrawPrizeTable.AddRewardCount(builder, RewardCount);
			DrawPrizeTable.AddContinuousDays(builder, ContinuousDays);
			DrawPrizeTable.AddBaseCount(builder, BaseCount);
			DrawPrizeTable.AddOpen(builder, Open);
			DrawPrizeTable.AddChannelName(builder, ChannelNameOffset);
			DrawPrizeTable.AddType(builder, Type);
			DrawPrizeTable.AddOpActivityType(builder, OpActivityType);
			DrawPrizeTable.AddActivityId(builder, ActivityId);
			DrawPrizeTable.AddName(builder, NameOffset);
			DrawPrizeTable.AddID(builder, ID);
			return DrawPrizeTable.EndDrawPrizeTable(builder);
		}

		// Token: 0x060026AC RID: 9900 RVA: 0x000961C0 File Offset: 0x000945C0
		public static void StartDrawPrizeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(22);
		}

		// Token: 0x060026AD RID: 9901 RVA: 0x000961CA File Offset: 0x000945CA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060026AE RID: 9902 RVA: 0x000961D5 File Offset: 0x000945D5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060026AF RID: 9903 RVA: 0x000961E6 File Offset: 0x000945E6
		public static void AddActivityId(FlatBufferBuilder builder, int ActivityId)
		{
			builder.AddInt(2, ActivityId, 0);
		}

		// Token: 0x060026B0 RID: 9904 RVA: 0x000961F1 File Offset: 0x000945F1
		public static void AddOpActivityType(FlatBufferBuilder builder, int OpActivityType)
		{
			builder.AddInt(3, OpActivityType, 0);
		}

		// Token: 0x060026B1 RID: 9905 RVA: 0x000961FC File Offset: 0x000945FC
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(4, Type, 0);
		}

		// Token: 0x060026B2 RID: 9906 RVA: 0x00096207 File Offset: 0x00094607
		public static void AddChannelName(FlatBufferBuilder builder, StringOffset ChannelNameOffset)
		{
			builder.AddOffset(5, ChannelNameOffset.Value, 0);
		}

		// Token: 0x060026B3 RID: 9907 RVA: 0x00096218 File Offset: 0x00094618
		public static void AddOpen(FlatBufferBuilder builder, int Open)
		{
			builder.AddInt(6, Open, 0);
		}

		// Token: 0x060026B4 RID: 9908 RVA: 0x00096223 File Offset: 0x00094623
		public static void AddBaseCount(FlatBufferBuilder builder, int BaseCount)
		{
			builder.AddInt(7, BaseCount, 0);
		}

		// Token: 0x060026B5 RID: 9909 RVA: 0x0009622E File Offset: 0x0009462E
		public static void AddContinuousDays(FlatBufferBuilder builder, int ContinuousDays)
		{
			builder.AddInt(8, ContinuousDays, 0);
		}

		// Token: 0x060026B6 RID: 9910 RVA: 0x00096239 File Offset: 0x00094639
		public static void AddRewardCount(FlatBufferBuilder builder, int RewardCount)
		{
			builder.AddInt(9, RewardCount, 0);
		}

		// Token: 0x060026B7 RID: 9911 RVA: 0x00096245 File Offset: 0x00094645
		public static void AddRefreshInterval(FlatBufferBuilder builder, int RefreshInterval)
		{
			builder.AddInt(10, RefreshInterval, 0);
		}

		// Token: 0x060026B8 RID: 9912 RVA: 0x00096251 File Offset: 0x00094651
		public static void AddRefreshTime(FlatBufferBuilder builder, int RefreshTime)
		{
			builder.AddInt(11, RefreshTime, 0);
		}

		// Token: 0x060026B9 RID: 9913 RVA: 0x0009625D File Offset: 0x0009465D
		public static void AddCountKey(FlatBufferBuilder builder, StringOffset CountKeyOffset)
		{
			builder.AddOffset(12, CountKeyOffset.Value, 0);
		}

		// Token: 0x060026BA RID: 9914 RVA: 0x0009626F File Offset: 0x0009466F
		public static void AddAllCountKey(FlatBufferBuilder builder, StringOffset AllCountKeyOffset)
		{
			builder.AddOffset(13, AllCountKeyOffset.Value, 0);
		}

		// Token: 0x060026BB RID: 9915 RVA: 0x00096281 File Offset: 0x00094681
		public static void AddContinuousKey(FlatBufferBuilder builder, StringOffset ContinuousKeyOffset)
		{
			builder.AddOffset(14, ContinuousKeyOffset.Value, 0);
		}

		// Token: 0x060026BC RID: 9916 RVA: 0x00096293 File Offset: 0x00094693
		public static void AddRestCountKey(FlatBufferBuilder builder, StringOffset RestCountKeyOffset)
		{
			builder.AddOffset(15, RestCountKeyOffset.Value, 0);
		}

		// Token: 0x060026BD RID: 9917 RVA: 0x000962A5 File Offset: 0x000946A5
		public static void AddRewardIDKey(FlatBufferBuilder builder, StringOffset RewardIDKeyOffset)
		{
			builder.AddOffset(16, RewardIDKeyOffset.Value, 0);
		}

		// Token: 0x060026BE RID: 9918 RVA: 0x000962B7 File Offset: 0x000946B7
		public static void AddGetCountKey(FlatBufferBuilder builder, StringOffset GetCountKeyOffset)
		{
			builder.AddOffset(17, GetCountKeyOffset.Value, 0);
		}

		// Token: 0x060026BF RID: 9919 RVA: 0x000962C9 File Offset: 0x000946C9
		public static void AddRaffleTicketType(FlatBufferBuilder builder, DrawPrizeTable.eRaffleTicketType RaffleTicketType)
		{
			builder.AddInt(18, (int)RaffleTicketType, 0);
		}

		// Token: 0x060026C0 RID: 9920 RVA: 0x000962D5 File Offset: 0x000946D5
		public static void AddPrams(FlatBufferBuilder builder, StringOffset PramsOffset)
		{
			builder.AddOffset(19, PramsOffset.Value, 0);
		}

		// Token: 0x060026C1 RID: 9921 RVA: 0x000962E7 File Offset: 0x000946E7
		public static void AddRaffleTicketIconPath(FlatBufferBuilder builder, StringOffset RaffleTicketIconPathOffset)
		{
			builder.AddOffset(20, RaffleTicketIconPathOffset.Value, 0);
		}

		// Token: 0x060026C2 RID: 9922 RVA: 0x000962F9 File Offset: 0x000946F9
		public static void AddRaffleTicketNickName(FlatBufferBuilder builder, StringOffset RaffleTicketNickNameOffset)
		{
			builder.AddOffset(21, RaffleTicketNickNameOffset.Value, 0);
		}

		// Token: 0x060026C3 RID: 9923 RVA: 0x0009630C File Offset: 0x0009470C
		public static Offset<DrawPrizeTable> EndDrawPrizeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DrawPrizeTable>(value);
		}

		// Token: 0x060026C4 RID: 9924 RVA: 0x00096326 File Offset: 0x00094726
		public static void FinishDrawPrizeTableBuffer(FlatBufferBuilder builder, Offset<DrawPrizeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011A8 RID: 4520
		private Table __p = new Table();

		// Token: 0x02000385 RID: 901
		public enum eRaffleTicketType
		{
			// Token: 0x040011AA RID: 4522
			RaffleTicketType_None,
			// Token: 0x040011AB RID: 4523
			ST_PRIMARY_RAFFLE_TICKETS = 74,
			// Token: 0x040011AC RID: 4524
			ST_MIDDLE_RAFFLE_TICKETS,
			// Token: 0x040011AD RID: 4525
			ST_SENIOR_RAFFLE_TICKETS
		}

		// Token: 0x02000386 RID: 902
		public enum eCrypt
		{
			// Token: 0x040011AF RID: 4527
			code = 1049420298
		}
	}
}
