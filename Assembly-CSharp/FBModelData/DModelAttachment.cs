using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D5E RID: 3422
	public sealed class DModelAttachment : Table
	{
		// Token: 0x06008AE8 RID: 35560 RVA: 0x00198CB2 File Offset: 0x001970B2
		public static DModelAttachment GetRootAsDModelAttachment(ByteBuffer _bb)
		{
			return DModelAttachment.GetRootAsDModelAttachment(_bb, new DModelAttachment());
		}

		// Token: 0x06008AE9 RID: 35561 RVA: 0x00198CBF File Offset: 0x001970BF
		public static DModelAttachment GetRootAsDModelAttachment(ByteBuffer _bb, DModelAttachment obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008AEA RID: 35562 RVA: 0x00198CDB File Offset: 0x001970DB
		public DModelAttachment __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700187D RID: 6269
		// (get) Token: 0x06008AEB RID: 35563 RVA: 0x00198CEC File Offset: 0x001970EC
		public string AttahcmentAsset
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x06008AEC RID: 35564 RVA: 0x00198D1B File Offset: 0x0019711B
		public static Offset<DModelAttachment> CreateDModelAttachment(FlatBufferBuilder builder, StringOffset attahcmentAsset = default(StringOffset))
		{
			builder.StartObject(1);
			DModelAttachment.AddAttahcmentAsset(builder, attahcmentAsset);
			return DModelAttachment.EndDModelAttachment(builder);
		}

		// Token: 0x06008AED RID: 35565 RVA: 0x00198D31 File Offset: 0x00197131
		public static void StartDModelAttachment(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x06008AEE RID: 35566 RVA: 0x00198D3A File Offset: 0x0019713A
		public static void AddAttahcmentAsset(FlatBufferBuilder builder, StringOffset attahcmentAssetOffset)
		{
			builder.AddOffset(0, attahcmentAssetOffset.Value, 0);
		}

		// Token: 0x06008AEF RID: 35567 RVA: 0x00198D4C File Offset: 0x0019714C
		public static Offset<DModelAttachment> EndDModelAttachment(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DModelAttachment>(value);
		}
	}
}
