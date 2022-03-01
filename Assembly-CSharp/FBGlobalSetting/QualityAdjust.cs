using System;
using FlatBuffers;

namespace FBGlobalSetting
{
	// Token: 0x02000125 RID: 293
	public sealed class QualityAdjust : Struct
	{
		// Token: 0x060006D4 RID: 1748 RVA: 0x0002813A File Offset: 0x0002653A
		public QualityAdjust __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0002814B File Offset: 0x0002654B
		public bool BIsOpen
		{
			get
			{
				return 0 != this.bb.Get(this.bb_pos);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x00028164 File Offset: 0x00026564
		public float FInterval
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x00028179 File Offset: 0x00026579
		public int ITimes
		{
			get
			{
				return this.bb.GetInt(this.bb_pos + 8);
			}
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0002818E File Offset: 0x0002658E
		public static Offset<QualityAdjust> CreateQualityAdjust(FlatBufferBuilder builder, bool BIsOpen, float FInterval, int ITimes)
		{
			builder.Prep(4, 12);
			builder.PutInt(ITimes);
			builder.PutFloat(FInterval);
			builder.Pad(3);
			builder.PutBool(BIsOpen);
			return new Offset<QualityAdjust>(builder.Offset);
		}
	}
}
