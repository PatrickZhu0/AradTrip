using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004A9 RID: 1193
	public class InscriptionTable : IFlatbufferObject
	{
		// Token: 0x17000EB5 RID: 3765
		// (get) Token: 0x06003A0D RID: 14861 RVA: 0x000C3A0C File Offset: 0x000C1E0C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003A0E RID: 14862 RVA: 0x000C3A19 File Offset: 0x000C1E19
		public static InscriptionTable GetRootAsInscriptionTable(ByteBuffer _bb)
		{
			return InscriptionTable.GetRootAsInscriptionTable(_bb, new InscriptionTable());
		}

		// Token: 0x06003A0F RID: 14863 RVA: 0x000C3A26 File Offset: 0x000C1E26
		public static InscriptionTable GetRootAsInscriptionTable(ByteBuffer _bb, InscriptionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003A10 RID: 14864 RVA: 0x000C3A42 File Offset: 0x000C1E42
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003A11 RID: 14865 RVA: 0x000C3A5C File Offset: 0x000C1E5C
		public InscriptionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EB6 RID: 3766
		// (get) Token: 0x06003A12 RID: 14866 RVA: 0x000C3A68 File Offset: 0x000C1E68
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EB7 RID: 3767
		// (get) Token: 0x06003A13 RID: 14867 RVA: 0x000C3AB4 File Offset: 0x000C1EB4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A14 RID: 14868 RVA: 0x000C3AF6 File Offset: 0x000C1EF6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000EB8 RID: 3768
		// (get) Token: 0x06003A15 RID: 14869 RVA: 0x000C3B04 File Offset: 0x000C1F04
		public int Color
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EB9 RID: 3769
		// (get) Token: 0x06003A16 RID: 14870 RVA: 0x000C3B50 File Offset: 0x000C1F50
		public InscriptionTable.eThirdType ThirdType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (InscriptionTable.eThirdType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003A17 RID: 14871 RVA: 0x000C3B94 File Offset: 0x000C1F94
		public int PropTypeArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000EBA RID: 3770
		// (get) Token: 0x06003A18 RID: 14872 RVA: 0x000C3BE4 File Offset: 0x000C1FE4
		public int PropTypeLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A19 RID: 14873 RVA: 0x000C3C17 File Offset: 0x000C2017
		public ArraySegment<byte>? GetPropTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000EBB RID: 3771
		// (get) Token: 0x06003A1A RID: 14874 RVA: 0x000C3C26 File Offset: 0x000C2026
		public FlatBufferArray<int> PropType
		{
			get
			{
				if (this.PropTypeValue == null)
				{
					this.PropTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.PropTypeArray), this.PropTypeLength);
				}
				return this.PropTypeValue;
			}
		}

		// Token: 0x06003A1B RID: 14875 RVA: 0x000C3C58 File Offset: 0x000C2058
		public int PropValueArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000EBC RID: 3772
		// (get) Token: 0x06003A1C RID: 14876 RVA: 0x000C3CA8 File Offset: 0x000C20A8
		public int PropValueLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A1D RID: 14877 RVA: 0x000C3CDB File Offset: 0x000C20DB
		public ArraySegment<byte>? GetPropValueBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000EBD RID: 3773
		// (get) Token: 0x06003A1E RID: 14878 RVA: 0x000C3CEA File Offset: 0x000C20EA
		public FlatBufferArray<int> PropValue
		{
			get
			{
				if (this.PropValueValue == null)
				{
					this.PropValueValue = new FlatBufferArray<int>(new Func<int, int>(this.PropValueArray), this.PropValueLength);
				}
				return this.PropValueValue;
			}
		}

		// Token: 0x06003A1F RID: 14879 RVA: 0x000C3D1C File Offset: 0x000C211C
		public int BuffIDArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000EBE RID: 3774
		// (get) Token: 0x06003A20 RID: 14880 RVA: 0x000C3D6C File Offset: 0x000C216C
		public int BuffIDLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A21 RID: 14881 RVA: 0x000C3D9F File Offset: 0x000C219F
		public ArraySegment<byte>? GetBuffIDBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000EBF RID: 3775
		// (get) Token: 0x06003A22 RID: 14882 RVA: 0x000C3DAE File Offset: 0x000C21AE
		public FlatBufferArray<int> BuffID
		{
			get
			{
				if (this.BuffIDValue == null)
				{
					this.BuffIDValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffIDArray), this.BuffIDLength);
				}
				return this.BuffIDValue;
			}
		}

		// Token: 0x17000EC0 RID: 3776
		// (get) Token: 0x06003A23 RID: 14883 RVA: 0x000C3DE0 File Offset: 0x000C21E0
		public int Score
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003A24 RID: 14884 RVA: 0x000C3E2C File Offset: 0x000C222C
		public int InscriptionHoleArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000EC1 RID: 3777
		// (get) Token: 0x06003A25 RID: 14885 RVA: 0x000C3E7C File Offset: 0x000C227C
		public int InscriptionHoleLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A26 RID: 14886 RVA: 0x000C3EAF File Offset: 0x000C22AF
		public ArraySegment<byte>? GetInscriptionHoleBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000EC2 RID: 3778
		// (get) Token: 0x06003A27 RID: 14887 RVA: 0x000C3EBE File Offset: 0x000C22BE
		public FlatBufferArray<int> InscriptionHole
		{
			get
			{
				if (this.InscriptionHoleValue == null)
				{
					this.InscriptionHoleValue = new FlatBufferArray<int>(new Func<int, int>(this.InscriptionHoleArray), this.InscriptionHoleLength);
				}
				return this.InscriptionHoleValue;
			}
		}

		// Token: 0x06003A28 RID: 14888 RVA: 0x000C3EF0 File Offset: 0x000C22F0
		public int OccuArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (60940446 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000EC3 RID: 3779
		// (get) Token: 0x06003A29 RID: 14889 RVA: 0x000C3F40 File Offset: 0x000C2340
		public int OccuLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A2A RID: 14890 RVA: 0x000C3F73 File Offset: 0x000C2373
		public ArraySegment<byte>? GetOccuBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000EC4 RID: 3780
		// (get) Token: 0x06003A2B RID: 14891 RVA: 0x000C3F82 File Offset: 0x000C2382
		public FlatBufferArray<int> Occu
		{
			get
			{
				if (this.OccuValue == null)
				{
					this.OccuValue = new FlatBufferArray<int>(new Func<int, int>(this.OccuArray), this.OccuLength);
				}
				return this.OccuValue;
			}
		}

		// Token: 0x06003A2C RID: 14892 RVA: 0x000C3FB4 File Offset: 0x000C23B4
		public static Offset<InscriptionTable> CreateInscriptionTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Color = 0, InscriptionTable.eThirdType ThirdType = InscriptionTable.eThirdType.ThirdType_None, VectorOffset PropTypeOffset = default(VectorOffset), VectorOffset PropValueOffset = default(VectorOffset), VectorOffset BuffIDOffset = default(VectorOffset), int Score = 0, VectorOffset InscriptionHoleOffset = default(VectorOffset), VectorOffset OccuOffset = default(VectorOffset))
		{
			builder.StartObject(10);
			InscriptionTable.AddOccu(builder, OccuOffset);
			InscriptionTable.AddInscriptionHole(builder, InscriptionHoleOffset);
			InscriptionTable.AddScore(builder, Score);
			InscriptionTable.AddBuffID(builder, BuffIDOffset);
			InscriptionTable.AddPropValue(builder, PropValueOffset);
			InscriptionTable.AddPropType(builder, PropTypeOffset);
			InscriptionTable.AddThirdType(builder, ThirdType);
			InscriptionTable.AddColor(builder, Color);
			InscriptionTable.AddName(builder, NameOffset);
			InscriptionTable.AddID(builder, ID);
			return InscriptionTable.EndInscriptionTable(builder);
		}

		// Token: 0x06003A2D RID: 14893 RVA: 0x000C401C File Offset: 0x000C241C
		public static void StartInscriptionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x06003A2E RID: 14894 RVA: 0x000C4026 File Offset: 0x000C2426
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003A2F RID: 14895 RVA: 0x000C4031 File Offset: 0x000C2431
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003A30 RID: 14896 RVA: 0x000C4042 File Offset: 0x000C2442
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(2, Color, 0);
		}

		// Token: 0x06003A31 RID: 14897 RVA: 0x000C404D File Offset: 0x000C244D
		public static void AddThirdType(FlatBufferBuilder builder, InscriptionTable.eThirdType ThirdType)
		{
			builder.AddInt(3, (int)ThirdType, 0);
		}

		// Token: 0x06003A32 RID: 14898 RVA: 0x000C4058 File Offset: 0x000C2458
		public static void AddPropType(FlatBufferBuilder builder, VectorOffset PropTypeOffset)
		{
			builder.AddOffset(4, PropTypeOffset.Value, 0);
		}

		// Token: 0x06003A33 RID: 14899 RVA: 0x000C406C File Offset: 0x000C246C
		public static VectorOffset CreatePropTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A34 RID: 14900 RVA: 0x000C40A9 File Offset: 0x000C24A9
		public static void StartPropTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A35 RID: 14901 RVA: 0x000C40B4 File Offset: 0x000C24B4
		public static void AddPropValue(FlatBufferBuilder builder, VectorOffset PropValueOffset)
		{
			builder.AddOffset(5, PropValueOffset.Value, 0);
		}

		// Token: 0x06003A36 RID: 14902 RVA: 0x000C40C8 File Offset: 0x000C24C8
		public static VectorOffset CreatePropValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A37 RID: 14903 RVA: 0x000C4105 File Offset: 0x000C2505
		public static void StartPropValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A38 RID: 14904 RVA: 0x000C4110 File Offset: 0x000C2510
		public static void AddBuffID(FlatBufferBuilder builder, VectorOffset BuffIDOffset)
		{
			builder.AddOffset(6, BuffIDOffset.Value, 0);
		}

		// Token: 0x06003A39 RID: 14905 RVA: 0x000C4124 File Offset: 0x000C2524
		public static VectorOffset CreateBuffIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A3A RID: 14906 RVA: 0x000C4161 File Offset: 0x000C2561
		public static void StartBuffIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A3B RID: 14907 RVA: 0x000C416C File Offset: 0x000C256C
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(7, Score, 0);
		}

		// Token: 0x06003A3C RID: 14908 RVA: 0x000C4177 File Offset: 0x000C2577
		public static void AddInscriptionHole(FlatBufferBuilder builder, VectorOffset InscriptionHoleOffset)
		{
			builder.AddOffset(8, InscriptionHoleOffset.Value, 0);
		}

		// Token: 0x06003A3D RID: 14909 RVA: 0x000C4188 File Offset: 0x000C2588
		public static VectorOffset CreateInscriptionHoleVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A3E RID: 14910 RVA: 0x000C41C5 File Offset: 0x000C25C5
		public static void StartInscriptionHoleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A3F RID: 14911 RVA: 0x000C41D0 File Offset: 0x000C25D0
		public static void AddOccu(FlatBufferBuilder builder, VectorOffset OccuOffset)
		{
			builder.AddOffset(9, OccuOffset.Value, 0);
		}

		// Token: 0x06003A40 RID: 14912 RVA: 0x000C41E4 File Offset: 0x000C25E4
		public static VectorOffset CreateOccuVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A41 RID: 14913 RVA: 0x000C4221 File Offset: 0x000C2621
		public static void StartOccuVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A42 RID: 14914 RVA: 0x000C422C File Offset: 0x000C262C
		public static Offset<InscriptionTable> EndInscriptionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<InscriptionTable>(value);
		}

		// Token: 0x06003A43 RID: 14915 RVA: 0x000C4246 File Offset: 0x000C2646
		public static void FinishInscriptionTableBuffer(FlatBufferBuilder builder, Offset<InscriptionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400165C RID: 5724
		private Table __p = new Table();

		// Token: 0x0400165D RID: 5725
		private FlatBufferArray<int> PropTypeValue;

		// Token: 0x0400165E RID: 5726
		private FlatBufferArray<int> PropValueValue;

		// Token: 0x0400165F RID: 5727
		private FlatBufferArray<int> BuffIDValue;

		// Token: 0x04001660 RID: 5728
		private FlatBufferArray<int> InscriptionHoleValue;

		// Token: 0x04001661 RID: 5729
		private FlatBufferArray<int> OccuValue;

		// Token: 0x020004AA RID: 1194
		public enum eThirdType
		{
			// Token: 0x04001663 RID: 5731
			ThirdType_None,
			// Token: 0x04001664 RID: 5732
			RedInscription = 800,
			// Token: 0x04001665 RID: 5733
			YellowInscription,
			// Token: 0x04001666 RID: 5734
			BlueInscription,
			// Token: 0x04001667 RID: 5735
			DarkBlondInscription,
			// Token: 0x04001668 RID: 5736
			BrilliantGoldenInscription,
			// Token: 0x04001669 RID: 5737
			OrangeInscription,
			// Token: 0x0400166A RID: 5738
			GreenInscription,
			// Token: 0x0400166B RID: 5739
			VioletInscription
		}

		// Token: 0x020004AB RID: 1195
		public enum eCrypt
		{
			// Token: 0x0400166D RID: 5741
			code = 60940446
		}
	}
}
