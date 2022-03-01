using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class ControlDoorState : MonoBehaviour
{
	// Token: 0x060012EA RID: 4842 RVA: 0x00064B28 File Offset: 0x00062F28
	private void Awake()
	{
		if (this.doorsEffect == null)
		{
			this.doorsEffect = new GameObject[]
			{
				this.OpenDoorObj_LEFT,
				this.OpenDoorObj_TOP,
				this.OpenDoorObj_RIGHT,
				this.OpenDoorObj_BOTTOM
			};
		}
		this.CloseDoor();
	}

	// Token: 0x060012EB RID: 4843 RVA: 0x00064B78 File Offset: 0x00062F78
	public void OpenDoor(TransportDoorType doorType = TransportDoorType.None)
	{
		if (this.CloseDoorObj)
		{
			if (this.CloseDoorObj != null)
			{
				this.CloseDoorObj.CustomActive(false);
			}
			if (this.OpenDoorObj != null)
			{
				this.OpenDoorObj.CustomActive(true);
			}
			this.SetOpenDoor(doorType);
		}
	}

	// Token: 0x060012EC RID: 4844 RVA: 0x00064BD8 File Offset: 0x00062FD8
	public void CloseDoor()
	{
		if (this.CloseDoorObj != null)
		{
			this.CloseDoorObj.CustomActive(true);
		}
		if (this.OpenDoorObj != null)
		{
			this.OpenDoorObj.CustomActive(false);
		}
		this.SetOpenDoorVisible(false);
	}

	// Token: 0x060012ED RID: 4845 RVA: 0x00064C28 File Offset: 0x00063028
	private void SetOpenDoorVisible(bool flag)
	{
		for (int i = 0; i < this.doorsEffect.Length; i++)
		{
			if (this.doorsEffect[i] != null)
			{
				this.doorsEffect[i].CustomActive(flag);
			}
		}
	}

	// Token: 0x060012EE RID: 4846 RVA: 0x00064C6F File Offset: 0x0006306F
	private void SetOpenDoor(TransportDoorType doorType)
	{
		if (doorType >= TransportDoorType.None)
		{
			return;
		}
		if (this.doorsEffect[(int)doorType] != null)
		{
			this.doorsEffect[(int)doorType].CustomActive(true);
		}
	}

	// Token: 0x060012EF RID: 4847 RVA: 0x00064C9A File Offset: 0x0006309A
	public Vector3 GetRegionPos(TransportDoorType doorType)
	{
		if (this.doorsEffect[(int)doorType] != null)
		{
			return this.doorsEffect[(int)doorType].transform.position;
		}
		return Vector3.zero;
	}

	// Token: 0x04000C80 RID: 3200
	public GameObject CloseDoorObj;

	// Token: 0x04000C81 RID: 3201
	public GameObject OpenDoorObj;

	// Token: 0x04000C82 RID: 3202
	public GameObject OpenDoorObj_TOP;

	// Token: 0x04000C83 RID: 3203
	public GameObject OpenDoorObj_BOTTOM;

	// Token: 0x04000C84 RID: 3204
	public GameObject OpenDoorObj_LEFT;

	// Token: 0x04000C85 RID: 3205
	public GameObject OpenDoorObj_RIGHT;

	// Token: 0x04000C86 RID: 3206
	private GameObject[] doorsEffect;
}
