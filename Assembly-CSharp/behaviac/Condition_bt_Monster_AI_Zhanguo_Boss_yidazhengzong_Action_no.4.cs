using System;

namespace behaviac
{
	// Token: 0x02003E7A RID: 15994
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node4 : Condition
	{
		// Token: 0x06016475 RID: 91253 RVA: 0x006BC81F File Offset: 0x006BAC1F
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node4()
		{
			this.opl_p0 = 7286;
		}

		// Token: 0x06016476 RID: 91254 RVA: 0x006BC834 File Offset: 0x006BAC34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCAD RID: 64685
		private int opl_p0;
	}
}
