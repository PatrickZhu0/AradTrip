using System;

namespace behaviac
{
	// Token: 0x0200409D RID: 16541
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node16 : Condition
	{
		// Token: 0x06016895 RID: 92309 RVA: 0x006D2C8D File Offset: 0x006D108D
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node16()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x06016896 RID: 92310 RVA: 0x006D2CA0 File Offset: 0x006D10A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100DF RID: 65759
		private int opl_p0;
	}
}
