using System;

namespace behaviac
{
	// Token: 0x0200370C RID: 14092
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node4 : Condition
	{
		// Token: 0x06015626 RID: 87590 RVA: 0x00673A61 File Offset: 0x00671E61
		public Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06015627 RID: 87591 RVA: 0x00673A80 File Offset: 0x00671E80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFEF RID: 61423
		private BE_Target opl_p0;

		// Token: 0x0400EFF0 RID: 61424
		private BE_Equal opl_p1;

		// Token: 0x0400EFF1 RID: 61425
		private BE_State opl_p2;
	}
}
