using System;
using UnityEngine;

// Token: 0x02004B6E RID: 19310
[Serializable]
public class DTransportDoor : DRegionInfo, ISceneTransportDoorData
{
	// Token: 0x0601C64F RID: 116303 RVA: 0x0089DEB0 File Offset: 0x0089C2B0
	public void UpdateData()
	{
	}

	// Token: 0x0601C650 RID: 116304 RVA: 0x0089DEB2 File Offset: 0x0089C2B2
	public Vector3 GetDoorTransCenter()
	{
		return Vector3.zero;
	}

	// Token: 0x0601C651 RID: 116305 RVA: 0x0089DEBC File Offset: 0x0089C2BC
	public override void Duplicate(DEntityInfo info)
	{
		base.Duplicate(info);
		DTransportDoor dtransportDoor = info as DTransportDoor;
		if (dtransportDoor != null)
		{
			this.doortype = dtransportDoor.doortype;
			this.nextsceneid = dtransportDoor.nextsceneid;
			this.townscenepath = dtransportDoor.townscenepath;
			this.nextdoortype = dtransportDoor.nextdoortype;
			this.birthposition = dtransportDoor.birthposition;
			this.mBirthPos = dtransportDoor.mBirthPos;
			this.bInitBirthPos = dtransportDoor.bInitBirthPos;
		}
	}

	// Token: 0x0601C652 RID: 116306 RVA: 0x0089DF31 File Offset: 0x0089C331
	public TransportDoorType GetDoortype()
	{
		return this.doortype;
	}

	// Token: 0x0601C653 RID: 116307 RVA: 0x0089DF39 File Offset: 0x0089C339
	public bool IsEggDoor()
	{
		return this.isEggDoor;
	}

	// Token: 0x0601C654 RID: 116308 RVA: 0x0089DF41 File Offset: 0x0089C341
	public int GetNextsceneid()
	{
		return this.nextsceneid;
	}

	// Token: 0x0601C655 RID: 116309 RVA: 0x0089DF49 File Offset: 0x0089C349
	public string GetTownscenepath()
	{
		return this.townscenepath;
	}

	// Token: 0x0601C656 RID: 116310 RVA: 0x0089DF51 File Offset: 0x0089C351
	public TransportDoorType GetNextdoortype()
	{
		return this.nextdoortype;
	}

	// Token: 0x0601C657 RID: 116311 RVA: 0x0089DF59 File Offset: 0x0089C359
	public VInt3 GetBirthposition()
	{
		if (!this.bInitBirthPos)
		{
			this.mBirthPos = new VInt3(this.birthposition);
			this.bInitBirthPos = true;
		}
		return this.mBirthPos;
	}

	// Token: 0x0601C658 RID: 116312 RVA: 0x0089DF84 File Offset: 0x0089C384
	public ISceneRegionInfoData GetRegionInfo()
	{
		return this;
	}

	// Token: 0x0601C659 RID: 116313 RVA: 0x0089DF87 File Offset: 0x0089C387
	public void SetBirthposition(VInt3 pos)
	{
		if (!this.bInitBirthPos)
		{
			this.bInitBirthPos = true;
		}
		this.mBirthPos = pos;
	}

	// Token: 0x04013879 RID: 79993
	public TransportDoorType doortype;

	// Token: 0x0401387A RID: 79994
	public bool isEggDoor;

	// Token: 0x0401387B RID: 79995
	public int nextsceneid;

	// Token: 0x0401387C RID: 79996
	public string townscenepath;

	// Token: 0x0401387D RID: 79997
	public TransportDoorType nextdoortype;

	// Token: 0x0401387E RID: 79998
	public Vector3 birthposition;

	// Token: 0x0401387F RID: 79999
	[NonSerialized]
	private VInt3 mBirthPos;

	// Token: 0x04013880 RID: 80000
	[NonSerialized]
	private bool bInitBirthPos;
}
