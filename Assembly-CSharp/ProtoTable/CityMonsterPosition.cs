using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000354 RID: 852
	public class CityMonsterPosition : IFlatbufferObject
	{
		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06002483 RID: 9347 RVA: 0x000912F8 File Offset: 0x0008F6F8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002484 RID: 9348 RVA: 0x00091305 File Offset: 0x0008F705
		public static CityMonsterPosition GetRootAsCityMonsterPosition(ByteBuffer _bb)
		{
			return CityMonsterPosition.GetRootAsCityMonsterPosition(_bb, new CityMonsterPosition());
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x00091312 File Offset: 0x0008F712
		public static CityMonsterPosition GetRootAsCityMonsterPosition(ByteBuffer _bb, CityMonsterPosition obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x0009132E File Offset: 0x0008F72E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x00091348 File Offset: 0x0008F748
		public CityMonsterPosition __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06002488 RID: 9352 RVA: 0x00091354 File Offset: 0x0008F754
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1205593230 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06002489 RID: 9353 RVA: 0x000913A0 File Offset: 0x0008F7A0
		public int SceneID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1205593230 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x0600248A RID: 9354 RVA: 0x000913EC File Offset: 0x0008F7EC
		public int PosType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1205593230 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x0600248B RID: 9355 RVA: 0x00091438 File Offset: 0x0008F838
		public int Pos
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1205593230 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x00091482 File Offset: 0x0008F882
		public static Offset<CityMonsterPosition> CreateCityMonsterPosition(FlatBufferBuilder builder, int ID = 0, int SceneID = 0, int PosType = 0, int Pos = 0)
		{
			builder.StartObject(4);
			CityMonsterPosition.AddPos(builder, Pos);
			CityMonsterPosition.AddPosType(builder, PosType);
			CityMonsterPosition.AddSceneID(builder, SceneID);
			CityMonsterPosition.AddID(builder, ID);
			return CityMonsterPosition.EndCityMonsterPosition(builder);
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x000914AE File Offset: 0x0008F8AE
		public static void StartCityMonsterPosition(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0600248E RID: 9358 RVA: 0x000914B7 File Offset: 0x0008F8B7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x000914C2 File Offset: 0x0008F8C2
		public static void AddSceneID(FlatBufferBuilder builder, int SceneID)
		{
			builder.AddInt(1, SceneID, 0);
		}

		// Token: 0x06002490 RID: 9360 RVA: 0x000914CD File Offset: 0x0008F8CD
		public static void AddPosType(FlatBufferBuilder builder, int PosType)
		{
			builder.AddInt(2, PosType, 0);
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x000914D8 File Offset: 0x0008F8D8
		public static void AddPos(FlatBufferBuilder builder, int Pos)
		{
			builder.AddInt(3, Pos, 0);
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x000914E4 File Offset: 0x0008F8E4
		public static Offset<CityMonsterPosition> EndCityMonsterPosition(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CityMonsterPosition>(value);
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x000914FE File Offset: 0x0008F8FE
		public static void FinishCityMonsterPositionBuffer(FlatBufferBuilder builder, Offset<CityMonsterPosition> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040010F9 RID: 4345
		private Table __p = new Table();

		// Token: 0x02000355 RID: 853
		public enum eCrypt
		{
			// Token: 0x040010FB RID: 4347
			code = -1205593230
		}
	}
}
