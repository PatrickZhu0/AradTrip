using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200031D RID: 797
	public class ChiJiNpcRewardTable : IFlatbufferObject
	{
		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x06001F97 RID: 8087 RVA: 0x0008474C File Offset: 0x00082B4C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001F98 RID: 8088 RVA: 0x00084759 File Offset: 0x00082B59
		public static ChiJiNpcRewardTable GetRootAsChiJiNpcRewardTable(ByteBuffer _bb)
		{
			return ChiJiNpcRewardTable.GetRootAsChiJiNpcRewardTable(_bb, new ChiJiNpcRewardTable());
		}

		// Token: 0x06001F99 RID: 8089 RVA: 0x00084766 File Offset: 0x00082B66
		public static ChiJiNpcRewardTable GetRootAsChiJiNpcRewardTable(ByteBuffer _bb, ChiJiNpcRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001F9A RID: 8090 RVA: 0x00084782 File Offset: 0x00082B82
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001F9B RID: 8091 RVA: 0x0008479C File Offset: 0x00082B9C
		public ChiJiNpcRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x06001F9C RID: 8092 RVA: 0x000847A8 File Offset: 0x00082BA8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (628208941 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06001F9D RID: 8093 RVA: 0x000847F4 File Offset: 0x00082BF4
		public int npcId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (628208941 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x06001F9E RID: 8094 RVA: 0x00084840 File Offset: 0x00082C40
		public int param
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (628208941 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x0008488C File Offset: 0x00082C8C
		public int param2
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (628208941 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001FA0 RID: 8096 RVA: 0x000848D8 File Offset: 0x00082CD8
		public int rewardsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (628208941 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x00084928 File Offset: 0x00082D28
		public int rewardsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001FA2 RID: 8098 RVA: 0x0008495B File Offset: 0x00082D5B
		public ArraySegment<byte>? GetRewardsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x06001FA3 RID: 8099 RVA: 0x0008496A File Offset: 0x00082D6A
		public FlatBufferArray<int> rewards
		{
			get
			{
				if (this.rewardsValue == null)
				{
					this.rewardsValue = new FlatBufferArray<int>(new Func<int, int>(this.rewardsArray), this.rewardsLength);
				}
				return this.rewardsValue;
			}
		}

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x06001FA4 RID: 8100 RVA: 0x0008499C File Offset: 0x00082D9C
		public string NpcDialogue
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001FA5 RID: 8101 RVA: 0x000849DF File Offset: 0x00082DDF
		public ArraySegment<byte>? GetNpcDialogueBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06001FA6 RID: 8102 RVA: 0x000849EE File Offset: 0x00082DEE
		public static Offset<ChiJiNpcRewardTable> CreateChiJiNpcRewardTable(FlatBufferBuilder builder, int ID = 0, int npcId = 0, int param = 0, int param2 = 0, VectorOffset rewardsOffset = default(VectorOffset), StringOffset NpcDialogueOffset = default(StringOffset))
		{
			builder.StartObject(6);
			ChiJiNpcRewardTable.AddNpcDialogue(builder, NpcDialogueOffset);
			ChiJiNpcRewardTable.AddRewards(builder, rewardsOffset);
			ChiJiNpcRewardTable.AddParam2(builder, param2);
			ChiJiNpcRewardTable.AddParam(builder, param);
			ChiJiNpcRewardTable.AddNpcId(builder, npcId);
			ChiJiNpcRewardTable.AddID(builder, ID);
			return ChiJiNpcRewardTable.EndChiJiNpcRewardTable(builder);
		}

		// Token: 0x06001FA7 RID: 8103 RVA: 0x00084A2A File Offset: 0x00082E2A
		public static void StartChiJiNpcRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06001FA8 RID: 8104 RVA: 0x00084A33 File Offset: 0x00082E33
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001FA9 RID: 8105 RVA: 0x00084A3E File Offset: 0x00082E3E
		public static void AddNpcId(FlatBufferBuilder builder, int npcId)
		{
			builder.AddInt(1, npcId, 0);
		}

		// Token: 0x06001FAA RID: 8106 RVA: 0x00084A49 File Offset: 0x00082E49
		public static void AddParam(FlatBufferBuilder builder, int param)
		{
			builder.AddInt(2, param, 0);
		}

		// Token: 0x06001FAB RID: 8107 RVA: 0x00084A54 File Offset: 0x00082E54
		public static void AddParam2(FlatBufferBuilder builder, int param2)
		{
			builder.AddInt(3, param2, 0);
		}

		// Token: 0x06001FAC RID: 8108 RVA: 0x00084A5F File Offset: 0x00082E5F
		public static void AddRewards(FlatBufferBuilder builder, VectorOffset rewardsOffset)
		{
			builder.AddOffset(4, rewardsOffset.Value, 0);
		}

		// Token: 0x06001FAD RID: 8109 RVA: 0x00084A70 File Offset: 0x00082E70
		public static VectorOffset CreateRewardsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001FAE RID: 8110 RVA: 0x00084AAD File Offset: 0x00082EAD
		public static void StartRewardsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001FAF RID: 8111 RVA: 0x00084AB8 File Offset: 0x00082EB8
		public static void AddNpcDialogue(FlatBufferBuilder builder, StringOffset NpcDialogueOffset)
		{
			builder.AddOffset(5, NpcDialogueOffset.Value, 0);
		}

		// Token: 0x06001FB0 RID: 8112 RVA: 0x00084ACC File Offset: 0x00082ECC
		public static Offset<ChiJiNpcRewardTable> EndChiJiNpcRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiNpcRewardTable>(value);
		}

		// Token: 0x06001FB1 RID: 8113 RVA: 0x00084AE6 File Offset: 0x00082EE6
		public static void FinishChiJiNpcRewardTableBuffer(FlatBufferBuilder builder, Offset<ChiJiNpcRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F6C RID: 3948
		private Table __p = new Table();

		// Token: 0x04000F6D RID: 3949
		private FlatBufferArray<int> rewardsValue;

		// Token: 0x0200031E RID: 798
		public enum eCrypt
		{
			// Token: 0x04000F6F RID: 3951
			code = 628208941
		}
	}
}
