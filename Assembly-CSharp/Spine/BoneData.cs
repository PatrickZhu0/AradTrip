using System;

namespace Spine
{
	// Token: 0x020049BC RID: 18876
	public class BoneData
	{
		// Token: 0x0601B276 RID: 111222 RVA: 0x00858D7C File Offset: 0x0085717C
		public BoneData(int index, string name, BoneData parent)
		{
			if (index < 0)
			{
				throw new ArgumentException("index must be >= 0", "index");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.index = index;
			this.name = name;
			this.parent = parent;
		}

		// Token: 0x1700236E RID: 9070
		// (get) Token: 0x0601B277 RID: 111223 RVA: 0x00858DE7 File Offset: 0x008571E7
		public int Index
		{
			get
			{
				return this.index;
			}
		}

		// Token: 0x1700236F RID: 9071
		// (get) Token: 0x0601B278 RID: 111224 RVA: 0x00858DEF File Offset: 0x008571EF
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17002370 RID: 9072
		// (get) Token: 0x0601B279 RID: 111225 RVA: 0x00858DF7 File Offset: 0x008571F7
		public BoneData Parent
		{
			get
			{
				return this.parent;
			}
		}

		// Token: 0x17002371 RID: 9073
		// (get) Token: 0x0601B27A RID: 111226 RVA: 0x00858DFF File Offset: 0x008571FF
		// (set) Token: 0x0601B27B RID: 111227 RVA: 0x00858E07 File Offset: 0x00857207
		public float Length
		{
			get
			{
				return this.length;
			}
			set
			{
				this.length = value;
			}
		}

		// Token: 0x17002372 RID: 9074
		// (get) Token: 0x0601B27C RID: 111228 RVA: 0x00858E10 File Offset: 0x00857210
		// (set) Token: 0x0601B27D RID: 111229 RVA: 0x00858E18 File Offset: 0x00857218
		public float X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x17002373 RID: 9075
		// (get) Token: 0x0601B27E RID: 111230 RVA: 0x00858E21 File Offset: 0x00857221
		// (set) Token: 0x0601B27F RID: 111231 RVA: 0x00858E29 File Offset: 0x00857229
		public float Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17002374 RID: 9076
		// (get) Token: 0x0601B280 RID: 111232 RVA: 0x00858E32 File Offset: 0x00857232
		// (set) Token: 0x0601B281 RID: 111233 RVA: 0x00858E3A File Offset: 0x0085723A
		public float Rotation
		{
			get
			{
				return this.rotation;
			}
			set
			{
				this.rotation = value;
			}
		}

		// Token: 0x17002375 RID: 9077
		// (get) Token: 0x0601B282 RID: 111234 RVA: 0x00858E43 File Offset: 0x00857243
		// (set) Token: 0x0601B283 RID: 111235 RVA: 0x00858E4B File Offset: 0x0085724B
		public float ScaleX
		{
			get
			{
				return this.scaleX;
			}
			set
			{
				this.scaleX = value;
			}
		}

		// Token: 0x17002376 RID: 9078
		// (get) Token: 0x0601B284 RID: 111236 RVA: 0x00858E54 File Offset: 0x00857254
		// (set) Token: 0x0601B285 RID: 111237 RVA: 0x00858E5C File Offset: 0x0085725C
		public float ScaleY
		{
			get
			{
				return this.scaleY;
			}
			set
			{
				this.scaleY = value;
			}
		}

		// Token: 0x17002377 RID: 9079
		// (get) Token: 0x0601B286 RID: 111238 RVA: 0x00858E65 File Offset: 0x00857265
		// (set) Token: 0x0601B287 RID: 111239 RVA: 0x00858E6D File Offset: 0x0085726D
		public float ShearX
		{
			get
			{
				return this.shearX;
			}
			set
			{
				this.shearX = value;
			}
		}

		// Token: 0x17002378 RID: 9080
		// (get) Token: 0x0601B288 RID: 111240 RVA: 0x00858E76 File Offset: 0x00857276
		// (set) Token: 0x0601B289 RID: 111241 RVA: 0x00858E7E File Offset: 0x0085727E
		public float ShearY
		{
			get
			{
				return this.shearY;
			}
			set
			{
				this.shearY = value;
			}
		}

		// Token: 0x17002379 RID: 9081
		// (get) Token: 0x0601B28A RID: 111242 RVA: 0x00858E87 File Offset: 0x00857287
		// (set) Token: 0x0601B28B RID: 111243 RVA: 0x00858E8F File Offset: 0x0085728F
		public TransformMode TransformMode
		{
			get
			{
				return this.transformMode;
			}
			set
			{
				this.transformMode = value;
			}
		}

		// Token: 0x0601B28C RID: 111244 RVA: 0x00858E98 File Offset: 0x00857298
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x04012F09 RID: 77577
		internal int index;

		// Token: 0x04012F0A RID: 77578
		internal string name;

		// Token: 0x04012F0B RID: 77579
		internal BoneData parent;

		// Token: 0x04012F0C RID: 77580
		internal float length;

		// Token: 0x04012F0D RID: 77581
		internal float x;

		// Token: 0x04012F0E RID: 77582
		internal float y;

		// Token: 0x04012F0F RID: 77583
		internal float rotation;

		// Token: 0x04012F10 RID: 77584
		internal float scaleX = 1f;

		// Token: 0x04012F11 RID: 77585
		internal float scaleY = 1f;

		// Token: 0x04012F12 RID: 77586
		internal float shearX;

		// Token: 0x04012F13 RID: 77587
		internal float shearY;

		// Token: 0x04012F14 RID: 77588
		internal TransformMode transformMode;
	}
}
