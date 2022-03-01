using System;
using UnityEngine;

// Token: 0x02004933 RID: 18739
[AddComponentMenu("EasyTouch Controls/Set Direct Action Transform ")]
public class ETCSetDirectActionTransform : MonoBehaviour
{
	// Token: 0x0601AF3A RID: 110394 RVA: 0x008497A8 File Offset: 0x00847BA8
	private void Start()
	{
		if (!string.IsNullOrEmpty(this.axisName1))
		{
			ETCInput.SetAxisDirecTransform(this.axisName1, base.transform);
		}
		if (!string.IsNullOrEmpty(this.axisName2))
		{
			ETCInput.SetAxisDirecTransform(this.axisName2, base.transform);
		}
	}

	// Token: 0x04012C37 RID: 76855
	public string axisName1;

	// Token: 0x04012C38 RID: 76856
	public string axisName2;
}
