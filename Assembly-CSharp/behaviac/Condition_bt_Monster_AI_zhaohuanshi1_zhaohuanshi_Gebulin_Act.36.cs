using System;

namespace behaviac
{
	// Token: 0x02004064 RID: 16484
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node62 : Condition
	{
		// Token: 0x06016827 RID: 92199 RVA: 0x006CFBF1 File Offset: 0x006CDFF1
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node62()
		{
			this.opl_p0 = 5110;
		}

		// Token: 0x06016828 RID: 92200 RVA: 0x006CFC04 File Offset: 0x006CE004
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010073 RID: 65651
		private int opl_p0;
	}
}
