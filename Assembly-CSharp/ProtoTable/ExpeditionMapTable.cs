using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000421 RID: 1057
	public class ExpeditionMapTable : IFlatbufferObject
	{
		// Token: 0x17000C48 RID: 3144
		// (get) Token: 0x0600325E RID: 12894 RVA: 0x000B240C File Offset: 0x000B080C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600325F RID: 12895 RVA: 0x000B2419 File Offset: 0x000B0819
		public static ExpeditionMapTable GetRootAsExpeditionMapTable(ByteBuffer _bb)
		{
			return ExpeditionMapTable.GetRootAsExpeditionMapTable(_bb, new ExpeditionMapTable());
		}

		// Token: 0x06003260 RID: 12896 RVA: 0x000B2426 File Offset: 0x000B0826
		public static ExpeditionMapTable GetRootAsExpeditionMapTable(ByteBuffer _bb, ExpeditionMapTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003261 RID: 12897 RVA: 0x000B2442 File Offset: 0x000B0842
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003262 RID: 12898 RVA: 0x000B245C File Offset: 0x000B085C
		public ExpeditionMapTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C49 RID: 3145
		// (get) Token: 0x06003263 RID: 12899 RVA: 0x000B2468 File Offset: 0x000B0868
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1661111065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C4A RID: 3146
		// (get) Token: 0x06003264 RID: 12900 RVA: 0x000B24B4 File Offset: 0x000B08B4
		public string MapName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003265 RID: 12901 RVA: 0x000B24F6 File Offset: 0x000B08F6
		public ArraySegment<byte>? GetMapNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000C4B RID: 3147
		// (get) Token: 0x06003266 RID: 12902 RVA: 0x000B2504 File Offset: 0x000B0904
		public int PlayerLevelLimit
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1661111065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C4C RID: 3148
		// (get) Token: 0x06003267 RID: 12903 RVA: 0x000B2550 File Offset: 0x000B0950
		public int AdventureTeamLevelLimit
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1661111065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C4D RID: 3149
		// (get) Token: 0x06003268 RID: 12904 RVA: 0x000B259C File Offset: 0x000B099C
		public int RolesCapacity
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1661111065 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C4E RID: 3150
		// (get) Token: 0x06003269 RID: 12905 RVA: 0x000B25E8 File Offset: 0x000B09E8
		public string ExpeditionTime
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600326A RID: 12906 RVA: 0x000B262B File Offset: 0x000B0A2B
		public ArraySegment<byte>? GetExpeditionTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000C4F RID: 3151
		// (get) Token: 0x0600326B RID: 12907 RVA: 0x000B263C File Offset: 0x000B0A3C
		public string BackgroundPath
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600326C RID: 12908 RVA: 0x000B267F File Offset: 0x000B0A7F
		public ArraySegment<byte>? GetBackgroundPathBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000C50 RID: 3152
		// (get) Token: 0x0600326D RID: 12909 RVA: 0x000B2690 File Offset: 0x000B0A90
		public string MiniMapPath
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600326E RID: 12910 RVA: 0x000B26D3 File Offset: 0x000B0AD3
		public ArraySegment<byte>? GetMiniMapPathBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x0600326F RID: 12911 RVA: 0x000B26E4 File Offset: 0x000B0AE4
		public static Offset<ExpeditionMapTable> CreateExpeditionMapTable(FlatBufferBuilder builder, int ID = 0, StringOffset MapNameOffset = default(StringOffset), int PlayerLevelLimit = 0, int AdventureTeamLevelLimit = 0, int RolesCapacity = 0, StringOffset ExpeditionTimeOffset = default(StringOffset), StringOffset BackgroundPathOffset = default(StringOffset), StringOffset MiniMapPathOffset = default(StringOffset))
		{
			builder.StartObject(8);
			ExpeditionMapTable.AddMiniMapPath(builder, MiniMapPathOffset);
			ExpeditionMapTable.AddBackgroundPath(builder, BackgroundPathOffset);
			ExpeditionMapTable.AddExpeditionTime(builder, ExpeditionTimeOffset);
			ExpeditionMapTable.AddRolesCapacity(builder, RolesCapacity);
			ExpeditionMapTable.AddAdventureTeamLevelLimit(builder, AdventureTeamLevelLimit);
			ExpeditionMapTable.AddPlayerLevelLimit(builder, PlayerLevelLimit);
			ExpeditionMapTable.AddMapName(builder, MapNameOffset);
			ExpeditionMapTable.AddID(builder, ID);
			return ExpeditionMapTable.EndExpeditionMapTable(builder);
		}

		// Token: 0x06003270 RID: 12912 RVA: 0x000B273B File Offset: 0x000B0B3B
		public static void StartExpeditionMapTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06003271 RID: 12913 RVA: 0x000B2744 File Offset: 0x000B0B44
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003272 RID: 12914 RVA: 0x000B274F File Offset: 0x000B0B4F
		public static void AddMapName(FlatBufferBuilder builder, StringOffset MapNameOffset)
		{
			builder.AddOffset(1, MapNameOffset.Value, 0);
		}

		// Token: 0x06003273 RID: 12915 RVA: 0x000B2760 File Offset: 0x000B0B60
		public static void AddPlayerLevelLimit(FlatBufferBuilder builder, int PlayerLevelLimit)
		{
			builder.AddInt(2, PlayerLevelLimit, 0);
		}

		// Token: 0x06003274 RID: 12916 RVA: 0x000B276B File Offset: 0x000B0B6B
		public static void AddAdventureTeamLevelLimit(FlatBufferBuilder builder, int AdventureTeamLevelLimit)
		{
			builder.AddInt(3, AdventureTeamLevelLimit, 0);
		}

		// Token: 0x06003275 RID: 12917 RVA: 0x000B2776 File Offset: 0x000B0B76
		public static void AddRolesCapacity(FlatBufferBuilder builder, int RolesCapacity)
		{
			builder.AddInt(4, RolesCapacity, 0);
		}

		// Token: 0x06003276 RID: 12918 RVA: 0x000B2781 File Offset: 0x000B0B81
		public static void AddExpeditionTime(FlatBufferBuilder builder, StringOffset ExpeditionTimeOffset)
		{
			builder.AddOffset(5, ExpeditionTimeOffset.Value, 0);
		}

		// Token: 0x06003277 RID: 12919 RVA: 0x000B2792 File Offset: 0x000B0B92
		public static void AddBackgroundPath(FlatBufferBuilder builder, StringOffset BackgroundPathOffset)
		{
			builder.AddOffset(6, BackgroundPathOffset.Value, 0);
		}

		// Token: 0x06003278 RID: 12920 RVA: 0x000B27A3 File Offset: 0x000B0BA3
		public static void AddMiniMapPath(FlatBufferBuilder builder, StringOffset MiniMapPathOffset)
		{
			builder.AddOffset(7, MiniMapPathOffset.Value, 0);
		}

		// Token: 0x06003279 RID: 12921 RVA: 0x000B27B4 File Offset: 0x000B0BB4
		public static Offset<ExpeditionMapTable> EndExpeditionMapTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ExpeditionMapTable>(value);
		}

		// Token: 0x0600327A RID: 12922 RVA: 0x000B27CE File Offset: 0x000B0BCE
		public static void FinishExpeditionMapTableBuffer(FlatBufferBuilder builder, Offset<ExpeditionMapTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014C3 RID: 5315
		private Table __p = new Table();

		// Token: 0x02000422 RID: 1058
		public enum eCrypt
		{
			// Token: 0x040014C5 RID: 5317
			code = -1661111065
		}
	}
}
