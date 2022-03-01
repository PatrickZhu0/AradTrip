using System;

// Token: 0x020041CB RID: 16843
public struct BeStateData
{
	// Token: 0x0601739A RID: 95130 RVA: 0x007236F0 File Offset: 0x00721AF0
	public BeStateData(int iState, int iStateData, int fStateData2, int fStateData3, int iExTag, int fTimeout = 0, bool timeOutForce = false)
	{
		this._State = iState;
		this._StateData = iStateData;
		this._StateData2 = fStateData2;
		this._StateData3 = fStateData3;
		this._ExTag = iExTag;
		this._timeout = fTimeout;
		this._timeoutForce = timeOutForce;
		this.isForceSwitch = false;
	}

	// Token: 0x0601739B RID: 95131 RVA: 0x00723744 File Offset: 0x00721B44
	public BeStateData(int iState = 0, int iStateData = 0)
	{
		this._State = iState;
		this._StateData = iStateData;
		this._StateData2 = 0;
		this._StateData3 = 0;
		this._ExTag = 0;
		this._timeout = 0;
		this._timeoutForce = false;
		this.isForceSwitch = false;
	}

	// Token: 0x04010B90 RID: 68496
	public int _State;

	// Token: 0x04010B91 RID: 68497
	public int _StateData;

	// Token: 0x04010B92 RID: 68498
	public VInt _StateData2;

	// Token: 0x04010B93 RID: 68499
	public VInt _StateData3;

	// Token: 0x04010B94 RID: 68500
	public int _ExTag;

	// Token: 0x04010B95 RID: 68501
	public int _timeout;

	// Token: 0x04010B96 RID: 68502
	public bool _timeoutForce;

	// Token: 0x04010B97 RID: 68503
	public bool isForceSwitch;
}
