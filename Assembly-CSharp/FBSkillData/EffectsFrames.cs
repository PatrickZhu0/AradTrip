using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B1F RID: 19231
	public sealed class EffectsFrames : Table
	{
		// Token: 0x0601C0E3 RID: 114915 RVA: 0x00890D01 File Offset: 0x0088F101
		public static EffectsFrames GetRootAsEffectsFrames(ByteBuffer _bb)
		{
			return EffectsFrames.GetRootAsEffectsFrames(_bb, new EffectsFrames());
		}

		// Token: 0x0601C0E4 RID: 114916 RVA: 0x00890D0E File Offset: 0x0088F10E
		public static EffectsFrames GetRootAsEffectsFrames(ByteBuffer _bb, EffectsFrames obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C0E5 RID: 114917 RVA: 0x00890D2A File Offset: 0x0088F12A
		public EffectsFrames __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002686 RID: 9862
		// (get) Token: 0x0601C0E6 RID: 114918 RVA: 0x00890D3C File Offset: 0x0088F13C
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002687 RID: 9863
		// (get) Token: 0x0601C0E7 RID: 114919 RVA: 0x00890D6C File Offset: 0x0088F16C
		public int EffectResID
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002688 RID: 9864
		// (get) Token: 0x0601C0E8 RID: 114920 RVA: 0x00890DA0 File Offset: 0x0088F1A0
		public int StartFrames
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002689 RID: 9865
		// (get) Token: 0x0601C0E9 RID: 114921 RVA: 0x00890DD4 File Offset: 0x0088F1D4
		public int EndFrames
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700268A RID: 9866
		// (get) Token: 0x0601C0EA RID: 114922 RVA: 0x00890E0C File Offset: 0x0088F20C
		public string Attachname
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700268B RID: 9867
		// (get) Token: 0x0601C0EB RID: 114923 RVA: 0x00890E3C File Offset: 0x0088F23C
		public int Playtype
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700268C RID: 9868
		// (get) Token: 0x0601C0EC RID: 114924 RVA: 0x00890E74 File Offset: 0x0088F274
		public int Timetype
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700268D RID: 9869
		// (get) Token: 0x0601C0ED RID: 114925 RVA: 0x00890EAC File Offset: 0x0088F2AC
		public float Time
		{
			get
			{
				int num = base.__offset(18);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700268E RID: 9870
		// (get) Token: 0x0601C0EE RID: 114926 RVA: 0x00890EE8 File Offset: 0x0088F2E8
		public string EffectAsset
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700268F RID: 9871
		// (get) Token: 0x0601C0EF RID: 114927 RVA: 0x00890F18 File Offset: 0x0088F318
		public int AttachPoint
		{
			get
			{
				int num = base.__offset(22);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002690 RID: 9872
		// (get) Token: 0x0601C0F0 RID: 114928 RVA: 0x00890F4D File Offset: 0x0088F34D
		public Vector3 LocalPosition
		{
			get
			{
				return this.GetLocalPosition(new Vector3());
			}
		}

		// Token: 0x0601C0F1 RID: 114929 RVA: 0x00890F5C File Offset: 0x0088F35C
		public Vector3 GetLocalPosition(Vector3 obj)
		{
			int num = base.__offset(24);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002691 RID: 9873
		// (get) Token: 0x0601C0F2 RID: 114930 RVA: 0x00890F92 File Offset: 0x0088F392
		public Quaternion LocalRotation
		{
			get
			{
				return this.GetLocalRotation(new Quaternion());
			}
		}

		// Token: 0x0601C0F3 RID: 114931 RVA: 0x00890FA0 File Offset: 0x0088F3A0
		public Quaternion GetLocalRotation(Quaternion obj)
		{
			int num = base.__offset(26);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002692 RID: 9874
		// (get) Token: 0x0601C0F4 RID: 114932 RVA: 0x00890FD6 File Offset: 0x0088F3D6
		public Vector3 LocalScale
		{
			get
			{
				return this.GetLocalScale(new Vector3());
			}
		}

		// Token: 0x0601C0F5 RID: 114933 RVA: 0x00890FE4 File Offset: 0x0088F3E4
		public Vector3 GetLocalScale(Vector3 obj)
		{
			int num = base.__offset(28);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002693 RID: 9875
		// (get) Token: 0x0601C0F6 RID: 114934 RVA: 0x0089101C File Offset: 0x0088F41C
		public int Effecttype
		{
			get
			{
				int num = base.__offset(30);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002694 RID: 9876
		// (get) Token: 0x0601C0F7 RID: 114935 RVA: 0x00891054 File Offset: 0x0088F454
		public bool Loop
		{
			get
			{
				int num = base.__offset(32);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002695 RID: 9877
		// (get) Token: 0x0601C0F8 RID: 114936 RVA: 0x00891090 File Offset: 0x0088F490
		public bool LoopLoop
		{
			get
			{
				int num = base.__offset(34);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002696 RID: 9878
		// (get) Token: 0x0601C0F9 RID: 114937 RVA: 0x008910CC File Offset: 0x0088F4CC
		public bool OnlyLocalSee
		{
			get
			{
				int num = base.__offset(36);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C0FA RID: 114938 RVA: 0x00891107 File Offset: 0x0088F507
		public static void StartEffectsFrames(FlatBufferBuilder builder)
		{
			builder.StartObject(17);
		}

		// Token: 0x0601C0FB RID: 114939 RVA: 0x00891111 File Offset: 0x0088F511
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C0FC RID: 114940 RVA: 0x00891122 File Offset: 0x0088F522
		public static void AddEffectResID(FlatBufferBuilder builder, int effectResID)
		{
			builder.AddInt(1, effectResID, 0);
		}

		// Token: 0x0601C0FD RID: 114941 RVA: 0x0089112D File Offset: 0x0088F52D
		public static void AddStartFrames(FlatBufferBuilder builder, int startFrames)
		{
			builder.AddInt(2, startFrames, 0);
		}

		// Token: 0x0601C0FE RID: 114942 RVA: 0x00891138 File Offset: 0x0088F538
		public static void AddEndFrames(FlatBufferBuilder builder, int endFrames)
		{
			builder.AddInt(3, endFrames, 0);
		}

		// Token: 0x0601C0FF RID: 114943 RVA: 0x00891143 File Offset: 0x0088F543
		public static void AddAttachname(FlatBufferBuilder builder, StringOffset attachnameOffset)
		{
			builder.AddOffset(4, attachnameOffset.Value, 0);
		}

		// Token: 0x0601C100 RID: 114944 RVA: 0x00891154 File Offset: 0x0088F554
		public static void AddPlaytype(FlatBufferBuilder builder, int playtype)
		{
			builder.AddInt(5, playtype, 0);
		}

		// Token: 0x0601C101 RID: 114945 RVA: 0x0089115F File Offset: 0x0088F55F
		public static void AddTimetype(FlatBufferBuilder builder, int timetype)
		{
			builder.AddInt(6, timetype, 0);
		}

		// Token: 0x0601C102 RID: 114946 RVA: 0x0089116A File Offset: 0x0088F56A
		public static void AddTime(FlatBufferBuilder builder, float time)
		{
			builder.AddFloat(7, time, 0.0);
		}

		// Token: 0x0601C103 RID: 114947 RVA: 0x0089117D File Offset: 0x0088F57D
		public static void AddEffectAsset(FlatBufferBuilder builder, StringOffset effectAssetOffset)
		{
			builder.AddOffset(8, effectAssetOffset.Value, 0);
		}

		// Token: 0x0601C104 RID: 114948 RVA: 0x0089118E File Offset: 0x0088F58E
		public static void AddAttachPoint(FlatBufferBuilder builder, int attachPoint)
		{
			builder.AddInt(9, attachPoint, 0);
		}

		// Token: 0x0601C105 RID: 114949 RVA: 0x0089119A File Offset: 0x0088F59A
		public static void AddLocalPosition(FlatBufferBuilder builder, Offset<Vector3> localPositionOffset)
		{
			builder.AddStruct(10, localPositionOffset.Value, 0);
		}

		// Token: 0x0601C106 RID: 114950 RVA: 0x008911AC File Offset: 0x0088F5AC
		public static void AddLocalRotation(FlatBufferBuilder builder, Offset<Quaternion> localRotationOffset)
		{
			builder.AddStruct(11, localRotationOffset.Value, 0);
		}

		// Token: 0x0601C107 RID: 114951 RVA: 0x008911BE File Offset: 0x0088F5BE
		public static void AddLocalScale(FlatBufferBuilder builder, Offset<Vector3> localScaleOffset)
		{
			builder.AddStruct(12, localScaleOffset.Value, 0);
		}

		// Token: 0x0601C108 RID: 114952 RVA: 0x008911D0 File Offset: 0x0088F5D0
		public static void AddEffecttype(FlatBufferBuilder builder, int effecttype)
		{
			builder.AddInt(13, effecttype, 0);
		}

		// Token: 0x0601C109 RID: 114953 RVA: 0x008911DC File Offset: 0x0088F5DC
		public static void AddLoop(FlatBufferBuilder builder, bool loop)
		{
			builder.AddBool(14, loop, false);
		}

		// Token: 0x0601C10A RID: 114954 RVA: 0x008911E8 File Offset: 0x0088F5E8
		public static void AddLoopLoop(FlatBufferBuilder builder, bool loopLoop)
		{
			builder.AddBool(15, loopLoop, false);
		}

		// Token: 0x0601C10B RID: 114955 RVA: 0x008911F4 File Offset: 0x0088F5F4
		public static void AddOnlyLocalSee(FlatBufferBuilder builder, bool onlyLocalSee)
		{
			builder.AddBool(16, onlyLocalSee, false);
		}

		// Token: 0x0601C10C RID: 114956 RVA: 0x00891200 File Offset: 0x0088F600
		public static Offset<EffectsFrames> EndEffectsFrames(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EffectsFrames>(value);
		}
	}
}
