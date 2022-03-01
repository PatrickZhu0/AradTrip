using System;

// Token: 0x020000D1 RID: 209
public class AsyncLoadRequest<T> : IAsyncLoadRequest<T> where T : class
{
	// Token: 0x0600046B RID: 1131 RVA: 0x0001EA08 File Offset: 0x0001CE08
	public bool IsDone()
	{
		return this.m_IsDone;
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0001EA10 File Offset: 0x0001CE10
	public void Encase(T resObj)
	{
		this.m_IsDone = true;
		this.m_ResObject = resObj;
		this.m_Extracted = false;
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0001EA28 File Offset: 0x0001CE28
	public virtual T Extract()
	{
		if (!this.m_IsDone)
		{
			return (T)((object)null);
		}
		if (!this.m_Extracted)
		{
			T resObject = this.m_ResObject;
			this.m_ResObject = (T)((object)null);
			this.m_Extracted = true;
			return resObject;
		}
		return (T)((object)null);
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x0001EA74 File Offset: 0x0001CE74
	public string GetLoadPath()
	{
		return this.m_ResPath;
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x0001EA7C File Offset: 0x0001CE7C
	public virtual void Abort()
	{
		this.m_IsAbort = true;
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x0001EA85 File Offset: 0x0001CE85
	public bool IsValid()
	{
		return null != this.m_ResObject;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0001EA98 File Offset: 0x0001CE98
	public bool IsAbort()
	{
		return this.m_IsAbort;
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x0001EAA0 File Offset: 0x0001CEA0
	public void Reset()
	{
		this.m_ResObject = (T)((object)null);
		this.m_IsDone = false;
		this.m_Extracted = false;
		this.m_IsAbort = false;
		this.m_ResPath = null;
		this.m_WaterMark = 0U;
	}

	// Token: 0x040003FE RID: 1022
	public T m_ResObject;

	// Token: 0x040003FF RID: 1023
	public string m_ResPath;

	// Token: 0x04000400 RID: 1024
	public bool m_IsDone;

	// Token: 0x04000401 RID: 1025
	public bool m_Extracted;

	// Token: 0x04000402 RID: 1026
	public bool m_IsAbort;

	// Token: 0x04000403 RID: 1027
	public uint m_WaterMark;
}
