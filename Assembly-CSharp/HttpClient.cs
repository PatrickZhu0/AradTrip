using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000165 RID: 357
public class HttpClient : MonoBehaviour
{
	// Token: 0x06000A58 RID: 2648 RVA: 0x00036034 File Offset: 0x00034434
	private void Awake()
	{
		HttpClient.Instance = this;
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x0003603C File Offset: 0x0003443C
	public void GetRequest(string url, HttpClient.deleHttpRequest deleFunc)
	{
		WWW www = new WWW(url);
		base.StartCoroutine(this.WaitForGetRequest(www, deleFunc));
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x0003605F File Offset: 0x0003445F
	public void BeginPostRequest()
	{
		this.wwwForm = new WWWForm();
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x0003606C File Offset: 0x0003446C
	public void AddField(string fieldName, string fieldValue)
	{
		if (this.wwwForm == null)
		{
			return;
		}
		this.wwwForm.AddField(fieldName, fieldValue);
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x00036087 File Offset: 0x00034487
	public void AddBinary(string fieldName, byte[] content, string fileName = null)
	{
		if (this.wwwForm == null)
		{
			return;
		}
		this.wwwForm.AddBinaryData(fieldName, content, fileName, null);
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x000360A4 File Offset: 0x000344A4
	public void PostRequest(string url, HttpClient.deleHttpRequest deleFunc)
	{
		if (this.wwwForm == null)
		{
			return;
		}
		WWW www = new WWW(url, this.wwwForm);
		base.StartCoroutine(this.WaitForPostRequest(www, deleFunc));
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x000360DC File Offset: 0x000344DC
	private IEnumerator WaitForGetRequest(WWW www, HttpClient.deleHttpRequest deleFunc)
	{
		yield return www;
		if (!www.isDone)
		{
			yield break;
		}
		if (deleFunc != null)
		{
			deleFunc(www);
		}
		else if (www.error != null)
		{
		}
		www.Dispose();
		yield break;
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x00036100 File Offset: 0x00034500
	private IEnumerator WaitForPostRequest(WWW www, HttpClient.deleHttpRequest deleFunc)
	{
		yield return www;
		if (!www.isDone)
		{
			yield break;
		}
		if (deleFunc != null)
		{
			deleFunc(www);
		}
		else if (www.error != null)
		{
		}
		www.Dispose();
		this.wwwForm = null;
		yield break;
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x00036129 File Offset: 0x00034529
	private void Start()
	{
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x0003612B File Offset: 0x0003452B
	private void Update()
	{
	}

	// Token: 0x040007A0 RID: 1952
	public static HttpClient Instance;

	// Token: 0x040007A1 RID: 1953
	protected WWWForm wwwForm;

	// Token: 0x02000166 RID: 358
	// (Invoke) Token: 0x06000A64 RID: 2660
	public delegate void deleHttpRequest(WWW wwwReq);
}
