using System;

namespace behaviac
{
	// Token: 0x02003594 RID: 13716
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node5 : Condition
	{
		// Token: 0x06015358 RID: 86872 RVA: 0x006647D7 File Offset: 0x00662BD7
		public Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06015359 RID: 86873 RVA: 0x00664808 File Offset: 0x00662C08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED1D RID: 60701
		private int opl_p0;

		// Token: 0x0400ED1E RID: 60702
		private int opl_p1;

		// Token: 0x0400ED1F RID: 60703
		private int opl_p2;

		// Token: 0x0400ED20 RID: 60704
		private int opl_p3;
	}
}
