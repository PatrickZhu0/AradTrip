using System;

// Token: 0x020040FC RID: 16636
public class BDStateStackOP : BDEventBase
{
	// Token: 0x06016A65 RID: 92773 RVA: 0x006DD4BD File Offset: 0x006DB8BD
	public BDStateStackOP(int iOP, int iState, int iStateData, float fStateData2, float fStateData3, int iExTag)
	{
		this._op = iOP;
		this._state = iState;
		this._statedata = iStateData;
		this._statedata2 = VInt.Float2VIntValue(fStateData2);
		this._statedata3 = VInt.Float2VIntValue(fStateData3);
		this._extag = iExTag;
	}

	// Token: 0x06016A66 RID: 92774 RVA: 0x006DD4FC File Offset: 0x006DB8FC
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		if (pkEntity == null)
		{
			return;
		}
		if (pkEntity.actionLooped)
		{
			return;
		}
		switch (this._op)
		{
		case 0:
			pkEntity.sgPushState(new BeStateData(this._state, this._statedata, this._statedata2, this._statedata3, this._extag, 0, false));
			break;
		case 1:
			pkEntity.sgPopState();
			break;
		case 2:
			pkEntity.sgClearStateStack();
			break;
		case 3:
			pkEntity.sgLocomoteState();
			break;
		}
	}

	// Token: 0x04010243 RID: 66115
	public int _op;

	// Token: 0x04010244 RID: 66116
	public int _state;

	// Token: 0x04010245 RID: 66117
	public int _statedata;

	// Token: 0x04010246 RID: 66118
	public int _extag;

	// Token: 0x04010247 RID: 66119
	public int _statedata2;

	// Token: 0x04010248 RID: 66120
	public int _statedata3;
}
