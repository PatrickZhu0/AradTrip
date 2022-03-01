using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200040E RID: 1038
	public class EquipStrRateTable : IFlatbufferObject
	{
		// Token: 0x17000BC7 RID: 3015
		// (get) Token: 0x060030D9 RID: 12505 RVA: 0x000AE928 File Offset: 0x000ACD28
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060030DA RID: 12506 RVA: 0x000AE935 File Offset: 0x000ACD35
		public static EquipStrRateTable GetRootAsEquipStrRateTable(ByteBuffer _bb)
		{
			return EquipStrRateTable.GetRootAsEquipStrRateTable(_bb, new EquipStrRateTable());
		}

		// Token: 0x060030DB RID: 12507 RVA: 0x000AE942 File Offset: 0x000ACD42
		public static EquipStrRateTable GetRootAsEquipStrRateTable(ByteBuffer _bb, EquipStrRateTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060030DC RID: 12508 RVA: 0x000AE95E File Offset: 0x000ACD5E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060030DD RID: 12509 RVA: 0x000AE978 File Offset: 0x000ACD78
		public EquipStrRateTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000BC8 RID: 3016
		// (get) Token: 0x060030DE RID: 12510 RVA: 0x000AE984 File Offset: 0x000ACD84
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BC9 RID: 3017
		// (get) Token: 0x060030DF RID: 12511 RVA: 0x000AE9D0 File Offset: 0x000ACDD0
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BCA RID: 3018
		// (get) Token: 0x060030E0 RID: 12512 RVA: 0x000AEA1C File Offset: 0x000ACE1C
		public int Strengthen
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060030E1 RID: 12513 RVA: 0x000AEA68 File Offset: 0x000ACE68
		public int SucRateArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BCB RID: 3019
		// (get) Token: 0x060030E2 RID: 12514 RVA: 0x000AEAB8 File Offset: 0x000ACEB8
		public int SucRateLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060030E3 RID: 12515 RVA: 0x000AEAEB File Offset: 0x000ACEEB
		public ArraySegment<byte>? GetSucRateBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000BCC RID: 3020
		// (get) Token: 0x060030E4 RID: 12516 RVA: 0x000AEAFA File Offset: 0x000ACEFA
		public FlatBufferArray<int> SucRate
		{
			get
			{
				if (this.SucRateValue == null)
				{
					this.SucRateValue = new FlatBufferArray<int>(new Func<int, int>(this.SucRateArray), this.SucRateLength);
				}
				return this.SucRateValue;
			}
		}

		// Token: 0x17000BCD RID: 3021
		// (get) Token: 0x060030E5 RID: 12517 RVA: 0x000AEB2C File Offset: 0x000ACF2C
		public EquipStrRateTable.eFail Fail
		{
			get
			{
				int num = this.__p.__offset(12);
				return (EquipStrRateTable.eFail)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BCE RID: 3022
		// (get) Token: 0x060030E6 RID: 12518 RVA: 0x000AEB70 File Offset: 0x000ACF70
		public int Fix1
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BCF RID: 3023
		// (get) Token: 0x060030E7 RID: 12519 RVA: 0x000AEBBC File Offset: 0x000ACFBC
		public int Fix1Max
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BD0 RID: 3024
		// (get) Token: 0x060030E8 RID: 12520 RVA: 0x000AEC08 File Offset: 0x000AD008
		public int Fix2
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BD1 RID: 3025
		// (get) Token: 0x060030E9 RID: 12521 RVA: 0x000AEC54 File Offset: 0x000AD054
		public int Fix2Max
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060030EA RID: 12522 RVA: 0x000AECA0 File Offset: 0x000AD0A0
		public int Fix3ConditionArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BD2 RID: 3026
		// (get) Token: 0x060030EB RID: 12523 RVA: 0x000AECF0 File Offset: 0x000AD0F0
		public int Fix3ConditionLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060030EC RID: 12524 RVA: 0x000AED23 File Offset: 0x000AD123
		public ArraySegment<byte>? GetFix3ConditionBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000BD3 RID: 3027
		// (get) Token: 0x060030ED RID: 12525 RVA: 0x000AED32 File Offset: 0x000AD132
		public FlatBufferArray<int> Fix3Condition
		{
			get
			{
				if (this.Fix3ConditionValue == null)
				{
					this.Fix3ConditionValue = new FlatBufferArray<int>(new Func<int, int>(this.Fix3ConditionArray), this.Fix3ConditionLength);
				}
				return this.Fix3ConditionValue;
			}
		}

		// Token: 0x17000BD4 RID: 3028
		// (get) Token: 0x060030EE RID: 12526 RVA: 0x000AED64 File Offset: 0x000AD164
		public int Fix3
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BD5 RID: 3029
		// (get) Token: 0x060030EF RID: 12527 RVA: 0x000AEDB0 File Offset: 0x000AD1B0
		public int TickAddNum
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-499643615 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060030F0 RID: 12528 RVA: 0x000AEDFC File Offset: 0x000AD1FC
		public static Offset<EquipStrRateTable> CreateEquipStrRateTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int Strengthen = 0, VectorOffset SucRateOffset = default(VectorOffset), EquipStrRateTable.eFail Fail = EquipStrRateTable.eFail.NONE, int Fix1 = 0, int Fix1Max = 0, int Fix2 = 0, int Fix2Max = 0, VectorOffset Fix3ConditionOffset = default(VectorOffset), int Fix3 = 0, int TickAddNum = 0)
		{
			builder.StartObject(12);
			EquipStrRateTable.AddTickAddNum(builder, TickAddNum);
			EquipStrRateTable.AddFix3(builder, Fix3);
			EquipStrRateTable.AddFix3Condition(builder, Fix3ConditionOffset);
			EquipStrRateTable.AddFix2Max(builder, Fix2Max);
			EquipStrRateTable.AddFix2(builder, Fix2);
			EquipStrRateTable.AddFix1Max(builder, Fix1Max);
			EquipStrRateTable.AddFix1(builder, Fix1);
			EquipStrRateTable.AddFail(builder, Fail);
			EquipStrRateTable.AddSucRate(builder, SucRateOffset);
			EquipStrRateTable.AddStrengthen(builder, Strengthen);
			EquipStrRateTable.AddType(builder, Type);
			EquipStrRateTable.AddID(builder, ID);
			return EquipStrRateTable.EndEquipStrRateTable(builder);
		}

		// Token: 0x060030F1 RID: 12529 RVA: 0x000AEE74 File Offset: 0x000AD274
		public static void StartEquipStrRateTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x060030F2 RID: 12530 RVA: 0x000AEE7E File Offset: 0x000AD27E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060030F3 RID: 12531 RVA: 0x000AEE89 File Offset: 0x000AD289
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060030F4 RID: 12532 RVA: 0x000AEE94 File Offset: 0x000AD294
		public static void AddStrengthen(FlatBufferBuilder builder, int Strengthen)
		{
			builder.AddInt(2, Strengthen, 0);
		}

		// Token: 0x060030F5 RID: 12533 RVA: 0x000AEE9F File Offset: 0x000AD29F
		public static void AddSucRate(FlatBufferBuilder builder, VectorOffset SucRateOffset)
		{
			builder.AddOffset(3, SucRateOffset.Value, 0);
		}

		// Token: 0x060030F6 RID: 12534 RVA: 0x000AEEB0 File Offset: 0x000AD2B0
		public static VectorOffset CreateSucRateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030F7 RID: 12535 RVA: 0x000AEEED File Offset: 0x000AD2ED
		public static void StartSucRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060030F8 RID: 12536 RVA: 0x000AEEF8 File Offset: 0x000AD2F8
		public static void AddFail(FlatBufferBuilder builder, EquipStrRateTable.eFail Fail)
		{
			builder.AddInt(4, (int)Fail, 0);
		}

		// Token: 0x060030F9 RID: 12537 RVA: 0x000AEF03 File Offset: 0x000AD303
		public static void AddFix1(FlatBufferBuilder builder, int Fix1)
		{
			builder.AddInt(5, Fix1, 0);
		}

		// Token: 0x060030FA RID: 12538 RVA: 0x000AEF0E File Offset: 0x000AD30E
		public static void AddFix1Max(FlatBufferBuilder builder, int Fix1Max)
		{
			builder.AddInt(6, Fix1Max, 0);
		}

		// Token: 0x060030FB RID: 12539 RVA: 0x000AEF19 File Offset: 0x000AD319
		public static void AddFix2(FlatBufferBuilder builder, int Fix2)
		{
			builder.AddInt(7, Fix2, 0);
		}

		// Token: 0x060030FC RID: 12540 RVA: 0x000AEF24 File Offset: 0x000AD324
		public static void AddFix2Max(FlatBufferBuilder builder, int Fix2Max)
		{
			builder.AddInt(8, Fix2Max, 0);
		}

		// Token: 0x060030FD RID: 12541 RVA: 0x000AEF2F File Offset: 0x000AD32F
		public static void AddFix3Condition(FlatBufferBuilder builder, VectorOffset Fix3ConditionOffset)
		{
			builder.AddOffset(9, Fix3ConditionOffset.Value, 0);
		}

		// Token: 0x060030FE RID: 12542 RVA: 0x000AEF44 File Offset: 0x000AD344
		public static VectorOffset CreateFix3ConditionVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060030FF RID: 12543 RVA: 0x000AEF81 File Offset: 0x000AD381
		public static void StartFix3ConditionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003100 RID: 12544 RVA: 0x000AEF8C File Offset: 0x000AD38C
		public static void AddFix3(FlatBufferBuilder builder, int Fix3)
		{
			builder.AddInt(10, Fix3, 0);
		}

		// Token: 0x06003101 RID: 12545 RVA: 0x000AEF98 File Offset: 0x000AD398
		public static void AddTickAddNum(FlatBufferBuilder builder, int TickAddNum)
		{
			builder.AddInt(11, TickAddNum, 0);
		}

		// Token: 0x06003102 RID: 12546 RVA: 0x000AEFA4 File Offset: 0x000AD3A4
		public static Offset<EquipStrRateTable> EndEquipStrRateTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipStrRateTable>(value);
		}

		// Token: 0x06003103 RID: 12547 RVA: 0x000AEFBE File Offset: 0x000AD3BE
		public static void FinishEquipStrRateTableBuffer(FlatBufferBuilder builder, Offset<EquipStrRateTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400144B RID: 5195
		private Table __p = new Table();

		// Token: 0x0400144C RID: 5196
		private FlatBufferArray<int> SucRateValue;

		// Token: 0x0400144D RID: 5197
		private FlatBufferArray<int> Fix3ConditionValue;

		// Token: 0x0200040F RID: 1039
		public enum eFail
		{
			// Token: 0x0400144F RID: 5199
			NONE,
			// Token: 0x04001450 RID: 5200
			MINUSONE,
			// Token: 0x04001451 RID: 5201
			ZERO,
			// Token: 0x04001452 RID: 5202
			BROKEN,
			// Token: 0x04001453 RID: 5203
			MINUSMORE
		}

		// Token: 0x02000410 RID: 1040
		public enum eCrypt
		{
			// Token: 0x04001455 RID: 5205
			code = -499643615
		}
	}
}
