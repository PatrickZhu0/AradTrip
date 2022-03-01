using System;

namespace Spine
{
	// Token: 0x020049B4 RID: 18868
	public class ClippingAttachment : VertexAttachment
	{
		// Token: 0x0601B1BC RID: 111036 RVA: 0x008576D4 File Offset: 0x00855AD4
		public ClippingAttachment(string name) : base(name)
		{
		}

		// Token: 0x17002316 RID: 8982
		// (get) Token: 0x0601B1BD RID: 111037 RVA: 0x008576DD File Offset: 0x00855ADD
		// (set) Token: 0x0601B1BE RID: 111038 RVA: 0x008576E5 File Offset: 0x00855AE5
		public SlotData EndSlot
		{
			get
			{
				return this.endSlot;
			}
			set
			{
				this.endSlot = value;
			}
		}

		// Token: 0x04012EA5 RID: 77477
		internal SlotData endSlot;
	}
}
