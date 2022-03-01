using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200054E RID: 1358
	public class PetLevelTable : IFlatbufferObject
	{
		// Token: 0x170012CD RID: 4813
		// (get) Token: 0x06004604 RID: 17924 RVA: 0x000E084C File Offset: 0x000DEC4C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004605 RID: 17925 RVA: 0x000E0859 File Offset: 0x000DEC59
		public static PetLevelTable GetRootAsPetLevelTable(ByteBuffer _bb)
		{
			return PetLevelTable.GetRootAsPetLevelTable(_bb, new PetLevelTable());
		}

		// Token: 0x06004606 RID: 17926 RVA: 0x000E0866 File Offset: 0x000DEC66
		public static PetLevelTable GetRootAsPetLevelTable(ByteBuffer _bb, PetLevelTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004607 RID: 17927 RVA: 0x000E0882 File Offset: 0x000DEC82
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004608 RID: 17928 RVA: 0x000E089C File Offset: 0x000DEC9C
		public PetLevelTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012CE RID: 4814
		// (get) Token: 0x06004609 RID: 17929 RVA: 0x000E08A8 File Offset: 0x000DECA8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1343709279 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012CF RID: 4815
		// (get) Token: 0x0600460A RID: 17930 RVA: 0x000E08F4 File Offset: 0x000DECF4
		public int Level
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1343709279 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012D0 RID: 4816
		// (get) Token: 0x0600460B RID: 17931 RVA: 0x000E0940 File Offset: 0x000DED40
		public int Quality
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1343709279 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012D1 RID: 4817
		// (get) Token: 0x0600460C RID: 17932 RVA: 0x000E098C File Offset: 0x000DED8C
		public int UplevelExp
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1343709279 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012D2 RID: 4818
		// (get) Token: 0x0600460D RID: 17933 RVA: 0x000E09D8 File Offset: 0x000DEDD8
		public int FatigueExp
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1343709279 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012D3 RID: 4819
		// (get) Token: 0x0600460E RID: 17934 RVA: 0x000E0A24 File Offset: 0x000DEE24
		public int FatigueHunger
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1343709279 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012D4 RID: 4820
		// (get) Token: 0x0600460F RID: 17935 RVA: 0x000E0A70 File Offset: 0x000DEE70
		public string SellReward
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004610 RID: 17936 RVA: 0x000E0AB3 File Offset: 0x000DEEB3
		public ArraySegment<byte>? GetSellRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x06004611 RID: 17937 RVA: 0x000E0AC4 File Offset: 0x000DEEC4
		public static Offset<PetLevelTable> CreatePetLevelTable(FlatBufferBuilder builder, int ID = 0, int Level = 0, int Quality = 0, int UplevelExp = 0, int FatigueExp = 0, int FatigueHunger = 0, StringOffset SellRewardOffset = default(StringOffset))
		{
			builder.StartObject(7);
			PetLevelTable.AddSellReward(builder, SellRewardOffset);
			PetLevelTable.AddFatigueHunger(builder, FatigueHunger);
			PetLevelTable.AddFatigueExp(builder, FatigueExp);
			PetLevelTable.AddUplevelExp(builder, UplevelExp);
			PetLevelTable.AddQuality(builder, Quality);
			PetLevelTable.AddLevel(builder, Level);
			PetLevelTable.AddID(builder, ID);
			return PetLevelTable.EndPetLevelTable(builder);
		}

		// Token: 0x06004612 RID: 17938 RVA: 0x000E0B13 File Offset: 0x000DEF13
		public static void StartPetLevelTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06004613 RID: 17939 RVA: 0x000E0B1C File Offset: 0x000DEF1C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004614 RID: 17940 RVA: 0x000E0B27 File Offset: 0x000DEF27
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(1, Level, 0);
		}

		// Token: 0x06004615 RID: 17941 RVA: 0x000E0B32 File Offset: 0x000DEF32
		public static void AddQuality(FlatBufferBuilder builder, int Quality)
		{
			builder.AddInt(2, Quality, 0);
		}

		// Token: 0x06004616 RID: 17942 RVA: 0x000E0B3D File Offset: 0x000DEF3D
		public static void AddUplevelExp(FlatBufferBuilder builder, int UplevelExp)
		{
			builder.AddInt(3, UplevelExp, 0);
		}

		// Token: 0x06004617 RID: 17943 RVA: 0x000E0B48 File Offset: 0x000DEF48
		public static void AddFatigueExp(FlatBufferBuilder builder, int FatigueExp)
		{
			builder.AddInt(4, FatigueExp, 0);
		}

		// Token: 0x06004618 RID: 17944 RVA: 0x000E0B53 File Offset: 0x000DEF53
		public static void AddFatigueHunger(FlatBufferBuilder builder, int FatigueHunger)
		{
			builder.AddInt(5, FatigueHunger, 0);
		}

		// Token: 0x06004619 RID: 17945 RVA: 0x000E0B5E File Offset: 0x000DEF5E
		public static void AddSellReward(FlatBufferBuilder builder, StringOffset SellRewardOffset)
		{
			builder.AddOffset(6, SellRewardOffset.Value, 0);
		}

		// Token: 0x0600461A RID: 17946 RVA: 0x000E0B70 File Offset: 0x000DEF70
		public static Offset<PetLevelTable> EndPetLevelTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PetLevelTable>(value);
		}

		// Token: 0x0600461B RID: 17947 RVA: 0x000E0B8A File Offset: 0x000DEF8A
		public static void FinishPetLevelTableBuffer(FlatBufferBuilder builder, Offset<PetLevelTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A03 RID: 6659
		private Table __p = new Table();

		// Token: 0x0200054F RID: 1359
		public enum eCrypt
		{
			// Token: 0x04001A05 RID: 6661
			code = -1343709279
		}
	}
}
