using System;

namespace behaviac
{
	// Token: 0x020036CF RID: 14031
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node3 : Condition
	{
		// Token: 0x060155B5 RID: 87477 RVA: 0x0067170F File Offset: 0x0066FB0F
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node3()
		{
			this.opl_p0 = 5432;
		}

		// Token: 0x060155B6 RID: 87478 RVA: 0x00671724 File Offset: 0x0066FB24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF88 RID: 61320
		private int opl_p0;
	}
}
