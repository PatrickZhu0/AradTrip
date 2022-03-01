using System;
using UnityEngine;

// Token: 0x02000EFC RID: 3836
public class ComItemHiddenShow : MonoBehaviour
{
	// Token: 0x06009612 RID: 38418 RVA: 0x001C618D File Offset: 0x001C458D
	private void Start()
	{
		this._updateObjectState();
	}

	// Token: 0x06009613 RID: 38419 RVA: 0x001C6198 File Offset: 0x001C4598
	public void ChangeState()
	{
		this.mGlobalState = !this.mGlobalState;
		for (int i = 0; i < this.mObjectList.Length; i++)
		{
			if (i < this.mObjectState.Length)
			{
				this.mObjectState[i] = !this.mObjectState[i];
			}
		}
		this._updateObjectState();
	}

	// Token: 0x06009614 RID: 38420 RVA: 0x001C61F4 File Offset: 0x001C45F4
	private void _updateObjectState()
	{
		for (int i = 0; i < this.mObjectList.Length; i++)
		{
			GameObject gameObject = this.mObjectList[i];
			bool active = this.mGlobalState;
			if (i < this.mObjectState.Length)
			{
				active = this.mObjectState[i];
			}
			gameObject.SetActive(active);
		}
	}

	// Token: 0x04004CEA RID: 19690
	public bool mGlobalState;

	// Token: 0x04004CEB RID: 19691
	public GameObject[] mObjectList = new GameObject[0];

	// Token: 0x04004CEC RID: 19692
	public bool[] mObjectState = new bool[0];
}
