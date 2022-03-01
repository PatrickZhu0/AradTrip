using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E5 RID: 18917
	public class RegionlessAttachmentLoader : AttachmentLoader
	{
		// Token: 0x17002418 RID: 9240
		// (get) Token: 0x0601B4A3 RID: 111779 RVA: 0x008665FC File Offset: 0x008649FC
		private static AtlasRegion EmptyRegion
		{
			get
			{
				if (RegionlessAttachmentLoader.emptyRegion == null)
				{
					RegionlessAttachmentLoader.emptyRegion = new AtlasRegion
					{
						name = "Empty AtlasRegion",
						page = new AtlasPage
						{
							name = "Empty AtlasPage",
							rendererObject = new Material(Shader.Find("Spine/Special/HiddenPass"))
							{
								name = "NoRender Material"
							}
						}
					};
				}
				return RegionlessAttachmentLoader.emptyRegion;
			}
		}

		// Token: 0x0601B4A4 RID: 111780 RVA: 0x0086666C File Offset: 0x00864A6C
		public RegionAttachment NewRegionAttachment(Skin skin, string name, string path)
		{
			return new RegionAttachment(name)
			{
				RendererObject = RegionlessAttachmentLoader.EmptyRegion
			};
		}

		// Token: 0x0601B4A5 RID: 111781 RVA: 0x00866690 File Offset: 0x00864A90
		public MeshAttachment NewMeshAttachment(Skin skin, string name, string path)
		{
			return new MeshAttachment(name)
			{
				RendererObject = RegionlessAttachmentLoader.EmptyRegion
			};
		}

		// Token: 0x0601B4A6 RID: 111782 RVA: 0x008666B2 File Offset: 0x00864AB2
		public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name)
		{
			return new BoundingBoxAttachment(name);
		}

		// Token: 0x0601B4A7 RID: 111783 RVA: 0x008666BA File Offset: 0x00864ABA
		public PathAttachment NewPathAttachment(Skin skin, string name)
		{
			return new PathAttachment(name);
		}

		// Token: 0x0601B4A8 RID: 111784 RVA: 0x008666C2 File Offset: 0x00864AC2
		public PointAttachment NewPointAttachment(Skin skin, string name)
		{
			return new PointAttachment(name);
		}

		// Token: 0x0601B4A9 RID: 111785 RVA: 0x008666CA File Offset: 0x00864ACA
		public ClippingAttachment NewClippingAttachment(Skin skin, string name)
		{
			return new ClippingAttachment(name);
		}

		// Token: 0x0401301C RID: 77852
		private static AtlasRegion emptyRegion;
	}
}
