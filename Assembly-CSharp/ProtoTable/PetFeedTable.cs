using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200054B RID: 1355
	public class PetFeedTable : IFlatbufferObject
	{
		// Token: 0x170012C8 RID: 4808
		// (get) Token: 0x060045F0 RID: 17904 RVA: 0x000E05D0 File Offset: 0x000DE9D0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060045F1 RID: 17905 RVA: 0x000E05DD File Offset: 0x000DE9DD
		public static PetFeedTable GetRootAsPetFeedTable(ByteBuffer _bb)
		{
			return PetFeedTable.GetRootAsPetFeedTable(_bb, new PetFeedTable());
		}

		// Token: 0x060045F2 RID: 17906 RVA: 0x000E05EA File Offset: 0x000DE9EA
		public static PetFeedTable GetRootAsPetFeedTable(ByteBuffer _bb, PetFeedTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060045F3 RID: 17907 RVA: 0x000E0606 File Offset: 0x000DEA06
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060045F4 RID: 17908 RVA: 0x000E0620 File Offset: 0x000DEA20
		public PetFeedTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012C9 RID: 4809
		// (get) Token: 0x060045F5 RID: 17909 RVA: 0x000E062C File Offset: 0x000DEA2C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1919976737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012CA RID: 4810
		// (get) Token: 0x060045F6 RID: 17910 RVA: 0x000E0678 File Offset: 0x000DEA78
		public PetFeedTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (PetFeedTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060045F7 RID: 17911 RVA: 0x000E06BC File Offset: 0x000DEABC
		public string ConsumeItemArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170012CB RID: 4811
		// (get) Token: 0x060045F8 RID: 17912 RVA: 0x000E0704 File Offset: 0x000DEB04
		public int ConsumeItemLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170012CC RID: 4812
		// (get) Token: 0x060045F9 RID: 17913 RVA: 0x000E0736 File Offset: 0x000DEB36
		public FlatBufferArray<string> ConsumeItem
		{
			get
			{
				if (this.ConsumeItemValue == null)
				{
					this.ConsumeItemValue = new FlatBufferArray<string>(new Func<int, string>(this.ConsumeItemArray), this.ConsumeItemLength);
				}
				return this.ConsumeItemValue;
			}
		}

		// Token: 0x060045FA RID: 17914 RVA: 0x000E0766 File Offset: 0x000DEB66
		public static Offset<PetFeedTable> CreatePetFeedTable(FlatBufferBuilder builder, int ID = 0, PetFeedTable.eType Type = PetFeedTable.eType.Type_None, VectorOffset ConsumeItemOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			PetFeedTable.AddConsumeItem(builder, ConsumeItemOffset);
			PetFeedTable.AddType(builder, Type);
			PetFeedTable.AddID(builder, ID);
			return PetFeedTable.EndPetFeedTable(builder);
		}

		// Token: 0x060045FB RID: 17915 RVA: 0x000E078A File Offset: 0x000DEB8A
		public static void StartPetFeedTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060045FC RID: 17916 RVA: 0x000E0793 File Offset: 0x000DEB93
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060045FD RID: 17917 RVA: 0x000E079E File Offset: 0x000DEB9E
		public static void AddType(FlatBufferBuilder builder, PetFeedTable.eType Type)
		{
			builder.AddInt(1, (int)Type, 0);
		}

		// Token: 0x060045FE RID: 17918 RVA: 0x000E07A9 File Offset: 0x000DEBA9
		public static void AddConsumeItem(FlatBufferBuilder builder, VectorOffset ConsumeItemOffset)
		{
			builder.AddOffset(2, ConsumeItemOffset.Value, 0);
		}

		// Token: 0x060045FF RID: 17919 RVA: 0x000E07BC File Offset: 0x000DEBBC
		public static VectorOffset CreateConsumeItemVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004600 RID: 17920 RVA: 0x000E0802 File Offset: 0x000DEC02
		public static void StartConsumeItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004601 RID: 17921 RVA: 0x000E0810 File Offset: 0x000DEC10
		public static Offset<PetFeedTable> EndPetFeedTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PetFeedTable>(value);
		}

		// Token: 0x06004602 RID: 17922 RVA: 0x000E082A File Offset: 0x000DEC2A
		public static void FinishPetFeedTableBuffer(FlatBufferBuilder builder, Offset<PetFeedTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040019FA RID: 6650
		private Table __p = new Table();

		// Token: 0x040019FB RID: 6651
		private FlatBufferArray<string> ConsumeItemValue;

		// Token: 0x0200054C RID: 1356
		public enum eType
		{
			// Token: 0x040019FD RID: 6653
			Type_None,
			// Token: 0x040019FE RID: 6654
			PET_FEED_GOLD,
			// Token: 0x040019FF RID: 6655
			PET_FEED_POINT,
			// Token: 0x04001A00 RID: 6656
			PET_FEED_ITEM
		}

		// Token: 0x0200054D RID: 1357
		public enum eCrypt
		{
			// Token: 0x04001A02 RID: 6658
			code = 1919976737
		}
	}
}
