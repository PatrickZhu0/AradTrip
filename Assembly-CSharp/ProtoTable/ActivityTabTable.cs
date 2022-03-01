using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000289 RID: 649
	public class ActivityTabTable : IFlatbufferObject
	{
		// Token: 0x17000330 RID: 816
		// (get) Token: 0x060016ED RID: 5869 RVA: 0x000707BC File Offset: 0x0006EBBC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x000707C9 File Offset: 0x0006EBC9
		public static ActivityTabTable GetRootAsActivityTabTable(ByteBuffer _bb)
		{
			return ActivityTabTable.GetRootAsActivityTabTable(_bb, new ActivityTabTable());
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x000707D6 File Offset: 0x0006EBD6
		public static ActivityTabTable GetRootAsActivityTabTable(ByteBuffer _bb, ActivityTabTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x000707F2 File Offset: 0x0006EBF2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060016F1 RID: 5873 RVA: 0x0007080C File Offset: 0x0006EC0C
		public ActivityTabTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x060016F2 RID: 5874 RVA: 0x00070818 File Offset: 0x0006EC18
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (67498292 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060016F3 RID: 5875 RVA: 0x00070864 File Offset: 0x0006EC64
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060016F4 RID: 5876 RVA: 0x000708A6 File Offset: 0x0006ECA6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x060016F5 RID: 5877 RVA: 0x000708B4 File Offset: 0x0006ECB4
		public int ActivityIdsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (67498292 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060016F6 RID: 5878 RVA: 0x00070900 File Offset: 0x0006ED00
		public int ActivityIdsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060016F7 RID: 5879 RVA: 0x00070932 File Offset: 0x0006ED32
		public ArraySegment<byte>? GetActivityIdsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x060016F8 RID: 5880 RVA: 0x00070940 File Offset: 0x0006ED40
		public FlatBufferArray<int> ActivityIds
		{
			get
			{
				if (this.ActivityIdsValue == null)
				{
					this.ActivityIdsValue = new FlatBufferArray<int>(new Func<int, int>(this.ActivityIdsArray), this.ActivityIdsLength);
				}
				return this.ActivityIdsValue;
			}
		}

		// Token: 0x060016F9 RID: 5881 RVA: 0x00070970 File Offset: 0x0006ED70
		public static Offset<ActivityTabTable> CreateActivityTabTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VectorOffset ActivityIdsOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			ActivityTabTable.AddActivityIds(builder, ActivityIdsOffset);
			ActivityTabTable.AddName(builder, NameOffset);
			ActivityTabTable.AddID(builder, ID);
			return ActivityTabTable.EndActivityTabTable(builder);
		}

		// Token: 0x060016FA RID: 5882 RVA: 0x00070994 File Offset: 0x0006ED94
		public static void StartActivityTabTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x0007099D File Offset: 0x0006ED9D
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x000709A8 File Offset: 0x0006EDA8
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060016FD RID: 5885 RVA: 0x000709B9 File Offset: 0x0006EDB9
		public static void AddActivityIds(FlatBufferBuilder builder, VectorOffset ActivityIdsOffset)
		{
			builder.AddOffset(2, ActivityIdsOffset.Value, 0);
		}

		// Token: 0x060016FE RID: 5886 RVA: 0x000709CC File Offset: 0x0006EDCC
		public static VectorOffset CreateActivityIdsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060016FF RID: 5887 RVA: 0x00070A09 File Offset: 0x0006EE09
		public static void StartActivityIdsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001700 RID: 5888 RVA: 0x00070A14 File Offset: 0x0006EE14
		public static Offset<ActivityTabTable> EndActivityTabTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActivityTabTable>(value);
		}

		// Token: 0x06001701 RID: 5889 RVA: 0x00070A2E File Offset: 0x0006EE2E
		public static void FinishActivityTabTableBuffer(FlatBufferBuilder builder, Offset<ActivityTabTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DBE RID: 3518
		private Table __p = new Table();

		// Token: 0x04000DBF RID: 3519
		private FlatBufferArray<int> ActivityIdsValue;

		// Token: 0x0200028A RID: 650
		public enum eCrypt
		{
			// Token: 0x04000DC1 RID: 3521
			code = 67498292
		}
	}
}
