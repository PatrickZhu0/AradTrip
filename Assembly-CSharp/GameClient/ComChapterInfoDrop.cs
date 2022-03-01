using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E86 RID: 3718
	public class ComChapterInfoDrop : MonoBehaviour, IChapterInfoDrops
	{
		// Token: 0x06009323 RID: 37667 RVA: 0x001B6290 File Offset: 0x001B4690
		private void _createDropUnit(int id, int mDungeonID)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Chapter/Normal/ChapterInfoDropItem", true, 0U);
			Utility.AttachTo(gameObject, base.gameObject, false);
			ComChapterInfoDropUnit component = gameObject.GetComponent<ComChapterInfoDropUnit>();
			if (null != component)
			{
				component.Load(id);
				component.ShowName(this.showName);
				component.ShowLevel(this.showLevel);
				component.ShowFatigueCombustionBuffRoot(mDungeonID);
				component.SetSize(new Vector2((float)this.weith, (float)this.height));
				this.mCache.Add(component);
			}
		}

		// Token: 0x06009324 RID: 37668 RVA: 0x001B631A File Offset: 0x001B471A
		private void OnDestroy()
		{
			this._unload();
		}

		// Token: 0x06009325 RID: 37669 RVA: 0x001B6324 File Offset: 0x001B4724
		private void _unload()
		{
			for (int i = 0; i < this.mCache.Count; i++)
			{
				this.mCache[i].Unload();
				Object.Destroy(this.mCache[i].gameObject);
			}
			this.mCache.Clear();
		}

		// Token: 0x06009326 RID: 37670 RVA: 0x001B6380 File Offset: 0x001B4780
		private IEnumerator _setDropListIter(IList<int> drops, int dungonID)
		{
			this._unload();
			yield return Yielders.EndOfFrame;
			if (drops != null)
			{
				for (int i = 0; i < drops.Count; i++)
				{
					this._createDropUnit(drops[i], dungonID);
					yield return Yielders.EndOfFrame;
				}
			}
			yield break;
		}

		// Token: 0x06009327 RID: 37671 RVA: 0x001B63A9 File Offset: 0x001B47A9
		public void SetDropList(IList<int> drops, int dungonID)
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this._setDropListIter(drops, dungonID));
		}

		// Token: 0x06009328 RID: 37672 RVA: 0x001B63C0 File Offset: 0x001B47C0
		public void UpdateDropCount(List<ComItemList.Items> drops)
		{
		}

		// Token: 0x06009329 RID: 37673 RVA: 0x001B63C4 File Offset: 0x001B47C4
		public void RefreshFaFatigueCombustionBuff()
		{
			for (int i = 0; i < this.mCache.Count; i++)
			{
				this.mCache[i].CloseFatigueCombustionBuffRoot();
			}
		}

		// Token: 0x04004A40 RID: 19008
		public bool showName = true;

		// Token: 0x04004A41 RID: 19009
		public bool showLevel = true;

		// Token: 0x04004A42 RID: 19010
		public int weith;

		// Token: 0x04004A43 RID: 19011
		public int height;

		// Token: 0x04004A44 RID: 19012
		private const string kItemPrfabPath = "UIFlatten/Prefabs/Chapter/Normal/ChapterInfoDropItem";

		// Token: 0x04004A45 RID: 19013
		private List<ComChapterInfoDropUnit> mCache = new List<ComChapterInfoDropUnit>();
	}
}
