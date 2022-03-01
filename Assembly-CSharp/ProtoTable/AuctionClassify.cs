using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002B0 RID: 688
	public class AuctionClassify : IFlatbufferObject
	{
		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x0600188A RID: 6282 RVA: 0x00073AB0 File Offset: 0x00071EB0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600188B RID: 6283 RVA: 0x00073ABD File Offset: 0x00071EBD
		public static AuctionClassify GetRootAsAuctionClassify(ByteBuffer _bb)
		{
			return AuctionClassify.GetRootAsAuctionClassify(_bb, new AuctionClassify());
		}

		// Token: 0x0600188C RID: 6284 RVA: 0x00073ACA File Offset: 0x00071ECA
		public static AuctionClassify GetRootAsAuctionClassify(ByteBuffer _bb, AuctionClassify obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600188D RID: 6285 RVA: 0x00073AE6 File Offset: 0x00071EE6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600188E RID: 6286 RVA: 0x00073B00 File Offset: 0x00071F00
		public AuctionClassify __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x0600188F RID: 6287 RVA: 0x00073B0C File Offset: 0x00071F0C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1389355257 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06001890 RID: 6288 RVA: 0x00073B58 File Offset: 0x00071F58
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x00073B9A File Offset: 0x00071F9A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06001892 RID: 6290 RVA: 0x00073BA8 File Offset: 0x00071FA8
		public AuctionClassify.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (AuctionClassify.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06001893 RID: 6291 RVA: 0x00073BEC File Offset: 0x00071FEC
		public int IsFirstNode
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1389355257 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06001894 RID: 6292 RVA: 0x00073C38 File Offset: 0x00072038
		public AuctionClassify.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (AuctionClassify.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06001895 RID: 6293 RVA: 0x00073C7C File Offset: 0x0007207C
		public AuctionClassify.eThirdType ThirdType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (AuctionClassify.eThirdType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06001896 RID: 6294 RVA: 0x00073CC0 File Offset: 0x000720C0
		public AuctionClassify.eJob Job
		{
			get
			{
				int num = this.__p.__offset(16);
				return (AuctionClassify.eJob)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06001897 RID: 6295 RVA: 0x00073D04 File Offset: 0x00072104
		public AuctionClassify.eQuality Quality
		{
			get
			{
				int num = this.__p.__offset(18);
				return (AuctionClassify.eQuality)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06001898 RID: 6296 RVA: 0x00073D48 File Offset: 0x00072148
		public AuctionClassify.eSum Sum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (AuctionClassify.eSum)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x00073D8C File Offset: 0x0007218C
		public int ChildrenIDsArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (-1389355257 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x0600189A RID: 6298 RVA: 0x00073DDC File Offset: 0x000721DC
		public int ChildrenIDsLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x00073E0F File Offset: 0x0007220F
		public ArraySegment<byte>? GetChildrenIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x0600189C RID: 6300 RVA: 0x00073E1E File Offset: 0x0007221E
		public FlatBufferArray<int> ChildrenIDs
		{
			get
			{
				if (this.ChildrenIDsValue == null)
				{
					this.ChildrenIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.ChildrenIDsArray), this.ChildrenIDsLength);
				}
				return this.ChildrenIDsValue;
			}
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00073E50 File Offset: 0x00072250
		public static Offset<AuctionClassify> CreateAuctionClassify(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), AuctionClassify.eType Type = AuctionClassify.eType.AT_NONE, int IsFirstNode = 0, AuctionClassify.eSubType SubType = AuctionClassify.eSubType.AST_NONE, AuctionClassify.eThirdType ThirdType = AuctionClassify.eThirdType.ATT_NONE, AuctionClassify.eJob Job = AuctionClassify.eJob.AC_JIANSHI, AuctionClassify.eQuality Quality = AuctionClassify.eQuality.QL_NONE, AuctionClassify.eSum Sum = AuctionClassify.eSum.SUM_SINGLE, VectorOffset ChildrenIDsOffset = default(VectorOffset))
		{
			builder.StartObject(10);
			AuctionClassify.AddChildrenIDs(builder, ChildrenIDsOffset);
			AuctionClassify.AddSum(builder, Sum);
			AuctionClassify.AddQuality(builder, Quality);
			AuctionClassify.AddJob(builder, Job);
			AuctionClassify.AddThirdType(builder, ThirdType);
			AuctionClassify.AddSubType(builder, SubType);
			AuctionClassify.AddIsFirstNode(builder, IsFirstNode);
			AuctionClassify.AddType(builder, Type);
			AuctionClassify.AddName(builder, NameOffset);
			AuctionClassify.AddID(builder, ID);
			return AuctionClassify.EndAuctionClassify(builder);
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x00073EB8 File Offset: 0x000722B8
		public static void StartAuctionClassify(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x00073EC2 File Offset: 0x000722C2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x00073ECD File Offset: 0x000722CD
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x00073EDE File Offset: 0x000722DE
		public static void AddType(FlatBufferBuilder builder, AuctionClassify.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x00073EE9 File Offset: 0x000722E9
		public static void AddIsFirstNode(FlatBufferBuilder builder, int IsFirstNode)
		{
			builder.AddInt(3, IsFirstNode, 0);
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x00073EF4 File Offset: 0x000722F4
		public static void AddSubType(FlatBufferBuilder builder, AuctionClassify.eSubType SubType)
		{
			builder.AddInt(4, (int)SubType, 0);
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x00073EFF File Offset: 0x000722FF
		public static void AddThirdType(FlatBufferBuilder builder, AuctionClassify.eThirdType ThirdType)
		{
			builder.AddInt(5, (int)ThirdType, 0);
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x00073F0A File Offset: 0x0007230A
		public static void AddJob(FlatBufferBuilder builder, AuctionClassify.eJob Job)
		{
			builder.AddInt(6, (int)Job, 0);
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x00073F15 File Offset: 0x00072315
		public static void AddQuality(FlatBufferBuilder builder, AuctionClassify.eQuality Quality)
		{
			builder.AddInt(7, (int)Quality, 0);
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x00073F20 File Offset: 0x00072320
		public static void AddSum(FlatBufferBuilder builder, AuctionClassify.eSum Sum)
		{
			builder.AddInt(8, (int)Sum, 0);
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00073F2B File Offset: 0x0007232B
		public static void AddChildrenIDs(FlatBufferBuilder builder, VectorOffset ChildrenIDsOffset)
		{
			builder.AddOffset(9, ChildrenIDsOffset.Value, 0);
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x00073F40 File Offset: 0x00072340
		public static VectorOffset CreateChildrenIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060018AA RID: 6314 RVA: 0x00073F7D File Offset: 0x0007237D
		public static void StartChildrenIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060018AB RID: 6315 RVA: 0x00073F88 File Offset: 0x00072388
		public static Offset<AuctionClassify> EndAuctionClassify(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionClassify>(value);
		}

		// Token: 0x060018AC RID: 6316 RVA: 0x00073FA2 File Offset: 0x000723A2
		public static void FinishAuctionClassifyBuffer(FlatBufferBuilder builder, Offset<AuctionClassify> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E09 RID: 3593
		private Table __p = new Table();

		// Token: 0x04000E0A RID: 3594
		private FlatBufferArray<int> ChildrenIDsValue;

		// Token: 0x020002B1 RID: 689
		public enum eType
		{
			// Token: 0x04000E0C RID: 3596
			AT_NONE,
			// Token: 0x04000E0D RID: 3597
			AT_EQUIP,
			// Token: 0x04000E0E RID: 3598
			AT_DEFENCE,
			// Token: 0x04000E0F RID: 3599
			AT_JEWELRY,
			// Token: 0x04000E10 RID: 3600
			AT_ARMOR,
			// Token: 0x04000E11 RID: 3601
			AT_QUALITY,
			// Token: 0x04000E12 RID: 3602
			AT_EXPENDABLE,
			// Token: 0x04000E13 RID: 3603
			AT_MATERIAL
		}

		// Token: 0x020002B2 RID: 690
		public enum eSubType
		{
			// Token: 0x04000E15 RID: 3605
			AST_NONE,
			// Token: 0x04000E16 RID: 3606
			AST_WEAPON,
			// Token: 0x04000E17 RID: 3607
			AST_HEAD,
			// Token: 0x04000E18 RID: 3608
			AST_CHEST,
			// Token: 0x04000E19 RID: 3609
			AST_BELT,
			// Token: 0x04000E1A RID: 3610
			AST_LEG,
			// Token: 0x04000E1B RID: 3611
			AST_BOOT,
			// Token: 0x04000E1C RID: 3612
			AST_RING,
			// Token: 0x04000E1D RID: 3613
			AST_NECKLASE,
			// Token: 0x04000E1E RID: 3614
			AST_BRACELET,
			// Token: 0x04000E1F RID: 3615
			AST_TITLE,
			// Token: 0x04000E20 RID: 3616
			AST_EXP = 19,
			// Token: 0x04000E21 RID: 3617
			AST_EnchantmentCard = 25,
			// Token: 0x04000E22 RID: 3618
			AST_HP_DRUG = 50,
			// Token: 0x04000E23 RID: 3619
			AST_MP_DRUG,
			// Token: 0x04000E24 RID: 3620
			AST_BeadCard = 54,
			// Token: 0x04000E25 RID: 3621
			AttributeDrug = 62
		}

		// Token: 0x020002B3 RID: 691
		public enum eThirdType
		{
			// Token: 0x04000E27 RID: 3623
			ATT_NONE,
			// Token: 0x04000E28 RID: 3624
			ATT_HUGESWORD,
			// Token: 0x04000E29 RID: 3625
			ATT_KATANA,
			// Token: 0x04000E2A RID: 3626
			ATT_SHORTSWORD,
			// Token: 0x04000E2B RID: 3627
			ATT_BEAMSWORD,
			// Token: 0x04000E2C RID: 3628
			ATT_BLUNT,
			// Token: 0x04000E2D RID: 3629
			ATT_REVOLVER,
			// Token: 0x04000E2E RID: 3630
			ATT_CROSSBOW,
			// Token: 0x04000E2F RID: 3631
			ATT_HANDCANNON,
			// Token: 0x04000E30 RID: 3632
			ATT_RIFLE,
			// Token: 0x04000E31 RID: 3633
			ATT_PISTOL,
			// Token: 0x04000E32 RID: 3634
			ATT_STAFF,
			// Token: 0x04000E33 RID: 3635
			ATT_WAND,
			// Token: 0x04000E34 RID: 3636
			ATT_SPEAR,
			// Token: 0x04000E35 RID: 3637
			ATT_STICK,
			// Token: 0x04000E36 RID: 3638
			ATT_BESOM,
			// Token: 0x04000E37 RID: 3639
			ATT_GLOVE,
			// Token: 0x04000E38 RID: 3640
			ATT_BIKAI,
			// Token: 0x04000E39 RID: 3641
			ATT_CLAW,
			// Token: 0x04000E3A RID: 3642
			ATT_OFG,
			// Token: 0x04000E3B RID: 3643
			ATT_EAST_STICK,
			// Token: 0x04000E3C RID: 3644
			ATT_CLOTH = 51,
			// Token: 0x04000E3D RID: 3645
			ATT_SKIN,
			// Token: 0x04000E3E RID: 3646
			ATT_LIGHT,
			// Token: 0x04000E3F RID: 3647
			ATT_HEAVY,
			// Token: 0x04000E40 RID: 3648
			ATT_PLATE,
			// Token: 0x04000E41 RID: 3649
			ATT_BatteDrug = 401
		}

		// Token: 0x020002B4 RID: 692
		public enum eJob
		{
			// Token: 0x04000E43 RID: 3651
			AC_JIANSHI,
			// Token: 0x04000E44 RID: 3652
			AC_QIANGSHOU,
			// Token: 0x04000E45 RID: 3653
			AC_FASHI,
			// Token: 0x04000E46 RID: 3654
			AC_GEDOU,
			// Token: 0x04000E47 RID: 3655
			AC_JOB_ALL
		}

		// Token: 0x020002B5 RID: 693
		public enum eQuality
		{
			// Token: 0x04000E49 RID: 3657
			QL_NONE,
			// Token: 0x04000E4A RID: 3658
			QL_WHITE,
			// Token: 0x04000E4B RID: 3659
			QL_BLUE,
			// Token: 0x04000E4C RID: 3660
			QL_PURPLE,
			// Token: 0x04000E4D RID: 3661
			QL_GREEN,
			// Token: 0x04000E4E RID: 3662
			QL_PINK,
			// Token: 0x04000E4F RID: 3663
			QL_YELLOW,
			// Token: 0x04000E50 RID: 3664
			QL__ALL
		}

		// Token: 0x020002B6 RID: 694
		public enum eSum
		{
			// Token: 0x04000E52 RID: 3666
			SUM_SINGLE,
			// Token: 0x04000E53 RID: 3667
			SUM_ALL
		}

		// Token: 0x020002B7 RID: 695
		public enum eCrypt
		{
			// Token: 0x04000E55 RID: 3669
			code = -1389355257
		}
	}
}
