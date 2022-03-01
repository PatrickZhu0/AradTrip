using System;

namespace GameClient
{
	// Token: 0x02001854 RID: 6228
	public class LimitTimeMallGiftPackActivity : LimitTimeMallGiftPackActivityBase
	{
		// Token: 0x0600F479 RID: 62585 RVA: 0x00420460 File Offset: 0x0041E860
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/MallGiftPackItem";
		}

		// Token: 0x0600F47A RID: 62586 RVA: 0x00420467 File Offset: 0x0041E867
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/MallGiftPackActivity";
		}
	}
}
