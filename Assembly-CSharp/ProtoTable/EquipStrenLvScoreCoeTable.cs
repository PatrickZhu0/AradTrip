using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000411 RID: 1041
	public class EquipStrenLvScoreCoeTable : IFlatbufferObject
	{
		// Token: 0x17000BD6 RID: 3030
		// (get) Token: 0x06003105 RID: 12549 RVA: 0x000AEFE0 File Offset: 0x000AD3E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003106 RID: 12550 RVA: 0x000AEFED File Offset: 0x000AD3ED
		public static EquipStrenLvScoreCoeTable GetRootAsEquipStrenLvScoreCoeTable(ByteBuffer _bb)
		{
			return EquipStrenLvScoreCoeTable.GetRootAsEquipStrenLvScoreCoeTable(_bb, new EquipStrenLvScoreCoeTable());
		}

		// Token: 0x06003107 RID: 12551 RVA: 0x000AEFFA File Offset: 0x000AD3FA
		public static EquipStrenLvScoreCoeTable GetRootAsEquipStrenLvScoreCoeTable(ByteBuffer _bb, EquipStrenLvScoreCoeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003108 RID: 12552 RVA: 0x000AF016 File Offset: 0x000AD416
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003109 RID: 12553 RVA: 0x000AF030 File Offset: 0x000AD430
		public EquipStrenLvScoreCoeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000BD7 RID: 3031
		// (get) Token: 0x0600310A RID: 12554 RVA: 0x000AF03C File Offset: 0x000AD43C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1862351641 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BD8 RID: 3032
		// (get) Token: 0x0600310B RID: 12555 RVA: 0x000AF088 File Offset: 0x000AD488
		public int Coefficient
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1862351641 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600310C RID: 12556 RVA: 0x000AF0D1 File Offset: 0x000AD4D1
		public static Offset<EquipStrenLvScoreCoeTable> CreateEquipStrenLvScoreCoeTable(FlatBufferBuilder builder, int ID = 0, int Coefficient = 0)
		{
			builder.StartObject(2);
			EquipStrenLvScoreCoeTable.AddCoefficient(builder, Coefficient);
			EquipStrenLvScoreCoeTable.AddID(builder, ID);
			return EquipStrenLvScoreCoeTable.EndEquipStrenLvScoreCoeTable(builder);
		}

		// Token: 0x0600310D RID: 12557 RVA: 0x000AF0EE File Offset: 0x000AD4EE
		public static void StartEquipStrenLvScoreCoeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0600310E RID: 12558 RVA: 0x000AF0F7 File Offset: 0x000AD4F7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600310F RID: 12559 RVA: 0x000AF102 File Offset: 0x000AD502
		public static void AddCoefficient(FlatBufferBuilder builder, int Coefficient)
		{
			builder.AddInt(1, Coefficient, 0);
		}

		// Token: 0x06003110 RID: 12560 RVA: 0x000AF110 File Offset: 0x000AD510
		public static Offset<EquipStrenLvScoreCoeTable> EndEquipStrenLvScoreCoeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipStrenLvScoreCoeTable>(value);
		}

		// Token: 0x06003111 RID: 12561 RVA: 0x000AF12A File Offset: 0x000AD52A
		public static void FinishEquipStrenLvScoreCoeTableBuffer(FlatBufferBuilder builder, Offset<EquipStrenLvScoreCoeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001456 RID: 5206
		private Table __p = new Table();

		// Token: 0x02000412 RID: 1042
		public enum eCrypt
		{
			// Token: 0x04001458 RID: 5208
			code = -1862351641
		}
	}
}
