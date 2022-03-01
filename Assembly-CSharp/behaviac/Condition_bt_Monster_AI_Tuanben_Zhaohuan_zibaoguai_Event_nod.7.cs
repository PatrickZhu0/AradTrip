using System;

namespace behaviac
{
	// Token: 0x02003B85 RID: 15237
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node1 : Condition
	{
		// Token: 0x06015EBC RID: 89788 RVA: 0x0069FAB9 File Offset: 0x0069DEB9
		public Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node1()
		{
			this.opl_p0 = 21360;
		}

		// Token: 0x06015EBD RID: 89789 RVA: 0x0069FACC File Offset: 0x0069DECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F77F RID: 63359
		private int opl_p0;
	}
}
