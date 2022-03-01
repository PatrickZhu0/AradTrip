using System;
using GameClient;
using UnityEngine;

// Token: 0x02004624 RID: 17956
internal class TaskGuideModelArrow : MonoBehaviour
{
	// Token: 0x060193BC RID: 103356 RVA: 0x007FB588 File Offset: 0x007F9988
	public void Initialize(BeTownPlayerMain mainPlayer)
	{
		try
		{
			this.mainPlayer = mainPlayer;
			this.goActor = base.transform.parent.gameObject;
			if (this.goActor != null)
			{
				string[] array = new string[]
				{
					"ArrowLeft",
					"ArrowRight",
					"ArrowTop",
					"ArrowBottom"
				};
				for (int i = 0; i < 4; i++)
				{
					this.goArrowArray[i] = Utility.FindChild(array[i], base.transform.gameObject);
				}
				this.orgQuaterion = base.transform.rotation;
				this.orgPosition = base.transform.position;
			}
			this.currentSystem = ClientSystem.GetTargetSystem<ClientSystemTown>();
		}
		catch (Exception ex)
		{
		}
		this.EndTrace();
	}

	// Token: 0x060193BD RID: 103357 RVA: 0x007FB668 File Offset: 0x007F9A68
	public void BeginTrace(int iNpcID, Vector3 target)
	{
		if (this.iNpcID != 0)
		{
			NpcArrowComponent.DeActiveNpcArrow(this.iNpcID);
			this.iNpcID = 0;
		}
		this.bNeedUpdate = true;
		this.target = target;
		this.iNpcID = iNpcID;
	}

	// Token: 0x060193BE RID: 103358 RVA: 0x007FB69C File Offset: 0x007F9A9C
	public void EndTrace()
	{
		this.bNeedUpdate = false;
		for (int i = 0; i < this.goArrowArray.Length; i++)
		{
			if (this.goArrowArray[i] && this.goArrowArray[i].activeSelf)
			{
				this.goArrowArray[i].SetActive(false);
			}
		}
		NpcArrowComponent.DeActiveNpcArrow(this.iNpcID);
		this.iNpcID = 0;
		this.target = Vector3.zero;
	}

	// Token: 0x060193BF RID: 103359 RVA: 0x007FB718 File Offset: 0x007F9B18
	private void Update()
	{
		if (!this.bNeedUpdate)
		{
			return;
		}
		for (int i = 0; i < this.goArrowArray.Length; i++)
		{
			if (this.goArrowArray[i] && this.goArrowArray[i].activeSelf)
			{
				this.goArrowArray[i].SetActive(false);
			}
		}
		if (this.mainPlayer == null)
		{
			return;
		}
		Vector3 vector = this.target - this.mainPlayer.ActorData.MoveData.Position;
		if (Mathf.Abs(vector.x) > Mathf.Abs(vector.z))
		{
			if (vector.x > 0f)
			{
				this.m_eDir = TaskGuideArrow.TaskGuideDir.TGD_RIGHT;
			}
			else
			{
				this.m_eDir = TaskGuideArrow.TaskGuideDir.TGD_LEFT;
			}
		}
		else if (vector.z > 0f)
		{
			this.m_eDir = TaskGuideArrow.TaskGuideDir.TGD_TOP;
		}
		else
		{
			this.m_eDir = TaskGuideArrow.TaskGuideDir.TGD_BOTTOM;
		}
		base.transform.localScale = new Vector3(1f / this.goActor.transform.localScale.x, 1f, 1f);
		base.transform.rotation = Quaternion.Euler(Vector3.zero);
		base.transform.position = this.goActor.transform.position;
		if (this.m_eDir != TaskGuideArrow.TaskGuideDir.TGD_INVALID && this.goArrowArray[(int)this.m_eDir] != null && !this.goArrowArray[(int)this.m_eDir].activeSelf)
		{
			this.goArrowArray[(int)this.m_eDir].SetActive(true);
		}
		if (this.iNpcID != 0)
		{
			BeTownNPC townNpcByNpcId = this.currentSystem.GetTownNpcByNpcId(this.iNpcID);
			if (townNpcByNpcId != null && Mathf.Abs((townNpcByNpcId.ActorData.MoveData.Position - this.mainPlayer.ActorData.MoveData.Position).x) <= this.fMaxDistance)
			{
				for (int j = 0; j < this.goArrowArray.Length; j++)
				{
					if (this.goArrowArray[j])
					{
						this.goArrowArray[j].SetActive(false);
					}
				}
				NpcArrowComponent.ActiveNpcArrow(this.iNpcID);
			}
			else
			{
				NpcArrowComponent.DeActiveNpcArrow(this.iNpcID);
			}
		}
	}

	// Token: 0x0401217F RID: 74111
	private GameObject[] goArrowArray = new GameObject[4];

	// Token: 0x04012180 RID: 74112
	private Quaternion orgQuaterion = Quaternion.Euler(Vector3.zero);

	// Token: 0x04012181 RID: 74113
	private Vector3 orgPosition = Vector3.zero;

	// Token: 0x04012182 RID: 74114
	private ClientSystemTown currentSystem;

	// Token: 0x04012183 RID: 74115
	private BeTownPlayerMain mainPlayer;

	// Token: 0x04012184 RID: 74116
	private GameObject goActor;

	// Token: 0x04012185 RID: 74117
	private TaskGuideArrow.TaskGuideDir m_eDir = TaskGuideArrow.TaskGuideDir.TGD_INVALID;

	// Token: 0x04012186 RID: 74118
	private int iNpcID;

	// Token: 0x04012187 RID: 74119
	private float fMaxDistance = 5.2f;

	// Token: 0x04012188 RID: 74120
	private Vector3 target = Vector3.zero;

	// Token: 0x04012189 RID: 74121
	private bool bNeedUpdate;
}
