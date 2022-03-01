using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Spine
{
	// Token: 0x0200499B RID: 18843
	public class AnimationState
	{
		// Token: 0x0601B107 RID: 110855 RVA: 0x008546F4 File Offset: 0x00852AF4
		public AnimationState(AnimationStateData data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			this.data = data;
			this.queue = new EventQueue(this, delegate()
			{
				this.animationsChanged = true;
			}, this.trackEntryPool);
		}

		// Token: 0x170022F9 RID: 8953
		// (get) Token: 0x0601B108 RID: 110856 RVA: 0x0085478B File Offset: 0x00852B8B
		public AnimationStateData Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x170022FA RID: 8954
		// (get) Token: 0x0601B109 RID: 110857 RVA: 0x00854793 File Offset: 0x00852B93
		public ExposedList<TrackEntry> Tracks
		{
			get
			{
				return this.tracks;
			}
		}

		// Token: 0x170022FB RID: 8955
		// (get) Token: 0x0601B10A RID: 110858 RVA: 0x0085479B File Offset: 0x00852B9B
		// (set) Token: 0x0601B10B RID: 110859 RVA: 0x008547A3 File Offset: 0x00852BA3
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

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x0601B10C RID: 110860 RVA: 0x008547AC File Offset: 0x00852BAC
		// (remove) Token: 0x0601B10D RID: 110861 RVA: 0x008547E4 File Offset: 0x00852BE4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Start;

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x0601B10E RID: 110862 RVA: 0x0085481C File Offset: 0x00852C1C
		// (remove) Token: 0x0601B10F RID: 110863 RVA: 0x00854854 File Offset: 0x00852C54
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryEventDelegate Event;

		// Token: 0x0601B110 RID: 110864 RVA: 0x0085488C File Offset: 0x00852C8C
		public void Update(float delta)
		{
			delta *= this.timeScale;
			TrackEntry[] items = this.tracks.Items;
			int i = 0;
			int count = this.tracks.Count;
			while (i < count)
			{
				TrackEntry trackEntry = items[i];
				if (trackEntry != null)
				{
					trackEntry.animationLast = trackEntry.nextAnimationLast;
					trackEntry.trackLast = trackEntry.nextTrackLast;
					float num = delta * trackEntry.timeScale;
					if (trackEntry.delay > 0f)
					{
						trackEntry.delay -= num;
						if (trackEntry.delay > 0f)
						{
							goto IL_1C9;
						}
						num = -trackEntry.delay;
						trackEntry.delay = 0f;
					}
					TrackEntry trackEntry2 = trackEntry.next;
					if (trackEntry2 != null)
					{
						float num2 = trackEntry.trackLast - trackEntry2.delay;
						if (num2 >= 0f)
						{
							trackEntry2.delay = 0f;
							trackEntry2.trackTime = num2 + delta * trackEntry2.timeScale;
							trackEntry.trackTime += num;
							this.SetCurrent(i, trackEntry2, true);
							while (trackEntry2.mixingFrom != null)
							{
								trackEntry2.mixTime += num;
								trackEntry2 = trackEntry2.mixingFrom;
							}
							goto IL_1C9;
						}
					}
					else if (trackEntry.trackLast >= trackEntry.trackEnd && trackEntry.mixingFrom == null)
					{
						items[i] = null;
						this.queue.End(trackEntry);
						this.DisposeNext(trackEntry);
						goto IL_1C9;
					}
					if (trackEntry.mixingFrom != null && this.UpdateMixingFrom(trackEntry, delta))
					{
						TrackEntry mixingFrom = trackEntry.mixingFrom;
						trackEntry.mixingFrom = null;
						while (mixingFrom != null)
						{
							this.queue.End(mixingFrom);
							mixingFrom = mixingFrom.mixingFrom;
						}
					}
					trackEntry.trackTime += num;
				}
				IL_1C9:
				i++;
			}
			this.queue.Drain();
		}

		// Token: 0x0601B111 RID: 110865 RVA: 0x00854A78 File Offset: 0x00852E78
		private bool UpdateMixingFrom(TrackEntry to, float delta)
		{
			TrackEntry mixingFrom = to.mixingFrom;
			if (mixingFrom == null)
			{
				return true;
			}
			bool result = this.UpdateMixingFrom(mixingFrom, delta);
			mixingFrom.animationLast = mixingFrom.nextAnimationLast;
			mixingFrom.trackLast = mixingFrom.nextTrackLast;
			if (to.mixTime > 0f && (to.mixTime >= to.mixDuration || to.timeScale == 0f))
			{
				if (mixingFrom.totalAlpha == 0f || to.mixDuration == 0f)
				{
					to.mixingFrom = mixingFrom.mixingFrom;
					to.interruptAlpha = mixingFrom.interruptAlpha;
					this.queue.End(mixingFrom);
				}
				return result;
			}
			mixingFrom.trackTime += delta * mixingFrom.timeScale;
			to.mixTime += delta * to.timeScale;
			return false;
		}

		// Token: 0x0601B112 RID: 110866 RVA: 0x00854B58 File Offset: 0x00852F58
		public bool Apply(Skeleton skeleton)
		{
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton", "skeleton cannot be null.");
			}
			if (this.animationsChanged)
			{
				this.AnimationsChanged();
			}
			ExposedList<Event> exposedList = this.events;
			bool result = false;
			TrackEntry[] items = this.tracks.Items;
			int i = 0;
			int count = this.tracks.Count;
			while (i < count)
			{
				TrackEntry trackEntry = items[i];
				if (trackEntry != null && trackEntry.delay <= 0f)
				{
					result = true;
					MixPose mixPose = (i != 0) ? MixPose.CurrentLayered : MixPose.Current;
					float num = trackEntry.alpha;
					if (trackEntry.mixingFrom != null)
					{
						num *= this.ApplyMixingFrom(trackEntry, skeleton, mixPose);
					}
					else if (trackEntry.trackTime >= trackEntry.trackEnd && trackEntry.next == null)
					{
						num = 0f;
					}
					float animationLast = trackEntry.animationLast;
					float animationTime = trackEntry.AnimationTime;
					int count2 = trackEntry.animation.timelines.Count;
					ExposedList<Timeline> timelines = trackEntry.animation.timelines;
					Timeline[] items2 = timelines.Items;
					if (num == 1f)
					{
						for (int j = 0; j < count2; j++)
						{
							items2[j].Apply(skeleton, animationLast, animationTime, exposedList, 1f, MixPose.Setup, MixDirection.In);
						}
					}
					else
					{
						int[] items3 = trackEntry.timelineData.Items;
						bool flag = trackEntry.timelinesRotation.Count == 0;
						if (flag)
						{
							trackEntry.timelinesRotation.EnsureCapacity(timelines.Count << 1);
						}
						float[] items4 = trackEntry.timelinesRotation.Items;
						for (int k = 0; k < count2; k++)
						{
							Timeline timeline = items2[k];
							MixPose pose = (items3[k] < 1) ? mixPose : MixPose.Setup;
							RotateTimeline rotateTimeline = timeline as RotateTimeline;
							if (rotateTimeline != null)
							{
								AnimationState.ApplyRotateTimeline(rotateTimeline, skeleton, animationTime, num, pose, items4, k << 1, flag);
							}
							else
							{
								timeline.Apply(skeleton, animationLast, animationTime, exposedList, num, pose, MixDirection.In);
							}
						}
					}
					this.QueueEvents(trackEntry, animationTime);
					exposedList.Clear(false);
					trackEntry.nextAnimationLast = animationTime;
					trackEntry.nextTrackLast = trackEntry.trackTime;
				}
				i++;
			}
			this.queue.Drain();
			return result;
		}

		// Token: 0x0601B113 RID: 110867 RVA: 0x00854DAC File Offset: 0x008531AC
		private float ApplyMixingFrom(TrackEntry to, Skeleton skeleton, MixPose currentPose)
		{
			TrackEntry mixingFrom = to.mixingFrom;
			if (mixingFrom.mixingFrom != null)
			{
				this.ApplyMixingFrom(mixingFrom, skeleton, currentPose);
			}
			float num;
			if (to.mixDuration == 0f)
			{
				num = 1f;
				currentPose = MixPose.Setup;
			}
			else
			{
				num = to.mixTime / to.mixDuration;
				if (num > 1f)
				{
					num = 1f;
				}
			}
			ExposedList<Event> exposedList = (num >= mixingFrom.eventThreshold) ? null : this.events;
			bool flag = num < mixingFrom.attachmentThreshold;
			bool flag2 = num < mixingFrom.drawOrderThreshold;
			float animationLast = mixingFrom.animationLast;
			float animationTime = mixingFrom.AnimationTime;
			ExposedList<Timeline> timelines = mixingFrom.animation.timelines;
			int count = timelines.Count;
			Timeline[] items = timelines.Items;
			int[] items2 = mixingFrom.timelineData.Items;
			TrackEntry[] items3 = mixingFrom.timelineDipMix.Items;
			bool flag3 = mixingFrom.timelinesRotation.Count == 0;
			if (flag3)
			{
				mixingFrom.timelinesRotation.Resize(timelines.Count << 1);
			}
			float[] items4 = mixingFrom.timelinesRotation.Items;
			float num2 = mixingFrom.alpha * to.interruptAlpha;
			float num3 = num2 * (1f - num);
			mixingFrom.totalAlpha = 0f;
			int i = 0;
			while (i < count)
			{
				Timeline timeline = items[i];
				MixPose pose;
				float num4;
				switch (items2[i])
				{
				case 0:
					if (flag || !(timeline is AttachmentTimeline))
					{
						if (flag2 || !(timeline is DrawOrderTimeline))
						{
							pose = currentPose;
							num4 = num3;
							goto IL_1E3;
						}
					}
					break;
				case 1:
					pose = MixPose.Setup;
					num4 = num3;
					goto IL_1E3;
				case 2:
					pose = MixPose.Setup;
					num4 = num2;
					goto IL_1E3;
				default:
				{
					pose = MixPose.Setup;
					TrackEntry trackEntry = items3[i];
					num4 = num2 * Math.Max(0f, 1f - trackEntry.mixTime / trackEntry.mixDuration);
					goto IL_1E3;
				}
				}
				IL_22F:
				i++;
				continue;
				IL_1E3:
				mixingFrom.totalAlpha += num4;
				RotateTimeline rotateTimeline = timeline as RotateTimeline;
				if (rotateTimeline != null)
				{
					AnimationState.ApplyRotateTimeline(rotateTimeline, skeleton, animationTime, num4, pose, items4, i << 1, flag3);
					goto IL_22F;
				}
				timeline.Apply(skeleton, animationLast, animationTime, exposedList, num4, pose, MixDirection.Out);
				goto IL_22F;
			}
			if (to.mixDuration > 0f)
			{
				this.QueueEvents(mixingFrom, animationTime);
			}
			this.events.Clear(false);
			mixingFrom.nextAnimationLast = animationTime;
			mixingFrom.nextTrackLast = mixingFrom.trackTime;
			return num;
		}

		// Token: 0x0601B114 RID: 110868 RVA: 0x00855034 File Offset: 0x00853434
		private static void ApplyRotateTimeline(RotateTimeline rotateTimeline, Skeleton skeleton, float time, float alpha, MixPose pose, float[] timelinesRotation, int i, bool firstFrame)
		{
			if (firstFrame)
			{
				timelinesRotation[i] = 0f;
			}
			if (alpha == 1f)
			{
				rotateTimeline.Apply(skeleton, 0f, time, null, 1f, pose, MixDirection.In);
				return;
			}
			Bone bone = skeleton.bones.Items[rotateTimeline.boneIndex];
			float[] frames = rotateTimeline.frames;
			if (time < frames[0])
			{
				if (pose == MixPose.Setup)
				{
					bone.rotation = bone.data.rotation;
				}
				return;
			}
			float num;
			if (time >= frames[frames.Length - 2])
			{
				num = bone.data.rotation + frames[frames.Length + -1];
			}
			else
			{
				int num2 = Animation.BinarySearch(frames, time, 2);
				float num3 = frames[num2 + -1];
				float num4 = frames[num2];
				float curvePercent = rotateTimeline.GetCurvePercent((num2 >> 1) - 1, 1f - (time - num4) / (frames[num2 + -2] - num4));
				num = frames[num2 + 1] - num3;
				num -= (float)((16384 - (int)(16384.499999999996 - (double)(num / 360f))) * 360);
				num = num3 + num * curvePercent + bone.data.rotation;
				num -= (float)((16384 - (int)(16384.499999999996 - (double)(num / 360f))) * 360);
			}
			float num5 = (pose != MixPose.Setup) ? bone.rotation : bone.data.rotation;
			float num6 = num - num5;
			num6 -= (float)((16384 - (int)(16384.499999999996 - (double)(num6 / 360f))) * 360);
			float num7;
			if (num6 == 0f)
			{
				num7 = timelinesRotation[i];
			}
			else
			{
				float num8;
				float value;
				if (firstFrame)
				{
					num8 = 0f;
					value = num6;
				}
				else
				{
					num8 = timelinesRotation[i];
					value = timelinesRotation[i + 1];
				}
				bool flag = num6 > 0f;
				bool flag2 = num8 >= 0f;
				if (Math.Sign(value) != Math.Sign(num6) && Math.Abs(value) <= 90f)
				{
					if (Math.Abs(num8) > 180f)
					{
						num8 += (float)(360 * Math.Sign(num8));
					}
					flag2 = flag;
				}
				num7 = num6 + num8 - num8 % 360f;
				if (flag2 != flag)
				{
					num7 += (float)(360 * Math.Sign(num8));
				}
				timelinesRotation[i] = num7;
			}
			timelinesRotation[i + 1] = num6;
			num5 += num7 * alpha;
			bone.rotation = num5 - (float)((16384 - (int)(16384.499999999996 - (double)(num5 / 360f))) * 360);
		}

		// Token: 0x0601B115 RID: 110869 RVA: 0x008552D0 File Offset: 0x008536D0
		private void QueueEvents(TrackEntry entry, float animationTime)
		{
			float animationStart = entry.animationStart;
			float animationEnd = entry.animationEnd;
			float num = animationEnd - animationStart;
			float num2 = entry.trackLast % num;
			ExposedList<Event> exposedList = this.events;
			Event[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Event @event = items[i];
				if (@event.time < num2)
				{
					break;
				}
				if (@event.time <= animationEnd)
				{
					this.queue.Event(entry, @event);
				}
				i++;
			}
			bool flag;
			if (entry.loop)
			{
				flag = (num == 0f || num2 > entry.trackTime % num);
			}
			else
			{
				flag = (animationTime >= animationEnd && entry.animationLast < animationEnd);
			}
			if (flag)
			{
				this.queue.Complete(entry);
			}
			while (i < count)
			{
				Event event2 = items[i];
				if (event2.time >= animationStart)
				{
					this.queue.Event(entry, items[i]);
				}
				i++;
			}
		}

		// Token: 0x0601B116 RID: 110870 RVA: 0x008553F8 File Offset: 0x008537F8
		public void ClearTracks()
		{
			bool drainDisabled = this.queue.drainDisabled;
			this.queue.drainDisabled = true;
			int i = 0;
			int count = this.tracks.Count;
			while (i < count)
			{
				this.ClearTrack(i);
				i++;
			}
			this.tracks.Clear(true);
			this.queue.drainDisabled = drainDisabled;
			this.queue.Drain();
		}

		// Token: 0x0601B117 RID: 110871 RVA: 0x00855468 File Offset: 0x00853868
		public void ClearTrack(int trackIndex)
		{
			if (trackIndex >= this.tracks.Count)
			{
				return;
			}
			TrackEntry trackEntry = this.tracks.Items[trackIndex];
			if (trackEntry == null)
			{
				return;
			}
			this.queue.End(trackEntry);
			this.DisposeNext(trackEntry);
			TrackEntry trackEntry2 = trackEntry;
			for (;;)
			{
				TrackEntry mixingFrom = trackEntry2.mixingFrom;
				if (mixingFrom == null)
				{
					break;
				}
				this.queue.End(mixingFrom);
				trackEntry2.mixingFrom = null;
				trackEntry2 = mixingFrom;
			}
			this.tracks.Items[trackEntry.trackIndex] = null;
			this.queue.Drain();
		}

		// Token: 0x0601B118 RID: 110872 RVA: 0x008554FC File Offset: 0x008538FC
		private void SetCurrent(int index, TrackEntry current, bool interrupt)
		{
			TrackEntry trackEntry = this.ExpandToIndex(index);
			this.tracks.Items[index] = current;
			if (trackEntry != null)
			{
				if (interrupt)
				{
					this.queue.Interrupt(trackEntry);
				}
				current.mixingFrom = trackEntry;
				current.mixTime = 0f;
				if (trackEntry.mixingFrom != null && trackEntry.mixDuration > 0f)
				{
					current.interruptAlpha *= Math.Min(1f, trackEntry.mixTime / trackEntry.mixDuration);
				}
				trackEntry.timelinesRotation.Clear(true);
			}
			this.queue.Start(current);
		}

		// Token: 0x0601B119 RID: 110873 RVA: 0x008555A0 File Offset: 0x008539A0
		public TrackEntry SetAnimation(int trackIndex, string animationName, bool loop)
		{
			Animation animation = this.data.skeletonData.FindAnimation(animationName);
			if (animation == null)
			{
				throw new ArgumentException("Animation not found: " + animationName, "animationName");
			}
			return this.SetAnimation(trackIndex, animation, loop);
		}

		// Token: 0x0601B11A RID: 110874 RVA: 0x008555E4 File Offset: 0x008539E4
		public TrackEntry SetAnimation(int trackIndex, Animation animation, bool loop)
		{
			if (animation == null)
			{
				throw new ArgumentNullException("animation", "animation cannot be null.");
			}
			bool interrupt = true;
			TrackEntry trackEntry = this.ExpandToIndex(trackIndex);
			if (trackEntry != null)
			{
				if (trackEntry.nextTrackLast == -1f)
				{
					this.tracks.Items[trackIndex] = trackEntry.mixingFrom;
					this.queue.Interrupt(trackEntry);
					this.queue.End(trackEntry);
					this.DisposeNext(trackEntry);
					trackEntry = trackEntry.mixingFrom;
					interrupt = false;
				}
				else
				{
					this.DisposeNext(trackEntry);
				}
			}
			TrackEntry trackEntry2 = this.NewTrackEntry(trackIndex, animation, loop, trackEntry);
			this.SetCurrent(trackIndex, trackEntry2, interrupt);
			this.queue.Drain();
			return trackEntry2;
		}

		// Token: 0x0601B11B RID: 110875 RVA: 0x00855690 File Offset: 0x00853A90
		public TrackEntry AddAnimation(int trackIndex, string animationName, bool loop, float delay)
		{
			Animation animation = this.data.skeletonData.FindAnimation(animationName);
			if (animation == null)
			{
				throw new ArgumentException("Animation not found: " + animationName, "animationName");
			}
			return this.AddAnimation(trackIndex, animation, loop, delay);
		}

		// Token: 0x0601B11C RID: 110876 RVA: 0x008556D8 File Offset: 0x00853AD8
		public TrackEntry AddAnimation(int trackIndex, Animation animation, bool loop, float delay)
		{
			if (animation == null)
			{
				throw new ArgumentNullException("animation", "animation cannot be null.");
			}
			TrackEntry trackEntry = this.ExpandToIndex(trackIndex);
			if (trackEntry != null)
			{
				while (trackEntry.next != null)
				{
					trackEntry = trackEntry.next;
				}
			}
			TrackEntry trackEntry2 = this.NewTrackEntry(trackIndex, animation, loop, trackEntry);
			if (trackEntry == null)
			{
				this.SetCurrent(trackIndex, trackEntry2, true);
				this.queue.Drain();
			}
			else
			{
				trackEntry.next = trackEntry2;
				if (delay <= 0f)
				{
					float num = trackEntry.animationEnd - trackEntry.animationStart;
					if (num != 0f)
					{
						if (trackEntry.loop)
						{
							delay += num * (float)(1 + (int)(trackEntry.trackTime / num));
						}
						else
						{
							delay += num;
						}
						delay -= this.data.GetMix(trackEntry.animation, animation);
					}
					else
					{
						delay = 0f;
					}
				}
			}
			trackEntry2.delay = delay;
			return trackEntry2;
		}

		// Token: 0x0601B11D RID: 110877 RVA: 0x008557CC File Offset: 0x00853BCC
		public TrackEntry SetEmptyAnimation(int trackIndex, float mixDuration)
		{
			TrackEntry trackEntry = this.SetAnimation(trackIndex, AnimationState.EmptyAnimation, false);
			trackEntry.mixDuration = mixDuration;
			trackEntry.trackEnd = mixDuration;
			return trackEntry;
		}

		// Token: 0x0601B11E RID: 110878 RVA: 0x008557F8 File Offset: 0x00853BF8
		public TrackEntry AddEmptyAnimation(int trackIndex, float mixDuration, float delay)
		{
			if (delay <= 0f)
			{
				delay -= mixDuration;
			}
			TrackEntry trackEntry = this.AddAnimation(trackIndex, AnimationState.EmptyAnimation, false, delay);
			trackEntry.mixDuration = mixDuration;
			trackEntry.trackEnd = mixDuration;
			return trackEntry;
		}

		// Token: 0x0601B11F RID: 110879 RVA: 0x00855834 File Offset: 0x00853C34
		public void SetEmptyAnimations(float mixDuration)
		{
			bool drainDisabled = this.queue.drainDisabled;
			this.queue.drainDisabled = true;
			int i = 0;
			int count = this.tracks.Count;
			while (i < count)
			{
				TrackEntry trackEntry = this.tracks.Items[i];
				if (trackEntry != null)
				{
					this.SetEmptyAnimation(i, mixDuration);
				}
				i++;
			}
			this.queue.drainDisabled = drainDisabled;
			this.queue.Drain();
		}

		// Token: 0x0601B120 RID: 110880 RVA: 0x008558AC File Offset: 0x00853CAC
		private TrackEntry ExpandToIndex(int index)
		{
			if (index < this.tracks.Count)
			{
				return this.tracks.Items[index];
			}
			while (index >= this.tracks.Count)
			{
				this.tracks.Add(null);
			}
			return null;
		}

		// Token: 0x0601B121 RID: 110881 RVA: 0x008558FC File Offset: 0x00853CFC
		private TrackEntry NewTrackEntry(int trackIndex, Animation animation, bool loop, TrackEntry last)
		{
			TrackEntry trackEntry = this.trackEntryPool.Obtain();
			trackEntry.trackIndex = trackIndex;
			trackEntry.animation = animation;
			trackEntry.loop = loop;
			trackEntry.eventThreshold = 0f;
			trackEntry.attachmentThreshold = 0f;
			trackEntry.drawOrderThreshold = 0f;
			trackEntry.animationStart = 0f;
			trackEntry.animationEnd = animation.Duration;
			trackEntry.animationLast = -1f;
			trackEntry.nextAnimationLast = -1f;
			trackEntry.delay = 0f;
			trackEntry.trackTime = 0f;
			trackEntry.trackLast = -1f;
			trackEntry.nextTrackLast = -1f;
			trackEntry.trackEnd = float.MaxValue;
			trackEntry.timeScale = 1f;
			trackEntry.alpha = 1f;
			trackEntry.interruptAlpha = 1f;
			trackEntry.mixTime = 0f;
			trackEntry.mixDuration = ((last != null) ? this.data.GetMix(last.animation, animation) : 0f);
			return trackEntry;
		}

		// Token: 0x0601B122 RID: 110882 RVA: 0x00855A08 File Offset: 0x00853E08
		private void DisposeNext(TrackEntry entry)
		{
			for (TrackEntry next = entry.next; next != null; next = next.next)
			{
				this.queue.Dispose(next);
			}
			entry.next = null;
		}

		// Token: 0x0601B123 RID: 110883 RVA: 0x00855A44 File Offset: 0x00853E44
		private void AnimationsChanged()
		{
			this.animationsChanged = false;
			HashSet<int> hashSet = this.propertyIDs;
			hashSet.Clear();
			ExposedList<TrackEntry> mixingToArray = this.mixingTo;
			TrackEntry[] items = this.tracks.Items;
			int i = 0;
			int count = this.tracks.Count;
			while (i < count)
			{
				TrackEntry trackEntry = items[i];
				if (trackEntry != null)
				{
					trackEntry.SetTimelineData(null, mixingToArray, hashSet);
				}
				i++;
			}
		}

		// Token: 0x0601B124 RID: 110884 RVA: 0x00855AAF File Offset: 0x00853EAF
		public TrackEntry GetCurrent(int trackIndex)
		{
			return (trackIndex < this.tracks.Count) ? this.tracks.Items[trackIndex] : null;
		}

		// Token: 0x0601B125 RID: 110885 RVA: 0x00855AD8 File Offset: 0x00853ED8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int i = 0;
			int count = this.tracks.Count;
			while (i < count)
			{
				TrackEntry trackEntry = this.tracks.Items[i];
				if (trackEntry != null)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(trackEntry.ToString());
				}
				i++;
			}
			return (stringBuilder.Length != 0) ? stringBuilder.ToString() : "<none>";
		}

		// Token: 0x0601B126 RID: 110886 RVA: 0x00855B62 File Offset: 0x00853F62
		internal void OnStart(TrackEntry entry)
		{
			if (this.Start != null)
			{
				this.Start(entry);
			}
		}

		// Token: 0x0601B127 RID: 110887 RVA: 0x00855B7B File Offset: 0x00853F7B
		internal void OnInterrupt(TrackEntry entry)
		{
			if (this.Interrupt != null)
			{
				this.Interrupt(entry);
			}
		}

		// Token: 0x0601B128 RID: 110888 RVA: 0x00855B94 File Offset: 0x00853F94
		internal void OnEnd(TrackEntry entry)
		{
			if (this.End != null)
			{
				this.End(entry);
			}
		}

		// Token: 0x0601B129 RID: 110889 RVA: 0x00855BAD File Offset: 0x00853FAD
		internal void OnDispose(TrackEntry entry)
		{
			if (this.Dispose != null)
			{
				this.Dispose(entry);
			}
		}

		// Token: 0x0601B12A RID: 110890 RVA: 0x00855BC6 File Offset: 0x00853FC6
		internal void OnComplete(TrackEntry entry)
		{
			if (this.Complete != null)
			{
				this.Complete(entry);
			}
		}

		// Token: 0x0601B12B RID: 110891 RVA: 0x00855BDF File Offset: 0x00853FDF
		internal void OnEvent(TrackEntry entry, Event e)
		{
			if (this.Event != null)
			{
				this.Event(entry, e);
			}
		}

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x0601B12C RID: 110892 RVA: 0x00855BFC File Offset: 0x00853FFC
		// (remove) Token: 0x0601B12D RID: 110893 RVA: 0x00855C34 File Offset: 0x00854034
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Interrupt;

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x0601B12E RID: 110894 RVA: 0x00855C6C File Offset: 0x0085406C
		// (remove) Token: 0x0601B12F RID: 110895 RVA: 0x00855CA4 File Offset: 0x008540A4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate End;

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x0601B130 RID: 110896 RVA: 0x00855CDC File Offset: 0x008540DC
		// (remove) Token: 0x0601B131 RID: 110897 RVA: 0x00855D14 File Offset: 0x00854114
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Dispose;

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x0601B132 RID: 110898 RVA: 0x00855D4C File Offset: 0x0085414C
		// (remove) Token: 0x0601B133 RID: 110899 RVA: 0x00855D84 File Offset: 0x00854184
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event AnimationState.TrackEntryDelegate Complete;

		// Token: 0x04012E1D RID: 77341
		private static readonly Animation EmptyAnimation = new Animation("<empty>", new ExposedList<Timeline>(), 0f);

		// Token: 0x04012E1E RID: 77342
		internal const int Subsequent = 0;

		// Token: 0x04012E1F RID: 77343
		internal const int First = 1;

		// Token: 0x04012E20 RID: 77344
		internal const int Dip = 2;

		// Token: 0x04012E21 RID: 77345
		internal const int DipMix = 3;

		// Token: 0x04012E22 RID: 77346
		private AnimationStateData data;

		// Token: 0x04012E23 RID: 77347
		private Pool<TrackEntry> trackEntryPool = new Pool<TrackEntry>(16, int.MaxValue);

		// Token: 0x04012E24 RID: 77348
		private readonly ExposedList<TrackEntry> tracks = new ExposedList<TrackEntry>();

		// Token: 0x04012E25 RID: 77349
		private readonly ExposedList<Event> events = new ExposedList<Event>();

		// Token: 0x04012E26 RID: 77350
		private readonly EventQueue queue;

		// Token: 0x04012E27 RID: 77351
		private readonly HashSet<int> propertyIDs = new HashSet<int>();

		// Token: 0x04012E28 RID: 77352
		private readonly ExposedList<TrackEntry> mixingTo = new ExposedList<TrackEntry>();

		// Token: 0x04012E29 RID: 77353
		private bool animationsChanged;

		// Token: 0x04012E2A RID: 77354
		private float timeScale = 1f;

		// Token: 0x0200499C RID: 18844
		// (Invoke) Token: 0x0601B137 RID: 110903
		public delegate void TrackEntryDelegate(TrackEntry trackEntry);

		// Token: 0x0200499D RID: 18845
		// (Invoke) Token: 0x0601B13B RID: 110907
		public delegate void TrackEntryEventDelegate(TrackEntry trackEntry, Event e);
	}
}
