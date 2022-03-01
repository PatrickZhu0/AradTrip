using System;
using System.Collections;
using LitJson;
using UnityEngine;
using XUPorterJSON;

namespace GameClient
{
	// Token: 0x02000E33 RID: 3635
	public class BaseWaitHttpRequest : BaseCustomEnum<BaseWaitHttpRequest.eState>, IEnumerator
	{
		// Token: 0x06009124 RID: 37156 RVA: 0x001ADACC File Offset: 0x001ABECC
		public BaseWaitHttpRequest()
		{
			this.mResult = BaseWaitHttpRequest.eState.None;
			this.mTickTimeOut = (this.mTimeOut = 3000);
			this.mGapTime = 1000;
			this.mReconnectCnt = 3;
		}

		// Token: 0x170018E1 RID: 6369
		// (get) Token: 0x06009125 RID: 37157 RVA: 0x001ADB0C File Offset: 0x001ABF0C
		// (set) Token: 0x06009126 RID: 37158 RVA: 0x001ADB14 File Offset: 0x001ABF14
		public string url
		{
			get
			{
				return this.mUrl;
			}
			set
			{
				if (this.mResult == BaseWaitHttpRequest.eState.None)
				{
					this.mUrl = value;
					this.mWWW = new WWW(this.mUrl);
				}
				else
				{
					Debug.LogFormat("[BaseWaitHttpRequest] 错误状态 {0}, 无法设置Url地址 {1}", new object[]
					{
						this.mResult,
						value
					});
				}
			}
		}

		// Token: 0x170018E2 RID: 6370
		// (get) Token: 0x06009127 RID: 37159 RVA: 0x001ADB6B File Offset: 0x001ABF6B
		// (set) Token: 0x06009128 RID: 37160 RVA: 0x001ADB74 File Offset: 0x001ABF74
		public int timeout
		{
			get
			{
				return this.mTimeOut;
			}
			set
			{
				if (this.mResult == BaseWaitHttpRequest.eState.None)
				{
					this.mTimeOut = value;
					this.mTickTimeOut = value;
				}
				else
				{
					Debug.LogFormat("[BaseWaitHttpRequest] 错误状态 {0}, 无法设置超时时间 {1} ms", new object[]
					{
						this.mResult,
						value
					});
				}
			}
		}

		// Token: 0x170018E3 RID: 6371
		// (get) Token: 0x06009129 RID: 37161 RVA: 0x001ADBC8 File Offset: 0x001ABFC8
		// (set) Token: 0x0600912A RID: 37162 RVA: 0x001ADBD0 File Offset: 0x001ABFD0
		public int gaptime
		{
			get
			{
				return this.mGapTime;
			}
			set
			{
				if (this.mResult == BaseWaitHttpRequest.eState.None)
				{
					this.mGapTime = value;
				}
				else
				{
					Debug.LogFormat("[BaseWaitHttpRequest] 错误状态 {0}, 无法设置间隔时间 {1} ms", new object[]
					{
						this.mResult,
						value
					});
				}
			}
		}

		// Token: 0x170018E4 RID: 6372
		// (get) Token: 0x0600912B RID: 37163 RVA: 0x001ADC10 File Offset: 0x001AC010
		// (set) Token: 0x0600912C RID: 37164 RVA: 0x001ADC18 File Offset: 0x001AC018
		public int reconnectCnt
		{
			get
			{
				return this.mReconnectCnt;
			}
			set
			{
				if (this.mResult == BaseWaitHttpRequest.eState.None)
				{
					this.mReconnectCnt = value;
				}
				else
				{
					Debug.LogFormat("[BaseWaitHttpRequest] 错误状态 {0}, 无法设置重试次数 {1} 次", new object[]
					{
						this.mResult,
						value
					});
				}
			}
		}

		// Token: 0x0600912D RID: 37165 RVA: 0x001ADC58 File Offset: 0x001AC058
		protected void SetRequestWaitResult()
		{
		}

		// Token: 0x0600912E RID: 37166 RVA: 0x001ADC5A File Offset: 0x001AC05A
		public byte[] GetResultBytes()
		{
			if (this.mResult == BaseWaitHttpRequest.eState.Success && this.mWWW != null)
			{
				return this.mWWW.bytes;
			}
			return null;
		}

		// Token: 0x0600912F RID: 37167 RVA: 0x001ADC80 File Offset: 0x001AC080
		public string GetResultString()
		{
			if (this.mResult == BaseWaitHttpRequest.eState.Success && this.mWWW != null)
			{
				return this.mWWW.text;
			}
			return null;
		}

		// Token: 0x06009130 RID: 37168 RVA: 0x001ADCA8 File Offset: 0x001AC0A8
		public Hashtable GetResultHashJson()
		{
			Debug.LogFormat("[BaseWaitHttpRequest] 获取值 url {0}, {1}", new object[]
			{
				this.url,
				base.GetResult()
			});
			if (base.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				try
				{
					return this.mWWW.text.hashtableFromJson();
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString());
				}
			}
			return null;
		}

