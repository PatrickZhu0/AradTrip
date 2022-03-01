using System;

namespace behaviac
{
	// Token: 0x02002623 RID: 9763
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node90 : Condition
	{
		// Token: 0x0601358C RID: 79244 RVA: 0x005C14CD File Offset: 0x005BF8CD
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node90()
		{
			this.opl_p0 = 1007;
		}

		// Token: 0x0601358D RID: 79245 RVA: 0x005C14E0 File Offset: 0x005BF8E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFDB RID: 53211
		private int opl_p0;
	}
}
