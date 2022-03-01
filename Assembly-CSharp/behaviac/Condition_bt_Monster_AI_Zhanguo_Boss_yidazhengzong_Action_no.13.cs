using System;

namespace behaviac
{
	// Token: 0x02003E86 RID: 16006
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node20 : Condition
	{
		// Token: 0x0601648D RID: 91277 RVA: 0x006BCD97 File Offset: 0x006BB197
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node20()
		{
			this.opl_p0 = 7283;
		}

		// Token: 0x0601648E RID: 91278 RVA: 0x006BCDAC File Offset: 0x006BB1AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCC5 RID: 64709
		private int opl_p0;
	}
}
