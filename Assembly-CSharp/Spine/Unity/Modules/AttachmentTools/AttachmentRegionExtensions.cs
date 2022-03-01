using System;
using UnityEngine;

namespace Spine.Unity.Modules.AttachmentTools
{
	// Token: 0x02004A04 RID: 18948
	public static class AttachmentRegionExtensions
	{
		// Token: 0x0601B574 RID: 111988 RVA: 0x0086C374 File Offset: 0x0086A774
		public static AtlasRegion GetRegion(this Attachment attachment)
		{
			IHasRendererObject hasRendererObject = attachment as IHasRendererObject;
			if (hasRendererObject != null)
			{
				return hasRendererObject.RendererObject as AtlasRegion;
			}
			return null;
		}

		// Token: 0x0601B575 RID: 111989 RVA: 0x0086C39B File Offset: 0x0086A79B
		public static AtlasRegion GetRegion(this RegionAttachment regionAttachment)
		{
			return regionAttachment.RendererObject as AtlasRegion;
		}

		// Token: 0x0601B576 RID: 111990 RVA: 0x0086C3A8 File Offset: 0x0086A7A8
		public static AtlasRegion GetRegion(this MeshAttachment meshAttachment)
		{
			return meshAttachment.RendererObject as AtlasRegion;
		}

		// Token: 0x0601B577 RID: 111991 RVA: 0x0086C3B8 File Offset: 0x0086A7B8
		public static void SetRegion(this Attachment attachment, AtlasRegion region, bool updateOffset = true)
		{
			RegionAttachment regionAttachment = attachment as RegionAttachment;
			if (regionAttachment != null)
			{
				regionAttachment.SetRegion(region, updateOffset);
			}
			MeshAttachment meshAttachment = attachment as MeshAttachment;
			if (meshAttachment != null)
			{
				meshAttachment.SetRegion(region, updateOffset);
			}
		}

		// Token: 0x0601B578 RID: 111992 RVA: 0x0086C3F0 File Offset: 0x0086A7F0
		public static void SetRegion(this RegionAttachment attachment, AtlasRegion region, bool updateOffset = true)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			attachment.RendererObject = region;
			attachment.SetUVs(region.u, region.v, region.u2, region.v2, region.rotate);
			attachment.regionOffsetX = region.offsetX;
			attachment.regionOffsetY = region.offsetY;
			attachment.regionWidth = (float)region.width;
			attachment.regionHeight = (float)region.height;
			attachment.regionOriginalWidth = (float)region.originalWidth;
			attachment.regionOriginalHeight = (float)region.originalHeight;
			if (updateOffset)
			{
				attachment.UpdateOffset();
			}
		}

