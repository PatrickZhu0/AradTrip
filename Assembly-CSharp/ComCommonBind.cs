using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000DA9 RID: 3497
public class ComCommonBind : MonoBehaviour
{
	// Token: 0x06008DAC RID: 36268 RVA: 0x001A59FC File Offset: 0x001A3DFC
	public static ComCommonBind LoadBind(string path)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		if (null != gameObject)
		{
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (null != component)
			{
				return component;
			}
		}
		return null;
	}

	// Token: 0x06008DAD RID: 36269 RVA: 0x001A5A3C File Offset: 0x001A3E3C
	public ComCommonBind LoadExtraBind(string path)
	{
		ComCommonBind comCommonBind = ComCommonBind.LoadBind(path);
		if (null != comCommonBind)
		{
			if (!this.mAllCacheBinds.ContainsKey(path))
			{
				this.mAllCacheBinds.Add(path, new List<ComCommonBind>());
			}
			this.mAllCacheBinds[path].Add(comCommonBind);
		}
		return comCommonBind;
	}

	// Token: 0x06008DAE RID: 36270 RVA: 0x001A5A94 File Offset: 0x001A3E94
	public ComCommonBind GetExistBind(string path, int idx)
	{
		if (this.mAllCacheBinds.ContainsKey(path) && idx > 0 && idx < this.mAllCacheBinds[path].Count)
		{
			return this.mAllCacheBinds[path][idx];
		}
		return null;
	}

	// Token: 0x06008DAF RID: 36271 RVA: 0x001A5AE4 File Offset: 0x001A3EE4
	public void ClearAllCacheBinds()
	{
		foreach (KeyValuePair<string, List<ComCommonBind>> keyValuePair in this.mAllCacheBinds)
		{
			this.ClearCacheBinds(keyValuePair.Key);
		}
		this.mAllCacheBinds.Clear();
	}

	// Token: 0x06008DB0 RID: 36272 RVA: 0x001A5B30 File Offset: 0x001A3F30
	public void OnDestroy()
	{
		this.ClearAllCacheBinds();
		Array.Clear(this.reses, 0, this.reses.Length);
		Array.Clear(this.units, 0, this.units.Length);
		Array.Clear(this.prefabs, 0, this.prefabs.Length);
		this.reses = null;
		this.units = null;
		this.prefabs = null;
		this.mAllCacheBinds = null;
	}

	// Token: 0x06008DB1 RID: 36273 RVA: 0x001A5B9C File Offset: 0x001A3F9C
	private void _clearAllCallback(Component com)
	{
		if (com is Button)
		{
			Button button = com as Button;
			if (null != button)
			{
				button.onClick.RemoveAllListeners();
			}
		}
		else if (com is Toggle)
		{
			Toggle toggle = com as Toggle;
			if (null != toggle)
			{
				toggle.onValueChanged.RemoveAllListeners();
			}
		}
		else if (com is Dropdown)
		{
			Dropdown dropdown = com as Dropdown;
			if (null != dropdown)
			{
				dropdown.onValueChanged.RemoveAllListeners();
			}
		}
	}

	// Token: 0x06008DB2 RID: 36274 RVA: 0x001A5C30 File Offset: 0x001A4030
	public void ClearCacheBinds(string path)
	{
		if (this.mAllCacheBinds.ContainsKey(path))
		{
			List<ComCommonBind> list = this.mAllCacheBinds[path];
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list[i].units.Length; j++)
				{
					this._clearAllCallback(list[i].units[j].com);
				}
				list[i].ClearAllCacheBinds();
				Object.Destroy(list[i].gameObject);
				list[i] = null;
			}
			list.Clear();
		}
	}

	// Token: 0x06008DB3 RID: 36275 RVA: 0x001A5CDC File Offset: 0x001A40DC
	public void GetSprite(string name, ref Image image)
	{
		if (image == null)
		{
			return;
		}
		for (int i = 0; i < this.reses.Length; i++)
		{
			if (this.reses[i].tag.Equals(name))
			{
				image.sprite = this.reses[i].sprite;
				image.material = this.reses[i].material;
			}
		}
	}

	// Token: 0x06008DB4 RID: 36276 RVA: 0x001A5D5C File Offset: 0x001A415C
	public string GetPrefabPath(string name)
	{
		for (int i = 0; i < this.prefabs.Length; i++)
		{
			if (this.prefabs[i].tag.Equals(name))
			{
				return this.prefabs[i].path;
			}
		}
		return null;
	}

	// Token: 0x06008DB5 RID: 36277 RVA: 0x001A5DB4 File Offset: 0x001A41B4
	public GameObject GetPrefabInstance(string name)
	{
		string prefabPath = this.GetPrefabPath(name);
		return Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabPath, true, 0U);
	}

	// Token: 0x06008DB6 RID: 36278 RVA: 0x001A5DD8 File Offset: 0x001A41D8
	public GameObject GetGameObject(string name)
	{
		for (int i = 0; i < this.units.Length; i++)
		{
			if (this.units[i].tag.Equals(name) && null != this.units[i].com)
			{
				return this.units[i].com.gameObject;
			}
		}
		return null;
	}

	// Token: 0x06008DB7 RID: 36279 RVA: 0x001A5E50 File Offset: 0x001A4250
	public Component GetCom(Type type, string name)
	{
		for (int i = 0; i < this.units.Length; i++)
		{
			if (this.units[i].com.GetType() == type && this.units[i].tag.Equals(name))
			{
				return this.units[i].com;
			}
		}
		return null;
	}

	// Token: 0x06008DB8 RID: 36280 RVA: 0x001A5EC4 File Offset: 0x001A42C4
	public T GetCom<T>(string name) where T : Component
	{
		for (int i = 0; i < this.units.Length; i++)
		{
			if (this.units[i].com is T && this.units[i].tag.Equals(name))
			{
				return this.units[i].com as T;
			}
		}
		return (T)((object)null);
	}

	// Token: 0x0400464C RID: 17996
	public ComCommonBind.AttachResource[] reses = new ComCommonBind.AttachResource[0];

	// Token: 0x0400464D RID: 17997
	public ComCommonBind.BindUnit[] units = new ComCommonBind.BindUnit[0];

	// Token: 0x0400464E RID: 17998
	public ComCommonBind.AttachPrefabPath[] prefabs = new ComCommonBind.AttachPrefabPath[0];

	// Token: 0x0400464F RID: 17999
	private Dictionary<string, List<ComCommonBind>> mAllCacheBinds = new Dictionary<string, List<ComCommonBind>>();

	// Token: 0x02000DAA RID: 3498
	public enum eBindUnitType
	{
		// Token: 0x04004651 RID: 18001
		Component,
		// Token: 0x04004652 RID: 18002
		GameObject
	}

	// Token: 0x02000DAB RID: 3499
	[Serializable]
	public struct BindUnit
	{
		// Token: 0x04004653 RID: 18003
		public string tag;

		// Token: 0x04004654 RID: 18004
		public Component com;

		// Token: 0x04004655 RID: 18005
		public ComCommonBind.eBindUnitType type;
	}

	// Token: 0x02000DAC RID: 3500
	[Serializable]
	public struct AttachPrefabPath
	{
		// Token: 0x04004656 RID: 18006
		public string tag;

		// Token: 0x04004657 RID: 18007
		public string path;
	}

	// Token: 0x02000DAD RID: 3501
	[Serializable]
	public struct AttachResource
	{
		// Token: 0x04004658 RID: 18008
		public string tag;

		// Token: 0x04004659 RID: 18009
		public Sprite sprite;

		// Token: 0x0400465A RID: 18010
		public Material material;
	}
}
