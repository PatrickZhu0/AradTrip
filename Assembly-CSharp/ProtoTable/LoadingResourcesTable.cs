using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004DE RID: 1246
	public class LoadingResourcesTable : IFlatbufferObject
	{
		// Token: 0x1700107E RID: 4222
		// (get) Token: 0x06003F07 RID: 16135 RVA: 0x000D0234 File Offset: 0x000CE634
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003F08 RID: 16136 RVA: 0x000D0241 File Offset: 0x000CE641
		public static LoadingResourcesTable GetRootAsLoadingResourcesTable(ByteBuffer _bb)
		{
			return LoadingResourcesTable.GetRootAsLoadingResourcesTable(_bb, new LoadingResourcesTable());
		}

		// Token: 0x06003F09 RID: 16137 RVA: 0x000D024E File Offset: 0x000CE64E
		public static LoadingResourcesTable GetRootAsLoadingResourcesTable(ByteBuffer _bb, LoadingResourcesTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003F0A RID: 16138 RVA: 0x000D026A File Offset: 0x000CE66A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003F0B RID: 16139 RVA: 0x000D0284 File Offset: 0x000CE684
		public LoadingResourcesTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700107F RID: 4223
		// (get) Token: 0x06003F0C RID: 16140 RVA: 0x000D0290 File Offset: 0x000CE690
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (654184969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001080 RID: 4224
		// (get) Token: 0x06003F0D RID: 16141 RVA: 0x000D02DC File Offset: 0x000CE6DC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003F0E RID: 16142 RVA: 0x000D031E File Offset: 0x000CE71E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001081 RID: 4225
		// (get) Token: 0x06003F0F RID: 16143 RVA: 0x000D032C File Offset: 0x000CE72C
		public LoadingResourcesTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (LoadingResourcesTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001082 RID: 4226
		// (get) Token: 0x06003F10 RID: 16144 RVA: 0x000D0370 File Offset: 0x000CE770
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (654184969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001083 RID: 4227
		// (get) Token: 0x06003F11 RID: 16145 RVA: 0x000D03BC File Offset: 0x000CE7BC
		public string Resources
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003F12 RID: 16146 RVA: 0x000D03FF File Offset: 0x000CE7FF
		public ArraySegment<byte>? GetResourcesBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001084 RID: 4228
		// (get) Token: 0x06003F13 RID: 16147 RVA: 0x000D0410 File Offset: 0x000CE810
		public string Text
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003F14 RID: 16148 RVA: 0x000D0453 File Offset: 0x000CE853
		public ArraySegment<byte>? GetTextBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06003F15 RID: 16149 RVA: 0x000D0462 File Offset: 0x000CE862
		public static Offset<LoadingResourcesTable> CreateLoadingResourcesTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), LoadingResourcesTable.eType Type = LoadingResourcesTable.eType.AT_NONE, int Level = 0, StringOffset ResourcesOffset = default(StringOffset), StringOffset TextOffset = default(StringOffset))
		{
			builder.StartObject(6);
			LoadingResourcesTable.AddText(builder, TextOffset);
			LoadingResourcesTable.AddResources(builder, ResourcesOffset);
			LoadingResourcesTable.AddLevel(builder, Level);
			LoadingResourcesTable.AddType(builder, Type);
			LoadingResourcesTable.AddName(builder, NameOffset);
			LoadingResourcesTable.AddID(builder, ID);
			return LoadingResourcesTable.EndLoadingResourcesTable(builder);
		}

		// Token: 0x06003F16 RID: 16150 RVA: 0x000D049E File Offset: 0x000CE89E
		public static void StartLoadingResourcesTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06003F17 RID: 16151 RVA: 0x000D04A7 File Offset: 0x000CE8A7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003F18 RID: 16152 RVA: 0x000D04B2 File Offset: 0x000CE8B2
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003F19 RID: 16153 RVA: 0x000D04C3 File Offset: 0x000CE8C3
		public static void AddType(FlatBufferBuilder builder, LoadingResourcesTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06003F1A RID: 16154 RVA: 0x000D04CE File Offset: 0x000CE8CE
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x06003F1B RID: 16155 RVA: 0x000D04D9 File Offset: 0x000CE8D9
		public static void AddResources(FlatBufferBuilder builder, StringOffset ResourcesOffset)
		{
			builder.AddOffset(4, ResourcesOffset.Value, 0);
		}

		// Token: 0x06003F1C RID: 16156 RVA: 0x000D04EA File Offset: 0x000CE8EA
		public static void AddText(FlatBufferBuilder builder, StringOffset TextOffset)
		{
			builder.AddOffset(5, TextOffset.Value, 0);
		}

		// Token: 0x06003F1D RID: 16157 RVA: 0x000D04FC File Offset: 0x000CE8FC
		public static Offset<LoadingResourcesTable> EndLoadingResourcesTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<LoadingResourcesTable>(value);
		}

		// Token: 0x06003F1E RID: 16158 RVA: 0x000D0516 File Offset: 0x000CE916
		public static void FinishLoadingResourcesTableBuffer(FlatBufferBuilder builder, Offset<LoadingResourcesTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017F6 RID: 6134
		private Table __p = new Table();

		// Token: 0x020004DF RID: 1247
		public enum eType
		{
			// Token: 0x040017F8 RID: 6136
			AT_NONE,
			// Token: 0x040017F9 RID: 6137
			AT_EQUIP,
			// Token: 0x040017FA RID: 6138
			AT_DEFENCE
		}

		// Token: 0x020004E0 RID: 1248
		public enum eCrypt
		{
			// Token: 0x040017FC RID: 6140
			code = 654184969
		}
	}
}
