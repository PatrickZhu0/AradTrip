using System;
using UnityEngine;

namespace Spine.Unity.Modules.AttachmentTools
{
	// Token: 0x02004A07 RID: 18951
	public static class AttachmentCloneExtensions
	{
		// Token: 0x0601B5AD RID: 112045 RVA: 0x0086DC04 File Offset: 0x0086C004
		public static Attachment GetClone(this Attachment o, bool cloneMeshesAsLinked)
		{
			RegionAttachment regionAttachment = o as RegionAttachment;
			if (regionAttachment != null)
			{
				return regionAttachment.GetClone();
			}
			MeshAttachment meshAttachment = o as MeshAttachment;
			if (meshAttachment != null)
			{
				return (!cloneMeshesAsLinked) ? meshAttachment.GetClone() : meshAttachment.GetLinkedClone(true);
			}
			BoundingBoxAttachment boundingBoxAttachment = o as BoundingBoxAttachment;
			if (boundingBoxAttachment != null)
			{
				return boundingBoxAttachment.GetClone();
			}
			PathAttachment pathAttachment = o as PathAttachment;
			if (pathAttachment != null)
			{
				return pathAttachment.GetClone();
			}
			PointAttachment pointAttachment = o as PointAttachment;
			if (pointAttachment != null)
			{
				return pointAttachment.GetClone();
			}
			ClippingAttachment clippingAttachment = o as ClippingAttachment;
			if (clippingAttachment != null)
			{
				return clippingAttachment.GetClone();
			}
			return null;
		}

		// Token: 0x0601B5AE RID: 112046 RVA: 0x0086DCA4 File Offset: 0x0086C0A4
		public static RegionAttachment GetClone(this RegionAttachment o)
		{
			return new RegionAttachment(o.Name + "clone")
			{
				x = o.x,
				y = o.y,
				rotation = o.rotation,
				scaleX = o.scaleX,
				scaleY = o.scaleY,
				width = o.width,
				height = o.height,
				r = o.r,
				g = o.g,
				b = o.b,
				a = o.a,
				Path = o.Path,
				RendererObject = o.RendererObject,
				regionOffsetX = o.regionOffsetX,
				regionOffsetY = o.regionOffsetY,
				regionWidth = o.regionWidth,
				regionHeight = o.regionHeight,
				regionOriginalWidth = o.regionOriginalWidth,
				regionOriginalHeight = o.regionOriginalHeight,
				uvs = (o.uvs.Clone() as float[]),
				offset = (o.offset.Clone() as float[])
			};
		}

		// Token: 0x0601B5AF RID: 112047 RVA: 0x0086DDD8 File Offset: 0x0086C1D8
		public static ClippingAttachment GetClone(this ClippingAttachment o)
		{
			ClippingAttachment clippingAttachment = new ClippingAttachment(o.Name)
			{
				endSlot = o.endSlot
			};
			AttachmentCloneExtensions.CloneVertexAttachment(o, clippingAttachment);
			return clippingAttachment;
		}

		// Token: 0x0601B5B0 RID: 112048 RVA: 0x0086DE08 File Offset: 0x0086C208
		public static PointAttachment GetClone(this PointAttachment o)
		{
			return new PointAttachment(o.Name)
			{
				rotation = o.rotation,
				x = o.x,
				y = o.y
			};
		}

		// Token: 0x0601B5B1 RID: 112049 RVA: 0x0086DE48 File Offset: 0x0086C248
		public static BoundingBoxAttachment GetClone(this BoundingBoxAttachment o)
		{
			BoundingBoxAttachment boundingBoxAttachment = new BoundingBoxAttachment(o.Name);
			AttachmentCloneExtensions.CloneVertexAttachment(o, boundingBoxAttachment);
			return boundingBoxAttachment;
		}

		// Token: 0x0601B5B2 RID: 112050 RVA: 0x0086DE69 File Offset: 0x0086C269
		public static MeshAttachment GetLinkedClone(this MeshAttachment o, bool inheritDeform = true)
		{
			return o.GetLinkedMesh(o.Name, o.RendererObject as AtlasRegion, inheritDeform);
		}

		// Token: 0x0601B5B3 RID: 112051 RVA: 0x0086DE84 File Offset: 0x0086C284
		public static MeshAttachment GetClone(this MeshAttachment o)
		{
			MeshAttachment meshAttachment = new MeshAttachment(o.Name)
			{
				r = o.r,
				g = o.g,
				b = o.b,
				a = o.a,
				inheritDeform = o.inheritDeform,
				Path = o.Path,
				RendererObject = o.RendererObject,
				regionOffsetX = o.regionOffsetX,
				regionOffsetY = o.regionOffsetY,
				regionWidth = o.regionWidth,
				regionHeight = o.regionHeight,
				regionOriginalWidth = o.regionOriginalWidth,
				regionOriginalHeight = o.regionOriginalHeight,
				RegionU = o.RegionU,
				RegionV = o.RegionV,
				RegionU2 = o.RegionU2,
				RegionV2 = o.RegionV2,
				RegionRotate = o.RegionRotate,
				uvs = (o.uvs.Clone() as float[])
			};
			if (o.ParentMesh != null)
			{
				meshAttachment.ParentMesh = o.ParentMesh;
			}
			else
			{
				AttachmentCloneExtensions.CloneVertexAttachment(o, meshAttachment);
				meshAttachment.regionUVs = (o.regionUVs.Clone() as float[]);
				meshAttachment.triangles = (o.triangles.Clone() as int[]);
				meshAttachment.hulllength = o.hulllength;
				meshAttachment.Edges = ((o.Edges != null) ? (o.Edges.Clone() as int[]) : null);
				meshAttachment.Width = o.Width;
				meshAttachment.Height = o.Height;
			}
			return meshAttachment;
		}

