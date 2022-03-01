using System;

namespace behaviac
{
	// Token: 0x02003FF0 RID: 16368
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node11 : Condition
	{
		// Token: 0x06016746 RID: 91974 RVA: 0x006CB8FD File Offset: 0x006C9CFD
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node11()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x06016747 RID: 91975 RVA: 0x006CB910 File Offset: 0x006C9D10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF98 RID: 65432
		private int opl_p0;
	}
}
