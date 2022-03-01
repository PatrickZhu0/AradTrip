using System;

namespace Spine
{
	// Token: 0x020049AF RID: 18863
	public abstract class Attachment
	{
		// Token: 0x0601B1B0 RID: 111024 RVA: 0x008572D2 File Offset: 0x008556D2
		protected Attachment(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null");
			}
			this.Name = name;
		}

		// Token: 0x17002314 RID: 8980
		// (get) Token: 0x0601B1B1 RID: 111025 RVA: 0x008572F7 File Offset: 0x008556F7
		// (set) Token: 0x0601B1B2 RID: 111026 RVA: 0x008572FF File Offset: 0x008556FF
		public string Name { get; private set; }

		// Token: 0x0601B1B3 RID: 111027 RVA: 0x00857308 File Offset: 0x00855708
		public override string ToString()
		{
			return this.Name;
		}
	}
}
