using System;
using System.Collections.Generic;

// Token: 0x020000E0 RID: 224
public class AsyncRequestHandleAllocator<T> where T : class
{
	// Token: 0x060004C8 RID: 1224 RVA: 0x0001FC3D File Offset: 0x0001E03D
	public AsyncRequestHandleAllocator(uint type)
	{
		this.m_HandleType = type;
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x0001FC6C File Offset: 0x0001E06C
	public T GetAsyncRequestByHandle(uint handle)
	{
		if (handle == this.m_AsyncReqHandleDescCache.m_Handle)
		{
			return this.m_AsyncReqHandleDescCache.m_Request;
		}
		int i = 0;
		int count = this.m_AsyncReqHandleDescList.Count;
		while (i < count)
		{
			if (handle == this.m_AsyncReqHandleDescList[i].m_Handle)
			{
				this.m_AsyncReqHandleDescCache.m_Handle = handle;
				this.m_AsyncReqHandleDescCache.m_Request = this.m_AsyncReqHandleDescList[i].m_Request;
				return this.m_AsyncReqHandleDescList[i].m_Request;
			}
			i++;
		}
		return (T)((object)null);
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x0001FD0C File Offset: 0x0001E10C
	public uint AddAsyncRequest(T asyncRequest)
	{
		if (asyncRequest != null)
		{
			uint num = this._AllocHandle();
			this.m_AsyncReqHandleDescCache.m_Handle = num;
			this.m_AsyncReqHandleDescCache.m_Request = asyncRequest;
			this.m_AsyncReqHandleDescList.Add(new AsyncRequestHandleAllocator<T>.AsyncRequestDesc(num, asyncRequest));
			return num;
		}
		return uint.MaxValue;
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x0001FD58 File Offset: 0x0001E158
	public void RemoveAsyncRequest(uint handle)
	{
		int i = 0;
		int count = this.m_AsyncReqHandleDescList.Count;
		while (i < count)
		{
			if (handle == this.m_AsyncReqHandleDescList[i].m_Handle)
			{
				if (handle == this.m_AsyncReqHandleDescCache.m_Handle)
				{
					this.m_AsyncReqHandleDescCache.m_Handle = uint.MaxValue;
					this.m_AsyncReqHandleDescCache.m_Request = (T)((object)null);
				}
				this.m_AsyncReqHandleDescList.RemoveAt(i);
				return;
			}
			i++;
		}
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x0001FDD8 File Offset: 0x0001E1D8
	protected uint _AllocHandle()
	{
		if (this.m_CurAudioHandleCnt + 1U >= 1073741823U)
		{
			this.m_CurAudioHandleCnt = 0U;
		}
		return this.m_CurAudioHandleCnt++ | (this.m_HandleType & 3U) << 30;
	}

	// Token: 0x04000430 RID: 1072
	protected uint m_CurAudioHandleCnt;

	// Token: 0x04000431 RID: 1073
	protected uint m_HandleType;

	// Token: 0x04000432 RID: 1074
	protected List<AsyncRequestHandleAllocator<T>.AsyncRequestDesc> m_AsyncReqHandleDescList = new List<AsyncRequestHandleAllocator<T>.AsyncRequestDesc>();

	// Token: 0x04000433 RID: 1075
	protected AsyncRequestHandleAllocator<T>.AsyncRequestDesc m_AsyncReqHandleDescCache = new AsyncRequestHandleAllocator<T>.AsyncRequestDesc(uint.MaxValue, (T)((object)null));

	// Token: 0x020000E1 RID: 225
	protected class AsyncRequestDesc
	{
		// Token: 0x060004CD RID: 1229 RVA: 0x0001FE1B File Offset: 0x0001E21B
		public AsyncRequestDesc(uint handle, T request)
		{
			this.m_Handle = handle;
			this.m_Request = request;
		}

		// Token: 0x04000434 RID: 1076
		public uint m_Handle;

		// Token: 0x04000435 RID: 1077
		public T m_Request;
	}
}
