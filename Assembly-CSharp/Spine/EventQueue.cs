using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Spine
{
	// Token: 0x0200499F RID: 18847
	internal class EventQueue
	{
		// Token: 0x0601B178 RID: 110968 RVA: 0x0085652E File Offset: 0x0085492E
		internal EventQueue(AnimationState state, Action HandleAnimationsChanged, Pool<TrackEntry> trackEntryPool)
		{
			this.state = state;
			this.AnimationsChanged += HandleAnimationsChanged;
			this.trackEntryPool = trackEntryPool;
		}

		// Token: 0x1400006E RID: 110
		// (add) Token: 0x0601B179 RID: 110969 RVA: 0x00856558 File Offset: 0x00854958
		// (remove) Token: 0x0601B17A RID: 110970 RVA: 0x00856590 File Offset: 0x00854990
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal event Action AnimationsChanged;

		// Token: 0x0601B17B RID: 110971 RVA: 0x008565C6 File Offset: 0x008549C6
		internal void Start(TrackEntry entry)
		{
			this.eventQueueEntries.Add(new EventQueue.EventQueueEntry(EventQueue.EventType.Start, entry, null));
			if (this.AnimationsChanged != null)
			{
				this.AnimationsChanged();
			}
		}

		// Token: 0x0601B17C RID: 110972 RVA: 0x008565F1 File Offset: 0x008549F1
		internal void Interrupt(TrackEntry entry)
		{
			this.eventQueueEntries.Add(new EventQueue.EventQueueEntry(EventQueue.EventType.Interrupt, entry, null));
		}

		// Token: 0x0601B17D RID: 110973 RVA: 0x00856606 File Offset: 0x00854A06
		internal void End(TrackEntry entry)
		{
			this.eventQueueEntries.Add(new EventQueue.EventQueueEntry(EventQueue.EventType.End, entry, null));
			if (this.AnimationsChanged != null)
			{
				this.AnimationsChanged();
			}
		}

		// Token: 0x0601B17E RID: 110974 RVA: 0x00856631 File Offset: 0x00854A31
		internal void Dispose(TrackEntry entry)
		{
			this.eventQueueEntries.Add(new EventQueue.EventQueueEntry(EventQueue.EventType.Dispose, entry, null));
		}

		// Token: 0x0601B17F RID: 110975 RVA: 0x00856646 File Offset: 0x00854A46
		internal void Complete(TrackEntry entry)
		{
			this.eventQueueEntries.Add(new EventQueue.EventQueueEntry(EventQueue.EventType.Complete, entry, null));
		}

		// Token: 0x0601B180 RID: 110976 RVA: 0x0085665B File Offset: 0x00854A5B
		internal void Event(TrackEntry entry, Event e)
		{
			this.eventQueueEntries.Add(new EventQueue.EventQueueEntry(EventQueue.EventType.Event, entry, e));
		}

		// Token: 0x0601B181 RID: 110977 RVA: 0x00856670 File Offset: 0x00854A70
		internal void Drain()
		{
			if (this.drainDisabled)
			{
				return;
			}
			this.drainDisabled = true;
			List<EventQueue.EventQueueEntry> list = this.eventQueueEntries;
			AnimationState animationState = this.state;
			int i = 0;
			while (i < list.Count)
			{
				EventQueue.EventQueueEntry eventQueueEntry = list[i];
				TrackEntry entry = eventQueueEntry.entry;
				switch (eventQueueEntry.type)
				{
				case EventQueue.EventType.Start:
					entry.OnStart();
					animationState.OnStart(entry);
					break;
				case EventQueue.EventType.Interrupt:
					entry.OnInterrupt();
					animationState.OnInterrupt(entry);
					break;
				case EventQueue.EventType.End:
					entry.OnEnd();
					animationState.OnEnd(entry);
					goto IL_A2;
				case EventQueue.EventType.Dispose:
					goto IL_A2;
				case EventQueue.EventType.Complete:
					entry.OnComplete();
					animationState.OnComplete(entry);
					break;
				case EventQueue.EventType.Event:
					entry.OnEvent(eventQueueEntry.e);
					animationState.OnEvent(entry, eventQueueEntry.e);
					break;
				}
				IL_F9:
				i++;
				continue;
				IL_A2:
				entry.OnDispose();
				animationState.OnDispose(entry);
				this.trackEntryPool.Free(entry);
				goto IL_F9;
			}
			this.eventQueueEntries.Clear();
			this.drainDisabled = false;
		}

		// Token: 0x0601B182 RID: 110978 RVA: 0x00856798 File Offset: 0x00854B98
		internal void Clear()
		{
			this.eventQueueEntries.Clear();
		}

		// Token: 0x04012E51 RID: 77393
		private readonly List<EventQueue.EventQueueEntry> eventQueueEntries = new List<EventQueue.EventQueueEntry>();

		// Token: 0x04012E52 RID: 77394
		internal bool drainDisabled;

		// Token: 0x04012E53 RID: 77395
		private readonly AnimationState state;

		// Token: 0x04012E54 RID: 77396
		private readonly Pool<TrackEntry> trackEntryPool;

		// Token: 0x020049A0 RID: 18848
		private struct EventQueueEntry
		{
			// Token: 0x0601B183 RID: 110979 RVA: 0x008567A5 File Offset: 0x00854BA5
			public EventQueueEntry(EventQueue.EventType eventType, TrackEntry trackEntry, Event e = null)
			{
				this.type = eventType;
				this.entry = trackEntry;
				this.e = e;
			}

			// Token: 0x04012E56 RID: 77398
			public EventQueue.EventType type;

			// Token: 0x04012E57 RID: 77399
			public TrackEntry entry;

			// Token: 0x04012E58 RID: 77400
			public Event e;
		}

		// Token: 0x020049A1 RID: 18849
		private enum EventType
		{
			// Token: 0x04012E5A RID: 77402
			Start,
			// Token: 0x04012E5B RID: 77403
			Interrupt,
			// Token: 0x04012E5C RID: 77404
			End,
			// Token: 0x04012E5D RID: 77405
			Dispose,
			// Token: 0x04012E5E RID: 77406
			Complete,
			// Token: 0x04012E5F RID: 77407
			Event
		}
	}
}
