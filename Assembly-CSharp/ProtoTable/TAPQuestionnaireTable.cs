using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005E3 RID: 1507
	public class TAPQuestionnaireTable : IFlatbufferObject
	{
		// Token: 0x170015FC RID: 5628
		// (get) Token: 0x06004FCC RID: 20428 RVA: 0x000F74B8 File Offset: 0x000F58B8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004FCD RID: 20429 RVA: 0x000F74C5 File Offset: 0x000F58C5
		public static TAPQuestionnaireTable GetRootAsTAPQuestionnaireTable(ByteBuffer _bb)
		{
			return TAPQuestionnaireTable.GetRootAsTAPQuestionnaireTable(_bb, new TAPQuestionnaireTable());
		}

		// Token: 0x06004FCE RID: 20430 RVA: 0x000F74D2 File Offset: 0x000F58D2
		public static TAPQuestionnaireTable GetRootAsTAPQuestionnaireTable(ByteBuffer _bb, TAPQuestionnaireTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004FCF RID: 20431 RVA: 0x000F74EE File Offset: 0x000F58EE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004FD0 RID: 20432 RVA: 0x000F7508 File Offset: 0x000F5908
		public TAPQuestionnaireTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015FD RID: 5629
		// (get) Token: 0x06004FD1 RID: 20433 RVA: 0x000F7514 File Offset: 0x000F5914
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-427165796 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015FE RID: 5630
		// (get) Token: 0x06004FD2 RID: 20434 RVA: 0x000F7560 File Offset: 0x000F5960
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-427165796 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015FF RID: 5631
		// (get) Token: 0x06004FD3 RID: 20435 RVA: 0x000F75AC File Offset: 0x000F59AC
		public int QuestionIndex
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-427165796 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001600 RID: 5632
		// (get) Token: 0x06004FD4 RID: 20436 RVA: 0x000F75F8 File Offset: 0x000F59F8
		public string QuestionDes
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004FD5 RID: 20437 RVA: 0x000F763B File Offset: 0x000F5A3B
		public ArraySegment<byte>? GetQuestionDesBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001601 RID: 5633
		// (get) Token: 0x06004FD6 RID: 20438 RVA: 0x000F764C File Offset: 0x000F5A4C
		public int AnswerIndex
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-427165796 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001602 RID: 5634
		// (get) Token: 0x06004FD7 RID: 20439 RVA: 0x000F7698 File Offset: 0x000F5A98
		public string AnswerDes
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004FD8 RID: 20440 RVA: 0x000F76DB File Offset: 0x000F5ADB
		public ArraySegment<byte>? GetAnswerDesBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06004FD9 RID: 20441 RVA: 0x000F76EA File Offset: 0x000F5AEA
		public static Offset<TAPQuestionnaireTable> CreateTAPQuestionnaireTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int QuestionIndex = 0, StringOffset QuestionDesOffset = default(StringOffset), int AnswerIndex = 0, StringOffset AnswerDesOffset = default(StringOffset))
		{
			builder.StartObject(6);
			TAPQuestionnaireTable.AddAnswerDes(builder, AnswerDesOffset);
			TAPQuestionnaireTable.AddAnswerIndex(builder, AnswerIndex);
			TAPQuestionnaireTable.AddQuestionDes(builder, QuestionDesOffset);
			TAPQuestionnaireTable.AddQuestionIndex(builder, QuestionIndex);
			TAPQuestionnaireTable.AddType(builder, Type);
			TAPQuestionnaireTable.AddID(builder, ID);
			return TAPQuestionnaireTable.EndTAPQuestionnaireTable(builder);
		}

		// Token: 0x06004FDA RID: 20442 RVA: 0x000F7726 File Offset: 0x000F5B26
		public static void StartTAPQuestionnaireTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06004FDB RID: 20443 RVA: 0x000F772F File Offset: 0x000F5B2F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004FDC RID: 20444 RVA: 0x000F773A File Offset: 0x000F5B3A
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x06004FDD RID: 20445 RVA: 0x000F7745 File Offset: 0x000F5B45
		public static void AddQuestionIndex(FlatBufferBuilder builder, int QuestionIndex)
		{
			builder.AddInt(2, QuestionIndex, 0);
		}

		// Token: 0x06004FDE RID: 20446 RVA: 0x000F7750 File Offset: 0x000F5B50
		public static void AddQuestionDes(FlatBufferBuilder builder, StringOffset QuestionDesOffset)
		{
			builder.AddOffset(3, QuestionDesOffset.Value, 0);
		}

		// Token: 0x06004FDF RID: 20447 RVA: 0x000F7761 File Offset: 0x000F5B61
		public static void AddAnswerIndex(FlatBufferBuilder builder, int AnswerIndex)
		{
			builder.AddInt(4, AnswerIndex, 0);
		}

		// Token: 0x06004FE0 RID: 20448 RVA: 0x000F776C File Offset: 0x000F5B6C
		public static void AddAnswerDes(FlatBufferBuilder builder, StringOffset AnswerDesOffset)
		{
			builder.AddOffset(5, AnswerDesOffset.Value, 0);
		}

		// Token: 0x06004FE1 RID: 20449 RVA: 0x000F7780 File Offset: 0x000F5B80
		public static Offset<TAPQuestionnaireTable> EndTAPQuestionnaireTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TAPQuestionnaireTable>(value);
		}

		// Token: 0x06004FE2 RID: 20450 RVA: 0x000F779A File Offset: 0x000F5B9A
		public static void FinishTAPQuestionnaireTableBuffer(FlatBufferBuilder builder, Offset<TAPQuestionnaireTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DD2 RID: 7634
		private Table __p = new Table();

		// Token: 0x020005E4 RID: 1508
		public enum eCrypt
		{
			// Token: 0x04001DD4 RID: 7636
			code = -427165796
		}
	}
}
