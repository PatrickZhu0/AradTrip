using System;
using UnityEngine;

// Token: 0x02004AF8 RID: 19192
public class ComboTeachData : ScriptableObject
{
	// Token: 0x04013786 RID: 79750
	public string dataName;

	// Token: 0x04013787 RID: 79751
	public int roomID;

	// Token: 0x04013788 RID: 79752
	public bool Advanced;

	// Token: 0x04013789 RID: 79753
	public string buffID;

	// Token: 0x0401378A RID: 79754
	public Vector3 playerPos = default(Vector3);

	// Token: 0x0401378B RID: 79755
	public Vector3 monsterPos = default(Vector3);

	// Token: 0x0401378C RID: 79756
	public ComboData[] datas = new ComboData[0];
}
