using System;

namespace behaviac
{
	// Token: 0x020028AA RID: 10410
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node26 : Condition
	{
		// Token: 0x06013A8E RID: 80526 RVA: 0x005DEF19 File Offset: 0x005DD319
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node26()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013A8F RID: 80527 RVA: 0x005DEF2C File Offset: 0x005DD32C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4EC RID: 54508
		private float opl_p0;
	}
}
