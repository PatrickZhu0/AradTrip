using System;
using GameClient;
using UnityEngine;

// Token: 0x02004608 RID: 17928
public class NpcArrowComponent : MonoBehaviour
{
	// Token: 0x06019331 RID: 103217 RVA: 0x007F8BDF File Offset: 0x007F6FDF
	private void Start()
	{
	}

	// Token: 0x06019332 RID: 103218 RVA: 0x007F8BE1 File Offset: 0x007F6FE1
	public void Active()
	{
		base.gameObject.SetActive(true);
	}

	// Token: 0x06019333 RID: 103219 RVA: 0x007F8BEF File Offset: 0x007F6FEF
	public void DeActive()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x06019334 RID: 103220 RVA: 0x007F8C00 File Offset: 0x007F7000
	public static void ActiveNpcArrow(int iNpcID)
	{
		ClientSystemTown targetSystem = ClientSystem.GetTargetSystem<ClientSystemTown>();
		if (targetSystem != null)
		{
			BeTownNPC townNpcByNpcId = targetSystem.GetTownNpcByNpcId(iNpcID);
			if (townNpcByNpcId != null && townNpcByNpcId.GraphicActor != null)
			{
				townNpcByNpcId.GraphicActor.ActiveArrow();
			}
		}
	}

	// Token: 0x06019335 RID: 103221 RVA: 0x007F8C40 File Offset: 0x007F7040
	public static void DeActiveNpcArrow(int iNpcID)
	{
		ClientSystemTown targetSystem = ClientSystem.GetTargetSystem<ClientSystemTown>();
		if (targetSystem != null)
		{
			BeTownNPC townNpcByNpcId = targetSystem.GetTownNpcByNpcId(iNpcID);
			if (townNpcByNpcId != null && townNpcByNpcId.GraphicActor != null)
			{
				townNpcByNpcId.GraphicActor.DeActiveArrow();
			}
		}
	}
}
