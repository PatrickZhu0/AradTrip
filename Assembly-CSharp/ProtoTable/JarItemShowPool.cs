using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004CA RID: 1226
	public class JarItemShowPool : IFlatbufferObject
	{
		// Token: 0x17000F96 RID: 3990
		// (get) Token: 0x06003C87 RID: 15495 RVA: 0x000C9D28 File Offset: 0x000C8128
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003C88 RID: 15496 RVA: 0x000C9D35 File Offset: 0x000C8135
		public static JarItemShowPool GetRootAsJarItemShowPool(ByteBuffer _bb)
		{
			return JarItemShowPool.GetRootAsJarItemShowPool(_bb, new JarItemShowPool());
		}

		// Token: 0x06003C89 RID: 15497 RVA: 0x000C9D42 File Offset: 0x000C8142
		public static JarItemShowPool GetRootAsJarItemShowPool(ByteBuffer _bb, JarItemShowPool obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003C8A RID: 15498 RVA: 0x000C9D5E File Offset: 0x000C815E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003C8B RID: 15499 RVA: 0x000C9D78 File Offset: 0x000C8178
		public JarItemShowPool __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000F97 RID: 3991
		// (get) Token: 0x06003C8C RID: 15500 RVA: 0x000C9D84 File Offset: 0x000C8184
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1647923331 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F98 RID: 3992
		// (get) Token: 0x06003C8D RID: 15501 RVA: 0x000C9DD0 File Offset: 0x000C81D0
		public int JarType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1647923331 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F99 RID: 3993
		// (get) Token: 0x06003C8E RID: 15502 RVA: 0x000C9E1C File Offset: 0x000C821C
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1647923331 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F9A RID: 3994
		// (get) Token: 0x06003C8F RID: 15503 RVA: 0x000C9E68 File Offset: 0x000C8268
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1647923331 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003C90 RID: 15504 RVA: 0x000C9EB4 File Offset: 0x000C82B4
		public int VisibleArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (1647923331 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F9B RID: 3995
		// (get) Token: 0x06003C91 RID: 15505 RVA: 0x000C9F04 File Offset: 0x000C8304
		public int VisibleLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003C92 RID: 15506 RVA: 0x000C9F37 File Offset: 0x000C8337
		public ArraySegment<byte>? GetVisibleBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000F9C RID: 3996
		// (get) Token: 0x06003C93 RID: 15507 RVA: 0x000C9F46 File Offset: 0x000C8346
		public FlatBufferArray<int> Visible
		{
			get
			{
				if (this.VisibleValue == null)
				{
					this.VisibleValue = new FlatBufferArray<int>(new Func<int, int>(this.VisibleArray), this.VisibleLength);
				}
				return this.VisibleValue;
			}
		}

		// Token: 0x06003C94 RID: 15508 RVA: 0x000C9F76 File Offset: 0x000C8376
		public static Offset<JarItemShowPool> CreateJarItemShowPool(FlatBufferBuilder builder, int ID = 0, int JarType = 0, int ItemID = 0, int ItemNum = 0, VectorOffset VisibleOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			JarItemShowPool.AddVisible(builder, VisibleOffset);
			JarItemShowPool.AddItemNum(builder, ItemNum);
			JarItemShowPool.AddItemID(builder, ItemID);
			JarItemShowPool.AddJarType(builder, JarType);
			JarItemShowPool.AddID(builder, ID);
			return JarItemShowPool.EndJarItemShowPool(builder);
		}

		// Token: 0x06003C95 RID: 15509 RVA: 0x000C9FAA File Offset: 0x000C83AA
		public static void StartJarItemShowPool(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06003C96 RID: 15510 RVA: 0x000C9FB3 File Offset: 0x000C83B3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003C97 RID: 15511 RVA: 0x000C9FBE File Offset: 0x000C83BE
		public static void AddJarType(FlatBufferBuilder builder, int JarType)
		{
			builder.AddInt(1, JarType, 0);
		}

		// Token: 0x06003C98 RID: 15512 RVA: 0x000C9FC9 File Offset: 0x000C83C9
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(2, ItemID, 0);
		}

		// Token: 0x06003C99 RID: 15513 RVA: 0x000C9FD4 File Offset: 0x000C83D4
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(3, ItemNum, 0);
		}

		// Token: 0x06003C9A RID: 15514 RVA: 0x000C9FDF File Offset: 0x000C83DF
		public static void AddVisible(FlatBufferBuilder builder, VectorOffset VisibleOffset)
		{
			builder.AddOffset(4, VisibleOffset.Value, 0);
		}

		// Token: 0x06003C9B RID: 15515 RVA: 0x000C9FF0 File Offset: 0x000C83F0
		public static VectorOffset CreateVisibleVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003C9C RID: 15516 RVA: 0x000CA02D File Offset: 0x000C842D
		public static void StartVisibleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003C9D RID: 15517 RVA: 0x000CA038 File Offset: 0x000C8438
		public static Offset<JarItemShowPool> EndJarItemShowPool(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<JarItemShowPool>(value);
		}

		// Token: 0x06003C9E RID: 15518 RVA: 0x000CA052 File Offset: 0x000C8452
		public static void FinishJarItemShowPoolBuffer(FlatBufferBuilder builder, Offset<JarItemShowPool> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017BF RID: 6079
		private Table __p = new Table();

		// Token: 0x040017C0 RID: 6080
		private FlatBufferArray<int> VisibleValue;

		// Token: 0x020004CB RID: 1227
		public enum eCrypt
		{
			// Token: 0x040017C2 RID: 6082
			code = 1647923331
		}
	}
}
