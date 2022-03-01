using System;

namespace behaviac
{
	// Token: 0x02003664 RID: 13924
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node24 : Condition
	{
		// Token: 0x060154EA RID: 87274 RVA: 0x0066CB6F File Offset: 0x0066AF6F
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node24()
		{
			this.opl_p0 = 5424;
		}

		// Token: 0x060154EB RID: 87275 RVA: 0x0066CB84 File Offset: 0x0066AF84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEA2 RID: 61090
		private int opl_p0;
	}
}
