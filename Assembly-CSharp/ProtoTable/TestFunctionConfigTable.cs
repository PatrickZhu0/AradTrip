using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000602 RID: 1538
	public class TestFunctionConfigTable : IFlatbufferObject
	{
		// Token: 0x17001673 RID: 5747
		// (get) Token: 0x0600514D RID: 20813 RVA: 0x000FA7F0 File Offset: 0x000F8BF0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600514E RID: 20814 RVA: 0x000FA7FD File Offset: 0x000F8BFD
		public static TestFunctionConfigTable GetRootAsTestFunctionConfigTable(ByteBuffer _bb)
		{
			return TestFunctionConfigTable.GetRootAsTestFunctionConfigTable(_bb, new TestFunctionConfigTable());
		}

		// Token: 0x0600514F RID: 20815 RVA: 0x000FA80A File Offset: 0x000F8C0A
		public static TestFunctionConfigTable GetRootAsTestFunctionConfigTable(ByteBuffer _bb, TestFunctionConfigTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005150 RID: 20816 RVA: 0x000FA826 File Offset: 0x000F8C26
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005151 RID: 20817 RVA: 0x000FA840 File Offset: 0x000F8C40
		public TestFunctionConfigTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001674 RID: 5748
		// (get) Token: 0x06005152 RID: 20818 RVA: 0x000FA84C File Offset: 0x000F8C4C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-746320344 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001675 RID: 5749
		// (get) Token: 0x06005153 RID: 20819 RVA: 0x000FA898 File Offset: 0x000F8C98
		public bool Open
		{
			get
			{
				int num = this.__p.__offset(6);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005154 RID: 20820 RVA: 0x000FA8E1 File Offset: 0x000F8CE1
		public static Offset<TestFunctionConfigTable> CreateTestFunctionConfigTable(FlatBufferBuilder builder, int ID = 0, bool Open = false)
		{
			builder.StartObject(2);
			TestFunctionConfigTable.AddID(builder, ID);
			TestFunctionConfigTable.AddOpen(builder, Open);
			return TestFunctionConfigTable.EndTestFunctionConfigTable(builder);
		}

		// Token: 0x06005155 RID: 20821 RVA: 0x000FA8FE File Offset: 0x000F8CFE
		public static void StartTestFunctionConfigTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06005156 RID: 20822 RVA: 0x000FA907 File Offset: 0x000F8D07
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005157 RID: 20823 RVA: 0x000FA912 File Offset: 0x000F8D12
		public static void AddOpen(FlatBufferBuilder builder, bool Open)
		{
			builder.AddBool(1, Open, false);
		}

		// Token: 0x06005158 RID: 20824 RVA: 0x000FA920 File Offset: 0x000F8D20
		public static Offset<TestFunctionConfigTable> EndTestFunctionConfigTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TestFunctionConfigTable>(value);
		}

		// Token: 0x06005159 RID: 20825 RVA: 0x000FA93A File Offset: 0x000F8D3A
		public static void FinishTestFunctionConfigTableBuffer(FlatBufferBuilder builder, Offset<TestFunctionConfigTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E0C RID: 7692
		private Table __p = new Table();

		// Token: 0x02000603 RID: 1539
		public enum eCrypt
		{
			// Token: 0x04001E0E RID: 7694
			code = -746320344
		}
	}
}
