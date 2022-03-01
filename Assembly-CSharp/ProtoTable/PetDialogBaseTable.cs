using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000548 RID: 1352
	public class PetDialogBaseTable : IFlatbufferObject
	{
		// Token: 0x170012C2 RID: 4802
		// (get) Token: 0x060045D8 RID: 17880 RVA: 0x000E02E0 File Offset: 0x000DE6E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060045D9 RID: 17881 RVA: 0x000E02ED File Offset: 0x000DE6ED
		public static PetDialogBaseTable GetRootAsPetDialogBaseTable(ByteBuffer _bb)
		{
			return PetDialogBaseTable.GetRootAsPetDialogBaseTable(_bb, new PetDialogBaseTable());
		}

		// Token: 0x060045DA RID: 17882 RVA: 0x000E02FA File Offset: 0x000DE6FA
		public static PetDialogBaseTable GetRootAsPetDialogBaseTable(ByteBuffer _bb, PetDialogBaseTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060045DB RID: 17883 RVA: 0x000E0316 File Offset: 0x000DE716
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060045DC RID: 17884 RVA: 0x000E0330 File Offset: 0x000DE730
		public PetDialogBaseTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012C3 RID: 4803
		// (get) Token: 0x060045DD RID: 17885 RVA: 0x000E033C File Offset: 0x000DE73C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1391162910 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012C4 RID: 4804
		// (get) Token: 0x060045DE RID: 17886 RVA: 0x000E0388 File Offset: 0x000DE788
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060045DF RID: 17887 RVA: 0x000E03CA File Offset: 0x000DE7CA
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170012C5 RID: 4805
		// (get) Token: 0x060045E0 RID: 17888 RVA: 0x000E03D8 File Offset: 0x000DE7D8
		public PetDialogBaseTable.eFilterType FilterType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (PetDialogBaseTable.eFilterType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060045E1 RID: 17889 RVA: 0x000E041C File Offset: 0x000DE81C
		public int DialogIDsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (1391162910 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170012C6 RID: 4806
		// (get) Token: 0x060045E2 RID: 17890 RVA: 0x000E046C File Offset: 0x000DE86C
		public int DialogIDsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060045E3 RID: 17891 RVA: 0x000E049F File Offset: 0x000DE89F
		public ArraySegment<byte>? GetDialogIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170012C7 RID: 4807
		// (get) Token: 0x060045E4 RID: 17892 RVA: 0x000E04AE File Offset: 0x000DE8AE
		public FlatBufferArray<int> DialogIDs
		{
			get
			{
				if (this.DialogIDsValue == null)
				{
					this.DialogIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.DialogIDsArray), this.DialogIDsLength);
				}
				return this.DialogIDsValue;
			}
		}

		// Token: 0x060045E5 RID: 17893 RVA: 0x000E04DE File Offset: 0x000DE8DE
		public static Offset<PetDialogBaseTable> CreatePetDialogBaseTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset), PetDialogBaseTable.eFilterType FilterType = PetDialogBaseTable.eFilterType.Invalid, VectorOffset DialogIDsOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			PetDialogBaseTable.AddDialogIDs(builder, DialogIDsOffset);
			PetDialogBaseTable.AddFilterType(builder, FilterType);
			PetDialogBaseTable.AddDesc(builder, DescOffset);
			PetDialogBaseTable.AddID(builder, ID);
			return PetDialogBaseTable.EndPetDialogBaseTable(builder);
		}

		// Token: 0x060045E6 RID: 17894 RVA: 0x000E050A File Offset: 0x000DE90A
		public static void StartPetDialogBaseTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x060045E7 RID: 17895 RVA: 0x000E0513 File Offset: 0x000DE913
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060045E8 RID: 17896 RVA: 0x000E051E File Offset: 0x000DE91E
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x060045E9 RID: 17897 RVA: 0x000E052F File Offset: 0x000DE92F
		public static void AddFilterType(FlatBufferBuilder builder, PetDialogBaseTable.eFilterType FilterType)
		{
			builder.AddInt(2, (int)FilterType, 0);
		}

		// Token: 0x060045EA RID: 17898 RVA: 0x000E053A File Offset: 0x000DE93A
		public static void AddDialogIDs(FlatBufferBuilder builder, VectorOffset DialogIDsOffset)
		{
			builder.AddOffset(3, DialogIDsOffset.Value, 0);
		}

		// Token: 0x060045EB RID: 17899 RVA: 0x000E054C File Offset: 0x000DE94C
		public static VectorOffset CreateDialogIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060045EC RID: 17900 RVA: 0x000E0589 File Offset: 0x000DE989
		public static void StartDialogIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060045ED RID: 17901 RVA: 0x000E0594 File Offset: 0x000DE994
		public static Offset<PetDialogBaseTable> EndPetDialogBaseTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PetDialogBaseTable>(value);
		}

		// Token: 0x060045EE RID: 17902 RVA: 0x000E05AE File Offset: 0x000DE9AE
		public static void FinishPetDialogBaseTableBuffer(FlatBufferBuilder builder, Offset<PetDialogBaseTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040019F3 RID: 6643
		private Table __p = new Table();

		// Token: 0x040019F4 RID: 6644
		private FlatBufferArray<int> DialogIDsValue;

		// Token: 0x02000549 RID: 1353
		public enum eFilterType
		{
			// Token: 0x040019F6 RID: 6646
			Invalid,
			// Token: 0x040019F7 RID: 6647
			Random
		}

		// Token: 0x0200054A RID: 1354
		public enum eCrypt
		{
			// Token: 0x040019F9 RID: 6649
			code = 1391162910
		}
	}
}
