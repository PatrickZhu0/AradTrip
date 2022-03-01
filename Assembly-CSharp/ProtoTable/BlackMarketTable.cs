using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002E4 RID: 740
	public class BlackMarketTable : IFlatbufferObject
	{
		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06001B29 RID: 6953 RVA: 0x00079848 File Offset: 0x00077C48
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001B2A RID: 6954 RVA: 0x00079855 File Offset: 0x00077C55
		public static BlackMarketTable GetRootAsBlackMarketTable(ByteBuffer _bb)
		{
			return BlackMarketTable.GetRootAsBlackMarketTable(_bb, new BlackMarketTable());
		}

		// Token: 0x06001B2B RID: 6955 RVA: 0x00079862 File Offset: 0x00077C62
		public static BlackMarketTable GetRootAsBlackMarketTable(ByteBuffer _bb, BlackMarketTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001B2C RID: 6956 RVA: 0x0007987E File Offset: 0x00077C7E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001B2D RID: 6957 RVA: 0x00079898 File Offset: 0x00077C98
		public BlackMarketTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06001B2E RID: 6958 RVA: 0x000798A4 File Offset: 0x00077CA4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (56829445 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06001B2F RID: 6959 RVA: 0x000798F0 File Offset: 0x00077CF0
		public int NpcID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (56829445 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06001B30 RID: 6960 RVA: 0x0007993C File Offset: 0x00077D3C
		public string NpcPortrait
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B31 RID: 6961 RVA: 0x0007997E File Offset: 0x00077D7E
		public ArraySegment<byte>? GetNpcPortraitBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06001B32 RID: 6962 RVA: 0x0007998C File Offset: 0x00077D8C
		public string NPCDialogue
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B33 RID: 6963 RVA: 0x000799CF File Offset: 0x00077DCF
		public ArraySegment<byte>? GetNPCDialogueBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06001B34 RID: 6964 RVA: 0x000799E0 File Offset: 0x00077DE0
		public string TransactionTypeDescribe
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B35 RID: 6965 RVA: 0x00079A23 File Offset: 0x00077E23
		public ArraySegment<byte>? GetTransactionTypeDescribeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06001B36 RID: 6966 RVA: 0x00079A32 File Offset: 0x00077E32
		public static Offset<BlackMarketTable> CreateBlackMarketTable(FlatBufferBuilder builder, int ID = 0, int NpcID = 0, StringOffset NpcPortraitOffset = default(StringOffset), StringOffset NPCDialogueOffset = default(StringOffset), StringOffset TransactionTypeDescribeOffset = default(StringOffset))
		{
			builder.StartObject(5);
			BlackMarketTable.AddTransactionTypeDescribe(builder, TransactionTypeDescribeOffset);
			BlackMarketTable.AddNPCDialogue(builder, NPCDialogueOffset);
			BlackMarketTable.AddNpcPortrait(builder, NpcPortraitOffset);
			BlackMarketTable.AddNpcID(builder, NpcID);
			BlackMarketTable.AddID(builder, ID);
			return BlackMarketTable.EndBlackMarketTable(builder);
		}

		// Token: 0x06001B37 RID: 6967 RVA: 0x00079A66 File Offset: 0x00077E66
		public static void StartBlackMarketTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06001B38 RID: 6968 RVA: 0x00079A6F File Offset: 0x00077E6F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001B39 RID: 6969 RVA: 0x00079A7A File Offset: 0x00077E7A
		public static void AddNpcID(FlatBufferBuilder builder, int NpcID)
		{
			builder.AddInt(1, NpcID, 0);
		}

		// Token: 0x06001B3A RID: 6970 RVA: 0x00079A85 File Offset: 0x00077E85
		public static void AddNpcPortrait(FlatBufferBuilder builder, StringOffset NpcPortraitOffset)
		{
			builder.AddOffset(2, NpcPortraitOffset.Value, 0);
		}

		// Token: 0x06001B3B RID: 6971 RVA: 0x00079A96 File Offset: 0x00077E96
		public static void AddNPCDialogue(FlatBufferBuilder builder, StringOffset NPCDialogueOffset)
		{
			builder.AddOffset(3, NPCDialogueOffset.Value, 0);
		}

		// Token: 0x06001B3C RID: 6972 RVA: 0x00079AA7 File Offset: 0x00077EA7
		public static void AddTransactionTypeDescribe(FlatBufferBuilder builder, StringOffset TransactionTypeDescribeOffset)
		{
			builder.AddOffset(4, TransactionTypeDescribeOffset.Value, 0);
		}

		// Token: 0x06001B3D RID: 6973 RVA: 0x00079AB8 File Offset: 0x00077EB8
		public static Offset<BlackMarketTable> EndBlackMarketTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BlackMarketTable>(value);
		}

		// Token: 0x06001B3E RID: 6974 RVA: 0x00079AD2 File Offset: 0x00077ED2
		public static void FinishBlackMarketTableBuffer(FlatBufferBuilder builder, Offset<BlackMarketTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EBD RID: 3773
		private Table __p = new Table();

		// Token: 0x020002E5 RID: 741
		public enum eCrypt
		{
			// Token: 0x04000EBF RID: 3775
			code = 56829445
		}
	}
}
