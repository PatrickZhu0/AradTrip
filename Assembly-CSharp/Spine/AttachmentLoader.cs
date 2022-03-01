using System;

namespace Spine
{
	// Token: 0x020049B1 RID: 18865
	public interface AttachmentLoader
	{
		// Token: 0x0601B1B5 RID: 111029
		RegionAttachment NewRegionAttachment(Skin skin, string name, string path);

		// Token: 0x0601B1B6 RID: 111030
		MeshAttachment NewMeshAttachment(Skin skin, string name, string path);

		// Token: 0x0601B1B7 RID: 111031
		BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name);

		// Token: 0x0601B1B8 RID: 111032
		PathAttachment NewPathAttachment(Skin skin, string name);

		// Token: 0x0601B1B9 RID: 111033
		PointAttachment NewPointAttachment(Skin skin, string name);

		// Token: 0x0601B1BA RID: 111034
		ClippingAttachment NewClippingAttachment(Skin skin, string name);
	}
}
