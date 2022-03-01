using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02001366 RID: 4966
public class ActiveBindRecords : MonoBehaviour
{
	// Token: 0x0600C0DA RID: 49370 RVA: 0x002DB8DE File Offset: 0x002D9CDE
	private void OnDestroy()
	{
		this.m_VarBinders = null;
	}

	// Token: 0x04006CF9 RID: 27897
	public List<ActiveVarBinder> m_VarBinders = new List<ActiveVarBinder>();
}
