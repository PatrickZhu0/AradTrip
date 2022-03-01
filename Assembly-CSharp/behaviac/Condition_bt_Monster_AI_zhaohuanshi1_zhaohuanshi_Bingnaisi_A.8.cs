using System;

namespace behaviac
{
	// Token: 0x0200402B RID: 16427
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node15 : Condition
	{
		// Token: 0x060167B7 RID: 92087 RVA: 0x006CDEBF File Offset: 0x006CC2BF
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x060167B8 RID: 92088 RVA: 0x006CDEF4 File Offset: 0x006CC2F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010003 RID: 65539
		private int opl_p0;

		// Token: 0x04010004 RID: 65540
		private int opl_p1;

		// Token: 0x04010005 RID: 65541
		private int opl_p2;

		// Token: 0x04010006 RID: 65542
		private int opl_p3;
	}
}
