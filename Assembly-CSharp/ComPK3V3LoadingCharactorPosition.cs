using System;
using UnityEngine;

// Token: 0x0200004A RID: 74
[ExecuteInEditMode]
public class ComPK3V3LoadingCharactorPosition : MonoBehaviour
{
	// Token: 0x060001BD RID: 445 RVA: 0x0000F6A1 File Offset: 0x0000DAA1
	private void Awake()
	{
		this._init();
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0000F6A9 File Offset: 0x0000DAA9
	private void _init()
	{
		this.mRect = base.GetComponent<RectTransform>();
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0000F6B8 File Offset: 0x0000DAB8
	public void SetTeamType(BattlePlayer.eDungeonPlayerTeamType type)
	{
		if (null == this.mRect)
		{
			return;
		}
		if (type != BattlePlayer.eDungeonPlayerTeamType.eTeamBlue)
		{
			if (type == BattlePlayer.eDungeonPlayerTeamType.eTeamRed)
			{
				this.mRect.localPosition = this.redTeamPosition;
				this.mRect.localScale = this.redTeamScale;
			}
		}
		else
		{
			this.mRect.localPosition = this.blueTeamPosition;
			this.mRect.localScale = this.blueTeamScale;
		}
	}

	// Token: 0x040001AC RID: 428
	[HideInInspector]
	public Vector3 redTeamPosition = Vector3.zero;

	// Token: 0x040001AD RID: 429
	[HideInInspector]
	public Vector3 redTeamScale = Vector3.zero;

	// Token: 0x040001AE RID: 430
	[HideInInspector]
	public Vector3 blueTeamPosition = Vector3.zero;

	// Token: 0x040001AF RID: 431
	[HideInInspector]
	public Vector3 blueTeamScale = Vector3.zero;

	// Token: 0x040001B0 RID: 432
	private RectTransform mRect;
}
