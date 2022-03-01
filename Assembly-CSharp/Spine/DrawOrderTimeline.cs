using System;

namespace Spine
{
	// Token: 0x02004995 RID: 18837
	public class DrawOrderTimeline : Timeline
	{
		// Token: 0x0601B0DB RID: 110811 RVA: 0x00853AFE File Offset: 0x00851EFE
		public DrawOrderTimeline(int frameCount)
		{
			this.frames = new float[frameCount];
			this.drawOrders = new int[frameCount][];
		}

		// Token: 0x170022E8 RID: 8936
		// (get) Token: 0x0601B0DC RID: 110812 RVA: 0x00853B1E File Offset: 0x00851F1E
		// (set) Token: 0x0601B0DD RID: 110813 RVA: 0x00853B26 File Offset: 0x00851F26
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

		// Token: 0x170022E9 RID: 8937
		// (get) Token: 0x0601B0DE RID: 110814 RVA: 0x00853B2F File Offset: 0x00851F2F
		// (set) Token: 0x0601B0DF RID: 110815 RVA: 0x00853B37 File Offset: 0x00851F37
		public int[][] DrawOrders
		{
			get
			{
				return this.drawOrders;
			}
			set
			{
				this.drawOrders = value;
			}
		}

		// Token: 0x170022EA RID: 8938
		// (get) Token: 0x0601B0E0 RID: 110816 RVA: 0x00853B40 File Offset: 0x00851F40
		public int FrameCount
		{
			get
			{
				return this.frames.Length;
			}
		}

		// Token: 0x170022EB RID: 8939
		// (get) Token: 0x0601B0E1 RID: 110817 RVA: 0x00853B4A File Offset: 0x00851F4A
		public int PropertyId
		{
			get
			{
				return 134217728;
			}
		}

		// Token: 0x0601B0E2 RID: 110818 RVA: 0x00853B51 File Offset: 0x00851F51
		public void SetFrame(int frameIndex, float time, int[] drawOrder)
		{
			this.frames[frameIndex] = time;
			this.drawOrders[frameIndex] = drawOrder;
		}

		// Token: 0x0601B0E3 RID: 110819 RVA: 0x00853B68 File Offset: 0x00851F68
		public void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			ExposedList<Slot> drawOrder = skeleton.drawOrder;
			ExposedList<Slot> slots = skeleton.slots;
			if (direction == MixDirection.Out && pose == MixPose.Setup)
			{
				Array.Copy(slots.Items, 0, drawOrder.Items, 0, slots.Count);
				return;
			}
			float[] array = this.frames;
			if (time < array[0])
			{
				if (pose == MixPose.Setup)
				{
					Array.Copy(slots.Items, 0, drawOrder.Items, 0, slots.Count);
				}
				return;
			}
			int num;
			if (time >= array[array.Length - 1])
			{
				num = array.Length - 1;
			}
			else
			{
				num = Animation.BinarySearch(array, time) - 1;
			}
			int[] array2 = this.drawOrders[num];
			if (array2 == null)
			{
				drawOrder.Clear(true);
				int i = 0;
				int count = slots.Count;
				while (i < count)
				{
					drawOrder.Add(slots.Items[i]);
					i++;
				}
			}
			else
			{
				Slot[] items = drawOrder.Items;
				Slot[] items2 = slots.Items;
				int j = 0;
				int num2 = array2.Length;
				while (j < num2)
				{
					items[j] = items2[array2[j]];
					j++;
				}
			}
		}

		// Token: 0x04012DF9 RID: 77305
		internal float[] frames;

		// Token: 0x04012DFA RID: 77306
		private int[][] drawOrders;
	}
}
