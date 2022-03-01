using System;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class ResourceRequestWrapper : IAsyncLoadWrapper<Object>
{
	// Token: 0x060004A8 RID: 1192 RVA: 0x0001F756 File Offset: 0x0001DB56
	public bool IsReady()
	{
		return true;
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0001F759 File Offset: 0x0001DB59
	public void Prepare(string loadPath, AsyncLoadData asyncLoadData)
	{
		if (this.m_LoadData == null)
		{
			this.m_LoadData = (asyncLoadData as ResourceResquestData);
			this.m_LoadPath = loadPath;
		}
	}

	// Token: 0x060004AA RID: 1194 RVA: 0x0001F77C File Offset: 0x0001DB7C
	public void DoLoad()
	{
		if (this.m_LoadData != null)
		{
			this.m_Request = Resources.LoadAsync(this.m_LoadPath, this.m_LoadData.m_AssetType);
		}
		else
		{
			Logger.LogErrorFormat("Async load data is invalid with res path:{0}!", new object[]
			{
				this.m_LoadPath
			});
		}
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x0001F7CE File Offset: 0x0001DBCE
	public bool IsDone()
	{
		return this.m_Request.isDone;
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x0001F7DB File Offset: 0x0001DBDB
	public Object Extract()
	{
		return this.m_Request.asset;
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x0001F7E8 File Offset: 0x0001DBE8
	public bool InLoading()
	{
		return null != this.m_Request;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x0001F7F6 File Offset: 0x0001DBF6
	public void OnAbort()
	{
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0001F7F8 File Offset: 0x0001DBF8
	public void Reset()
	{
		this.m_Request = null;
		this.m_LoadData = null;
		this.m_LoadPath = null;
	}

	// Token: 0x04000421 RID: 1057
	public ResourceRequest m_Request;

	// Token: 0x04000422 RID: 1058
	private ResourceResquestData m_LoadData;

	// Token: 0x04000423 RID: 1059
	private string m_LoadPath;
}