		// Token: 0x0601B579 RID: 111993 RVA: 0x0086C494 File Offset: 0x0086A894
		public static void SetRegion(this MeshAttachment attachment, AtlasRegion region, bool updateUVs = true)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			attachment.RendererObject = region;
			attachment.RegionU = region.u;
			attachment.RegionV = region.v;
			attachment.RegionU2 = region.u2;
			attachment.RegionV2 = region.v2;
			attachment.RegionRotate = region.rotate;
			attachment.regionOffsetX = region.offsetX;
			attachment.regionOffsetY = region.offsetY;
			attachment.regionWidth = (float)region.width;
			attachment.regionHeight = (float)region.height;
			attachment.regionOriginalWidth = (float)region.originalWidth;
			attachment.regionOriginalHeight = (float)region.originalHeight;
			if (updateUVs)
			{
				attachment.UpdateUVs();
			}
		}

		// Token: 0x0601B57A RID: 111994 RVA: 0x0086C54D File Offset: 0x0086A94D
		public static RegionAttachment ToRegionAttachment(this Sprite sprite, Material material, float rotation = 0f)
		{
			return sprite.ToRegionAttachment(material.ToSpineAtlasPage(), rotation);
		}

		// Token: 0x0601B57B RID: 111995 RVA: 0x0086C55C File Offset: 0x0086A95C
		public static RegionAttachment ToRegionAttachment(this Sprite sprite, AtlasPage page, float rotation = 0f)
		{
			if (sprite == null)
			{
				throw new ArgumentNullException("sprite");
			}
			if (page == null)
			{
				throw new ArgumentNullException("page");
			}
			AtlasRegion region = sprite.ToAtlasRegion(page);
			float scale = 1f / sprite.pixelsPerUnit;
			return region.ToRegionAttachment(sprite.name, scale, rotation);
		}

		// Token: 0x0601B57C RID: 111996 RVA: 0x0086C5B4 File Offset: 0x0086A9B4
		public static RegionAttachment ToRegionAttachmentPMAClone(this Sprite sprite, Shader shader, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null, float rotation = 0f)
		{
			if (sprite == null)
			{
				throw new ArgumentNullException("sprite");
			}
			if (shader == null)
			{
				throw new ArgumentNullException("shader");
			}
			AtlasRegion region = sprite.ToAtlasRegionPMAClone(shader, textureFormat, mipmaps, materialPropertySource);
			float scale = 1f / sprite.pixelsPerUnit;
			return region.ToRegionAttachment(sprite.name, scale, rotation);
		}

		// Token: 0x0601B57D RID: 111997 RVA: 0x0086C617 File Offset: 0x0086AA17
		public static RegionAttachment ToRegionAttachmentPMAClone(this Sprite sprite, Material materialPropertySource, TextureFormat textureFormat = 4, bool mipmaps = false, float rotation = 0f)
		{
			return sprite.ToRegionAttachmentPMAClone(materialPropertySource.shader, textureFormat, mipmaps, materialPropertySource, rotation);
		}

		// Token: 0x0601B57E RID: 111998 RVA: 0x0086C62C File Offset: 0x0086AA2C
		public static RegionAttachment ToRegionAttachment(this AtlasRegion region, string attachmentName, float scale = 0.01f, float rotation = 0f)
		{
			if (string.IsNullOrEmpty(attachmentName))
			{
				throw new ArgumentException("attachmentName can't be null or empty.", "attachmentName");
			}
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			RegionAttachment regionAttachment = new RegionAttachment(attachmentName);
			regionAttachment.RendererObject = region;
			regionAttachment.SetUVs(region.u, region.v, region.u2, region.v2, region.rotate);
			regionAttachment.regionOffsetX = region.offsetX;
			regionAttachment.regionOffsetY = region.offsetY;
			regionAttachment.regionWidth = (float)region.width;
			regionAttachment.regionHeight = (float)region.height;
			regionAttachment.regionOriginalWidth = (float)region.originalWidth;
			regionAttachment.regionOriginalHeight = (float)region.originalHeight;
			regionAttachment.Path = region.name;
			regionAttachment.scaleX = 1f;
			regionAttachment.scaleY = 1f;
			regionAttachment.rotation = rotation;
			regionAttachment.r = 1f;
			regionAttachment.g = 1f;
			regionAttachment.b = 1f;
			regionAttachment.a = 1f;
			regionAttachment.width = regionAttachment.regionOriginalWidth * scale;
			regionAttachment.height = regionAttachment.regionOriginalHeight * scale;
			regionAttachment.SetColor(Color.white);
			regionAttachment.UpdateOffset();
			return regionAttachment;
		}

		// Token: 0x0601B57F RID: 111999 RVA: 0x0086C766 File Offset: 0x0086AB66
		public static void SetScale(this RegionAttachment regionAttachment, Vector2 scale)
		{
			regionAttachment.scaleX = scale.x;
			regionAttachment.scaleY = scale.y;
		}

		// Token: 0x0601B580 RID: 112000 RVA: 0x0086C782 File Offset: 0x0086AB82
		public static void SetScale(this RegionAttachment regionAttachment, float x, float y)
		{
			regionAttachment.scaleX = x;
			regionAttachment.scaleY = y;
		}

		// Token: 0x0601B581 RID: 112001 RVA: 0x0086C792 File Offset: 0x0086AB92
		public static void SetPositionOffset(this RegionAttachment regionAttachment, Vector2 offset)
		{
			regionAttachment.x = offset.x;
			regionAttachment.y = offset.y;
		}

		// Token: 0x0601B582 RID: 112002 RVA: 0x0086C7AE File Offset: 0x0086ABAE
		public static void SetPositionOffset(this RegionAttachment regionAttachment, float x, float y)
		{
			regionAttachment.x = x;
			regionAttachment.y = y;
		}

		// Token: 0x0601B583 RID: 112003 RVA: 0x0086C7BE File Offset: 0x0086ABBE
		public static void SetRotation(this RegionAttachment regionAttachment, float rotation)
		{
			regionAttachment.rotation = rotation;
		}
	}
}
