using System;
using System.IO;
using System.Net;
using System.Threading;

// Token: 0x02000143 RID: 323
public class Http
{
	// Token: 0x0600096C RID: 2412 RVA: 0x00031828 File Offset: 0x0002FC28
	public static void UploadFile(string url, string filename)
	{
		try
		{
			using (FileStream fileStream = new FileStream(StringHelper.BytesToString(filename), FileMode.Open))
			{
				int num = (int)fileStream.Length;
				byte[] array = new byte[num + 1];
				int num2 = fileStream.Read(array, 0, num);
				fileStream.Close();
				Http.SendPostRequest(url, array, null);
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("upload {0} log to {1} failed, error:{2}", new object[]
			{
				filename,
				url,
				ex.ToString()
			});
		}
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x000318C8 File Offset: 0x0002FCC8
	public static void SendPostRequest(string url, string content, Action<string> timeoutCallback = null)
	{
		try
		{
			byte[] array = StringHelper.StringToUTF8Bytes(content);
			if (array.Length != 0)
			{
				Http.SendPostRequest(url, array, timeoutCallback);
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("send post request to {0} failed, error:{1}", new object[]
			{
				url,
				ex.ToString()
			});
		}
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x0003192C File Offset: 0x0002FD2C
	public static void SendPostRequest(string url, byte[] content, Action<string> timeoutCallback = null)
	{
		try
		{
			if (content.Length != 0)
			{
				int num = content.Length - 1;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				httpWebRequest.Timeout = 5000;
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentLength = (long)num;
				Http.CustomAsyncCall customAsyncCall = new Http.CustomAsyncCall();
				customAsyncCall.req = httpWebRequest;
				customAsyncCall.content = content;
				customAsyncCall.state = Http.eCustomAsyncCall.Start;
				customAsyncCall.timeoutCB = timeoutCallback;
				httpWebRequest.BeginGetRequestStream(customAsyncCall.requestCB, customAsyncCall);
				Http.mIdx++;
			}
		}
		catch (Exception ex)
		{
			if (timeoutCallback != null)
			{
				timeoutCallback(ex.ToString());
			}
			Logger.LogErrorFormat("send post request to {0} failed, error:{1}", new object[]
			{
				url,
				ex.ToString()
			});
		}
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x00031A0C File Offset: 0x0002FE0C
	private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
	{
		Http.CustomAsyncCall customAsyncCall = (Http.CustomAsyncCall)asynchronousResult.AsyncState;
		try
		{
			if (customAsyncCall.req == null || customAsyncCall.content == null || customAsyncCall.content.Length <= 0)
			{
				customAsyncCall.state = Http.eCustomAsyncCall.Error;
			}
			else
			{
				byte[] content = customAsyncCall.content;
				HttpWebRequest req = customAsyncCall.req;
				Stream stream = req.EndGetRequestStream(asynchronousResult);
				customAsyncCall.postStream = stream;
				stream.WriteTimeout = 5000;
				stream.BeginWrite(content, 0, content.Length - 1, customAsyncCall.uploadCB, customAsyncCall);
				customAsyncCall.state = Http.eCustomAsyncCall.WriteRequestStream;
			}
		}
		catch (Exception ex)
		{
			if (customAsyncCall.timeoutCB != null)
			{
				customAsyncCall.timeoutCB(ex.ToString());
			}
			customAsyncCall.state = Http.eCustomAsyncCall.Error;
		}
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x00031ADC File Offset: 0x0002FEDC
	private static void _SendCB(IAsyncResult asynchronousResult)
	{
		Http.CustomAsyncCall customAsyncCall = (Http.CustomAsyncCall)asynchronousResult.AsyncState;
		try
		{
			if (customAsyncCall == null || customAsyncCall.req == null || customAsyncCall.postStream == null)
			{
				customAsyncCall.state = Http.eCustomAsyncCall.Error;
			}
			else
			{
				HttpWebRequest req = customAsyncCall.req;
				Stream postStream = customAsyncCall.postStream;
				postStream.Close();
				customAsyncCall.state = Http.eCustomAsyncCall.WaitResponse;
				req.BeginGetResponse(customAsyncCall.responseCB, customAsyncCall);
			}
		}
		catch (Exception ex)
		{
			if (customAsyncCall.timeoutCB != null)
			{
				customAsyncCall.timeoutCB(ex.ToString());
			}
			customAsyncCall.state = Http.eCustomAsyncCall.Error;
		}
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x00031B84 File Offset: 0x0002FF84
	private static void GetResponseCallback(IAsyncResult asynchronousResult)
	{
		Http.CustomAsyncCall customAsyncCall = (Http.CustomAsyncCall)asynchronousResult.AsyncState;
		try
		{
			if (customAsyncCall == null)
			{
				customAsyncCall.state = Http.eCustomAsyncCall.Error;
			}
			else
			{
				Http.GetResponseVoiceJson(customAsyncCall, asynchronousResult);
				customAsyncCall.state = Http.eCustomAsyncCall.End;
				Http.mIdx--;
			}
		}
		catch (Exception ex)
		{
			if (customAsyncCall.timeoutCB != null)
			{
				customAsyncCall.timeoutCB(ex.ToString());
			}
			customAsyncCall.state = Http.eCustomAsyncCall.Error;
		}
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x00031C08 File Offset: 0x00030008
	private static void GetResponseVoiceJson(Http.CustomAsyncCall args, IAsyncResult asynchronousResult)
	{
		if (Http.ReturnResponsedJsonListener != null)
		{
			try
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)args.req.EndGetResponse(asynchronousResult);
				using (Stream responseStream = httpWebResponse.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(responseStream))
					{
						string responseMsg = streamReader.ReadToEnd();
						ChatVoiceResponseInfo obj = new ChatVoiceResponseInfo
						{
							ResponseMsg = responseMsg,
							ResponseJsonSucc = true
						};
						Http.ReturnResponsedJsonListener(obj);
						responseStream.Close();
						streamReader.Close();
					}
				}
				httpWebResponse.Close();
			}
			catch (Exception ex)
			{
				ChatVoiceResponseInfo obj2 = new ChatVoiceResponseInfo
				{
					ResponseMsg = ex.ToString() + "Get_Json_Failed",
					ResponseJsonSucc = false
				};
				Http.ReturnResponsedJsonListener(obj2);
				Logger.LogErrorFormat("读取上传回调的语音消息返回值 error {0}", new object[]
				{
					ex.ToString()
				});
			}
		}
	}

	// Token: 0x04000712 RID: 1810
	private static ManualResetEvent allDone = new ManualResetEvent(false);

	// Token: 0x04000713 RID: 1811
	private const int kMaxCount = 10;

	// Token: 0x04000714 RID: 1812
	private const int kTimeOut = 5000;

	// Token: 0x04000715 RID: 1813
	private static int mIdx = 0;

	// Token: 0x04000716 RID: 1814
	public static Action<ChatVoiceResponseInfo> ReturnResponsedJsonListener;

	// Token: 0x02000144 RID: 324
	private enum eCustomAsyncCall
	{
		// Token: 0x04000718 RID: 1816
		None,
		// Token: 0x04000719 RID: 1817
		Start,
		// Token: 0x0400071A RID: 1818
		WriteRequestStream,
		// Token: 0x0400071B RID: 1819
		WaitResponse,
		// Token: 0x0400071C RID: 1820
		End,
		// Token: 0x0400071D RID: 1821
		Error
	}

	// Token: 0x02000145 RID: 325
	private class CustomAsyncCall
	{
		// Token: 0x0400071E RID: 1822
		public HttpWebRequest req;

		// Token: 0x0400071F RID: 1823
		public byte[] content = new byte[0];

		// Token: 0x04000720 RID: 1824
		public Http.eCustomAsyncCall state;

		// Token: 0x04000721 RID: 1825
		public Stream postStream;

		// Token: 0x04000722 RID: 1826
		public AsyncCallback requestCB = new AsyncCallback(Http.GetRequestStreamCallback);

		// Token: 0x04000723 RID: 1827
		public AsyncCallback uploadCB = new AsyncCallback(Http._SendCB);

		// Token: 0x04000724 RID: 1828
		public AsyncCallback responseCB = new AsyncCallback(Http.GetResponseCallback);

		// Token: 0x04000725 RID: 1829
		public Action<string> timeoutCB;
	}
}
