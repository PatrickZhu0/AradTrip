using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001142 RID: 4418
	public class BeFightBuff
	{
		// Token: 0x0600A88D RID: 43149 RVA: 0x00238460 File Offset: 0x00236860
		public BeFightBuff(int id, ulong objId, ulong playerGuid, float leftTime, int overlay)
		{
			this.guid = objId;
			this.buffID = id;
			this.playerId = playerGuid;
			this.m_leftTime = leftTime;
			this.m_overLay = overlay;
			this.table = Singleton<TableManager>.GetInstance().GetTableItem<ChijiBuffTable>(id, string.Empty, string.Empty);
		}

		// Token: 0x170019FE RID: 6654
		// (get) Token: 0x0600A88E RID: 43150 RVA: 0x002384B3 File Offset: 0x002368B3
		public int BuffID
		{
			get
			{
				return this.buffID;
			}
		}

		// Token: 0x170019FF RID: 6655
		// (get) Token: 0x0600A88F RID: 43151 RVA: 0x002384BB File Offset: 0x002368BB
		public ulong GUID
		{
			get
			{
				return this.guid;
			}
		}

		// Token: 0x17001A00 RID: 6656
		// (get) Token: 0x0600A890 RID: 43152 RVA: 0x002384C3 File Offset: 0x002368C3
		public ulong PlayerGUID
		{
			get
			{
				return this.playerId;
			}
		}

		// Token: 0x17001A01 RID: 6657
		// (get) Token: 0x0600A891 RID: 43153 RVA: 0x002384CB File Offset: 0x002368CB
		public ChijiBuffTable Table
		{
			get
			{
				return this.table;
			}
		}

		// Token: 0x17001A02 RID: 6658
		// (get) Token: 0x0600A892 RID: 43154 RVA: 0x002384D3 File Offset: 0x002368D3
		public float LeftTime
		{
			get
			{
				return this.m_leftTime;
			}
		}

		// Token: 0x0600A893 RID: 43155 RVA: 0x002384DB File Offset: 0x002368DB
		public void Refresh(float leftTime, int overlay)
		{
			this.m_leftTime = leftTime;
			this.m_overLay = overlay;
			if (this.geEffect != null)
			{
				this.geEffect.SetTimeLen(99999999);
			}
		}

		// Token: 0x17001A03 RID: 6659
		// (get) Token: 0x0600A894 RID: 43156 RVA: 0x00238506 File Offset: 0x00236906
		public int OverLay
		{
			get
			{
				return this.m_overLay;
			}
		}

		// Token: 0x0600A895 RID: 43157 RVA: 0x0023850E File Offset: 0x0023690E
		public void Update(float elapseTime)
		{
			if (this.m_leftTime <= 0f)
			{
				return;
			}
			this.m_leftTime -= elapseTime;
		}

		// Token: 0x0600A896 RID: 43158 RVA: 0x0023852F File Offset: 0x0023692F
		public void DeInit()
		{
			this.geEffect = null;
		}

		// Token: 0x0600A897 RID: 43159 RVA: 0x00238538 File Offset: 0x00236938
		public void Start(GeActorEx master)
		{
			if (master != null && this.table != null)
			{
				DAssetObject effectRes;
				effectRes.m_AssetObj = null;
				effectRes.m_AssetPath = this.table.EffectName;
				EffectsFrames effectsFrames = new EffectsFrames();
				effectsFrames.localPosition = new Vector3(0f, 0f, 0f);
				effectsFrames.timetype = EffectTimeType.BUFF;
				if (Utility.IsStringValid(this.table.EffectLocateName))
				{
					effectsFrames.attachname = this.table.EffectLocateName;
				}
				bool isLowLevelShow = this.table.IsLowLevelShow;
				this.geEffect = master.CreateEffect(effectRes, effectsFrames, 99999f, new Vec3(0f, 0f, 0f), 1f, 1f, this.table.EffectLoop, isLowLevelShow, false);
			}
		}

		// Token: 0x0600A898 RID: 43160 RVA: 0x00238607 File Offset: 0x00236A07
		public void Finish(GeActorEx master)
		{
			if (master != null && this.geEffect != null)
			{
				master.DestroyEffect(this.geEffect);
			}
		}

		// Token: 0x04005E29 RID: 24105
		private int buffID;

		// Token: 0x04005E2A RID: 24106
		private ulong guid;

		// Token: 0x04005E2B RID: 24107
		private ulong playerId;

		// Token: 0x04005E2C RID: 24108
		private ChijiBuffTable table;

		// Token: 0x04005E2D RID: 24109
		private GeEffectEx geEffect;

		// Token: 0x04005E2E RID: 24110
		private float m_leftTime;

		// Token: 0x04005E2F RID: 24111
		private int m_overLay;
	}
}
