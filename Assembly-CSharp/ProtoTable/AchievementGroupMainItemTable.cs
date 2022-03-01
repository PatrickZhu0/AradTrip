using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000268 RID: 616
	public class AchievementGroupMainItemTable : IFlatbufferObject
	{
		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06001447 RID: 5191 RVA: 0x0006A704 File Offset: 0x00068B04
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x0006A711 File Offset: 0x00068B11
		public static AchievementGroupMainItemTable GetRootAsAchievementGroupMainItemTable(ByteBuffer _bb)
		{
			return AchievementGroupMainItemTable.GetRootAsAchievementGroupMainItemTable(_bb, new AchievementGroupMainItemTable());
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x0006A71E File Offset: 0x00068B1E
		public static AchievementGroupMainItemTable GetRootAsAchievementGroupMainItemTable(ByteBuffer _bb, AchievementGroupMainItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x0006A73A File Offset: 0x00068B3A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x0006A754 File Offset: 0x00068B54
		public AchievementGroupMainItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x0600144C RID: 5196 RVA: 0x0006A760 File Offset: 0x00068B60
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1454208316 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x0600144D RID: 5197 RVA: 0x0006A7AC File Offset: 0x00068BAC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x0006A7EE File Offset: 0x00068BEE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x0600144F RID: 5199 RVA: 0x0006A7FC File Offset: 0x00068BFC
		public string PureName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x0006A83E File Offset: 0x00068C3E
		public ArraySegment<byte>? GetPureNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06001451 RID: 5201 RVA: 0x0006A84C File Offset: 0x00068C4C
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x0006A88F File Offset: 0x00068C8F
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x0006A8A0 File Offset: 0x00068CA0
		public int ChildTabsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1454208316 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x0006A8F0 File Offset: 0x00068CF0
		public int ChildTabsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001455 RID: 5205 RVA: 0x0006A923 File Offset: 0x00068D23
		public ArraySegment<byte>? GetChildTabsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06001456 RID: 5206 RVA: 0x0006A932 File Offset: 0x00068D32
		public FlatBufferArray<int> ChildTabs
		{
			get
			{
				if (this.ChildTabsValue == null)
				{
					this.ChildTabsValue = new FlatBufferArray<int>(new Func<int, int>(this.ChildTabsArray), this.ChildTabsLength);
				}
				return this.ChildTabsValue;
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06001457 RID: 5207 RVA: 0x0006A964 File Offset: 0x00068D64
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x0006A9A7 File Offset: 0x00068DA7
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0006A9B6 File Offset: 0x00068DB6
		public static Offset<AchievementGroupMainItemTable> CreateAchievementGroupMainItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset PureNameOffset = default(StringOffset), StringOffset IconOffset = default(StringOffset), VectorOffset ChildTabsOffset = default(VectorOffset), StringOffset LinkInfoOffset = default(StringOffset))
		{
			builder.StartObject(6);
			AchievementGroupMainItemTable.AddLinkInfo(builder, LinkInfoOffset);
			AchievementGroupMainItemTable.AddChildTabs(builder, ChildTabsOffset);
			AchievementGroupMainItemTable.AddIcon(builder, IconOffset);
			AchievementGroupMainItemTable.AddPureName(builder, PureNameOffset);
			AchievementGroupMainItemTable.AddName(builder, NameOffset);
			AchievementGroupMainItemTable.AddID(builder, ID);
			return AchievementGroupMainItemTable.EndAchievementGroupMainItemTable(builder);
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0006A9F2 File Offset: 0x00068DF2
		public static void StartAchievementGroupMainItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0600145B RID: 5211 RVA: 0x0006A9FB File Offset: 0x00068DFB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600145C RID: 5212 RVA: 0x0006AA06 File Offset: 0x00068E06
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x0006AA17 File Offset: 0x00068E17
		public static void AddPureName(FlatBufferBuilder builder, StringOffset PureNameOffset)
		{
			builder.AddOffset(2, PureNameOffset.Value, 0);
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x0006AA28 File Offset: 0x00068E28
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(3, IconOffset.Value, 0);
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x0006AA39 File Offset: 0x00068E39
		public static void AddChildTabs(FlatBufferBuilder builder, VectorOffset ChildTabsOffset)
		{
			builder.AddOffset(4, ChildTabsOffset.Value, 0);
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x0006AA4C File Offset: 0x00068E4C
		public static VectorOffset CreateChildTabsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x0006AA89 File Offset: 0x00068E89
		public static void StartChildTabsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001462 RID: 5218 RVA: 0x0006AA94 File Offset: 0x00068E94
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(5, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x0006AAA8 File Offset: 0x00068EA8
		public static Offset<AchievementGroupMainItemTable> EndAchievementGroupMainItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AchievementGroupMainItemTable>(value);
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x0006AAC2 File Offset: 0x00068EC2
		public static void FinishAchievementGroupMainItemTableBuffer(FlatBufferBuilder builder, Offset<AchievementGroupMainItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D62 RID: 3426
		private Table __p = new Table();

		// Token: 0x04000D63 RID: 3427
		private FlatBufferArray<int> ChildTabsValue;

		// Token: 0x02000269 RID: 617
		public enum eCrypt
		{
			// Token: 0x04000D65 RID: 3429
			code = -1454208316
		}
	}
}