		// Token: 0x06009131 RID: 37169 RVA: 0x001ADD24 File Offset: 0x001AC124
		public T GetResultJson<T>()
		{
			try
			{
				return JsonMapper.ToObject<T>(this.GetResultString());
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[BaseWaitHttpRequest] Json解析出错 {0}", new object[]
				{
					ex.ToString()
				});
			}
			return default(T);
		}

		// Token: 0x06009132 RID: 37170 RVA: 0x001ADD7C File Offset: 0x001AC17C
		public ArrayList GetResultJson()
		{
			Debug.LogFormat("[BaseWaitHttpRequest] 获取值 url {0}, {1}", new object[]
			{
				this.url,
				base.GetResult()
			});
			try
			{
				return this.mWWW.text.arrayListFromJson();
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
			return null;
		}

		// Token: 0x06009133 RID: 37171 RVA: 0x001ADDEC File Offset: 0x001AC1EC
		public bool MoveNext()
		{
			if (this.mWWW == null)
			{
				return false;
			}
			switch (this.mResult)
			{
			case BaseWaitHttpRequest.eState.None:
				this.mResult = BaseWaitHttpRequest.eState.Wait;
				break;
			case BaseWaitHttpRequest.eState.Wait:
				if (this._isTimeUpInCurState())
				{
					if (this._tryNextReconnect())
					{
						Debug.LogFormat("[BaseWaitHttpRequest] HTTP地址{0}超时, 等待下一次连接, 剩余{1}次", new object[]
						{
							this.url,
							this.reconnectCnt
						});
						this.mResult = BaseWaitHttpRequest.eState.GapWait;
					}
					else
					{
						this.mResult = BaseWaitHttpRequest.eState.TimeOut;
					}
				}
				else if (this.mWWW.isDone)
				{
					if (!string.IsNullOrEmpty(this.mWWW.error))
					{
						if (this._tryNextReconnect())
						{
							Debug.LogFormat("[BaseWaitHttpRequest] HTTP地址{0}出错({1}), 等待下一次连接 ", new object[]
							{
								this.url,
								this.mWWW.error
							});
							this.mResult = BaseWaitHttpRequest.eState.GapWait;
						}
						else
						{
							this.mResult = BaseWaitHttpRequest.eState.Error;
						}
					}
					else if (this.mWWW.responseHeaders.Count > 0)
					{
						this.mResult = BaseWaitHttpRequest.eState.Success;
					}
				}
				break;
			case BaseWaitHttpRequest.eState.GapWait:
				if (this._isTimeUpInCurState())
				{
					this._clearWWW();
					this.mTickTimeOut = this.mTimeOut;
					this.mWWW = new WWW(this.mUrl);
					this.mResult = BaseWaitHttpRequest.eState.Wait;
					Debug.LogFormat("[BaseWaitHttpRequest] HTTP地址{0}, 重新请求地址, 设置超时时间: {1}", new object[]
					{
						this.url,
						this.mTickTimeOut
					});
				}
				break;
			case BaseWaitHttpRequest.eState.Success:
				Debug.LogFormat("[BaseWaitHttpRequest] HTTP地址{0}, 成功", new object[]
				{
					this.url
				});
				return false;
			case BaseWaitHttpRequest.eState.Error:
				Debug.LogFormat("[BaseWaitHttpRequest] HTTP地址{0}, 错误:{1}", new object[]
				{
					this.url,
					this.mWWW.error
				});
				this._clearWWW();
				return false;
			case BaseWaitHttpRequest.eState.TimeOut:
				Debug.LogFormat("[BaseWaitHttpRequest] HTTP地址{0}, 超时", new object[]
				{
					this.url
				});
				this._clearWWW();
				return true;
			}
			return true;
		}

		// Token: 0x06009134 RID: 37172 RVA: 0x001ADFEF File Offset: 0x001AC3EF
		private bool _isTimeUpInCurState()
		{
			this.mTickTimeOut -= (int)(Time.unscaledDeltaTime * 1000f);
			return this.mTickTimeOut < 0;
		}

		// Token: 0x06009135 RID: 37173 RVA: 0x001AE013 File Offset: 0x001AC413
		private bool _tryNextReconnect()
		{
			if (this.mReconnectCnt > 0)
			{
				this.mTickTimeOut = this.mGapTime;
				this.mReconnectCnt--;
				return true;
			}
			return false;
		}

		// Token: 0x06009136 RID: 37174 RVA: 0x001AE03E File Offset: 0x001AC43E
		private void _clearWWW()
		{
			if (this.mWWW != null)
			{
				this.mWWW.Dispose();
			}
			this.mWWW = null;
		}

		// Token: 0x06009137 RID: 37175 RVA: 0x001AE05D File Offset: 0x001AC45D
		public void Reset()
		{
			this._clearWWW();
			this.mWWW = null;
			this.mUrl = null;
		}

		// Token: 0x170018E5 RID: 6373
		// (get) Token: 0x06009138 RID: 37176 RVA: 0x001AE073 File Offset: 0x001AC473
		public object Current
		{
			get
			{
				return null;
			}
		}

		// Token: 0x04004875 RID: 18549
		private string mUrl;

		// Token: 0x04004876 RID: 18550
		private WWW mWWW;

		// Token: 0x04004877 RID: 18551
		private int mReconnectCnt;

		// Token: 0x04004878 RID: 18552
		private int mTimeOut;

		// Token: 0x04004879 RID: 18553
		private int mTickTimeOut;

		// Token: 0x0400487A RID: 18554
		private int mGapTime;

		// Token: 0x0400487B RID: 18555
		public const int kDefaultTimeOut = 3000;

		// Token: 0x0400487C RID: 18556
		public const int kDefaultGapTimeOut = 1000;

		// Token: 0x0400487D RID: 18557
		public const int kDefaultReconnectCount = 3;

		// Token: 0x02000E34 RID: 3636
		public enum eState
		{
			// Token: 0x0400487F RID: 18559
			None,
			// Token: 0x04004880 RID: 18560
			Wait,
			// Token: 0x04004881 RID: 18561
			GapWait,
			// Token: 0x04004882 RID: 18562
			Success,
			// Token: 0x04004883 RID: 18563
			Error,
			// Token: 0x04004884 RID: 18564
			TimeOut
		}
	}
}
