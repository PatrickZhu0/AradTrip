using System;
using System.IO;
using System.Net;
using System.Text;

// Token: 0x02000146 RID: 326
public class HTTPAsyncRequest
{
	// Token: 0x06000976 RID: 2422 RVA: 0x00031DB0 File Offset: 0x000301B0
	public void SendHttpRequst(string url, int timeout)
	{
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			this.mStatus.req = httpWebRequest;
			this.mStatus.state = HTTPAsyncRequest.eState.Wait;
			httpWebRequest.Timeout = timeout;
			httpWebRequest.BeginGetResponse(new AsyncCallback(this._getResponseCallback), this.mStatus);
		}
		catch (WebException ex)
		{
			Logger.LogErrorFormat("[WebException] msg {0} status {1}", new object[]
			{
				ex.Message,
				ex.Status
			});
			this.mStatus.state = HTTPAsyncRequest.eState.Error;
		}
		catch (Exception ex2)
		{
			Logger.LogErrorFormat("[WebException] msg {0}", new object[]
			{
				ex2.ToString()
			});
			this.mStatus.state = HTTPAsyncRequest.eState.Error;
		}
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x00031E88 File Offset: 0x00030288
	private void _getResponseCallback(IAsyncResult ar)
	{
		try
		{
			HTTPAsyncRequest.CustomAsyncCallState customAsyncCallState = (HTTPAsyncRequest.CustomAsyncCallState)ar.AsyncState;
			HttpWebRequest req = customAsyncCallState.req;
			customAsyncCallState.res = (HttpWebResponse)req.EndGetResponse(ar);
			Stream responseStream = customAsyncCallState.res.GetResponseStream();
			customAsyncCallState.resstream = responseStream;
			customAsyncCallState.leftCount = customAsyncCallState.res.ContentLength;
			IAsyncResult asyncResult = responseStream.BeginRead(customAsyncCallState.buffer, 0, 1024, new AsyncCallback(this._getReadStreamCallback), customAsyncCallState);
		}
		catch (WebException ex)
		{
			Logger.LogErrorFormat("[WebException] msg {0} status {1}", new object[]
			{
				ex.Message,
				ex.Status
			});
			this.mStatus.state = HTTPAsyncRequest.eState.Error;
		}
		catch (Exception ex2)
		{
			this.mStatus.state = HTTPAsyncRequest.eState.Error;
			Logger.LogErrorFormat("[WebException] msg {0}", new object[]
			{
				ex2.ToString()
			});
		}
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x00031F88 File Offset: 0x00030388
	private void _finishStreamRead(HTTPAsyncRequest.CustomAsyncCallState status)
	{
		if (status.resdata.Length > 1)
		{
			this.mResultString = status.resdata.ToString();
		}
		status.resstream.Close();
		status.state = HTTPAsyncRequest.eState.Success;
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x00031FC0 File Offset: 0x000303C0
	private void _getReadStreamCallback(IAsyncResult ar)
	{
		try
		{
			HTTPAsyncRequest.CustomAsyncCallState customAsyncCallState = (HTTPAsyncRequest.CustomAsyncCallState)ar.AsyncState;
			Stream resstream = customAsyncCallState.resstream;
			int num = resstream.EndRead(ar);
			if (num > 0)
			{
				customAsyncCallState.resdata.Append(Encoding.UTF8.GetString(customAsyncCallState.buffer, 0, num));
				IAsyncResult asyncResult = resstream.BeginRead(customAsyncCallState.buffer, 0, 1024, new AsyncCallback(this._getReadStreamCallback), customAsyncCallState);
			}
			else
			{
				this._finishStreamRead(customAsyncCallState);
			}
		}
		catch (WebException ex)
		{
			Logger.LogErrorFormat("[WebException] msg {0} status {1}", new object[]
			{
				ex.Message,
				ex.Status
			});
			this.mStatus.state = HTTPAsyncRequest.eState.Error;
		}
		catch (Exception ex2)
		{
			Logger.LogErrorFormat("[WebException] msg {0}", new object[]
			{
				ex2.ToString()
			});
			this.mStatus.state = HTTPAsyncRequest.eState.Error;
		}
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x000320C4 File Offset: 0x000304C4
	public HTTPAsyncRequest.eState GetState()
	{
		if (this.mStatus == null)
		{
			return HTTPAsyncRequest.eState.None;
		}
		return this.mStatus.state;
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x000320DE File Offset: 0x000304DE
	public string GetResString()
	{
		return this.mResultString;
	}

	// Token: 0x04000726 RID: 1830
	private HTTPAsyncRequest.CustomAsyncCallState mStatus = new HTTPAsyncRequest.CustomAsyncCallState();

	// Token: 0x04000727 RID: 1831
	private string mResultString = string.Empty;

	// Token: 0x02000147 RID: 327
	public enum eState
	{
		// Token: 0x04000729 RID: 1833
		None,
		// Token: 0x0400072A RID: 1834
		Wait,
		// Token: 0x0400072B RID: 1835
		Success,
		// Token: 0x0400072C RID: 1836
		Error
	}

	// Token: 0x02000148 RID: 328
	private class CustomAsyncCallState
	{
		// Token: 0x0600097D RID: 2429 RVA: 0x0003210E File Offset: 0x0003050E
		public long GetReadSize()
		{
			if (this.leftCount < 1024L)
			{
				return this.leftCount;
			}
			return 1024L;
		}

		// Token: 0x0400072D RID: 1837
		public const int cBuffSize = 1024;

		// Token: 0x0400072E RID: 1838
		public HTTPAsyncRequest.eState state;

		// Token: 0x0400072F RID: 1839
		public HttpWebRequest req;

		// Token: 0x04000730 RID: 1840
		public HttpWebResponse res;

		// Token: 0x04000731 RID: 1841
		public Stream resstream;

		// Token: 0x04000732 RID: 1842
		public byte[] buffer = new byte[1024];

		// Token: 0x04000733 RID: 1843
		public StringBuilder resdata = new StringBuilder(256);

		// Token: 0x04000734 RID: 1844
		public long leftCount;
	}
}
