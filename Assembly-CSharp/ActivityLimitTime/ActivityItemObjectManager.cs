using System;
using GameClient;
using UnityEngine;

namespace ActivityLimitTime
{
	// Token: 0x020018C6 RID: 6342
	public class ActivityItemObjectManager : MonoSingleton<ActivityItemObjectManager>
	{
		// Token: 0x0600F7C6 RID: 63430 RVA: 0x00433FAC File Offset: 0x004323AC
		public void InitPrefabPool(GameObject parentGo)
		{
			Utility.AttachTo(base.gameObject, parentGo, false);
			this.InitTabPool(0, ActivityItemObjectManager.TabPrefabResPath);
			this.InitNotePool(0, ActivityItemObjectManager.NotePrefabResPath);
			this.InitDetailPool(0, ActivityItemObjectManager.DetailPrefabResPath);
			this.InitAwardPool(0, ActivityItemObjectManager.AwardPrefabResPath);
		}

		// Token: 0x0600F7C7 RID: 63431 RVA: 0x00433FEC File Offset: 0x004323EC
		public void ReleasePrefabPool()
		{
			if (this.actTabPool != null)
			{
				this.actTabPool.ReleasePool();
			}
			if (this.actNotePool != null)
			{
				this.actNotePool.ReleasePool();
			}
			if (this.actDetailPool != null)
			{
				this.actDetailPool.ReleasePool();
			}
			if (this.actAwardPool != null)
			{
				this.actAwardPool.ReleasePool();
			}
		}

		// Token: 0x0600F7C8 RID: 63432 RVA: 0x00434051 File Offset: 0x00432451
		private void InitTabPool(int initNum, string prefabpath)
		{
			this.actTabPool = new ActivityLTObjectPool<ActivityLTTab>(initNum, base.gameObject, prefabpath);
		}

		// Token: 0x0600F7C9 RID: 63433 RVA: 0x00434066 File Offset: 0x00432466
		private void InitNotePool(int initNum, string prefabpath)
		{
			this.actNotePool = new ActivityLTObjectPool<ActivityLTNote>(initNum, base.gameObject, prefabpath);
		}

		// Token: 0x0600F7CA RID: 63434 RVA: 0x0043407B File Offset: 0x0043247B
		private void InitDetailPool(int initNum, string prefabpath)
		{
			this.actDetailPool = new ActivityLTObjectPool<ActivityLTDetailContent>(initNum, base.gameObject, prefabpath);
		}

		// Token: 0x0600F7CB RID: 63435 RVA: 0x00434090 File Offset: 0x00432490
		private void InitAwardPool(int initNum, string prefabpath)
		{
			this.actAwardPool = new ActivityLTObjectPool<ActivityLTAwardIcon>(initNum, base.gameObject, prefabpath);
		}

		// Token: 0x0600F7CC RID: 63436 RVA: 0x004340A5 File Offset: 0x004324A5
		public GameObject GetActTabGo()
		{
			return this.actTabPool.GetGameObject();
		}

		// Token: 0x0600F7CD RID: 63437 RVA: 0x004340B2 File Offset: 0x004324B2
		public void ReleaseActTabGo(GameObject go)
		{
			this.actTabPool.ReleaseGameObject(go);
		}

		// Token: 0x0600F7CE RID: 63438 RVA: 0x004340C0 File Offset: 0x004324C0
		public GameObject GetActNoteGo()
		{
			return this.actNotePool.GetGameObject();
		}

		// Token: 0x0600F7CF RID: 63439 RVA: 0x004340CD File Offset: 0x004324CD
		public void ReleaseActNoteGo(GameObject go)
		{
			this.actNotePool.ReleaseGameObject(go);
		}

		// Token: 0x0600F7D0 RID: 63440 RVA: 0x004340DB File Offset: 0x004324DB
		public GameObject GetActDetailGo()
		{
			return this.actDetailPool.GetGameObject();
		}

		// Token: 0x0600F7D1 RID: 63441 RVA: 0x004340E8 File Offset: 0x004324E8
		public void ReleaseActDetailGo(GameObject go)
		{
			this.actDetailPool.ReleaseGameObject(go);
		}

		// Token: 0x0600F7D2 RID: 63442 RVA: 0x004340F6 File Offset: 0x004324F6
		public GameObject GetActAwardGo()
		{
			return this.actAwardPool.GetGameObject();
		}

		// Token: 0x0600F7D3 RID: 63443 RVA: 0x00434103 File Offset: 0x00432503
		public void ReleaseActAwardGo(GameObject go)
		{
			this.actAwardPool.ReleaseGameObject(go);
		}

		// Token: 0x040098F8 RID: 39160
		public static string TabPrefabResPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimeTabItem";

		// Token: 0x040098F9 RID: 39161
		public static string NotePrefabResPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimeNote";

		// Token: 0x040098FA RID: 39162
		public static string DetailPrefabResPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimeDetailItem";

		// Token: 0x040098FB RID: 39163
		public static string ConsumeLottryItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ConsumeLottryItem";

		// Token: 0x040098FC RID: 39164
		public static string AwardPrefabResPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimelAwardIcon";

		// Token: 0x040098FD RID: 39165
		private ActivityLTObjectPool<ActivityLTTab> actTabPool;

		// Token: 0x040098FE RID: 39166
		private ActivityLTObjectPool<ActivityLTNote> actNotePool;

		// Token: 0x040098FF RID: 39167
		private ActivityLTObjectPool<ActivityLTDetailContent> actDetailPool;

		// Token: 0x04009900 RID: 39168
		private ActivityLTObjectPool<ActivityLTAwardIcon> actAwardPool;
	}
}
