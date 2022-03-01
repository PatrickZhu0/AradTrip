using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200026C RID: 620
	public class AchievementGroupSubItemTable : IFlatbufferObject
	{
		// Token: 0x1700026A RID: 618
		// (get) Token: 0x0600147F RID: 5247 RVA: 0x0006ADE8 File Offset: 0x000691E8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0006ADF5 File Offset: 0x000691F5
		public static AchievementGroupSubItemTable GetRootAsAchievementGroupSubItemTable(ByteBuffer _bb)
		{
			return AchievementGroupSubItemTable.GetRootAsAchievementGroupSubItemTable(_bb, new AchievementGroupSubItemTable());
		}

		// Token: 0x06001481 RID: 5249 RVA: 0x0006AE02 File Offset: 0x00069202
		public static AchievementGroupSubItemTable GetRootAsAchievementGroupSubItemTable(ByteBuffer _bb, AchievementGroupSubItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x0006AE1E File Offset: 0x0006921E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001483 RID: 5251 RVA: 0x0006AE38 File Offset: 0x00069238
		public AchievementGroupSubItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x0006AE44 File Offset: 0x00069244
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-21208349 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06001485 RID: 5253 RVA: 0x0006AE90 File Offset: 0x00069290
		public int sort0
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-21208349 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06001486 RID: 5254 RVA: 0x0006AEDC File Offset: 0x000692DC
		public int sort1
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-21208349 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x0006AF28 File Offset: 0x00069328
		public string Name
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0006AF6B File Offset: 0x0006936B
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06001489 RID: 5257 RVA: 0x0006AF7C File Offset: 0x0006937C
		public int Type
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-21208349 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600148A RID: 5258 RVA: 0x0006AFC8 File Offset: 0x000693C8
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0006B00B File Offset: 0x0006940B
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x0600148C RID: 5260 RVA: 0x0006B01C File Offset: 0x0006941C
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0006B05F File Offset: 0x0006945F
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x0600148E RID: 5262 RVA: 0x0006B070 File Offset: 0x00069470
		public int FunctionID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-21208349 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x0600148F RID: 5263 RVA: 0x0006B0BC File Offset: 0x000694BC
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001490 RID: 5264 RVA: 0x0006B0FF File Offset: 0x000694FF
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06001491 RID: 5265 RVA: 0x0006B110 File Offset: 0x00069510
		public static Offset<AchievementGroupSubItemTable> CreateAchievementGroupSubItemTable(FlatBufferBuilder builder, int ID = 0, int sort0 = 0, int sort1 = 0, StringOffset NameOffset = default(StringOffset), int Type = 0, StringOffset IconOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), int FunctionID = 0, StringOffset LinkInfoOffset = default(StringOffset))
		{
			builder.StartObject(9);
			AchievementGroupSubItemTable.AddLinkInfo(builder, LinkInfoOffset);
			AchievementGroupSubItemTable.AddFunctionID(builder, FunctionID);
			AchievementGroupSubItemTable.AddDesc(builder, DescOffset);
			AchievementGroupSubItemTable.AddIcon(builder, IconOffset);
			AchievementGroupSubItemTable.AddType(builder, Type);
			AchievementGroupSubItemTable.AddName(builder, NameOffset);
			AchievementGroupSubItemTable.AddSort1(builder, sort1);
			AchievementGroupSubItemTable.AddSort0(builder, sort0);
			AchievementGroupSubItemTable.AddID(builder, ID);
			return AchievementGroupSubItemTable.EndAchievementGroupSubItemTable(builder);
		}

		// Token: 0x06001492 RID: 5266 RVA: 0x0006B170 File Offset: 0x00069570
		public static void StartAchievementGroupSubItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0006B17A File Offset: 0x0006957A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0006B185 File Offset: 0x00069585
		public static void AddSort0(FlatBufferBuilder builder, int sort0)
		{
			builder.AddInt(1, sort0, 0);
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0006B190 File Offset: 0x00069590
		public static void AddSort1(FlatBufferBuilder builder, int sort1)
		{
			builder.AddInt(2, sort1, 0);
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x0006B19B File Offset: 0x0006959B
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(3, NameOffset.Value, 0);
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x0006B1AC File Offset: 0x000695AC
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(4, Type, 0);
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x0006B1B7 File Offset: 0x000695B7
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(5, IconOffset.Value, 0);
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x0006B1C8 File Offset: 0x000695C8
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(6, DescOffset.Value, 0);
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x0006B1D9 File Offset: 0x000695D9
		public static void AddFunctionID(FlatBufferBuilder builder, int FunctionID)
		{
			builder.AddInt(7, FunctionID, 0);
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x0006B1E4 File Offset: 0x000695E4
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(8, LinkInfoOffset.Value, 0);
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x0006B1F8 File Offset: 0x000695F8
		public static Offset<AchievementGroupSubItemTable> EndAchievementGroupSubItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AchievementGroupSubItemTable>(value);
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0006B212 File Offset: 0x00069612
		public static void FinishAchievementGroupSubItemTableBuffer(FlatBufferBuilder builder, Offset<AchievementGroupSubItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D6A RID: 3434
		private Table __p = new Table();

		// Token: 0x0200026D RID: 621
		public enum eCrypt
		{
			// Token: 0x04000D6C RID: 3436
			code = -21208349
		}
	}
}
