using System;

namespace behaviac
{
	// Token: 0x02002239 RID: 8761
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node7 : Condition
	{
		// Token: 0x06012DFB RID: 77307 RVA: 0x005901B5 File Offset: 0x0058E5B5
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_newveryhard_Event_node7()
		{
			this.opl_p0 = EventType.OnBeforeOtherHit;
		}

		// Token: 0x06012DFC RID: 77308 RVA: 0x005901C4 File Offset: 0x0058E5C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C7F9 RID: 51193
		private EventType opl_p0;
	}
}
