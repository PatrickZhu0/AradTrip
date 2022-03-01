using System;

namespace Spine
{
	// Token: 0x02004994 RID: 18836
	public class EventTimeline : Timeline
	{
		// Token: 0x0601B0D2 RID: 110802 RVA: 0x008539CF File Offset: 0x00851DCF
		public EventTimeline(int frameCount)
		{
			this.frames = new float[frameCount];
			this.events = new Event[frameCount];
		}

		// Token: 0x170022E4 RID: 8932
		// (get) Token: 0x0601B0D3 RID: 110803 RVA: 0x008539EF File Offset: 0x00851DEF
		// (set) Token: 0x0601B0D4 RID: 110804 RVA: 0x008539F7 File Offset: 0x00851DF7
		public float[] Frames
		{
			get
			{
				return this.frames;
			}
			set
			{
				this.frames = value;
			}
		}

		// Token: 0x170022E5 RID: 8933
		// (get) Token: 0x0601B0D5 RID: 110805 RVA: 0x00853A00 File Offset: 0x00851E00
		// (set) Token: 0x0601B0D6 RID: 110806 RVA: 0x00853A08 File Offset: 0x00851E08
		public Event[] Events
		{
			get
			{
				return this.events;
			}
			set
			{
				this.events = value;
			}
		}

		// Token: 0x170022E6 RID: 8934
		// (get) Token: 0x0601B0D7 RID: 110807 RVA: 0x00853A11 File Offset: 0x00851E11
		public int FrameCount
		{
			get
			{
				return this.frames.Length;
			}
		}

		// Token: 0x170022E7 RID: 8935
		// (get) Token: 0x0601B0D8 RID: 110808 RVA: 0x00853A1B File Offset: 0x00851E1B
		public int PropertyId
		{
			get
			{
				return 117440512;
			}
		}

		// Token: 0x0601B0D9 RID: 110809 RVA: 0x00853A22 File Offset: 0x00851E22
		public void SetFrame(int frameIndex, Event e)
		{
			this.frames[frameIndex] = e.Time;
			this.events[frameIndex] = e;
		}

		// Token: 0x0601B0DA RID: 110810 RVA: 0x00853A3C File Offset: 0x00851E3C
		public void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			if (firedEvents == null)
			{
				return;
			}
			float[] array = this.frames;
			int num = array.Length;
			if (lastTime > time)
			{
				this.Apply(skeleton, lastTime, 2.1474836E+09f, firedEvents, alpha, pose, direction);
				lastTime = -1f;
			}
			else if (lastTime >= array[num - 1])
			{
				return;
			}
			if (time < array[0])
			{
				return;
			}
			int i;
			if (lastTime < array[0])
			{
				i = 0;
			}
			else
			{
				i = Animation.BinarySearch(array, lastTime);
				float num2 = array[i];
				while (i > 0)
				{
					if (array[i - 1] != num2)
					{
						break;
					}
					i--;
				}
			}
			while (i < num && time >= array[i])
			{
				firedEvents.Add(this.events[i]);
				i++;
			}
		}

		// Token: 0x04012DF7 RID: 77303
		internal float[] frames;

		// Token: 0x04012DF8 RID: 77304
		private Event[] events;
	}
}
