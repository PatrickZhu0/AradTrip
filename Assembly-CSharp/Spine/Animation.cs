using System;

namespace Spine
{
	// Token: 0x02004986 RID: 18822
	public class Animation
	{
		// Token: 0x0601B081 RID: 110721 RVA: 0x00851ED8 File Offset: 0x008502D8
		public Animation(string name, ExposedList<Timeline> timelines, float duration)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			if (timelines == null)
			{
				throw new ArgumentNullException("timelines", "timelines cannot be null.");
			}
			this.name = name;
			this.timelines = timelines;
			this.duration = duration;
		}

		// Token: 0x170022C6 RID: 8902
		// (get) Token: 0x0601B082 RID: 110722 RVA: 0x00851F2C File Offset: 0x0085032C
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170022C7 RID: 8903
		// (get) Token: 0x0601B083 RID: 110723 RVA: 0x00851F34 File Offset: 0x00850334
		// (set) Token: 0x0601B084 RID: 110724 RVA: 0x00851F3C File Offset: 0x0085033C
		public ExposedList<Timeline> Timelines
		{
			get
			{
				return this.timelines;
			}
			set
			{
				this.timelines = value;
			}
		}

		// Token: 0x170022C8 RID: 8904
		// (get) Token: 0x0601B085 RID: 110725 RVA: 0x00851F45 File Offset: 0x00850345
		// (set) Token: 0x0601B086 RID: 110726 RVA: 0x00851F4D File Offset: 0x0085034D
		public float Duration
		{
			get
			{
				return this.duration;
			}
			set
			{
				this.duration = value;
			}
		}

		// Token: 0x0601B087 RID: 110727 RVA: 0x00851F58 File Offset: 0x00850358
		public void Apply(Skeleton skeleton, float lastTime, float time, bool loop, ExposedList<Event> events, float alpha, MixPose pose, MixDirection direction)
		{
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton", "skeleton cannot be null.");
			}
			if (loop && this.duration != 0f)
			{
				time %= this.duration;
				if (lastTime > 0f)
				{
					lastTime %= this.duration;
				}
			}
			ExposedList<Timeline> exposedList = this.timelines;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				exposedList.Items[i].Apply(skeleton, lastTime, time, events, alpha, pose, direction);
				i++;
			}
		}

		// Token: 0x0601B088 RID: 110728 RVA: 0x00851FEC File Offset: 0x008503EC
		internal static int BinarySearch(float[] values, float target, int step)
		{
			int num = 0;
			int num2 = values.Length / step - 2;
			if (num2 == 0)
			{
				return step;
			}
			int num3 = (int)((uint)num2 >> 1);
			for (;;)
			{
				if (values[(num3 + 1) * step] <= target)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3;
				}
				if (num == num2)
				{
					break;
				}
				num3 = (int)((uint)(num + num2) >> 1);
			}
			return (num + 1) * step;
		}

		// Token: 0x0601B089 RID: 110729 RVA: 0x00852040 File Offset: 0x00850440
		internal static int BinarySearch(float[] values, float target)
		{
			int num = 0;
			int num2 = values.Length - 2;
			if (num2 == 0)
			{
				return 1;
			}
			int num3 = (int)((uint)num2 >> 1);
			for (;;)
			{
				if (values[num3 + 1] <= target)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3;
				}
				if (num == num2)
				{
					break;
				}
				num3 = (int)((uint)(num + num2) >> 1);
			}
			return num + 1;
		}

		// Token: 0x0601B08A RID: 110730 RVA: 0x0085208C File Offset: 0x0085048C
		internal static int LinearSearch(float[] values, float target, int step)
		{
			int i = 0;
			int num = values.Length - step;
			while (i <= num)
			{
				if (values[i] > target)
				{
					return i;
				}
				i += step;
			}
			return -1;
		}

		// Token: 0x04012DA5 RID: 77221
		internal ExposedList<Timeline> timelines;

		// Token: 0x04012DA6 RID: 77222
		internal float duration;

		// Token: 0x04012DA7 RID: 77223
		internal string name;
	}
}
