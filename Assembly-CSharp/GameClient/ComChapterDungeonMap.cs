using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E80 RID: 3712
	[ExecuteInEditMode]
	public class ComChapterDungeonMap : MonoBehaviour
	{
		// Token: 0x06009305 RID: 37637 RVA: 0x001B5228 File Offset: 0x001B3628
		private int _getIndex(IDungeonConnectData item)
		{
			int num = 1;
			int num2 = 0;
			for (int i = 0; i < 4; i++)
			{
				if (item.GetIsConnect(i))
				{
					num2 += num;
				}
				num *= 2;
			}
			return num2;
		}

		// Token: 0x06009306 RID: 37638 RVA: 0x001B5260 File Offset: 0x001B3660
		private void _unloadCache()
		{
			for (int i = 0; i < this.mCache.Count; i++)
			{
				Object.Destroy(this.mCache[i]);
			}
			this.mCache.Clear();
		}

		// Token: 0x06009307 RID: 37639 RVA: 0x001B52A8 File Offset: 0x001B36A8
		private GameObject _createTag(string name, string spriteName, GameObject root, float scale)
		{
			GameObject gameObject = new GameObject(name, new Type[]
			{
				typeof(Image)
			});
			Utility.AttachTo(gameObject, root, false);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.offsetMin = new Vector2(-15f, -15f);
			component.offsetMax = new Vector2(15f, 15f);
			component.anchorMax = new Vector2(0.5f, 0.5f);
			component.anchorMin = new Vector2(0.5f, 0.5f);
			Image component2 = gameObject.GetComponent<Image>();
			this.mBind.GetSprite(spriteName, ref component2);
			component2.SetNativeSize();
			component2.GetComponent<RectTransform>().localScale = Vector3.one * scale;
			component2.color = this.mapBgColor;
			return gameObject;
		}

		// Token: 0x06009308 RID: 37640 RVA: 0x001B5374 File Offset: 0x001B3774
		private IEnumerator _sedDungeonDataIter(IDungeonData data)
		{
			this._unloadCache();
			yield return Yielders.EndOfFrame;
			if (null != this.mBind && data != null)
			{
				GridLayoutGroup gridlayout = this.mBind.GetCom<GridLayoutGroup>("gridlayout");
				GameObject root = this.mBind.GetGameObject("root");
				gridlayout.constraintCount = data.GetWeidth();
				int all = data.GetWeidth() * data.GetHeight();
				int len = data.GetAreaConnectListLength();
				for (int i = 0; i < all - len; i++)
				{
					GameObject ob = new GameObject("emp");
					Utility.AttachTo(ob, root, false);
					Image image = ob.AddComponent<Image>();
					image.color = Color.clear;
					this.mCache.Add(ob);
					yield return Yielders.EndOfFrame;
				}
				List<IDungeonConnectData> list = new List<IDungeonConnectData>();
				for (int k = 0; k < len; k++)
				{
					list.Add(data.GetAreaConnectList(k));
				}
				list.Sort((IDungeonConnectData x, IDungeonConnectData y) => x.GetPositionY() * data.GetWeidth() + x.GetPositionX() - (y.GetPositionY() * data.GetWeidth() + y.GetPositionX()));
				yield return Yielders.EndOfFrame;
				for (int j = 0; j < list.Count; j++)
				{
					yield return Yielders.EndOfFrame;
					GameObject ob2 = new GameObject();
					Utility.AttachTo(ob2, root, false);
					this.mCache.Add(ob2);
					Image image2 = ob2.AddComponent<Image>();
					image2.color = this.mapBgColor;
					int idx = this._getIndex(list[j]);
					this.mBind.GetSprite(string.Format("{0}", idx), ref image2);
					ob2.name = string.Format("{0},{1}", list[j].GetPositionX(), list[j].GetPositionY());
					ob2.transform.SetSiblingIndex(list[j].GetPositionY() * data.GetWeidth() + list[j].GetPositionX() + 1);
					if (list[j].IsBoss())
					{
						this._createTag("boss", "boss", ob2, 0.5f);
					}
					else if (list[j].IsStart())
					{
						this._createTag("start", "start", ob2, 1f);
					}
				}
			}
			yield break;
		}

		// Token: 0x06009309 RID: 37641 RVA: 0x001B5396 File Offset: 0x001B3796
		public void SetDungeonData(IDungeonData data)
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this._sedDungeonDataIter(data));
		}

		// Token: 0x04004A08 RID: 18952
		public ComCommonBind mBind;

		// Token: 0x04004A09 RID: 18953
		public IDungeonData mData;

		// Token: 0x04004A0A RID: 18954
		private List<GameObject> mCache = new List<GameObject>();

		// Token: 0x04004A0B RID: 18955
		private Color mapBgColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 150);
	}
}
