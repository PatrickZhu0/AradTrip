using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02002537 RID: 9527
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node62 : Action
	{
		// Token: 0x060133B7 RID: 78775 RVA: 0x005B6AA8 File Offset: 0x005B4EA8
		public Action_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node62()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = new List<Input>();
			this.method_p0.Capacity = 1;
			Input item = default(Input);
			item.delay = 0;
			item.moveInSkillState = false;
			item.moveKeepDistance = 0;
			item.PKRobotComboCheck = false;
			item.pressTime = 1100;
			item.randomChangeDirection = false;
			item.skillID = 2609;
			item.specialChoice = 0;
			this.method_p0.Add(item);
			this.method_p1 = false;
		}

		// Token: 0x060133B8 RID: 78776 RVA: 0x005B6B3C File Offset: 0x005B4F3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoAction(ref this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDDD RID: 52701
		private List<Input> method_p0;

		// Token: 0x0400CDDE RID: 52702
		private bool method_p1;
	}
}
