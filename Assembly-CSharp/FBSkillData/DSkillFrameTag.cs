using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B30 RID: 19248
	public sealed class DSkillFrameTag : Table
	{
		// Token: 0x0601C25D RID: 115293 RVA: 0x008939DA File Offset: 0x00891DDA
		public static DSkillFrameTag GetRootAsDSkillFrameTag(ByteBuffer _bb)
		{
			return DSkillFrameTag.GetRootAsDSkillFrameTag(_bb, new DSkillFrameTag());
		}

		// Token: 0x0601C25E RID: 115294 RVA: 0x008939E7 File Offset: 0x00891DE7
		public static DSkillFrameTag GetRootAsDSkillFrameTag(ByteBuffer _bb, DSkillFrameTag obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C25F RID: 115295 RVA: 0x00893A03 File Offset: 0x00891E03
		public DSkillFrameTag __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002707 RID: 9991
		// (get) Token: 0x0601C260 RID: 115296 RVA: 0x00893A14 File Offset: 0x00891E14
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002708 RID: 9992
		// (get) Token: 0x0601C261 RID: 115297 RVA: 0x00893A44 File Offset: 0x00891E44
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002709 RID: 9993
		// (get) Token: 0x0601C262 RID: 115298 RVA: 0x00893A78 File Offset: 0x00891E78
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700270A RID: 9994
		// (get) Token: 0x0601C263 RID: 115299 RVA: 0x00893AAC File Offset: 0x00891EAC
		public int Tag
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700270B RID: 9995
		// (get) Token: 0x0601C264 RID: 115300 RVA: 0x00893AE4 File Offset: 0x00891EE4
		public string TagFlag
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x0601C265 RID: 115301 RVA: 0x00893B14 File Offset: 0x00891F14
		public static Offset<DSkillFrameTag> CreateDSkillFrameTag(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, int tag = 0, StringOffset tagFlag = default(StringOffset))
		{
			builder.StartObject(5);
			DSkillFrameTag.AddTagFlag(builder, tagFlag);
			DSkillFrameTag.AddTag(builder, tag);
			DSkillFrameTag.AddLength(builder, length);
			DSkillFrameTag.AddStartframe(builder, startframe);
			DSkillFrameTag.AddName(builder, name);
			return DSkillFrameTag.EndDSkillFrameTag(builder);
		}

		// Token: 0x0601C266 RID: 115302 RVA: 0x00893B48 File Offset: 0x00891F48
		public static void StartDSkillFrameTag(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0601C267 RID: 115303 RVA: 0x00893B51 File Offset: 0x00891F51
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C268 RID: 115304 RVA: 0x00893B62 File Offset: 0x00891F62
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C269 RID: 115305 RVA: 0x00893B6D File Offset: 0x00891F6D
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C26A RID: 115306 RVA: 0x00893B78 File Offset: 0x00891F78
		public static void AddTag(FlatBufferBuilder builder, int tag)
		{
			builder.AddInt(3, tag, 0);
		}

		// Token: 0x0601C26B RID: 115307 RVA: 0x00893B83 File Offset: 0x00891F83
		public static void AddTagFlag(FlatBufferBuilder builder, StringOffset tagFlagOffset)
		{
			builder.AddOffset(4, tagFlagOffset.Value, 0);
		}

		// Token: 0x0601C26C RID: 115308 RVA: 0x00893B94 File Offset: 0x00891F94
		public static Offset<DSkillFrameTag> EndDSkillFrameTag(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillFrameTag>(value);
		}
	}
}
