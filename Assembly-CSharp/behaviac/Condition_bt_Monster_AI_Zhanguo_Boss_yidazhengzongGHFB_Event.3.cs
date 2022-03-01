using System;

namespace behaviac
{
	// Token: 0x02003E73 RID: 15987
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node4 : Condition
	{
		// Token: 0x06016468 RID: 91240 RVA: 0x006BC45B File Offset: 0x006BA85B
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzongGHFB_Event_node4()
		{
			this.opl_p0 = 20054;
		}

		// Token: 0x06016469 RID: 91241 RVA: 0x006BC470 File Offset: 0x006BA870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCA1 RID: 64673
		private int opl_p0;
	}
}
