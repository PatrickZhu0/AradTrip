using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003D9 RID: 985
	public class EquipBaseScoreTable : IFlatbufferObject
	{
		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x06002CD6 RID: 11478 RVA: 0x000A51E0 File Offset: 0x000A35E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002CD7 RID: 11479 RVA: 0x000A51ED File Offset: 0x000A35ED
		public static EquipBaseScoreTable GetRootAsEquipBaseScoreTable(ByteBuffer _bb)
		{
			return EquipBaseScoreTable.GetRootAsEquipBaseScoreTable(_bb, new EquipBaseScoreTable());
		}

		// Token: 0x06002CD8 RID: 11480 RVA: 0x000A51FA File Offset: 0x000A35FA
		public static EquipBaseScoreTable GetRootAsEquipBaseScoreTable(ByteBuffer _bb, EquipBaseScoreTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002CD9 RID: 11481 RVA: 0x000A5216 File Offset: 0x000A3616
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002CDA RID: 11482 RVA: 0x000A5230 File Offset: 0x000A3630
		public EquipBaseScoreTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x06002CDB RID: 11483 RVA: 0x000A523C File Offset: 0x000A363C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x06002CDC RID: 11484 RVA: 0x000A5288 File Offset: 0x000A3688
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x06002CDD RID: 11485 RVA: 0x000A52D4 File Offset: 0x000A36D4
		public int SubType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A9F RID: 2719
		// (get) Token: 0x06002CDE RID: 11486 RVA: 0x000A5320 File Offset: 0x000A3720
		public int ThirdType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x06002CDF RID: 11487 RVA: 0x000A536C File Offset: 0x000A376C
		public int NeedLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x06002CE0 RID: 11488 RVA: 0x000A53B8 File Offset: 0x000A37B8
		public int Color
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x06002CE1 RID: 11489 RVA: 0x000A5404 File Offset: 0x000A3804
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x06002CE2 RID: 11490 RVA: 0x000A5450 File Offset: 0x000A3850
		public int SuitId
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x06002CE3 RID: 11491 RVA: 0x000A549C File Offset: 0x000A389C
		public int Score
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1655327513 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002CE4 RID: 11492 RVA: 0x000A54E8 File Offset: 0x000A38E8
		public static Offset<EquipBaseScoreTable> CreateEquipBaseScoreTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int SubType = 0, int ThirdType = 0, int NeedLevel = 0, int Color = 0, int Color2 = 0, int SuitId = 0, int Score = 0)
		{
			builder.StartObject(9);
			EquipBaseScoreTable.AddScore(builder, Score);
			EquipBaseScoreTable.AddSuitId(builder, SuitId);
			EquipBaseScoreTable.AddColor2(builder, Color2);
			EquipBaseScoreTable.AddColor(builder, Color);
			EquipBaseScoreTable.AddNeedLevel(builder, NeedLevel);
			EquipBaseScoreTable.AddThirdType(builder, ThirdType);
			EquipBaseScoreTable.AddSubType(builder, SubType);
			EquipBaseScoreTable.AddType(builder, Type);
			EquipBaseScoreTable.AddID(builder, ID);
			return EquipBaseScoreTable.EndEquipBaseScoreTable(builder);
		}

		// Token: 0x06002CE5 RID: 11493 RVA: 0x000A5548 File Offset: 0x000A3948
		public static void StartEquipBaseScoreTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06002CE6 RID: 11494 RVA: 0x000A5552 File Offset: 0x000A3952
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002CE7 RID: 11495 RVA: 0x000A555D File Offset: 0x000A395D
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x06002CE8 RID: 11496 RVA: 0x000A5568 File Offset: 0x000A3968
		public static void AddSubType(FlatBufferBuilder builder, int SubType)
		{
			builder.AddInt(2, SubType, 0);
		}

		// Token: 0x06002CE9 RID: 11497 RVA: 0x000A5573 File Offset: 0x000A3973
		public static void AddThirdType(FlatBufferBuilder builder, int ThirdType)
		{
			builder.AddInt(3, ThirdType, 0);
		}

		// Token: 0x06002CEA RID: 11498 RVA: 0x000A557E File Offset: 0x000A397E
		public static void AddNeedLevel(FlatBufferBuilder builder, int NeedLevel)
		{
			builder.AddInt(4, NeedLevel, 0);
		}

		// Token: 0x06002CEB RID: 11499 RVA: 0x000A5589 File Offset: 0x000A3989
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(5, Color, 0);
		}

		// Token: 0x06002CEC RID: 11500 RVA: 0x000A5594 File Offset: 0x000A3994
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(6, Color2, 0);
		}

		// Token: 0x06002CED RID: 11501 RVA: 0x000A559F File Offset: 0x000A399F
		public static void AddSuitId(FlatBufferBuilder builder, int SuitId)
		{
			builder.AddInt(7, SuitId, 0);
		}

		// Token: 0x06002CEE RID: 11502 RVA: 0x000A55AA File Offset: 0x000A39AA
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(8, Score, 0);
		}

		// Token: 0x06002CEF RID: 11503 RVA: 0x000A55B8 File Offset: 0x000A39B8
		public static Offset<EquipBaseScoreTable> EndEquipBaseScoreTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipBaseScoreTable>(value);
		}

		// Token: 0x06002CF0 RID: 11504 RVA: 0x000A55D2 File Offset: 0x000A39D2
		public static void FinishEquipBaseScoreTableBuffer(FlatBufferBuilder builder, Offset<EquipBaseScoreTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400132C RID: 4908
		private Table __p = new Table();

		// Token: 0x020003DA RID: 986
		public enum eCrypt
		{
			// Token: 0x0400132E RID: 4910
			code = -1655327513
		}
	}
}
