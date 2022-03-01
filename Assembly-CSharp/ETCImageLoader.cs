using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000EC RID: 236
public class ETCImageLoader
{
	// Token: 0x060004E2 RID: 1250 RVA: 0x000217CC File Offset: 0x0001FBCC
	public static bool LoadSprite(ref Image image, string path, bool isMustExist = true)
	{
		image.material = null;
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path, typeof(Sprite), isMustExist, 0U);
		if (assetInst == null || null == assetInst.obj)
		{
			return false;
		}
		image.sprite = (assetInst.obj as Sprite);
		string texturePathFromSprite = ETCImageLoader.GetTexturePathFromSprite(path);
		string extension = Path.GetExtension(texturePathFromSprite);
		string path2 = string.Empty;
		if (extension == null || extension.Length <= 0)
		{
			path2 = texturePathFromSprite + "_Material.mat";
		}
		else
		{
			path2 = texturePathFromSprite.Replace(extension, "_Material.mat");
		}
		AssetInst assetInst2 = Singleton<AssetLoader>.instance.LoadRes(path2, typeof(Material), false, 0U);
		if (assetInst2 == null || null == assetInst2.obj)
		{
			image.canvasRenderer.SetAlphaTexture(null);
			return true;
		}
		image.material = (assetInst2.obj as Material);
		image.canvasRenderer.SetAlphaTexture(image.material.GetTexture("_AlphaTex"));
		return true;
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x000218DC File Offset: 0x0001FCDC
	public static bool HasSprite(string path)
	{
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path, typeof(Sprite), false, 0U);
		return assetInst != null && !(null == assetInst.obj);
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x0002191C File Offset: 0x0001FD1C
	public static Texture LoadAlphaFromSpritePath(string path, bool isMustExist = true)
	{
		string path2 = ETCImageLoader.GetBasePathFromSpritePath(path) + "_Alpha.png";
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path2, typeof(Texture), isMustExist, 0U);
		if (assetInst == null || null == assetInst.obj)
		{
			return null;
		}
		return assetInst.obj as Texture;
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x00021978 File Offset: 0x0001FD78
	public static Material LoadMaterialFromSpritePath(string path, bool isMustExist = true)
	{
		string path2 = ETCImageLoader.GetBasePathFromSpritePath(path) + "_Material.mat";
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path2, typeof(Material), isMustExist, 0U);
		if (assetInst == null || null == assetInst.obj)
		{
			return null;
		}
		return assetInst.obj as Material;
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x000219D4 File Offset: 0x0001FDD4
	public static string GetTexturePathFromSprite(string path)
	{
		int num = path.IndexOf(":");
		if (num < 0)
		{
			return path;
		}
		return path.Substring(0, num);
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00021A00 File Offset: 0x0001FE00
	public static string GetBasePathFromSpritePath(string path)
	{
		string texturePathFromSprite = ETCImageLoader.GetTexturePathFromSprite(path);
		int num = texturePathFromSprite.LastIndexOf(".");
		if (num < 0)
		{
			return texturePathFromSprite;
		}
		return texturePathFromSprite.Substring(0, num);
	}
}
