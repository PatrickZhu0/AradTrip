using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000573 RID: 1395
	public class RandomDungeonTable : IFlatbufferObject
	{
		// Token: 0x17001350 RID: 4944
		// (get) Token: 0x060047B2 RID: 18354 RVA: 0x000E4244 File Offset: 0x000E2644
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060047B3 RID: 18355 RVA: 0x000E4251 File Offset: 0x000E2651
		public static RandomDungeonTable GetRootAsRandomDungeonTable(ByteBuffer _bb)
		{
			return RandomDungeonTable.GetRootAsRandomDungeonTable(_bb, new RandomDungeonTable());
		}

		// Token: 0x060047B4 RID: 18356 RVA: 0x000E425E File Offset: 0x000E265E
		public static RandomDungeonTable GetRootAsRandomDungeonTable(ByteBuffer _bb, RandomDungeonTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060047B5 RID: 18357 RVA: 0x000E427A File Offset: 0x000E267A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060047B6 RID: 18358 RVA: 0x000E4294 File Offset: 0x000E2694
		public RandomDungeonTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001351 RID: 4945
		// (get) Token: 0x060047B7 RID: 18359 RVA: 0x000E42A0 File Offset: 0x000E26A0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2129423425 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001352 RID: 4946
		// (get) Token: 0x060047B8 RID: 18360 RVA: 0x000E42EC File Offset: 0x000E26EC
		public int dungeonType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (2129423425 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001353 RID: 4947
		// (get) Token: 0x060047B9 RID: 18361 RVA: 0x000E4338 File Offset: 0x000E2738
		public string DungeonRoom
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060047BA RID: 18362 RVA: 0x000E437A File Offset: 0x000E277A
		public ArraySegment<byte>? GetDungeonRoomBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x060047BB RID: 18363 RVA: 0x000E4388 File Offset: 0x000E2788
		public static Offset<RandomDungeonTable> CreateRandomDungeonTable(FlatBufferBuilder builder, int ID = 0, int dungeonType = 0, StringOffset DungeonRoomOffset = default(StringOffset))
		{
			builder.StartObject(3);
			RandomDungeonTable.AddDungeonRoom(builder, DungeonRoomOffset);
			RandomDungeonTable.AddDungeonType(builder, dungeonType);
			RandomDungeonTable.AddID(builder, ID);
			return RandomDungeonTable.EndRandomDungeonTable(builder);
		}

		// Token: 0x060047BC RID: 18364 RVA: 0x000E43AC File Offset: 0x000E27AC
		public static void StartRandomDungeonTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060047BD RID: 18365 RVA: 0x000E43B5 File Offset: 0x000E27B5
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060047BE RID: 18366 RVA: 0x000E43C0 File Offset: 0x000E27C0
		public static void AddDungeonType(FlatBufferBuilder builder, int dungeonType)
		{
			builder.AddInt(1, dungeonType, 0);
		}

		// Token: 0x060047BF RID: 18367 RVA: 0x000E43CB File Offset: 0x000E27CB
		public static void AddDungeonRoom(FlatBufferBuilder builder, StringOffset DungeonRoomOffset)
		{
			builder.AddOffset(2, DungeonRoomOffset.Value, 0);
		}

		// Token: 0x060047C0 RID: 18368 RVA: 0x000E43DC File Offset: 0x000E27DC
		public static Offset<RandomDungeonTable> EndRandomDungeonTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RandomDungeonTable>(value);
		}

		// Token: 0x060047C1 RID: 18369 RVA: 0x000E43F6 File Offset: 0x000E27F6
		public static void FinishRandomDungeonTableBuffer(FlatBufferBuilder builder, Offset<RandomDungeonTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A85 RID: 6789
		private Table __p = new Table();

		// Token: 0x02000574 RID: 1396
		public enum eCrypt
		{
			// Token: 0x04001A87 RID: 6791
			code = 2129423425
		}
	}
}
