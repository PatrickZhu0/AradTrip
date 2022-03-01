using System;

namespace behaviac
{
	// Token: 0x02003184 RID: 12676
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node24 : Condition
	{
		// Token: 0x06014B9F RID: 84895 RVA: 0x0063D8F1 File Offset: 0x0063BCF1
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node24()
		{
			this.opl_p0 = 21542;
		}

		// Token: 0x06014BA0 RID: 84896 RVA: 0x0063D904 File Offset: 0x0063BD04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E50C RID: 58636
		private int opl_p0;
	}
}
