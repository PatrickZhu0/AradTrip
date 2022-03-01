using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002D2 RID: 722
	public class BeadTable : IFlatbufferObject
	{
		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x060019E9 RID: 6633 RVA: 0x00076AA4 File Offset: 0x00074EA4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060019EA RID: 6634 RVA: 0x00076AB1 File Offset: 0x00074EB1
		public static BeadTable GetRootAsBeadTable(ByteBuffer _bb)
		{
			return BeadTable.GetRootAsBeadTable(_bb, new BeadTable());
		}

		// Token: 0x060019EB RID: 6635 RVA: 0x00076ABE File Offset: 0x00074EBE
		public static BeadTable GetRootAsBeadTable(ByteBuffer _bb, BeadTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060019EC RID: 6636 RVA: 0x00076ADA File Offset: 0x00074EDA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x00076AF4 File Offset: 0x00074EF4
		public BeadTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x060019EE RID: 6638 RVA: 0x00076B00 File Offset: 0x00074F00
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x060019EF RID: 6639 RVA: 0x00076B4C File Offset: 0x00074F4C
		public int Color
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060019F0 RID: 6640 RVA: 0x00076B98 File Offset: 0x00074F98
		public int PartsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x060019F1 RID: 6641 RVA: 0x00076BE4 File Offset: 0x00074FE4
		public int PartsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060019F2 RID: 6642 RVA: 0x00076C16 File Offset: 0x00075016
		public ArraySegment<byte>? GetPartsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x060019F3 RID: 6643 RVA: 0x00076C24 File Offset: 0x00075024
		public FlatBufferArray<int> Parts
		{
			get
			{
				if (this.PartsValue == null)
				{
					this.PartsValue = new FlatBufferArray<int>(new Func<int, int>(this.PartsArray), this.PartsLength);
				}
				return this.PartsValue;
			}
		}

		// Token: 0x060019F4 RID: 6644 RVA: 0x00076C54 File Offset: 0x00075054
		public int PropTypeArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x060019F5 RID: 6645 RVA: 0x00076CA4 File Offset: 0x000750A4
		public int PropTypeLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060019F6 RID: 6646 RVA: 0x00076CD7 File Offset: 0x000750D7
		public ArraySegment<byte>? GetPropTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x060019F7 RID: 6647 RVA: 0x00076CE6 File Offset: 0x000750E6
		public FlatBufferArray<int> PropType
		{
			get
			{
				if (this.PropTypeValue == null)
				{
					this.PropTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.PropTypeArray), this.PropTypeLength);
				}
				return this.PropTypeValue;
			}
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x00076D18 File Offset: 0x00075118
		public int PropValueArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x060019F9 RID: 6649 RVA: 0x00076D68 File Offset: 0x00075168
		public int PropValueLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x00076D9B File Offset: 0x0007519B
		public ArraySegment<byte>? GetPropValueBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x060019FB RID: 6651 RVA: 0x00076DAA File Offset: 0x000751AA
		public FlatBufferArray<int> PropValue
		{
			get
			{
				if (this.PropValueValue == null)
				{
					this.PropValueValue = new FlatBufferArray<int>(new Func<int, int>(this.PropValueArray), this.PropValueLength);
				}
				return this.PropValueValue;
			}
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x00076DDC File Offset: 0x000751DC
		public int BuffInfoIDPveArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x060019FD RID: 6653 RVA: 0x00076E2C File Offset: 0x0007522C
		public int BuffInfoIDPveLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x00076E5F File Offset: 0x0007525F
		public ArraySegment<byte>? GetBuffInfoIDPveBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x060019FF RID: 6655 RVA: 0x00076E6E File Offset: 0x0007526E
		public FlatBufferArray<int> BuffInfoIDPve
		{
			get
			{
				if (this.BuffInfoIDPveValue == null)
				{
					this.BuffInfoIDPveValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffInfoIDPveArray), this.BuffInfoIDPveLength);
				}
				return this.BuffInfoIDPveValue;
			}
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x00076EA0 File Offset: 0x000752A0
		public int BuffInfoIDPvpArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06001A01 RID: 6657 RVA: 0x00076EF0 File Offset: 0x000752F0
		public int BuffInfoIDPvpLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x00076F23 File Offset: 0x00075323
		public ArraySegment<byte>? GetBuffInfoIDPvpBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06001A03 RID: 6659 RVA: 0x00076F32 File Offset: 0x00075332
		public FlatBufferArray<int> BuffInfoIDPvp
		{
			get
			{
				if (this.BuffInfoIDPvpValue == null)
				{
					this.BuffInfoIDPvpValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffInfoIDPvpArray), this.BuffInfoIDPvpLength);
				}
				return this.BuffInfoIDPvpValue;
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06001A04 RID: 6660 RVA: 0x00076F64 File Offset: 0x00075364
		public string SkillAttributes
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x00076FA7 File Offset: 0x000753A7
		public ArraySegment<byte>? GetSkillAttributesBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06001A06 RID: 6662 RVA: 0x00076FB8 File Offset: 0x000753B8
		public int Level
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06001A07 RID: 6663 RVA: 0x00077004 File Offset: 0x00075404
		public string NextLevPrecbeadID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001A08 RID: 6664 RVA: 0x00077047 File Offset: 0x00075447
		public ArraySegment<byte>? GetNextLevPrecbeadIDBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06001A09 RID: 6665 RVA: 0x00077058 File Offset: 0x00075458
		public string UpConsume
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x0007709B File Offset: 0x0007549B
		public ArraySegment<byte>? GetUpConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06001A0B RID: 6667 RVA: 0x000770AC File Offset: 0x000754AC
		public int AddtionBuffPro
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06001A0C RID: 6668 RVA: 0x000770F8 File Offset: 0x000754F8
		public int BuffGroup
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06001A0D RID: 6669 RVA: 0x00077144 File Offset: 0x00075544
		public int BeadName
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06001A0E RID: 6670 RVA: 0x00077190 File Offset: 0x00075590
		public string Instruction
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x000771D3 File Offset: 0x000755D3
		public ArraySegment<byte>? GetInstructionBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06001A10 RID: 6672 RVA: 0x000771E4 File Offset: 0x000755E4
		public int BeadType
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x00077230 File Offset: 0x00075630
		public int ReplacePearlArray(int j)
		{
			int num = this.__p.__offset(36);
			return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06001A12 RID: 6674 RVA: 0x00077280 File Offset: 0x00075680
		public int ReplacePearlLength
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x000772B3 File Offset: 0x000756B3
		public ArraySegment<byte>? GetReplacePearlBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06001A14 RID: 6676 RVA: 0x000772C2 File Offset: 0x000756C2
		public FlatBufferArray<int> ReplacePearl
		{
			get
			{
				if (this.ReplacePearlValue == null)
				{
					this.ReplacePearlValue = new FlatBufferArray<int>(new Func<int, int>(this.ReplacePearlArray), this.ReplacePearlLength);
				}
				return this.ReplacePearlValue;
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06001A15 RID: 6677 RVA: 0x000772F4 File Offset: 0x000756F4
		public int ProminentAtt
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06001A16 RID: 6678 RVA: 0x00077340 File Offset: 0x00075740
		public int Score
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (127561488 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x0007738C File Offset: 0x0007578C
		public static Offset<BeadTable> CreateBeadTable(FlatBufferBuilder builder, int ID = 0, int Color = 0, VectorOffset PartsOffset = default(VectorOffset), VectorOffset PropTypeOffset = default(VectorOffset), VectorOffset PropValueOffset = default(VectorOffset), VectorOffset BuffInfoIDPveOffset = default(VectorOffset), VectorOffset BuffInfoIDPvpOffset = default(VectorOffset), StringOffset SkillAttributesOffset = default(StringOffset), int Level = 0, StringOffset NextLevPrecbeadIDOffset = default(StringOffset), StringOffset UpConsumeOffset = default(StringOffset), int AddtionBuffPro = 0, int BuffGroup = 0, int BeadName = 0, StringOffset InstructionOffset = default(StringOffset), int BeadType = 0, VectorOffset ReplacePearlOffset = default(VectorOffset), int ProminentAtt = 0, int Score = 0)
		{
			builder.StartObject(19);
			BeadTable.AddScore(builder, Score);
			BeadTable.AddProminentAtt(builder, ProminentAtt);
			BeadTable.AddReplacePearl(builder, ReplacePearlOffset);
			BeadTable.AddBeadType(builder, BeadType);
			BeadTable.AddInstruction(builder, InstructionOffset);
			BeadTable.AddBeadName(builder, BeadName);
			BeadTable.AddBuffGroup(builder, BuffGroup);
			BeadTable.AddAddtionBuffPro(builder, AddtionBuffPro);
			BeadTable.AddUpConsume(builder, UpConsumeOffset);
			BeadTable.AddNextLevPrecbeadID(builder, NextLevPrecbeadIDOffset);
			BeadTable.AddLevel(builder, Level);
			BeadTable.AddSkillAttributes(builder, SkillAttributesOffset);
			BeadTable.AddBuffInfoIDPvp(builder, BuffInfoIDPvpOffset);
			BeadTable.AddBuffInfoIDPve(builder, BuffInfoIDPveOffset);
			BeadTable.AddPropValue(builder, PropValueOffset);
			BeadTable.AddPropType(builder, PropTypeOffset);
			BeadTable.AddParts(builder, PartsOffset);
			BeadTable.AddColor(builder, Color);
			BeadTable.AddID(builder, ID);
			return BeadTable.EndBeadTable(builder);
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x0007743C File Offset: 0x0007583C
		public static void StartBeadTable(FlatBufferBuilder builder)
		{
			builder.StartObject(19);
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x00077446 File Offset: 0x00075846
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x00077451 File Offset: 0x00075851
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(1, Color, 0);
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x0007745C File Offset: 0x0007585C
		public static void AddParts(FlatBufferBuilder builder, VectorOffset PartsOffset)
		{
			builder.AddOffset(2, PartsOffset.Value, 0);
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x00077470 File Offset: 0x00075870
		public static VectorOffset CreatePartsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x000774AD File Offset: 0x000758AD
		public static void StartPartsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001A1E RID: 6686 RVA: 0x000774B8 File Offset: 0x000758B8
		public static void AddPropType(FlatBufferBuilder builder, VectorOffset PropTypeOffset)
		{
			builder.AddOffset(3, PropTypeOffset.Value, 0);
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x000774CC File Offset: 0x000758CC
		public static VectorOffset CreatePropTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x00077509 File Offset: 0x00075909
		public static void StartPropTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x00077514 File Offset: 0x00075914
		public static void AddPropValue(FlatBufferBuilder builder, VectorOffset PropValueOffset)
		{
			builder.AddOffset(4, PropValueOffset.Value, 0);
		}

		// Token: 0x06001A22 RID: 6690 RVA: 0x00077528 File Offset: 0x00075928
		public static VectorOffset CreatePropValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001A23 RID: 6691 RVA: 0x00077565 File Offset: 0x00075965
		public static void StartPropValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001A24 RID: 6692 RVA: 0x00077570 File Offset: 0x00075970
		public static void AddBuffInfoIDPve(FlatBufferBuilder builder, VectorOffset BuffInfoIDPveOffset)
		{
			builder.AddOffset(5, BuffInfoIDPveOffset.Value, 0);
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x00077584 File Offset: 0x00075984
		public static VectorOffset CreateBuffInfoIDPveVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x000775C1 File Offset: 0x000759C1
		public static void StartBuffInfoIDPveVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001A27 RID: 6695 RVA: 0x000775CC File Offset: 0x000759CC
		public static void AddBuffInfoIDPvp(FlatBufferBuilder builder, VectorOffset BuffInfoIDPvpOffset)
		{
			builder.AddOffset(6, BuffInfoIDPvpOffset.Value, 0);
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x000775E0 File Offset: 0x000759E0
		public static VectorOffset CreateBuffInfoIDPvpVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x0007761D File Offset: 0x00075A1D
		public static void StartBuffInfoIDPvpVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x00077628 File Offset: 0x00075A28
		public static void AddSkillAttributes(FlatBufferBuilder builder, StringOffset SkillAttributesOffset)
		{
			builder.AddOffset(7, SkillAttributesOffset.Value, 0);
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x00077639 File Offset: 0x00075A39
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(8, Level, 0);
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x00077644 File Offset: 0x00075A44
		public static void AddNextLevPrecbeadID(FlatBufferBuilder builder, StringOffset NextLevPrecbeadIDOffset)
		{
			builder.AddOffset(9, NextLevPrecbeadIDOffset.Value, 0);
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x00077656 File Offset: 0x00075A56
		public static void AddUpConsume(FlatBufferBuilder builder, StringOffset UpConsumeOffset)
		{
			builder.AddOffset(10, UpConsumeOffset.Value, 0);
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x00077668 File Offset: 0x00075A68
		public static void AddAddtionBuffPro(FlatBufferBuilder builder, int AddtionBuffPro)
		{
			builder.AddInt(11, AddtionBuffPro, 0);
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x00077674 File Offset: 0x00075A74
		public static void AddBuffGroup(FlatBufferBuilder builder, int BuffGroup)
		{
			builder.AddInt(12, BuffGroup, 0);
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x00077680 File Offset: 0x00075A80
		public static void AddBeadName(FlatBufferBuilder builder, int BeadName)
		{
			builder.AddInt(13, BeadName, 0);
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x0007768C File Offset: 0x00075A8C
		public static void AddInstruction(FlatBufferBuilder builder, StringOffset InstructionOffset)
		{
			builder.AddOffset(14, InstructionOffset.Value, 0);
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x0007769E File Offset: 0x00075A9E
		public static void AddBeadType(FlatBufferBuilder builder, int BeadType)
		{
			builder.AddInt(15, BeadType, 0);
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x000776AA File Offset: 0x00075AAA
		public static void AddReplacePearl(FlatBufferBuilder builder, VectorOffset ReplacePearlOffset)
		{
			builder.AddOffset(16, ReplacePearlOffset.Value, 0);
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x000776BC File Offset: 0x00075ABC
		public static VectorOffset CreateReplacePearlVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x000776F9 File Offset: 0x00075AF9
		public static void StartReplacePearlVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x00077704 File Offset: 0x00075B04
		public static void AddProminentAtt(FlatBufferBuilder builder, int ProminentAtt)
		{
			builder.AddInt(17, ProminentAtt, 0);
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x00077710 File Offset: 0x00075B10
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(18, Score, 0);
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x0007771C File Offset: 0x00075B1C
		public static Offset<BeadTable> EndBeadTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BeadTable>(value);
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x00077736 File Offset: 0x00075B36
		public static void FinishBeadTableBuffer(FlatBufferBuilder builder, Offset<BeadTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E9B RID: 3739
		private Table __p = new Table();

		// Token: 0x04000E9C RID: 3740
		private FlatBufferArray<int> PartsValue;

		// Token: 0x04000E9D RID: 3741
		private FlatBufferArray<int> PropTypeValue;

		// Token: 0x04000E9E RID: 3742
		private FlatBufferArray<int> PropValueValue;

		// Token: 0x04000E9F RID: 3743
		private FlatBufferArray<int> BuffInfoIDPveValue;

		// Token: 0x04000EA0 RID: 3744
		private FlatBufferArray<int> BuffInfoIDPvpValue;

		// Token: 0x04000EA1 RID: 3745
		private FlatBufferArray<int> ReplacePearlValue;

		// Token: 0x020002D3 RID: 723
		public enum eCrypt
		{
			// Token: 0x04000EA3 RID: 3747
			code = 127561488
		}
	}
}
