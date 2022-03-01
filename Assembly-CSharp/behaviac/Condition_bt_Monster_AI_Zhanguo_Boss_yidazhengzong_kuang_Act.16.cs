using System;

namespace behaviac
{
	// Token: 0x02003EB7 RID: 16055
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node32 : Condition
	{
		// Token: 0x060164EC RID: 91372 RVA: 0x006BEEFF File Offset: 0x006BD2FF
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node32()
		{
			this.opl_p0 = 7283;
		}

		// Token: 0x060164ED RID: 91373 RVA: 0x006BEF14 File Offset: 0x006BD314
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD20 RID: 64800
		private int opl_p0;
	}
}
