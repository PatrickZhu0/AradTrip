using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049FB RID: 18939
	public struct SubmeshInstruction
	{
		// Token: 0x1700242D RID: 9261
		// (get) Token: 0x0601B535 RID: 111925 RVA: 0x00868A69 File Offset: 0x00866E69
		public int SlotCount
		{
			get
			{
				return this.endSlot - this.startSlot;
			}
		}

		// Token: 0x0601B536 RID: 111926 RVA: 0x00868A78 File Offset: 0x00866E78
		public override string ToString()
		{
			return string.Format("[SubmeshInstruction: slots {0} to {1}. (Material){2}. preActiveClippingSlotSource:{3}]", new object[]
			{
				this.startSlot,
				this.endSlot - 1,
				(!(this.material == null)) ? this.material.name : "<none>",
				this.preActiveClippingSlotSource
			});
		}

		// Token: 0x04013077 RID: 77943
		public Skeleton skeleton;

		// Token: 0x04013078 RID: 77944
		public int startSlot;

		// Token: 0x04013079 RID: 77945
		public int endSlot;

		// Token: 0x0401307A RID: 77946
		public Material material;

		// Token: 0x0401307B RID: 77947
		public bool forceSeparate;

		// Token: 0x0401307C RID: 77948
		public int preActiveClippingSlotSource;

		// Token: 0x0401307D RID: 77949
		public int rawTriangleCount;

		// Token: 0x0401307E RID: 77950
		public int rawVertexCount;

		// Token: 0x0401307F RID: 77951
		public int rawFirstVertexIndex;

		// Token: 0x04013080 RID: 77952
		public bool hasClipping;
	}
}
