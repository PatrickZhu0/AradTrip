using System;

namespace Spine
{
	// Token: 0x020049BE RID: 18878
	public class Event
	{
		// Token: 0x0601B28D RID: 111245 RVA: 0x00858EA0 File Offset: 0x008572A0
		public Event(float time, EventData data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			this.time = time;
			this.data = data;
		}

		// Token: 0x1700237A RID: 9082
		// (get) Token: 0x0601B28E RID: 111246 RVA: 0x00858ECC File Offset: 0x008572CC
		public EventData Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x1700237B RID: 9083
		// (get) Token: 0x0601B28F RID: 111247 RVA: 0x00858ED4 File Offset: 0x008572D4
		public float Time
		{
			get
			{
				return this.time;
			}
		}

		// Token: 0x1700237C RID: 9084
		// (get) Token: 0x0601B290 RID: 111248 RVA: 0x00858EDC File Offset: 0x008572DC
		// (set) Token: 0x0601B291 RID: 111249 RVA: 0x00858EE4 File Offset: 0x008572E4
		public int Int
		{
			get
			{
				return this.intValue;
			}
			set
			{
				this.intValue = value;
			}
		}

		// Token: 0x1700237D RID: 9085
		// (get) Token: 0x0601B292 RID: 111250 RVA: 0x00858EED File Offset: 0x008572ED
		// (set) Token: 0x0601B293 RID: 111251 RVA: 0x00858EF5 File Offset: 0x008572F5
		public float Float
		{
			get
			{
				return this.floatValue;
			}
			set
			{
				this.floatValue = value;
			}
		}

		// Token: 0x1700237E RID: 9086
		// (get) Token: 0x0601B294 RID: 111252 RVA: 0x00858EFE File Offset: 0x008572FE
		// (set) Token: 0x0601B295 RID: 111253 RVA: 0x00858F06 File Offset: 0x00857306
		public string String
		{
			get
			{
				return this.stringValue;
			}
			set
			{
				this.stringValue = value;
			}
		}

		// Token: 0x0601B296 RID: 111254 RVA: 0x00858F0F File Offset: 0x0085730F
		public override string ToString()
		{
			return this.data.Name;
		}

		// Token: 0x04012F1B RID: 77595
		internal readonly EventData data;

		// Token: 0x04012F1C RID: 77596
		internal readonly float time;

		// Token: 0x04012F1D RID: 77597
		internal int intValue;

		// Token: 0x04012F1E RID: 77598
		internal float floatValue;

		// Token: 0x04012F1F RID: 77599
		internal string stringValue;
	}
}
