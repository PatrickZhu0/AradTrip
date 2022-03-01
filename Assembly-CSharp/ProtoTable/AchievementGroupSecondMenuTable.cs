using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200026A RID: 618
	public class AchievementGroupSecondMenuTable : IFlatbufferObject
	{
		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06001466 RID: 5222 RVA: 0x0006AAE4 File Offset: 0x00068EE4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0006AAF1 File Offset: 0x00068EF1
		public static AchievementGroupSecondMenuTable GetRootAsAchievementGroupSecondMenuTable(ByteBuffer _bb)
		{
			return AchievementGroupSecondMenuTable.GetRootAsAchievementGroupSecondMenuTable(_bb, new AchievementGroupSecondMenuTable());
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x0006AAFE File Offset: 0x00068EFE
		public static AchievementGroupSecondMenuTable GetRootAsAchievementGroupSecondMenuTable(ByteBuffer _bb, AchievementGroupSecondMenuTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x0006AB1A File Offset: 0x00068F1A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0006AB34 File Offset: 0x00068F34
		public AchievementGroupSecondMenuTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x0600146B RID: 5227 RVA: 0x0006AB40 File Offset: 0x00068F40
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-533477339 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x0600146C RID: 5228 RVA: 0x0006AB8C File Offset: 0x00068F8C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600146D RID: 5229 RVA: 0x0006ABCE File Offset: 0x00068FCE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600146E RID: 5230 RVA: 0x0006ABDC File Offset: 0x00068FDC
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600146F RID: 5231 RVA: 0x0006AC1E File Offset: 0x0006901E
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001470 RID: 5232 RVA: 0x0006AC2C File Offset: 0x0006902C
		public int SubItemIDArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-533477339 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06001471 RID: 5233 RVA: 0x0006AC7C File Offset: 0x0006907C
		public int SubItemIDLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001472 RID: 5234 RVA: 0x0006ACAF File Offset: 0x000690AF
		public ArraySegment<byte>? GetSubItemIDBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x0006ACBE File Offset: 0x000690BE
		public FlatBufferArray<int> SubItemID
		{
			get
			{
				if (this.SubItemIDValue == null)
				{
					this.SubItemIDValue = new FlatBufferArray<int>(new Func<int, int>(this.SubItemIDArray), this.SubItemIDLength);
				}
				return this.SubItemIDValue;
			}
		}

		// Token: 0x06001474 RID: 5236 RVA: 0x0006ACEE File Offset: 0x000690EE
		public static Offset<AchievementGroupSecondMenuTable> CreateAchievementGroupSecondMenuTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset IconOffset = default(StringOffset), VectorOffset SubItemIDOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			AchievementGroupSecondMenuTable.AddSubItemID(builder, SubItemIDOffset);
			AchievementGroupSecondMenuTable.AddIcon(builder, IconOffset);
			AchievementGroupSecondMenuTable.AddName(builder, NameOffset);
			AchievementGroupSecondMenuTable.AddID(builder, ID);
			return AchievementGroupSecondMenuTable.EndAchievementGroupSecondMenuTable(builder);
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x0006AD1A File Offset: 0x0006911A
		public static void StartAchievementGroupSecondMenuTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x0006AD23 File Offset: 0x00069123
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x0006AD2E File Offset: 0x0006912E
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x0006AD3F File Offset: 0x0006913F
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(2, IconOffset.Value, 0);
		}

		// Token: 0x06001479 RID: 5241 RVA: 0x0006AD50 File Offset: 0x00069150
		public static void AddSubItemID(FlatBufferBuilder builder, VectorOffset SubItemIDOffset)
		{
			builder.AddOffset(3, SubItemIDOffset.Value, 0);
		}

		// Token: 0x0600147A RID: 5242 RVA: 0x0006AD64 File Offset: 0x00069164
		public static VectorOffset CreateSubItemIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600147B RID: 5243 RVA: 0x0006ADA1 File Offset: 0x000691A1
		public static void StartSubItemIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600147C RID: 5244 RVA: 0x0006ADAC File Offset: 0x000691AC
		public static Offset<AchievementGroupSecondMenuTable> EndAchievementGroupSecondMenuTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AchievementGroupSecondMenuTable>(value);
		}

		// Token: 0x0600147D RID: 5245 RVA: 0x0006ADC6 File Offset: 0x000691C6
		public static void FinishAchievementGroupSecondMenuTableBuffer(FlatBufferBuilder builder, Offset<AchievementGroupSecondMenuTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D66 RID: 3430
		private Table __p = new Table();

		// Token: 0x04000D67 RID: 3431
		private FlatBufferArray<int> SubItemIDValue;

		// Token: 0x0200026B RID: 619
		public enum eCrypt
		{
			// Token: 0x04000D69 RID: 3433
			code = -533477339
		}
	}
}
