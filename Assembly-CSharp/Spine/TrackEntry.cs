using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Spine
{
	// Token: 0x0200499E RID: 18846
	public class TrackEntry : Pool<TrackEntry>.IPoolable
	{
		// Token: 0x0601B13F RID: 110911 RVA: 0x00855E14 File Offset: 0x00854214
		public void Reset()
		{
			this.next = null;
			this.mixingFrom = null;
			this.animation = null;
			this.timelineData.Clear(true);
			this.timelineDipMix.Clear(true);
			this.timelinesRotation.Clear(true);
			this.Start = null;
			this.Interrupt = null;
			this.End = null;
			this.Dispose = null;
			this.Complete = null;
			this.Event = null;
		}

		// Token: 0x0601B140 RID: 110912 RVA: 0x00855E84 File Offset: 0x00854284
		internal TrackEntry SetTimelineData(TrackEntry to, ExposedList<TrackEntry> mixingToArray, HashSet<int> propertyIDs)
		{
			if (to != null)
			{
				mixingToArray.Add(to);
			}
			TrackEntry result = (this.mixingFrom == null) ? this : this.mixingFrom.SetTimelineData(this, mixingToArray, propertyIDs);
			if (to != null)
			{
				mixingToArray.Pop();
			}
			TrackEntry[] items = mixingToArray.Items;
			int num = mixingToArray.Count - 1;
			Timeline[] items2 = this.animation.timelines.Items;
			int count = this.animation.timelines.Count;
			int[] items3 = this.timelineData.Resize(count).Items;
			this.timelineDipMix.Clear(true);
			TrackEntry[] items4 = this.timelineDipMix.Resize(count).Items;
			for (int i = 0; i < count; i++)
			{
				int propertyId = items2[i].PropertyId;
				if (!propertyIDs.Add(propertyId))
				{
					items3[i] = 0;
				}
				else if (to == null || !to.HasTimeline(propertyId))
				{
					items3[i] = 1;
				}
				else
				{
					int j = num;
					while (j >= 0)
					{
						TrackEntry trackEntry = items[j];
						if (!trackEntry.HasTimeline(propertyId))
						{
							if (trackEntry.mixDuration > 0f)
							{
								items3[i] = 3;
								items4[i] = trackEntry;
								goto IL_142;
							}
							break;
						}
						else
						{
							j--;
						}
					}
					items3[i] = 2;
				}
				IL_142:;
			}
			return result;
		}

		// Token: 0x0601B141 RID: 110913 RVA: 0x00855FE4 File Offset: 0x008543E4
		private bool HasTimeline(int id)
		{
			Timeline[] items = this.animation.timelines.Items;
			int i = 0;
			int count = this.animation.timelines.Count;
			while (i < count)
			{
				if (items[i].PropertyId == id)
				{
					return true;
				}
				i++;
			}
			return false;
		}

		// Token: 0x170022FC RID: 8956
		// (get) Token: 0x0601B142 RID: 110914 RVA: 0x00856036 File Offset: 0x00854436
		public int TrackIndex
		{
			get
			{
				return this.trackIndex;
			}
		}

		// Token: 0x170022FD RID: 8957
		// (get) Token: 0x0601B143 RID: 110915 RVA: 0x0085603E File Offset: 0x0085443E
		public Animation Animation
		{
			get
			{
				return this.animation;
			}
		}

		// Token: 0x170022FE RID: 8958
		// (get) Token: 0x0601B144 RID: 110916 RVA: 0x00856046 File Offset: 0x00854446
		// (set) Token: 0x0601B145 RID: 110917 RVA: 0x0085604E File Offset: 0x0085444E
		public bool Loop
		{
			get
			{
				return this.loop;
			}
			set
			{
				this.loop = value;
			}
		}

		// Token: 0x170022FF RID: 8959
		// (get) Token: 0x0601B146 RID: 110918 RVA: 0x00856057 File Offset: 0x00854457
		// (set) Token: 0x0601B147 RID: 110919 RVA: 0x0085605F File Offset: 0x0085445F
		public float Delay
		{
			get
			{
				return this.delay;
			}
			set
			{
				this.delay = value;
			}
		}

		// Token: 0x17002300 RID: 8960
		// (get) Token: 0x0601B148 RID: 110920 RVA: 0x00856068 File Offset: 0x00854468
		// (set) Token: 0x0601B149 RID: 110921 RVA: 0x00856070 File Offset: 0x00854470
		public float TrackTime
		{
			get
			{
				return this.trackTime;
			}
			set
			{
				this.trackTime = value;
			}
		}

		// Token: 0x17002301 RID: 8961
		// (get) Token: 0x0601B14A RID: 110922 RVA: 0x00856079 File Offset: 0x00854479
		// (set) Token: 0x0601B14B RID: 110923 RVA: 0x00856081 File Offset: 0x00854481
		public float TrackEnd
		{
			get
			{
				return this.trackEnd;
			}
			set
			{
				this.trackEnd = value;
			}
		}

		// Token: 0x17002302 RID: 8962
		// (get) Token: 0x0601B14C RID: 110924 RVA: 0x0085608A File Offset: 0x0085448A
		// (set) Token: 0x0601B14D RID: 110925 RVA: 0x00856092 File Offset: 0x00854492
		public float AnimationStart
		{
			get
			{
				return this.animationStart;
			}
			set
			{
				this.animationStart = value;
			}
		}

		// Token: 0x17002303 RID: 8963
		// (get) Token: 0x0601B14E RID: 110926 RVA: 0x0085609B File Offset: 0x0085449B
		// (set) Token: 0x0601B14F RID: 110927 RVA: 0x008560A3 File Offset: 0x008544A3
		public float AnimationEnd
		{
			get
			{
				return this.animationEnd;
			}
			set
			{
				this.animationEnd = value;
			}
		}

		// Token: 0x17002304 RID: 8964
		// (get) Token: 0x0601B150 RID: 110928 RVA: 0x008560AC File Offset: 0x008544AC
		// (set) Token: 0x0601B151 RID: 110929 RVA: 0x008560B4 File Offset: 0x008544B4
		public float AnimationLast
		{
			get
			{
				return this.animationLast;
			}
			set
			{
				this.animationLast = value;
				this.nextAnimationLast = value;
			}
		}

		// Token: 0x17002305 RID: 8965
		// (get) Token: 0x0601B152 RID: 110930 RVA: 0x008560C4 File Offset: 0x008544C4
		public float AnimationTime
		{
			get
			{
				if (!this.loop)
				{
					return Math.Min(this.trackTime + this.animationStart, this.animationEnd);
				}
				float num = this.animationEnd - this.animationStart;
				if (num == 0f)
				{
					return this.animationStart;
				}
				return this.trackTime % num + this.animationStart;
			}
		}

		// Token: 0x17002306 RID: 8966
		// (get) Token: 0x0601B153 RID: 110931 RVA: 0x00856124 File Offset: 0x00854524
		// (set) Token: 0x0601B154 RID: 110932 RVA: 0x0085612C File Offset: 0x0085452C
		public float TimeScale
		{
			get
			{
				return this.timeScale;
			}
			set
			{
				this.timeScale = value;
			}
		}

		// Token: 0x17002307 RID: 8967
		// (get) Token: 0x0601B155 RID: 110933 RVA: 0x00856135 File Offset: 0x00854535
		// (set) Token: 0x0601B156 RID: 110934 RVA: 0x0085613D File Offset: 0x0085453D
		public float Alpha
		{
			get
			{
				return this.alpha;
			}
			set
			{
				this.alpha = value;
			}
		}

		// Token: 0x17002308 RID: 8968
		// (get) Token: 0x0601B157 RID: 110935 RVA: 0x00856146 File Offset: 0x00854546
		// (set) Token: 0x0601B158 RID: 110936 RVA: 0x0085614E File Offset: 0x0085454E
		public float EventThreshold
		{
			get
			{
				return this.eventThreshold;
			}
			set
			{
				this.eventThreshold = value;
			}
		}

		// Token: 0x17002309 RID: 8969
		// (get) Token: 0x0601B159 RID: 110937 RVA: 0x00856157 File Offset: 0x00854557
		// (set) Token: 0x0601B15A RID: 110938 RVA: 0x0085615F File Offset: 0x0085455F
		public float AttachmentThreshold
		{
			get
			{
				return this.attachmentThreshold;
			}
			set
			{
				this.attachmentThreshold = value;
			}
		}

		// Token: 0x1700230A RID: 8970
		// (get) Token: 0x0601B15B RID: 110939 RVA: 0x00856168 File Offset: 0x00854568
		// (set) Token: 0x0601B15C RID: 110940 RVA: 0x00856170 File Offset: 0x00854570
		public float DrawOrderThreshold
		{
			get
			{
				return this.drawOrderThreshold;
			}
			set
			{
				this.drawOrderThreshold = value;
			}
		}

		// Token: 0x1700230B RID: 8971
		// (get) Token: 0x0601B15D RID: 110941 RVA: 0x00856179 File Offset: 0x00854579
		public TrackEntry Next
		{
			get
			{
				return this.next;
			}
		}

		// Token: 0x1700230C RID: 8972
		// (get) Token: 0x0601B15E RID: 110942 RVA: 0x00856181 File Offset: 0x00854581
		public bool IsComplete
		{
			get
			{
				return this.trackTime >= this.animationEnd - this.animationStart;
			}
		}

		// Token: 0x1700230D RID: 8973
		// (get) Token: 0x0601B15F RID: 110943 RVA: 0x0085619B File Offset: 0x0085459B
		// (set) Token: 0x0601B160 RID: 110944 RVA: 0x008561A3 File Offset: 0x008545A3
		public float MixTime
		{
			get
			{
				return this.mixTime;
			}
			set
			{
				this.mixTime = value;
			}
		}

		// Token: 0x1700230E RID: 8974
		// (get) Token: 0x0601B161 RID: 110945 RVA: 0x008561AC File Offset: 0x008545AC
		// (set) Token: 0x0601B162 RID: 110946 RVA: 0x008561B4 File Offset: 0x008545B4
		public float MixDuration
		{
			get
			{
				return this.mixDuration;
			}
			set
			{
				this.mixDuration = value;
			}
		}

		// Token: 0x1700230F RID: 8975
		// (get) Token: 0x0601B163 RID: 110947 RVA: 0x008561BD File Offset: 0x008545BD
		public TrackEntry MixingFrom
		{
			get
			{
				return this.mixingFrom;
			}
		}

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x0601B164 RID: 110948 RVA: 0x008561C8 File Offset: 0x008545C8
		// (remove) Token: 0x0601B165 RID: 110949 RVA: 0x00856200 File Offset: 0x00854600
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Start;

		// Token: 0x1400006D RID: 109
		// (add) Token: 0x0601B166 RID: 110950 RVA: 0x00856238 File Offset: 0x00854638
		// (remove) Token: 0x0601B167 RID: 110951 RVA: 0x00856270 File Offset: 0x00854670
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryEventDelegate Event;

		// Token: 0x0601B168 RID: 110952 RVA: 0x008562A6 File Offset: 0x008546A6
		internal void OnStart()
		{
			if (this.Start != null)
			{
				this.Start(this);
			}
		}

		// Token: 0x0601B169 RID: 110953 RVA: 0x008562BF File Offset: 0x008546BF
		internal void OnInterrupt()
		{
			if (this.Interrupt != null)
			{
				this.Interrupt(this);
			}
		}

		// Token: 0x0601B16A RID: 110954 RVA: 0x008562D8 File Offset: 0x008546D8
		internal void OnEnd()
		{
			if (this.End != null)
			{
				this.End(this);
			}
		}

		// Token: 0x0601B16B RID: 110955 RVA: 0x008562F1 File Offset: 0x008546F1
		internal void OnDispose()
		{
			if (this.Dispose != null)
			{
				this.Dispose(this);
			}
		}

		// Token: 0x0601B16C RID: 110956 RVA: 0x0085630A File Offset: 0x0085470A
		internal void OnComplete()
		{
			if (this.Complete != null)
			{
				this.Complete(this);
			}
		}

		// Token: 0x0601B16D RID: 110957 RVA: 0x00856323 File Offset: 0x00854723
		internal void OnEvent(Event e)
		{
			if (this.Event != null)
			{
				this.Event(this, e);
			}
		}

		// Token: 0x0601B16E RID: 110958 RVA: 0x0085633D File Offset: 0x0085473D
		public void ResetRotationDirections()
		{
			this.timelinesRotation.Clear(true);
		}

		// Token: 0x0601B16F RID: 110959 RVA: 0x0085634B File Offset: 0x0085474B
		public override string ToString()
		{
			return (this.animation != null) ? this.animation.name : "<none>";
		}

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x0601B170 RID: 110960 RVA: 0x00856370 File Offset: 0x00854770
		// (remove) Token: 0x0601B171 RID: 110961 RVA: 0x008563A8 File Offset: 0x008547A8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Interrupt;

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x0601B172 RID: 110962 RVA: 0x008563E0 File Offset: 0x008547E0
		// (remove) Token: 0x0601B173 RID: 110963 RVA: 0x00856418 File Offset: 0x00854818
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate End;

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x0601B174 RID: 110964 RVA: 0x00856450 File Offset: 0x00854850
		// (remove) Token: 0x0601B175 RID: 110965 RVA: 0x00856488 File Offset: 0x00854888
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Dispose;

		// Token: 0x1400006C RID: 108
		// (add) Token: 0x0601B176 RID: 110966 RVA: 0x008564C0 File Offset: 0x008548C0
		// (remove) Token: 0x0601B177 RID: 110967 RVA: 0x008564F8 File Offset: 0x008548F8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Complete;

		// Token: 0x04012E31 RID: 77361
		internal Animation animation;

		// Token: 0x04012E32 RID: 77362
		internal TrackEntry next;

		// Token: 0x04012E33 RID: 77363
		internal TrackEntry mixingFrom;

		// Token: 0x04012E34 RID: 77364
		internal int trackIndex;

		// Token: 0x04012E35 RID: 77365
		internal bool loop;

		// Token: 0x04012E36 RID: 77366
		internal float eventThreshold;

		// Token: 0x04012E37 RID: 77367
		internal float attachmentThreshold;

		// Token: 0x04012E38 RID: 77368
		internal float drawOrderThreshold;

		// Token: 0x04012E39 RID: 77369
		internal float animationStart;

		// Token: 0x04012E3A RID: 77370
		internal float animationEnd;

		// Token: 0x04012E3B RID: 77371
		internal float animationLast;

		// Token: 0x04012E3C RID: 77372
		internal float nextAnimationLast;

		// Token: 0x04012E3D RID: 77373
		internal float delay;

		// Token: 0x04012E3E RID: 77374
		internal float trackTime;

		// Token: 0x04012E3F RID: 77375
		internal float trackLast;

		// Token: 0x04012E40 RID: 77376
		internal float nextTrackLast;

		// Token: 0x04012E41 RID: 77377
		internal float trackEnd;

		// Token: 0x04012E42 RID: 77378
		internal float timeScale = 1f;

		// Token: 0x04012E43 RID: 77379
		internal float alpha;

		// Token: 0x04012E44 RID: 77380
		internal float mixTime;

		// Token: 0x04012E45 RID: 77381
		internal float mixDuration;

		// Token: 0x04012E46 RID: 77382
		internal float interruptAlpha;

		// Token: 0x04012E47 RID: 77383
		internal float totalAlpha;

		// Token: 0x04012E48 RID: 77384
		internal readonly ExposedList<int> timelineData = new ExposedList<int>();

		// Token: 0x04012E49 RID: 77385
		internal readonly ExposedList<TrackEntry> timelineDipMix = new ExposedList<TrackEntry>();

		// Token: 0x04012E4A RID: 77386
		internal readonly ExposedList<float> timelinesRotation = new ExposedList<float>();
	}
}
