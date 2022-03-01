using System;

// Token: 0x0200019B RID: 411
public class LTEvent
{
	// Token: 0x06000CCD RID: 3277 RVA: 0x0003F9CF File Offset: 0x0003DDCF
	public LTEvent(int id, object data)
	{
		this.id = id;
		this.data = data;
	}

	// Token: 0x040008DA RID: 2266
	public object data;

	// Token: 0x040008DB RID: 2267
	public int id;
}
