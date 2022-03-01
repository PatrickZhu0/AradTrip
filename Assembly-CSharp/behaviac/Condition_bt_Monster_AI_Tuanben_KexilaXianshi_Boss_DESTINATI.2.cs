using System;

namespace behaviac
{
	// Token: 0x02003A80 RID: 14976
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node64 : Condition
	{
		// Token: 0x06015CC7 RID: 89287 RVA: 0x006965A3 File Offset: 0x006949A3
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node64()
		{
			this.opl_p0 = 6600;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015CC8 RID: 89288 RVA: 0x006965D8 File Offset: 0x006949D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F601 RID: 62977
		private int opl_p0;

		// Token: 0x0400F602 RID: 62978
		private int opl_p1;

		// Token: 0x0400F603 RID: 62979
		private int opl_p2;

		// Token: 0x0400F604 RID: 62980
		private int opl_p3;
	}
}
