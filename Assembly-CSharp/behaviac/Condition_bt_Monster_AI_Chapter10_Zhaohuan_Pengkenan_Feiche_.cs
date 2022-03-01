using System;

namespace behaviac
{
	// Token: 0x0200315A RID: 12634
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node3 : Condition
	{
		// Token: 0x06014B52 RID: 84818 RVA: 0x0063C852 File Offset: 0x0063AC52
		public Condition_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_node3()
		{
			this.opl_p0 = 20434;
		}

		// Token: 0x06014B53 RID: 84819 RVA: 0x0063C868 File Offset: 0x0063AC68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4CC RID: 58572
		private int opl_p0;
	}
}
