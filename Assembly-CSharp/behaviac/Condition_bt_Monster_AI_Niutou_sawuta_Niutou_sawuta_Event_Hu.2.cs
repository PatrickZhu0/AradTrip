using System;

namespace behaviac
{
	// Token: 0x02003718 RID: 14104
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3 : Condition
	{
		// Token: 0x0601563D RID: 87613 RVA: 0x006741E3 File Offset: 0x006725E3
		public Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node3()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601563E RID: 87614 RVA: 0x00674214 File Offset: 0x00672614
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F007 RID: 61447
		private int opl_p0;

		// Token: 0x0400F008 RID: 61448
		private int opl_p1;

		// Token: 0x0400F009 RID: 61449
		private int opl_p2;

		// Token: 0x0400F00A RID: 61450
		private int opl_p3;
	}
}
