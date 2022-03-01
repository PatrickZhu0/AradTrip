using System;
using System.Collections;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E3B RID: 3643
	public class ThreeStepProcess : BaseCustomEnum<ThreeStepProcess.eResult>, IEnumerator
	{
		// Token: 0x0600915D RID: 37213 RVA: 0x001AE860 File Offset: 0x001ACC60
		public ThreeStepProcess(string tag, IEnumeratorManager processManager, IEnumerator process, IEnumerator start = null, IEnumerator end = null)
		{
			this.mManager = processManager;
			this.mTag = tag;
			this.mErrorHandle = new ThreeStepProcess.ErrorProcessHandle(this._commonError);
			this.mProcessList[1] = ((start != null) ? start : this._commonStart());
			this.mProcessList[2] = process;
			this.mProcessList[3] = ((end != null) ? end : this._commonEnd());
		}

		// Token: 0x170018E6 RID: 6374
		// (get) Token: 0x0600915E RID: 37214 RVA: 0x001AE910 File Offset: 0x001ACD10
		// (set) Token: 0x0600915F RID: 37215 RVA: 0x001AE918 File Offset: 0x001ACD18
		private ThreeStepProcess.eState state
		{
			get
			{
				return this.mState;
			}
			set
			{
				this.mLastState = this.mState;
				this.mState = value;
			}
		}

		// Token: 0x170018E7 RID: 6375
		// (get) Token: 0x06009160 RID: 37216 RVA: 0x001AE92D File Offset: 0x001ACD2D
		private ThreeStepProcess.eState lastState
		{
			get
			{
				return this.mLastState;
			}
		}

		// Token: 0x06009161 RID: 37217 RVA: 0x001AE935 File Offset: 0x001ACD35
		public void SetErrorProcessHandle(ThreeStepProcess.ErrorProcessHandle handle)
		{
			if (this.mState == ThreeStepProcess.eState.None && handle != null)
			{
				this.mErrorHandle = handle;
			}
		}

		// Token: 0x06009162 RID: 37218 RVA: 0x001AE950 File Offset: 0x001ACD50
		private IEnumerator _commonStart()
		{
			yield break;
		}

		// Token: 0x06009163 RID: 37219 RVA: 0x001AE96C File Offset: 0x001ACD6C
		private IEnumerator _commonEnd()
		{
			yield break;
		}

		// Token: 0x06009164 RID: 37220 RVA: 0x001AE988 File Offset: 0x001ACD88
		private IEnumerator _commonError(eEnumError errorType, string errorMsg)
		{
			Logger.LogErrorFormat("[3step] {0} 通用异常处理流程 {1} {2}", new object[]
			{
				this.mTag,
				errorMsg,
				errorType
			});
			yield break;
		}

		// Token: 0x06009165 RID: 37221 RVA: 0x001AE9B4 File Offset: 0x001ACDB4
		private bool _currentProceesIsRunning()
		{
			if (this.lastState != ThreeStepProcess.eState.None && this.lastState != ThreeStepProcess.eState.onIterEnumrator && this.lastState != ThreeStepProcess.eState.onFinish)
			{
				IEnumerator iter = this.mProcessList[(int)this.lastState];
				return this.mManager.IsEnumeratorRunning(iter);
			}
			return false;
		}

		// Token: 0x06009166 RID: 37222 RVA: 0x001AEA04 File Offset: 0x001ACE04
		private bool _currentProceesIsError()
		{
			bool result = false;
			if (this.lastState != ThreeStepProcess.eState.None && this.lastState != ThreeStepProcess.eState.onIterEnumrator && this.lastState != ThreeStepProcess.eState.onFinish)
			{
				IEnumerator iter = this.mProcessList[(int)this.lastState];
				result = this.mManager.IsEnumeratorError(iter);
			}
			return result;
		}

		// Token: 0x06009167 RID: 37223 RVA: 0x001AEA54 File Offset: 0x001ACE54
		private void _updateCurrentProceesValue()
		{
			this.mCurrentValue = null;
			if (this.lastState != ThreeStepProcess.eState.None && this.lastState != ThreeStepProcess.eState.onIterEnumrator && this.lastState != ThreeStepProcess.eState.onFinish)
			{
				IEnumerator iter = this.mProcessList[(int)this.lastState];
				this.mCurrentValue = this.mManager.GetEnumeratorCurrent(iter);
			}
			if (!(this.mCurrentValue is YieldInstruction))
			{
				this.mCurrentValue = null;
			}
		}

		// Token: 0x06009168 RID: 37224 RVA: 0x001AEAC4 File Offset: 0x001ACEC4
		private void _updateErrorProcess()
		{
			if (this.lastState != ThreeStepProcess.eState.None && this.lastState != ThreeStepProcess.eState.onIterEnumrator && this.lastState != ThreeStepProcess.eState.onFinish)
			{
				IEnumerator iter = this.mProcessList[(int)this.lastState];
				eEnumError enumeratorErrorType = this.mManager.GetEnumeratorErrorType(iter, false);
				string enumeratorError = this.mManager.GetEnumeratorError(iter, true);
				try
				{
					if (this.mErrorHandle != null)
					{
						this.mProcessList[0] = this.mErrorHandle(enumeratorErrorType, enumeratorError);
					}
				}
				catch
				{
					this.mProcessList[0] = this._commonError(enumeratorErrorType, enumeratorError);
				}
			}
		}

		// Token: 0x06009169 RID: 37225 RVA: 0x001AEB6C File Offset: 0x001ACF6C
		private void _beforeProcess(ThreeStepProcess.eState curstate)
		{
			if (curstate != ThreeStepProcess.eState.None && curstate != ThreeStepProcess.eState.onIterEnumrator && curstate != ThreeStepProcess.eState.onFinish)
			{
				IEnumerator enumerator = this.mProcessList[(int)curstate];
				if (enumerator != null)
				{
					this.mManager.AddEnumerator(enumerator, this);
				}
			}
		}

		// Token: 0x0600916A RID: 37226 RVA: 0x001AEBAC File Offset: 0x001ACFAC
		public bool MoveNext()
		{
			if (this.mManager == null)
			{
				return false;
			}
			ThreeStepProcess.eState state = this.state;
			switch (state + 1)
			{
			case ThreeStepProcess.eState.onError:
				this.state = ThreeStepProcess.eState.onStart;
				break;
			case ThreeStepProcess.eState.onStart:
			case ThreeStepProcess.eState.onProcess:
			case ThreeStepProcess.eState.onEnd:
			case ThreeStepProcess.eState.onFinish:
				this._beforeProcess(this.state);
				this.state = ThreeStepProcess.eState.onIterEnumrator;
				break;
			case ThreeStepProcess.eState.onIterEnumrator:
				return false;
			case (ThreeStepProcess.eState)6:
				if (this.lastState != ThreeStepProcess.eState.onError && this._currentProceesIsError())
				{
					this._updateErrorProcess();
					this.state = ThreeStepProcess.eState.onError;
				}
				else if (!this._currentProceesIsRunning())
				{
					this.state = this.mProcessNextStep[(int)this.lastState];
				}
				break;
			}
			this._updateCurrentProceesValue();
			return true;
		}

		// Token: 0x0600916B RID: 37227 RVA: 0x001AEC6E File Offset: 0x001AD06E
		private void _setNull()
		{
			this.mCurrentValue = null;
			this.mErrorHandle = null;
			this.mProcessList[0] = null;
			this.mProcessList[1] = null;
			this.mProcessList[2] = null;
			this.mProcessList[3] = null;
		}

		// Token: 0x0600916C RID: 37228 RVA: 0x001AECA2 File Offset: 0x001AD0A2
		public void Reset()
		{
			this.mState = ThreeStepProcess.eState.None;
			this.mLastState = ThreeStepProcess.eState.None;
			this.mResult = ThreeStepProcess.eResult.None;
			this._setNull();
		}

		// Token: 0x170018E8 RID: 6376
		// (get) Token: 0x0600916D RID: 37229 RVA: 0x001AECBF File Offset: 0x001AD0BF
		public object Current
		{
			get
			{
				return this.mCurrentValue;
			}
		}

		// Token: 0x04004890 RID: 18576
		private IEnumeratorManager mManager;

		// Token: 0x04004891 RID: 18577
		private ThreeStepProcess.eState mState = ThreeStepProcess.eState.None;

		// Token: 0x04004892 RID: 18578
		private ThreeStepProcess.eState mLastState = ThreeStepProcess.eState.None;

		// Token: 0x04004893 RID: 18579
		private string mTag = string.Empty;

		// Token: 0x04004894 RID: 18580
		private object mCurrentValue;

		// Token: 0x04004895 RID: 18581
		private ThreeStepProcess.ErrorProcessHandle mErrorHandle;

		// Token: 0x04004896 RID: 18582
		private IEnumerator[] mProcessList = new IEnumerator[4];

		// Token: 0x04004897 RID: 18583
		private ThreeStepProcess.eState[] mProcessNextStep = new ThreeStepProcess.eState[]
		{
			ThreeStepProcess.eState.onEnd,
			ThreeStepProcess.eState.onProcess,
			ThreeStepProcess.eState.onEnd,
			ThreeStepProcess.eState.onFinish
		};

		// Token: 0x02000E3C RID: 3644
		// (Invoke) Token: 0x0600916F RID: 37231
		public delegate IEnumerator ErrorProcessHandle(eEnumError errorType, string errorMsg);

		// Token: 0x02000E3D RID: 3645
		public enum eResult
		{
			// Token: 0x04004899 RID: 18585
			None,
			// Token: 0x0400489A RID: 18586
			Success,
			// Token: 0x0400489B RID: 18587
			FailStart,
			// Token: 0x0400489C RID: 18588
			FailProcess,
			// Token: 0x0400489D RID: 18589
			FailEnd,
			// Token: 0x0400489E RID: 18590
			FailError
		}

		// Token: 0x02000E3E RID: 3646
		private enum eState
		{
			// Token: 0x040048A0 RID: 18592
			None = -1,
			// Token: 0x040048A1 RID: 18593
			onError,
			// Token: 0x040048A2 RID: 18594
			onStart,
			// Token: 0x040048A3 RID: 18595
			onProcess,
			// Token: 0x040048A4 RID: 18596
			onEnd,
			// Token: 0x040048A5 RID: 18597
			onFinish,
			// Token: 0x040048A6 RID: 18598
			onIterEnumrator
		}
	}
}
