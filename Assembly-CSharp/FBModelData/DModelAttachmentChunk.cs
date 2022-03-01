using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D5F RID: 3423
	public sealed class DModelAttachmentChunk : Table
	{
		// Token: 0x06008AF1 RID: 35569 RVA: 0x00198D6E File Offset: 0x0019716E
		public static DModelAttachmentChunk GetRootAsDModelAttachmentChunk(ByteBuffer _bb)
		{
			return DModelAttachmentChunk.GetRootAsDModelAttachmentChunk(_bb, new DModelAttachmentChunk());
		}

		// Token: 0x06008AF2 RID: 35570 RVA: 0x00198D7B File Offset: 0x0019717B
		public static DModelAttachmentChunk GetRootAsDModelAttachmentChunk(ByteBuffer _bb, DModelAttachmentChunk obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008AF3 RID: 35571 RVA: 0x00198D97 File Offset: 0x00197197
		public DModelAttachmentChunk __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x06008AF4 RID: 35572 RVA: 0x00198DA8 File Offset: 0x001971A8
		public DModelAttachment GetAttachments(int j)
		{
			return this.GetAttachments(new DModelAttachment(), j);
		}

		// Token: 0x06008AF5 RID: 35573 RVA: 0x00198DB8 File Offset: 0x001971B8
		public DModelAttachment GetAttachments(DModelAttachment obj, int j)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x1700187E RID: 6270
		// (get) Token: 0x06008AF6 RID: 35574 RVA: 0x00198DF8 File Offset: 0x001971F8
		public int AttachmentsLength
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x06008AF7 RID: 35575 RVA: 0x00198E20 File Offset: 0x00197220
		public static Offset<DModelAttachmentChunk> CreateDModelAttachmentChunk(FlatBufferBuilder builder, VectorOffset attachments = default(VectorOffset))
		{
			builder.StartObject(1);
			DModelAttachmentChunk.AddAttachments(builder, attachments);
			return DModelAttachmentChunk.EndDModelAttachmentChunk(builder);
		}

		// Token: 0x06008AF8 RID: 35576 RVA: 0x00198E36 File Offset: 0x00197236
		public static void StartDModelAttachmentChunk(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x06008AF9 RID: 35577 RVA: 0x00198E3F File Offset: 0x0019723F
		public static void AddAttachments(FlatBufferBuilder builder, VectorOffset attachmentsOffset)
		{
			builder.AddOffset(0, attachmentsOffset.Value, 0);
		}

		// Token: 0x06008AFA RID: 35578 RVA: 0x00198E50 File Offset: 0x00197250
		public static VectorOffset CreateAttachmentsVector(FlatBufferBuilder builder, Offset<DModelAttachment>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06008AFB RID: 35579 RVA: 0x00198E96 File Offset: 0x00197296
		public static void StartAttachmentsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06008AFC RID: 35580 RVA: 0x00198EA4 File Offset: 0x001972A4
		public static Offset<DModelAttachmentChunk> EndDModelAttachmentChunk(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DModelAttachmentChunk>(value);
		}
	}
}
