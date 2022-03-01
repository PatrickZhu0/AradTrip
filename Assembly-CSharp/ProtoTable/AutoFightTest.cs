using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002CA RID: 714
	public class AutoFightTest : IFlatbufferObject
	{
		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x0600197D RID: 6525 RVA: 0x00075BBC File Offset: 0x00073FBC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600197E RID: 6526 RVA: 0x00075BC9 File Offset: 0x00073FC9
		public static AutoFightTest GetRootAsAutoFightTest(ByteBuffer _bb)
		{
			return AutoFightTest.GetRootAsAutoFightTest(_bb, new AutoFightTest());
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x00075BD6 File Offset: 0x00073FD6
		public static AutoFightTest GetRootAsAutoFightTest(ByteBuffer _bb, AutoFightTest obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x00075BF2 File Offset: 0x00073FF2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x00075C0C File Offset: 0x0007400C
		public AutoFightTest __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06001982 RID: 6530 RVA: 0x00075C18 File Offset: 0x00074018
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (637706797 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06001983 RID: 6531 RVA: 0x00075C64 File Offset: 0x00074064
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (637706797 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06001984 RID: 6532 RVA: 0x00075CB0 File Offset: 0x000740B0
		public int ChapterId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (637706797 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06001985 RID: 6533 RVA: 0x00075CFC File Offset: 0x000740FC
		public int DungeonId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (637706797 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06001986 RID: 6534 RVA: 0x00075D48 File Offset: 0x00074148
		public string Name
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x00075D8B File Offset: 0x0007418B
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x00075D9A File Offset: 0x0007419A
		public static Offset<AutoFightTest> CreateAutoFightTest(FlatBufferBuilder builder, int ID = 0, int Type = 0, int ChapterId = 0, int DungeonId = 0, StringOffset NameOffset = default(StringOffset))
		{
			builder.StartObject(5);
			AutoFightTest.AddName(builder, NameOffset);
			AutoFightTest.AddDungeonId(builder, DungeonId);
			AutoFightTest.AddChapterId(builder, ChapterId);
			AutoFightTest.AddType(builder, Type);
			AutoFightTest.AddID(builder, ID);
			return AutoFightTest.EndAutoFightTest(builder);
		}

		// Token: 0x06001989 RID: 6537 RVA: 0x00075DCE File Offset: 0x000741CE
		public static void StartAutoFightTest(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0600198A RID: 6538 RVA: 0x00075DD7 File Offset: 0x000741D7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600198B RID: 6539 RVA: 0x00075DE2 File Offset: 0x000741E2
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x0600198C RID: 6540 RVA: 0x00075DED File Offset: 0x000741ED
		public static void AddChapterId(FlatBufferBuilder builder, int ChapterId)
		{
			builder.AddInt(2, ChapterId, 0);
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x00075DF8 File Offset: 0x000741F8
		public static void AddDungeonId(FlatBufferBuilder builder, int DungeonId)
		{
			builder.AddInt(3, DungeonId, 0);
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x00075E03 File Offset: 0x00074203
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(4, NameOffset.Value, 0);
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x00075E14 File Offset: 0x00074214
		public static Offset<AutoFightTest> EndAutoFightTest(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AutoFightTest>(value);
		}

		// Token: 0x06001990 RID: 6544 RVA: 0x00075E2E File Offset: 0x0007422E
		public static void FinishAutoFightTestBuffer(FlatBufferBuilder builder, Offset<AutoFightTest> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E8D RID: 3725
		private Table __p = new Table();

		// Token: 0x020002CB RID: 715
		public enum eCrypt
		{
			// Token: 0x04000E8F RID: 3727
			code = 637706797
		}
	}
}
