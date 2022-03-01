using System;

namespace behaviac
{
	// Token: 0x02002BA0 RID: 11168
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node0 : Condition
	{
		// Token: 0x06014049 RID: 81993 RVA: 0x0060312B File Offset: 0x0060152B
		public Condition_bt_Monster_AI_65Tuanben_65TB_JDYS_Greeen_Action_node0()
		{
			this.opl_p0 = 20774;
		}

		// Token: 0x0601404A RID: 81994 RVA: 0x00603140 File Offset: 0x00601540
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA42 RID: 55874
		private int opl_p0;
	}
}
