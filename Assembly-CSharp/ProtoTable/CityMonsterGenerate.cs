using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000351 RID: 849
	public class CityMonsterGenerate : IFlatbufferObject
	{
		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x06002464 RID: 9316 RVA: 0x00090E88 File Offset: 0x0008F288
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x00090E95 File Offset: 0x0008F295
		public static CityMonsterGenerate GetRootAsCityMonsterGenerate(ByteBuffer _bb)
		{
			return CityMonsterGenerate.GetRootAsCityMonsterGenerate(_bb, new CityMonsterGenerate());
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x00090EA2 File Offset: 0x0008F2A2
		public static CityMonsterGenerate GetRootAsCityMonsterGenerate(ByteBuffer _bb, CityMonsterGenerate obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x00090EBE File Offset: 0x0008F2BE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x00090ED8 File Offset: 0x0008F2D8
		public CityMonsterGenerate __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x06002469 RID: 9321 RVA: 0x00090EE4 File Offset: 0x0008F2E4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1220320540 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x0600246A RID: 9322 RVA: 0x00090F30 File Offset: 0x0008F330
		public CityMonsterGenerate.eMonsterType MonsterType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (CityMonsterGenerate.eMonsterType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x0600246B RID: 9323 RVA: 0x00090F74 File Offset: 0x0008F374
		public int SceneID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1220320540 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x0600246C RID: 9324 RVA: 0x00090FC0 File Offset: 0x0008F3C0
		public int PosType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1220320540 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x0600246D RID: 9325 RVA: 0x0009100C File Offset: 0x0008F40C
		public int MinNum
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1220320540 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x0600246E RID: 9326 RVA: 0x00091058 File Offset: 0x0008F458
		public int MaxNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1220320540 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x000910A4 File Offset: 0x0008F4A4
		public int MonsterListArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-1220320540 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06002470 RID: 9328 RVA: 0x000910F4 File Offset: 0x0008F4F4
		public int MonsterListLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x00091127 File Offset: 0x0008F527
		public ArraySegment<byte>? GetMonsterListBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06002472 RID: 9330 RVA: 0x00091136 File Offset: 0x0008F536
		public FlatBufferArray<int> MonsterList
		{
			get
			{
				if (this.MonsterListValue == null)
				{
					this.MonsterListValue = new FlatBufferArray<int>(new Func<int, int>(this.MonsterListArray), this.MonsterListLength);
				}
				return this.MonsterListValue;
			}
		}

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06002473 RID: 9331 RVA: 0x00091168 File Offset: 0x0008F568
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1220320540 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002474 RID: 9332 RVA: 0x000911B4 File Offset: 0x0008F5B4
		public static Offset<CityMonsterGenerate> CreateCityMonsterGenerate(FlatBufferBuilder builder, int ID = 0, CityMonsterGenerate.eMonsterType MonsterType = CityMonsterGenerate.eMonsterType.MonsterType_None, int SceneID = 0, int PosType = 0, int MinNum = 0, int MaxNum = 0, VectorOffset MonsterListOffset = default(VectorOffset), int DungeonID = 0)
		{
			builder.StartObject(8);
			CityMonsterGenerate.AddDungeonID(builder, DungeonID);
			CityMonsterGenerate.AddMonsterList(builder, MonsterListOffset);
			CityMonsterGenerate.AddMaxNum(builder, MaxNum);
			CityMonsterGenerate.AddMinNum(builder, MinNum);
			CityMonsterGenerate.AddPosType(builder, PosType);
			CityMonsterGenerate.AddSceneID(builder, SceneID);
			CityMonsterGenerate.AddMonsterType(builder, MonsterType);
			CityMonsterGenerate.AddID(builder, ID);
			return CityMonsterGenerate.EndCityMonsterGenerate(builder);
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x0009120B File Offset: 0x0008F60B
		public static void StartCityMonsterGenerate(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06002476 RID: 9334 RVA: 0x00091214 File Offset: 0x0008F614
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x0009121F File Offset: 0x0008F61F
		public static void AddMonsterType(FlatBufferBuilder builder, CityMonsterGenerate.eMonsterType MonsterType)
		{
			builder.AddInt(1, (int)MonsterType, 0);
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x0009122A File Offset: 0x0008F62A
		public static void AddSceneID(FlatBufferBuilder builder, int SceneID)
		{
			builder.AddInt(2, SceneID, 0);
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x00091235 File Offset: 0x0008F635
		public static void AddPosType(FlatBufferBuilder builder, int PosType)
		{
			builder.AddInt(3, PosType, 0);
		}

		// Token: 0x0600247A RID: 9338 RVA: 0x00091240 File Offset: 0x0008F640
		public static void AddMinNum(FlatBufferBuilder builder, int MinNum)
		{
			builder.AddInt(4, MinNum, 0);
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x0009124B File Offset: 0x0008F64B
		public static void AddMaxNum(FlatBufferBuilder builder, int MaxNum)
		{
			builder.AddInt(5, MaxNum, 0);
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x00091256 File Offset: 0x0008F656
		public static void AddMonsterList(FlatBufferBuilder builder, VectorOffset MonsterListOffset)
		{
			builder.AddOffset(6, MonsterListOffset.Value, 0);
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x00091268 File Offset: 0x0008F668
		public static VectorOffset CreateMonsterListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x000912A5 File Offset: 0x0008F6A5
		public static void StartMonsterListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x000912B0 File Offset: 0x0008F6B0
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(7, DungeonID, 0);
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x000912BC File Offset: 0x0008F6BC
		public static Offset<CityMonsterGenerate> EndCityMonsterGenerate(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CityMonsterGenerate>(value);
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x000912D6 File Offset: 0x0008F6D6
		public static void FinishCityMonsterGenerateBuffer(FlatBufferBuilder builder, Offset<CityMonsterGenerate> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040010F1 RID: 4337
		private Table __p = new Table();

		// Token: 0x040010F2 RID: 4338
		private FlatBufferArray<int> MonsterListValue;

		// Token: 0x02000352 RID: 850
		public enum eMonsterType
		{
			// Token: 0x040010F4 RID: 4340
			MonsterType_None,
			// Token: 0x040010F5 RID: 4341
			Activity,
			// Token: 0x040010F6 RID: 4342
			Task
		}

		// Token: 0x02000353 RID: 851
		public enum eCrypt
		{
			// Token: 0x040010F8 RID: 4344
			code = -1220320540
		}
	}
}
