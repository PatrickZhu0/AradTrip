using System;
using FlatBuffers;

namespace FBDungeonData
{
	// Token: 0x02004AFB RID: 19195
	public sealed class DSceneDataConnect : Table
	{
		// Token: 0x0601BEDC RID: 114396 RVA: 0x0088C93F File Offset: 0x0088AD3F
		public static DSceneDataConnect GetRootAsDSceneDataConnect(ByteBuffer _bb)
		{
			return DSceneDataConnect.GetRootAsDSceneDataConnect(_bb, new DSceneDataConnect());
		}

		// Token: 0x0601BEDD RID: 114397 RVA: 0x0088C94C File Offset: 0x0088AD4C
		public static DSceneDataConnect GetRootAsDSceneDataConnect(ByteBuffer _bb, DSceneDataConnect obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BEDE RID: 114398 RVA: 0x0088C968 File Offset: 0x0088AD68
		public DSceneDataConnect __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x0601BEDF RID: 114399 RVA: 0x0088C97C File Offset: 0x0088AD7C
		public bool GetIsconnect(int j)
		{
			int num = base.__offset(4);
			return num != 0 && 0 != this.bb.Get(base.__vector(num) + j);
		}

		// Token: 0x170025F3 RID: 9715
		// (get) Token: 0x0601BEE0 RID: 114400 RVA: 0x0088C9B8 File Offset: 0x0088ADB8
		public int IsconnectLength
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601BEE1 RID: 114401 RVA: 0x0088C9E0 File Offset: 0x0088ADE0
		public int GetLinkAreaIndex(int j)
		{
			int num = base.__offset(6);
			return (num == 0) ? 0 : this.bb.GetInt(base.__vector(num) + j * 4);
		}

		// Token: 0x170025F4 RID: 9716
		// (get) Token: 0x0601BEE2 RID: 114402 RVA: 0x0088CA18 File Offset: 0x0088AE18
		public int LinkAreaIndexLength
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x170025F5 RID: 9717
		// (get) Token: 0x0601BEE3 RID: 114403 RVA: 0x0088CA40 File Offset: 0x0088AE40
		public int Areaindex
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? -1 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170025F6 RID: 9718
		// (get) Token: 0x0601BEE4 RID: 114404 RVA: 0x0088CA74 File Offset: 0x0088AE74
		public int Id
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170025F7 RID: 9719
		// (get) Token: 0x0601BEE5 RID: 114405 RVA: 0x0088CAAC File Offset: 0x0088AEAC
		public string Sceneareapath
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170025F8 RID: 9720
		// (get) Token: 0x0601BEE6 RID: 114406 RVA: 0x0088CADC File Offset: 0x0088AEDC
		public int Positionx
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? -1 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170025F9 RID: 9721
		// (get) Token: 0x0601BEE7 RID: 114407 RVA: 0x0088CB14 File Offset: 0x0088AF14
		public int Positiony
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? -1 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170025FA RID: 9722
		// (get) Token: 0x0601BEE8 RID: 114408 RVA: 0x0088CB4C File Offset: 0x0088AF4C
		public bool Isboss
		{
			get
			{
				int num = base.__offset(18);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170025FB RID: 9723
		// (get) Token: 0x0601BEE9 RID: 114409 RVA: 0x0088CB88 File Offset: 0x0088AF88
		public bool Isstart
		{
			get
			{
				int num = base.__offset(20);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170025FC RID: 9724
		// (get) Token: 0x0601BEEA RID: 114410 RVA: 0x0088CBC4 File Offset: 0x0088AFC4
		public bool Isegg
		{
			get
			{
				int num = base.__offset(22);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170025FD RID: 9725
		// (get) Token: 0x0601BEEB RID: 114411 RVA: 0x0088CC00 File Offset: 0x0088B000
		public bool Isnothell
		{
			get
			{
				int num = base.__offset(24);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170025FE RID: 9726
		// (get) Token: 0x0601BEEC RID: 114412 RVA: 0x0088CC3C File Offset: 0x0088B03C
		public byte TreasureType
		{
			get
			{
				int num = base.__offset(26);
				return (num == 0) ? 0 : this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601BEED RID: 114413 RVA: 0x0088CC74 File Offset: 0x0088B074
		public static Offset<DSceneDataConnect> CreateDSceneDataConnect(FlatBufferBuilder builder, VectorOffset isconnect = default(VectorOffset), VectorOffset linkAreaIndex = default(VectorOffset), int areaindex = -1, int id = 0, StringOffset sceneareapath = default(StringOffset), int positionx = -1, int positiony = -1, bool isboss = false, bool isstart = false, bool isegg = false, bool isnothell = false, byte treasureType = 0)
		{
			builder.StartObject(12);
			DSceneDataConnect.AddPositiony(builder, positiony);
			DSceneDataConnect.AddPositionx(builder, positionx);
			DSceneDataConnect.AddSceneareapath(builder, sceneareapath);
			DSceneDataConnect.AddId(builder, id);
			DSceneDataConnect.AddAreaindex(builder, areaindex);
			DSceneDataConnect.AddLinkAreaIndex(builder, linkAreaIndex);
			DSceneDataConnect.AddIsconnect(builder, isconnect);
			DSceneDataConnect.AddTreasureType(builder, treasureType);
			DSceneDataConnect.AddIsnothell(builder, isnothell);
			DSceneDataConnect.AddIsegg(builder, isegg);
			DSceneDataConnect.AddIsstart(builder, isstart);
			DSceneDataConnect.AddIsboss(builder, isboss);
			return DSceneDataConnect.EndDSceneDataConnect(builder);
		}

		// Token: 0x0601BEEE RID: 114414 RVA: 0x0088CCEC File Offset: 0x0088B0EC
		public static void StartDSceneDataConnect(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x0601BEEF RID: 114415 RVA: 0x0088CCF6 File Offset: 0x0088B0F6
		public static void AddIsconnect(FlatBufferBuilder builder, VectorOffset isconnectOffset)
		{
			builder.AddOffset(0, isconnectOffset.Value, 0);
		}

		// Token: 0x0601BEF0 RID: 114416 RVA: 0x0088CD08 File Offset: 0x0088B108
		public static VectorOffset CreateIsconnectVector(FlatBufferBuilder builder, bool[] data)
		{
			builder.StartVector(1, data.Length, 1);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddBool(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601BEF1 RID: 114417 RVA: 0x0088CD45 File Offset: 0x0088B145
		public static void StartIsconnectVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(1, numElems, 1);
		}

		// Token: 0x0601BEF2 RID: 114418 RVA: 0x0088CD50 File Offset: 0x0088B150
		public static void AddLinkAreaIndex(FlatBufferBuilder builder, VectorOffset linkAreaIndexOffset)
		{
			builder.AddOffset(1, linkAreaIndexOffset.Value, 0);
		}

		// Token: 0x0601BEF3 RID: 114419 RVA: 0x0088CD64 File Offset: 0x0088B164
		public static VectorOffset CreateLinkAreaIndexVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601BEF4 RID: 114420 RVA: 0x0088CDA1 File Offset: 0x0088B1A1
		public static void StartLinkAreaIndexVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601BEF5 RID: 114421 RVA: 0x0088CDAC File Offset: 0x0088B1AC
		public static void AddAreaindex(FlatBufferBuilder builder, int areaindex)
		{
			builder.AddInt(2, areaindex, -1);
		}

		// Token: 0x0601BEF6 RID: 114422 RVA: 0x0088CDB7 File Offset: 0x0088B1B7
		public static void AddId(FlatBufferBuilder builder, int id)
		{
			builder.AddInt(3, id, 0);
		}

		// Token: 0x0601BEF7 RID: 114423 RVA: 0x0088CDC2 File Offset: 0x0088B1C2
		public static void AddSceneareapath(FlatBufferBuilder builder, StringOffset sceneareapathOffset)
		{
			builder.AddOffset(4, sceneareapathOffset.Value, 0);
		}

		// Token: 0x0601BEF8 RID: 114424 RVA: 0x0088CDD3 File Offset: 0x0088B1D3
		public static void AddPositionx(FlatBufferBuilder builder, int positionx)
		{
			builder.AddInt(5, positionx, -1);
		}

		// Token: 0x0601BEF9 RID: 114425 RVA: 0x0088CDDE File Offset: 0x0088B1DE
		public static void AddPositiony(FlatBufferBuilder builder, int positiony)
		{
			builder.AddInt(6, positiony, -1);
		}

		// Token: 0x0601BEFA RID: 114426 RVA: 0x0088CDE9 File Offset: 0x0088B1E9
		public static void AddIsboss(FlatBufferBuilder builder, bool isboss)
		{
			builder.AddBool(7, isboss, false);
		}

		// Token: 0x0601BEFB RID: 114427 RVA: 0x0088CDF4 File Offset: 0x0088B1F4
		public static void AddIsstart(FlatBufferBuilder builder, bool isstart)
		{
			builder.AddBool(8, isstart, false);
		}

		// Token: 0x0601BEFC RID: 114428 RVA: 0x0088CDFF File Offset: 0x0088B1FF
		public static void AddIsegg(FlatBufferBuilder builder, bool isegg)
		{
			builder.AddBool(9, isegg, false);
		}

		// Token: 0x0601BEFD RID: 114429 RVA: 0x0088CE0B File Offset: 0x0088B20B
		public static void AddIsnothell(FlatBufferBuilder builder, bool isnothell)
		{
			builder.AddBool(10, isnothell, false);
		}

		// Token: 0x0601BEFE RID: 114430 RVA: 0x0088CE17 File Offset: 0x0088B217
		public static void AddTreasureType(FlatBufferBuilder builder, byte treasureType)
		{
			builder.AddByte(11, treasureType, 0);
		}

		// Token: 0x0601BEFF RID: 114431 RVA: 0x0088CE24 File Offset: 0x0088B224
		public static Offset<DSceneDataConnect> EndDSceneDataConnect(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSceneDataConnect>(value);
		}
	}
}