		// Token: 0x0601B5B4 RID: 112052 RVA: 0x0086E028 File Offset: 0x0086C428
		public static PathAttachment GetClone(this PathAttachment o)
		{
			PathAttachment pathAttachment = new PathAttachment(o.Name)
			{
				lengths = (o.lengths.Clone() as float[]),
				closed = o.closed,
				constantSpeed = o.constantSpeed
			};
			AttachmentCloneExtensions.CloneVertexAttachment(o, pathAttachment);
			return pathAttachment;
		}

		// Token: 0x0601B5B5 RID: 112053 RVA: 0x0086E07C File Offset: 0x0086C47C
		private static void CloneVertexAttachment(VertexAttachment src, VertexAttachment dest)
		{
			dest.worldVerticesLength = src.worldVerticesLength;
			if (src.bones != null)
			{
				dest.bones = (src.bones.Clone() as int[]);
			}
			if (src.vertices != null)
			{
				dest.vertices = (src.vertices.Clone() as float[]);
			}
		}

		// Token: 0x0601B5B6 RID: 112054 RVA: 0x0086E0D8 File Offset: 0x0086C4D8
		public static MeshAttachment GetLinkedMesh(this MeshAttachment o, string newLinkedMeshName, AtlasRegion region, bool inheritDeform = true)
		{
			if (region == null)
			{
				throw new ArgumentNullException("region");
			}
			if (o.ParentMesh != null)
			{
				o = o.ParentMesh;
			}
			MeshAttachment meshAttachment = new MeshAttachment(newLinkedMeshName);
			meshAttachment.SetRegion(region, false);
			meshAttachment.Path = newLinkedMeshName;
			meshAttachment.r = 1f;
			meshAttachment.g = 1f;
			meshAttachment.b = 1f;
			meshAttachment.a = 1f;
			meshAttachment.inheritDeform = inheritDeform;
			meshAttachment.ParentMesh = o;
			meshAttachment.UpdateUVs();
			return meshAttachment;
		}

		// Token: 0x0601B5B7 RID: 112055 RVA: 0x0086E160 File Offset: 0x0086C560
		public static MeshAttachment GetLinkedMesh(this MeshAttachment o, Sprite sprite, Shader shader, bool inheritDeform = true, Material materialPropertySource = null)
		{
			Material material = new Material(shader);
			if (materialPropertySource != null)
			{
				material.CopyPropertiesFromMaterial(materialPropertySource);
				material.shaderKeywords = materialPropertySource.shaderKeywords;
			}
			return o.GetLinkedMesh(sprite.name, sprite.ToAtlasRegion(false), inheritDeform);
		}

		// Token: 0x0601B5B8 RID: 112056 RVA: 0x0086E1AA File Offset: 0x0086C5AA
		public static MeshAttachment GetLinkedMesh(this MeshAttachment o, Sprite sprite, Material materialPropertySource, bool inheritDeform = true)
		{
			return o.GetLinkedMesh(sprite, materialPropertySource.shader, inheritDeform, materialPropertySource);
		}

		// Token: 0x0601B5B9 RID: 112057 RVA: 0x0086E1BC File Offset: 0x0086C5BC
		public static Attachment GetRemappedClone(this Attachment o, Sprite sprite, Material sourceMaterial, bool premultiplyAlpha = true, bool cloneMeshAsLinked = true, bool useOriginalRegionSize = false)
		{
			AtlasRegion atlasRegion = (!premultiplyAlpha) ? sprite.ToAtlasRegion(new Material(sourceMaterial)
			{
				mainTexture = sprite.texture
			}) : sprite.ToAtlasRegionPMAClone(sourceMaterial, 4, false);
			return o.GetRemappedClone(atlasRegion, cloneMeshAsLinked, useOriginalRegionSize, 1f / sprite.pixelsPerUnit);
		}

		// Token: 0x0601B5BA RID: 112058 RVA: 0x0086E210 File Offset: 0x0086C610
		public static Attachment GetRemappedClone(this Attachment o, AtlasRegion atlasRegion, bool cloneMeshAsLinked = true, bool useOriginalRegionSize = false, float scale = 0.01f)
		{
			RegionAttachment regionAttachment = o as RegionAttachment;
			if (regionAttachment != null)
			{
				RegionAttachment clone = regionAttachment.GetClone();
				clone.SetRegion(atlasRegion, false);
				if (!useOriginalRegionSize)
				{
					clone.width = (float)atlasRegion.width * scale;
					clone.height = (float)atlasRegion.height * scale;
				}
				clone.UpdateOffset();
				return clone;
			}
			MeshAttachment meshAttachment = o as MeshAttachment;
			if (meshAttachment != null)
			{
				MeshAttachment meshAttachment2 = (!cloneMeshAsLinked) ? meshAttachment.GetClone() : meshAttachment.GetLinkedClone(cloneMeshAsLinked);
				meshAttachment2.SetRegion(atlasRegion, true);
				return meshAttachment2;
			}
			return o.GetClone(true);
		}
	}
}
