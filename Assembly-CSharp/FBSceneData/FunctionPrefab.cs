using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B0C RID: 19212
	public sealed class FunctionPrefab : Table
	{
		// Token: 0x0601BF4E RID: 114510 RVA: 0x0088D636 File Offset: 0x0088BA36
		public static FunctionPrefab GetRootAsFunctionPrefab(ByteBuffer _bb)
		{
			return FunctionPrefab.GetRootAsFunctionPrefab(_bb, new FunctionPrefab());
		}

		// Token: 0x0601BF4F RID: 114511 RVA: 0x0088D643 File Offset: 0x0088BA43
		public static FunctionPrefab GetRootAsFunctionPrefab(ByteBuffer _bb, FunctionPrefab obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BF50 RID: 114512 RVA: 0x0088D65F File Offset: 0x0088BA5F
		public FunctionPrefab __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700261B RID: 9755
		// (get) Token: 0x0601BF51 RID: 114513 RVA: 0x0088D670 File Offset: 0x0088BA70
		public DEntityInfo Super
		{
			get
			{
				return this.GetSuper(new DEntityInfo());
			}
		}

		// Token: 0x0601BF52 RID: 114514 RVA: 0x0088D680 File Offset: 0x0088BA80
		public DEntityInfo GetSuper(DEntityInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x1700261C RID: 9756
		// (get) Token: 0x0601BF53 RID: 114515 RVA: 0x0088D6BC File Offset: 0x0088BABC
		public FunctionType EFunctionType
		{
			get
			{
				int num = base.__offset(6);
				return (FunctionType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x0601BF54 RID: 114516 RVA: 0x0088D6F0 File Offset: 0x0088BAF0
		public static Offset<FunctionPrefab> CreateFunctionPrefab(FlatBufferBuilder builder, Offset<DEntityInfo> super = default(Offset<DEntityInfo>), FunctionType eFunctionType = FunctionType.FT_FollowPet)
		{
			builder.StartObject(2);
			FunctionPrefab.AddSuper(builder, super);
			FunctionPrefab.AddEFunctionType(builder, eFunctionType);
			return FunctionPrefab.EndFunctionPrefab(builder);
		}

		// Token: 0x0601BF55 RID: 114517 RVA: 0x0088D70D File Offset: 0x0088BB0D
		public static void StartFunctionPrefab(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0601BF56 RID: 114518 RVA: 0x0088D716 File Offset: 0x0088BB16
		public static void AddSuper(FlatBufferBuilder builder, Offset<DEntityInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BF57 RID: 114519 RVA: 0x0088D727 File Offset: 0x0088BB27
		public static void AddEFunctionType(FlatBufferBuilder builder, FunctionType eFunctionType)
		{
			builder.AddSbyte(1, (sbyte)eFunctionType, 0);
		}

		// Token: 0x0601BF58 RID: 114520 RVA: 0x0088D734 File Offset: 0x0088BB34
		public static Offset<FunctionPrefab> EndFunctionPrefab(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FunctionPrefab>(value);
		}
	}
}
