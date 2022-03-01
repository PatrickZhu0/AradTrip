using System;

namespace behaviac
{
	// Token: 0x02003EB2 RID: 16050
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node14 : Condition
	{
		// Token: 0x060164E2 RID: 91362 RVA: 0x006BED05 File Offset: 0x006BD105
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node14()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060164E3 RID: 91363 RVA: 0x006BED18 File Offset: 0x006BD118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD17 RID: 64791
		private float opl_p0;
	}
}
