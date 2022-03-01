using System;

namespace behaviac
{
	// Token: 0x020028D1 RID: 10449
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node62 : Condition
	{
		// Token: 0x06013ADC RID: 80604 RVA: 0x005E00DA File Offset: 0x005DE4DA
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node62()
		{
			this.opl_p0 = 0.56f;
		}

		// Token: 0x06013ADD RID: 80605 RVA: 0x005E00F0 File Offset: 0x005DE4F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D53C RID: 54588
		private float opl_p0;
	}
}
