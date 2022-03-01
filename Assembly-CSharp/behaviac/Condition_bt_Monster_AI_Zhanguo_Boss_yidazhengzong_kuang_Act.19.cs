using System;

namespace behaviac
{
	// Token: 0x02003EBB RID: 16059
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node25 : Condition
	{
		// Token: 0x060164F4 RID: 91380 RVA: 0x006BF1C7 File Offset: 0x006BD5C7
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node25()
		{
			this.opl_p0 = 7283;
		}

		// Token: 0x060164F5 RID: 91381 RVA: 0x006BF1DC File Offset: 0x006BD5DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD28 RID: 64808
		private int opl_p0;
	}
}
