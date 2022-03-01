using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000629 RID: 1577
	public class coolname : IFlatbufferObject
	{
		// Token: 0x17001814 RID: 6164
		// (get) Token: 0x06005581 RID: 21889 RVA: 0x00105528 File Offset: 0x00103928
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005582 RID: 21890 RVA: 0x00105535 File Offset: 0x00103935
		public static coolname GetRootAscoolname(ByteBuffer _bb)
		{
			return coolname.GetRootAscoolname(_bb, new coolname());
		}

		// Token: 0x06005583 RID: 21891 RVA: 0x00105542 File Offset: 0x00103942
		public static coolname GetRootAscoolname(ByteBuffer _bb, coolname obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005584 RID: 21892 RVA: 0x0010555E File Offset: 0x0010395E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005585 RID: 21893 RVA: 0x00105578 File Offset: 0x00103978
		public coolname __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001815 RID: 6165
		// (get) Token: 0x06005586 RID: 21894 RVA: 0x00105584 File Offset: 0x00103984
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (498103660 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001816 RID: 6166
		// (get) Token: 0x06005587 RID: 21895 RVA: 0x001055D0 File Offset: 0x001039D0
		public int Char
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (498103660 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005588 RID: 21896 RVA: 0x00105619 File Offset: 0x00103A19
		public static Offset<coolname> Createcoolname(FlatBufferBuilder builder, int ID = 0, int Char = 0)
		{
			builder.StartObject(2);
			coolname.AddChar(builder, Char);
			coolname.AddID(builder, ID);
			return coolname.Endcoolname(builder);
		}

		// Token: 0x06005589 RID: 21897 RVA: 0x00105636 File Offset: 0x00103A36
		public static void Startcoolname(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0600558A RID: 21898 RVA: 0x0010563F File Offset: 0x00103A3F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600558B RID: 21899 RVA: 0x0010564A File Offset: 0x00103A4A
		public static void AddChar(FlatBufferBuilder builder, int Char)
		{
			builder.AddInt(1, Char, 0);
		}

		// Token: 0x0600558C RID: 21900 RVA: 0x00105658 File Offset: 0x00103A58
		public static Offset<coolname> Endcoolname(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<coolname>(value);
		}

		// Token: 0x0600558D RID: 21901 RVA: 0x00105672 File Offset: 0x00103A72
		public static void FinishcoolnameBuffer(FlatBufferBuilder builder, Offset<coolname> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001EBE RID: 7870
		private Table __p = new Table();

		// Token: 0x0200062A RID: 1578
		public enum eCrypt
		{
			// Token: 0x04001EC0 RID: 7872
			code = 498103660
		}
	}
}
