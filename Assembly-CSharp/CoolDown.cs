using System;

// Token: 0x020042AB RID: 17067
public class CoolDown
{
	// Token: 0x060179CB RID: 96715 RVA: 0x007462C4 File Offset: 0x007446C4
	public void StartCD(int time)
	{
		this.m_IsStartCD = true;
		this.m_CurCDAcc = 0;
		this.m_CDTime = time;
	}

	// Token: 0x060179CC RID: 96716 RVA: 0x007462DB File Offset: 0x007446DB
	public void UpdateCD(int deltaTime)
	{
		if (this.m_IsStartCD)
		{
			this.m_CurCDAcc += deltaTime;
			if (this.m_CurCDAcc >= this.m_CDTime)
			{
				this.m_IsStartCD = false;
			}
		}
	}

	// Token: 0x060179CD RID: 96717 RVA: 0x0074630E File Offset: 0x0074470E
	public bool IsCD()
	{
		return this.m_IsStartCD;
	}

	// Token: 0x04010F87 RID: 69511
	private bool m_IsStartCD;

	// Token: 0x04010F88 RID: 69512
	private int m_CurCDAcc;

	// Token: 0x04010F89 RID: 69513
	private int m_CDTime;
}
