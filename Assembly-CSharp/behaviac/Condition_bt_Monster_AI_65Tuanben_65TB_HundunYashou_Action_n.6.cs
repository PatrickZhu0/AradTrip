using System;

namespace behaviac
{
	// Token: 0x02002B89 RID: 11145
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node2 : Condition
	{
		// Token: 0x0601401E RID: 81950 RVA: 0x00601FF6 File Offset: 0x006003F6
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node2()
		{
			this.opl_p0 = 20763;
		}

		// Token: 0x0601401F RID: 81951 RVA: 0x0060200C File Offset: 0x0060040C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA17 RID: 55831
		private int opl_p0;
	}
}
