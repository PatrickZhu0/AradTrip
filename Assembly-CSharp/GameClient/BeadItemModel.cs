using System;

namespace GameClient
{
	// Token: 0x02001ABD RID: 6845
	public class BeadItemModel : IBeadItemModel
	{
		// Token: 0x06010CF0 RID: 68848 RVA: 0x004CA8B8 File Offset: 0x004C8CB8
		public BeadItemModel(int mountedType, ItemData beadItemData, int eqPrecHoleIndex, ItemData equipItemData, int buffID, int beadPickNumber, int holeType, int replceNumber)
		{
			this.mountedType = mountedType;
			if (this.mountedType != 0)
			{
				this.equipItemData = equipItemData;
				this.eqPrecHoleIndex = eqPrecHoleIndex;
			}
			this.beadItemData = beadItemData;
			this.buffID = buffID;
			this.beadPickNumber = beadPickNumber;
			this.holeType = holeType;
			this.replaceNumber = replceNumber;
		}

		// Token: 0x17001D65 RID: 7525
		// (get) Token: 0x06010CF1 RID: 68849 RVA: 0x004CA918 File Offset: 0x004C8D18
		// (set) Token: 0x06010CF2 RID: 68850 RVA: 0x004CA920 File Offset: 0x004C8D20
		public int eqPrecHoleIndex { get; private set; }

		// Token: 0x17001D66 RID: 7526
		// (get) Token: 0x06010CF3 RID: 68851 RVA: 0x004CA929 File Offset: 0x004C8D29
		// (set) Token: 0x06010CF4 RID: 68852 RVA: 0x004CA931 File Offset: 0x004C8D31
		public ItemData equipItemData { get; private set; }

		// Token: 0x17001D67 RID: 7527
		// (get) Token: 0x06010CF5 RID: 68853 RVA: 0x004CA93A File Offset: 0x004C8D3A
		// (set) Token: 0x06010CF6 RID: 68854 RVA: 0x004CA942 File Offset: 0x004C8D42
		public int mountedType { get; private set; }

		// Token: 0x17001D68 RID: 7528
		// (get) Token: 0x06010CF7 RID: 68855 RVA: 0x004CA94B File Offset: 0x004C8D4B
		// (set) Token: 0x06010CF8 RID: 68856 RVA: 0x004CA953 File Offset: 0x004C8D53
		public ItemData beadItemData { get; private set; }

		// Token: 0x17001D69 RID: 7529
		// (get) Token: 0x06010CF9 RID: 68857 RVA: 0x004CA95C File Offset: 0x004C8D5C
		// (set) Token: 0x06010CFA RID: 68858 RVA: 0x004CA964 File Offset: 0x004C8D64
		public int buffID { get; private set; }

		// Token: 0x17001D6A RID: 7530
		// (get) Token: 0x06010CFB RID: 68859 RVA: 0x004CA96D File Offset: 0x004C8D6D
		// (set) Token: 0x06010CFC RID: 68860 RVA: 0x004CA975 File Offset: 0x004C8D75
		public int beadPickNumber { get; private set; }

		// Token: 0x17001D6B RID: 7531
		// (get) Token: 0x06010CFD RID: 68861 RVA: 0x004CA97E File Offset: 0x004C8D7E
		// (set) Token: 0x06010CFE RID: 68862 RVA: 0x004CA986 File Offset: 0x004C8D86
		public int holeType { get; private set; }

		// Token: 0x17001D6C RID: 7532
		// (get) Token: 0x06010CFF RID: 68863 RVA: 0x004CA98F File Offset: 0x004C8D8F
		// (set) Token: 0x06010D00 RID: 68864 RVA: 0x004CA997 File Offset: 0x004C8D97
		public int replaceNumber { get; private set; }
	}
}
