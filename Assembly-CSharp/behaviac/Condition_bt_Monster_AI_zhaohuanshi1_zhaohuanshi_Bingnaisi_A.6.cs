using System;

namespace behaviac
{
	// Token: 0x02004028 RID: 16424
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node12 : Condition
	{
		// Token: 0x060167B1 RID: 92081 RVA: 0x006CDD85 File Offset: 0x006CC185
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_Action_node12()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x060167B2 RID: 92082 RVA: 0x006CDD98 File Offset: 0x006CC198
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFFF RID: 65535
		private int opl_p0;
	}
}
