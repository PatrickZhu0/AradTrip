using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D66 RID: 3430
	public sealed class DModelData : Table
	{
		// Token: 0x06008B4F RID: 35663 RVA: 0x00199706 File Offset: 0x00197B06
		public static DModelData GetRootAsDModelData(ByteBuffer _bb)
		{
			return DModelData.GetRootAsDModelData(_bb, new DModelData());
		}

		// Token: 0x06008B50 RID: 35664 RVA: 0x00199713 File Offset: 0x00197B13
		public static DModelData GetRootAsDModelData(ByteBuffer _bb, DModelData obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008B51 RID: 35665 RVA: 0x0019972F File Offset: 0x00197B2F
		public DModelData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700188F RID: 6287
		// (get) Token: 0x06008B52 RID: 35666 RVA: 0x00199740 File Offset: 0x00197B40
		public string ModelDataName
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17001890 RID: 6288
		// (get) Token: 0x06008B53 RID: 35667 RVA: 0x00199770 File Offset: 0x00197B70
		public string ModelAvatar
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17001891 RID: 6289
		// (get) Token: 0x06008B54 RID: 35668 RVA: 0x0019979F File Offset: 0x00197B9F
		public Vector3 ModelScale
		{
			get
			{
				return this.GetModelScale(new Vector3());
			}
		}

		// Token: 0x06008B55 RID: 35669 RVA: 0x001997AC File Offset: 0x00197BAC
		public Vector3 GetModelScale(Vector3 obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17001892 RID: 6290
		// (get) Token: 0x06008B56 RID: 35670 RVA: 0x001997E1 File Offset: 0x00197BE1
		public Vector3 PreviewLightDir
		{
			get
			{
				return this.GetPreviewLightDir(new Vector3());
			}
		}

		// Token: 0x06008B57 RID: 35671 RVA: 0x001997F0 File Offset: 0x00197BF0
		public Vector3 GetPreviewLightDir(Vector3 obj)
		{
			int num = base.__offset(10);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17001893 RID: 6291
		// (get) Token: 0x06008B58 RID: 35672 RVA: 0x00199826 File Offset: 0x00197C26
		public Color PreviewAmbient
		{
			get
			{
				return this.GetPreviewAmbient(new Color());
			}
		}

		// Token: 0x06008B59 RID: 35673 RVA: 0x00199834 File Offset: 0x00197C34
		public Color GetPreviewAmbient(Color obj)
		{
			int num = base.__offset(12);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x06008B5A RID: 35674 RVA: 0x0019986A File Offset: 0x00197C6A
		public DModelPartChunk GetPartsChunk(int j)
		{
			return this.GetPartsChunk(new DModelPartChunk(), j);
		}

		// Token: 0x06008B5B RID: 35675 RVA: 0x00199878 File Offset: 0x00197C78
		public DModelPartChunk GetPartsChunk(DModelPartChunk obj, int j)
		{
			int num = base.__offset(14);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17001894 RID: 6292
		// (get) Token: 0x06008B5C RID: 35676 RVA: 0x001998B8 File Offset: 0x00197CB8
		public int PartsChunkLength
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x17001895 RID: 6293
		// (get) Token: 0x06008B5D RID: 35677 RVA: 0x001998E1 File Offset: 0x00197CE1
		public DModelAttachmentChunk AttachChunk
		{
			get
			{
				return this.GetAttachChunk(new DModelAttachmentChunk());
			}
		}

		// Token: 0x06008B5E RID: 35678 RVA: 0x001998F0 File Offset: 0x00197CF0
		public DModelAttachmentChunk GetAttachChunk(DModelAttachmentChunk obj)
		{
			int num = base.__offset(16);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17001896 RID: 6294
		// (get) Token: 0x06008B5F RID: 35679 RVA: 0x0019992C File Offset: 0x00197D2C
		public DModelAnimClipChunk AnimClipChunk
		{
			get
			{
				return this.GetAnimClipChunk(new DModelAnimClipChunk());
			}
		}

		// Token: 0x06008B60 RID: 35680 RVA: 0x0019993C File Offset: 0x00197D3C
		public DModelAnimClipChunk GetAnimClipChunk(DModelAnimClipChunk obj)
		{
			int num = base.__offset(18);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x06008B61 RID: 35681 RVA: 0x00199972 File Offset: 0x00197D72
		public DAnimatChunk GetAnimatChunk(int j)
		{
			return this.GetAnimatChunk(new DAnimatChunk(), j);
		}

		// Token: 0x06008B62 RID: 35682 RVA: 0x00199980 File Offset: 0x00197D80
		public DAnimatChunk GetAnimatChunk(DAnimatChunk obj, int j)
		{
			int num = base.__offset(20);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17001897 RID: 6295
		// (get) Token: 0x06008B63 RID: 35683 RVA: 0x001999C0 File Offset: 0x00197DC0
		public int AnimatChunkLength
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x17001898 RID: 6296
		// (get) Token: 0x06008B64 RID: 35684 RVA: 0x001999E9 File Offset: 0x00197DE9
		public DBlockChunk BlockGridChunk
		{
			get
			{
				return this.GetBlockGridChunk(new DBlockChunk());
			}
		}

		// Token: 0x06008B65 RID: 35685 RVA: 0x001999F8 File Offset: 0x00197DF8
		public DBlockChunk GetBlockGridChunk(DBlockChunk obj)
		{
			int num = base.__offset(22);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x06008B66 RID: 35686 RVA: 0x00199A34 File Offset: 0x00197E34
		public static void StartDModelData(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x06008B67 RID: 35687 RVA: 0x00199A3E File Offset: 0x00197E3E
		public static void AddModelDataName(FlatBufferBuilder builder, StringOffset modelDataNameOffset)
		{
			builder.AddOffset(0, modelDataNameOffset.Value, 0);
		}

		// Token: 0x06008B68 RID: 35688 RVA: 0x00199A4F File Offset: 0x00197E4F
		public static void AddModelAvatar(FlatBufferBuilder builder, StringOffset modelAvatarOffset)
		{
			builder.AddOffset(1, modelAvatarOffset.Value, 0);
		}

		// Token: 0x06008B69 RID: 35689 RVA: 0x00199A60 File Offset: 0x00197E60
		public static void AddModelScale(FlatBufferBuilder builder, Offset<Vector3> modelScaleOffset)
		{
			builder.AddStruct(2, modelScaleOffset.Value, 0);
		}

		// Token: 0x06008B6A RID: 35690 RVA: 0x00199A71 File Offset: 0x00197E71
		public static void AddPreviewLightDir(FlatBufferBuilder builder, Offset<Vector3> previewLightDirOffset)
		{
			builder.AddStruct(3, previewLightDirOffset.Value, 0);
		}

		// Token: 0x06008B6B RID: 35691 RVA: 0x00199A82 File Offset: 0x00197E82
		public static void AddPreviewAmbient(FlatBufferBuilder builder, Offset<Color> previewAmbientOffset)
		{
			builder.AddStruct(4, previewAmbientOffset.Value, 0);
		}

		// Token: 0x06008B6C RID: 35692 RVA: 0x00199A93 File Offset: 0x00197E93
		public static void AddPartsChunk(FlatBufferBuilder builder, VectorOffset partsChunkOffset)
		{
			builder.AddOffset(5, partsChunkOffset.Value, 0);
		}

		// Token: 0x06008B6D RID: 35693 RVA: 0x00199AA4 File Offset: 0x00197EA4
		public static VectorOffset CreatePartsChunkVector(FlatBufferBuilder builder, Offset<DModelPartChunk>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06008B6E RID: 35694 RVA: 0x00199AEA File Offset: 0x00197EEA
		public static void StartPartsChunkVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06008B6F RID: 35695 RVA: 0x00199AF5 File Offset: 0x00197EF5
		public static void AddAttachChunk(FlatBufferBuilder builder, Offset<DModelAttachmentChunk> attachChunkOffset)
		{
			builder.AddOffset(6, attachChunkOffset.Value, 0);
		}

		// Token: 0x06008B70 RID: 35696 RVA: 0x00199B06 File Offset: 0x00197F06
		public static void AddAnimClipChunk(FlatBufferBuilder builder, Offset<DModelAnimClipChunk> animClipChunkOffset)
		{
			builder.AddStruct(7, animClipChunkOffset.Value, 0);
		}

		// Token: 0x06008B71 RID: 35697 RVA: 0x00199B17 File Offset: 0x00197F17
		public static void AddAnimatChunk(FlatBufferBuilder builder, VectorOffset animatChunkOffset)
		{
			builder.AddOffset(8, animatChunkOffset.Value, 0);
		}

		// Token: 0x06008B72 RID: 35698 RVA: 0x00199B28 File Offset: 0x00197F28
		public static VectorOffset CreateAnimatChunkVector(FlatBufferBuilder builder, Offset<DAnimatChunk>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06008B73 RID: 35699 RVA: 0x00199B6E File Offset: 0x00197F6E
		public static void StartAnimatChunkVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06008B74 RID: 35700 RVA: 0x00199B79 File Offset: 0x00197F79
		public static void AddBlockGridChunk(FlatBufferBuilder builder, Offset<DBlockChunk> blockGridChunkOffset)
		{
			builder.AddOffset(9, blockGridChunkOffset.Value, 0);
		}

		// Token: 0x06008B75 RID: 35701 RVA: 0x00199B8C File Offset: 0x00197F8C
		public static Offset<DModelData> EndDModelData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DModelData>(value);
		}
	}
}
