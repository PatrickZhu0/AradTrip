using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000457 RID: 1111
	public class GuidanceMainItemTable : IFlatbufferObject
	{
		// Token: 0x17000D50 RID: 3408
		// (get) Token: 0x0600356F RID: 13679 RVA: 0x000B9648 File Offset: 0x000B7A48
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003570 RID: 13680 RVA: 0x000B9655 File Offset: 0x000B7A55
		public static GuidanceMainItemTable GetRootAsGuidanceMainItemTable(ByteBuffer _bb)
		{
			return GuidanceMainItemTable.GetRootAsGuidanceMainItemTable(_bb, new GuidanceMainItemTable());
		}

		// Token: 0x06003571 RID: 13681 RVA: 0x000B9662 File Offset: 0x000B7A62
		public static GuidanceMainItemTable GetRootAsGuidanceMainItemTable(ByteBuffer _bb, GuidanceMainItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003572 RID: 13682 RVA: 0x000B967E File Offset: 0x000B7A7E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003573 RID: 13683 RVA: 0x000B9698 File Offset: 0x000B7A98
		public GuidanceMainItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D51 RID: 3409
		// (get) Token: 0x06003574 RID: 13684 RVA: 0x000B96A4 File Offset: 0x000B7AA4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (146672630 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D52 RID: 3410
		// (get) Token: 0x06003575 RID: 13685 RVA: 0x000B96F0 File Offset: 0x000B7AF0
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003576 RID: 13686 RVA: 0x000B9732 File Offset: 0x000B7B32
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D53 RID: 3411
		// (get) Token: 0x06003577 RID: 13687 RVA: 0x000B9740 File Offset: 0x000B7B40
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003578 RID: 13688 RVA: 0x000B9782 File Offset: 0x000B7B82
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000D54 RID: 3412
		// (get) Token: 0x06003579 RID: 13689 RVA: 0x000B9790 File Offset: 0x000B7B90
		public int FunctionId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (146672630 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D55 RID: 3413
		// (get) Token: 0x0600357A RID: 13690 RVA: 0x000B97DC File Offset: 0x000B7BDC
		public int recommandLv
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (146672630 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D56 RID: 3414
		// (get) Token: 0x0600357B RID: 13691 RVA: 0x000B9828 File Offset: 0x000B7C28
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600357C RID: 13692 RVA: 0x000B986B File Offset: 0x000B7C6B
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000D57 RID: 3415
		// (get) Token: 0x0600357D RID: 13693 RVA: 0x000B987C File Offset: 0x000B7C7C
		public int bCloseFrame
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (146672630 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600357E RID: 13694 RVA: 0x000B98C8 File Offset: 0x000B7CC8
		public static Offset<GuidanceMainItemTable> CreateGuidanceMainItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset IconOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), int FunctionId = 0, int recommandLv = 0, StringOffset LinkInfoOffset = default(StringOffset), int bCloseFrame = 0)
		{
			builder.StartObject(7);
			GuidanceMainItemTable.AddBCloseFrame(builder, bCloseFrame);
			GuidanceMainItemTable.AddLinkInfo(builder, LinkInfoOffset);
			GuidanceMainItemTable.AddRecommandLv(builder, recommandLv);
			GuidanceMainItemTable.AddFunctionId(builder, FunctionId);
			GuidanceMainItemTable.AddDesc(builder, DescOffset);
			GuidanceMainItemTable.AddIcon(builder, IconOffset);
			GuidanceMainItemTable.AddID(builder, ID);
			return GuidanceMainItemTable.EndGuidanceMainItemTable(builder);
		}

		// Token: 0x0600357F RID: 13695 RVA: 0x000B9917 File Offset: 0x000B7D17
		public static void StartGuidanceMainItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06003580 RID: 13696 RVA: 0x000B9920 File Offset: 0x000B7D20
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003581 RID: 13697 RVA: 0x000B992B File Offset: 0x000B7D2B
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(1, IconOffset.Value, 0);
		}

		// Token: 0x06003582 RID: 13698 RVA: 0x000B993C File Offset: 0x000B7D3C
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(2, DescOffset.Value, 0);
		}

		// Token: 0x06003583 RID: 13699 RVA: 0x000B994D File Offset: 0x000B7D4D
		public static void AddFunctionId(FlatBufferBuilder builder, int FunctionId)
		{
			builder.AddInt(3, FunctionId, 0);
		}

		// Token: 0x06003584 RID: 13700 RVA: 0x000B9958 File Offset: 0x000B7D58
		public static void AddRecommandLv(FlatBufferBuilder builder, int recommandLv)
		{
			builder.AddInt(4, recommandLv, 0);
		}

		// Token: 0x06003585 RID: 13701 RVA: 0x000B9963 File Offset: 0x000B7D63
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(5, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06003586 RID: 13702 RVA: 0x000B9974 File Offset: 0x000B7D74
		public static void AddBCloseFrame(FlatBufferBuilder builder, int bCloseFrame)
		{
			builder.AddInt(6, bCloseFrame, 0);
		}

		// Token: 0x06003587 RID: 13703 RVA: 0x000B9980 File Offset: 0x000B7D80
		public static Offset<GuidanceMainItemTable> EndGuidanceMainItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuidanceMainItemTable>(value);
		}

		// Token: 0x06003588 RID: 13704 RVA: 0x000B999A File Offset: 0x000B7D9A
		public static void FinishGuidanceMainItemTableBuffer(FlatBufferBuilder builder, Offset<GuidanceMainItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400158D RID: 5517
		private Table __p = new Table();

		// Token: 0x02000458 RID: 1112
		public enum eCrypt
		{
			// Token: 0x0400158F RID: 5519
			code = 146672630
		}
	}
}
