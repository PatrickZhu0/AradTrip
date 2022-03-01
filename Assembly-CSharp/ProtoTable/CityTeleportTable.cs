using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200035A RID: 858
	public class CityTeleportTable : IFlatbufferObject
	{
		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x060024C8 RID: 9416 RVA: 0x00091CBC File Offset: 0x000900BC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060024C9 RID: 9417 RVA: 0x00091CC9 File Offset: 0x000900C9
		public static CityTeleportTable GetRootAsCityTeleportTable(ByteBuffer _bb)
		{
			return CityTeleportTable.GetRootAsCityTeleportTable(_bb, new CityTeleportTable());
		}

		// Token: 0x060024CA RID: 9418 RVA: 0x00091CD6 File Offset: 0x000900D6
		public static CityTeleportTable GetRootAsCityTeleportTable(ByteBuffer _bb, CityTeleportTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060024CB RID: 9419 RVA: 0x00091CF2 File Offset: 0x000900F2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060024CC RID: 9420 RVA: 0x00091D0C File Offset: 0x0009010C
		public CityTeleportTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x060024CD RID: 9421 RVA: 0x00091D18 File Offset: 0x00090118
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2008346028 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x060024CE RID: 9422 RVA: 0x00091D64 File Offset: 0x00090164
		public string LabelName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x00091DA6 File Offset: 0x000901A6
		public ArraySegment<byte>? GetLabelNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x00091DB4 File Offset: 0x000901B4
		public int CityIDArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (2008346028 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x060024D1 RID: 9425 RVA: 0x00091E00 File Offset: 0x00090200
		public int CityIDLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060024D2 RID: 9426 RVA: 0x00091E32 File Offset: 0x00090232
		public ArraySegment<byte>? GetCityIDBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x060024D3 RID: 9427 RVA: 0x00091E40 File Offset: 0x00090240
		public FlatBufferArray<int> CityID
		{
			get
			{
				if (this.CityIDValue == null)
				{
					this.CityIDValue = new FlatBufferArray<int>(new Func<int, int>(this.CityIDArray), this.CityIDLength);
				}
				return this.CityIDValue;
			}
		}

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x060024D4 RID: 9428 RVA: 0x00091E70 File Offset: 0x00090270
		public int LowestLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (2008346028 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x060024D5 RID: 9429 RVA: 0x00091EBC File Offset: 0x000902BC
		public CityTeleportTable.eTabType TabType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (CityTeleportTable.eTabType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060024D6 RID: 9430 RVA: 0x00091F00 File Offset: 0x00090300
		public static Offset<CityTeleportTable> CreateCityTeleportTable(FlatBufferBuilder builder, int ID = 0, StringOffset LabelNameOffset = default(StringOffset), VectorOffset CityIDOffset = default(VectorOffset), int LowestLevel = 0, CityTeleportTable.eTabType TabType = CityTeleportTable.eTabType.TabType_None)
		{
			builder.StartObject(5);
			CityTeleportTable.AddTabType(builder, TabType);
			CityTeleportTable.AddLowestLevel(builder, LowestLevel);
			CityTeleportTable.AddCityID(builder, CityIDOffset);
			CityTeleportTable.AddLabelName(builder, LabelNameOffset);
			CityTeleportTable.AddID(builder, ID);
			return CityTeleportTable.EndCityTeleportTable(builder);
		}

		// Token: 0x060024D7 RID: 9431 RVA: 0x00091F34 File Offset: 0x00090334
		public static void StartCityTeleportTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060024D8 RID: 9432 RVA: 0x00091F3D File Offset: 0x0009033D
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060024D9 RID: 9433 RVA: 0x00091F48 File Offset: 0x00090348
		public static void AddLabelName(FlatBufferBuilder builder, StringOffset LabelNameOffset)
		{
			builder.AddOffset(1, LabelNameOffset.Value, 0);
		}

		// Token: 0x060024DA RID: 9434 RVA: 0x00091F59 File Offset: 0x00090359
		public static void AddCityID(FlatBufferBuilder builder, VectorOffset CityIDOffset)
		{
			builder.AddOffset(2, CityIDOffset.Value, 0);
		}

		// Token: 0x060024DB RID: 9435 RVA: 0x00091F6C File Offset: 0x0009036C
		public static VectorOffset CreateCityIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060024DC RID: 9436 RVA: 0x00091FA9 File Offset: 0x000903A9
		public static void StartCityIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060024DD RID: 9437 RVA: 0x00091FB4 File Offset: 0x000903B4
		public static void AddLowestLevel(FlatBufferBuilder builder, int LowestLevel)
		{
			builder.AddInt(3, LowestLevel, 0);
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x00091FBF File Offset: 0x000903BF
		public static void AddTabType(FlatBufferBuilder builder, CityTeleportTable.eTabType TabType)
		{
			builder.AddInt(4, (int)TabType, 0);
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x00091FCC File Offset: 0x000903CC
		public static Offset<CityTeleportTable> EndCityTeleportTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CityTeleportTable>(value);
		}

		// Token: 0x060024E0 RID: 9440 RVA: 0x00091FE6 File Offset: 0x000903E6
		public static void FinishCityTeleportTableBuffer(FlatBufferBuilder builder, Offset<CityTeleportTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400111D RID: 4381
		private Table __p = new Table();

		// Token: 0x0400111E RID: 4382
		private FlatBufferArray<int> CityIDValue;

		// Token: 0x0200035B RID: 859
		public enum eTabType
		{
			// Token: 0x04001120 RID: 4384
			TabType_None,
			// Token: 0x04001121 RID: 4385
			AlardLand,
			// Token: 0x04001122 RID: 4386
			EastCountry,
			// Token: 0x04001123 RID: 4387
			NewLand
		}

		// Token: 0x0200035C RID: 860
		public enum eCrypt
		{
			// Token: 0x04001125 RID: 4389
			code = 2008346028
		}
	}
}
