using System;

namespace behaviac
{
	// Token: 0x020023D2 RID: 9170
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node7 : Condition
	{
		// Token: 0x06013109 RID: 78089 RVA: 0x005A6E43 File Offset: 0x005A5243
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node7()
		{
			this.opl_p0 = EventType.OnBeforeOtherHit;
		}

		// Token: 0x0601310A RID: 78090 RVA: 0x005A6E54 File Offset: 0x005A5254
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB3B RID: 52027
		private EventType opl_p0;
	}
}
