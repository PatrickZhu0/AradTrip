using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200055F RID: 1375
	public class PushExhibitionTable : IFlatbufferObject
	{
		// Token: 0x17001315 RID: 4885
		// (get) Token: 0x060046DF RID: 18143 RVA: 0x000E26B8 File Offset: 0x000E0AB8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060046E0 RID: 18144 RVA: 0x000E26C5 File Offset: 0x000E0AC5
		public static PushExhibitionTable GetRootAsPushExhibitionTable(ByteBuffer _bb)
		{
			return PushExhibitionTable.GetRootAsPushExhibitionTable(_bb, new PushExhibitionTable());
		}

		// Token: 0x060046E1 RID: 18145 RVA: 0x000E26D2 File Offset: 0x000E0AD2
		public static PushExhibitionTable GetRootAsPushExhibitionTable(ByteBuffer _bb, PushExhibitionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060046E2 RID: 18146 RVA: 0x000E26EE File Offset: 0x000E0AEE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060046E3 RID: 18147 RVA: 0x000E2708 File Offset: 0x000E0B08
		public PushExhibitionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001316 RID: 4886
		// (get) Token: 0x060046E4 RID: 18148 RVA: 0x000E2714 File Offset: 0x000E0B14
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001317 RID: 4887
		// (get) Token: 0x060046E5 RID: 18149 RVA: 0x000E2760 File Offset: 0x000E0B60
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046E6 RID: 18150 RVA: 0x000E27A2 File Offset: 0x000E0BA2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001318 RID: 4888
		// (get) Token: 0x060046E7 RID: 18151 RVA: 0x000E27B0 File Offset: 0x000E0BB0
		public int FinishLevel
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001319 RID: 4889
		// (get) Token: 0x060046E8 RID: 18152 RVA: 0x000E27FC File Offset: 0x000E0BFC
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046E9 RID: 18153 RVA: 0x000E283F File Offset: 0x000E0C3F
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700131A RID: 4890
		// (get) Token: 0x060046EA RID: 18154 RVA: 0x000E2850 File Offset: 0x000E0C50
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046EB RID: 18155 RVA: 0x000E2893 File Offset: 0x000E0C93
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700131B RID: 4891
		// (get) Token: 0x060046EC RID: 18156 RVA: 0x000E28A4 File Offset: 0x000E0CA4
		public int StartTime
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700131C RID: 4892
		// (get) Token: 0x060046ED RID: 18157 RVA: 0x000E28F0 File Offset: 0x000E0CF0
		public int EndTime
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700131D RID: 4893
		// (get) Token: 0x060046EE RID: 18158 RVA: 0x000E293C File Offset: 0x000E0D3C
		public int AfterStartServer
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700131E RID: 4894
		// (get) Token: 0x060046EF RID: 18159 RVA: 0x000E2988 File Offset: 0x000E0D88
		public int AfterStartServerDays
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700131F RID: 4895
		// (get) Token: 0x060046F0 RID: 18160 RVA: 0x000E29D4 File Offset: 0x000E0DD4
		public string OpenInterval
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046F1 RID: 18161 RVA: 0x000E2A17 File Offset: 0x000E0E17
		public ArraySegment<byte>? GetOpenIntervalBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17001320 RID: 4896
		// (get) Token: 0x060046F2 RID: 18162 RVA: 0x000E2A28 File Offset: 0x000E0E28
		public string CloseInterval
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046F3 RID: 18163 RVA: 0x000E2A6B File Offset: 0x000E0E6B
		public ArraySegment<byte>? GetCloseIntervalBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17001321 RID: 4897
		// (get) Token: 0x060046F4 RID: 18164 RVA: 0x000E2A7C File Offset: 0x000E0E7C
		public string LoadingIcon
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046F5 RID: 18165 RVA: 0x000E2ABF File Offset: 0x000E0EBF
		public ArraySegment<byte>? GetLoadingIconBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17001322 RID: 4898
		// (get) Token: 0x060046F6 RID: 18166 RVA: 0x000E2AD0 File Offset: 0x000E0ED0
		public int SortNum
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001323 RID: 4899
		// (get) Token: 0x060046F7 RID: 18167 RVA: 0x000E2B1C File Offset: 0x000E0F1C
		public int IsShowTime
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001324 RID: 4900
		// (get) Token: 0x060046F8 RID: 18168 RVA: 0x000E2B68 File Offset: 0x000E0F68
		public int IsSetNative
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-7804209 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060046F9 RID: 18169 RVA: 0x000E2BB4 File Offset: 0x000E0FB4
		public static Offset<PushExhibitionTable> CreatePushExhibitionTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int FinishLevel = 0, StringOffset IconPathOffset = default(StringOffset), StringOffset LinkInfoOffset = default(StringOffset), int StartTime = 0, int EndTime = 0, int AfterStartServer = 0, int AfterStartServerDays = 0, StringOffset OpenIntervalOffset = default(StringOffset), StringOffset CloseIntervalOffset = default(StringOffset), StringOffset LoadingIconOffset = default(StringOffset), int SortNum = 0, int IsShowTime = 0, int IsSetNative = 0)
		{
			builder.StartObject(15);
			PushExhibitionTable.AddIsSetNative(builder, IsSetNative);
			PushExhibitionTable.AddIsShowTime(builder, IsShowTime);
			PushExhibitionTable.AddSortNum(builder, SortNum);
			PushExhibitionTable.AddLoadingIcon(builder, LoadingIconOffset);
			PushExhibitionTable.AddCloseInterval(builder, CloseIntervalOffset);
			PushExhibitionTable.AddOpenInterval(builder, OpenIntervalOffset);
			PushExhibitionTable.AddAfterStartServerDays(builder, AfterStartServerDays);
			PushExhibitionTable.AddAfterStartServer(builder, AfterStartServer);
			PushExhibitionTable.AddEndTime(builder, EndTime);
			PushExhibitionTable.AddStartTime(builder, StartTime);
			PushExhibitionTable.AddLinkInfo(builder, LinkInfoOffset);
			PushExhibitionTable.AddIconPath(builder, IconPathOffset);
			PushExhibitionTable.AddFinishLevel(builder, FinishLevel);
			PushExhibitionTable.AddName(builder, NameOffset);
			PushExhibitionTable.AddID(builder, ID);
			return PushExhibitionTable.EndPushExhibitionTable(builder);
		}

		// Token: 0x060046FA RID: 18170 RVA: 0x000E2C44 File Offset: 0x000E1044
		public static void StartPushExhibitionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(15);
		}

		// Token: 0x060046FB RID: 18171 RVA: 0x000E2C4E File Offset: 0x000E104E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060046FC RID: 18172 RVA: 0x000E2C59 File Offset: 0x000E1059
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060046FD RID: 18173 RVA: 0x000E2C6A File Offset: 0x000E106A
		public static void AddFinishLevel(FlatBufferBuilder builder, int FinishLevel)
		{
			builder.AddInt(2, FinishLevel, 0);
		}

		// Token: 0x060046FE RID: 18174 RVA: 0x000E2C75 File Offset: 0x000E1075
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(3, IconPathOffset.Value, 0);
		}

		// Token: 0x060046FF RID: 18175 RVA: 0x000E2C86 File Offset: 0x000E1086
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(4, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06004700 RID: 18176 RVA: 0x000E2C97 File Offset: 0x000E1097
		public static void AddStartTime(FlatBufferBuilder builder, int StartTime)
		{
			builder.AddInt(5, StartTime, 0);
		}

		// Token: 0x06004701 RID: 18177 RVA: 0x000E2CA2 File Offset: 0x000E10A2
		public static void AddEndTime(FlatBufferBuilder builder, int EndTime)
		{
			builder.AddInt(6, EndTime, 0);
		}

		// Token: 0x06004702 RID: 18178 RVA: 0x000E2CAD File Offset: 0x000E10AD
		public static void AddAfterStartServer(FlatBufferBuilder builder, int AfterStartServer)
		{
			builder.AddInt(7, AfterStartServer, 0);
		}

		// Token: 0x06004703 RID: 18179 RVA: 0x000E2CB8 File Offset: 0x000E10B8
		public static void AddAfterStartServerDays(FlatBufferBuilder builder, int AfterStartServerDays)
		{
			builder.AddInt(8, AfterStartServerDays, 0);
		}

		// Token: 0x06004704 RID: 18180 RVA: 0x000E2CC3 File Offset: 0x000E10C3
		public static void AddOpenInterval(FlatBufferBuilder builder, StringOffset OpenIntervalOffset)
		{
			builder.AddOffset(9, OpenIntervalOffset.Value, 0);
		}

		// Token: 0x06004705 RID: 18181 RVA: 0x000E2CD5 File Offset: 0x000E10D5
		public static void AddCloseInterval(FlatBufferBuilder builder, StringOffset CloseIntervalOffset)
		{
			builder.AddOffset(10, CloseIntervalOffset.Value, 0);
		}

		// Token: 0x06004706 RID: 18182 RVA: 0x000E2CE7 File Offset: 0x000E10E7
		public static void AddLoadingIcon(FlatBufferBuilder builder, StringOffset LoadingIconOffset)
		{
			builder.AddOffset(11, LoadingIconOffset.Value, 0);
		}

		// Token: 0x06004707 RID: 18183 RVA: 0x000E2CF9 File Offset: 0x000E10F9
		public static void AddSortNum(FlatBufferBuilder builder, int SortNum)
		{
			builder.AddInt(12, SortNum, 0);
		}

		// Token: 0x06004708 RID: 18184 RVA: 0x000E2D05 File Offset: 0x000E1105
		public static void AddIsShowTime(FlatBufferBuilder builder, int IsShowTime)
		{
			builder.AddInt(13, IsShowTime, 0);
		}

		// Token: 0x06004709 RID: 18185 RVA: 0x000E2D11 File Offset: 0x000E1111
		public static void AddIsSetNative(FlatBufferBuilder builder, int IsSetNative)
		{
			builder.AddInt(14, IsSetNative, 0);
		}

		// Token: 0x0600470A RID: 18186 RVA: 0x000E2D20 File Offset: 0x000E1120
		public static Offset<PushExhibitionTable> EndPushExhibitionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PushExhibitionTable>(value);
		}

		// Token: 0x0600470B RID: 18187 RVA: 0x000E2D3A File Offset: 0x000E113A
		public static void FinishPushExhibitionTableBuffer(FlatBufferBuilder builder, Offset<PushExhibitionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A30 RID: 6704
		private Table __p = new Table();

		// Token: 0x02000560 RID: 1376
		public enum eCrypt
		{
			// Token: 0x04001A32 RID: 6706
			code = -7804209
		}
	}
}
