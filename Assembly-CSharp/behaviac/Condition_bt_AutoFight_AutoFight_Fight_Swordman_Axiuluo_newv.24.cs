using System;

namespace behaviac
{
	// Token: 0x02002220 RID: 8736
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node56 : Condition
	{
		// Token: 0x06012DCA RID: 77258 RVA: 0x0058E18F File Offset: 0x0058C58F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Action_node56()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012DCB RID: 77259 RVA: 0x0058E1A4 File Offset: 0x0058C5A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7C2 RID: 51138
		private int opl_p0;
	}
}
