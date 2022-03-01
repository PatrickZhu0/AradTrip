using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000550 RID: 1360
	public class PetTable : IFlatbufferObject
	{
		// Token: 0x170012D5 RID: 4821
		// (get) Token: 0x0600461D RID: 17949 RVA: 0x000E0BAC File Offset: 0x000DEFAC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600461E RID: 17950 RVA: 0x000E0BB9 File Offset: 0x000DEFB9
		public static PetTable GetRootAsPetTable(ByteBuffer _bb)
		{
			return PetTable.GetRootAsPetTable(_bb, new PetTable());
		}

		// Token: 0x0600461F RID: 17951 RVA: 0x000E0BC6 File Offset: 0x000DEFC6
		public static PetTable GetRootAsPetTable(ByteBuffer _bb, PetTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004620 RID: 17952 RVA: 0x000E0BE2 File Offset: 0x000DEFE2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004621 RID: 17953 RVA: 0x000E0BFC File Offset: 0x000DEFFC
		public PetTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170012D6 RID: 4822
		// (get) Token: 0x06004622 RID: 17954 RVA: 0x000E0C08 File Offset: 0x000DF008
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012D7 RID: 4823
		// (get) Token: 0x06004623 RID: 17955 RVA: 0x000E0C54 File Offset: 0x000DF054
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004624 RID: 17956 RVA: 0x000E0C96 File Offset: 0x000DF096
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170012D8 RID: 4824
		// (get) Token: 0x06004625 RID: 17957 RVA: 0x000E0CA4 File Offset: 0x000DF0A4
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004626 RID: 17958 RVA: 0x000E0CE6 File Offset: 0x000DF0E6
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170012D9 RID: 4825
		// (get) Token: 0x06004627 RID: 17959 RVA: 0x000E0CF4 File Offset: 0x000DF0F4
		public PetTable.ePetType PetType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (PetTable.ePetType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012DA RID: 4826
		// (get) Token: 0x06004628 RID: 17960 RVA: 0x000E0D38 File Offset: 0x000DF138
		public PetTable.eQuality Quality
		{
			get
			{
				int num = this.__p.__offset(12);
				return (PetTable.eQuality)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012DB RID: 4827
		// (get) Token: 0x06004629 RID: 17961 RVA: 0x000E0D7C File Offset: 0x000DF17C
		public int MaxLv
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012DC RID: 4828
		// (get) Token: 0x0600462A RID: 17962 RVA: 0x000E0DC8 File Offset: 0x000DF1C8
		public int InnateSkill
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600462B RID: 17963 RVA: 0x000E0E14 File Offset: 0x000DF214
		public int SkillsArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170012DD RID: 4829
		// (get) Token: 0x0600462C RID: 17964 RVA: 0x000E0E64 File Offset: 0x000DF264
		public int SkillsLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600462D RID: 17965 RVA: 0x000E0E97 File Offset: 0x000DF297
		public ArraySegment<byte>? GetSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170012DE RID: 4830
		// (get) Token: 0x0600462E RID: 17966 RVA: 0x000E0EA6 File Offset: 0x000DF2A6
		public FlatBufferArray<int> Skills
		{
			get
			{
				if (this.SkillsValue == null)
				{
					this.SkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.SkillsArray), this.SkillsLength);
				}
				return this.SkillsValue;
			}
		}

		// Token: 0x170012DF RID: 4831
		// (get) Token: 0x0600462F RID: 17967 RVA: 0x000E0ED8 File Offset: 0x000DF2D8
		public int PetEggID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E0 RID: 4832
		// (get) Token: 0x06004630 RID: 17968 RVA: 0x000E0F24 File Offset: 0x000DF324
		public int ToDevourExp
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E1 RID: 4833
		// (get) Token: 0x06004631 RID: 17969 RVA: 0x000E0F70 File Offset: 0x000DF370
		public int MonsterID
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E2 RID: 4834
		// (get) Token: 0x06004632 RID: 17970 RVA: 0x000E0FBC File Offset: 0x000DF3BC
		public int ModeID
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E3 RID: 4835
		// (get) Token: 0x06004633 RID: 17971 RVA: 0x000E1008 File Offset: 0x000DF408
		public int ChangedHeight
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E4 RID: 4836
		// (get) Token: 0x06004634 RID: 17972 RVA: 0x000E1054 File Offset: 0x000DF454
		public int OpenEggHeight
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E5 RID: 4837
		// (get) Token: 0x06004635 RID: 17973 RVA: 0x000E10A0 File Offset: 0x000DF4A0
		public int ModelOrientation
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E6 RID: 4838
		// (get) Token: 0x06004636 RID: 17974 RVA: 0x000E10EC File Offset: 0x000DF4EC
		public int OpenEggRotation
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012E7 RID: 4839
		// (get) Token: 0x06004637 RID: 17975 RVA: 0x000E1138 File Offset: 0x000DF538
		public string OpenEggAction
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004638 RID: 17976 RVA: 0x000E117B File Offset: 0x000DF57B
		public ArraySegment<byte>? GetOpenEggActionBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x06004639 RID: 17977 RVA: 0x000E118C File Offset: 0x000DF58C
		public int OpenEggModelScaleArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170012E8 RID: 4840
		// (get) Token: 0x0600463A RID: 17978 RVA: 0x000E11DC File Offset: 0x000DF5DC
		public int OpenEggModelScaleLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600463B RID: 17979 RVA: 0x000E120F File Offset: 0x000DF60F
		public ArraySegment<byte>? GetOpenEggModelScaleBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170012E9 RID: 4841
		// (get) Token: 0x0600463C RID: 17980 RVA: 0x000E121E File Offset: 0x000DF61E
		public FlatBufferArray<int> OpenEggModelScale
		{
			get
			{
				if (this.OpenEggModelScaleValue == null)
				{
					this.OpenEggModelScaleValue = new FlatBufferArray<int>(new Func<int, int>(this.OpenEggModelScaleArray), this.OpenEggModelScaleLength);
				}
				return this.OpenEggModelScaleValue;
			}
		}

		// Token: 0x170012EA RID: 4842
		// (get) Token: 0x0600463D RID: 17981 RVA: 0x000E1250 File Offset: 0x000DF650
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600463E RID: 17982 RVA: 0x000E1293 File Offset: 0x000DF693
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170012EB RID: 4843
		// (get) Token: 0x0600463F RID: 17983 RVA: 0x000E12A4 File Offset: 0x000DF6A4
		public int HungryDialogID
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012EC RID: 4844
		// (get) Token: 0x06004640 RID: 17984 RVA: 0x000E12F0 File Offset: 0x000DF6F0
		public int FeedDialogID
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012ED RID: 4845
		// (get) Token: 0x06004641 RID: 17985 RVA: 0x000E133C File Offset: 0x000DF73C
		public int LowLevelDialogID
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012EE RID: 4846
		// (get) Token: 0x06004642 RID: 17986 RVA: 0x000E1388 File Offset: 0x000DF788
		public int HighLevelDialogID
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012EF RID: 4847
		// (get) Token: 0x06004643 RID: 17987 RVA: 0x000E13D4 File Offset: 0x000DF7D4
		public int PetModelSize
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012F0 RID: 4848
		// (get) Token: 0x06004644 RID: 17988 RVA: 0x000E1420 File Offset: 0x000DF820
		public int PetDialogLocation
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012F1 RID: 4849
		// (get) Token: 0x06004645 RID: 17989 RVA: 0x000E146C File Offset: 0x000DF86C
		public int MaxLevelScore
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (483311095 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004646 RID: 17990 RVA: 0x000E14B8 File Offset: 0x000DF8B8
		public static Offset<PetTable> CreatePetTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), PetTable.ePetType PetType = PetTable.ePetType.PT_NONE, PetTable.eQuality Quality = PetTable.eQuality.QL_NONE, int MaxLv = 0, int InnateSkill = 0, VectorOffset SkillsOffset = default(VectorOffset), int PetEggID = 0, int ToDevourExp = 0, int MonsterID = 0, int ModeID = 0, int ChangedHeight = 0, int OpenEggHeight = 0, int ModelOrientation = 0, int OpenEggRotation = 0, StringOffset OpenEggActionOffset = default(StringOffset), VectorOffset OpenEggModelScaleOffset = default(VectorOffset), StringOffset IconPathOffset = default(StringOffset), int HungryDialogID = 0, int FeedDialogID = 0, int LowLevelDialogID = 0, int HighLevelDialogID = 0, int PetModelSize = 0, int PetDialogLocation = 0, int MaxLevelScore = 0)
		{
			builder.StartObject(26);
			PetTable.AddMaxLevelScore(builder, MaxLevelScore);
			PetTable.AddPetDialogLocation(builder, PetDialogLocation);
			PetTable.AddPetModelSize(builder, PetModelSize);
			PetTable.AddHighLevelDialogID(builder, HighLevelDialogID);
			PetTable.AddLowLevelDialogID(builder, LowLevelDialogID);
			PetTable.AddFeedDialogID(builder, FeedDialogID);
			PetTable.AddHungryDialogID(builder, HungryDialogID);
			PetTable.AddIconPath(builder, IconPathOffset);
			PetTable.AddOpenEggModelScale(builder, OpenEggModelScaleOffset);
			PetTable.AddOpenEggAction(builder, OpenEggActionOffset);
			PetTable.AddOpenEggRotation(builder, OpenEggRotation);
			PetTable.AddModelOrientation(builder, ModelOrientation);
			PetTable.AddOpenEggHeight(builder, OpenEggHeight);
			PetTable.AddChangedHeight(builder, ChangedHeight);
			PetTable.AddModeID(builder, ModeID);
			PetTable.AddMonsterID(builder, MonsterID);
			PetTable.AddToDevourExp(builder, ToDevourExp);
			PetTable.AddPetEggID(builder, PetEggID);
			PetTable.AddSkills(builder, SkillsOffset);
			PetTable.AddInnateSkill(builder, InnateSkill);
			PetTable.AddMaxLv(builder, MaxLv);
			PetTable.AddQuality(builder, Quality);
			PetTable.AddPetType(builder, PetType);
			PetTable.AddDesc(builder, DescOffset);
			PetTable.AddName(builder, NameOffset);
			PetTable.AddID(builder, ID);
			return PetTable.EndPetTable(builder);
		}

		// Token: 0x06004647 RID: 17991 RVA: 0x000E15A0 File Offset: 0x000DF9A0
		public static void StartPetTable(FlatBufferBuilder builder)
		{
			builder.StartObject(26);
		}

		// Token: 0x06004648 RID: 17992 RVA: 0x000E15AA File Offset: 0x000DF9AA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004649 RID: 17993 RVA: 0x000E15B5 File Offset: 0x000DF9B5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600464A RID: 17994 RVA: 0x000E15C6 File Offset: 0x000DF9C6
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(2, DescOffset.Value, 0);
		}

		// Token: 0x0600464B RID: 17995 RVA: 0x000E15D7 File Offset: 0x000DF9D7
		public static void AddPetType(FlatBufferBuilder builder, PetTable.ePetType PetType)
		{
			builder.AddInt(3, (int)PetType, 0);
		}

		// Token: 0x0600464C RID: 17996 RVA: 0x000E15E2 File Offset: 0x000DF9E2
		public static void AddQuality(FlatBufferBuilder builder, PetTable.eQuality Quality)
		{
			builder.AddInt(4, (int)Quality, 0);
		}

		// Token: 0x0600464D RID: 17997 RVA: 0x000E15ED File Offset: 0x000DF9ED
		public static void AddMaxLv(FlatBufferBuilder builder, int MaxLv)
		{
			builder.AddInt(5, MaxLv, 0);
		}

		// Token: 0x0600464E RID: 17998 RVA: 0x000E15F8 File Offset: 0x000DF9F8
		public static void AddInnateSkill(FlatBufferBuilder builder, int InnateSkill)
		{
			builder.AddInt(6, InnateSkill, 0);
		}

		// Token: 0x0600464F RID: 17999 RVA: 0x000E1603 File Offset: 0x000DFA03
		public static void AddSkills(FlatBufferBuilder builder, VectorOffset SkillsOffset)
		{
			builder.AddOffset(7, SkillsOffset.Value, 0);
		}

		// Token: 0x06004650 RID: 18000 RVA: 0x000E1614 File Offset: 0x000DFA14
		public static VectorOffset CreateSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004651 RID: 18001 RVA: 0x000E1651 File Offset: 0x000DFA51
		public static void StartSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004652 RID: 18002 RVA: 0x000E165C File Offset: 0x000DFA5C
		public static void AddPetEggID(FlatBufferBuilder builder, int PetEggID)
		{
			builder.AddInt(8, PetEggID, 0);
		}

		// Token: 0x06004653 RID: 18003 RVA: 0x000E1667 File Offset: 0x000DFA67
		public static void AddToDevourExp(FlatBufferBuilder builder, int ToDevourExp)
		{
			builder.AddInt(9, ToDevourExp, 0);
		}

		// Token: 0x06004654 RID: 18004 RVA: 0x000E1673 File Offset: 0x000DFA73
		public static void AddMonsterID(FlatBufferBuilder builder, int MonsterID)
		{
			builder.AddInt(10, MonsterID, 0);
		}

		// Token: 0x06004655 RID: 18005 RVA: 0x000E167F File Offset: 0x000DFA7F
		public static void AddModeID(FlatBufferBuilder builder, int ModeID)
		{
			builder.AddInt(11, ModeID, 0);
		}

		// Token: 0x06004656 RID: 18006 RVA: 0x000E168B File Offset: 0x000DFA8B
		public static void AddChangedHeight(FlatBufferBuilder builder, int ChangedHeight)
		{
			builder.AddInt(12, ChangedHeight, 0);
		}

		// Token: 0x06004657 RID: 18007 RVA: 0x000E1697 File Offset: 0x000DFA97
		public static void AddOpenEggHeight(FlatBufferBuilder builder, int OpenEggHeight)
		{
			builder.AddInt(13, OpenEggHeight, 0);
		}

		// Token: 0x06004658 RID: 18008 RVA: 0x000E16A3 File Offset: 0x000DFAA3
		public static void AddModelOrientation(FlatBufferBuilder builder, int ModelOrientation)
		{
			builder.AddInt(14, ModelOrientation, 0);
		}

		// Token: 0x06004659 RID: 18009 RVA: 0x000E16AF File Offset: 0x000DFAAF
		public static void AddOpenEggRotation(FlatBufferBuilder builder, int OpenEggRotation)
		{
			builder.AddInt(15, OpenEggRotation, 0);
		}

		// Token: 0x0600465A RID: 18010 RVA: 0x000E16BB File Offset: 0x000DFABB
		public static void AddOpenEggAction(FlatBufferBuilder builder, StringOffset OpenEggActionOffset)
		{
			builder.AddOffset(16, OpenEggActionOffset.Value, 0);
		}

		// Token: 0x0600465B RID: 18011 RVA: 0x000E16CD File Offset: 0x000DFACD
		public static void AddOpenEggModelScale(FlatBufferBuilder builder, VectorOffset OpenEggModelScaleOffset)
		{
			builder.AddOffset(17, OpenEggModelScaleOffset.Value, 0);
		}

		// Token: 0x0600465C RID: 18012 RVA: 0x000E16E0 File Offset: 0x000DFAE0
		public static VectorOffset CreateOpenEggModelScaleVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600465D RID: 18013 RVA: 0x000E171D File Offset: 0x000DFB1D
		public static void StartOpenEggModelScaleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600465E RID: 18014 RVA: 0x000E1728 File Offset: 0x000DFB28
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(18, IconPathOffset.Value, 0);
		}

		// Token: 0x0600465F RID: 18015 RVA: 0x000E173A File Offset: 0x000DFB3A
		public static void AddHungryDialogID(FlatBufferBuilder builder, int HungryDialogID)
		{
			builder.AddInt(19, HungryDialogID, 0);
		}

		// Token: 0x06004660 RID: 18016 RVA: 0x000E1746 File Offset: 0x000DFB46
		public static void AddFeedDialogID(FlatBufferBuilder builder, int FeedDialogID)
		{
			builder.AddInt(20, FeedDialogID, 0);
		}

		// Token: 0x06004661 RID: 18017 RVA: 0x000E1752 File Offset: 0x000DFB52
		public static void AddLowLevelDialogID(FlatBufferBuilder builder, int LowLevelDialogID)
		{
			builder.AddInt(21, LowLevelDialogID, 0);
		}

		// Token: 0x06004662 RID: 18018 RVA: 0x000E175E File Offset: 0x000DFB5E
		public static void AddHighLevelDialogID(FlatBufferBuilder builder, int HighLevelDialogID)
		{
			builder.AddInt(22, HighLevelDialogID, 0);
		}

		// Token: 0x06004663 RID: 18019 RVA: 0x000E176A File Offset: 0x000DFB6A
		public static void AddPetModelSize(FlatBufferBuilder builder, int PetModelSize)
		{
			builder.AddInt(23, PetModelSize, 0);
		}

		// Token: 0x06004664 RID: 18020 RVA: 0x000E1776 File Offset: 0x000DFB76
		public static void AddPetDialogLocation(FlatBufferBuilder builder, int PetDialogLocation)
		{
			builder.AddInt(24, PetDialogLocation, 0);
		}

		// Token: 0x06004665 RID: 18021 RVA: 0x000E1782 File Offset: 0x000DFB82
		public static void AddMaxLevelScore(FlatBufferBuilder builder, int MaxLevelScore)
		{
			builder.AddInt(25, MaxLevelScore, 0);
		}

		// Token: 0x06004666 RID: 18022 RVA: 0x000E1790 File Offset: 0x000DFB90
		public static Offset<PetTable> EndPetTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PetTable>(value);
		}

		// Token: 0x06004667 RID: 18023 RVA: 0x000E17AA File Offset: 0x000DFBAA
		public static void FinishPetTableBuffer(FlatBufferBuilder builder, Offset<PetTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A06 RID: 6662
		private Table __p = new Table();

		// Token: 0x04001A07 RID: 6663
		private FlatBufferArray<int> SkillsValue;

		// Token: 0x04001A08 RID: 6664
		private FlatBufferArray<int> OpenEggModelScaleValue;

		// Token: 0x02000551 RID: 1361
		public enum ePetType
		{
			// Token: 0x04001A0A RID: 6666
			PT_NONE,
			// Token: 0x04001A0B RID: 6667
			PT_ATTACK,
			// Token: 0x04001A0C RID: 6668
			PT_PROPERTY,
			// Token: 0x04001A0D RID: 6669
			PT_SUPPORT
		}

		// Token: 0x02000552 RID: 1362
		public enum eQuality
		{
			// Token: 0x04001A0F RID: 6671
			QL_NONE,
			// Token: 0x04001A10 RID: 6672
			QL_WHITE,
			// Token: 0x04001A11 RID: 6673
			QL_BLUE,
			// Token: 0x04001A12 RID: 6674
			QL_PURPLE,
			// Token: 0x04001A13 RID: 6675
			QL_GREEN,
			// Token: 0x04001A14 RID: 6676
			QL_PINK,
			// Token: 0x04001A15 RID: 6677
			QL_YELLOW
		}

		// Token: 0x02000553 RID: 1363
		public enum eCrypt
		{
			// Token: 0x04001A17 RID: 6679
			code = 483311095
		}
	}
}
