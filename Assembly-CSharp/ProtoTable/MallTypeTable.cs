using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004F4 RID: 1268
	public class MallTypeTable : IFlatbufferObject
	{
		// Token: 0x1700111D RID: 4381
		// (get) Token: 0x060040E9 RID: 16617 RVA: 0x000D4A10 File Offset: 0x000D2E10
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060040EA RID: 16618 RVA: 0x000D4A1D File Offset: 0x000D2E1D
		public static MallTypeTable GetRootAsMallTypeTable(ByteBuffer _bb)
		{
			return MallTypeTable.GetRootAsMallTypeTable(_bb, new MallTypeTable());
		}

		// Token: 0x060040EB RID: 16619 RVA: 0x000D4A2A File Offset: 0x000D2E2A
		public static MallTypeTable GetRootAsMallTypeTable(ByteBuffer _bb, MallTypeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060040EC RID: 16620 RVA: 0x000D4A46 File Offset: 0x000D2E46
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060040ED RID: 16621 RVA: 0x000D4A60 File Offset: 0x000D2E60
		public MallTypeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700111E RID: 4382
		// (get) Token: 0x060040EE RID: 16622 RVA: 0x000D4A6C File Offset: 0x000D2E6C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1598275002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700111F RID: 4383
		// (get) Token: 0x060040EF RID: 16623 RVA: 0x000D4AB8 File Offset: 0x000D2EB8
		public string MainTypeName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040F0 RID: 16624 RVA: 0x000D4AFA File Offset: 0x000D2EFA
		public ArraySegment<byte>? GetMainTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001120 RID: 4384
		// (get) Token: 0x060040F1 RID: 16625 RVA: 0x000D4B08 File Offset: 0x000D2F08
		public MallTypeTable.eFuncType FuncType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (MallTypeTable.eFuncType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001121 RID: 4385
		// (get) Token: 0x060040F2 RID: 16626 RVA: 0x000D4B4C File Offset: 0x000D2F4C
		public MallTypeTable.eMoneyType MoneyType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (MallTypeTable.eMoneyType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001122 RID: 4386
		// (get) Token: 0x060040F3 RID: 16627 RVA: 0x000D4B90 File Offset: 0x000D2F90
		public int MoneyID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1598275002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001123 RID: 4387
		// (get) Token: 0x060040F4 RID: 16628 RVA: 0x000D4BDC File Offset: 0x000D2FDC
		public MallTypeTable.eMallType MallType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (MallTypeTable.eMallType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060040F5 RID: 16629 RVA: 0x000D4C20 File Offset: 0x000D3020
		public MallTypeTable.eMallSubType MallSubTypeArray(int j)
		{
			int num = this.__p.__offset(16);
			return (MallTypeTable.eMallSubType)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001124 RID: 4388
		// (get) Token: 0x060040F6 RID: 16630 RVA: 0x000D4C68 File Offset: 0x000D3068
		public int MallSubTypeLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060040F7 RID: 16631 RVA: 0x000D4C9B File Offset: 0x000D309B
		public ArraySegment<byte>? GetMallSubTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17001125 RID: 4389
		// (get) Token: 0x060040F8 RID: 16632 RVA: 0x000D4CAA File Offset: 0x000D30AA
		public FlatBufferArray<MallTypeTable.eMallSubType> MallSubType
		{
			get
			{
				if (this.MallSubTypeValue == null)
				{
					this.MallSubTypeValue = new FlatBufferArray<MallTypeTable.eMallSubType>(new Func<int, MallTypeTable.eMallSubType>(this.MallSubTypeArray), this.MallSubTypeLength);
				}
				return this.MallSubTypeValue;
			}
		}

		// Token: 0x17001126 RID: 4390
		// (get) Token: 0x060040F9 RID: 16633 RVA: 0x000D4CDC File Offset: 0x000D30DC
		public int ScrollViewRootIndex
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1598275002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001127 RID: 4391
		// (get) Token: 0x060040FA RID: 16634 RVA: 0x000D4D28 File Offset: 0x000D3128
		public int ClassifyJob
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1598275002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001128 RID: 4392
		// (get) Token: 0x060040FB RID: 16635 RVA: 0x000D4D74 File Offset: 0x000D3174
		public int Use
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1598275002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001129 RID: 4393
		// (get) Token: 0x060040FC RID: 16636 RVA: 0x000D4DC0 File Offset: 0x000D31C0
		public int IsForActivity
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1598275002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060040FD RID: 16637 RVA: 0x000D4E0C File Offset: 0x000D320C
		public static Offset<MallTypeTable> CreateMallTypeTable(FlatBufferBuilder builder, int ID = 0, StringOffset MainTypeNameOffset = default(StringOffset), MallTypeTable.eFuncType FuncType = MallTypeTable.eFuncType.FT_NONE, MallTypeTable.eMoneyType MoneyType = MallTypeTable.eMoneyType.MT_NONE, int MoneyID = 0, MallTypeTable.eMallType MallType = MallTypeTable.eMallType.MallType_None, VectorOffset MallSubTypeOffset = default(VectorOffset), int ScrollViewRootIndex = 0, int ClassifyJob = 0, int Use = 0, int IsForActivity = 0)
		{
			builder.StartObject(11);
			MallTypeTable.AddIsForActivity(builder, IsForActivity);
			MallTypeTable.AddUse(builder, Use);
			MallTypeTable.AddClassifyJob(builder, ClassifyJob);
			MallTypeTable.AddScrollViewRootIndex(builder, ScrollViewRootIndex);
			MallTypeTable.AddMallSubType(builder, MallSubTypeOffset);
			MallTypeTable.AddMallType(builder, MallType);
			MallTypeTable.AddMoneyID(builder, MoneyID);
			MallTypeTable.AddMoneyType(builder, MoneyType);
			MallTypeTable.AddFuncType(builder, FuncType);
			MallTypeTable.AddMainTypeName(builder, MainTypeNameOffset);
			MallTypeTable.AddID(builder, ID);
			return MallTypeTable.EndMallTypeTable(builder);
		}

		// Token: 0x060040FE RID: 16638 RVA: 0x000D4E7C File Offset: 0x000D327C
		public static void StartMallTypeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x060040FF RID: 16639 RVA: 0x000D4E86 File Offset: 0x000D3286
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004100 RID: 16640 RVA: 0x000D4E91 File Offset: 0x000D3291
		public static void AddMainTypeName(FlatBufferBuilder builder, StringOffset MainTypeNameOffset)
		{
			builder.AddOffset(1, MainTypeNameOffset.Value, 0);
		}

		// Token: 0x06004101 RID: 16641 RVA: 0x000D4EA2 File Offset: 0x000D32A2
		public static void AddFuncType(FlatBufferBuilder builder, MallTypeTable.eFuncType FuncType)
		{
			builder.AddInt(2, (int)FuncType, 0);
		}

		// Token: 0x06004102 RID: 16642 RVA: 0x000D4EAD File Offset: 0x000D32AD
		public static void AddMoneyType(FlatBufferBuilder builder, MallTypeTable.eMoneyType MoneyType)
		{
			builder.AddInt(3, (int)MoneyType, 0);
		}

		// Token: 0x06004103 RID: 16643 RVA: 0x000D4EB8 File Offset: 0x000D32B8
		public static void AddMoneyID(FlatBufferBuilder builder, int MoneyID)
		{
			builder.AddInt(4, MoneyID, 0);
		}

		// Token: 0x06004104 RID: 16644 RVA: 0x000D4EC3 File Offset: 0x000D32C3
		public static void AddMallType(FlatBufferBuilder builder, MallTypeTable.eMallType MallType)
		{
			builder.AddInt(5, (int)MallType, 0);
		}

		// Token: 0x06004105 RID: 16645 RVA: 0x000D4ECE File Offset: 0x000D32CE
		public static void AddMallSubType(FlatBufferBuilder builder, VectorOffset MallSubTypeOffset)
		{
			builder.AddOffset(6, MallSubTypeOffset.Value, 0);
		}

		// Token: 0x06004106 RID: 16646 RVA: 0x000D4EE0 File Offset: 0x000D32E0
		public static VectorOffset CreateMallSubTypeVector(FlatBufferBuilder builder, MallTypeTable.eMallSubType[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004107 RID: 16647 RVA: 0x000D4F1D File Offset: 0x000D331D
		public static void StartMallSubTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004108 RID: 16648 RVA: 0x000D4F28 File Offset: 0x000D3328
		public static void AddScrollViewRootIndex(FlatBufferBuilder builder, int ScrollViewRootIndex)
		{
			builder.AddInt(7, ScrollViewRootIndex, 0);
		}

		// Token: 0x06004109 RID: 16649 RVA: 0x000D4F33 File Offset: 0x000D3333
		public static void AddClassifyJob(FlatBufferBuilder builder, int ClassifyJob)
		{
			builder.AddInt(8, ClassifyJob, 0);
		}

		// Token: 0x0600410A RID: 16650 RVA: 0x000D4F3E File Offset: 0x000D333E
		public static void AddUse(FlatBufferBuilder builder, int Use)
		{
			builder.AddInt(9, Use, 0);
		}

		// Token: 0x0600410B RID: 16651 RVA: 0x000D4F4A File Offset: 0x000D334A
		public static void AddIsForActivity(FlatBufferBuilder builder, int IsForActivity)
		{
			builder.AddInt(10, IsForActivity, 0);
		}

		// Token: 0x0600410C RID: 16652 RVA: 0x000D4F58 File Offset: 0x000D3358
		public static Offset<MallTypeTable> EndMallTypeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MallTypeTable>(value);
		}

		// Token: 0x0600410D RID: 16653 RVA: 0x000D4F72 File Offset: 0x000D3372
		public static void FinishMallTypeTableBuffer(FlatBufferBuilder builder, Offset<MallTypeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400183A RID: 6202
		private Table __p = new Table();

		// Token: 0x0400183B RID: 6203
		private FlatBufferArray<MallTypeTable.eMallSubType> MallSubTypeValue;

		// Token: 0x020004F5 RID: 1269
		public enum eFuncType
		{
			// Token: 0x0400183D RID: 6205
			FT_NONE,
			// Token: 0x0400183E RID: 6206
			FT_GIFT = 9
		}

		// Token: 0x020004F6 RID: 1270
		public enum eMoneyType
		{
			// Token: 0x04001840 RID: 6208
			MT_NONE,
			// Token: 0x04001841 RID: 6209
			MT_TICKET,
			// Token: 0x04001842 RID: 6210
			MT_BIND_TICKET,
			// Token: 0x04001843 RID: 6211
			MT_MALL_POINT
		}

		// Token: 0x020004F7 RID: 1271
		public enum eMallType
		{
			// Token: 0x04001845 RID: 6213
			MallType_None,
			// Token: 0x04001846 RID: 6214
			SN_HOT,
			// Token: 0x04001847 RID: 6215
			SN_EQUIP,
			// Token: 0x04001848 RID: 6216
			SN_COST,
			// Token: 0x04001849 RID: 6217
			SN_FASHION,
			// Token: 0x0400184A RID: 6218
			SN_GOLD,
			// Token: 0x0400184B RID: 6219
			SN_GIFT,
			// Token: 0x0400184C RID: 6220
			SN_ACTIVITY_GIFT,
			// Token: 0x0400184D RID: 6221
			SN_FASHION_GIFT,
			// Token: 0x0400184E RID: 6222
			SN_NEW_SERVER_GIFT,
			// Token: 0x0400184F RID: 6223
			SN_RECOMMEND,
			// Token: 0x04001850 RID: 6224
			SN_MATERIAL,
			// Token: 0x04001851 RID: 6225
			SN_NATIONAL_DAY = 14,
			// Token: 0x04001852 RID: 6226
			SN_ITEM,
			// Token: 0x04001853 RID: 6227
			SN_FUNCTION,
			// Token: 0x04001854 RID: 6228
			SN_EXCHANGE,
			// Token: 0x04001855 RID: 6229
			SN_MEDICINE,
			// Token: 0x04001856 RID: 6230
			SN_MALL_POINT_ITEM,
			// Token: 0x04001857 RID: 6231
			SN_ASCEND_GIFT,
			// Token: 0x04001858 RID: 6232
			SN_GRATITUDE_GIFT,
			// Token: 0x04001859 RID: 6233
			SN_GRATITUDE_LUCKYBAG,
			// Token: 0x0400185A RID: 6234
			SN_STARSTONE_GIFT,
			// Token: 0x0400185B RID: 6235
			SN_VOUCHER,
			// Token: 0x0400185C RID: 6236
			SN_GUESSCOINS_GIFT,
			// Token: 0x0400185D RID: 6237
			SN_MIDSUMMER_GIFT,
			// Token: 0x0400185E RID: 6238
			SN_COOL_GIFT
		}

		// Token: 0x020004F8 RID: 1272
		public enum eMallSubType
		{
			// Token: 0x04001860 RID: 6240
			MST_NONE,
			// Token: 0x04001861 RID: 6241
			MST_HEAD,
			// Token: 0x04001862 RID: 6242
			MST_UPWEAR,
			// Token: 0x04001863 RID: 6243
			MST_CHEST,
			// Token: 0x04001864 RID: 6244
			MST_DOWNWEAR,
			// Token: 0x04001865 RID: 6245
			MST_BELT,
			// Token: 0x04001866 RID: 6246
			MST_ALL,
			// Token: 0x04001867 RID: 6247
			MST_WEAPON
		}

		// Token: 0x020004F9 RID: 1273
		public enum eCrypt
		{
			// Token: 0x04001869 RID: 6249
			code = -1598275002
		}
	}
}
