using System;

namespace behaviac
{
	// Token: 0x020022E1 RID: 8929
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node7 : Condition
	{
		// Token: 0x06012F3C RID: 77628 RVA: 0x00599C07 File Offset: 0x00598007
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node7()
		{
			this.opl_p0 = EventType.OnBeforeOtherHit;
		}

		// Token: 0x06012F3D RID: 77629 RVA: 0x00599C18 File Offset: 0x00598018
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C950 RID: 51536
		private EventType opl_p0;
	}
}
