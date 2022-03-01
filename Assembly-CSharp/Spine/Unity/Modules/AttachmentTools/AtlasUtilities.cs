using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules.AttachmentTools
{
	// Token: 0x02004A05 RID: 18949
	public static class AtlasUtilities
	{
		// Token: 0x0601B584 RID: 112004 RVA: 0x0086C7C7 File Offset: 0x0086ABC7
		public static AtlasRegion ToAtlasRegion(this Texture2D t, Material materialPropertySource, float scale = 0.01f)
		{
			return t.ToAtlasRegion(materialPropertySource.shader, scale, materialPropertySource);
		}

		// Token: 0x0601B585 RID: 112005 RVA: 0x0086C7D8 File Offset: 0x0086ABD8
		public static AtlasRegion ToAtlasRegion(this Texture2D t, Shader shader, float scale = 0.01f, Material materialPropertySource = null)
		{
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				material.shaderKeywords = materialPropertySource.shaderKeywords;
			}
			material.mainTexture = t;
			AtlasPage page = material.ToSpineAtlasPage();
			float num = (float)t.width;
			float num2 = (float)t.height;
			AtlasRegion atlasRegion = new AtlasRegion();
			atlasRegion.name = t.name;
			atlasRegion.index = -1;
			atlasRegion.rotate = false;
			Vector2 zero = Vector2.zero;
			Vector2 vector = new Vector2(num, num2) * scale;
			atlasRegion.width = (int)num;
			atlasRegion.originalWidth = (int)num;
			atlasRegion.height = (int)num2;
			atlasRegion.originalHeight = (int)num2;
			atlasRegion.offsetX = num * (0.5f - AtlasUtilities.InverseLerp(zero.x, vector.x, 0f));
			atlasRegion.offsetY = num2 * (0.5f - AtlasUtilities.InverseLerp(zero.y, vector.y, 0f));
			atlasRegion.u = 0f;
			atlasRegion.v = 1f;
			atlasRegion.u2 = 1f;
			atlasRegion.v2 = 0f;
			atlasRegion.x = 0;
			atlasRegion.y = 0;
			atlasRegion.page = page;
			return atlasRegion;
		}

		// Token: 0x0601B586 RID: 112006 RVA: 0x0086C91F File Offset: 0x0086AD1F
		public static AtlasRegion ToAtlasRegionPMAClone(this Texture2D t, Material materialPropertySource, TextureFormat textureFormat = 4, bool mipmaps = false)
		{
			return t.ToAtlasRegionPMAClone(materialPropertySource.shader, textureFormat, mipmaps, materialPropertySource);
		}

		// Token: 0x0601B587 RID: 112007 RVA: 0x0086C930 File Offset: 0x0086AD30
		public static AtlasRegion ToAtlasRegionPMAClone(this Texture2D t, Shader shader, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null)
		{
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				material.shaderKeywords = materialPropertySource.shaderKeywords;
			}
			Texture2D clone = t.GetClone(false, textureFormat, mipmaps);
			clone.ApplyPMA(true);
			clone.name = t.name + "-pma-";
			material.name = t.name + shader.name;
			material.mainTexture = clone;
			AtlasPage page = material.ToSpineAtlasPage();
			AtlasRegion atlasRegion = clone.ToAtlasRegion(shader, 0.01f, null);
			atlasRegion.page = page;
			return atlasRegion;
		}

		// Token: 0x0601B588 RID: 112008 RVA: 0x0086C9C8 File Offset: 0x0086ADC8
		public static AtlasPage ToSpineAtlasPage(this Material m)
		{
			AtlasPage atlasPage = new AtlasPage
			{
				rendererObject = m,
				name = m.name
			};
			Texture mainTexture = m.mainTexture;
			if (mainTexture != null)
			{
				atlasPage.width = mainTexture.width;
				atlasPage.height = mainTexture.height;
			}
			return atlasPage;
		}

		// Token: 0x0601B589 RID: 112009 RVA: 0x0086CA1C File Offset: 0x0086AE1C
		public static AtlasRegion ToAtlasRegion(this Sprite s, AtlasPage page)
		{
			if (page == null)
			{
				throw new ArgumentNullException("page", "page cannot be null. AtlasPage determines which texture region belongs and how it should be rendered. You can use material.ToSpineAtlasPage() to get a shareable AtlasPage from a Material, or use the sprite.ToAtlasRegion(material) overload.");
			}
			AtlasRegion atlasRegion = s.ToAtlasRegion(false);
			atlasRegion.page = page;
			return atlasRegion;
		}

		// Token: 0x0601B58A RID: 112010 RVA: 0x0086CA50 File Offset: 0x0086AE50
		public static AtlasRegion ToAtlasRegion(this Sprite s, Material material)
		{
			AtlasRegion atlasRegion = s.ToAtlasRegion(false);
			atlasRegion.page = material.ToSpineAtlasPage();
			return atlasRegion;
		}

		// Token: 0x0601B58B RID: 112011 RVA: 0x0086CA74 File Offset: 0x0086AE74
		public static AtlasRegion ToAtlasRegionPMAClone(this Sprite s, Shader shader, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null)
		{
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				material.shaderKeywords = materialPropertySource.shaderKeywords;
			}
			Texture2D texture2D = s.ToTexture(false, textureFormat, mipmaps);
			texture2D.ApplyPMA(true);
			texture2D.name = s.name + "-pma-";
			material.name = texture2D.name + shader.name;
			material.mainTexture = texture2D;
			AtlasPage page = material.ToSpineAtlasPage();
			AtlasRegion atlasRegion = s.ToAtlasRegion(true);
			atlasRegion.page = page;
			return atlasRegion;
		}

		// Token: 0x0601B58C RID: 112012 RVA: 0x0086CB06 File Offset: 0x0086AF06
		public static AtlasRegion ToAtlasRegionPMAClone(this Sprite s, Material materialPropertySource, TextureFormat textureFormat = 4, bool mipmaps = false)
		{
			return s.ToAtlasRegionPMAClone(materialPropertySource.shader, textureFormat, mipmaps, materialPropertySource);
		}

		// Token: 0x0601B58D RID: 112013 RVA: 0x0086CB18 File Offset: 0x0086AF18
		internal static AtlasRegion ToAtlasRegion(this Sprite s, bool isolatedTexture = false)
		{
			AtlasRegion atlasRegion = new AtlasRegion();
			atlasRegion.name = s.name;
			atlasRegion.index = -1;
			atlasRegion.rotate = (s.packed && s.packingRotation != 0);
			Bounds bounds = s.bounds;
			Vector2 vector = bounds.min;
			Vector2 vector2 = bounds.max;
			Rect rect = s.rect.SpineUnityFlipRect(s.texture.height);
			atlasRegion.width = (int)rect.width;
			atlasRegion.originalWidth = (int)rect.width;
			atlasRegion.height = (int)rect.height;
			atlasRegion.originalHeight = (int)rect.height;
			atlasRegion.offsetX = rect.width * (0.5f - AtlasUtilities.InverseLerp(vector.x, vector2.x, 0f));
			atlasRegion.offsetY = rect.height * (0.5f - AtlasUtilities.InverseLerp(vector.y, vector2.y, 0f));
			if (isolatedTexture)
			{
				atlasRegion.u = 0f;
				atlasRegion.v = 1f;
				atlasRegion.u2 = 1f;
				atlasRegion.v2 = 0f;
				atlasRegion.x = 0;
				atlasRegion.y = 0;
			}
			else
			{
				Texture2D texture = s.texture;
				Rect rect2 = AtlasUtilities.TextureRectToUVRect(s.textureRect, texture.width, texture.height);
				atlasRegion.u = rect2.xMin;
				atlasRegion.v = rect2.yMax;
				atlasRegion.u2 = rect2.xMax;
				atlasRegion.v2 = rect2.yMin;
				atlasRegion.x = (int)rect.x;
				atlasRegion.y = (int)rect.y;
			}
			return atlasRegion;
		}

		// Token: 0x0601B58E RID: 112014 RVA: 0x0086CCE0 File Offset: 0x0086B0E0
		public static void GetRepackedAttachments(List<Attachment> sourceAttachments, List<Attachment> outputAttachments, Material materialPropertySource, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = 4, bool mipmaps = false, string newAssetName = "Repacked Attachments", bool clearCache = false, bool useOriginalNonrenderables = true)
		{
			if (sourceAttachments == null)
			{
				throw new ArgumentNullException("sourceAttachments");
			}
			if (outputAttachments == null)
			{
				throw new ArgumentNullException("outputAttachments");
			}
			Dictionary<AtlasRegion, int> dictionary = new Dictionary<AtlasRegion, int>();
			List<int> list = new List<int>();
			List<Texture2D> list2 = new List<Texture2D>();
			List<AtlasRegion> list3 = new List<AtlasRegion>();
			outputAttachments.Clear();
			outputAttachments.AddRange(sourceAttachments);
			int num = 0;
			int i = 0;
			int count = sourceAttachments.Count;
			while (i < count)
			{
				Attachment attachment = sourceAttachments[i];
				if (AtlasUtilities.IsRenderable(attachment))
				{
					Attachment clone = attachment.GetClone(true);
					AtlasRegion region = clone.GetRegion();
					int item;
					if (dictionary.TryGetValue(region, out item))
					{
						list.Add(item);
					}
					else
					{
						list3.Add(region);
						list2.Add(region.ToTexture(true, 4, false));
						dictionary.Add(region, num);
						list.Add(num);
						num++;
					}
					outputAttachments[i] = clone;
				}
				else
				{
					outputAttachments[i] = ((!useOriginalNonrenderables) ? attachment.GetClone(true) : attachment);
					list.Add(-1);
				}
				i++;
			}
			Texture2D texture2D = new Texture2D(maxAtlasSize, maxAtlasSize, textureFormat, mipmaps);
			texture2D.mipMapBias = -0.5f;
			texture2D.anisoLevel = list2[0].anisoLevel;
			texture2D.name = newAssetName;
			Rect[] array = texture2D.PackTextures(list2.ToArray(), padding, maxAtlasSize);
			Shader shader = (!(materialPropertySource == null)) ? materialPropertySource.shader : Shader.Find("Spine/Skeleton");
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				material.shaderKeywords = materialPropertySource.shaderKeywords;
			}
			material.name = newAssetName;
			material.mainTexture = texture2D;
			AtlasPage atlasPage = material.ToSpineAtlasPage();
			atlasPage.name = newAssetName;
			List<AtlasRegion> list4 = new List<AtlasRegion>();
			int j = 0;
			int count2 = list3.Count;
			while (j < count2)
			{
				AtlasRegion atlasRegion = list3[j];
				AtlasRegion item2 = AtlasUtilities.UVRectToAtlasRegion(array[j], atlasRegion.name, atlasPage, atlasRegion.offsetX, atlasRegion.offsetY, atlasRegion.rotate);
				list4.Add(item2);
				j++;
			}
			int k = 0;
			int count3 = outputAttachments.Count;
			while (k < count3)
			{
				Attachment attachment2 = outputAttachments[k];
				if (AtlasUtilities.IsRenderable(attachment2))
				{
					attachment2.SetRegion(list4[list[k]], true);
				}
				k++;
			}
			if (clearCache)
			{
				AtlasUtilities.ClearCache();
			}
			outputTexture = texture2D;
			outputMaterial = material;
		}

		// Token: 0x0601B58F RID: 112015 RVA: 0x0086CF88 File Offset: 0x0086B388
		public static Skin GetRepackedSkin(this Skin o, string newName, Material materialPropertySource, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = 4, bool mipmaps = false, bool useOriginalNonrenderables = true)
		{
			return o.GetRepackedSkin(newName, materialPropertySource.shader, out outputMaterial, out outputTexture, maxAtlasSize, padding, textureFormat, mipmaps, materialPropertySource, useOriginalNonrenderables, true);
		}

		// Token: 0x0601B590 RID: 112016 RVA: 0x0086CFB4 File Offset: 0x0086B3B4
		public static Skin GetRepackedSkin(this Skin o, string newName, Shader shader, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null, bool clearCache = false, bool useOriginalNonrenderables = true)
		{
			if (o == null)
			{
				throw new NullReferenceException("Skin was null");
			}
			Dictionary<Skin.AttachmentKeyTuple, Attachment> attachments = o.Attachments;
			Skin skin = new Skin(newName);
			Dictionary<AtlasRegion, int> dictionary = new Dictionary<AtlasRegion, int>();
			List<int> list = new List<int>();
			List<Attachment> list2 = new List<Attachment>();
			List<Texture2D> list3 = new List<Texture2D>();
			List<AtlasRegion> list4 = new List<AtlasRegion>();
			int num = 0;
			foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair in attachments)
			{
				Skin.AttachmentKeyTuple key = keyValuePair.Key;
				Attachment value = keyValuePair.Value;
				if (AtlasUtilities.IsRenderable(value))
				{
					Attachment clone = value.GetClone(true);
					AtlasRegion region = clone.GetRegion();
					int item;
					if (dictionary.TryGetValue(region, out item))
					{
						list.Add(item);
					}
					else
					{
						list4.Add(region);
						list3.Add(region.ToTexture(true, 4, false));
						dictionary.Add(region, num);
						list.Add(num);
						num++;
					}
					list2.Add(clone);
					skin.AddAttachment(key.slotIndex, key.name, clone);
				}
				else
				{
					skin.AddAttachment(key.slotIndex, key.name, (!useOriginalNonrenderables) ? value.GetClone(true) : value);
				}
			}
			Texture2D texture2D = new Texture2D(maxAtlasSize, maxAtlasSize, textureFormat, mipmaps);
			texture2D.mipMapBias = -0.5f;
			texture2D.anisoLevel = list3[0].anisoLevel;
			texture2D.name = newName;
			Rect[] array = texture2D.PackTextures(list3.ToArray(), padding, maxAtlasSize);
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				material.shaderKeywords = materialPropertySource.shaderKeywords;
			}
			material.name = newName;
			material.mainTexture = texture2D;
			AtlasPage atlasPage = material.ToSpineAtlasPage();
			atlasPage.name = newName;
			List<AtlasRegion> list5 = new List<AtlasRegion>();
			int i = 0;
			int count = list4.Count;
			while (i < count)
			{
				AtlasRegion atlasRegion = list4[i];
				AtlasRegion item2 = AtlasUtilities.UVRectToAtlasRegion(array[i], atlasRegion.name, atlasPage, atlasRegion.offsetX, atlasRegion.offsetY, atlasRegion.rotate);
				list5.Add(item2);
				i++;
			}
			int j = 0;
			int count2 = list2.Count;
			while (j < count2)
			{
				Attachment attachment = list2[j];
				if (AtlasUtilities.IsRenderable(attachment))
				{
					attachment.SetRegion(list5[list[j]], true);
				}
				j++;
			}
			if (clearCache)
			{
				AtlasUtilities.ClearCache();
			}
			outputTexture = texture2D;
			outputMaterial = material;
			return skin;
		}

		// Token: 0x0601B591 RID: 112017 RVA: 0x0086D284 File Offset: 0x0086B684
		public static Sprite ToSprite(this AtlasRegion ar, float pixelsPerUnit = 100f)
		{
			return Sprite.Create(ar.GetMainTexture(), ar.GetUnityRect(), new Vector2(0.5f, 0.5f), pixelsPerUnit);
		}

		// Token: 0x0601B592 RID: 112018 RVA: 0x0086D2A8 File Offset: 0x0086B6A8
		public static void ClearCache()
		{
			foreach (Texture2D texture2D in AtlasUtilities.CachedRegionTexturesList)
			{
				Object.Destroy(texture2D);
			}
			AtlasUtilities.CachedRegionTextures.Clear();
			AtlasUtilities.CachedRegionTexturesList.Clear();
		}

		// Token: 0x0601B593 RID: 112019 RVA: 0x0086D318 File Offset: 0x0086B718
		public static Texture2D ToTexture(this AtlasRegion ar, bool applyImmediately = true, TextureFormat textureFormat = 4, bool mipmaps = false)
		{
			Texture2D texture2D;
			AtlasUtilities.CachedRegionTextures.TryGetValue(ar, out texture2D);
			if (texture2D == null)
			{
				Texture2D mainTexture = ar.GetMainTexture();
				Rect unityRect = ar.GetUnityRect(mainTexture.height);
				int num = (int)unityRect.width;
				int num2 = (int)unityRect.height;
				texture2D = new Texture2D(num, num2, textureFormat, mipmaps);
				texture2D.name = ar.name;
				Color[] pixels = mainTexture.GetPixels((int)unityRect.x, (int)unityRect.y, num, num2);
				texture2D.SetPixels(pixels);
				AtlasUtilities.CachedRegionTextures.Add(ar, texture2D);
				AtlasUtilities.CachedRegionTexturesList.Add(texture2D);
				if (applyImmediately)
				{
					texture2D.Apply();
				}
			}
			return texture2D;
		}

		// Token: 0x0601B594 RID: 112020 RVA: 0x0086D3C4 File Offset: 0x0086B7C4
		private static Texture2D ToTexture(this Sprite s, bool applyImmediately = true, TextureFormat textureFormat = 4, bool mipmaps = false)
		{
			Texture2D texture = s.texture;
			Rect textureRect = s.textureRect;
			Color[] pixels = texture.GetPixels((int)textureRect.x, (int)textureRect.y, (int)textureRect.width, (int)textureRect.height);
			Texture2D texture2D = new Texture2D((int)textureRect.width, (int)textureRect.height, textureFormat, mipmaps);
			texture2D.SetPixels(pixels);
			if (applyImmediately)
			{
				texture2D.Apply();
			}
			return texture2D;
		}

		// Token: 0x0601B595 RID: 112021 RVA: 0x0086D434 File Offset: 0x0086B834
		private static Texture2D GetClone(this Texture2D t, bool applyImmediately = true, TextureFormat textureFormat = 4, bool mipmaps = false)
		{
			Color[] pixels = t.GetPixels(0, 0, t.width, t.height);
			Texture2D texture2D = new Texture2D(t.width, t.height, textureFormat, mipmaps);
			texture2D.SetPixels(pixels);
			if (applyImmediately)
			{
				texture2D.Apply();
			}
			return texture2D;
		}

		// Token: 0x0601B596 RID: 112022 RVA: 0x0086D47E File Offset: 0x0086B87E
		private static bool IsRenderable(Attachment a)
		{
			return a is IHasRendererObject;
		}

		// Token: 0x0601B597 RID: 112023 RVA: 0x0086D489 File Offset: 0x0086B889
		private static Rect SpineUnityFlipRect(this Rect rect, int textureHeight)
		{
			rect.y = (float)textureHeight - rect.y - rect.height;
			return rect;
		}

		// Token: 0x0601B598 RID: 112024 RVA: 0x0086D4A5 File Offset: 0x0086B8A5
		private static Rect GetUnityRect(this AtlasRegion region)
		{
			return region.GetSpineAtlasRect(true).SpineUnityFlipRect(region.page.height);
		}

		// Token: 0x0601B599 RID: 112025 RVA: 0x0086D4BE File Offset: 0x0086B8BE
		private static Rect GetUnityRect(this AtlasRegion region, int textureHeight)
		{
			return region.GetSpineAtlasRect(true).SpineUnityFlipRect(textureHeight);
		}

		// Token: 0x0601B59A RID: 112026 RVA: 0x0086D4D0 File Offset: 0x0086B8D0
		private static Rect GetSpineAtlasRect(this AtlasRegion region, bool includeRotate = true)
		{
			if (includeRotate && region.rotate)
			{
				return new Rect((float)region.x, (float)region.y, (float)region.height, (float)region.width);
			}
			return new Rect((float)region.x, (float)region.y, (float)region.width, (float)region.height);
		}

		// Token: 0x0601B59B RID: 112027 RVA: 0x0086D534 File Offset: 0x0086B934
		private static Rect UVRectToTextureRect(Rect uvRect, int texWidth, int texHeight)
		{
			uvRect.x *= (float)texWidth;
			uvRect.width *= (float)texWidth;
			uvRect.y *= (float)texHeight;
			uvRect.height *= (float)texHeight;
			return uvRect;
		}

		// Token: 0x0601B59C RID: 112028 RVA: 0x0086D584 File Offset: 0x0086B984
		private static Rect TextureRectToUVRect(Rect textureRect, int texWidth, int texHeight)
		{
			textureRect.x = Mathf.InverseLerp(0f, (float)texWidth, textureRect.x);
			textureRect.y = Mathf.InverseLerp(0f, (float)texHeight, textureRect.y);
			textureRect.width = Mathf.InverseLerp(0f, (float)texWidth, textureRect.width);
			textureRect.height = Mathf.InverseLerp(0f, (float)texHeight, textureRect.height);
			return textureRect;
		}

		// Token: 0x0601B59D RID: 112029 RVA: 0x0086D5FC File Offset: 0x0086B9FC
		private static AtlasRegion UVRectToAtlasRegion(Rect uvRect, string name, AtlasPage page, float offsetX, float offsetY, bool rotate)
		{
			Rect rect = AtlasUtilities.UVRectToTextureRect(uvRect, page.width, page.height);
			Rect rect2 = rect.SpineUnityFlipRect(page.height);
			int x = (int)rect2.x;
			int y = (int)rect2.y;
			int num;
			int num2;
			if (rotate)
			{
				num = (int)rect2.height;
				num2 = (int)rect2.width;
			}
			else
			{
				num = (int)rect2.width;
				num2 = (int)rect2.height;
			}
			return new AtlasRegion
			{
				page = page,
				name = name,
				u = uvRect.xMin,
				u2 = uvRect.xMax,
				v = uvRect.yMax,
				v2 = uvRect.yMin,
				index = -1,
				width = num,
				originalWidth = num,
				height = num2,
				originalHeight = num2,
				offsetX = offsetX,
				offsetY = offsetY,
				x = x,
				y = y,
				rotate = rotate
			};
		}

		// Token: 0x0601B59E RID: 112030 RVA: 0x0086D718 File Offset: 0x0086BB18
		private static Texture2D GetMainTexture(this AtlasRegion region)
		{
			Material material = region.page.rendererObject as Material;
			return material.mainTexture as Texture2D;
		}

		// Token: 0x0601B59F RID: 112031 RVA: 0x0086D744 File Offset: 0x0086BB44
		private static void ApplyPMA(this Texture2D texture, bool applyImmediately = true)
		{
			Color[] pixels = texture.GetPixels();
			int i = 0;
			int num = pixels.Length;
			while (i < num)
			{
				Color color = pixels[i];
				float a = color.a;
				color.r *= a;
				color.g *= a;
				color.b *= a;
				pixels[i] = color;
				i++;
			}
			texture.SetPixels(pixels);
			if (applyImmediately)
			{
				texture.Apply();
			}
		}

		// Token: 0x0601B5A0 RID: 112032 RVA: 0x0086D7D7 File Offset: 0x0086BBD7
		private static float InverseLerp(float a, float b, float value)
		{
			return (value - a) / (b - a);
		}

		// Token: 0x040130AE RID: 77998
		internal const TextureFormat SpineTextureFormat = 4;

		// Token: 0x040130AF RID: 77999
		internal const float DefaultMipmapBias = -0.5f;

		// Token: 0x040130B0 RID: 78000
		internal const bool UseMipMaps = false;

		// Token: 0x040130B1 RID: 78001
		internal const float DefaultScale = 0.01f;

		// Token: 0x040130B2 RID: 78002
		private const int NonrenderingRegion = -1;

		// Token: 0x040130B3 RID: 78003
		private static Dictionary<AtlasRegion, Texture2D> CachedRegionTextures = new Dictionary<AtlasRegion, Texture2D>();

		// Token: 0x040130B4 RID: 78004
		private static List<Texture2D> CachedRegionTexturesList = new List<Texture2D>();
	}
}
