using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200049D RID: 1181
	public class InscriptionDropItemTable : IFlatbufferObject
	{
		// Token: 0x17000E8B RID: 3723
		// (get) Token: 0x06003978 RID: 14712 RVA: 0x000C2658 File Offset: 0x000C0A58
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003979 RID: 14713 RVA: 0x000C2665 File Offset: 0x000C0A65
		public static InscriptionDropItemTable GetRootAsInscriptionDropItemTable(ByteBuffer _bb)
		{
			return InscriptionDropItemTable.GetRootAsInscriptionDropItemTable(_bb, new InscriptionDropItemTable());
		}

		// Token: 0x0600397A RID: 14714 RVA: 0x000C2672 File Offset: 0x000C0A72
		public static InscriptionDropItemTable GetRootAsInscriptionDropItemTable(ByteBuffer _bb, InscriptionDropItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600397B RID: 14715 RVA: 0x000C268E File Offset: 0x000C0A8E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600397C RID: 14716 RVA: 0x000C26A8 File Offset: 0x000C0AA8
		public InscriptionDropItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E8C RID: 3724
		// (get) Token: 0x0600397D RID: 14717 RVA: 0x000C26B4 File Offset: 0x000C0AB4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E8D RID: 3725
		// (get) Token: 0x0600397E RID: 14718 RVA: 0x000C2700 File Offset: 0x000C0B00
		public int GroupID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600397F RID: 14719 RVA: 0x000C274C File Offset: 0x000C0B4C
		public int ChooseNumSetArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E8E RID: 3726
		// (get) Token: 0x06003980 RID: 14720 RVA: 0x000C2798 File Offset: 0x000C0B98
		public int ChooseNumSetLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003981 RID: 14721 RVA: 0x000C27CA File Offset: 0x000C0BCA
		public ArraySegment<byte>? GetChooseNumSetBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000E8F RID: 3727
		// (get) Token: 0x06003982 RID: 14722 RVA: 0x000C27D8 File Offset: 0x000C0BD8
		public FlatBufferArray<int> ChooseNumSet
		{
			get
			{
				if (this.ChooseNumSetValue == null)
				{
					this.ChooseNumSetValue = new FlatBufferArray<int>(new Func<int, int>(this.ChooseNumSetArray), this.ChooseNumSetLength);
				}
				return this.ChooseNumSetValue;
			}
		}

		// Token: 0x06003983 RID: 14723 RVA: 0x000C2808 File Offset: 0x000C0C08
		public int NumProbSetArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E90 RID: 3728
		// (get) Token: 0x06003984 RID: 14724 RVA: 0x000C2858 File Offset: 0x000C0C58
		public int NumProbSetLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003985 RID: 14725 RVA: 0x000C288B File Offset: 0x000C0C8B
		public ArraySegment<byte>? GetNumProbSetBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000E91 RID: 3729
		// (get) Token: 0x06003986 RID: 14726 RVA: 0x000C289A File Offset: 0x000C0C9A
		public FlatBufferArray<int> NumProbSet
		{
			get
			{
				if (this.NumProbSetValue == null)
				{
					this.NumProbSetValue = new FlatBufferArray<int>(new Func<int, int>(this.NumProbSetArray), this.NumProbSetLength);
				}
				return this.NumProbSetValue;
			}
		}

		// Token: 0x17000E92 RID: 3730
		// (get) Token: 0x06003987 RID: 14727 RVA: 0x000C28CC File Offset: 0x000C0CCC
		public int DataType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E93 RID: 3731
		// (get) Token: 0x06003988 RID: 14728 RVA: 0x000C2918 File Offset: 0x000C0D18
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E94 RID: 3732
		// (get) Token: 0x06003989 RID: 14729 RVA: 0x000C2964 File Offset: 0x000C0D64
		public int ItemProb
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600398A RID: 14730 RVA: 0x000C29B0 File Offset: 0x000C0DB0
		public int ItemNumArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E95 RID: 3733
		// (get) Token: 0x0600398B RID: 14731 RVA: 0x000C2A00 File Offset: 0x000C0E00
		public int ItemNumLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600398C RID: 14732 RVA: 0x000C2A33 File Offset: 0x000C0E33
		public ArraySegment<byte>? GetItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000E96 RID: 3734
		// (get) Token: 0x0600398D RID: 14733 RVA: 0x000C2A42 File Offset: 0x000C0E42
		public FlatBufferArray<int> ItemNum
		{
			get
			{
				if (this.ItemNumValue == null)
				{
					this.ItemNumValue = new FlatBufferArray<int>(new Func<int, int>(this.ItemNumArray), this.ItemNumLength);
				}
				return this.ItemNumValue;
			}
		}

		// Token: 0x0600398E RID: 14734 RVA: 0x000C2A74 File Offset: 0x000C0E74
		public int OccuAdditionArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E97 RID: 3735
		// (get) Token: 0x0600398F RID: 14735 RVA: 0x000C2AC4 File Offset: 0x000C0EC4
		public int OccuAdditionLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003990 RID: 14736 RVA: 0x000C2AF7 File Offset: 0x000C0EF7
		public ArraySegment<byte>? GetOccuAdditionBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000E98 RID: 3736
		// (get) Token: 0x06003991 RID: 14737 RVA: 0x000C2B06 File Offset: 0x000C0F06
		public FlatBufferArray<int> OccuAddition
		{
			get
			{
				if (this.OccuAdditionValue == null)
				{
					this.OccuAdditionValue = new FlatBufferArray<int>(new Func<int, int>(this.OccuAdditionArray), this.OccuAdditionLength);
				}
				return this.OccuAdditionValue;
			}
		}

		// Token: 0x17000E99 RID: 3737
		// (get) Token: 0x06003992 RID: 14738 RVA: 0x000C2B38 File Offset: 0x000C0F38
		public int AdditionProb
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (853950550 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E9A RID: 3738
		// (get) Token: 0x06003993 RID: 14739 RVA: 0x000C2B84 File Offset: 0x000C0F84
		public string Text
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003994 RID: 14740 RVA: 0x000C2BC7 File Offset: 0x000C0FC7
		public ArraySegment<byte>? GetTextBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x06003995 RID: 14741 RVA: 0x000C2BD8 File Offset: 0x000C0FD8
		public static Offset<InscriptionDropItemTable> CreateInscriptionDropItemTable(FlatBufferBuilder builder, int ID = 0, int GroupID = 0, VectorOffset ChooseNumSetOffset = default(VectorOffset), VectorOffset NumProbSetOffset = default(VectorOffset), int DataType = 0, int ItemID = 0, int ItemProb = 0, VectorOffset ItemNumOffset = default(VectorOffset), VectorOffset OccuAdditionOffset = default(VectorOffset), int AdditionProb = 0, StringOffset TextOffset = default(StringOffset))
		{
			builder.StartObject(11);
			InscriptionDropItemTable.AddText(builder, TextOffset);
			InscriptionDropItemTable.AddAdditionProb(builder, AdditionProb);
			InscriptionDropItemTable.AddOccuAddition(builder, OccuAdditionOffset);
			InscriptionDropItemTable.AddItemNum(builder, ItemNumOffset);
			InscriptionDropItemTable.AddItemProb(builder, ItemProb);
			InscriptionDropItemTable.AddItemID(builder, ItemID);
			InscriptionDropItemTable.AddDataType(builder, DataType);
			InscriptionDropItemTable.AddNumProbSet(builder, NumProbSetOffset);
			InscriptionDropItemTable.AddChooseNumSet(builder, ChooseNumSetOffset);
			InscriptionDropItemTable.AddGroupID(builder, GroupID);
			InscriptionDropItemTable.AddID(builder, ID);
			return InscriptionDropItemTable.EndInscriptionDropItemTable(builder);
		}

		// Token: 0x06003996 RID: 14742 RVA: 0x000C2C48 File Offset: 0x000C1048
		public static void StartInscriptionDropItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06003997 RID: 14743 RVA: 0x000C2C52 File Offset: 0x000C1052
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003998 RID: 14744 RVA: 0x000C2C5D File Offset: 0x000C105D
		public static void AddGroupID(FlatBufferBuilder builder, int GroupID)
		{
			builder.AddInt(1, GroupID, 0);
		}

		// Token: 0x06003999 RID: 14745 RVA: 0x000C2C68 File Offset: 0x000C1068
		public static void AddChooseNumSet(FlatBufferBuilder builder, VectorOffset ChooseNumSetOffset)
		{
			builder.AddOffset(2, ChooseNumSetOffset.Value, 0);
		}

		// Token: 0x0600399A RID: 14746 RVA: 0x000C2C7C File Offset: 0x000C107C
		public static VectorOffset CreateChooseNumSetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600399B RID: 14747 RVA: 0x000C2CB9 File Offset: 0x000C10B9
		public static void StartChooseNumSetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600399C RID: 14748 RVA: 0x000C2CC4 File Offset: 0x000C10C4
		public static void AddNumProbSet(FlatBufferBuilder builder, VectorOffset NumProbSetOffset)
		{
			builder.AddOffset(3, NumProbSetOffset.Value, 0);
		}

		// Token: 0x0600399D RID: 14749 RVA: 0x000C2CD8 File Offset: 0x000C10D8
		public static VectorOffset CreateNumProbSetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600399E RID: 14750 RVA: 0x000C2D15 File Offset: 0x000C1115
		public static void StartNumProbSetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600399F RID: 14751 RVA: 0x000C2D20 File Offset: 0x000C1120
		public static void AddDataType(FlatBufferBuilder builder, int DataType)
		{
			builder.AddInt(4, DataType, 0);
		}

		// Token: 0x060039A0 RID: 14752 RVA: 0x000C2D2B File Offset: 0x000C112B
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(5, ItemID, 0);
		}

		// Token: 0x060039A1 RID: 14753 RVA: 0x000C2D36 File Offset: 0x000C1136
		public static void AddItemProb(FlatBufferBuilder builder, int ItemProb)
		{
			builder.AddInt(6, ItemProb, 0);
		}

		// Token: 0x060039A2 RID: 14754 RVA: 0x000C2D41 File Offset: 0x000C1141
		public static void AddItemNum(FlatBufferBuilder builder, VectorOffset ItemNumOffset)
		{
			builder.AddOffset(7, ItemNumOffset.Value, 0);
		}

		// Token: 0x060039A3 RID: 14755 RVA: 0x000C2D54 File Offset: 0x000C1154
		public static VectorOffset CreateItemNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060039A4 RID: 14756 RVA: 0x000C2D91 File Offset: 0x000C1191
		public static void StartItemNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060039A5 RID: 14757 RVA: 0x000C2D9C File Offset: 0x000C119C
		public static void AddOccuAddition(FlatBufferBuilder builder, VectorOffset OccuAdditionOffset)
		{
			builder.AddOffset(8, OccuAdditionOffset.Value, 0);
		}

		// Token: 0x060039A6 RID: 14758 RVA: 0x000C2DB0 File Offset: 0x000C11B0
		public static VectorOffset CreateOccuAdditionVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060039A7 RID: 14759 RVA: 0x000C2DED File Offset: 0x000C11ED
		public static void StartOccuAdditionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060039A8 RID: 14760 RVA: 0x000C2DF8 File Offset: 0x000C11F8
		public static void AddAdditionProb(FlatBufferBuilder builder, int AdditionProb)
		{
			builder.AddInt(9, AdditionProb, 0);
		}

		// Token: 0x060039A9 RID: 14761 RVA: 0x000C2E04 File Offset: 0x000C1204
		public static void AddText(FlatBufferBuilder builder, StringOffset TextOffset)
		{
			builder.AddOffset(10, TextOffset.Value, 0);
		}

		// Token: 0x060039AA RID: 14762 RVA: 0x000C2E18 File Offset: 0x000C1218
		public static Offset<InscriptionDropItemTable> EndInscriptionDropItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<InscriptionDropItemTable>(value);
		}

		// Token: 0x060039AB RID: 14763 RVA: 0x000C2E32 File Offset: 0x000C1232
		public static void FinishInscriptionDropItemTableBuffer(FlatBufferBuilder builder, Offset<InscriptionDropItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001638 RID: 5688
		private Table __p = new Table();

		// Token: 0x04001639 RID: 5689
		private FlatBufferArray<int> ChooseNumSetValue;

		// Token: 0x0400163A RID: 5690
		private FlatBufferArray<int> NumProbSetValue;

		// Token: 0x0400163B RID: 5691
		private FlatBufferArray<int> ItemNumValue;

		// Token: 0x0400163C RID: 5692
		private FlatBufferArray<int> OccuAdditionValue;

		// Token: 0x0200049E RID: 1182
		public enum eCrypt
		{
			// Token: 0x0400163E RID: 5694
			code = 853950550
		}
	}
}
