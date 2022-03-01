using System;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02004609 RID: 17929
public class NpcDialogComponent : MonoBehaviour
{
	// Token: 0x170020B2 RID: 8370
	// (get) Token: 0x06019337 RID: 103223 RVA: 0x007F8CA3 File Offset: 0x007F70A3
	public int ID
	{
		get
		{
			return this.iNpcID;
		}
	}

	// Token: 0x170020B3 RID: 8371
	// (get) Token: 0x06019338 RID: 103224 RVA: 0x007F8CAB File Offset: 0x007F70AB
	public float NextTick
	{
		get
		{
			return this.fLastTick + this.fTickInterval;
		}
	}

	// Token: 0x170020B4 RID: 8372
	// (get) Token: 0x06019339 RID: 103225 RVA: 0x007F8CBA File Offset: 0x007F70BA
	public int TickPower
	{
		get
		{
			return this.iTickPower;
		}
	}

	// Token: 0x0601933A RID: 103226 RVA: 0x007F8CC4 File Offset: 0x007F70C4
	public void BeginTick()
	{
		this.iTickPower++;
		if (this.contents.Length > 0)
		{
			this.fBeginTick = Time.time;
			base.transform.gameObject.CustomActive(true);
			if (this.eDialogShowType == NpcTable.eDialogType.random)
			{
				this.iCurIndex = Random.Range(0, this.contents.Length - 1);
			}
			else if (this.eDialogShowType == NpcTable.eDialogType.trival)
			{
				this.iCurIndex = (this.iCurIndex + 1) % this.contents.Length;
			}
			if (this.uiText != null)
			{
				this.uiText.SetText(this.contents[this.iCurIndex], false);
			}
			this.m_bInterval = true;
		}
	}

	// Token: 0x0601933B RID: 103227 RVA: 0x007F8D84 File Offset: 0x007F7184
	public void EndTick()
	{
		this.fLastTick += this.fTickInterval;
	}

	// Token: 0x170020B5 RID: 8373
	// (get) Token: 0x0601933C RID: 103228 RVA: 0x007F8D99 File Offset: 0x007F7199
	public bool InTick
	{
		get
		{
			return this.m_bInterval;
		}
	}

	// Token: 0x0601933D RID: 103229 RVA: 0x007F8DA4 File Offset: 0x007F71A4
	public void Initialize(Vector3 worldPos, int iNpcID, NpcDialogComponent.IdBelong2 eIdBelong2 = NpcDialogComponent.IdBelong2.IdBelong2_NpcTable)
	{
		this.eDialogShowType = NpcTable.eDialogType.trival;
		this.goChildText = base.transform.Find("content").gameObject;
		this.uiText = this.goChildText.GetComponent<LinkParse>();
		base.transform.gameObject.SetActive(false);
		this.iCurIndex = 0;
		this.fLastTick = 0f;
		if (eIdBelong2 == NpcDialogComponent.IdBelong2.IdBelong2_NpcTable)
		{
			this.iNpcID = iNpcID;
			this.npcTable = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iNpcID, string.Empty, string.Empty);
			if (this.npcTable != null)
			{
				this.contents = this.GetContents(this.npcTable.TalkContent);
				this.fTickInterval = (float)this.npcTable.Interval * 1f / 1000f;
			}
		}
		else if (eIdBelong2 == NpcDialogComponent.IdBelong2.IdBelong2_FollowPetTable)
		{
		}
		this.UpdateWorldPosition(worldPos);
		this.m_bInterval = false;
	}

	// Token: 0x0601933E RID: 103230 RVA: 0x007F8E89 File Offset: 0x007F7289
	public void UpdateWorldPosition(Vector3 worldPos)
	{
		if (worldPos != Vector3.zero)
		{
			base.transform.position = worldPos;
		}
	}

	// Token: 0x0601933F RID: 103231 RVA: 0x007F8EA8 File Offset: 0x007F72A8
	public bool Tick(float fDelta)
	{
		if (this.m_bInterval)
		{
			if (this.fBeginTick + this.fTickInterval + NpcDialogComponent.ms_common_interval < Time.time)
			{
				this.m_bInterval = false;
			}
			else if (this.fBeginTick + this.fTickInterval < Time.time)
			{
				base.transform.gameObject.CustomActive(false);
			}
		}
		return this.m_bInterval;
	}

	// Token: 0x06019340 RID: 103232 RVA: 0x007F8F17 File Offset: 0x007F7317
	public void SetContentText()
	{
		if (this.contents.Length > 0 && this.uiText != null)
		{
			this.uiText.SetText(this.contents[0], false);
		}
	}

	// Token: 0x06019341 RID: 103233 RVA: 0x007F8F4C File Offset: 0x007F734C
	private string[] GetContents(string orgContent)
	{
		string[] result = new string[0];
		if (orgContent != null && orgContent.Length > 0)
		{
			result = orgContent.Split(new char[]
			{
				'\r',
				'\n'
			});
		}
		return result;
	}

	// Token: 0x040120E4 RID: 73956
	private static float ms_common_interval = 30f;

	// Token: 0x040120E5 RID: 73957
	private GameObject goChildText;

	// Token: 0x040120E6 RID: 73958
	private LinkParse uiText;

	// Token: 0x040120E7 RID: 73959
	private float fLastTick;

	// Token: 0x040120E8 RID: 73960
	private float fBeginTick;

	// Token: 0x040120E9 RID: 73961
	private float fTickInterval = 3f;

	// Token: 0x040120EA RID: 73962
	private int iTickPower;

	// Token: 0x040120EB RID: 73963
	private string[] contents = new string[0];

	// Token: 0x040120EC RID: 73964
	private int iCurIndex;

	// Token: 0x040120ED RID: 73965
	private NpcTable npcTable;

	// Token: 0x040120EE RID: 73966
	private NpcTable.eDialogType eDialogShowType = NpcTable.eDialogType.trival;

	// Token: 0x040120EF RID: 73967
	private int iNpcID;

	// Token: 0x040120F0 RID: 73968
	private NpcDialogComponent.IdBelong2 eIdBelong2;

	// Token: 0x040120F1 RID: 73969
	private bool m_bInterval;

	// Token: 0x0200460A RID: 17930
	public enum IdBelong2
	{
		// Token: 0x040120F3 RID: 73971
		IdBelong2_NpcTable,
		// Token: 0x040120F4 RID: 73972
		IdBelong2_UnitTable,
		// Token: 0x040120F5 RID: 73973
		IdBelong2_FollowPetTable
	}
}
