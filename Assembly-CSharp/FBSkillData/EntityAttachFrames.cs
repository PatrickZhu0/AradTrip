using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B24 RID: 19236
	public sealed class EntityAttachFrames : Table
	{
		// Token: 0x0601C19C RID: 115100 RVA: 0x0089247E File Offset: 0x0089087E
		public static EntityAttachFrames GetRootAsEntityAttachFrames(ByteBuffer _bb)
		{
			return EntityAttachFrames.GetRootAsEntityAttachFrames(_bb, new EntityAttachFrames());
		}

		// Token: 0x0601C19D RID: 115101 RVA: 0x0089248B File Offset: 0x0089088B
		public static EntityAttachFrames GetRootAsEntityAttachFrames(ByteBuffer _bb, EntityAttachFrames obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C19E RID: 115102 RVA: 0x008924A7 File Offset: 0x008908A7
		public EntityAttachFrames __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026D5 RID: 9941
		// (get) Token: 0x0601C19F RID: 115103 RVA: 0x008924B8 File Offset: 0x008908B8
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026D6 RID: 9942
		// (get) Token: 0x0601C1A0 RID: 115104 RVA: 0x008924E8 File Offset: 0x008908E8
		public int ResID
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026D7 RID: 9943
		// (get) Token: 0x0601C1A1 RID: 115105 RVA: 0x0089251C File Offset: 0x0089091C
		public float Start
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026D8 RID: 9944
		// (get) Token: 0x0601C1A2 RID: 115106 RVA: 0x00892554 File Offset: 0x00890954
		public float End
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026D9 RID: 9945
		// (get) Token: 0x0601C1A3 RID: 115107 RVA: 0x00892590 File Offset: 0x00890990
		public string AttachName
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026DA RID: 9946
		// (get) Token: 0x0601C1A4 RID: 115108 RVA: 0x008925C0 File Offset: 0x008909C0
		public string EntityAsset
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026DB RID: 9947
		// (get) Token: 0x0601C1A5 RID: 115109 RVA: 0x008925F0 File Offset: 0x008909F0
		public TransformParam Trans
		{
			get
			{
				return this.GetTrans(new TransformParam());
			}
		}

		// Token: 0x0601C1A6 RID: 115110 RVA: 0x00892600 File Offset: 0x00890A00
		public TransformParam GetTrans(TransformParam obj)
		{
			int num = base.__offset(16);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601C1A7 RID: 115111 RVA: 0x00892636 File Offset: 0x00890A36
		public AnimationFrames GetAnimations(int j)
		{
			return this.GetAnimations(new AnimationFrames(), j);
		}

		// Token: 0x0601C1A8 RID: 115112 RVA: 0x00892644 File Offset: 0x00890A44
		public AnimationFrames GetAnimations(AnimationFrames obj, int j)
		{
			int num = base.__offset(18);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170026DC RID: 9948
		// (get) Token: 0x0601C1A9 RID: 115113 RVA: 0x00892684 File Offset: 0x00890A84
		public int AnimationsLength
		{
			get
			{
				int num = base.__offset(18);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C1AA RID: 115114 RVA: 0x008926AD File Offset: 0x00890AAD
		public static void StartEntityAttachFrames(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x0601C1AB RID: 115115 RVA: 0x008926B6 File Offset: 0x00890AB6
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C1AC RID: 115116 RVA: 0x008926C7 File Offset: 0x00890AC7
		public static void AddResID(FlatBufferBuilder builder, int resID)
		{
			builder.AddInt(1, resID, 0);
		}

		// Token: 0x0601C1AD RID: 115117 RVA: 0x008926D2 File Offset: 0x00890AD2
		public static void AddStart(FlatBufferBuilder builder, float start)
		{
			builder.AddFloat(2, start, 0.0);
		}

		// Token: 0x0601C1AE RID: 115118 RVA: 0x008926E5 File Offset: 0x00890AE5
		public static void AddEnd(FlatBufferBuilder builder, float end)
		{
			builder.AddFloat(3, end, 0.0);
		}

		// Token: 0x0601C1AF RID: 115119 RVA: 0x008926F8 File Offset: 0x00890AF8
		public static void AddAttachName(FlatBufferBuilder builder, StringOffset attachNameOffset)
		{
			builder.AddOffset(4, attachNameOffset.Value, 0);
		}

		// Token: 0x0601C1B0 RID: 115120 RVA: 0x00892709 File Offset: 0x00890B09
		public static void AddEntityAsset(FlatBufferBuilder builder, StringOffset entityAssetOffset)
		{
			builder.AddOffset(5, entityAssetOffset.Value, 0);
		}

		// Token: 0x0601C1B1 RID: 115121 RVA: 0x0089271A File Offset: 0x00890B1A
		public static void AddTrans(FlatBufferBuilder builder, Offset<TransformParam> transOffset)
		{
			builder.AddStruct(6, transOffset.Value, 0);
		}

		// Token: 0x0601C1B2 RID: 115122 RVA: 0x0089272B File Offset: 0x00890B2B
		public static void AddAnimations(FlatBufferBuilder builder, VectorOffset animationsOffset)
		{
			builder.AddOffset(7, animationsOffset.Value, 0);
		}

		// Token: 0x0601C1B3 RID: 115123 RVA: 0x0089273C File Offset: 0x00890B3C
		public static VectorOffset CreateAnimationsVector(FlatBufferBuilder builder, Offset<AnimationFrames>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C1B4 RID: 115124 RVA: 0x00892782 File Offset: 0x00890B82
		public static void StartAnimationsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C1B5 RID: 115125 RVA: 0x00892790 File Offset: 0x00890B90
		public static Offset<EntityAttachFrames> EndEntityAttachFrames(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EntityAttachFrames>(value);
		}
	}
}
