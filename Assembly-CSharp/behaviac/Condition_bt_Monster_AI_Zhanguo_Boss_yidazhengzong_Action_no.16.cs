using System;

namespace behaviac
{
	// Token: 0x02003E8A RID: 16010
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node32 : Condition
	{
		// Token: 0x06016495 RID: 91285 RVA: 0x006BD003 File Offset: 0x006BB403
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node32()
		{
			this.opl_p0 = 7283;
		}

		// Token: 0x06016496 RID: 91286 RVA: 0x006BD018 File Offset: 0x006BB418
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCCD RID: 64717
		private int opl_p0;
	}
}
