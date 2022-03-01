using System;

namespace behaviac
{
	// Token: 0x020035F2 RID: 13810
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node37 : Condition
	{
		// Token: 0x0601540A RID: 87050 RVA: 0x006681D9 File Offset: 0x006665D9
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node37()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x0601540B RID: 87051 RVA: 0x006681E8 File Offset: 0x006665E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDC3 RID: 60867
		private EventType opl_p0;
	}
}
