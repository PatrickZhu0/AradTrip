using System;

namespace behaviac
{
	// Token: 0x02002CE7 RID: 11495
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node24 : Condition
	{
		// Token: 0x060142BE RID: 82622 RVA: 0x0060ED3D File Offset: 0x0060D13D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node24()
		{
			this.opl_p0 = 20746;
		}

		// Token: 0x060142BF RID: 82623 RVA: 0x0060ED50 File Offset: 0x0060D150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC6D RID: 56429
		private int opl_p0;
	}
}
