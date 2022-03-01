using System;

namespace behaviac
{
	// Token: 0x0200324F RID: 12879
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node9 : Condition
	{
		// Token: 0x06014D1E RID: 85278 RVA: 0x00645C62 File Offset: 0x00644062
		public Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node9()
		{
			this.opl_p0 = 21503;
		}

		// Token: 0x06014D1F RID: 85279 RVA: 0x00645C78 File Offset: 0x00644078
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E66B RID: 58987
		private int opl_p0;
	}
}
