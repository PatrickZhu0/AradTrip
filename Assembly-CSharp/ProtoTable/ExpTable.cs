using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200041D RID: 1053
	public class ExpTable : IFlatbufferObject
	{
		// Token: 0x17000C32 RID: 3122
		// (get) Token: 0x06003221 RID: 12833 RVA: 0x000B1B1C File Offset: 0x000AFF1C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003222 RID: 12834 RVA: 0x000B1B29 File Offset: 0x000AFF29
		public static ExpTable GetRootAsExpTable(ByteBuffer _bb)
		{
			return ExpTable.GetRootAsExpTable(_bb, new ExpTable());
		}

		// Token: 0x06003223 RID: 12835 RVA: 0x000B1B36 File Offset: 0x000AFF36
		public static ExpTable GetRootAsExpTable(ByteBuffer _bb, ExpTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003224 RID: 12836 RVA: 0x000B1B52 File Offset: 0x000AFF52
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003225 RID: 12837 RVA: 0x000B1B6C File Offset: 0x000AFF6C
		public ExpTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C33 RID: 3123
		// (get) Token: 0x06003226 RID: 12838 RVA: 0x000B1B78 File Offset: 0x000AFF78
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C34 RID: 3124
		// (get) Token: 0x06003227 RID: 12839 RVA: 0x000B1BC4 File Offset: 0x000AFFC4
		public int TotalExp
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C35 RID: 3125
		// (get) Token: 0x06003228 RID: 12840 RVA: 0x000B1C10 File Offset: 0x000B0010
		public int Sp
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C36 RID: 3126
		// (get) Token: 0x06003229 RID: 12841 RVA: 0x000B1C5C File Offset: 0x000B005C
		public int SkillNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C37 RID: 3127
		// (get) Token: 0x0600322A RID: 12842 RVA: 0x000B1CA8 File Offset: 0x000B00A8
		public int DailyTaskSelector
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C38 RID: 3128
		// (get) Token: 0x0600322B RID: 12843 RVA: 0x000B1CF4 File Offset: 0x000B00F4
		public int RetinueNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C39 RID: 3129
		// (get) Token: 0x0600322C RID: 12844 RVA: 0x000B1D40 File Offset: 0x000B0140
		public int SpLeft
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C3A RID: 3130
		// (get) Token: 0x0600322D RID: 12845 RVA: 0x000B1D8C File Offset: 0x000B018C
		public int SpPvp
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C3B RID: 3131
		// (get) Token: 0x0600322E RID: 12846 RVA: 0x000B1DD8 File Offset: 0x000B01D8
		public int AdventureTeamExpAddition
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C3C RID: 3132
		// (get) Token: 0x0600322F RID: 12847 RVA: 0x000B1E24 File Offset: 0x000B0224
		public int Score
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C3D RID: 3133
		// (get) Token: 0x06003230 RID: 12848 RVA: 0x000B1E70 File Offset: 0x000B0270
		public int CreditPointMonthGetNum
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C3E RID: 3134
		// (get) Token: 0x06003231 RID: 12849 RVA: 0x000B1EBC File Offset: 0x000B02BC
		public int CreditPointOwnNum
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C3F RID: 3135
		// (get) Token: 0x06003232 RID: 12850 RVA: 0x000B1F08 File Offset: 0x000B0308
		public int CreditPointMonthConversionNum
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (487311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003233 RID: 12851 RVA: 0x000B1F54 File Offset: 0x000B0354
		public static Offset<ExpTable> CreateExpTable(FlatBufferBuilder builder, int ID = 0, int TotalExp = 0, int Sp = 0, int SkillNum = 0, int DailyTaskSelector = 0, int RetinueNum = 0, int SpLeft = 0, int SpPvp = 0, int AdventureTeamExpAddition = 0, int Score = 0, int CreditPointMonthGetNum = 0, int CreditPointOwnNum = 0, int CreditPointMonthConversionNum = 0)
		{
			builder.StartObject(13);
			ExpTable.AddCreditPointMonthConversionNum(builder, CreditPointMonthConversionNum);
			ExpTable.AddCreditPointOwnNum(builder, CreditPointOwnNum);
			ExpTable.AddCreditPointMonthGetNum(builder, CreditPointMonthGetNum);
			ExpTable.AddScore(builder, Score);
			ExpTable.AddAdventureTeamExpAddition(builder, AdventureTeamExpAddition);
			ExpTable.AddSpPvp(builder, SpPvp);
			ExpTable.AddSpLeft(builder, SpLeft);
			ExpTable.AddRetinueNum(builder, RetinueNum);
			ExpTable.AddDailyTaskSelector(builder, DailyTaskSelector);
			ExpTable.AddSkillNum(builder, SkillNum);
			ExpTable.AddSp(builder, Sp);
			ExpTable.AddTotalExp(builder, TotalExp);
			ExpTable.AddID(builder, ID);
			return ExpTable.EndExpTable(builder);
		}

		// Token: 0x06003234 RID: 12852 RVA: 0x000B1FD4 File Offset: 0x000B03D4
		public static void StartExpTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x06003235 RID: 12853 RVA: 0x000B1FDE File Offset: 0x000B03DE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003236 RID: 12854 RVA: 0x000B1FE9 File Offset: 0x000B03E9
		public static void AddTotalExp(FlatBufferBuilder builder, int TotalExp)
		{
			builder.AddInt(1, TotalExp, 0);
		}

		// Token: 0x06003237 RID: 12855 RVA: 0x000B1FF4 File Offset: 0x000B03F4
		public static void AddSp(FlatBufferBuilder builder, int Sp)
		{
			builder.AddInt(2, Sp, 0);
		}

		// Token: 0x06003238 RID: 12856 RVA: 0x000B1FFF File Offset: 0x000B03FF
		public static void AddSkillNum(FlatBufferBuilder builder, int SkillNum)
		{
			builder.AddInt(3, SkillNum, 0);
		}

		// Token: 0x06003239 RID: 12857 RVA: 0x000B200A File Offset: 0x000B040A
		public static void AddDailyTaskSelector(FlatBufferBuilder builder, int DailyTaskSelector)
		{
			builder.AddInt(4, DailyTaskSelector, 0);
		}

		// Token: 0x0600323A RID: 12858 RVA: 0x000B2015 File Offset: 0x000B0415
		public static void AddRetinueNum(FlatBufferBuilder builder, int RetinueNum)
		{
			builder.AddInt(5, RetinueNum, 0);
		}

		// Token: 0x0600323B RID: 12859 RVA: 0x000B2020 File Offset: 0x000B0420
		public static void AddSpLeft(FlatBufferBuilder builder, int SpLeft)
		{
			builder.AddInt(6, SpLeft, 0);
		}

		// Token: 0x0600323C RID: 12860 RVA: 0x000B202B File Offset: 0x000B042B
		public static void AddSpPvp(FlatBufferBuilder builder, int SpPvp)
		{
			builder.AddInt(7, SpPvp, 0);
		}

		// Token: 0x0600323D RID: 12861 RVA: 0x000B2036 File Offset: 0x000B0436
		public static void AddAdventureTeamExpAddition(FlatBufferBuilder builder, int AdventureTeamExpAddition)
		{
			builder.AddInt(8, AdventureTeamExpAddition, 0);
		}

		// Token: 0x0600323E RID: 12862 RVA: 0x000B2041 File Offset: 0x000B0441
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(9, Score, 0);
		}

		// Token: 0x0600323F RID: 12863 RVA: 0x000B204D File Offset: 0x000B044D
		public static void AddCreditPointMonthGetNum(FlatBufferBuilder builder, int CreditPointMonthGetNum)
		{
			builder.AddInt(10, CreditPointMonthGetNum, 0);
		}

		// Token: 0x06003240 RID: 12864 RVA: 0x000B2059 File Offset: 0x000B0459
		public static void AddCreditPointOwnNum(FlatBufferBuilder builder, int CreditPointOwnNum)
		{
			builder.AddInt(11, CreditPointOwnNum, 0);
		}

		// Token: 0x06003241 RID: 12865 RVA: 0x000B2065 File Offset: 0x000B0465
		public static void AddCreditPointMonthConversionNum(FlatBufferBuilder builder, int CreditPointMonthConversionNum)
		{
			builder.AddInt(12, CreditPointMonthConversionNum, 0);
		}

		// Token: 0x06003242 RID: 12866 RVA: 0x000B2074 File Offset: 0x000B0474
		public static Offset<ExpTable> EndExpTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ExpTable>(value);
		}

		// Token: 0x06003243 RID: 12867 RVA: 0x000B208E File Offset: 0x000B048E
		public static void FinishExpTableBuffer(FlatBufferBuilder builder, Offset<ExpTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014BD RID: 5309
		private Table __p = new Table();

		// Token: 0x0200041E RID: 1054
		public enum eCrypt
		{
			// Token: 0x040014BF RID: 5311
			code = 487311095
		}
	}
}
