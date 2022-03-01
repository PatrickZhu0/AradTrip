using System;

namespace behaviac
{
	// Token: 0x020036DE RID: 14046
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node13 : Condition
	{
		// Token: 0x060155D2 RID: 87506 RVA: 0x00671FAB File Offset: 0x006703AB
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node13()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x060155D3 RID: 87507 RVA: 0x00671FCC File Offset: 0x006703CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFA5 RID: 61349
		private HMType opl_p0;

		// Token: 0x0400EFA6 RID: 61350
		private BE_Operation opl_p1;

		// Token: 0x0400EFA7 RID: 61351
		private float opl_p2;
	}
}
