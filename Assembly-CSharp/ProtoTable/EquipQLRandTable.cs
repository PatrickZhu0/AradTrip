using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003F7 RID: 1015
	public class EquipQLRandTable : IFlatbufferObject
	{
		// Token: 0x17000B34 RID: 2868
		// (get) Token: 0x06002ECF RID: 11983 RVA: 0x000A9BDC File Offset: 0x000A7FDC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002ED0 RID: 11984 RVA: 0x000A9BE9 File Offset: 0x000A7FE9
		public static EquipQLRandTable GetRootAsEquipQLRandTable(ByteBuffer _bb)
		{
			return EquipQLRandTable.GetRootAsEquipQLRandTable(_bb, new EquipQLRandTable());
		}

		// Token: 0x06002ED1 RID: 11985 RVA: 0x000A9BF6 File Offset: 0x000A7FF6
		public static EquipQLRandTable GetRootAsEquipQLRandTable(ByteBuffer _bb, EquipQLRandTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002ED2 RID: 11986 RVA: 0x000A9C12 File Offset: 0x000A8012
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002ED3 RID: 11987 RVA: 0x000A9C2C File Offset: 0x000A802C
		public EquipQLRandTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B35 RID: 2869
		// (get) Token: 0x06002ED4 RID: 11988 RVA: 0x000A9C38 File Offset: 0x000A8038
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1155177902 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B36 RID: 2870
		// (get) Token: 0x06002ED5 RID: 11989 RVA: 0x000A9C84 File Offset: 0x000A8084
		public EquipQLRandTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(6);
				return (EquipQLRandTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B37 RID: 2871
		// (get) Token: 0x06002ED6 RID: 11990 RVA: 0x000A9CC8 File Offset: 0x000A80C8
		public int Count
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1155177902 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002ED7 RID: 11991 RVA: 0x000A9D14 File Offset: 0x000A8114
		public int RandRangeArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1155177902 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B38 RID: 2872
		// (get) Token: 0x06002ED8 RID: 11992 RVA: 0x000A9D64 File Offset: 0x000A8164
		public int RandRangeLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002ED9 RID: 11993 RVA: 0x000A9D97 File Offset: 0x000A8197
		public ArraySegment<byte>? GetRandRangeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000B39 RID: 2873
		// (get) Token: 0x06002EDA RID: 11994 RVA: 0x000A9DA6 File Offset: 0x000A81A6
		public FlatBufferArray<int> RandRange
		{
			get
			{
				if (this.RandRangeValue == null)
				{
					this.RandRangeValue = new FlatBufferArray<int>(new Func<int, int>(this.RandRangeArray), this.RandRangeLength);
				}
				return this.RandRangeValue;
			}
		}

		// Token: 0x17000B3A RID: 2874
		// (get) Token: 0x06002EDB RID: 11995 RVA: 0x000A9DD8 File Offset: 0x000A81D8
		public int SupriseRate
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1155177902 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002EDC RID: 11996 RVA: 0x000A9E24 File Offset: 0x000A8224
		public int SurpriseRangeArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-1155177902 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B3B RID: 2875
		// (get) Token: 0x06002EDD RID: 11997 RVA: 0x000A9E74 File Offset: 0x000A8274
		public int SurpriseRangeLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002EDE RID: 11998 RVA: 0x000A9EA7 File Offset: 0x000A82A7
		public ArraySegment<byte>? GetSurpriseRangeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000B3C RID: 2876
		// (get) Token: 0x06002EDF RID: 11999 RVA: 0x000A9EB6 File Offset: 0x000A82B6
		public FlatBufferArray<int> SurpriseRange
		{
			get
			{
				if (this.SurpriseRangeValue == null)
				{
					this.SurpriseRangeValue = new FlatBufferArray<int>(new Func<int, int>(this.SurpriseRangeArray), this.SurpriseRangeLength);
				}
				return this.SurpriseRangeValue;
			}
		}

		// Token: 0x06002EE0 RID: 12000 RVA: 0x000A9EE6 File Offset: 0x000A82E6
		public static Offset<EquipQLRandTable> CreateEquipQLRandTable(FlatBufferBuilder builder, int ID = 0, EquipQLRandTable.eColor Color = EquipQLRandTable.eColor.CL_NONE, int Count = 0, VectorOffset RandRangeOffset = default(VectorOffset), int SupriseRate = 0, VectorOffset SurpriseRangeOffset = default(VectorOffset))
		{
			builder.StartObject(6);
			EquipQLRandTable.AddSurpriseRange(builder, SurpriseRangeOffset);
			EquipQLRandTable.AddSupriseRate(builder, SupriseRate);
			EquipQLRandTable.AddRandRange(builder, RandRangeOffset);
			EquipQLRandTable.AddCount(builder, Count);
			EquipQLRandTable.AddColor(builder, Color);
			EquipQLRandTable.AddID(builder, ID);
			return EquipQLRandTable.EndEquipQLRandTable(builder);
		}

		// Token: 0x06002EE1 RID: 12001 RVA: 0x000A9F22 File Offset: 0x000A8322
		public static void StartEquipQLRandTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06002EE2 RID: 12002 RVA: 0x000A9F2B File Offset: 0x000A832B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002EE3 RID: 12003 RVA: 0x000A9F36 File Offset: 0x000A8336
		public static void AddColor(FlatBufferBuilder builder, EquipQLRandTable.eColor Color)
		{
			builder.AddInt(1, (int)Color, 0);
		}

		// Token: 0x06002EE4 RID: 12004 RVA: 0x000A9F41 File Offset: 0x000A8341
		public static void AddCount(FlatBufferBuilder builder, int Count)
		{
			builder.AddInt(2, Count, 0);
		}

		// Token: 0x06002EE5 RID: 12005 RVA: 0x000A9F4C File Offset: 0x000A834C
		public static void AddRandRange(FlatBufferBuilder builder, VectorOffset RandRangeOffset)
		{
			builder.AddOffset(3, RandRangeOffset.Value, 0);
		}

		// Token: 0x06002EE6 RID: 12006 RVA: 0x000A9F60 File Offset: 0x000A8360
		public static VectorOffset CreateRandRangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EE7 RID: 12007 RVA: 0x000A9F9D File Offset: 0x000A839D
		public static void StartRandRangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EE8 RID: 12008 RVA: 0x000A9FA8 File Offset: 0x000A83A8
		public static void AddSupriseRate(FlatBufferBuilder builder, int SupriseRate)
		{
			builder.AddInt(4, SupriseRate, 0);
		}

		// Token: 0x06002EE9 RID: 12009 RVA: 0x000A9FB3 File Offset: 0x000A83B3
		public static void AddSurpriseRange(FlatBufferBuilder builder, VectorOffset SurpriseRangeOffset)
		{
			builder.AddOffset(5, SurpriseRangeOffset.Value, 0);
		}

		// Token: 0x06002EEA RID: 12010 RVA: 0x000A9FC4 File Offset: 0x000A83C4
		public static VectorOffset CreateSurpriseRangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EEB RID: 12011 RVA: 0x000AA001 File Offset: 0x000A8401
		public static void StartSurpriseRangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EEC RID: 12012 RVA: 0x000AA00C File Offset: 0x000A840C
		public static Offset<EquipQLRandTable> EndEquipQLRandTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipQLRandTable>(value);
		}

		// Token: 0x06002EED RID: 12013 RVA: 0x000AA026 File Offset: 0x000A8426
		public static void FinishEquipQLRandTableBuffer(FlatBufferBuilder builder, Offset<EquipQLRandTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001393 RID: 5011
		private Table __p = new Table();

		// Token: 0x04001394 RID: 5012
		private FlatBufferArray<int> RandRangeValue;

		// Token: 0x04001395 RID: 5013
		private FlatBufferArray<int> SurpriseRangeValue;

		// Token: 0x020003F8 RID: 1016
		public enum eColor
		{
			// Token: 0x04001397 RID: 5015
			CL_NONE,
			// Token: 0x04001398 RID: 5016
			WHITE,
			// Token: 0x04001399 RID: 5017
			BLUE,
			// Token: 0x0400139A RID: 5018
			PURPLE,
			// Token: 0x0400139B RID: 5019
			GREEN,
			// Token: 0x0400139C RID: 5020
			PINK,
			// Token: 0x0400139D RID: 5021
			YELLOW
		}

		// Token: 0x020003F9 RID: 1017
		public enum eCrypt
		{
			// Token: 0x0400139F RID: 5023
			code = -1155177902
		}
	}
}
