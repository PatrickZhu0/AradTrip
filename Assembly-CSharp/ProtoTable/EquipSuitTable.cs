using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000415 RID: 1045
	public class EquipSuitTable : IFlatbufferObject
	{
		// Token: 0x17000C14 RID: 3092
		// (get) Token: 0x060031BE RID: 12734 RVA: 0x000B0D4C File Offset: 0x000AF14C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060031BF RID: 12735 RVA: 0x000B0D59 File Offset: 0x000AF159
		public static EquipSuitTable GetRootAsEquipSuitTable(ByteBuffer _bb)
		{
			return EquipSuitTable.GetRootAsEquipSuitTable(_bb, new EquipSuitTable());
		}

		// Token: 0x060031C0 RID: 12736 RVA: 0x000B0D66 File Offset: 0x000AF166
		public static EquipSuitTable GetRootAsEquipSuitTable(ByteBuffer _bb, EquipSuitTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060031C1 RID: 12737 RVA: 0x000B0D82 File Offset: 0x000AF182
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060031C2 RID: 12738 RVA: 0x000B0D9C File Offset: 0x000AF19C
		public EquipSuitTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C15 RID: 3093
		// (get) Token: 0x060031C3 RID: 12739 RVA: 0x000B0DA8 File Offset: 0x000AF1A8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C16 RID: 3094
		// (get) Token: 0x060031C4 RID: 12740 RVA: 0x000B0DF4 File Offset: 0x000AF1F4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060031C5 RID: 12741 RVA: 0x000B0E36 File Offset: 0x000AF236
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000C17 RID: 3095
		// (get) Token: 0x060031C6 RID: 12742 RVA: 0x000B0E44 File Offset: 0x000AF244
		public int SuitsLv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060031C7 RID: 12743 RVA: 0x000B0E90 File Offset: 0x000AF290
		public int EquipIDsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C18 RID: 3096
		// (get) Token: 0x060031C8 RID: 12744 RVA: 0x000B0EE0 File Offset: 0x000AF2E0
		public int EquipIDsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060031C9 RID: 12745 RVA: 0x000B0F13 File Offset: 0x000AF313
		public ArraySegment<byte>? GetEquipIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000C19 RID: 3097
		// (get) Token: 0x060031CA RID: 12746 RVA: 0x000B0F22 File Offset: 0x000AF322
		public FlatBufferArray<int> EquipIDs
		{
			get
			{
				if (this.EquipIDsValue == null)
				{
					this.EquipIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipIDsArray), this.EquipIDsLength);
				}
				return this.EquipIDsValue;
			}
		}

		// Token: 0x17000C1A RID: 3098
		// (get) Token: 0x060031CB RID: 12747 RVA: 0x000B0F54 File Offset: 0x000AF354
		public int TwoEquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C1B RID: 3099
		// (get) Token: 0x060031CC RID: 12748 RVA: 0x000B0FA0 File Offset: 0x000AF3A0
		public int ThreeEquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C1C RID: 3100
		// (get) Token: 0x060031CD RID: 12749 RVA: 0x000B0FEC File Offset: 0x000AF3EC
		public int FourEquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C1D RID: 3101
		// (get) Token: 0x060031CE RID: 12750 RVA: 0x000B1038 File Offset: 0x000AF438
		public int FiveEquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C1E RID: 3102
		// (get) Token: 0x060031CF RID: 12751 RVA: 0x000B1084 File Offset: 0x000AF484
		public int SixEquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C1F RID: 3103
		// (get) Token: 0x060031D0 RID: 12752 RVA: 0x000B10D0 File Offset: 0x000AF4D0
		public int EightEquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C20 RID: 3104
		// (get) Token: 0x060031D1 RID: 12753 RVA: 0x000B111C File Offset: 0x000AF51C
		public int NineEquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C21 RID: 3105
		// (get) Token: 0x060031D2 RID: 12754 RVA: 0x000B1168 File Offset: 0x000AF568
		public string Description
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060031D3 RID: 12755 RVA: 0x000B11AB File Offset: 0x000AF5AB
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000C22 RID: 3106
		// (get) Token: 0x060031D4 RID: 12756 RVA: 0x000B11BC File Offset: 0x000AF5BC
		public int Adjust
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-2077694007 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060031D5 RID: 12757 RVA: 0x000B1208 File Offset: 0x000AF608
		public static Offset<EquipSuitTable> CreateEquipSuitTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int SuitsLv = 0, VectorOffset EquipIDsOffset = default(VectorOffset), int TwoEquipsAttrID = 0, int ThreeEquipsAttrID = 0, int FourEquipsAttrID = 0, int FiveEquipsAttrID = 0, int SixEquipsAttrID = 0, int EightEquipsAttrID = 0, int NineEquipsAttrID = 0, StringOffset DescriptionOffset = default(StringOffset), int Adjust = 0)
		{
			builder.StartObject(13);
			EquipSuitTable.AddAdjust(builder, Adjust);
			EquipSuitTable.AddDescription(builder, DescriptionOffset);
			EquipSuitTable.AddNineEquipsAttrID(builder, NineEquipsAttrID);
			EquipSuitTable.AddEightEquipsAttrID(builder, EightEquipsAttrID);
			EquipSuitTable.AddSixEquipsAttrID(builder, SixEquipsAttrID);
			EquipSuitTable.AddFiveEquipsAttrID(builder, FiveEquipsAttrID);
			EquipSuitTable.AddFourEquipsAttrID(builder, FourEquipsAttrID);
			EquipSuitTable.AddThreeEquipsAttrID(builder, ThreeEquipsAttrID);
			EquipSuitTable.AddTwoEquipsAttrID(builder, TwoEquipsAttrID);
			EquipSuitTable.AddEquipIDs(builder, EquipIDsOffset);
			EquipSuitTable.AddSuitsLv(builder, SuitsLv);
			EquipSuitTable.AddName(builder, NameOffset);
			EquipSuitTable.AddID(builder, ID);
			return EquipSuitTable.EndEquipSuitTable(builder);
		}

		// Token: 0x060031D6 RID: 12758 RVA: 0x000B1288 File Offset: 0x000AF688
		public static void StartEquipSuitTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x060031D7 RID: 12759 RVA: 0x000B1292 File Offset: 0x000AF692
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060031D8 RID: 12760 RVA: 0x000B129D File Offset: 0x000AF69D
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060031D9 RID: 12761 RVA: 0x000B12AE File Offset: 0x000AF6AE
		public static void AddSuitsLv(FlatBufferBuilder builder, int SuitsLv)
		{
			builder.AddInt(2, SuitsLv, 0);
		}

		// Token: 0x060031DA RID: 12762 RVA: 0x000B12B9 File Offset: 0x000AF6B9
		public static void AddEquipIDs(FlatBufferBuilder builder, VectorOffset EquipIDsOffset)
		{
			builder.AddOffset(3, EquipIDsOffset.Value, 0);
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x000B12CC File Offset: 0x000AF6CC
		public static VectorOffset CreateEquipIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060031DC RID: 12764 RVA: 0x000B1309 File Offset: 0x000AF709
		public static void StartEquipIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x000B1314 File Offset: 0x000AF714
		public static void AddTwoEquipsAttrID(FlatBufferBuilder builder, int TwoEquipsAttrID)
		{
			builder.AddInt(4, TwoEquipsAttrID, 0);
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x000B131F File Offset: 0x000AF71F
		public static void AddThreeEquipsAttrID(FlatBufferBuilder builder, int ThreeEquipsAttrID)
		{
			builder.AddInt(5, ThreeEquipsAttrID, 0);
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x000B132A File Offset: 0x000AF72A
		public static void AddFourEquipsAttrID(FlatBufferBuilder builder, int FourEquipsAttrID)
		{
			builder.AddInt(6, FourEquipsAttrID, 0);
		}

		// Token: 0x060031E0 RID: 12768 RVA: 0x000B1335 File Offset: 0x000AF735
		public static void AddFiveEquipsAttrID(FlatBufferBuilder builder, int FiveEquipsAttrID)
		{
			builder.AddInt(7, FiveEquipsAttrID, 0);
		}

		// Token: 0x060031E1 RID: 12769 RVA: 0x000B1340 File Offset: 0x000AF740
		public static void AddSixEquipsAttrID(FlatBufferBuilder builder, int SixEquipsAttrID)
		{
			builder.AddInt(8, SixEquipsAttrID, 0);
		}

		// Token: 0x060031E2 RID: 12770 RVA: 0x000B134B File Offset: 0x000AF74B
		public static void AddEightEquipsAttrID(FlatBufferBuilder builder, int EightEquipsAttrID)
		{
			builder.AddInt(9, EightEquipsAttrID, 0);
		}

		// Token: 0x060031E3 RID: 12771 RVA: 0x000B1357 File Offset: 0x000AF757
		public static void AddNineEquipsAttrID(FlatBufferBuilder builder, int NineEquipsAttrID)
		{
			builder.AddInt(10, NineEquipsAttrID, 0);
		}

		// Token: 0x060031E4 RID: 12772 RVA: 0x000B1363 File Offset: 0x000AF763
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(11, DescriptionOffset.Value, 0);
		}

		// Token: 0x060031E5 RID: 12773 RVA: 0x000B1375 File Offset: 0x000AF775
		public static void AddAdjust(FlatBufferBuilder builder, int Adjust)
		{
			builder.AddInt(12, Adjust, 0);
		}

		// Token: 0x060031E6 RID: 12774 RVA: 0x000B1384 File Offset: 0x000AF784
		public static Offset<EquipSuitTable> EndEquipSuitTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipSuitTable>(value);
		}

		// Token: 0x060031E7 RID: 12775 RVA: 0x000B139E File Offset: 0x000AF79E
		public static void FinishEquipSuitTableBuffer(FlatBufferBuilder builder, Offset<EquipSuitTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001469 RID: 5225
		private Table __p = new Table();

		// Token: 0x0400146A RID: 5226
		private FlatBufferArray<int> EquipIDsValue;

		// Token: 0x02000416 RID: 1046
		public enum eCrypt
		{
			// Token: 0x0400146C RID: 5228
			code = -2077694007
		}
	}
}
