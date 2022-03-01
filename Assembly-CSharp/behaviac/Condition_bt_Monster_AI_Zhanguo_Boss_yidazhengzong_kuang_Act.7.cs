using System;

namespace behaviac
{
	// Token: 0x02003EAB RID: 16043
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node4 : Condition
	{
		// Token: 0x060164D4 RID: 91348 RVA: 0x006BE987 File Offset: 0x006BCD87
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node4()
		{
			this.opl_p0 = 7286;
		}

		// Token: 0x060164D5 RID: 91349 RVA: 0x006BE99C File Offset: 0x006BCD9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD08 RID: 64776
		private int opl_p0;
	}
}
