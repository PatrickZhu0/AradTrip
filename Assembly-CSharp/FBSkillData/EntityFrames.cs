using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B22 RID: 19234
	public sealed class EntityFrames : Table
	{
		// Token: 0x0601C11F RID: 114975 RVA: 0x008913E0 File Offset: 0x0088F7E0
		public static EntityFrames GetRootAsEntityFrames(ByteBuffer _bb)
		{
			return EntityFrames.GetRootAsEntityFrames(_bb, new EntityFrames());
		}

		// Token: 0x0601C120 RID: 114976 RVA: 0x008913ED File Offset: 0x0088F7ED
		public static EntityFrames GetRootAsEntityFrames(ByteBuffer _bb, EntityFrames obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C121 RID: 114977 RVA: 0x00891409 File Offset: 0x0088F809
		public EntityFrames __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026A1 RID: 9889
		// (get) Token: 0x0601C122 RID: 114978 RVA: 0x0089141C File Offset: 0x0088F81C
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026A2 RID: 9890
		// (get) Token: 0x0601C123 RID: 114979 RVA: 0x0089144C File Offset: 0x0088F84C
		public int ResID
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026A3 RID: 9891
		// (get) Token: 0x0601C124 RID: 114980 RVA: 0x00891480 File Offset: 0x0088F880
		public int Type
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026A4 RID: 9892
		// (get) Token: 0x0601C125 RID: 114981 RVA: 0x008914B4 File Offset: 0x0088F8B4
		public bool RandomResID
		{
			get
			{
				int num = base.__offset(10);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C126 RID: 114982 RVA: 0x008914F0 File Offset: 0x0088F8F0
		public int GetResIDList(int j)
		{
			int num = base.__offset(12);
			return (num == 0) ? 0 : this.bb.GetInt(base.__vector(num) + j * 4);
		}

		// Token: 0x170026A5 RID: 9893
		// (get) Token: 0x0601C127 RID: 114983 RVA: 0x00891528 File Offset: 0x0088F928
		public int ResIDListLength
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x170026A6 RID: 9894
		// (get) Token: 0x0601C128 RID: 114984 RVA: 0x00891554 File Offset: 0x0088F954
		public int StartFrames
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026A7 RID: 9895
		// (get) Token: 0x0601C129 RID: 114985 RVA: 0x0089158C File Offset: 0x0088F98C
		public string EntityAsset
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026A8 RID: 9896
		// (get) Token: 0x0601C12A RID: 114986 RVA: 0x008915BC File Offset: 0x0088F9BC
		public Vector2 Gravity
		{
			get
			{
				return this.GetGravity(new Vector2());
			}
		}

		// Token: 0x0601C12B RID: 114987 RVA: 0x008915CC File Offset: 0x0088F9CC
		public Vector2 GetGravity(Vector2 obj)
		{
			int num = base.__offset(18);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170026A9 RID: 9897
		// (get) Token: 0x0601C12C RID: 114988 RVA: 0x00891604 File Offset: 0x0088FA04
		public float Speed
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026AA RID: 9898
		// (get) Token: 0x0601C12D RID: 114989 RVA: 0x00891640 File Offset: 0x0088FA40
		public float Angle
		{
			get
			{
				int num = base.__offset(22);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026AB RID: 9899
		// (get) Token: 0x0601C12E RID: 114990 RVA: 0x0089167C File Offset: 0x0088FA7C
		public bool IsAngleWithEffect
		{
			get
			{
				int num = base.__offset(24);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026AC RID: 9900
		// (get) Token: 0x0601C12F RID: 114991 RVA: 0x008916B7 File Offset: 0x0088FAB7
		public Vector2 Emitposition
		{
			get
			{
				return this.GetEmitposition(new Vector2());
			}
		}

		// Token: 0x0601C130 RID: 114992 RVA: 0x008916C4 File Offset: 0x0088FAC4
		public Vector2 GetEmitposition(Vector2 obj)
		{
			int num = base.__offset(26);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170026AD RID: 9901
		// (get) Token: 0x0601C131 RID: 114993 RVA: 0x008916FC File Offset: 0x0088FAFC
		public float EmitPositionZ
		{
			get
			{
				int num = base.__offset(28);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026AE RID: 9902
		// (get) Token: 0x0601C132 RID: 114994 RVA: 0x00891738 File Offset: 0x0088FB38
		public int AxisType
		{
			get
			{
				int num = base.__offset(30);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026AF RID: 9903
		// (get) Token: 0x0601C133 RID: 114995 RVA: 0x00891770 File Offset: 0x0088FB70
		public float ShockTime
		{
			get
			{
				int num = base.__offset(32);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026B0 RID: 9904
		// (get) Token: 0x0601C134 RID: 114996 RVA: 0x008917AC File Offset: 0x0088FBAC
		public float ShockSpeed
		{
			get
			{
				int num = base.__offset(34);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026B1 RID: 9905
		// (get) Token: 0x0601C135 RID: 114997 RVA: 0x008917E8 File Offset: 0x0088FBE8
		public float ShockRangeX
		{
			get
			{
				int num = base.__offset(36);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026B2 RID: 9906
		// (get) Token: 0x0601C136 RID: 114998 RVA: 0x00891824 File Offset: 0x0088FC24
		public float ShockRangeY
		{
			get
			{
				int num = base.__offset(38);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026B3 RID: 9907
		// (get) Token: 0x0601C137 RID: 114999 RVA: 0x00891860 File Offset: 0x0088FC60
		public bool IsRotation
		{
			get
			{
				int num = base.__offset(40);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026B4 RID: 9908
		// (get) Token: 0x0601C138 RID: 115000 RVA: 0x0089189C File Offset: 0x0088FC9C
		public float RotateSpeed
		{
			get
			{
				int num = base.__offset(42);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026B5 RID: 9909
		// (get) Token: 0x0601C139 RID: 115001 RVA: 0x008918D8 File Offset: 0x0088FCD8
		public float MoveSpeed
		{
			get
			{
				int num = base.__offset(44);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026B6 RID: 9910
		// (get) Token: 0x0601C13A RID: 115002 RVA: 0x00891914 File Offset: 0x0088FD14
		public int RotateInitDegree
		{
			get
			{
				int num = base.__offset(46);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026B7 RID: 9911
		// (get) Token: 0x0601C13B RID: 115003 RVA: 0x0089194C File Offset: 0x0088FD4C
		public bool FollowRotate
		{
			get
			{
				int num = base.__offset(48);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026B8 RID: 9912
		// (get) Token: 0x0601C13C RID: 115004 RVA: 0x00891987 File Offset: 0x0088FD87
		public ShockInfo SceneShock
		{
			get
			{
				return this.GetSceneShock(new ShockInfo());
			}
		}

		// Token: 0x0601C13D RID: 115005 RVA: 0x00891994 File Offset: 0x0088FD94
		public ShockInfo GetSceneShock(ShockInfo obj)
		{
			int num = base.__offset(50);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170026B9 RID: 9913
		// (get) Token: 0x0601C13E RID: 115006 RVA: 0x008919CC File Offset: 0x0088FDCC
		public int HitFallUP
		{
			get
			{
				int num = base.__offset(52);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026BA RID: 9914
		// (get) Token: 0x0601C13F RID: 115007 RVA: 0x00891A04 File Offset: 0x0088FE04
		public float ForceY
		{
			get
			{
				int num = base.__offset(54);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026BB RID: 9915
		// (get) Token: 0x0601C140 RID: 115008 RVA: 0x00891A40 File Offset: 0x0088FE40
		public int HurtID
		{
			get
			{
				int num = base.__offset(56);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026BC RID: 9916
		// (get) Token: 0x0601C141 RID: 115009 RVA: 0x00891A78 File Offset: 0x0088FE78
		public float LifeTime
		{
			get
			{
				int num = base.__offset(58);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026BD RID: 9917
		// (get) Token: 0x0601C142 RID: 115010 RVA: 0x00891AB4 File Offset: 0x0088FEB4
		public bool HitThrough
		{
			get
			{
				int num = base.__offset(60);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026BE RID: 9918
		// (get) Token: 0x0601C143 RID: 115011 RVA: 0x00891AF0 File Offset: 0x0088FEF0
		public int HitCount
		{
			get
			{
				int num = base.__offset(62);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026BF RID: 9919
		// (get) Token: 0x0601C144 RID: 115012 RVA: 0x00891B28 File Offset: 0x0088FF28
		public float Distance
		{
			get
			{
				int num = base.__offset(64);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026C0 RID: 9920
		// (get) Token: 0x0601C145 RID: 115013 RVA: 0x00891B64 File Offset: 0x0088FF64
		public bool AttackCountExceedPlayExtDead
		{
			get
			{
				int num = base.__offset(66);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026C1 RID: 9921
		// (get) Token: 0x0601C146 RID: 115014 RVA: 0x00891BA0 File Offset: 0x0088FFA0
		public bool HitGroundClick
		{
			get
			{
				int num = base.__offset(68);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026C2 RID: 9922
		// (get) Token: 0x0601C147 RID: 115015 RVA: 0x00891BDC File Offset: 0x0088FFDC
		public float DelayDead
		{
			get
			{
				int num = base.__offset(70);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026C3 RID: 9923
		// (get) Token: 0x0601C148 RID: 115016 RVA: 0x00891C18 File Offset: 0x00890018
		public int OffsetType
		{
			get
			{
				int num = base.__offset(72);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026C4 RID: 9924
		// (get) Token: 0x0601C149 RID: 115017 RVA: 0x00891C50 File Offset: 0x00890050
		public int TargetChooseType
		{
			get
			{
				int num = base.__offset(74);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026C5 RID: 9925
		// (get) Token: 0x0601C14A RID: 115018 RVA: 0x00891C85 File Offset: 0x00890085
		public Vector2 Range
		{
			get
			{
				return this.GetRange(new Vector2());
			}
		}

		// Token: 0x0601C14B RID: 115019 RVA: 0x00891C94 File Offset: 0x00890094
		public Vector2 GetRange(Vector2 obj)
		{
			int num = base.__offset(76);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170026C6 RID: 9926
		// (get) Token: 0x0601C14C RID: 115020 RVA: 0x00891CCC File Offset: 0x008900CC
		public float BoomerangeDistance
		{
			get
			{
				int num = base.__offset(78);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026C7 RID: 9927
		// (get) Token: 0x0601C14D RID: 115021 RVA: 0x00891D08 File Offset: 0x00890108
		public float StayDuration
		{
			get
			{
				int num = base.__offset(80);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026C8 RID: 9928
		// (get) Token: 0x0601C14E RID: 115022 RVA: 0x00891D44 File Offset: 0x00890144
		public float ParaSpeed
		{
			get
			{
				int num = base.__offset(82);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026C9 RID: 9929
		// (get) Token: 0x0601C14F RID: 115023 RVA: 0x00891D80 File Offset: 0x00890180
		public float ParaGravity
		{
			get
			{
				int num = base.__offset(84);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026CA RID: 9930
		// (get) Token: 0x0601C150 RID: 115024 RVA: 0x00891DBC File Offset: 0x008901BC
		public bool UseRandomLaunch
		{
			get
			{
				int num = base.__offset(86);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026CB RID: 9931
		// (get) Token: 0x0601C151 RID: 115025 RVA: 0x00891DF7 File Offset: 0x008901F7
		public RandomLaunchInfo RandomLaunchInfo
		{
			get
			{
				return this.GetRandomLaunchInfo(new RandomLaunchInfo());
			}
		}

		// Token: 0x0601C152 RID: 115026 RVA: 0x00891E04 File Offset: 0x00890204
		public RandomLaunchInfo GetRandomLaunchInfo(RandomLaunchInfo obj)
		{
			int num = base.__offset(88);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170026CC RID: 9932
		// (get) Token: 0x0601C153 RID: 115027 RVA: 0x00891E3C File Offset: 0x0089023C
		public bool OnCollideDie
		{
			get
			{
				int num = base.__offset(90);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026CD RID: 9933
		// (get) Token: 0x0601C154 RID: 115028 RVA: 0x00891E78 File Offset: 0x00890278
		public bool OnXInBlockDie
		{
			get
			{
				int num = base.__offset(92);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026CE RID: 9934
		// (get) Token: 0x0601C155 RID: 115029 RVA: 0x00891EB4 File Offset: 0x008902B4
		public bool ChangeForceBehindOther
		{
			get
			{
				int num = base.__offset(94);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026CF RID: 9935
		// (get) Token: 0x0601C156 RID: 115030 RVA: 0x00891EF0 File Offset: 0x008902F0
		public int ChangeFace
		{
			get
			{
				int num = base.__offset(96);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C157 RID: 115031 RVA: 0x00891F25 File Offset: 0x00890325
		public static void StartEntityFrames(FlatBufferBuilder builder)
		{
			builder.StartObject(47);
		}

		// Token: 0x0601C158 RID: 115032 RVA: 0x00891F2F File Offset: 0x0089032F
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C159 RID: 115033 RVA: 0x00891F40 File Offset: 0x00890340
		public static void AddResID(FlatBufferBuilder builder, int resID)
		{
			builder.AddInt(1, resID, 0);
		}

		// Token: 0x0601C15A RID: 115034 RVA: 0x00891F4B File Offset: 0x0089034B
		public static void AddType(FlatBufferBuilder builder, int type)
		{
			builder.AddInt(2, type, 0);
		}

		// Token: 0x0601C15B RID: 115035 RVA: 0x00891F56 File Offset: 0x00890356
		public static void AddRandomResID(FlatBufferBuilder builder, bool randomResID)
		{
			builder.AddBool(3, randomResID, false);
		}

		// Token: 0x0601C15C RID: 115036 RVA: 0x00891F61 File Offset: 0x00890361
		public static void AddResIDList(FlatBufferBuilder builder, VectorOffset resIDListOffset)
		{
			builder.AddOffset(4, resIDListOffset.Value, 0);
		}

		// Token: 0x0601C15D RID: 115037 RVA: 0x00891F74 File Offset: 0x00890374
		public static VectorOffset CreateResIDListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C15E RID: 115038 RVA: 0x00891FB1 File Offset: 0x008903B1
		public static void StartResIDListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C15F RID: 115039 RVA: 0x00891FBC File Offset: 0x008903BC
		public static void AddStartFrames(FlatBufferBuilder builder, int startFrames)
		{
			builder.AddInt(5, startFrames, 0);
		}

		// Token: 0x0601C160 RID: 115040 RVA: 0x00891FC7 File Offset: 0x008903C7
		public static void AddEntityAsset(FlatBufferBuilder builder, StringOffset entityAssetOffset)
		{
			builder.AddOffset(6, entityAssetOffset.Value, 0);
		}

		// Token: 0x0601C161 RID: 115041 RVA: 0x00891FD8 File Offset: 0x008903D8
		public static void AddGravity(FlatBufferBuilder builder, Offset<Vector2> gravityOffset)
		{
			builder.AddStruct(7, gravityOffset.Value, 0);
		}

		// Token: 0x0601C162 RID: 115042 RVA: 0x00891FE9 File Offset: 0x008903E9
		public static void AddSpeed(FlatBufferBuilder builder, float speed)
		{
			builder.AddFloat(8, speed, 0.0);
		}

		// Token: 0x0601C163 RID: 115043 RVA: 0x00891FFC File Offset: 0x008903FC
		public static void AddAngle(FlatBufferBuilder builder, float angle)
		{
			builder.AddFloat(9, angle, 0.0);
		}

		// Token: 0x0601C164 RID: 115044 RVA: 0x00892010 File Offset: 0x00890410
		public static void AddIsAngleWithEffect(FlatBufferBuilder builder, bool isAngleWithEffect)
		{
			builder.AddBool(10, isAngleWithEffect, false);
		}

		// Token: 0x0601C165 RID: 115045 RVA: 0x0089201C File Offset: 0x0089041C
		public static void AddEmitposition(FlatBufferBuilder builder, Offset<Vector2> emitpositionOffset)
		{
			builder.AddStruct(11, emitpositionOffset.Value, 0);
		}

		// Token: 0x0601C166 RID: 115046 RVA: 0x0089202E File Offset: 0x0089042E
		public static void AddEmitPositionZ(FlatBufferBuilder builder, float emitPositionZ)
		{
			builder.AddFloat(12, emitPositionZ, 0.0);
		}

		// Token: 0x0601C167 RID: 115047 RVA: 0x00892042 File Offset: 0x00890442
		public static void AddAxisType(FlatBufferBuilder builder, int axisType)
		{
			builder.AddInt(13, axisType, 0);
		}

		// Token: 0x0601C168 RID: 115048 RVA: 0x0089204E File Offset: 0x0089044E
		public static void AddShockTime(FlatBufferBuilder builder, float shockTime)
		{
			builder.AddFloat(14, shockTime, 0.0);
		}

		// Token: 0x0601C169 RID: 115049 RVA: 0x00892062 File Offset: 0x00890462
		public static void AddShockSpeed(FlatBufferBuilder builder, float shockSpeed)
		{
			builder.AddFloat(15, shockSpeed, 0.0);
		}

		// Token: 0x0601C16A RID: 115050 RVA: 0x00892076 File Offset: 0x00890476
		public static void AddShockRangeX(FlatBufferBuilder builder, float shockRangeX)
		{
			builder.AddFloat(16, shockRangeX, 0.0);
		}

		// Token: 0x0601C16B RID: 115051 RVA: 0x0089208A File Offset: 0x0089048A
		public static void AddShockRangeY(FlatBufferBuilder builder, float shockRangeY)
		{
			builder.AddFloat(17, shockRangeY, 0.0);
		}

		// Token: 0x0601C16C RID: 115052 RVA: 0x0089209E File Offset: 0x0089049E
		public static void AddIsRotation(FlatBufferBuilder builder, bool isRotation)
		{
			builder.AddBool(18, isRotation, false);
		}

		// Token: 0x0601C16D RID: 115053 RVA: 0x008920AA File Offset: 0x008904AA
		public static void AddRotateSpeed(FlatBufferBuilder builder, float rotateSpeed)
		{
			builder.AddFloat(19, rotateSpeed, 0.0);
		}

		// Token: 0x0601C16E RID: 115054 RVA: 0x008920BE File Offset: 0x008904BE
		public static void AddMoveSpeed(FlatBufferBuilder builder, float moveSpeed)
		{
			builder.AddFloat(20, moveSpeed, 0.0);
		}

		// Token: 0x0601C16F RID: 115055 RVA: 0x008920D2 File Offset: 0x008904D2
		public static void AddRotateInitDegree(FlatBufferBuilder builder, int rotateInitDegree)
		{
			builder.AddInt(21, rotateInitDegree, 0);
		}

		// Token: 0x0601C170 RID: 115056 RVA: 0x008920DE File Offset: 0x008904DE
		public static void AddFollowRotate(FlatBufferBuilder builder, bool followRotate)
		{
			builder.AddBool(22, followRotate, false);
		}

		// Token: 0x0601C171 RID: 115057 RVA: 0x008920EA File Offset: 0x008904EA
		public static void AddSceneShock(FlatBufferBuilder builder, Offset<ShockInfo> sceneShockOffset)
		{
			builder.AddStruct(23, sceneShockOffset.Value, 0);
		}

		// Token: 0x0601C172 RID: 115058 RVA: 0x008920FC File Offset: 0x008904FC
		public static void AddHitFallUP(FlatBufferBuilder builder, int hitFallUP)
		{
			builder.AddInt(24, hitFallUP, 0);
		}

		// Token: 0x0601C173 RID: 115059 RVA: 0x00892108 File Offset: 0x00890508
		public static void AddForceY(FlatBufferBuilder builder, float forceY)
		{
			builder.AddFloat(25, forceY, 0.0);
		}

		// Token: 0x0601C174 RID: 115060 RVA: 0x0089211C File Offset: 0x0089051C
		public static void AddHurtID(FlatBufferBuilder builder, int hurtID)
		{
			builder.AddInt(26, hurtID, 0);
		}

		// Token: 0x0601C175 RID: 115061 RVA: 0x00892128 File Offset: 0x00890528
		public static void AddLifeTime(FlatBufferBuilder builder, float lifeTime)
		{
			builder.AddFloat(27, lifeTime, 0.0);
		}

		// Token: 0x0601C176 RID: 115062 RVA: 0x0089213C File Offset: 0x0089053C
		public static void AddHitThrough(FlatBufferBuilder builder, bool hitThrough)
		{
			builder.AddBool(28, hitThrough, false);
		}

		// Token: 0x0601C177 RID: 115063 RVA: 0x00892148 File Offset: 0x00890548
		public static void AddHitCount(FlatBufferBuilder builder, int hitCount)
		{
			builder.AddInt(29, hitCount, 0);
		}

		// Token: 0x0601C178 RID: 115064 RVA: 0x00892154 File Offset: 0x00890554
		public static void AddDistance(FlatBufferBuilder builder, float distance)
		{
			builder.AddFloat(30, distance, 0.0);
		}

		// Token: 0x0601C179 RID: 115065 RVA: 0x00892168 File Offset: 0x00890568
		public static void AddAttackCountExceedPlayExtDead(FlatBufferBuilder builder, bool attackCountExceedPlayExtDead)
		{
			builder.AddBool(31, attackCountExceedPlayExtDead, false);
		}

		// Token: 0x0601C17A RID: 115066 RVA: 0x00892174 File Offset: 0x00890574
		public static void AddHitGroundClick(FlatBufferBuilder builder, bool hitGroundClick)
		{
			builder.AddBool(32, hitGroundClick, false);
		}

		// Token: 0x0601C17B RID: 115067 RVA: 0x00892180 File Offset: 0x00890580
		public static void AddDelayDead(FlatBufferBuilder builder, float delayDead)
		{
			builder.AddFloat(33, delayDead, 0.0);
		}

		// Token: 0x0601C17C RID: 115068 RVA: 0x00892194 File Offset: 0x00890594
		public static void AddOffsetType(FlatBufferBuilder builder, int offsetType)
		{
			builder.AddInt(34, offsetType, 0);
		}

		// Token: 0x0601C17D RID: 115069 RVA: 0x008921A0 File Offset: 0x008905A0
		public static void AddTargetChooseType(FlatBufferBuilder builder, int targetChooseType)
		{
			builder.AddInt(35, targetChooseType, 0);
		}

		// Token: 0x0601C17E RID: 115070 RVA: 0x008921AC File Offset: 0x008905AC
		public static void AddRange(FlatBufferBuilder builder, Offset<Vector2> rangeOffset)
		{
			builder.AddStruct(36, rangeOffset.Value, 0);
		}

		// Token: 0x0601C17F RID: 115071 RVA: 0x008921BE File Offset: 0x008905BE
		public static void AddBoomerangeDistance(FlatBufferBuilder builder, float boomerangeDistance)
		{
			builder.AddFloat(37, boomerangeDistance, 0.0);
		}

		// Token: 0x0601C180 RID: 115072 RVA: 0x008921D2 File Offset: 0x008905D2
		public static void AddStayDuration(FlatBufferBuilder builder, float stayDuration)
		{
			builder.AddFloat(38, stayDuration, 0.0);
		}

		// Token: 0x0601C181 RID: 115073 RVA: 0x008921E6 File Offset: 0x008905E6
		public static void AddParaSpeed(FlatBufferBuilder builder, float paraSpeed)
		{
			builder.AddFloat(39, paraSpeed, 0.0);
		}

		// Token: 0x0601C182 RID: 115074 RVA: 0x008921FA File Offset: 0x008905FA
		public static void AddParaGravity(FlatBufferBuilder builder, float paraGravity)
		{
			builder.AddFloat(40, paraGravity, 0.0);
		}

		// Token: 0x0601C183 RID: 115075 RVA: 0x0089220E File Offset: 0x0089060E
		public static void AddUseRandomLaunch(FlatBufferBuilder builder, bool useRandomLaunch)
		{
			builder.AddBool(41, useRandomLaunch, false);
		}

		// Token: 0x0601C184 RID: 115076 RVA: 0x0089221A File Offset: 0x0089061A
		public static void AddRandomLaunchInfo(FlatBufferBuilder builder, Offset<RandomLaunchInfo> randomLaunchInfoOffset)
		{
			builder.AddStruct(42, randomLaunchInfoOffset.Value, 0);
		}

		// Token: 0x0601C185 RID: 115077 RVA: 0x0089222C File Offset: 0x0089062C
		public static void AddOnCollideDie(FlatBufferBuilder builder, bool onCollideDie)
		{
			builder.AddBool(43, onCollideDie, false);
		}

		// Token: 0x0601C186 RID: 115078 RVA: 0x00892238 File Offset: 0x00890638
		public static void AddOnXInBlockDie(FlatBufferBuilder builder, bool onXInBlockDie)
		{
			builder.AddBool(44, onXInBlockDie, false);
		}

		// Token: 0x0601C187 RID: 115079 RVA: 0x00892244 File Offset: 0x00890644
		public static void AddChangeForceBehindOther(FlatBufferBuilder builder, bool changeForceBehindOther)
		{
			builder.AddBool(45, changeForceBehindOther, false);
		}

		// Token: 0x0601C188 RID: 115080 RVA: 0x00892250 File Offset: 0x00890650
		public static void AddChangeFace(FlatBufferBuilder builder, int changeFace)
		{
			builder.AddInt(46, changeFace, 0);
		}

		// Token: 0x0601C189 RID: 115081 RVA: 0x0089225C File Offset: 0x0089065C
		public static Offset<EntityFrames> EndEntityFrames(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EntityFrames>(value);
		}
	}
}
