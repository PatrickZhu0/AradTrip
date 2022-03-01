using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000621 RID: 1569
	public class WeekSignSpringTable : IFlatbufferObject
	{
		// Token: 0x170017F2 RID: 6130
		// (get) Token: 0x06005517 RID: 21783 RVA: 0x0010466C File Offset: 0x00102A6C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005518 RID: 21784 RVA: 0x00104679 File Offset: 0x00102A79
		public static WeekSignSpringTable GetRootAsWeekSignSpringTable(ByteBuffer _bb)
		{
			return WeekSignSpringTable.GetRootAsWeekSignSpringTable(_bb, new WeekSignSpringTable());
		}

		// Token: 0x06005519 RID: 21785 RVA: 0x00104686 File Offset: 0x00102A86
		public static WeekSignSpringTable GetRootAsWeekSignSpringTable(ByteBuffer _bb, WeekSignSpringTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600551A RID: 21786 RVA: 0x001046A2 File Offset: 0x00102AA2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600551B RID: 21787 RVA: 0x001046BC File Offset: 0x00102ABC
		public WeekSignSpringTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170017F3 RID: 6131
		// (get) Token: 0x0600551C RID: 21788 RVA: 0x001046C8 File Offset: 0x00102AC8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-6499428 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017F4 RID: 6132
		// (get) Token: 0x0600551D RID: 21789 RVA: 0x00104714 File Offset: 0x00102B14
		public int StartLv
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-6499428 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017F5 RID: 6133
		// (get) Token: 0x0600551E RID: 21790 RVA: 0x00104760 File Offset: 0x00102B60
		public int EndLv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-6499428 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600551F RID: 21791 RVA: 0x001047AC File Offset: 0x00102BAC
		public int DungeonIDArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-6499428 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170017F6 RID: 6134
		// (get) Token: 0x06005520 RID: 21792 RVA: 0x001047FC File Offset: 0x00102BFC
		public int DungeonIDLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005521 RID: 21793 RVA: 0x0010482F File Offset: 0x00102C2F
		public ArraySegment<byte>? GetDungeonIDBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170017F7 RID: 6135
		// (get) Token: 0x06005522 RID: 21794 RVA: 0x0010483E File Offset: 0x00102C3E
		public FlatBufferArray<int> DungeonID
		{
			get
			{
				if (this.DungeonIDValue == null)
				{
					this.DungeonIDValue = new FlatBufferArray<int>(new Func<int, int>(this.DungeonIDArray), this.DungeonIDLength);
				}
				return this.DungeonIDValue;
			}
		}

		// Token: 0x170017F8 RID: 6136
		// (get) Token: 0x06005523 RID: 21795 RVA: 0x00104870 File Offset: 0x00102C70
		public string AcquiredMethod
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005524 RID: 21796 RVA: 0x001048B3 File Offset: 0x00102CB3
		public ArraySegment<byte>? GetAcquiredMethodBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06005525 RID: 21797 RVA: 0x001048C2 File Offset: 0x00102CC2
		public static Offset<WeekSignSpringTable> CreateWeekSignSpringTable(FlatBufferBuilder builder, int ID = 0, int StartLv = 0, int EndLv = 0, VectorOffset DungeonIDOffset = default(VectorOffset), StringOffset AcquiredMethodOffset = default(StringOffset))
		{
			builder.StartObject(5);
			WeekSignSpringTable.AddAcquiredMethod(builder, AcquiredMethodOffset);
			WeekSignSpringTable.AddDungeonID(builder, DungeonIDOffset);
			WeekSignSpringTable.AddEndLv(builder, EndLv);
			WeekSignSpringTable.AddStartLv(builder, StartLv);
			WeekSignSpringTable.AddID(builder, ID);
			return WeekSignSpringTable.EndWeekSignSpringTable(builder);
		}

		// Token: 0x06005526 RID: 21798 RVA: 0x001048F6 File Offset: 0x00102CF6
		public static void StartWeekSignSpringTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06005527 RID: 21799 RVA: 0x001048FF File Offset: 0x00102CFF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005528 RID: 21800 RVA: 0x0010490A File Offset: 0x00102D0A
		public static void AddStartLv(FlatBufferBuilder builder, int StartLv)
		{
			builder.AddInt(1, StartLv, 0);
		}

		// Token: 0x06005529 RID: 21801 RVA: 0x00104915 File Offset: 0x00102D15
		public static void AddEndLv(FlatBufferBuilder builder, int EndLv)
		{
			builder.AddInt(2, EndLv, 0);
		}

		// Token: 0x0600552A RID: 21802 RVA: 0x00104920 File Offset: 0x00102D20
		public static void AddDungeonID(FlatBufferBuilder builder, VectorOffset DungeonIDOffset)
		{
			builder.AddOffset(3, DungeonIDOffset.Value, 0);
		}

		// Token: 0x0600552B RID: 21803 RVA: 0x00104934 File Offset: 0x00102D34
		public static VectorOffset CreateDungeonIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600552C RID: 21804 RVA: 0x00104971 File Offset: 0x00102D71
		public static void StartDungeonIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600552D RID: 21805 RVA: 0x0010497C File Offset: 0x00102D7C
		public static void AddAcquiredMethod(FlatBufferBuilder builder, StringOffset AcquiredMethodOffset)
		{
			builder.AddOffset(4, AcquiredMethodOffset.Value, 0);
		}

		// Token: 0x0600552E RID: 21806 RVA: 0x00104990 File Offset: 0x00102D90
		public static Offset<WeekSignSpringTable> EndWeekSignSpringTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<WeekSignSpringTable>(value);
		}

		// Token: 0x0600552F RID: 21807 RVA: 0x001049AA File Offset: 0x00102DAA
		public static void FinishWeekSignSpringTableBuffer(FlatBufferBuilder builder, Offset<WeekSignSpringTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001EB0 RID: 7856
		private Table __p = new Table();

		// Token: 0x04001EB1 RID: 7857
		private FlatBufferArray<int> DungeonIDValue;

		// Token: 0x02000622 RID: 1570
		public enum eCrypt
		{
			// Token: 0x04001EB3 RID: 7859
			code = -6499428
		}
	}
}
