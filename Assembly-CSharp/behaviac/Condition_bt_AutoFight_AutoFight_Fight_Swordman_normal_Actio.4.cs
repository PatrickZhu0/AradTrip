using System;

namespace behaviac
{
	// Token: 0x0200243D RID: 9277
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node13 : Condition
	{
		// Token: 0x060131D0 RID: 78288 RVA: 0x005AB943 File Offset: 0x005A9D43
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x060131D1 RID: 78289 RVA: 0x005AB958 File Offset: 0x005A9D58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBFA RID: 52218
		private int opl_p0;
	}
}
