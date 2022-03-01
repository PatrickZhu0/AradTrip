using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200039F RID: 927
	public class DungeonHellTable : IFlatbufferObject
	{
		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x06002859 RID: 10329 RVA: 0x00099D24 File Offset: 0x00098124
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600285A RID: 10330 RVA: 0x00099D31 File Offset: 0x00098131
		public static DungeonHellTable GetRootAsDungeonHellTable(ByteBuffer _bb)
		{
			return DungeonHellTable.GetRootAsDungeonHellTable(_bb, new DungeonHellTable());
		}

		// Token: 0x0600285B RID: 10331 RVA: 0x00099D3E File Offset: 0x0009813E
		public static DungeonHellTable GetRootAsDungeonHellTable(ByteBuffer _bb, DungeonHellTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600285C RID: 10332 RVA: 0x00099D5A File Offset: 0x0009815A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600285D RID: 10333 RVA: 0x00099D74 File Offset: 0x00098174
		public DungeonHellTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x0600285E RID: 10334 RVA: 0x00099D80 File Offset: 0x00098180
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2119833105 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x0600285F RID: 10335 RVA: 0x00099DCC File Offset: 0x000981CC
		public int Level
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2119833105 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700090F RID: 2319
		// (get) Token: 0x06002860 RID: 10336 RVA: 0x00099E18 File Offset: 0x00098218
		public int HardType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2119833105 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002861 RID: 10337 RVA: 0x00099E64 File Offset: 0x00098264
		public int MonsterGroupsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-2119833105 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x06002862 RID: 10338 RVA: 0x00099EB4 File Offset: 0x000982B4
		public int MonsterGroupsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002863 RID: 10339 RVA: 0x00099EE7 File Offset: 0x000982E7
		public ArraySegment<byte>? GetMonsterGroupsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000911 RID: 2321
		// (get) Token: 0x06002864 RID: 10340 RVA: 0x00099EF6 File Offset: 0x000982F6
		public FlatBufferArray<int> MonsterGroups
		{
			get
			{
				if (this.MonsterGroupsValue == null)
				{
					this.MonsterGroupsValue = new FlatBufferArray<int>(new Func<int, int>(this.MonsterGroupsArray), this.MonsterGroupsLength);
				}
				return this.MonsterGroupsValue;
			}
		}

		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x06002865 RID: 10341 RVA: 0x00099F28 File Offset: 0x00098328
		public int Prob
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2119833105 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x06002866 RID: 10342 RVA: 0x00099F74 File Offset: 0x00098374
		public int DungeonList
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-2119833105 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x06002867 RID: 10343 RVA: 0x00099FC0 File Offset: 0x000983C0
		public int ChoiceType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2119833105 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002868 RID: 10344 RVA: 0x0009A00C File Offset: 0x0009840C
		public static Offset<DungeonHellTable> CreateDungeonHellTable(FlatBufferBuilder builder, int ID = 0, int Level = 0, int HardType = 0, VectorOffset MonsterGroupsOffset = default(VectorOffset), int Prob = 0, int DungeonList = 0, int ChoiceType = 0)
		{
			builder.StartObject(7);
			DungeonHellTable.AddChoiceType(builder, ChoiceType);
			DungeonHellTable.AddDungeonList(builder, DungeonList);
			DungeonHellTable.AddProb(builder, Prob);
			DungeonHellTable.AddMonsterGroups(builder, MonsterGroupsOffset);
			DungeonHellTable.AddHardType(builder, HardType);
			DungeonHellTable.AddLevel(builder, Level);
			DungeonHellTable.AddID(builder, ID);
			return DungeonHellTable.EndDungeonHellTable(builder);
		}

		// Token: 0x06002869 RID: 10345 RVA: 0x0009A05B File Offset: 0x0009845B
		public static void StartDungeonHellTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600286A RID: 10346 RVA: 0x0009A064 File Offset: 0x00098464
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600286B RID: 10347 RVA: 0x0009A06F File Offset: 0x0009846F
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(1, Level, 0);
		}

		// Token: 0x0600286C RID: 10348 RVA: 0x0009A07A File Offset: 0x0009847A
		public static void AddHardType(FlatBufferBuilder builder, int HardType)
		{
			builder.AddInt(2, HardType, 0);
		}

		// Token: 0x0600286D RID: 10349 RVA: 0x0009A085 File Offset: 0x00098485
		public static void AddMonsterGroups(FlatBufferBuilder builder, VectorOffset MonsterGroupsOffset)
		{
			builder.AddOffset(3, MonsterGroupsOffset.Value, 0);
		}

		// Token: 0x0600286E RID: 10350 RVA: 0x0009A098 File Offset: 0x00098498
		public static VectorOffset CreateMonsterGroupsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600286F RID: 10351 RVA: 0x0009A0D5 File Offset: 0x000984D5
		public static void StartMonsterGroupsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002870 RID: 10352 RVA: 0x0009A0E0 File Offset: 0x000984E0
		public static void AddProb(FlatBufferBuilder builder, int Prob)
		{
			builder.AddInt(4, Prob, 0);
		}

		// Token: 0x06002871 RID: 10353 RVA: 0x0009A0EB File Offset: 0x000984EB
		public static void AddDungeonList(FlatBufferBuilder builder, int DungeonList)
		{
			builder.AddInt(5, DungeonList, 0);
		}

		// Token: 0x06002872 RID: 10354 RVA: 0x0009A0F6 File Offset: 0x000984F6
		public static void AddChoiceType(FlatBufferBuilder builder, int ChoiceType)
		{
			builder.AddInt(6, ChoiceType, 0);
		}

		// Token: 0x06002873 RID: 10355 RVA: 0x0009A104 File Offset: 0x00098504
		public static Offset<DungeonHellTable> EndDungeonHellTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonHellTable>(value);
		}

		// Token: 0x06002874 RID: 10356 RVA: 0x0009A11E File Offset: 0x0009851E
		public static void FinishDungeonHellTableBuffer(FlatBufferBuilder builder, Offset<DungeonHellTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011E0 RID: 4576
		private Table __p = new Table();

		// Token: 0x040011E1 RID: 4577
		private FlatBufferArray<int> MonsterGroupsValue;

		// Token: 0x020003A0 RID: 928
		public enum eCrypt
		{
			// Token: 0x040011E3 RID: 4579
			code = -2119833105
		}
	}
}
