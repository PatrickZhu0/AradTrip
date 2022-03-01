using System;

namespace Spine
{
	// Token: 0x020049AE RID: 18862
	public class AtlasAttachmentLoader : AttachmentLoader
	{
		// Token: 0x0601B1A8 RID: 111016 RVA: 0x008570E3 File Offset: 0x008554E3
		public AtlasAttachmentLoader(params Atlas[] atlasArray)
		{
			if (atlasArray == null)
			{
				throw new ArgumentNullException("atlas array cannot be null.");
			}
			this.atlasArray = atlasArray;
		}

		// Token: 0x0601B1A9 RID: 111017 RVA: 0x00857104 File Offset: 0x00855504
		public RegionAttachment NewRegionAttachment(Skin skin, string name, string path)
		{
			AtlasRegion atlasRegion = this.FindRegion(path);
			if (atlasRegion == null)
			{
				throw new ArgumentException(string.Format("Region not found in atlas: {0} (region attachment: {1})", path, name));
			}
			RegionAttachment regionAttachment = new RegionAttachment(name);
			regionAttachment.RendererObject = atlasRegion;
			regionAttachment.SetUVs(atlasRegion.u, atlasRegion.v, atlasRegion.u2, atlasRegion.v2, atlasRegion.rotate);
			regionAttachment.regionOffsetX = atlasRegion.offsetX;
			regionAttachment.regionOffsetY = atlasRegion.offsetY;
			regionAttachment.regionWidth = (float)atlasRegion.width;
			regionAttachment.regionHeight = (float)atlasRegion.height;
			regionAttachment.regionOriginalWidth = (float)atlasRegion.originalWidth;
			regionAttachment.regionOriginalHeight = (float)atlasRegion.originalHeight;
			return regionAttachment;
		}

		// Token: 0x0601B1AA RID: 111018 RVA: 0x008571B0 File Offset: 0x008555B0
		public MeshAttachment NewMeshAttachment(Skin skin, string name, string path)
		{
			AtlasRegion atlasRegion = this.FindRegion(path);
			if (atlasRegion == null)
			{
				throw new ArgumentException(string.Format("Region not found in atlas: {0} (region attachment: {1})", path, name));
			}
			return new MeshAttachment(name)
			{
				RendererObject = atlasRegion,
				RegionU = atlasRegion.u,
				RegionV = atlasRegion.v,
				RegionU2 = atlasRegion.u2,
				RegionV2 = atlasRegion.v2,
				RegionRotate = atlasRegion.rotate,
				regionOffsetX = atlasRegion.offsetX,
				regionOffsetY = atlasRegion.offsetY,
				regionWidth = (float)atlasRegion.width,
				regionHeight = (float)atlasRegion.height,
				regionOriginalWidth = (float)atlasRegion.originalWidth,
				regionOriginalHeight = (float)atlasRegion.originalHeight
			};
		}

		// Token: 0x0601B1AB RID: 111019 RVA: 0x00857274 File Offset: 0x00855674
		public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name)
		{
			return new BoundingBoxAttachment(name);
		}

		// Token: 0x0601B1AC RID: 111020 RVA: 0x0085727C File Offset: 0x0085567C
		public PathAttachment NewPathAttachment(Skin skin, string name)
		{
			return new PathAttachment(name);
		}

		// Token: 0x0601B1AD RID: 111021 RVA: 0x00857284 File Offset: 0x00855684
		public PointAttachment NewPointAttachment(Skin skin, string name)
		{
			return new PointAttachment(name);
		}

		// Token: 0x0601B1AE RID: 111022 RVA: 0x0085728C File Offset: 0x0085568C
		public ClippingAttachment NewClippingAttachment(Skin skin, string name)
		{
			return new ClippingAttachment(name);
		}

		// Token: 0x0601B1AF RID: 111023 RVA: 0x00857294 File Offset: 0x00855694
		public AtlasRegion FindRegion(string name)
		{
			for (int i = 0; i < this.atlasArray.Length; i++)
			{
				AtlasRegion atlasRegion = this.atlasArray[i].FindRegion(name);
				if (atlasRegion != null)
				{
					return atlasRegion;
				}
			}
			return null;
		}

		// Token: 0x04012E9B RID: 77467
		private Atlas[] atlasArray;
	}
}
