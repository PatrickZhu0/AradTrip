using System;

namespace behaviac
{
	// Token: 0x0200221A RID: 8730
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node49 : Condition
	{
		// Token: 0x06012DBE RID: 77246 RVA: 0x0058DBA3 File Offset: 0x0058BFA3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node49()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012DBF RID: 77247 RVA: 0x0058DBB8 File Offset: 0x0058BFB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7B6 RID: 51126
		private float opl_p0;
	}
}
