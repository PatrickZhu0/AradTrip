using System;

namespace behaviac
{
	// Token: 0x02002215 RID: 8725
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node38 : Condition
	{
		// Token: 0x06012DB4 RID: 77236 RVA: 0x0058D65B File Offset: 0x0058BA5B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node38()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012DB5 RID: 77237 RVA: 0x0058D670 File Offset: 0x0058BA70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7AB RID: 51115
		private float opl_p0;
	}
}
