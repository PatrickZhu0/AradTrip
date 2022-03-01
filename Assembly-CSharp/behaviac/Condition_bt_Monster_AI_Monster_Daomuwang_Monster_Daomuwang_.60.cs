using System;

namespace behaviac
{
	// Token: 0x0200366D RID: 13933
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node4 : Condition
	{
		// Token: 0x060154FB RID: 87291 RVA: 0x0066D66B File Offset: 0x0066BA6B
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node4()
		{
			this.opl_p0 = 5428;
		}

		// Token: 0x060154FC RID: 87292 RVA: 0x0066D680 File Offset: 0x0066BA80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEB2 RID: 61106
		private int opl_p0;
	}
}
