using System;

namespace behaviac
{
	// Token: 0x02002CDF RID: 11487
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node7 : Condition
	{
		// Token: 0x060142AE RID: 82606 RVA: 0x0060EA3D File Offset: 0x0060CE3D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node7()
		{
			this.opl_p0 = 20744;
		}

		// Token: 0x060142AF RID: 82607 RVA: 0x0060EA50 File Offset: 0x0060CE50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC5F RID: 56415
		private int opl_p0;
	}
}
