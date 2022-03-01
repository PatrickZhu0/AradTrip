using System;

namespace behaviac
{
	// Token: 0x02002446 RID: 9286
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node8 : Condition
	{
		// Token: 0x060131E0 RID: 78304 RVA: 0x005ABD90 File Offset: 0x005AA190
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node8()
		{
			this.opl_p0 = 0.56f;
		}

		// Token: 0x060131E1 RID: 78305 RVA: 0x005ABDA4 File Offset: 0x005AA1A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC09 RID: 52233
		private float opl_p0;
	}
}
