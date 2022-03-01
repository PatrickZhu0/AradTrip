using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B32 RID: 19250
	public sealed class DSkillFrameEffect : Table
	{
		// Token: 0x0601C281 RID: 115329 RVA: 0x00893DDE File Offset: 0x008921DE
		public static DSkillFrameEffect GetRootAsDSkillFrameEffect(ByteBuffer _bb)
		{
			return DSkillFrameEffect.GetRootAsDSkillFrameEffect(_bb, new DSkillFrameEffect());
		}

		// Token: 0x0601C282 RID: 115330 RVA: 0x00893DEB File Offset: 0x008921EB
		public static DSkillFrameEffect GetRootAsDSkillFrameEffect(ByteBuffer _bb, DSkillFrameEffect obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C283 RID: 115331 RVA: 0x00893E07 File Offset: 0x00892207
		public DSkillFrameEffect __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002712 RID: 10002
		// (get) Token: 0x0601C284 RID: 115332 RVA: 0x00893E18 File Offset: 0x00892218
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002713 RID: 10003
		// (get) Token: 0x0601C285 RID: 115333 RVA: 0x00893E48 File Offset: 0x00892248
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002714 RID: 10004
		// (get) Token: 0x0601C286 RID: 115334 RVA: 0x00893E7C File Offset: 0x0089227C
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002715 RID: 10005
		// (get) Token: 0x0601C287 RID: 115335 RVA: 0x00893EB0 File Offset: 0x008922B0
		public int EffectID
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002716 RID: 10006
		// (get) Token: 0x0601C288 RID: 115336 RVA: 0x00893EE8 File Offset: 0x008922E8
		public float BuffTime
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002717 RID: 10007
		// (get) Token: 0x0601C289 RID: 115337 RVA: 0x00893F24 File Offset: 0x00892324
		public bool PhaseDelete
		{
			get
			{
				int num = base.__offset(14);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002718 RID: 10008
		// (get) Token: 0x0601C28A RID: 115338 RVA: 0x00893F60 File Offset: 0x00892360
		public bool FinishDelete
		{
			get
			{
				int num = base.__offset(16);
				return num == 0 || 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002719 RID: 10009
		// (get) Token: 0x0601C28B RID: 115339 RVA: 0x00893F9C File Offset: 0x0089239C
		public bool FinishDeleteAll
		{
			get
			{
				int num = base.__offset(18);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700271A RID: 10010
		// (get) Token: 0x0601C28C RID: 115340 RVA: 0x00893FD8 File Offset: 0x008923D8
		public bool UseBuffAni
		{
			get
			{
				int num = base.__offset(20);
				return num == 0 || 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700271B RID: 10011
		// (get) Token: 0x0601C28D RID: 115341 RVA: 0x00894014 File Offset: 0x00892414
		public bool UsePause
		{
			get
			{
				int num = base.__offset(22);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700271C RID: 10012
		// (get) Token: 0x0601C28E RID: 115342 RVA: 0x00894050 File Offset: 0x00892450
		public float PauseTime
		{
			get
			{
				int num = base.__offset(24);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700271D RID: 10013
		// (get) Token: 0x0601C28F RID: 115343 RVA: 0x0089408C File Offset: 0x0089248C
		public int MechanismId
		{
			get
			{
				int num = base.__offset(26);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C290 RID: 115344 RVA: 0x008940C4 File Offset: 0x008924C4
		public static Offset<DSkillFrameEffect> CreateDSkillFrameEffect(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, int effectID = 0, float buffTime = 0f, bool phaseDelete = false, bool finishDelete = true, bool finishDeleteAll = false, bool useBuffAni = true, bool usePause = false, float pauseTime = 0f, int mechanismId = 0)
		{
			builder.StartObject(12);
			DSkillFrameEffect.AddMechanismId(builder, mechanismId);
			DSkillFrameEffect.AddPauseTime(builder, pauseTime);
			DSkillFrameEffect.AddBuffTime(builder, buffTime);
			DSkillFrameEffect.AddEffectID(builder, effectID);
			DSkillFrameEffect.AddLength(builder, length);
			DSkillFrameEffect.AddStartframe(builder, startframe);
			DSkillFrameEffect.AddName(builder, name);
			DSkillFrameEffect.AddUsePause(builder, usePause);
			DSkillFrameEffect.AddUseBuffAni(builder, useBuffAni);
			DSkillFrameEffect.AddFinishDeleteAll(builder, finishDeleteAll);
			DSkillFrameEffect.AddFinishDelete(builder, finishDelete);
			DSkillFrameEffect.AddPhaseDelete(builder, phaseDelete);
			return DSkillFrameEffect.EndDSkillFrameEffect(builder);
		}

		// Token: 0x0601C291 RID: 115345 RVA: 0x0089413C File Offset: 0x0089253C
		public static void StartDSkillFrameEffect(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x0601C292 RID: 115346 RVA: 0x00894146 File Offset: 0x00892546
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C293 RID: 115347 RVA: 0x00894157 File Offset: 0x00892557
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C294 RID: 115348 RVA: 0x00894162 File Offset: 0x00892562
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C295 RID: 115349 RVA: 0x0089416D File Offset: 0x0089256D
		public static void AddEffectID(FlatBufferBuilder builder, int effectID)
		{
			builder.AddInt(3, effectID, 0);
		}

		// Token: 0x0601C296 RID: 115350 RVA: 0x00894178 File Offset: 0x00892578
		public static void AddBuffTime(FlatBufferBuilder builder, float buffTime)
		{
			builder.AddFloat(4, buffTime, 0.0);
		}

		// Token: 0x0601C297 RID: 115351 RVA: 0x0089418B File Offset: 0x0089258B
		public static void AddPhaseDelete(FlatBufferBuilder builder, bool phaseDelete)
		{
			builder.AddBool(5, phaseDelete, false);
		}

		// Token: 0x0601C298 RID: 115352 RVA: 0x00894196 File Offset: 0x00892596
		public static void AddFinishDelete(FlatBufferBuilder builder, bool finishDelete)
		{
			builder.AddBool(6, finishDelete, true);
		}

		// Token: 0x0601C299 RID: 115353 RVA: 0x008941A1 File Offset: 0x008925A1
		public static void AddFinishDeleteAll(FlatBufferBuilder builder, bool finishDeleteAll)
		{
			builder.AddBool(7, finishDeleteAll, false);
		}

		// Token: 0x0601C29A RID: 115354 RVA: 0x008941AC File Offset: 0x008925AC
		public static void AddUseBuffAni(FlatBufferBuilder builder, bool useBuffAni)
		{
			builder.AddBool(8, useBuffAni, true);
		}

		// Token: 0x0601C29B RID: 115355 RVA: 0x008941B7 File Offset: 0x008925B7
		public static void AddUsePause(FlatBufferBuilder builder, bool usePause)
		{
			builder.AddBool(9, usePause, false);
		}

		// Token: 0x0601C29C RID: 115356 RVA: 0x008941C3 File Offset: 0x008925C3
		public static void AddPauseTime(FlatBufferBuilder builder, float pauseTime)
		{
			builder.AddFloat(10, pauseTime, 0.0);
		}

		// Token: 0x0601C29D RID: 115357 RVA: 0x008941D7 File Offset: 0x008925D7
		public static void AddMechanismId(FlatBufferBuilder builder, int mechanismId)
		{
			builder.AddInt(11, mechanismId, 0);
		}

		// Token: 0x0601C29E RID: 115358 RVA: 0x008941E4 File Offset: 0x008925E4
		public static Offset<DSkillFrameEffect> EndDSkillFrameEffect(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillFrameEffect>(value);
		}
	}
}
