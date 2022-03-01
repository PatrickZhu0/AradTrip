using System;
using GameClient;
using UnityEngine;

// Token: 0x0200136D RID: 4973
public class ActiveVarBinder : MonoBehaviour
{
	// Token: 0x0600C107 RID: 49415 RVA: 0x002DD0C5 File Offset: 0x002DB4C5
	private void OnDestroy()
	{
		this.m_OnSuccessTrigger = null;
		this.m_OnFailedTrigger = null;
	}

	// Token: 0x0600C108 RID: 49416 RVA: 0x002DD0D8 File Offset: 0x002DB4D8
	public void RefreshStatus()
	{
		int num;
		if (this.m_eDataSource == ActiveVarBinder.DataSource.DS_TEMPLATE)
		{
			num = DataManager<ActiveManager>.GetInstance().GetTemplateValue(this.m_iDataID, this.m_kKey, 0);
		}
		else
		{
			if (this.m_eDataSource != ActiveVarBinder.DataSource.DS_ACTIVEITEM)
			{
				return;
			}
			num = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(this.m_iDataID, this.m_kKey, 0);
		}
		bool flag = false;
		switch (this.m_eCompareType)
		{
		case ActiveVarBinder.CompareType.CT_GREAT:
			flag = (num > this.m_iCompareValue);
			break;
		case ActiveVarBinder.CompareType.CT_LESS:
			flag = (num < this.m_iCompareValue);
			break;
		case ActiveVarBinder.CompareType.CT_EQUAL:
			flag = (num == this.m_iCompareValue);
			break;
		case ActiveVarBinder.CompareType.CT_GREAT_EQUAL:
			flag = (num >= this.m_iCompareValue);
			break;
		case ActiveVarBinder.CompareType.CT_LESS_EQUAL:
			flag = (num <= this.m_iCompareValue);
			break;
		}
		if (flag)
		{
			if (this.m_OnSuccessTrigger != null && this.m_OnSuccessTrigger.m_TimeEvent != null)
			{
				this.m_OnSuccessTrigger.m_TimeEvent.Invoke();
			}
		}
		else if (this.m_OnFailedTrigger != null && this.m_OnFailedTrigger.m_TimeEvent != null)
		{
			this.m_OnFailedTrigger.m_TimeEvent.Invoke();
		}
	}

	// Token: 0x04006D16 RID: 27926
	public ActiveVarBinder.DataSource m_eDataSource;

	// Token: 0x04006D17 RID: 27927
	public int m_iDataID;

	// Token: 0x04006D18 RID: 27928
	public ActiveVarBinder.CompareType m_eCompareType;

	// Token: 0x04006D19 RID: 27929
	public string m_kKey;

	// Token: 0x04006D1A RID: 27930
	public int m_iCompareValue;

	// Token: 0x04006D1B RID: 27931
	[SerializeField]
	public ConditionTrigger m_OnSuccessTrigger = new ConditionTrigger();

	// Token: 0x04006D1C RID: 27932
	[SerializeField]
	public ConditionTrigger m_OnFailedTrigger = new ConditionTrigger();

	// Token: 0x0200136E RID: 4974
	public enum DataSource
	{
		// Token: 0x04006D1E RID: 27934
		DS_TEMPLATE,
		// Token: 0x04006D1F RID: 27935
		DS_ACTIVEITEM
	}

	// Token: 0x0200136F RID: 4975
	public enum CompareType
	{
		// Token: 0x04006D21 RID: 27937
		CT_GREAT,
		// Token: 0x04006D22 RID: 27938
		CT_LESS,
		// Token: 0x04006D23 RID: 27939
		CT_EQUAL,
		// Token: 0x04006D24 RID: 27940
		CT_GREAT_EQUAL,
		// Token: 0x04006D25 RID: 27941
		CT_LESS_EQUAL
	}
}
