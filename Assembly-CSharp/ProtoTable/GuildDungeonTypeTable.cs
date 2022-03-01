using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000475 RID: 1141
	public class GuildDungeonTypeTable : IFlatbufferObject
	{
		// Token: 0x17000DD1 RID: 3537
		// (get) Token: 0x06003722 RID: 14114 RVA: 0x000BD120 File Offset: 0x000BB520
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003723 RID: 14115 RVA: 0x000BD12D File Offset: 0x000BB52D
		public static GuildDungeonTypeTable GetRootAsGuildDungeonTypeTable(ByteBuffer _bb)
		{
			return GuildDungeonTypeTable.GetRootAsGuildDungeonTypeTable(_bb, new GuildDungeonTypeTable());
		}

		// Token: 0x06003724 RID: 14116 RVA: 0x000BD13A File Offset: 0x000BB53A
		public static GuildDungeonTypeTable GetRootAsGuildDungeonTypeTable(ByteBuffer _bb, GuildDungeonTypeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003725 RID: 14117 RVA: 0x000BD156 File Offset: 0x000BB556
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003726 RID: 14118 RVA: 0x000BD170 File Offset: 0x000BB570
		public GuildDungeonTypeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DD2 RID: 3538
		// (get) Token: 0x06003727 RID: 14119 RVA: 0x000BD17C File Offset: 0x000BB57C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-57312859 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DD3 RID: 3539
		// (get) Token: 0x06003728 RID: 14120 RVA: 0x000BD1C8 File Offset: 0x000BB5C8
		public int buildLvl
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-57312859 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DD4 RID: 3540
		// (get) Token: 0x06003729 RID: 14121 RVA: 0x000BD214 File Offset: 0x000BB614
		public int dungeonType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-57312859 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600372A RID: 14122 RVA: 0x000BD260 File Offset: 0x000BB660
		public string rewardItemArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000DD5 RID: 3541
		// (get) Token: 0x0600372B RID: 14123 RVA: 0x000BD2A8 File Offset: 0x000BB6A8
		public int rewardItemLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000DD6 RID: 3542
		// (get) Token: 0x0600372C RID: 14124 RVA: 0x000BD2DB File Offset: 0x000BB6DB
		public FlatBufferArray<string> rewardItem
		{
			get
			{
				if (this.rewardItemValue == null)
				{
					this.rewardItemValue = new FlatBufferArray<string>(new Func<int, string>(this.rewardItemArray), this.rewardItemLength);
				}
				return this.rewardItemValue;
			}
		}

		// Token: 0x17000DD7 RID: 3543
		// (get) Token: 0x0600372D RID: 14125 RVA: 0x000BD30C File Offset: 0x000BB70C
		public string challengeTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x000BD34F File Offset: 0x000BB74F
		public ArraySegment<byte>? GetChallengeTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000DD8 RID: 3544
		// (get) Token: 0x0600372F RID: 14127 RVA: 0x000BD360 File Offset: 0x000BB760
		public int recommendLv
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-57312859 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DD9 RID: 3545
		// (get) Token: 0x06003730 RID: 14128 RVA: 0x000BD3AC File Offset: 0x000BB7AC
		public string recommendEquip
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003731 RID: 14129 RVA: 0x000BD3EF File Offset: 0x000BB7EF
		public ArraySegment<byte>? GetRecommendEquipBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000DDA RID: 3546
		// (get) Token: 0x06003732 RID: 14130 RVA: 0x000BD400 File Offset: 0x000BB800
		public int recommendPlayerNum
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-57312859 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003733 RID: 14131 RVA: 0x000BD44C File Offset: 0x000BB84C
		public static Offset<GuildDungeonTypeTable> CreateGuildDungeonTypeTable(FlatBufferBuilder builder, int ID = 0, int buildLvl = 0, int dungeonType = 0, VectorOffset rewardItemOffset = default(VectorOffset), StringOffset challengeTimeOffset = default(StringOffset), int recommendLv = 0, StringOffset recommendEquipOffset = default(StringOffset), int recommendPlayerNum = 0)
		{
			builder.StartObject(8);
			GuildDungeonTypeTable.AddRecommendPlayerNum(builder, recommendPlayerNum);
			GuildDungeonTypeTable.AddRecommendEquip(builder, recommendEquipOffset);
			GuildDungeonTypeTable.AddRecommendLv(builder, recommendLv);
			GuildDungeonTypeTable.AddChallengeTime(builder, challengeTimeOffset);
			GuildDungeonTypeTable.AddRewardItem(builder, rewardItemOffset);
			GuildDungeonTypeTable.AddDungeonType(builder, dungeonType);
			GuildDungeonTypeTable.AddBuildLvl(builder, buildLvl);
			GuildDungeonTypeTable.AddID(builder, ID);
			return GuildDungeonTypeTable.EndGuildDungeonTypeTable(builder);
		}

		// Token: 0x06003734 RID: 14132 RVA: 0x000BD4A3 File Offset: 0x000BB8A3
		public static void StartGuildDungeonTypeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06003735 RID: 14133 RVA: 0x000BD4AC File Offset: 0x000BB8AC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003736 RID: 14134 RVA: 0x000BD4B7 File Offset: 0x000BB8B7
		public static void AddBuildLvl(FlatBufferBuilder builder, int buildLvl)
		{
			builder.AddInt(1, buildLvl, 0);
		}

		// Token: 0x06003737 RID: 14135 RVA: 0x000BD4C2 File Offset: 0x000BB8C2
		public static void AddDungeonType(FlatBufferBuilder builder, int dungeonType)
		{
			builder.AddInt(2, dungeonType, 0);
		}

		// Token: 0x06003738 RID: 14136 RVA: 0x000BD4CD File Offset: 0x000BB8CD
		public static void AddRewardItem(FlatBufferBuilder builder, VectorOffset rewardItemOffset)
		{
			builder.AddOffset(3, rewardItemOffset.Value, 0);
		}

		// Token: 0x06003739 RID: 14137 RVA: 0x000BD4E0 File Offset: 0x000BB8E0
		public static VectorOffset CreateRewardItemVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600373A RID: 14138 RVA: 0x000BD526 File Offset: 0x000BB926
		public static void StartRewardItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600373B RID: 14139 RVA: 0x000BD531 File Offset: 0x000BB931
		public static void AddChallengeTime(FlatBufferBuilder builder, StringOffset challengeTimeOffset)
		{
			builder.AddOffset(4, challengeTimeOffset.Value, 0);
		}

		// Token: 0x0600373C RID: 14140 RVA: 0x000BD542 File Offset: 0x000BB942
		public static void AddRecommendLv(FlatBufferBuilder builder, int recommendLv)
		{
			builder.AddInt(5, recommendLv, 0);
		}

		// Token: 0x0600373D RID: 14141 RVA: 0x000BD54D File Offset: 0x000BB94D
		public static void AddRecommendEquip(FlatBufferBuilder builder, StringOffset recommendEquipOffset)
		{
			builder.AddOffset(6, recommendEquipOffset.Value, 0);
		}

		// Token: 0x0600373E RID: 14142 RVA: 0x000BD55E File Offset: 0x000BB95E
		public static void AddRecommendPlayerNum(FlatBufferBuilder builder, int recommendPlayerNum)
		{
			builder.AddInt(7, recommendPlayerNum, 0);
		}

		// Token: 0x0600373F RID: 14143 RVA: 0x000BD56C File Offset: 0x000BB96C
		public static Offset<GuildDungeonTypeTable> EndGuildDungeonTypeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildDungeonTypeTable>(value);
		}

		// Token: 0x06003740 RID: 14144 RVA: 0x000BD586 File Offset: 0x000BB986
		public static void FinishGuildDungeonTypeTableBuffer(FlatBufferBuilder builder, Offset<GuildDungeonTypeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015CE RID: 5582
		private Table __p = new Table();

		// Token: 0x040015CF RID: 5583
		private FlatBufferArray<string> rewardItemValue;

		// Token: 0x02000476 RID: 1142
		public enum eCrypt
		{
			// Token: 0x040015D1 RID: 5585
			code = -57312859
		}
	}
}
