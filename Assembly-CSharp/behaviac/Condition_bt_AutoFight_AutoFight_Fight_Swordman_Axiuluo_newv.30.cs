using System;

namespace behaviac
{
	// Token: 0x02002228 RID: 8744
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node61 : Condition
	{
		// Token: 0x06012DDA RID: 77274 RVA: 0x0058E929 File Offset: 0x0058CD29
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node61()
		{
			this.opl_p0 = 1700;
		}

		// Token: 0x06012DDB RID: 77275 RVA: 0x0058E93C File Offset: 0x0058CD3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7D6 RID: 51158
		private int opl_p0;
	}
}
