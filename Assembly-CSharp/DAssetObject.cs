using System;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x020000E5 RID: 229
[Serializable]
public struct DAssetObject
{
	// Token: 0x060004D8 RID: 1240 RVA: 0x00021635 File Offset: 0x0001FA35
	public DAssetObject(Object go, string path)
	{
		this.m_AssetObj = go;
		this.m_AssetPath = path;
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x00021645 File Offset: 0x0001FA45
	public DAssetObject(string path, bool loadObject = false)
	{
		path = DAssetObject.GetValidFilePath(path);
		if (loadObject)
		{
			this.m_AssetObj = (Singleton<AssetLoader>.instance.LoadRes(path, true, 0U).obj as GameObject);
		}
		else
		{
			this.m_AssetObj = null;
		}
		this.m_AssetPath = path;
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x00021688 File Offset: 0x0001FA88
	public static string GetValidFilePath(string path)
	{
		path = Path.ChangeExtension(path, null);
		StringBuilder stringBuilder = new StringBuilder(path);
		stringBuilder = stringBuilder.Replace("Assets/Resources/", string.Empty);
		return stringBuilder.ToString();
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x000216BC File Offset: 0x0001FABC
	public void Set(string path)
	{
		path = DAssetObject.GetValidFilePath(path);
		this.m_AssetObj = (Singleton<AssetLoader>.instance.LoadRes(path, true, 0U).obj as GameObject);
		this.m_AssetPath = path;
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x000216EA File Offset: 0x0001FAEA
	public bool IsValid()
	{
		return this.m_AssetPath != null && this.m_AssetPath.Length > 1;
	}

	// Token: 0x04000460 RID: 1120
	public Object m_AssetObj;

	// Token: 0x04000461 RID: 1121
	public string m_AssetPath;
}
