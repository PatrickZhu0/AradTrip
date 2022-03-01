using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000FEA RID: 4074
public class ComNewbieDoubleMove : MonoBehaviour
{
	// Token: 0x06009B77 RID: 39799 RVA: 0x001E1E0B File Offset: 0x001E020B
	private void Start()
	{
		base.StartCoroutine(this.CheckEnd());
	}

	// Token: 0x06009B78 RID: 39800 RVA: 0x001E1E1C File Offset: 0x001E021C
	private IEnumerator CheckEnd()
	{
		while (!FrameSync.instance.bInMoveMode)
		{
			yield return Yielders.EndOfFrame;
		}
		BattleMain.instance.GetDungeonManager().ResumeFight(true, string.Empty, false);
		yield return Yielders.GetWaitForSeconds(this.delayRemove);
		Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04005502 RID: 21762
	public float delayRemove;
}
