using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B23 RID: 19235
	public sealed class AnimationFrames : Table
	{
		// Token: 0x0601C18B RID: 115083 RVA: 0x0089227E File Offset: 0x0089067E
		public static AnimationFrames GetRootAsAnimationFrames(ByteBuffer _bb)
		{
			return AnimationFrames.GetRootAsAnimationFrames(_bb, new AnimationFrames());
		}

		// Token: 0x0601C18C RID: 115084 RVA: 0x0089228B File Offset: 0x0089068B
		public static AnimationFrames GetRootAsAnimationFrames(ByteBuffer _bb, AnimationFrames obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C18D RID: 115085 RVA: 0x008922A7 File Offset: 0x008906A7
		public AnimationFrames __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026D0 RID: 9936
		// (get) Token: 0x0601C18E RID: 115086 RVA: 0x008922B8 File Offset: 0x008906B8
		public float Start
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026D1 RID: 9937
		// (get) Token: 0x0601C18F RID: 115087 RVA: 0x008922F0 File Offset: 0x008906F0
		public string Anim
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026D2 RID: 9938
		// (get) Token: 0x0601C190 RID: 115088 RVA: 0x00892320 File Offset: 0x00890720
		public float Blend
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026D3 RID: 9939
		// (get) Token: 0x0601C191 RID: 115089 RVA: 0x00892358 File Offset: 0x00890758
		public int Mode
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026D4 RID: 9940
		// (get) Token: 0x0601C192 RID: 115090 RVA: 0x00892390 File Offset: 0x00890790
		public float Speed
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x0601C193 RID: 115091 RVA: 0x008923C9 File Offset: 0x008907C9
		public static Offset<AnimationFrames> CreateAnimationFrames(FlatBufferBuilder builder, float start = 0f, StringOffset anim = default(StringOffset), float blend = 0f, int mode = 0, float speed = 0f)
		{
			builder.StartObject(5);
			AnimationFrames.AddSpeed(builder, speed);
			AnimationFrames.AddMode(builder, mode);
			AnimationFrames.AddBlend(builder, blend);
			AnimationFrames.AddAnim(builder, anim);
			AnimationFrames.AddStart(builder, start);
			return AnimationFrames.EndAnimationFrames(builder);
		}

		// Token: 0x0601C194 RID: 115092 RVA: 0x008923FD File Offset: 0x008907FD
		public static void StartAnimationFrames(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0601C195 RID: 115093 RVA: 0x00892406 File Offset: 0x00890806
		public static void AddStart(FlatBufferBuilder builder, float start)
		{
			builder.AddFloat(0, start, 0.0);
		}

		// Token: 0x0601C196 RID: 115094 RVA: 0x00892419 File Offset: 0x00890819
		public static void AddAnim(FlatBufferBuilder builder, StringOffset animOffset)
		{
			builder.AddOffset(1, animOffset.Value, 0);
		}

		// Token: 0x0601C197 RID: 115095 RVA: 0x0089242A File Offset: 0x0089082A
		public static void AddBlend(FlatBufferBuilder builder, float blend)
		{
			builder.AddFloat(2, blend, 0.0);
		}

		// Token: 0x0601C198 RID: 115096 RVA: 0x0089243D File Offset: 0x0089083D
		public static void AddMode(FlatBufferBuilder builder, int mode)
		{
			builder.AddInt(3, mode, 0);
		}

		// Token: 0x0601C199 RID: 115097 RVA: 0x00892448 File Offset: 0x00890848
		public static void AddSpeed(FlatBufferBuilder builder, float speed)
		{
			builder.AddFloat(4, speed, 0.0);
		}

		// Token: 0x0601C19A RID: 115098 RVA: 0x0089245C File Offset: 0x0089085C
		public static Offset<AnimationFrames> EndAnimationFrames(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AnimationFrames>(value);
		}
	}
}
