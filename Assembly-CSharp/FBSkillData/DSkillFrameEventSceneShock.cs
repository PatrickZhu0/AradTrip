using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B38 RID: 19256
	public sealed class DSkillFrameEventSceneShock : Table
	{
		// Token: 0x0601C305 RID: 115461 RVA: 0x00894DEE File Offset: 0x008931EE
		public static DSkillFrameEventSceneShock GetRootAsDSkillFrameEventSceneShock(ByteBuffer _bb)
		{
			return DSkillFrameEventSceneShock.GetRootAsDSkillFrameEventSceneShock(_bb, new DSkillFrameEventSceneShock());
		}

		// Token: 0x0601C306 RID: 115462 RVA: 0x00894DFB File Offset: 0x008931FB
		public static DSkillFrameEventSceneShock GetRootAsDSkillFrameEventSceneShock(ByteBuffer _bb, DSkillFrameEventSceneShock obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C307 RID: 115463 RVA: 0x00894E17 File Offset: 0x00893217
		public DSkillFrameEventSceneShock __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700273F RID: 10047
		// (get) Token: 0x0601C308 RID: 115464 RVA: 0x00894E28 File Offset: 0x00893228
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002740 RID: 10048
		// (get) Token: 0x0601C309 RID: 115465 RVA: 0x00894E58 File Offset: 0x00893258
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002741 RID: 10049
		// (get) Token: 0x0601C30A RID: 115466 RVA: 0x00894E8C File Offset: 0x0089328C
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002742 RID: 10050
		// (get) Token: 0x0601C30B RID: 115467 RVA: 0x00894EC0 File Offset: 0x008932C0
		public float Time
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002743 RID: 10051
		// (get) Token: 0x0601C30C RID: 115468 RVA: 0x00894EFC File Offset: 0x008932FC
		public float Speed
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002744 RID: 10052
		// (get) Token: 0x0601C30D RID: 115469 RVA: 0x00894F38 File Offset: 0x00893338
		public float Xrange
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002745 RID: 10053
		// (get) Token: 0x0601C30E RID: 115470 RVA: 0x00894F74 File Offset: 0x00893374
		public float Yrange
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002746 RID: 10054
		// (get) Token: 0x0601C30F RID: 115471 RVA: 0x00894FB0 File Offset: 0x008933B0
		public bool IsNew
		{
			get
			{
				int num = base.__offset(18);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002747 RID: 10055
		// (get) Token: 0x0601C310 RID: 115472 RVA: 0x00894FEC File Offset: 0x008933EC
		public int Mode
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002748 RID: 10056
		// (get) Token: 0x0601C311 RID: 115473 RVA: 0x00895024 File Offset: 0x00893424
		public bool Decelerate
		{
			get
			{
				int num = base.__offset(22);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002749 RID: 10057
		// (get) Token: 0x0601C312 RID: 115474 RVA: 0x00895060 File Offset: 0x00893460
		public float Xreduce
		{
			get
			{
				int num = base.__offset(24);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700274A RID: 10058
		// (get) Token: 0x0601C313 RID: 115475 RVA: 0x0089509C File Offset: 0x0089349C
		public float Yreduce
		{
			get
			{
				int num = base.__offset(26);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700274B RID: 10059
		// (get) Token: 0x0601C314 RID: 115476 RVA: 0x008950D8 File Offset: 0x008934D8
		public float Radius
		{
			get
			{
				int num = base.__offset(28);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700274C RID: 10060
		// (get) Token: 0x0601C315 RID: 115477 RVA: 0x00895114 File Offset: 0x00893514
		public int Num
		{
			get
			{
				int num = base.__offset(30);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C316 RID: 115478 RVA: 0x0089514C File Offset: 0x0089354C
		public static Offset<DSkillFrameEventSceneShock> CreateDSkillFrameEventSceneShock(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, float time = 0f, float speed = 0f, float xrange = 0f, float yrange = 0f, bool isNew = false, int mode = 0, bool decelerate = false, float xreduce = 0f, float yreduce = 0f, float radius = 0f, int num = 0)
		{
			builder.StartObject(14);
			DSkillFrameEventSceneShock.AddNum(builder, num);
			DSkillFrameEventSceneShock.AddRadius(builder, radius);
			DSkillFrameEventSceneShock.AddYreduce(builder, yreduce);
			DSkillFrameEventSceneShock.AddXreduce(builder, xreduce);
			DSkillFrameEventSceneShock.AddMode(builder, mode);
			DSkillFrameEventSceneShock.AddYrange(builder, yrange);
			DSkillFrameEventSceneShock.AddXrange(builder, xrange);
			DSkillFrameEventSceneShock.AddSpeed(builder, speed);
			DSkillFrameEventSceneShock.AddTime(builder, time);
			DSkillFrameEventSceneShock.AddLength(builder, length);
			DSkillFrameEventSceneShock.AddStartframe(builder, startframe);
			DSkillFrameEventSceneShock.AddName(builder, name);
			DSkillFrameEventSceneShock.AddDecelerate(builder, decelerate);
			DSkillFrameEventSceneShock.AddIsNew(builder, isNew);
			return DSkillFrameEventSceneShock.EndDSkillFrameEventSceneShock(builder);
		}

		// Token: 0x0601C317 RID: 115479 RVA: 0x008951D4 File Offset: 0x008935D4
		public static void StartDSkillFrameEventSceneShock(FlatBufferBuilder builder)
		{
			builder.StartObject(14);
		}

		// Token: 0x0601C318 RID: 115480 RVA: 0x008951DE File Offset: 0x008935DE
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C319 RID: 115481 RVA: 0x008951EF File Offset: 0x008935EF
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C31A RID: 115482 RVA: 0x008951FA File Offset: 0x008935FA
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C31B RID: 115483 RVA: 0x00895205 File Offset: 0x00893605
		public static void AddTime(FlatBufferBuilder builder, float time)
		{
			builder.AddFloat(3, time, 0.0);
		}

		// Token: 0x0601C31C RID: 115484 RVA: 0x00895218 File Offset: 0x00893618
		public static void AddSpeed(FlatBufferBuilder builder, float speed)
		{
			builder.AddFloat(4, speed, 0.0);
		}

		// Token: 0x0601C31D RID: 115485 RVA: 0x0089522B File Offset: 0x0089362B
		public static void AddXrange(FlatBufferBuilder builder, float xrange)
		{
			builder.AddFloat(5, xrange, 0.0);
		}

		// Token: 0x0601C31E RID: 115486 RVA: 0x0089523E File Offset: 0x0089363E
		public static void AddYrange(FlatBufferBuilder builder, float yrange)
		{
			builder.AddFloat(6, yrange, 0.0);
		}

		// Token: 0x0601C31F RID: 115487 RVA: 0x00895251 File Offset: 0x00893651
		public static void AddIsNew(FlatBufferBuilder builder, bool isNew)
		{
			builder.AddBool(7, isNew, false);
		}

		// Token: 0x0601C320 RID: 115488 RVA: 0x0089525C File Offset: 0x0089365C
		public static void AddMode(FlatBufferBuilder builder, int mode)
		{
			builder.AddInt(8, mode, 0);
		}

		// Token: 0x0601C321 RID: 115489 RVA: 0x00895267 File Offset: 0x00893667
		public static void AddDecelerate(FlatBufferBuilder builder, bool decelerate)
		{
			builder.AddBool(9, decelerate, false);
		}

		// Token: 0x0601C322 RID: 115490 RVA: 0x00895273 File Offset: 0x00893673
		public static void AddXreduce(FlatBufferBuilder builder, float xreduce)
		{
			builder.AddFloat(10, xreduce, 0.0);
		}

		// Token: 0x0601C323 RID: 115491 RVA: 0x00895287 File Offset: 0x00893687
		public static void AddYreduce(FlatBufferBuilder builder, float yreduce)
		{
			builder.AddFloat(11, yreduce, 0.0);
		}

		// Token: 0x0601C324 RID: 115492 RVA: 0x0089529B File Offset: 0x0089369B
		public static void AddRadius(FlatBufferBuilder builder, float radius)
		{
			builder.AddFloat(12, radius, 0.0);
		}

		// Token: 0x0601C325 RID: 115493 RVA: 0x008952AF File Offset: 0x008936AF
		public static void AddNum(FlatBufferBuilder builder, int num)
		{
			builder.AddInt(13, num, 0);
		}

		// Token: 0x0601C326 RID: 115494 RVA: 0x008952BC File Offset: 0x008936BC
		public static Offset<DSkillFrameEventSceneShock> EndDSkillFrameEventSceneShock(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillFrameEventSceneShock>(value);
		}
	}
}
