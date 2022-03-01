using System;
using System.Collections;
using GameClient;

// Token: 0x020017F8 RID: 6136
public class WaitHttpRespensedService : BaseCustomEnum<HTTPAsyncRequest.eState>, IEnumerator
{
	// Token: 0x0600F1FB RID: 61947 RVA: 0x004146A0 File Offset: 0x00412AA0
	public WaitHttpRespensedService(string url)
	{
		this.url = url;
		this.req = new HTTPAsyncRequest();
		this.req.SendHttpRequst(url, VoiceDataHelper.HttpRequesetTimeout);
	}

	// Token: 0x0600F1FC RID: 61948 RVA: 0x004146CB File Offset: 0x00412ACB
	public string GetResultString()
	{
		if (this.req != null && this.req.GetState() == HTTPAsyncRequest.eState.Success)
		{
			return this.req.GetResString();
		}
		return null;
	}

	// Token: 0x0600F1FD RID: 61949 RVA: 0x004146F6 File Offset: 0x00412AF6
	public byte[] GetResultByteArray()
	{
		if (this.req != null && this.req.GetState() == HTTPAsyncRequest.eState.Success)
		{
			return VoiceDataHelper.Base64DecodeToBytes(this.req.GetResString());
		}
		return null;
	}

	// Token: 0x0600F1FE RID: 61950 RVA: 0x00414726 File Offset: 0x00412B26
	public bool MoveNext()
	{
		this.mResult = this.req.GetState();
		if (this.mResult == HTTPAsyncRequest.eState.Error)
		{
		}
		return this.req != null && this.req.GetState() == HTTPAsyncRequest.eState.Wait;
	}

	// Token: 0x0600F1FF RID: 61951 RVA: 0x00414761 File Offset: 0x00412B61
	public void Reset()
	{
	}

	// Token: 0x17001CF8 RID: 7416
	// (get) Token: 0x0600F200 RID: 61952 RVA: 0x00414763 File Offset: 0x00412B63
	public object Current
	{
		get
		{
			return null;
		}
	}

	// Token: 0x040094B8 RID: 38072
	protected string url;

	// Token: 0x040094B9 RID: 38073
	protected HTTPAsyncRequest req;
}
