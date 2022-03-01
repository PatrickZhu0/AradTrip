using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000261 RID: 609
	public class AIConfigTable : IFlatbufferObject
	{
		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060013CC RID: 5068 RVA: 0x0006950D File Offset: 0x0006790D
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x0006951A File Offset: 0x0006791A
		public static AIConfigTable GetRootAsAIConfigTable(ByteBuffer _bb)
		{
			return AIConfigTable.GetRootAsAIConfigTable(_bb, new AIConfigTable());
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x00069527 File Offset: 0x00067927
		public static AIConfigTable GetRootAsAIConfigTable(ByteBuffer _bb, AIConfigTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x00069543 File Offset: 0x00067943
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x0006955D File Offset: 0x0006795D
		public AIConfigTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x00069568 File Offset: 0x00067968
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060013D2 RID: 5074 RVA: 0x000695B4 File Offset: 0x000679B4
		public int JobID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x00069600 File Offset: 0x00067A00
		public int AIType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060013D4 RID: 5076 RVA: 0x0006964C File Offset: 0x00067A4C
		public int AIAttackDelay
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060013D5 RID: 5077 RVA: 0x00069698 File Offset: 0x00067A98
		public int AIDestinationChangeTerm
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060013D6 RID: 5078 RVA: 0x000696E4 File Offset: 0x00067AE4
		public int AIThinkTargetTerm
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060013D7 RID: 5079 RVA: 0x00069730 File Offset: 0x00067B30
		public int AIKeepDistance
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060013D8 RID: 5080 RVA: 0x0006977C File Offset: 0x00067B7C
		public string AIActionPath
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x000697BF File Offset: 0x00067BBF
		public ArraySegment<byte>? GetAIActionPathBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060013DA RID: 5082 RVA: 0x000697D0 File Offset: 0x00067BD0
		public string AIDestinationSelectPath
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060013DB RID: 5083 RVA: 0x00069813 File Offset: 0x00067C13
		public ArraySegment<byte>? GetAIDestinationSelectPathBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060013DC RID: 5084 RVA: 0x00069824 File Offset: 0x00067C24
		public string AIEventPath
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x00069867 File Offset: 0x00067C67
		public ArraySegment<byte>? GetAIEventPathBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x00069878 File Offset: 0x00067C78
		public int EquipsArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (-2012602248 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060013DF RID: 5087 RVA: 0x000698C8 File Offset: 0x00067CC8
		public int EquipsLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x000698FB File Offset: 0x00067CFB
		public ArraySegment<byte>? GetEquipsBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060013E1 RID: 5089 RVA: 0x0006990A File Offset: 0x00067D0A
		public FlatBufferArray<int> Equips
		{
			get
			{
				if (this.EquipsValue == null)
				{
					this.EquipsValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipsArray), this.EquipsLength);
				}
				return this.EquipsValue;
			}
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x0006993C File Offset: 0x00067D3C
		public static Offset<AIConfigTable> CreateAIConfigTable(FlatBufferBuilder builder, int ID = 0, int JobID = 0, int AIType = 0, int AIAttackDelay = 0, int AIDestinationChangeTerm = 0, int AIThinkTargetTerm = 0, int AIKeepDistance = 0, StringOffset AIActionPathOffset = default(StringOffset), StringOffset AIDestinationSelectPathOffset = default(StringOffset), StringOffset AIEventPathOffset = default(StringOffset), VectorOffset EquipsOffset = default(VectorOffset))
		{
			builder.StartObject(11);
			AIConfigTable.AddEquips(builder, EquipsOffset);
			AIConfigTable.AddAIEventPath(builder, AIEventPathOffset);
			AIConfigTable.AddAIDestinationSelectPath(builder, AIDestinationSelectPathOffset);
			AIConfigTable.AddAIActionPath(builder, AIActionPathOffset);
			AIConfigTable.AddAIKeepDistance(builder, AIKeepDistance);
			AIConfigTable.AddAIThinkTargetTerm(builder, AIThinkTargetTerm);
			AIConfigTable.AddAIDestinationChangeTerm(builder, AIDestinationChangeTerm);
			AIConfigTable.AddAIAttackDelay(builder, AIAttackDelay);
			AIConfigTable.AddAIType(builder, AIType);
			AIConfigTable.AddJobID(builder, JobID);
			AIConfigTable.AddID(builder, ID);
			return AIConfigTable.EndAIConfigTable(builder);
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x000699AC File Offset: 0x00067DAC
		public static void StartAIConfigTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x000699B6 File Offset: 0x00067DB6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x000699C1 File Offset: 0x00067DC1
		public static void AddJobID(FlatBufferBuilder builder, int JobID)
		{
			builder.AddInt(1, JobID, 0);
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x000699CC File Offset: 0x00067DCC
		public static void AddAIType(FlatBufferBuilder builder, int AIType)
		{
			builder.AddInt(2, AIType, 0);
		}

		// Token: 0x060013E7 RID: 5095 RVA: 0x000699D7 File Offset: 0x00067DD7
		public static void AddAIAttackDelay(FlatBufferBuilder builder, int AIAttackDelay)
		{
			builder.AddInt(3, AIAttackDelay, 0);
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x000699E2 File Offset: 0x00067DE2
		public static void AddAIDestinationChangeTerm(FlatBufferBuilder builder, int AIDestinationChangeTerm)
		{
			builder.AddInt(4, AIDestinationChangeTerm, 0);
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x000699ED File Offset: 0x00067DED
		public static void AddAIThinkTargetTerm(FlatBufferBuilder builder, int AIThinkTargetTerm)
		{
			builder.AddInt(5, AIThinkTargetTerm, 0);
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x000699F8 File Offset: 0x00067DF8
		public static void AddAIKeepDistance(FlatBufferBuilder builder, int AIKeepDistance)
		{
			builder.AddInt(6, AIKeepDistance, 0);
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x00069A03 File Offset: 0x00067E03
		public static void AddAIActionPath(FlatBufferBuilder builder, StringOffset AIActionPathOffset)
		{
			builder.AddOffset(7, AIActionPathOffset.Value, 0);
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x00069A14 File Offset: 0x00067E14
		public static void AddAIDestinationSelectPath(FlatBufferBuilder builder, StringOffset AIDestinationSelectPathOffset)
		{
			builder.AddOffset(8, AIDestinationSelectPathOffset.Value, 0);
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x00069A25 File Offset: 0x00067E25
		public static void AddAIEventPath(FlatBufferBuilder builder, StringOffset AIEventPathOffset)
		{
			builder.AddOffset(9, AIEventPathOffset.Value, 0);
		}

		// Token: 0x060013EE RID: 5102 RVA: 0x00069A37 File Offset: 0x00067E37
		public static void AddEquips(FlatBufferBuilder builder, VectorOffset EquipsOffset)
		{
			builder.AddOffset(10, EquipsOffset.Value, 0);
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x00069A4C File Offset: 0x00067E4C
		public static VectorOffset CreateEquipsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060013F0 RID: 5104 RVA: 0x00069A89 File Offset: 0x00067E89
		public static void StartEquipsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060013F1 RID: 5105 RVA: 0x00069A94 File Offset: 0x00067E94
		public static Offset<AIConfigTable> EndAIConfigTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AIConfigTable>(value);
		}

		// Token: 0x060013F2 RID: 5106 RVA: 0x00069AAE File Offset: 0x00067EAE
		public static void FinishAIConfigTableBuffer(FlatBufferBuilder builder, Offset<AIConfigTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D4F RID: 3407
		private Table __p = new Table();

		// Token: 0x04000D50 RID: 3408
		private FlatBufferArray<int> EquipsValue;

		// Token: 0x02000262 RID: 610
		public enum eCrypt
		{
			// Token: 0x04000D52 RID: 3410
			code = -2012602248
		}
	}
}
