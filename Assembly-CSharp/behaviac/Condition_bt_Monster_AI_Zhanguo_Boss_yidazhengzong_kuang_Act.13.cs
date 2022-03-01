using System;

namespace behaviac
{
	// Token: 0x02003EB3 RID: 16051
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node15 : Condition
	{
		// Token: 0x060164E4 RID: 91364 RVA: 0x006BED4B File Offset: 0x006BD14B
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node15()
		{
			this.opl_p0 = 7285;
		}

		// Token: 0x060164E5 RID: 91365 RVA: 0x006BED60 File Offset: 0x006BD160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD18 RID: 64792
		private int opl_p0;
	}
}
