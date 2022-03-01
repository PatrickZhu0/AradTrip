using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B31 RID: 19249
	public sealed class DSkillSfx : Table
	{
		// Token: 0x0601C26E RID: 115310 RVA: 0x00893BB6 File Offset: 0x00891FB6
		public static DSkillSfx GetRootAsDSkillSfx(ByteBuffer _bb)
		{
			return DSkillSfx.GetRootAsDSkillSfx(_bb, new DSkillSfx());
		}

		// Token: 0x0601C26F RID: 115311 RVA: 0x00893BC3 File Offset: 0x00891FC3
		public static DSkillSfx GetRootAsDSkillSfx(ByteBuffer _bb, DSkillSfx obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C270 RID: 115312 RVA: 0x00893BDF File Offset: 0x00891FDF
		public DSkillSfx __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700270C RID: 9996
		// (get) Token: 0x0601C271 RID: 115313 RVA: 0x00893BF0 File Offset: 0x00891FF0
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700270D RID: 9997
		// (get) Token: 0x0601C272 RID: 115314 RVA: 0x00893C20 File Offset: 0x00892020
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700270E RID: 9998
		// (get) Token: 0x0601C273 RID: 115315 RVA: 0x00893C54 File Offset: 0x00892054
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700270F RID: 9999
		// (get) Token: 0x0601C274 RID: 115316 RVA: 0x00893C88 File Offset: 0x00892088
		public string SoundClipAsset
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002710 RID: 10000
		// (get) Token: 0x0601C275 RID: 115317 RVA: 0x00893CB8 File Offset: 0x008920B8
		public bool Loop
		{
			get
			{
				int num = base.__offset(12);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002711 RID: 10001
		// (get) Token: 0x0601C276 RID: 115318 RVA: 0x00893CF4 File Offset: 0x008920F4
		public int SoundID
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C277 RID: 115319 RVA: 0x00893D29 File Offset: 0x00892129
		public static Offset<DSkillSfx> CreateDSkillSfx(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, StringOffset soundClipAsset = default(StringOffset), bool loop = false, int soundID = 0)
		{
			builder.StartObject(6);
			DSkillSfx.AddSoundID(builder, soundID);
			DSkillSfx.AddSoundClipAsset(builder, soundClipAsset);
			DSkillSfx.AddLength(builder, length);
			DSkillSfx.AddStartframe(builder, startframe);
			DSkillSfx.AddName(builder, name);
			DSkillSfx.AddLoop(builder, loop);
			return DSkillSfx.EndDSkillSfx(builder);
		}

		// Token: 0x0601C278 RID: 115320 RVA: 0x00893D65 File Offset: 0x00892165
		public static void StartDSkillSfx(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0601C279 RID: 115321 RVA: 0x00893D6E File Offset: 0x0089216E
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C27A RID: 115322 RVA: 0x00893D7F File Offset: 0x0089217F
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C27B RID: 115323 RVA: 0x00893D8A File Offset: 0x0089218A
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C27C RID: 115324 RVA: 0x00893D95 File Offset: 0x00892195
		public static void AddSoundClipAsset(FlatBufferBuilder builder, StringOffset soundClipAssetOffset)
		{
			builder.AddOffset(3, soundClipAssetOffset.Value, 0);
		}

		// Token: 0x0601C27D RID: 115325 RVA: 0x00893DA6 File Offset: 0x008921A6
		public static void AddLoop(FlatBufferBuilder builder, bool loop)
		{
			builder.AddBool(4, loop, false);
		}

		// Token: 0x0601C27E RID: 115326 RVA: 0x00893DB1 File Offset: 0x008921B1
		public static void AddSoundID(FlatBufferBuilder builder, int soundID)
		{
			builder.AddInt(5, soundID, 0);
		}

		// Token: 0x0601C27F RID: 115327 RVA: 0x00893DBC File Offset: 0x008921BC
		public static Offset<DSkillSfx> EndDSkillSfx(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillSfx>(value);
		}
	}
}
