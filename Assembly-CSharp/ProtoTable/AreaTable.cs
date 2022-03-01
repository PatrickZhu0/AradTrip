using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002A7 RID: 679
	public class AreaTable : IFlatbufferObject
	{
		// Token: 0x17000389 RID: 905
		// (get) Token: 0x0600182F RID: 6191 RVA: 0x00072EF0 File Offset: 0x000712F0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001830 RID: 6192 RVA: 0x00072EFD File Offset: 0x000712FD
		public static AreaTable GetRootAsAreaTable(ByteBuffer _bb)
		{
			return AreaTable.GetRootAsAreaTable(_bb, new AreaTable());
		}

		// Token: 0x06001831 RID: 6193 RVA: 0x00072F0A File Offset: 0x0007130A
		public static AreaTable GetRootAsAreaTable(ByteBuffer _bb, AreaTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001832 RID: 6194 RVA: 0x00072F26 File Offset: 0x00071326
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001833 RID: 6195 RVA: 0x00072F40 File Offset: 0x00071340
		public AreaTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06001834 RID: 6196 RVA: 0x00072F4C File Offset: 0x0007134C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (136518473 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06001835 RID: 6197 RVA: 0x00072F98 File Offset: 0x00071398
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001836 RID: 6198 RVA: 0x00072FDA File Offset: 0x000713DA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06001837 RID: 6199 RVA: 0x00072FE8 File Offset: 0x000713E8
		public int MainlandID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (136518473 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001838 RID: 6200 RVA: 0x00073034 File Offset: 0x00071434
		public int TownIDsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (136518473 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06001839 RID: 6201 RVA: 0x00073084 File Offset: 0x00071484
		public int TownIDsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600183A RID: 6202 RVA: 0x000730B7 File Offset: 0x000714B7
		public ArraySegment<byte>? GetTownIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x0600183B RID: 6203 RVA: 0x000730C6 File Offset: 0x000714C6
		public FlatBufferArray<int> TownIDs
		{
			get
			{
				if (this.TownIDsValue == null)
				{
					this.TownIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.TownIDsArray), this.TownIDsLength);
				}
				return this.TownIDsValue;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x0600183C RID: 6204 RVA: 0x000730F8 File Offset: 0x000714F8
		public string LoadBG
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600183D RID: 6205 RVA: 0x0007313B File Offset: 0x0007153B
		public ArraySegment<byte>? GetLoadBGBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x0007314A File Offset: 0x0007154A
		public static Offset<AreaTable> CreateAreaTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int MainlandID = 0, VectorOffset TownIDsOffset = default(VectorOffset), StringOffset LoadBGOffset = default(StringOffset))
		{
			builder.StartObject(5);
			AreaTable.AddLoadBG(builder, LoadBGOffset);
			AreaTable.AddTownIDs(builder, TownIDsOffset);
			AreaTable.AddMainlandID(builder, MainlandID);
			AreaTable.AddName(builder, NameOffset);
			AreaTable.AddID(builder, ID);
			return AreaTable.EndAreaTable(builder);
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x0007317E File Offset: 0x0007157E
		public static void StartAreaTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x00073187 File Offset: 0x00071587
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x00073192 File Offset: 0x00071592
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x000731A3 File Offset: 0x000715A3
		public static void AddMainlandID(FlatBufferBuilder builder, int MainlandID)
		{
			builder.AddInt(2, MainlandID, 0);
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x000731AE File Offset: 0x000715AE
		public static void AddTownIDs(FlatBufferBuilder builder, VectorOffset TownIDsOffset)
		{
			builder.AddOffset(3, TownIDsOffset.Value, 0);
		}

		// Token: 0x06001844 RID: 6212 RVA: 0x000731C0 File Offset: 0x000715C0
		public static VectorOffset CreateTownIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001845 RID: 6213 RVA: 0x000731FD File Offset: 0x000715FD
		public static void StartTownIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x00073208 File Offset: 0x00071608
		public static void AddLoadBG(FlatBufferBuilder builder, StringOffset LoadBGOffset)
		{
			builder.AddOffset(4, LoadBGOffset.Value, 0);
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x0007321C File Offset: 0x0007161C
		public static Offset<AreaTable> EndAreaTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AreaTable>(value);
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x00073236 File Offset: 0x00071636
		public static void FinishAreaTableBuffer(FlatBufferBuilder builder, Offset<AreaTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DF4 RID: 3572
		private Table __p = new Table();

		// Token: 0x04000DF5 RID: 3573
		private FlatBufferArray<int> TownIDsValue;

		// Token: 0x020002A8 RID: 680
		public enum eCrypt
		{
			// Token: 0x04000DF7 RID: 3575
			code = 136518473
		}
	}
}
