using System;

namespace behaviac
{
	// Token: 0x0200357C RID: 13692
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node6 : Condition
	{
		// Token: 0x0601532B RID: 86827 RVA: 0x006638DB File Offset: 0x00661CDB
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaoBOSS_Event_node6()
		{
			this.opl_p0 = 5462;
		}

		// Token: 0x0601532C RID: 86828 RVA: 0x006638F0 File Offset: 0x00661CF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECEF RID: 60655
		private int opl_p0;
	}
}
