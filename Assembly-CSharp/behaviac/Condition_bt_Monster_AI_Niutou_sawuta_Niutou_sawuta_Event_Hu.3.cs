using System;

namespace behaviac
{
	// Token: 0x02003719 RID: 14105
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4 : Condition
	{
		// Token: 0x0601563F RID: 87615 RVA: 0x00674259 File Offset: 0x00672659
		public Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06015640 RID: 87616 RVA: 0x00674278 File Offset: 0x00672678
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F00B RID: 61451
		private BE_Target opl_p0;

		// Token: 0x0400F00C RID: 61452
		private BE_Equal opl_p1;

		// Token: 0x0400F00D RID: 61453
		private BE_State opl_p2;
	}
}
