using System;

namespace behaviac
{
	// Token: 0x02003A7A RID: 14970
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node59 : Condition
	{
		// Token: 0x06015CBD RID: 89277 RVA: 0x00694D7A File Offset: 0x0069317A
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node59()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015CBE RID: 89278 RVA: 0x00694DB0 File Offset: 0x006931B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5F7 RID: 62967
		private int opl_p0;

		// Token: 0x0400F5F8 RID: 62968
		private int opl_p1;

		// Token: 0x0400F5F9 RID: 62969
		private int opl_p2;

		// Token: 0x0400F5FA RID: 62970
		private int opl_p3;
	}
}
